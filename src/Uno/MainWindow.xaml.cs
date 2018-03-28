using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uno
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static DiscordRPC.RichPresence Presence;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitializeDiscordRichPresence()
        {
            DiscordRPC.EventHandlers handlers = new DiscordRPC.EventHandlers();
            handlers.readyCallback += new DiscordRPC.ReadyCallback(ReadyCallback);
            handlers.disconnectedCallback += new DiscordRPC.DisconnectedCallback(DisconnectedCallback);
            handlers.errorCallback += new DiscordRPC.ErrorCallback(ErrorCallback);
            handlers.joinCallback += new DiscordRPC.JoinCallback(JoinCallback);
            handlers.spectateCallback += new DiscordRPC.SpectateCallback(SpectateCallback);
            handlers.requestCallback += new DiscordRPC.RequestCallback(RequestCallback);
            DiscordRPC.Initialize("428633758246109184", ref handlers, true, "");
            Presence = new DiscordRPC.RichPresence
            {
                largeImageKey = "uno_l",
                smallImageKey = "uno"
            };

            Presence.details = "Probably playing Uno.";


            DiscordRPC.UpdatePresence(ref Presence);
            MessageBox.Show("initialized");
        }


        private void startRPCButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeDiscordRichPresence();
        }


        //whatever

        private static void RequestCallback(DiscordRPC.JoinRequest request)
        {
        }

        private static void SpectateCallback(string secret)
        {
        }

        private static void JoinCallback(string secret)
        {
        }

        private static void ErrorCallback(int errorCode, string message)
        {
        }

        private static void DisconnectedCallback(int errorCode, string message)
        {
        }

        private static void ReadyCallback()
        {
        }

        private void stopRPCButton_Click(object sender, RoutedEventArgs e)
        {
            DiscordRPC.Shutdown();
        }
    }
}
