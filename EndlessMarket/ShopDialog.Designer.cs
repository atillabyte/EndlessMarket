namespace EndlessMarket
{
    partial class ShopDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ShopOwnerLabel = new System.Windows.Forms.Label();
            this.scrollBarEx1 = new CustomScrollBar.ScrollBarEx();
            this.SuspendLayout();
            // 
            // ShopOwnerLabel
            // 
            this.ShopOwnerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ShopOwnerLabel.Font = new System.Drawing.Font("Calibri Light", 10.75F);
            this.ShopOwnerLabel.ForeColor = System.Drawing.Color.White;
            this.ShopOwnerLabel.Location = new System.Drawing.Point(22, 42);
            this.ShopOwnerLabel.Name = "ShopOwnerLabel";
            this.ShopOwnerLabel.Size = new System.Drawing.Size(169, 48);
            this.ShopOwnerLabel.TabIndex = 3;
            this.ShopOwnerLabel.Text = "How much Item Name would you like to buy?";
            this.ShopOwnerLabel.UseCompatibleTextRendering = true;
            // 
            // scrollBarEx1
            // 
            this.scrollBarEx1.Location = new System.Drawing.Point(22, 93);
            this.scrollBarEx1.Name = "scrollBarEx1";
            this.scrollBarEx1.Opacity = 0D;
            this.scrollBarEx1.Orientation = CustomScrollBar.ScrollBarOrientation.Horizontal;
            this.scrollBarEx1.Size = new System.Drawing.Size(151, 19);
            this.scrollBarEx1.TabIndex = 4;
            // 
            // ShopDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EndlessMarket.Properties.Resources.market_shop_dialog;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(265, 170);
            this.Controls.Add(this.scrollBarEx1);
            this.Controls.Add(this.ShopOwnerLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShopDialog";
            this.Text = "ShopDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ShopOwnerLabel;
        private CustomScrollBar.ScrollBarEx scrollBarEx1;
    }
}