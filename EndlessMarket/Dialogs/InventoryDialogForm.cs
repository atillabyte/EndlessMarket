using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessMarket
{
    public partial class InventoryDialogForm : Form
    {
        public ShopManager ShopManager { get; set; }
        public MarketForm Market { get; set; }

        public InventoryDialogForm()
        {
            InitializeComponent();
        }

        private void SellDialogForm_Load(object sender, EventArgs e)
        {
            this.InventoryOwnerLabel.Text = $"{this.Market.TextInfo.ToTitleCase(this.Market.ClientUsername)}'s Inventory";
            this.LoadIventoryItems(this.ShopManager, this.Market.ClientUsername);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Program.CancelButtonPressSound.Play();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Program.OkButtonPressSound.Play();
            
            foreach (MarketItemControl item in this.ItemsFlowLayoutPanel.Controls)
            {
                if (!item.Checked)
                    continue;

                var sellItemDialog = new SellItemDialogForm(this.Market, item.Item, item.Amount);

                if (sellItemDialog.ShowDialog() == DialogResult.OK)
                {
                    this.ShopManager.SellItem(this.Market, this.Market.ClientUsername, item.Item.Id, sellItemDialog.SellAmount, sellItemDialog.Price);

                    Thread.Sleep(500);
                    this.Market.LoadShop(this.Market.ClientUsername);
                }
                else
                {
                    this.LoadIventoryItems(this.ShopManager, this.Market.ClientUsername);
                    return;
                }
            }

            this.LoadIventoryItems(this.ShopManager, this.Market.ClientUsername);
            this.Market.UpdateItemsInCategory();
        }
        
        public void LoadIventoryItems(ShopManager manager, string username)
        {
            this.ItemsFlowLayoutPanel.Controls.Clear();

            var inventory = manager.GetCharacterInventory(username);
            var controls = new List<MarketItemControl>();

            foreach (var item in inventory.Items)
            {
                var control = manager.CreateSellItemControl(
                    manager.BitmapFromItemId(item.Id), manager.NameFromItemId(item.Id), "x" + item.Amount);

                control.Item = new MarketRecord() { Id = item.Id, Name = this.ShopManager.NameFromItemId(item.Id), Price = -1 };
                control.Amount = item.Amount;

                control.FlatAppearance.BorderSize = 0;
                control.FlatAppearance.CheckedBackColor = Color.FromArgb(8, 255, 255, 255);

                controls.Add(control);
            }

            this.ItemsFlowLayoutPanel.Controls.AddRange(controls.ToArray());
            this.UpdateItemBoxScrollBars();
        }

        private void UpdateItemBoxScrollBars()
        {
            EOScrollBarHost.BringToFront();

            EOScrollBarHost.Maximum = ItemsFlowLayoutPanel.VerticalScroll.Maximum;
            EOScrollBarHost.Minimum = ItemsFlowLayoutPanel.VerticalScroll.Minimum;
            EOScrollBarHost.Height = ItemsFlowLayoutPanel.Height;

            EOScrollBarHost.ValueChanged += (s, e) => {
                ItemsFlowLayoutPanel.VerticalScroll.Value = EOScrollBarHost.Value;
            };

            EOScrollBarHost.Scroll += (s, e) => {
                ItemsFlowLayoutPanel.VerticalScroll.Value = EOScrollBarHost.Value;
            };

            EOScrollBarRender.BringToFront();
            EOScrollBarRender.FindUnderlyingScrollBar();
        }

        #region Windows API
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        private void SellDialogForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
