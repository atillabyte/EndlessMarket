using Detourium;
using Detourium.Detours.Network;
using System;
using EOLib.Net;
using EOLib.Net.PacketProcessing;
using EOLib.Net.API;
using System.Linq;
using System.Security;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

using static EndlessMarket.NativeMethods;
using EOLib.Domain;
using EOLib.Domain.Login;
using EOLib.Net.Translators;
using System.Collections.Generic;
using System.Reflection;
using EndlessMarket.Plugin.Handlers;
using System.Threading.Tasks;

namespace EndlessMarket
{
    public class EOMarketPlugin : DetouriumPlugin
    {
        public override string PluginName => "EOMarket";
        public override double PluginVersion => 1.0;

        #region Window Hook
        private IntPtr EndlessHandle;
        private string EndlessTitle;

        private int EOClientWidth { get; } = 640;
        private int EOClientHeight { get; } = 512;

        private bool Initialized { get; set; }
        #endregion

        #region Window Movement Hook

        private CBTProc CBTCallback;
        private IntPtr CBTHook;

        private bool IsMovingWindow { get; set; }
        #endregion

        #region Network Hook
        public NetworkDetour NetworkDetour;
        public EOPacketManager EOPacketManager;

        private bool EOPacketInit { get; set; } = false;
        #endregion

        public override bool OnUninstall()
        {
            if (this.CBTHook != IntPtr.Zero)
                UnhookWindowsHookEx(this.CBTHook);

            if (this.NetworkDetour != null)
                this.NetworkDetour.Dispose();

            return true;
        }

        public override void OnInstalled()
        {
            while (!this.Initialized)
            {
                foreach (var window in OpenWindowGetter.GetOpenWindows()) {
                    var handle = window.Key;
                    var title = window.Value;

                    if (title.StartsWith("Endless Online")) {
                        this.Initialized = true;

                        this.EndlessHandle = handle;
                        this.EndlessTitle = title;
                    }
                }

                Thread.Sleep(100);
            }

            this.EOPacketManager = new EOPacketManager(this);
            this.NetworkDetour = new NetworkDetour().Install(PacketChannel.Send | PacketChannel.WSARecv, new InterceptCallback((packet) => {
                if (packet.Destination.Port == 8076 || packet.Destination.Port == 0)
                    return new InterceptResponse(false);

                if (!this.EOPacketInit)
                {
                    if (packet.Channel == PacketChannel.WSARecv)
                    {
                        var decode = new OldPacket(packet.Buffer.Skip(2));

                        if (decode.Family != PacketFamily.Init || decode.Action != PacketAction.Init)
                        {
                            return new InterceptResponse(false);
                        }

                        this.EOPacketInit = true;
                        decode.Skip(3);

                        this.EOPacketManager.SetMultiples(decode.GetByte(), decode.GetByte());
                    }

                    return new InterceptResponse(false);
                }

                var channel = packet.Channel == PacketChannel.Send ? EOPacketChannel.Send : EOPacketChannel.Receive;
                this.EOPacketManager.HandlePacket(channel, packet.Buffer.Skip(2));

                return new InterceptResponse(false);
            }));

            Thread.Sleep(1000);

            EasyTimer.SetInterval(() => {
                if (this.IsMovingWindow)
                    RepositionMarketWindow();
            }, 16);

            EasyTimer.SetInterval(() => {
                if (Program.Market.Visible)
                {
                    SetWindowPos(Program.Market.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
                    RepositionMarketWindow();
                }
            }, 5000);

            Program.Market.Load += (s, e) => {
                var threadId = GetWindowThreadProcessId(this.EndlessHandle, out var processId);
                this.CBTCallback = this.CBT_Callback;
                this.CBTHook = SetWindowsHookEx(HookType.WH_CBT, CBTCallback, instancePtr: IntPtr.Zero, threadID: threadId);

                SetWindowPos(Program.Market.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
                RepositionMarketWindow();
            };

            Program.Market.Shown += (s, e) => {
                SetWindowPos(Program.Market.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
                RepositionMarketWindow();
            };

            Program.Market.VisibleChanged += (s, e) => {
                if (Program.Market.Visible)
                {
                    SetWindowPos(Program.Market.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
                    RepositionMarketWindow();
                }
            };

            Program.Market.Hide();
            Application.EnableVisualStyles();

            new Thread(() => {
                Application.Run();
            }).Start();
        }

        private void RepositionMarketWindow()
        {
            if (Program.Market == null || !Program.Market.Visible)
                return;

            GetWindowRect(this.EndlessHandle, out var rect);

            var newX = rect.X + 8;
            var newY = rect.Y + 50;

            if (Program.Market.Location.X == newX && Program.Market.Location.Y == newY)
                return;

            Program.Market.Location = new Point(newX, newY);
            SetWindowPos(Program.Market.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            foreach (Form form in Application.OpenForms)
            {
                if (form == Program.Market)
                    continue;

                form.Location = new Point(Program.Market.Location.X + (EOClientWidth / 4), Program.Market.Location.Y + (EOClientHeight / 4));
            }
        }

        private IntPtr CBT_Callback(int code, IntPtr wParam, IntPtr lParam)
        {
            // HCBT_SYSCOMMAND
            if (code == 8)
            {
                // SC_MOVE (Moves the window)
                if ((int)wParam == 0xF010)
                {
                    this.IsMovingWindow = true;
                    this.RepositionMarketWindow();
                }
            }

            // HCBT_MOVESIZE (A window is about to be moved or sized.)
            if (code == 0)
            {
                this.IsMovingWindow = false;
                this.RepositionMarketWindow();
            }

            if (code == 9)
            {
                this.RepositionMarketWindow();
            }

            // HCBT_CLICKSKIPPED
            // (user cannot click application and move it at the same time)
            // (hence pause the movement tracking, just incase it's still tracking.)
            if (code == 6)
            {
                this.IsMovingWindow = false;
                this.RepositionMarketWindow();
            }

            return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }
    }

    public interface IPacketHandler
    {
        void Handle(EOPacketManager parent, IPacket packet);
    }

    public enum EOPacketChannel
    {
        Send,
        Receive
    }

    public class EOPacketManager
    {
        private IPacketEncoderRepository _packetEncoderRepository;
        private PacketProcessActions _packetProcessActions;
        private NumberEncoderService _numberEncoderService;

        private byte DMulti;
        private byte EMulti;

        internal List<IPacketHandler> PacketHandlers = new List<IPacketHandler>() {
            new LoginRequestHandler(),
            new WelcomeReplyHandler(),
            new ShopDialogRequestHandler(),
        };

        public EOPacketManager(EOMarketPlugin plugin)
        {
            _packetEncoderRepository = new PacketEncoderRepository();
            _packetProcessActions = new PacketProcessActions(new SequenceRepository(), _packetEncoderRepository, new PacketEncoderService(), new PacketSequenceService());
            _numberEncoderService = new NumberEncoderService();
        }

        public void SetMultiples(byte multi_d, byte multi_e)
        {
            this.DMulti = multi_d;
            this.EMulti = multi_e;

            _packetProcessActions.SetEncodeMultiples(this.DMulti, this.EMulti);
        }

        public void HandlePacket(EOPacketChannel channel, IEnumerable<byte> packet)
        {
            this.HandlePacket(channel, _packetProcessActions.DecodeData(packet));
        }

        public void HandlePacket(EOPacketChannel channel, IPacket packet)
        {
            var handler = this.PacketHandlers.Find(p => {
                var ph = p.GetType().GetCustomAttribute<EOPacketHandler>();
                return packet.GetHeader() == (ph.Family, ph.Action) && channel == ph.Channel;
            });

            Console.WriteLine($"[{channel}] [{packet.Family}:{packet.Action}]");

            handler?.Handle(this, packet);
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class EOPacketHandler : Attribute
    {
        public PacketFamily Family { get; }
        public PacketAction Action { get; }
        public EOPacketChannel Channel { get; }

        public EOPacketHandler(PacketFamily family, PacketAction action, EOPacketChannel channel)
        {
            this.Family = family;
            this.Action = action;
            this.Channel = channel;
        }
    }

    public static class EOPacketExtensions
    {
        public static (PacketFamily family, PacketAction action) GetHeader(this IPacket packet) => (packet.Family, packet.Action);
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

    public static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEHOOKSTRUCT
        {
            public POINT pt; // can't use System.Windows.Point because that has X,Y as doubles, not integer
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
            public override string ToString()
            {
                return $"({pt.X,4},{pt.Y,4})";
            }
        }

        public struct POINT
        {
            public int X;
            public int Y;
        }

        // from WinUser.h
        public enum HookType
        {
            WH_MIN = (-1),
            WH_MSGFILTER = (-1),
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }
        public enum HookCodes
        {
            HC_ACTION = 0,
            HC_GETNEXT = 1,
            HC_SKIP = 2,
            HC_NOREMOVE = 3,
            HC_NOREM = HC_NOREMOVE,
            HC_SYSMODALON = 4,
            HC_SYSMODALOFF = 5
        }
        public enum CBTHookCodes
        {
            HCBT_MOVESIZE = 0,
            HCBT_MINMAX = 1,
            HCBT_QS = 2,
            HCBT_CREATEWND = 3,
            HCBT_DESTROYWND = 4,
            HCBT_ACTIVATE = 5,
            HCBT_CLICKSKIPPED = 6,
            HCBT_KEYSKIPPED = 7,
            HCBT_SYSCOMMAND = 8,
            HCBT_SETFOCUS = 9
        }

        public delegate IntPtr CBTProc(int code, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hookPtr);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hookPtr, int nCode, IntPtr wordParam, IntPtr longParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, CBTProc hookProc, IntPtr instancePtr, uint threadID);

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);

        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOACTIVATE = 0x0010;
        public const uint TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    }
}