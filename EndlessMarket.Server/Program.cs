using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using SQLite;
using Nancy;
using Nancy.Hosting.Self;
using EOLib.Net;
using EOLib.Net.API;
using EOLib.Net.Handlers;
using EOLib.IO;
using EOLib.Net.PacketProcessing;
using EOLib.IO.Services;
using IniParser;
using IniParser.Parser;
using IniParser.Model.Configuration;

namespace EndlessMarket.Server
{
    class Program
    {
        public static SQLiteConnection EODatabase { get; set; }
        public static NancyHost Nancy { get; set; }
        public static EOMarketBot MarketBot { get; set; }

        static void Main(string[] args)
        {
            EODatabase = new SQLiteConnection(@"database.sdb");
            Nancy = new NancyHost(
                new HostConfiguration() { UrlReservations = new UrlReservations() { CreateAutomatically = true } },
                new Uri("http://localhost:8076"));

            Nancy.Start();
            Console.WriteLine($"[Market] API server started.");
            Console.WriteLine($"[Market] There are currently { EODatabase.Table<MarketPlace>().Count() } items for sale in the market database.");

            TryConnectBot();
            Thread.Sleep(1000 * 10);

            while (true)
            {
                // if the market bot doesn't connect within 10 seconds (or is down), attempt restarting the bot.
                if (MarketBot == null || !MarketBot.Client.ConnectedAndInitialized || !MarketBot.API.Initialized)
                {
                    Console.WriteLine($"[Market] Market Bot is currently down. A restart is in process.");
                    TryConnectBot();
                    Thread.Sleep(1000 * 10);
                }

                Thread.Sleep(500);
            }
        }

        public static void TryConnectBot()
        {
            try
            {
                Console.WriteLine($"[Market] Attempting to start Market Bot.");
                MarketBot = new EOMarketBot();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"[Market] Market Bot failed to start. (ex: {exception.Message})");
            }
        }
    }

    public class InventoryItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }

    }
    public class CharacterInventory
    {
        public string Name { get; set; }
        public List<InventoryItem> Items { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class EOMarketBot
    {
        public EOClient Client { get; set; }
        public PacketAPI API { get; set; }
        public ItemFile EIF { get; set; }

        private string Username = "";
        private string Password = "";

        public Queue<string> CommandsQueue = new Queue<string>();
        public string ServerPasswordSalt = "";
        public int ServerPort = 8078;

        public List<CharacterInventory> RequestedInventories =
            new List<CharacterInventory>();

        public EOMarketBot()
        {
            this.EIF = ItemFile.FromBytes(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "data", "pub", "dat001.eif")));
            this.Client = new EOClient(new PacketProcessActions(new SequenceRepository(), new PacketEncoderRepository(), new PacketEncoderService(), new PacketSequenceService()));
            this.API = new PacketAPI(this.Client);

            if (!File.Exists("config/market.ini"))
                throw new Exception("Unable to locate market configuration file.");

            if (!File.Exists("config/server.ini"))
                throw new Exception("Unable to locate server configuration file.");

            var parser = new FileIniDataParser
            (
                new IniDataParser(new IniParserConfiguration() {
                    AllowKeysWithoutSection = true,
                    CommentRegex = new Regex("\\#.*", RegexOptions.Compiled)
                })
            );

            var serverConfig = parser.ReadFile("config/server.ini");
            var marketConfig = parser.ReadFile("config/market.ini");

            if (!serverConfig.TryGetKey("PasswordSalt", out var serverPasswordSalt))
                throw new Exception("Unable to read 'PasswordSalt' from server config.");

            if (!serverConfig.TryGetKey("Port", out var serverPort))
                throw new Exception("Unable to read 'Port' from server config.");

            if (!marketConfig.TryGetKey("MarketAdminAccount", out var marketAdminAccount))
                throw new Exception("Unable to read 'MarketAdminAccount' from market config.");

            this.Username = marketAdminAccount.Split(':')[0];
            this.Password = marketAdminAccount.Split(':')[1];

            this.ServerPasswordSalt = serverPasswordSalt;
            this.ServerPort = int.Parse(serverPort);

            this.Client.ConnectToServer("localhost", this.ServerPort);

            if (!this.API.Initialize(0, 0, 28, new HDSerialNumberService().GetHDSerialNumber(), out var data))
                throw new TimeoutException(string.Format("Failed initialization handshake with server!"));
            this.Client.SetInitData(data);

            if (!this.API.ConfirmInit(data.emulti_e, data.emulti_d, data.clientID))
                throw new TimeoutException(string.Format("Failed initialization handshake with server!"));

            if (!this.API.Initialized || !this.Client.ConnectedAndInitialized || data.ServerResponse != InitReply.INIT_OK)
                throw new InvalidOperationException(string.Format("Invalid response from server or connection failed! Must receive an OK reply."));

            if (!this.API.LoginRequest(this.Username, this.Password, out var reply, out var loginData))
                throw new Exception($"Unable to login to the server. {reply}");

            if (!this.API.SelectCharacter(loginData[0].ID, out var welcomeReqData))
                throw new Exception("Unable to select character.");

            if (!this.API.WelcomeMessage(welcomeReqData.ActiveCharacterID, out var welcomeMsgData))
                throw new Exception("Unable to send welcome message.");

            this.API.OnServerPingReply += (ping) => Console.WriteLine($"[Marketplace Bot] Ping. ({ping})");
            this.Client.AddPacketHandler(new FamilyActionPair(PacketFamily.AdminInteract, PacketAction.List), new PacketHandler((packet) => {
                var name = packet.GetBreakString().Split(' ').Reverse().Skip(1).Take(1).First().ToLower();
                var inventoryItems = new List<(int id, int amount)>();

                packet.Skip(4 + 1 + 4 + 1);

                while (packet.PeekByte() != 255)
                {
                    var id = (int)packet.GetShort();
                    var amount = packet.GetInt();

                    if (id == 1)
                        continue;

                    inventoryItems.Add((id, amount));
                }

                this.RequestedInventories.RemoveAll(p => p.Name == name);

                this.RequestedInventories.Add(new CharacterInventory() {
                    Name = name,
                    Items = inventoryItems.Select(i => new InventoryItem() { Id = i.id, Amount = i.amount }).ToList(),
                    Timestamp = DateTime.Now
                });

            }), true);

            EasyTimer.SetInterval(() => {
                if (this.CommandsQueue.Any())
                    this.API.Speak(TalkType.Local, this.CommandsQueue.Dequeue());
            }, 500);

            EasyTimer.SetInterval(() => {
                if (this.Client.ConnectedAndInitialized && this.API.Initialized)
                    this.API.PingServer();
            }, 5000);

            // TODO: Update the EIF data from the server, supporting remotely hosted EOMarket bots.
            //this.API.RequestFile(InitFileType.Item);
        }
    }

    public class MarketPlace
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
    }

    public class MarketSellerRecord
    {
        public string Username { get; set; }
        public int Quantity { get; set; }
    }

    public class CharacterRecord
    {
        public string Name { get; set; }
        public string Account { get; set; }
    }

    public class AccountRecord
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class MarketIndexRecord
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }

    public class MarketIndexByUsernameRecord
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }

    public class EOMarket : NancyModule
    {
        public bool MarketBotConnected => Program.MarketBot.Client.ConnectedAndInitialized && Program.MarketBot.API.Initialized;

        public EOMarket()
        {
            this.Get["/api/v1/index/sellers"] = (context) => {
                if (!this.MarketBotConnected)
                    return this.Response.AsJson(new { status = "error", message = "The server is currently offline." }, HttpStatusCode.InternalServerError);

                var query = "SELECT username, COUNT(username) AS quantity FROM marketplace GROUP BY username";
                var users = Program.EODatabase.Query<MarketSellerRecord>(query);

                return this.Response.AsJson(users);
            };

            this.Get["/api/v1/index/market"] = (context) => {
                if (!this.MarketBotConnected)
                    return this.Response.AsJson(new { status = "error", message = "The server is currently offline." }, HttpStatusCode.InternalServerError);

                var query = "SELECT username, id, price, COUNT(id) AS quantity FROM marketplace GROUP BY id, price, username";
                var users = Program.EODatabase.Query<MarketIndexRecord>(query);

                return this.Response.AsJson(users);
            };

            this.Get["/api/v1/request/inventory/{username}"] = (context) => {
                var username = (string)context.username;

                if (!this.MarketBotConnected)
                    return this.Response.AsJson(new { status = "error", message = "The server is currently offline." }, HttpStatusCode.InternalServerError);

                if (!this.HeaderCheck(this.Request))
                    return this.Response.AsJson(new { status = "error", message = "Authentication failed." }, HttpStatusCode.Forbidden);

                if (!username.All(char.IsLetterOrDigit))
                    return this.Response.AsJson(new { status = "error", message = "You must provide valid arguments." }, HttpStatusCode.Forbidden);

                Program.MarketBot.CommandsQueue.Enqueue($"$inventory {username}");

                var executionTimestamp = DateTime.Now;
                while ((DateTime.Now - executionTimestamp).Seconds <= 5)
                {
                    var inventory = Program.MarketBot.RequestedInventories.Find(p => p.Name == username && (DateTime.Now - p.Timestamp).Seconds < 3);

                    if (inventory != null)
                        return this.Response.AsJson<CharacterInventory>(inventory, HttpStatusCode.OK);

                    Thread.Sleep(100);
                }


                return this.Response.AsJson(new { status = "error", message = "The server was unable to fulfill your request." }, HttpStatusCode.InternalServerError);
            };

            this.Get["/api/v1/index/username/{seller}"] = (context) => {
                if (!this.MarketBotConnected)
                    return this.Response.AsJson(new { status = "error", message = "The server is currently offline." }, HttpStatusCode.InternalServerError);

                var seller = (string)context.seller;
                var items = Program.EODatabase.Table<MarketPlace>().Where(p => p.Username == seller).ToList()
                                               .Select(p => new MarketIndexByUsernameRecord() {
                                                   Id = p.Id,
                                                   Price = p.Price,
                                                   Name = Program.MarketBot.EIF.GetRecordByID(p.Id).Name
                                               });

                return this.Response.AsJson(items);
            };

            this.Get["/api/v1/request/return/{username}/{id}/{amount}/{price}"] = (context) => {
                if (!this.MarketBotConnected)
                    return this.Response.AsJson(new { status = "error", message = "The server is currently offline." }, HttpStatusCode.InternalServerError);

                if (!this.HeaderCheck(this.Request))
                    return this.Response.AsJson(new { status = "error", message = "Authentication failed." }, HttpStatusCode.Forbidden);

                var username = (string)context.username;
                var id = int.Parse(context.id);
                var amount = int.Parse(context.amount);
                var price = int.Parse(context.price);

                if (!username.All(char.IsLetterOrDigit))
                    return this.Response.AsJson(new { status = "error", message = "You must provide valid arguments." }, HttpStatusCode.Forbidden);

                if (!this.LoginCheck(username, this.Request.Headers.First(p => p.Key == "password").Value.FirstOrDefault()))
                    return this.Response.AsJson(new { status = "error", message = "Password incorrect." }, HttpStatusCode.Forbidden);

                Program.MarketBot.CommandsQueue.Enqueue($"$mret {username} {id} {amount} {price}");

                return this.Response.AsJson(new { status = "success", message = $"The request has been received." });
            };

            this.Get["/api/v1/request/sell/{seller}/{id}/{amount}/{price}"] = (context) => {
                if (!this.MarketBotConnected)
                    return this.Response.AsJson(new { status = "error", message = "The server is currently offline." }, HttpStatusCode.InternalServerError);

                if (!this.HeaderCheck(this.Request))
                    return this.Response.AsJson(new { status = "error", message = "Authentication failed." }, HttpStatusCode.Forbidden);

                var seller = (string)context.seller;
                var id = int.Parse(context.id);
                var amount = int.Parse(context.amount);
                var price = int.Parse(context.price);

                if (!seller.All(char.IsLetterOrDigit))
                    return this.Response.AsJson(new { status = "error", message = "You must provide valid arguments." }, HttpStatusCode.Forbidden);

                if (!this.LoginCheck(seller, this.Request.Headers.First(p => p.Key == "password").Value.FirstOrDefault()))
                    return this.Response.AsJson(new { status = "error", message = "Password incorrect." }, HttpStatusCode.Forbidden);

                Program.MarketBot.CommandsQueue.Enqueue($"$msell {seller} {id} {amount} {price}");

                return this.Response.AsJson(new { status = "success", message = $"The request has been received." });
            };

            this.Get["/api/v1/request/purchase/{buyer}/{seller}/{id}/{amount}/{price}"] = (context) => {
                if (!this.MarketBotConnected)
                    return this.Response.AsJson(new { status = "error", message = "The server is currently offline." }, HttpStatusCode.InternalServerError);

                if (!this.HeaderCheck(this.Request))
                    return this.Response.AsJson(new { status = "error", message = "Authentication failed." }, HttpStatusCode.Forbidden);

                var buyer = (string)context.buyer;
                var seller = (string)context.seller;
                var id = int.Parse(context.id);
                var amount = int.Parse(context.amount);
                var price = int.Parse(context.price);

                if (!seller.All(char.IsLetterOrDigit) || !buyer.All(char.IsLetterOrDigit))
                    return this.Response.AsJson(new { status = "error", message = "You must provide valid arguments." }, HttpStatusCode.Forbidden);

                if (!this.LoginCheck(buyer, this.Request.Headers.First(p => p.Key == "password").Value.FirstOrDefault()))
                    return this.Response.AsJson(new { status = "error", message = "Password incorrect." }, HttpStatusCode.Forbidden);

                Program.MarketBot.CommandsQueue.Enqueue($"$mbuy {buyer} {seller} {id} {amount} {price}");

                return this.Response.AsJson(new { status = "success", message = $"The request has been received." });
            };
        }

        public bool HeaderCheck(Request request) => new List<string>() { "password" }.All(this.Request.Headers.Keys.Contains);

        public bool LoginCheck(string username, string password)
        {
            if (!username.All(char.IsLetterOrDigit))
                return false;

            var account = Program.EODatabase.Query<CharacterRecord>($"SELECT name, account FROM `characters` WHERE name = '{username}'");

            if (account == null || !account.Any())
                return false;

            var hash = new List<byte>();
                hash.AddRange((Encoding.ASCII.GetBytes("ChangeMe")));
                hash.AddRange((Encoding.ASCII.GetBytes(account[0].Account)));
                hash.AddRange((Encoding.ASCII.GetBytes(password)));

            var computed = new SoapHexBinary(SHA256.Create().ComputeHash(hash.ToArray())).ToString().Replace("-", "").Replace(" ", "").ToLower();
            var result = Program.EODatabase.Query<AccountRecord>($"SELECT username FROM `accounts` WHERE `username` = '{account[0].Account}' AND `password` = '{computed}'");

            if (result == null || !result.Any())
                return false;

            return true;
        }
    }

    public static class EasyTimer
    {
        public static IDisposable SetInterval(Action method, int delayInMilliseconds)
        {
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);
            timer.Elapsed += (source, e) => {
                method();
            };

            timer.Enabled = true;
            timer.Start();

            // Returns a stop handle which can be used for stopping
            // the timer, if required
            return timer as IDisposable;
        }

        public static IDisposable SetTimeout(Action method, int delayInMilliseconds)
        {
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);
            timer.Elapsed += (source, e) => {
                method();
            };

            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();

            // Returns a stop handle which can be used for stopping
            // the timer, if required
            return timer as IDisposable;
        }
    }
}
