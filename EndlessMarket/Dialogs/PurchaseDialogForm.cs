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
    public partial class PurchaseDialogForm : Form
    {
        private MarketRecord Item { get; set; }
        private int Amount { get; set; } = 1;

        public int PurchasedAmount = -1;

        public PurchaseDialogForm(MarketRecord record, int amount)
        {
            InitializeComponent();

            this.Item = record;
            this.Amount = amount;

            this.EOScrollBarHost.Maximum = this.Amount;
            this.EOScrollBarHost.ValueChanged += (s, e) => {
                if (EOTextBoxValueInputHost.Text != this.EOScrollBarHost.Value.ToString())
                    EOTextBoxValueInputHost.Text = this.EOScrollBarHost.Value.ToString();
            };

            this.EOTextBoxLabel.TextChanged += (s, e) => {
                if (EOTextBoxLabel.Text != this.EOScrollBarHost.Value.ToString()) {
                    if (int.TryParse(EOTextBoxLabel.Text, out var value))
                        EOScrollBarHost.Value = value;
                }
            };

            this.EOScrollBarHost.Value = 1;
            this.EOTextBoxValueInputHost.Text = this.EOScrollBarHost.Value.ToString();
            this.EOTextBoxLabel.Text = "    " + this.EOScrollBarHost.Value.ToString();

            this.PurchaseDescription.Text = $"How much {this.Item.Name}\nwould you like to buy?";
            this.PurchaseDescription.BringToFront();
        }

        public PurchaseDialogForm()
        {
            InitializeComponent();
        }

        private void PurchaseDialogPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PurchaseDialogForm_Load(object sender, EventArgs e)
        {
            this.EOScrollBarHorizontal.FindUnderlyingScrollBar();
            this.EOTextBoxLabel.FindUnderlyingTextBox();

            this.EOScrollBarHost.Value = 1;
        }

        private void EOTextBoxValueInputHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyCode) && e.KeyCode != Keys.Back)
            {
                e.SuppressKeyPress = true;
                return;
            }

            if ((string.IsNullOrEmpty(EOTextBoxValueInputHost.Text) && e.KeyCode == Keys.D0))
            {
                EOTextBoxValueInputHost.Text = 1.ToString();
                EOTextBoxValueInputHost.SelectionStart = EOTextBoxValueInputHost.Text.Length;
                EOTextBoxValueInputHost.SelectionLength = 0;

                e.SuppressKeyPress = true;
                return;
            }

            var digit = char.IsDigit((char)e.KeyCode) ? "" + (char)e.KeyCode : "";

            if (!string.IsNullOrEmpty(EOTextBoxValueInputHost.Text) && e.KeyCode != Keys.Back)
            {
                if (int.Parse(EOTextBoxValueInputHost.Text + digit) > this.Amount)
                {
                    EOTextBoxValueInputHost.Text = this.Amount.ToString();
                    EOTextBoxValueInputHost.SelectionStart = EOTextBoxValueInputHost.Text.Length;
                    EOTextBoxValueInputHost.SelectionLength = 0;

                    e.SuppressKeyPress = true;
                    return;
                }
            }
        }

        private void EOTextBoxValueInputHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.EOScrollBarHost.Value == 0 || string.IsNullOrEmpty(EOTextBoxValueInputHost.Text))
                return;

            if (EOTextBoxValueInputHost.Text != this.EOScrollBarHost.Value.ToString())
                return;

            this.PurchasedAmount = this.EOScrollBarHost.Value;

            var confirmPurchaseDialog = new ConfirmPurchaseDialogForm(
                "  Buy item(s)",
                $"  Buy { this.PurchasedAmount } { this.Item.Name } for { this.Item.Price * this.PurchasedAmount } gold ?"
            );

            if (confirmPurchaseDialog.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Program.CancelButtonPressSound.Play();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Windows API
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

    }
}
