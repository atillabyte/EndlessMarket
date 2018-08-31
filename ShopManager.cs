using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EOLib;
using EOLib.Graphics;
using EOLib.IO;
using IniParser;
using IniParser.Model.Configuration;
using IniParser.Parser;
using Newtonsoft.Json;

namespace EndlessMarket
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }

    }
    public class CharacterInventory
    {
        public string Name { get; set; }
        public List<InventoryItem> Items { get; set; }
    }

    public class MarketRecord
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }

    public class MarketIndexRecord
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Shop
    {
        public string Seller { get; internal set; }
        public List<MarketRecord> Items { get; internal set; }

        public Shop(string seller, IEnumerable<MarketRecord> items)
        {
            this.Seller = seller;
            this.Items = items.ToList();
        }
    }

    public class MarketItemControl : CheckBox
    {
        public MarketRecord Item { get; set; }
        public int Amount { get; set; }
    }

    public class ShopManager
    {
        private PEFileCollection PECollection { get; set; }
        private ItemFile EIF { get; set; }
        private NativeGraphicsManager GFX { get; set; }
        private Bitmap Pillow { get; set; }
        private TextInfo TextInfo = CultureInfo.CurrentCulture.TextInfo;

        public string APIEndpoint = "http://localhost:8076";
        private string ClientPassword { get; set; }

        public ShopManager()
        {
            this.PECollection = new PEFileCollection();
            this.PECollection.PopulateCollectionWithStandardGFX();
            this.EIF = ItemFile.FromBytes(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "pub", "dat001.eif")));
            this.GFX = new NativeGraphicsManager(new NativeGraphicsLoader(this.PECollection));

            this.Pillow = this.GFX.BitmapFromResource(GFXTypes.MapTiles, 0, true);
            var config = new IniReader(Path.Combine(Environment.CurrentDirectory, "config", "setup.ini"));
                config.Load();

            if (!config.GetValue("CONNECTION", "Host", out string host))
                throw new Exception("Unable to read 'Host' from client config.");

            this.APIEndpoint = $"http://{host}:8076";
        }

        public string PurchaseItem(MarketForm market, string buyer, string seller, int id, int amount, int price)
        {
            using (var wc = new WebClient() { Proxy = null })
            {
                wc.Headers = new WebHeaderCollection();
                wc.Headers.Set("password", this.ClientPassword);

                return wc.DownloadString($"{APIEndpoint}/api/v1/request/purchase/{buyer}/{seller}/{id}/{amount}/{price}");
            }
        }

        public string SellItem(MarketForm market, string seller, int id, int amount, int price)
        {
            using (var wc = new WebClient() { Proxy = null })
            {
                wc.Headers = new WebHeaderCollection();
                wc.Headers.Set("password", this.ClientPassword);

                return wc.DownloadString($"{APIEndpoint}/api/v1/request/sell/{seller}/{id}/{amount}/{price}");
            }
        }

        public string ReturnItem(MarketForm market, string username, int id, int amount, int price)
        {
            using (var wc = new WebClient() { Proxy = null })
            {
                wc.Headers = new WebHeaderCollection();
                wc.Headers.Set("password", this.ClientPassword);

                return wc.DownloadString($"{APIEndpoint}/api/v1/request/return/{username}/{id}/{amount}/{price}");
            }
        }

        public void SetPassword(string password) => this.ClientPassword = password;

        public List<MarketIndexRecord> GetMarketIndexRecords()
        {
            using (var wc = new WebClient() { Proxy = null })
            {
                var response = wc.DownloadString($"{APIEndpoint}/api/v1/index/market");

                try
                {
                    return JsonConvert.DeserializeObject<MarketIndexRecord[]>(response).ToList();
                }
                catch
                {
                    MessageBox.Show($"Unable to complete request. (response: {response}");
                }
            }

            return new List<MarketIndexRecord>();
        }

        public CharacterInventory GetCharacterInventory(string username)
        {
            using (var wc = new WebClient() { Proxy = null })
            {
                wc.Headers = new WebHeaderCollection();
                wc.Headers.Set("password", this.ClientPassword);

                var response = wc.DownloadString($"{APIEndpoint}/api/v1/request/inventory/{username}");

                try
                {
                    return JsonConvert.DeserializeObject<CharacterInventory>(response);
                }
                catch
                {
                    MessageBox.Show($"Unable to complete request. (response: {response}");
                }
            }

            return null;
        }

        public Shop LoadShop(MarketForm market, string seller)
        {
            using (var wc = new WebClient() { Proxy = null })
            {
                var response = wc.DownloadString($"{APIEndpoint}/api/v1/index/username/{seller}");

                try
                {
                    var deserialized = JsonConvert.DeserializeObject<MarketRecord[]>(response);
                    return new Shop(seller, deserialized);
                }
                catch
                {
                    MessageBox.Show($"Unable to complete request. (response: {response}");
                }
            }

            return null;
        }

        #region Rendering

        public static (int X, int Y) GetDrawCoordinatesFromGFX(int width, int height) =>
            (32 - (int)Math.Round(width / 2.0), 16 - (int)Math.Round(height / 2.0));

        public Category CategoryFromItemId(int id)
        {
            switch (this.EIF.GetRecordByID(id).Type)
            {
                case ItemType.Weapon:
                    return Category.Weapons;
                case ItemType.Teleport:
                    return Category.Usables;
                case ItemType.StatReward:
                    return Category.Usables;
                case ItemType.Ring:
                    return Category.Armor;
                case ItemType.Belt:
                    return Category.Armor;
                case ItemType.Boots:
                    return Category.Armor;
                case ItemType.EXPReward:
                    return Category.Usables;
                case ItemType.Shield:
                    return Category.Armor;
                case ItemType.Armlet:
                    return Category.Armor;
                case ItemType.EffectPotion:
                    return Category.Usables;
                case ItemType.Gloves:
                    return Category.Armor;
                case ItemType.Armor:
                    return Category.Armor;
                case ItemType.Heal:
                    return Category.Usables;
                case ItemType.Necklace:
                    return Category.Armor;
                case ItemType.Hat:
                    return Category.Armor;
                case ItemType.SkillReward:
                    return Category.Usables;
                case ItemType.HairDye:
                    return Category.Usables;
                case ItemType.Bracer:
                    return Category.Usables;
                default:
                    return Category.Misc;
            }
        }

        public string NameFromItemId(int id) =>
            this.EIF.GetRecordByID(id).Name;

        public Bitmap BitmapFromItemId(int id) =>
            this.GFX.BitmapFromResource(GFXTypes.Items, 2 * this.EIF.GetRecordByID(id).Graphic - 1, true);

        public MarketItemControl CreateCategoryItemControl(Bitmap item, string sellerLabel = "", string itemNameLabel = "", string amountLabel = "")
        {
            var bitmap = CreateCategoryItemPillow(item, sellerLabel, itemNameLabel, amountLabel);

            var control = new MarketItemControl() {
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                UseVisualStyleBackColor = true,
                BackgroundImageLayout = ImageLayout.None,
                BackgroundImage = bitmap,
                Font = new Font(FontFamily.GenericSansSerif, 6f, FontStyle.Regular),
                ForeColor = Color.White,
                TextImageRelation = TextImageRelation.TextAboveImage,
                TextAlign = ContentAlignment.BottomCenter,
                Size = new Size(162, bitmap.Height),
                Text = "",
            };

            control.FlatAppearance.BorderSize = 0;
            control.FlatAppearance.CheckedBackColor = Color.Transparent;
            control.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 0, 0, 0);
            control.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 0, 0, 0);

            return control;
        }

        public MarketItemControl CreateSellItemControl(Bitmap item, string itemNameLabel = "", string amountLabel = "")
        {
            var bitmap = CreateSellItemPillow(item, itemNameLabel, amountLabel);

            var control = new MarketItemControl() {
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                UseVisualStyleBackColor = true,
                BackgroundImageLayout = ImageLayout.None,
                BackgroundImage = bitmap,
                Font = new Font(FontFamily.GenericSansSerif, 6f, FontStyle.Regular),
                ForeColor = Color.White,
                TextImageRelation = TextImageRelation.TextAboveImage,
                TextAlign = ContentAlignment.BottomCenter,
                Size = new Size(233, bitmap.Height),
                Text = "",
            };

            control.FlatAppearance.BorderSize = 0;
            control.FlatAppearance.CheckedBackColor = Color.Transparent;
            control.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 0, 0, 0);
            control.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 0, 0, 0);

            return control;
        }

        public MarketItemControl CreateShopItemControl(Bitmap item, string topLabel = "", string bottomLabel = "", string middleRightLabel = "")
        {
            var bitmap = CreateShopItemPillow(item, topLabel, bottomLabel, middleRightLabel);

            var control = new MarketItemControl() {
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                UseVisualStyleBackColor = true,
                BackgroundImageLayout = ImageLayout.None,
                BackgroundImage = bitmap,
                Font = new Font(FontFamily.GenericSansSerif, 6f, FontStyle.Regular),
                ForeColor = Color.White,
                TextImageRelation = TextImageRelation.TextAboveImage,
                TextAlign = ContentAlignment.BottomCenter,
                Size = new Size(bitmap.Width + 8, bitmap.Height + 8),
                Text = "",
            };

            control.FlatAppearance.BorderSize = 0;
            control.FlatAppearance.CheckedBackColor = Color.Transparent;
            control.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 0, 0, 0);
            control.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 0, 0, 0);

            return control;
        }

        public Bitmap CreateCategoryItemPillow(Bitmap item, string sellerLabel = "", string itemNameLabel = "", string amountLabel = "")
        {
            var pillowItem = new Bitmap(164, this.Pillow.Height + 8);

            var combinedItemLabel = $"{itemNameLabel} {amountLabel}";
            var combinedSellerLabel = $"{TextInfo.ToTitleCase(sellerLabel.ToLower())}'s Shop";

            using (var g = Graphics.FromImage(pillowItem))
            {
                var (x, y) = GetDrawCoordinatesFromGFX(item.Width, item.Height);

                g.DrawImageUnscaled(this.Pillow, (-4), 0);
                g.DrawImageUnscaled(item, (-4) + x, 0 + y);

                {
                    var font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Regular);
                    var bounds = new Rectangle(this.Pillow.Width - 4, 4, pillowItem.Width, 16);

                    TextRenderer.DrawText(g, combinedItemLabel, font, bounds, Color.White, Color.Transparent,
                          TextFormatFlags.Left |
                          TextFormatFlags.Top |
                          TextFormatFlags.GlyphOverhangPadding);
                }
                {
                    var font = new Font(FontFamily.GenericSansSerif, 6.2f, FontStyle.Regular);
                    var bounds = new Rectangle(16, 20, pillowItem.Width, 32);

                    TextRenderer.DrawText(g, combinedSellerLabel, font, bounds, Color.LightGray, Color.Transparent,
                          TextFormatFlags.HorizontalCenter |
                          TextFormatFlags.Top |
                          TextFormatFlags.GlyphOverhangPadding);
                }
            }

            return pillowItem;
        }

        public Bitmap CreateSellItemPillow(Bitmap item, string itemNameLabel = "", string amountLabel = "")
        {
            var pillowItem = new Bitmap(235, this.Pillow.Height + 8);

            var combinedItemLabel = $"{itemNameLabel}\n{amountLabel}";

            using (var g = Graphics.FromImage(pillowItem))
            {
                var (x, y) = GetDrawCoordinatesFromGFX(item.Width, item.Height);

                g.DrawImageUnscaled(this.Pillow, 2, 2);
                g.DrawImageUnscaled(item, 2 + x, 2 + y);

                {
                    var font = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Regular);
                    var bounds = new Rectangle(this.Pillow.Width + 4, 4, pillowItem.Width + 80, 32);

                    TextRenderer.DrawText(g, combinedItemLabel, font, bounds, Color.FromArgb(210, 210, 210), Color.Transparent,
                          TextFormatFlags.Left |
                          TextFormatFlags.Top |
                          TextFormatFlags.GlyphOverhangPadding);
                }
            }

            return pillowItem;
        }

        public Bitmap CreatePillowItemPreview(int id)
        {
            var pillowItem = new Bitmap(this.Pillow.Width + 12, this.Pillow.Height + 30);
            var item = this.BitmapFromItemId(id);

            using (var g = Graphics.FromImage(pillowItem))
            {
                var (x, y) = GetDrawCoordinatesFromGFX(item.Width, item.Height);

                g.DrawImageUnscaled(this.Pillow, (pillowItem.Width / 4) - 16, 0);
                g.DrawImageUnscaled(item, ((pillowItem.Width / 4) - 16) + x, y);
            }

            return pillowItem;
        }

        public Bitmap CreateShopItemPillow(Bitmap item, string topLabel = "", string bottomLabel = "", string middleRightLabel = "")
        {
            var pillowItem = new Bitmap(this.Pillow.Width + 12, this.Pillow.Height + 30);

            using (var g = Graphics.FromImage(pillowItem))
            {
                var (x, y) = GetDrawCoordinatesFromGFX(item.Width, item.Height);

                g.DrawImageUnscaled(this.Pillow, (pillowItem.Width / 4) - 16, 0);
                g.DrawImageUnscaled(item, ((pillowItem.Width / 4) - 16) + x, y);

                var font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Regular);

                if (!string.IsNullOrEmpty(topLabel))
                {
                    var bounds = new Rectangle(0, 30, pillowItem.Width, pillowItem.Height);

                    TextRenderer.DrawText(g, topLabel, font, bounds, Color.White, Color.Transparent,
                          TextFormatFlags.HorizontalCenter |
                          TextFormatFlags.Top |
                          TextFormatFlags.GlyphOverhangPadding);
                }

                if (!string.IsNullOrEmpty(bottomLabel))
                {
                    var bounds = new Rectangle(0, 44, pillowItem.Width, pillowItem.Height);

                    TextRenderer.DrawText(g, bottomLabel, font, bounds, Color.White, Color.Transparent,
                          TextFormatFlags.HorizontalCenter |
                          TextFormatFlags.Top |
                          TextFormatFlags.GlyphOverhangPadding);
                }

                if (!string.IsNullOrEmpty(middleRightLabel))
                {
                    var bounds = new Rectangle(pillowItem.Width - 24, 16, pillowItem.Width, pillowItem.Height);

                    TextRenderer.DrawText(g, middleRightLabel, font, bounds, Color.White, Color.Transparent,
                          TextFormatFlags.Left |
                          TextFormatFlags.GlyphOverhangPadding);
                }
            }

            return pillowItem;
        }
        #endregion
    }
}
