using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EOLib.Net;
using EOLib.Net.Translators;
using Detourium.Detours.Network;

namespace EndlessMarket.Plugin.Handlers
{
    [EOPacketHandler(PacketFamily.Login, PacketAction.Request, EOPacketChannel.Send)]
    public class LoginRequestHandler : IPacketHandler
    {
        public void Handle(EOPacketManager parent, IPacket packet)
        {
            var username = packet.ReadBreakString();
            var password = packet.ReadBreakString();

            Program.Market.ShopManager.SetPassword(password);
        }
    }

    [EOPacketHandler(PacketFamily.Login, PacketAction.Reply, EOPacketChannel.Receive)]
    public class LoginReplyHandler : IPacketHandler
    {
        public void Handle(EOPacketManager parent, IPacket packet)
        {
        }
    }
}
