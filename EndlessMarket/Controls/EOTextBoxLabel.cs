using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessMarket.Controls
{
    public class EOTextBoxLabel : Label
    {
        public RichTextBox UnderlyingTextBox { get; set; }

        public bool ValueBox = false;
        public int MaxValue = 1;
        public bool GoldBox = false;

        public EOTextBoxLabel()
        {

        }

        public void FindUnderlyingTextBox()
        {
            if (this.Parent == null)
                return;

            var textbox = this.Parent.Controls.Cast<Control>().ToList()
                .Find(c => !c.Equals(this) && c is RichTextBox && c.Bounds.IntersectsWith(this.Bounds));

            if (textbox == null)
                return;

            this.UnderlyingTextBox = (RichTextBox)textbox;
            this.UnderlyingTextBox.TextChanged += (s, e) => {
                this.Text = !ValueBox ? "    " + this.UnderlyingTextBox.Text :
                            !GoldBox ? this.UnderlyingTextBox.Text + " / " + this.MaxValue :
                            this.UnderlyingTextBox.Text + "g";
            };
        }

        private int WM_NCHITTEST = 132;
        private int HTTRANSPARENT = -1;
        protected override void WndProc(ref Message m)
        {
            // Do not allow this window to become active - it should be "transparent" 
            // to mouse clicks i.e. Mouse clicks pass through this window
            if (m.Msg == WM_NCHITTEST) {
                m.Result = new IntPtr(HTTRANSPARENT);
                return;
            }

            base.WndProc(ref m);
        }
    }
}
