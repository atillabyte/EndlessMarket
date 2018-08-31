using System;
using System.Collections;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Windows.Forms;
using EndlessMarket.Properties;
using EOLib.Graphics;
using EOLib.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace EndlessMarket
{
    public partial class MainForm : Form
    {
        private Bitmap itemPillow;

        private string APIEndpoint = "http://localhost:8076";
        public string Username { get; set; } = "john";

        private Shop CurrentShop { get; set; }
        private NativeGraphicsManager GFX { get; set; }
        private ItemFile EIF { get; set; }

        public enum SelectedTab
        {
            Weapons,
            Armor,
            Usables,
            Misc
        }

        public SelectedTab selectedTab = SelectedTab.Armor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Startup(object sender, EventArgs e)
        {
            var pe = new PEFileCollection();
                pe.PopulateCollectionWithStandardGFX();

            this.EIF = ItemFile.FromBytes(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "pub", "dat001.eif")));
            this.GFX = new NativeGraphicsManager(new NativeGraphicsLoader(pe));
            
            itemPillow = GFX.BitmapFromResource(GFXTypes.MapTiles, 0, true);
            
            flowItemPanel.HorizontalScroll.Enabled = false;
            flowItemPanel.HorizontalScroll.Visible = false;

            EOItemScrollBar.Padding = new Padding(0);
            EOItemScrollBar.BorderColor = Color.Transparent;
            EOItemScrollBar.DisabledBorderColor = Color.Transparent;
            
            panel2.Controls.Add(EOItemScrollBar);

            EOItemScrollBar.BringToFront();

            EOItemScrollBar.Maximum = flowItemPanel.VerticalScroll.Maximum;
            EOItemScrollBar.Minimum = flowItemPanel.VerticalScroll.Minimum;
            EOItemScrollBar.Height = flowItemPanel.Height;

            EOItemScrollBar.Scroll += EOItemsScrollBar_Scroll;

            tabWeapons.PerformClick();

            // load your shop
            using (var wc = new WebClient() { Proxy = null})
            {
                var response = wc.DownloadString($"{APIEndpoint}/api/v1/index/username/{this.Username}");

                try
                {
                    var deserialized = JsonConvert.DeserializeObject<MarketIndexByUsernameRecord[]>(response);

                    this.CurrentShop = new Shop(deserialized, this.Username);
                }
                catch
                {
                    MessageBox.Show(response);
                }
            }
        }

        public void UpdateItemsInShop(List<MarketRecord> items)
        {
            var controls = new List<Control>();

            foreach (var item in items.GroupBy(n => new { n.Id, n.Price }))
            {
                var amount = item.Count();

                var gfxId = 2 * this.EIF.GetRecordByID(item.First().Id).Graphic - 1;
                var control = this.CreateItemControl(this.GFX.BitmapFromResource(GFXTypes.Items, gfxId, true), $"{item.First().Name}", $"{item.First().Price}g ea", $"x{amount}");

                controls.Add(control);
            }

            flowItemPanel.Controls.Clear();
            flowItemPanel.Controls.AddRange(controls.ToArray());
        }

        public void SetAddButton(bool enabled)
            => btnAddItem.Visible = enabled;

        public void UpdateShopOwnerLabel(string sellerName)
        {
            sellerName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sellerName.ToLower());
            this.ShopOwnerLabel.Text = $"{sellerName}'s Shop";
        }

        public Control CreateItemControl(Bitmap item, string topLabel = "", string bottomLabel = "", string middleRightLabel = "")
        {
            var bitmap = CreateItemPillow(item, topLabel, bottomLabel, middleRightLabel);

            var control = new CheckBox() {
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
                Size = new Size(bitmap.Width + 4, bitmap.Height + 8),
                Text = "",
            };
            
            control.FlatAppearance.BorderSize = 0;
            control.FlatAppearance.CheckedBackColor = Color.Transparent;
            control.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 0, 0, 0);
            control.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 0, 0, 0);

            return control;
        }

        public Bitmap CreateItemPillow(Bitmap item, string topLabel = "", string bottomLabel = "", string middleRightLabel = "")
        {
            var pillowItem = new Bitmap(itemPillow.Width + 8, itemPillow.Height + 30);

            using (var g = Graphics.FromImage(pillowItem)) {
                var (x, y) = GetDrawCoordinatesFromGFX(item.Width, item.Height);

                g.DrawImageUnscaled(itemPillow, (pillowItem.Width / 4) - 16, 0);
                g.DrawImageUnscaled(item, ((pillowItem.Width / 4) - 16) + x, y);

                if (!string.IsNullOrEmpty(topLabel))
                {
                    var Font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Regular);
                    var Bounds = new Rectangle(0, 30, pillowItem.Width, pillowItem.Height);

                    TextRenderer.DrawText(g, topLabel, Font, Bounds, Color.White, Color.Transparent,
                          TextFormatFlags.HorizontalCenter |
                          TextFormatFlags.Top |
                          TextFormatFlags.GlyphOverhangPadding);
                }

                if (!string.IsNullOrEmpty(bottomLabel))
                {
                    var Font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Regular);
                    var Bounds = new Rectangle(0, 44, pillowItem.Width, pillowItem.Height);

                    TextRenderer.DrawText(g, bottomLabel, Font, Bounds, Color.White, Color.Transparent,
                          TextFormatFlags.HorizontalCenter |
                          TextFormatFlags.Top |
                          TextFormatFlags.GlyphOverhangPadding);
                }

                if (!string.IsNullOrEmpty(middleRightLabel))
                {
                    var Font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Regular);
                    var Bounds = new Rectangle(pillowItem.Width - 24, 16, pillowItem.Width, pillowItem.Height);

                    TextRenderer.DrawText(g, middleRightLabel, Font, Bounds, Color.White, Color.Transparent,
                          TextFormatFlags.Left |
                          TextFormatFlags.GlyphOverhangPadding);
                }
            }

            return pillowItem;
        }

        public static (int X, int Y) GetDrawCoordinatesFromGFX(int width, int height) =>
            (32 - (int)Math.Round(width / 2.0), 16 - (int)Math.Round(height / 2.0));

        private void btnAddItem_MouseEnter(object sender, EventArgs e)
        {
            btnAddItem.Image = Resources.add_btn_hover;
        }

        private void btnAddItem_MouseLeave(object sender, EventArgs e)
        {
            btnAddItem.Image = Resources.add_btn;
        }
        
        private void EOItemsScrollBar_ValueChanged(object sender, EventArgs e)
        {
           flowItemPanel.VerticalScroll.Value = EOItemScrollBar.Value;
        }

        private void EOItemsScrollBar_Scroll(object sender, EventArgs e)
        {
          flowItemPanel.VerticalScroll.Value = EOItemScrollBar.Value;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        public void SetTabSelectedBackground()
        {
            tabWeapons.Image = Resources.tab;
            tabArmor.Image = Resources.tab;
            tabUsables.Image = Resources.tab;
            tabMisc.Image = Resources.tab2;

            switch (selectedTab) {
                case SelectedTab.Weapons:
                    tabWeapons.Image = Resources.tab_select;
                    break;
                case SelectedTab.Armor:
                    tabArmor.Image = Resources.tab_select;
                    break;
                case SelectedTab.Usables:
                    tabUsables.Image = Resources.tab_select;
                    break;
                case SelectedTab.Misc:
                    tabMisc.Image = Resources.tab2_select;
                    break;
            }
        }

        private void tabWeapons_Click(object sender, EventArgs e)
        {
            selectedTab = SelectedTab.Weapons;
            SetTabSelectedBackground();
        }

        private void tabArmor_Click(object sender, EventArgs e)
        {
            selectedTab = SelectedTab.Armor;
            SetTabSelectedBackground();
        }

        private void tabUsables_Click(object sender, EventArgs e)
        {
            selectedTab = SelectedTab.Usables;
            SetTabSelectedBackground();
        }

        private void tabMisc_Click(object sender, EventArgs e)
        {
            selectedTab = SelectedTab.Misc;
            SetTabSelectedBackground();
        }
    }

    public static class Extensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source) {
                if (seenKeys.Add(keySelector(element))) {
                    yield return element;
                }
            }
        }
    }

    public class Shop
    {
        public string Seller { get; set; }

        public List<MarketRecord> Items { get; set; } = new List<MarketRecord>();

        public Shop(IEnumerable<MarketRecord> items, string seller)
        {
            this.Seller = seller;
            this.Items = items.ToList();

            Program.MainForm.UpdateItemsInShop(this.Items);
            Program.MainForm.UpdateShopOwnerLabel(seller);
            Program.MainForm.SetAddButton((seller.ToLower() == Program.MainForm.Username));

        }
    }

    public class MarketRecord
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }

    public class MarketIndexByUsernameRecord : MarketRecord
    {

    }
}
