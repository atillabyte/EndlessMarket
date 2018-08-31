namespace EndlessMarket
{
    partial class SellItemDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellItemDialogForm));
            this.SellItemDialogPanel = new System.Windows.Forms.Panel();
            this.EOTextBoxPrice = new System.Windows.Forms.RichTextBox();
            this.EOTextBoxAmount = new System.Windows.Forms.RichTextBox();
            this.ItemPreviewFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DownArrowButton = new EndlessMarket.Controls.EOButton();
            this.UpArrowButton = new EndlessMarket.Controls.EOButton();
            this.CancelButton = new EndlessMarket.Controls.EOButton();
            this.OkButton = new EndlessMarket.Controls.EOButton();
            this.PriceLabel = new EndlessMarket.Controls.EOTextBoxLabel();
            this.AmountLabel = new EndlessMarket.Controls.EOTextBoxLabel();
            this.SellItemDialogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SellItemDialogPanel
            // 
            this.SellItemDialogPanel.BackgroundImage = global::EndlessMarket.Properties.Resources.SellDialogBackground;
            this.SellItemDialogPanel.Controls.Add(this.DownArrowButton);
            this.SellItemDialogPanel.Controls.Add(this.UpArrowButton);
            this.SellItemDialogPanel.Controls.Add(this.CancelButton);
            this.SellItemDialogPanel.Controls.Add(this.OkButton);
            this.SellItemDialogPanel.Controls.Add(this.PriceLabel);
            this.SellItemDialogPanel.Controls.Add(this.EOTextBoxPrice);
            this.SellItemDialogPanel.Controls.Add(this.AmountLabel);
            this.SellItemDialogPanel.Controls.Add(this.EOTextBoxAmount);
            this.SellItemDialogPanel.Controls.Add(this.ItemPreviewFlowLayoutPanel);
            this.SellItemDialogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellItemDialogPanel.Location = new System.Drawing.Point(0, 0);
            this.SellItemDialogPanel.Name = "SellItemDialogPanel";
            this.SellItemDialogPanel.Size = new System.Drawing.Size(329, 211);
            this.SellItemDialogPanel.TabIndex = 0;
            this.SellItemDialogPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SellItemDialogPanel_MouseDown);
            // 
            // EOTextBoxPrice
            // 
            this.EOTextBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EOTextBoxPrice.Location = new System.Drawing.Point(142, 105);
            this.EOTextBoxPrice.Multiline = false;
            this.EOTextBoxPrice.Name = "EOTextBoxPrice";
            this.EOTextBoxPrice.Size = new System.Drawing.Size(86, 24);
            this.EOTextBoxPrice.TabIndex = 9;
            this.EOTextBoxPrice.Text = "";
            this.EOTextBoxPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EOTextBoxPrice_KeyDown);
            // 
            // EOTextBoxAmount
            // 
            this.EOTextBoxAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EOTextBoxAmount.Location = new System.Drawing.Point(142, 56);
            this.EOTextBoxAmount.Name = "EOTextBoxAmount";
            this.EOTextBoxAmount.Size = new System.Drawing.Size(144, 24);
            this.EOTextBoxAmount.TabIndex = 8;
            this.EOTextBoxAmount.Text = "";
            this.EOTextBoxAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EOTextBoxAmount_KeyDown);
            // 
            // ItemPreviewFlowLayoutPanel
            // 
            this.ItemPreviewFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.ItemPreviewFlowLayoutPanel.Location = new System.Drawing.Point(22, 75);
            this.ItemPreviewFlowLayoutPanel.Name = "ItemPreviewFlowLayoutPanel";
            this.ItemPreviewFlowLayoutPanel.Size = new System.Drawing.Size(98, 43);
            this.ItemPreviewFlowLayoutPanel.TabIndex = 0;
            // 
            // DownArrowButton
            // 
            this.DownArrowButton.BackColor = System.Drawing.Color.Transparent;
            this.DownArrowButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DownArrowButton.FlatAppearance.BorderSize = 0;
            this.DownArrowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DownArrowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DownArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownArrowButton.Location = new System.Drawing.Point(237, 116);
            this.DownArrowButton.Name = "DownArrowButton";
            this.DownArrowButton.Size = new System.Drawing.Size(20, 13);
            this.DownArrowButton.TabIndex = 13;
            this.DownArrowButton.UseVisualStyleBackColor = false;
            this.DownArrowButton.Click += new System.EventHandler(this.DownArrowButton_Click);
            // 
            // UpArrowButton
            // 
            this.UpArrowButton.BackColor = System.Drawing.Color.Transparent;
            this.UpArrowButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UpArrowButton.FlatAppearance.BorderSize = 0;
            this.UpArrowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UpArrowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UpArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpArrowButton.Location = new System.Drawing.Point(237, 105);
            this.UpArrowButton.Name = "UpArrowButton";
            this.UpArrowButton.Size = new System.Drawing.Size(20, 13);
            this.UpArrowButton.TabIndex = 12;
            this.UpArrowButton.UseVisualStyleBackColor = false;
            this.UpArrowButton.Click += new System.EventHandler(this.UpArrowButton_Click);
            this.UpArrowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpArrowButton_MouseDown);
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
            this.CancelButton.Location = new System.Drawing.Point(216, 162);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 29);
            this.CancelButton.TabIndex = 11;
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
            this.OkButton.Location = new System.Drawing.Point(123, 162);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(91, 29);
            this.OkButton.TabIndex = 10;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // PriceLabel
            // 
            this.PriceLabel.BackColor = System.Drawing.Color.Transparent;
            this.PriceLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PriceLabel.ForeColor = System.Drawing.Color.White;
            this.PriceLabel.Location = new System.Drawing.Point(142, 105);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(86, 24);
            this.PriceLabel.TabIndex = 5;
            this.PriceLabel.Text = "1g";
            this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PriceLabel.UnderlyingTextBox = null;
            this.PriceLabel.UseCompatibleTextRendering = true;
            // 
            // AmountLabel
            // 
            this.AmountLabel.BackColor = System.Drawing.Color.Transparent;
            this.AmountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmountLabel.ForeColor = System.Drawing.Color.White;
            this.AmountLabel.Location = new System.Drawing.Point(142, 56);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(144, 25);
            this.AmountLabel.TabIndex = 5;
            this.AmountLabel.Text = "0 / 0";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AmountLabel.UnderlyingTextBox = null;
            this.AmountLabel.UseCompatibleTextRendering = true;
            // 
            // SellItemDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 211);
            this.Controls.Add(this.SellItemDialogPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(329, 211);
            this.MinimumSize = new System.Drawing.Size(329, 211);
            this.Name = "SellItemDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadForm);
            this.SellItemDialogPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SellItemDialogPanel;
        private Controls.EOTextBoxLabel PriceLabel;
        private System.Windows.Forms.RichTextBox EOTextBoxPrice;
        private Controls.EOTextBoxLabel AmountLabel;
        private System.Windows.Forms.RichTextBox EOTextBoxAmount;
        private System.Windows.Forms.FlowLayoutPanel ItemPreviewFlowLayoutPanel;
        private Controls.EOButton CancelButton;
        private Controls.EOButton OkButton;
        private Controls.EOButton DownArrowButton;
        private Controls.EOButton UpArrowButton;
    }
}