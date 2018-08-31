namespace EndlessMarket
{
    partial class ConfirmPurchaseDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmPurchaseDialogForm));
            this.ConfirmPurchasePanel = new System.Windows.Forms.Panel();
            this.OkButton = new EndlessMarket.Controls.EOButton();
            this.CancelButton = new EndlessMarket.Controls.EOButton();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ConfirmPurchasePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmPurchasePanel
            // 
            this.ConfirmPurchasePanel.BackgroundImage = global::EndlessMarket.Properties.Resources.ConfirmPurchaseDialogBackground;
            this.ConfirmPurchasePanel.Controls.Add(this.OkButton);
            this.ConfirmPurchasePanel.Controls.Add(this.CancelButton);
            this.ConfirmPurchasePanel.Controls.Add(this.DescriptionLabel);
            this.ConfirmPurchasePanel.Controls.Add(this.TitleLabel);
            this.ConfirmPurchasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmPurchasePanel.Location = new System.Drawing.Point(0, 0);
            this.ConfirmPurchasePanel.Name = "ConfirmPurchasePanel";
            this.ConfirmPurchasePanel.Size = new System.Drawing.Size(290, 125);
            this.ConfirmPurchasePanel.TabIndex = 0;
            this.ConfirmPurchasePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConfirmPurchasePanel_MouseDown);
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
            this.OkButton.Location = new System.Drawing.Point(84, 82);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(91, 29);
            this.OkButton.TabIndex = 3;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
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
            this.CancelButton.Location = new System.Drawing.Point(181, 82);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 29);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 40);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(266, 39);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "  Buy 1 Item Name for 0 gold ?";
            this.DescriptionLabel.UseCompatibleTextRendering = true;
            this.DescriptionLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DescriptionLabel_MouseDown);
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(266, 20);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "  Buy item(s)";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.UseCompatibleTextRendering = true;
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            // 
            // ConfirmPurchaseDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 125);
            this.Controls.Add(this.ConfirmPurchasePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(290, 125);
            this.MinimumSize = new System.Drawing.Size(290, 125);
            this.Name = "ConfirmPurchaseDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfirmPurchaseDialogForm";
            this.TopMost = true;
            this.ConfirmPurchasePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ConfirmPurchasePanel;
        private Controls.EOButton OkButton;
        private Controls.EOButton CancelButton;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TitleLabel;
    }
}