using EOLib.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessMarket.Plugin.Handlers
{
    [EOPacketHandler(PacketFamily.Shop, PacketAction.Dialog, EOPacketChannel.Receive)]
    public class ShopDialogRequestHandler : IPacketHandler
    {
        public void Handle(EOPacketManager parent, IPacket packet)
        {
            if (!Program.Market.Visible)
            {
                Program.Market.Show();
                Program.Market.Visible = true;
            }
        }
    }
}
