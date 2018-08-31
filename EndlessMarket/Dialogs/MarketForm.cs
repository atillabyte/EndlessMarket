using EndlessMarket.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessMarket
{
    public enum Category
    {
        Weapons,
        Armor,
        Usables,
        Misc
    }

    public partial class MarketForm : Form
    {
        public TextInfo TextInfo = CultureInfo.CurrentCulture.TextInfo;
        public ShopManager ShopManager = new ShopManager();
        public Shop CurrentShop { get; set; }
        public Category CurrentCategory { get; set; }
        public string ClientUsername { get; set; }

        public MarketForm()
        {
            this.CurrentCategory = Category.Weapons;

            InitializeComponent();
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            */
        }

        private void LoadForm(object sender, EventArgs e)
        {
            this.UpdateItemsInCategory();
            this.LoadShop(this.ClientUsername);
        }

        private void FormVisibilityChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.UpdateItemsInCategory();
                this.LoadShop(this.ClientUsername);
            }
        }

        private void UpdateItemBoxScrollBars()
        {
            ItemBoxEOScrollBarHost.BringToFront();

            ItemBoxEOScrollBarHost.Maximum = ItemBoxFlowLayoutPanel.VerticalScroll.Maximum;
            ItemBoxEOScrollBarHost.Minimum = ItemBoxFlowLayoutPanel.VerticalScroll.Minimum;
            ItemBoxEOScrollBarHost.Height = ItemBoxFlowLayoutPanel.Height;

            ItemBoxEOScrollBarHost.ValueChanged += (s, e) => {
                ItemBoxFlowLayoutPanel.VerticalScroll.Value = ItemBoxEOScrollBarHost.Value;
            };

            ItemBoxEOScrollBarHost.Scroll += (s, e) => {
                ItemBoxFlowLayoutPanel.VerticalScroll.Value = ItemBoxEOScrollBarHost.Value;
            };

            ItemBoxEOScrollBarRender.BringToFront();
            ItemBoxEOScrollBarRender.FindUnderlyingScrollBar();
        }

        private void UpdateCategoryBoxScrollBars()
        {
            CategoryBoxScrollBarHost.BringToFront();

            CategoryBoxScrollBarHost.Maximum = CategoryBoxFlowLayoutPanel.VerticalScroll.Maximum;
            CategoryBoxScrollBarHost.Minimum = CategoryBoxFlowLayoutPanel.VerticalScroll.Minimum;
            CategoryBoxScrollBarHost.Height = CategoryBoxFlowLayoutPanel.Height;

            CategoryBoxScrollBarHost.ValueChanged += (s, e) => {
                CategoryBoxFlowLayoutPanel.VerticalScroll.Value = CategoryBoxScrollBarHost.Value;
            };

            CategoryBoxScrollBarHost.Scroll += (s, e) => {
                CategoryBoxFlowLayoutPanel.VerticalScroll.Value = CategoryBoxScrollBarHost.Value;
            };

            CategoryBoxEOScrollBarRender.BringToFront();
            CategoryBoxEOScrollBarRender.FindUnderlyingScrollBar();
        }

        public void LoadShop(string seller)
        {
            this.CurrentShop = this.ShopManager.LoadShop(this, seller);

            this.ItemAddButton.Visible = seller.ToLower() == this.ClientUsername.ToLower();

            this.UpdateShopOwnerLabel($"{TextInfo.ToTitleCase(this.CurrentShop.Seller.ToLower())}'s Shop");
            this.UpdateItemsInShop(this.CurrentShop.Items);

            // event handling
            foreach (MarketItemControl control in this.ItemBoxFlowLayoutPanel.Controls)
            {
                control.CheckedChanged += (s, e) => {
                    if (this.ClientUsername == seller)
                        control.FlatAppearance.CheckedBackColor = Color.FromArgb(32, 255, 0, 0);

                    this.ItemDeleteButton.Visible = 
                         seller.ToLower() == this.ClientUsername.ToLower() && 
                         this.ItemBoxFlowLayoutPanel.Controls.Cast<MarketItemControl>().Any(p => p.Checked);
                };

                control.MouseClick += (s, e) =>
                {
                    if (this.ClientUsername == seller)
                        return;

                    if (e.Button != MouseButtons.Left)
                        return;

                    var purchaseDialog = new PurchaseDialogForm(control.Item, control.Amount);
                    
                    if (purchaseDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.ShopManager.PurchaseItem(this, this.ClientUsername, this.CurrentShop.Seller, control.Item.Id, purchaseDialog.PurchasedAmount, control.Item.Price);

                        // wait a few moments before reloading the shop (todo: automatically detect changes before reloading)
                        Thread.Sleep(1500);

                        this.LoadShop(this.CurrentShop.Seller);
                    }
                };
            }
        }

        public void UpdateShopOwnerLabel(string label)
        {
            this.ShopOwnerLabel.Text = label;
        }

        public void UpdateItemsInCategory()
        {
            TabWeapons.Image = Resources.TabButton;
            TabArmor.Image = Resources.TabButton;
            TabUsables.Image = Resources.TabButton;
            TabMisc.Image = Resources.TinyTabButton;

            switch(this.CurrentCategory)
            {
                case Category.Weapons:
                    TabWeapons.Image = Resources.TabButtonSelected;
                    break;
                case Category.Armor:
                    TabArmor.Image = Resources.TabButtonSelected;
                    break;
                case Category.Usables:
                    TabUsables.Image = Resources.TabButtonSelected;
                    break;
                case Category.Misc:
                    TabMisc.Image = Resources.TinyTabButtonSelected;
                    break;
            }

            CategoryBoxFlowLayoutPanel.Controls.Clear();

            var controls = new List<Control>();
            var records = this.ShopManager.GetMarketIndexRecords();

            foreach (var record in records)
            {
                if (this.ShopManager.CategoryFromItemId(record.Id) != this.CurrentCategory)
                    continue;

                var control = this.ShopManager.CreateCategoryItemControl(this.ShopManager.BitmapFromItemId(record.Id),
                    record.Username, this.ShopManager.NameFromItemId(record.Id), "x" + record.Quantity);

                control.MouseClick += (s, e) => {
                    if (e.Button != MouseButtons.Left)
                        return;

                    this.LoadShop(record.Username);
                };
                
                controls.Add(control);
            }

            CategoryBoxFlowLayoutPanel.Controls.AddRange(controls.ToArray());

            this.UpdateCategoryBoxScrollBars();
        }

        public void UpdateItemsInShop(List<MarketRecord> items)
        {
            var controls = new List<Control>();

            foreach (var item in items.GroupBy(n => new { n.Id, n.Price }))
            {
                var first = item.First();
                var amount = item.Count();

                var control = this.ShopManager.CreateShopItemControl(this.ShopManager.BitmapFromItemId(first.Id),
                    first.Name,
                    $"{item.First().Price}g ea",
                    $"x{amount}"
                );

                control.Item = first;
                control.Amount = amount;

                controls.Add(control);
            }

            ItemBoxFlowLayoutPanel.Controls.Clear();
            ItemBoxFlowLayoutPanel.Controls.AddRange(controls.ToArray());

            this.UpdateItemBoxScrollBars();
        }

        private void ItemAddButton_Click(object sender, EventArgs e)
        {
            Program.OkButtonPressSound.Play();

            var sellDialogForm = new InventoryDialogForm();

            sellDialogForm.Market = this;
            sellDialogForm.ShopManager = this.ShopManager;

            if (sellDialogForm.ShowDialog() == DialogResult.OK)
            {
                this.LoadShop(this.ClientUsername);
            }
        }

        private void ItemDeleteButton_Click(object sender, EventArgs e)
        {
            Program.OkButtonPressSound.Play();

            foreach (MarketItemControl control in this.ItemBoxFlowLayoutPanel.Controls)
            {
                if (!control.Checked)
                    continue;

                var returnItemDialog = new ReturnItemDialogForm(control.Item, control.Amount);

                if (returnItemDialog.ShowDialog() == DialogResult.OK)
                {
                    this.ShopManager.ReturnItem(this, this.ClientUsername, control.Item.Id, returnItemDialog.ReturnedAmount, control.Item.Price);
                }
            }

            Thread.Sleep(1500);
            this.LoadShop(this.ClientUsername);
            this.UpdateItemsInCategory();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Program.CancelButtonPressSound.Play();
            Application.OpenForms.Cast<Form>().Where(f => f != this).ToList().ForEach((f) => f.Close());

            this.Hide();
        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            Program.OkButtonPressSound.Play();
            this.LoadShop(this.ClientUsername);
        }

        #region Windows API
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        private void TabWeapons_Click(object sender, EventArgs e)
        {
            this.CurrentCategory = Category.Weapons;
            this.UpdateItemsInCategory();
        }

        private void TabArmor_Click(object sender, EventArgs e)
        {
            this.CurrentCategory = Category.Armor;
            this.UpdateItemsInCategory();
        }

        private void TabUsables_Click(object sender, EventArgs e)
        {
            this.CurrentCategory = Category.Usables;
            this.UpdateItemsInCategory();
        }

        private void TabMisc_Click(object sender, EventArgs e)
        {
            this.CurrentCategory = Category.Misc;
            this.UpdateItemsInCategory();
        }
    }
}
