using EOLib.Domain;
using EOLib.Net;
using EOLib.Net.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessMarket.Plugin.Handlers
{
    [EOPacketHandler(PacketFamily.Welcome, PacketAction.Reply, EOPacketChannel.Receive)]
    public class WelcomeReplyHandler : IPacketHandler
    {
        public void Handle(EOPacketManager parent, IPacket packet)
        {
            var reply = new LoginRequestGrantedPacketTranslator(new NumberEncoderService()).TranslatePacket(packet);

            Program.Market.ClientUsername = reply.Name;
        }
    }
}
