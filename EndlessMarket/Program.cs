using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using Detourium;

namespace EndlessMarket
{
    static class Program
    {
        public static MarketForm Market
            = new MarketForm();

        public static SoundPlayer OkButtonPressSound { get; set; }
            = new SoundPlayer(@"sfx/sfx002.wav");

        public static SoundPlayer CancelButtonPressSound { get; set; }
            = new SoundPlayer(@"sfx/sfx003.wav");

        public static SoundPlayer PurchaseSound { get; set; }
            = new SoundPlayer(@"sfx/sfx026.wav");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // reference the latest version of Detourium.Plugins.
            AppDomain.CurrentDomain.AssemblyResolve += (s, args) => (!args.Name.Contains("Detourium.Plugins")) ? null :
                Assembly.LoadFrom(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Detourium", "Detourium.Plugins.dll"));
            AppDomain.CurrentDomain.Load(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Detourium", "Detourium.Plugins.dll"));

            Start();
        }

        static void Start()
        {
            new EOMarketPlugin() { Configuration = new PluginConfiguration() { DisplayConsole = true } }
            .Install(new ProcessStartInfo(@"endless.exe") {
                WorkingDirectory = Environment.CurrentDirectory,
                UseShellExecute = false
            }, true);
        }
    }
}
