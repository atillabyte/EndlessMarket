using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using EndlessMarket.Properties;
using System.Drawing.Text;
using System.ComponentModel;

namespace EndlessMarket.Controls
{
    public class EOScrollBarHorizontal : Control
    {
        public HScrollBar UnderlyingScrollBar { get; set; }

        public EOScrollBarHorizontal()
        {
            base.SetStyle(ControlStyles.UserPaint
                        | ControlStyles.ResizeRedraw
                        | ControlStyles.Selectable
                        | ControlStyles.SupportsTransparentBackColor
                        | ControlStyles.AllPaintingInWmPaint
                        | ControlStyles.OptimizedDoubleBuffer, true);

            this.Size = new Size(129, 19);
            this.DoubleBuffered = true;
        }

        public void FindUnderlyingScrollBar()
        {
            if (this.Parent == null)
                return;

            var scrollbar = this.Parent.Controls.Cast<Control>().ToList()
                .Find(c => !c.Equals(this) && c is HScrollBar && c.Bounds.IntersectsWith(this.Bounds));

            if (scrollbar == null)
                return;

            this.UnderlyingScrollBar = (HScrollBar)scrollbar;
            this.UnderlyingScrollBar.Scroll += (s, e) => {
                this.Invalidate();
            };

            this.UnderlyingScrollBar.ValueChanged += (s, e) => {
                this.Invalidate();
            };

            this.UnderlyingScrollBar.SmallChange = 1;
            this.UnderlyingScrollBar.LargeChange = 1;

            //this.UnderlyingScrollBar.Maximum += 2;
        }

        private Bitmap ScrollBackground { get; set; } =
                Resources.ScrollBackgroundHorizontal;

        private Bitmap ScrollThumb = Resources.ScrollThumbWheel;

        private bool IsHovering(Rectangle rectangle) => false;
        //rectangle.Contains(this.PointToClient(Control.MousePosition)); // TODO: too buggy, make more reliable.

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

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.DrawImage(this.ScrollBackground, 0, 0, this.Width, this.Height);

            if (this.UnderlyingScrollBar != null)
            {
                var scrollPercentage = (double)this.UnderlyingScrollBar.Value / this.UnderlyingScrollBar.Maximum;
                var x = 3 + (scrollPercentage * 105);

                g.DrawImage(this.ScrollThumb, (int)x, 2, this.ScrollThumb.Width, this.ScrollThumb.Height);
            }
        }
    }

    public class EOScrollBar : Control
    {
        public VScrollBar UnderlyingScrollBar { get; set; }
        public int MultiplierOffset { get; set; } = 150;

        public EOScrollBar()
        {
            base.SetStyle(ControlStyles.UserPaint
                        | ControlStyles.ResizeRedraw
                        | ControlStyles.Selectable
                        | ControlStyles.SupportsTransparentBackColor
                        | ControlStyles.AllPaintingInWmPaint
                        | ControlStyles.OptimizedDoubleBuffer, true);

            this.Size = new Size(18, 150);
            this.DoubleBuffered = true;
        }

        public void FindUnderlyingScrollBar()
        {
            if (this.Parent == null)
                return;

            var scrollbar = this.Parent.Controls.Cast<Control>().ToList()
                .Find(c => !c.Equals(this) && c is VScrollBar && c.Bounds.IntersectsWith(this.Bounds));

            if (scrollbar == null)
                return;

            this.UnderlyingScrollBar = (VScrollBar)scrollbar;
            this.UnderlyingScrollBar.Scroll += (s, e) => {
                this.Invalidate();
            };

            this.UnderlyingScrollBar.ValueChanged += (s, e) => {
                this.Invalidate();
            };

            this.UnderlyingScrollBar.SmallChange = 6;
            this.UnderlyingScrollBar.LargeChange = 6;
        }

        private Bitmap ScrollBackground { get; set; } =
                Resources.ScrollBackgroundVertical;

        private Bitmap ScrollArrowUp = Resources.ScrollArrowUp;
        private Bitmap ScrollArrowUpPress = Resources.ScrollArrowUpPress;
        private Bitmap ScrollArrowDown = Resources.ScrollArrowDown;
        private Bitmap ScrollArrowDownPress = Resources.ScrollArrowDownPress;
        private Bitmap ScrollThumb = Resources.ScrollThumbWheel;

        private bool IsHovering(Rectangle rectangle) => false; 
                    //rectangle.Contains(this.PointToClient(Control.MousePosition)); // TODO: too buggy, make more reliable.

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

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.DrawImage(this.ScrollBackground, 0, 0, this.Width, this.Height);

            // scroll arrows
            var scrollArrowUpBounds = new Rectangle(1, 1, this.ScrollArrowUp.Width, this.ScrollArrowUp.Height);
            var scrollArrowUp = IsHovering(scrollArrowUpBounds) ? Resources.ScrollArrowUpPress : Resources.ScrollArrowUp;

            var scrollArrowDownBounds = new Rectangle(1, (this.Height - 1) - this.ScrollArrowDown.Height, this.ScrollArrowDown.Width, this.ScrollArrowDown.Height);
            var scrollArrowDown = IsHovering(scrollArrowDownBounds) ? Resources.ScrollArrowDownPress : Resources.ScrollArrowDown;

            g.DrawImage(scrollArrowUp, scrollArrowUpBounds);
            g.DrawImage(scrollArrowDown, scrollArrowDownBounds);

            if (this.UnderlyingScrollBar != null)
            {
                var scrollPercentage = (double)this.UnderlyingScrollBar.Value / this.UnderlyingScrollBar.Maximum;
                var y = 17 + (scrollPercentage * MultiplierOffset);

                g.DrawImage(this.ScrollThumb, 1, (int)y, this.ScrollThumb.Width, this.ScrollThumb.Height);
            }
        }
    }
}
