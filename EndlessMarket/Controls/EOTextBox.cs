using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessMarket.Controls
{
    public class EOTextBox : RichTextBox
    {
        public EOTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.UserPaint, true);
        }
    }
}
