namespace EndlessMarket
{
    partial class InventoryDialogForm
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryDialogForm));
            this.SellDialogFormPanel = new System.Windows.Forms.Panel();
            this.EOScrollBarHost = new System.Windows.Forms.VScrollBar();
            this.InventoryOwnerLabel = new System.Windows.Forms.Label();
            this.EOScrollBarRender = new EndlessMarket.Controls.EOScrollBar();
            this.ItemsFlowLayoutPanel = new EndlessMarket.Controls.EOFlowItemPanel();
            this.CancelButton = new EndlessMarket.Controls.EOButton();
            this.OkButton = new EndlessMarket.Controls.EOButton();
            this.SellDialogFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SellDialogFormPanel
            // 
            this.SellDialogFormPanel.BackgroundImage = global::EndlessMarket.Properties.Resources.SellDialogMarketBackground;
            this.SellDialogFormPanel.Controls.Add(this.EOScrollBarRender);
            this.SellDialogFormPanel.Controls.Add(this.EOScrollBarHost);
            this.SellDialogFormPanel.Controls.Add(this.InventoryOwnerLabel);
            this.SellDialogFormPanel.Controls.Add(this.ItemsFlowLayoutPanel);
            this.SellDialogFormPanel.Controls.Add(this.CancelButton);
            this.SellDialogFormPanel.Controls.Add(this.OkButton);
            this.SellDialogFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellDialogFormPanel.Location = new System.Drawing.Point(0, 0);
            this.SellDialogFormPanel.Name = "SellDialogFormPanel";
            this.SellDialogFormPanel.Size = new System.Drawing.Size(284, 290);
            this.SellDialogFormPanel.TabIndex = 0;
            this.SellDialogFormPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SellDialogForm_MouseDown);
            // 
            // EOScrollBarHost
            // 
            this.EOScrollBarHost.Location = new System.Drawing.Point(251, 44);
            this.EOScrollBarHost.Name = "EOScrollBarHost";
            this.EOScrollBarHost.Size = new System.Drawing.Size(18, 201);
            this.EOScrollBarHost.TabIndex = 0;
            // 
            // InventoryOwnerLabel
            // 
            this.InventoryOwnerLabel.BackColor = System.Drawing.Color.Transparent;
            this.InventoryOwnerLabel.ForeColor = System.Drawing.Color.White;
            this.InventoryOwnerLabel.Location = new System.Drawing.Point(12, 12);
            this.InventoryOwnerLabel.Name = "InventoryOwnerLabel";
            this.InventoryOwnerLabel.Size = new System.Drawing.Size(260, 21);
            this.InventoryOwnerLabel.TabIndex = 10;
            this.InventoryOwnerLabel.Text = "Username\'s Inventory";
            this.InventoryOwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InventoryOwnerLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SellDialogForm_MouseDown);
            // 
            // EOScrollBarRender
            // 
            this.EOScrollBarRender.Location = new System.Drawing.Point(251, 44);
            this.EOScrollBarRender.MultiplierOffset = 150;
            this.EOScrollBarRender.Name = "EOScrollBarRender";
            this.EOScrollBarRender.Size = new System.Drawing.Size(18, 201);
            this.EOScrollBarRender.TabIndex = 11;
            this.EOScrollBarRender.UnderlyingScrollBar = null;
            // 
            // ItemsFlowLayoutPanel
            // 
            this.ItemsFlowLayoutPanel.AutoScroll = true;
            this.ItemsFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.ItemsFlowLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ItemsFlowLayoutPanel.Location = new System.Drawing.Point(12, 44);
            this.ItemsFlowLayoutPanel.Name = "ItemsFlowLayoutPanel";
            this.ItemsFlowLayoutPanel.Size = new System.Drawing.Size(256, 201);
            this.ItemsFlowLayoutPanel.TabIndex = 9;
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.ButtonType = EndlessMarket.Controls.ButtonType.Cancel;
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelButton.Image")));
            this.CancelButton.Location = new System.Drawing.Point(181, 251);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 29);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.ButtonType = EndlessMarket.Controls.ButtonType.Ok;
            this.OkButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Image = ((System.Drawing.Image)(resources.GetObject("OkButton.Image")));
            this.OkButton.Location = new System.Drawing.Point(88, 251);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(91, 29);
            this.OkButton.TabIndex = 7;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // InventoryDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 290);
            this.Controls.Add(this.SellDialogFormPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(284, 290);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(284, 290);
            this.Name = "InventoryDialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SellDialogForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SellDialogForm_MouseDown);
            this.SellDialogFormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SellDialogFormPanel;
        private Controls.EOFlowItemPanel ItemsFlowLayoutPanel;
        private Controls.EOButton CancelButton;
        private Controls.EOButton OkButton;
        internal System.Windows.Forms.Label InventoryOwnerLabel;
        private Controls.EOScrollBar EOScrollBarRender;
        private System.Windows.Forms.VScrollBar EOScrollBarHost;
    }
}