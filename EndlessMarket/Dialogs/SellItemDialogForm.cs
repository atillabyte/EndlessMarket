using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessMarket
{
    public partial class SellItemDialogForm : Form
    {
        private MarketForm Market;

        private MarketRecord Item { get; set; }
        private int Amount { get; set; } = 1;

        public int SellAmount = 1;
        public int Price = 1;

        public SellItemDialogForm(MarketForm market, MarketRecord record, int amount)
        {
            InitializeComponent();

            this.Market = market;
            this.Item = record;
            this.Amount = amount;
        }

        public SellItemDialogForm()
        {
            InitializeComponent();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            this.EOTextBoxPrice.TextChanged += (s, f) => {
                if (int.TryParse(this.EOTextBoxPrice.Text, out int price))
                {
                    this.Price = price;
                }
            };

            this.EOTextBoxAmount.TextChanged += (s, f) => {
                if (int.TryParse(this.EOTextBoxAmount.Text, out int amount))
                {
                    this.SellAmount = amount;
                }
            };

            this.PriceLabel.FindUnderlyingTextBox();
            this.AmountLabel.FindUnderlyingTextBox();

            this.PriceLabel.ValueBox = true;
            this.PriceLabel.GoldBox = true;
            this.PriceLabel.MaxValue = int.MaxValue;

            this.AmountLabel.ValueBox = true;
            this.AmountLabel.GoldBox = false;
            this.AmountLabel.MaxValue = this.Amount;
            
            this.EOTextBoxAmount.Text = "1";
            this.EOTextBoxPrice.Text = "1";

            var bitmap = this.Market.ShopManager.CreatePillowItemPreview(this.Item.Id);
            var previewControl = new MarketItemControl() {
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                UseVisualStyleBackColor = true,
                BackgroundImageLayout = ImageLayout.Center,
                Font = new Font(FontFamily.GenericSansSerif, 6f, FontStyle.Regular),
                ForeColor = Color.White,
                TextImageRelation = TextImageRelation.TextAboveImage,
                TextAlign = ContentAlignment.BottomCenter,
                Size = new Size(this.ItemPreviewFlowLayoutPanel.Width, this.ItemPreviewFlowLayoutPanel.Height),
                Location = new Point(0, 0),
                Text = "",
                BackgroundImage = bitmap,
            };

            previewControl.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            previewControl.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            previewControl.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 255, 255, 255);
            previewControl.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            previewControl.FlatAppearance.BorderSize = 1;

            this.ItemPreviewFlowLayoutPanel.Controls.Add(previewControl);
        }

        private void SellDialogPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Program.CancelButtonPressSound.Play();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.Price < 1 || String.IsNullOrEmpty(EOTextBoxPrice.Text))
                return;

            if (this.Price < 1 || String.IsNullOrEmpty(EOTextBoxAmount.Text))
                return;

            if (!int.TryParse(EOTextBoxAmount.Text, out var amount))
                return;

            this.SellAmount = amount;

            var confirmSellDialog = new ConfirmPurchaseDialogForm(
               "  Sell item(s)",
               $"  Sell {this.SellAmount} {this.Item.Name} on the market for\n  {this.Price}g per item?"
           );

            if (confirmSellDialog.ShowDialog() == DialogResult.OK)
            {
                Program.PurchaseSound.Play();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void EOTextBoxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyCode) && e.KeyCode != Keys.Back)
            {
                e.SuppressKeyPress = true;
                return;
            }

            if ((string.IsNullOrEmpty(EOTextBoxAmount.Text) && e.KeyCode == Keys.D0))
            {
                EOTextBoxAmount.Text = 1.ToString();
                EOTextBoxAmount.SelectionStart = EOTextBoxAmount.Text.Length;
                EOTextBoxAmount.SelectionLength = 0;

                e.SuppressKeyPress = true;
                return;
            }

            var digit = char.IsDigit((char)e.KeyCode) ? "" + (char)e.KeyCode : "";

            if (!string.IsNullOrEmpty(EOTextBoxAmount.Text) && e.KeyCode != Keys.Back)
            {
                if (int.Parse(EOTextBoxAmount.Text + digit) > this.Amount)
                {
                    EOTextBoxAmount.Text = this.Amount.ToString();
                    EOTextBoxAmount.SelectionStart = EOTextBoxAmount.Text.Length;
                    EOTextBoxAmount.SelectionLength = 0;

                    e.SuppressKeyPress = true;
                    return;
                }
            }
        }

        private void EOTextBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyCode) && e.KeyCode != Keys.Back)
            {
                e.SuppressKeyPress = true;
                return;
            }

            if ((string.IsNullOrEmpty(EOTextBoxPrice.Text) && e.KeyCode == Keys.D0))
            {
                EOTextBoxPrice.Text = 1.ToString();
                EOTextBoxPrice.SelectionStart = EOTextBoxPrice.Text.Length;
                EOTextBoxPrice.SelectionLength = 0;

                e.SuppressKeyPress = true;
                return;
            }

            var digit = char.IsDigit((char)e.KeyCode) ? "" + (char)e.KeyCode : "";

            if (!string.IsNullOrEmpty(EOTextBoxPrice.Text) && e.KeyCode != Keys.Back)
            {
                if (int.TryParse(EOTextBoxPrice.Text + digit, out int price))
                {
                    if (price > int.MaxValue)
                    {
                        EOTextBoxPrice.Text = int.MaxValue.ToString();
                        EOTextBoxPrice.SelectionStart = EOTextBoxPrice.Text.Length;
                        EOTextBoxPrice.SelectionLength = 0;

                        e.SuppressKeyPress = true;
                        return;
                    }
                }
                else
                {
                    e.SuppressKeyPress = true;
                    return;
                }
            }
        }

        private void SellItemDialogPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #region Windows API
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        private void UpArrowButton_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void DownArrowButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(EOTextBoxPrice.Text, out int price))
            {
                if (price - 50 >= 1)
                {
                    EOTextBoxPrice.Text = (price - 50).ToString();
                    EOTextBoxPrice.SelectionStart = EOTextBoxAmount.Text.Length;
                    EOTextBoxPrice.SelectionLength = 0;
                }
                else
                {
                    EOTextBoxPrice.Text = (0).ToString();
                    EOTextBoxPrice.SelectionStart = EOTextBoxAmount.Text.Length;
                    EOTextBoxPrice.SelectionLength = 0;
                }
            }
        }

        private void UpArrowButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(EOTextBoxPrice.Text, out int price))
            {
                if (price < int.MaxValue - 50)
                {
                    EOTextBoxPrice.Text = (price + 50).ToString();
                    EOTextBoxPrice.SelectionStart = EOTextBoxAmount.Text.Length;
                    EOTextBoxPrice.SelectionLength = 0;
                }
                else
                {
                    EOTextBoxPrice.Text = (int.MaxValue - 1).ToString();
                    EOTextBoxPrice.SelectionStart = EOTextBoxAmount.Text.Length;
                    EOTextBoxPrice.SelectionLength = 0;
                }
            }
        }
    }
}
