namespace EndlessMarket
{
    partial class ReturnItemDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnItemDialogForm));
            this.PurchaseDialogPanel = new System.Windows.Forms.Panel();
            this.CancelButton = new EndlessMarket.Controls.EOButton();
            this.OkButton = new EndlessMarket.Controls.EOButton();
            this.EOTextBoxPanel = new System.Windows.Forms.Panel();
            this.EOTextBoxLabel = new EndlessMarket.Controls.EOTextBoxLabel();
            this.EOTextBoxValueInputHost = new EndlessMarket.Controls.EOTextBox();
            this.CoverUpPanelLeft = new System.Windows.Forms.Panel();
            this.EOScrollBarHorizontal = new EndlessMarket.Controls.EOScrollBarHorizontal();
            this.EOScrollBarHost = new System.Windows.Forms.HScrollBar();
            this.ReturnDescription = new System.Windows.Forms.Label();
            this.PurchaseDialogPanel.SuspendLayout();
            this.EOTextBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PurchaseDialogPanel
            // 
            this.PurchaseDialogPanel.BackgroundImage = global::EndlessMarket.Properties.Resources.PurchaseDialogMarketBackground;
            this.PurchaseDialogPanel.Controls.Add(this.CancelButton);
            this.PurchaseDialogPanel.Controls.Add(this.OkButton);
            this.PurchaseDialogPanel.Controls.Add(this.EOTextBoxPanel);
            this.PurchaseDialogPanel.Controls.Add(this.CoverUpPanelLeft);
            this.PurchaseDialogPanel.Controls.Add(this.EOScrollBarHorizontal);
            this.PurchaseDialogPanel.Controls.Add(this.EOScrollBarHost);
            this.PurchaseDialogPanel.Controls.Add(this.ReturnDescription);
            this.PurchaseDialogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PurchaseDialogPanel.Location = new System.Drawing.Point(0, 0);
            this.PurchaseDialogPanel.Name = "PurchaseDialogPanel";
            this.PurchaseDialogPanel.Size = new System.Drawing.Size(265, 170);
            this.PurchaseDialogPanel.TabIndex = 0;
            this.PurchaseDialogPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReturnDialogPanel_MouseDown);
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
            this.CancelButton.Location = new System.Drawing.Point(152, 124);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 29);
            this.CancelButton.TabIndex = 6;
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
            this.OkButton.Location = new System.Drawing.Point(59, 124);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(91, 29);
            this.OkButton.TabIndex = 5;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // EOTextBoxPanel
            // 
            this.EOTextBoxPanel.BackgroundImage = global::EndlessMarket.Properties.Resources.InputTextBackground;
            this.EOTextBoxPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EOTextBoxPanel.Controls.Add(this.EOTextBoxLabel);
            this.EOTextBoxPanel.Controls.Add(this.EOTextBoxValueInputHost);
            this.EOTextBoxPanel.Location = new System.Drawing.Point(148, 94);
            this.EOTextBoxPanel.Name = "EOTextBoxPanel";
            this.EOTextBoxPanel.Size = new System.Drawing.Size(96, 19);
            this.EOTextBoxPanel.TabIndex = 4;
            // 
            // EOTextBoxLabel
            // 
            this.EOTextBoxLabel.AutoSize = true;
            this.EOTextBoxLabel.BackColor = System.Drawing.Color.Transparent;
            this.EOTextBoxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EOTextBoxLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EOTextBoxLabel.ForeColor = System.Drawing.Color.White;
            this.EOTextBoxLabel.Image = ((System.Drawing.Image)(resources.GetObject("EOTextBoxLabel.Image")));
            this.EOTextBoxLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.EOTextBoxLabel.Location = new System.Drawing.Point(0, 0);
            this.EOTextBoxLabel.Name = "EOTextBoxLabel";
            this.EOTextBoxLabel.Size = new System.Drawing.Size(28, 17);
            this.EOTextBoxLabel.TabIndex = 5;
            this.EOTextBoxLabel.Text = "        ";
            this.EOTextBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EOTextBoxLabel.UnderlyingTextBox = null;
            this.EOTextBoxLabel.UseCompatibleTextRendering = true;
            // 
            // EOTextBoxValueInputHost
            // 
            this.EOTextBoxValueInputHost.BackColor = System.Drawing.Color.Transparent;
            this.EOTextBoxValueInputHost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EOTextBoxValueInputHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EOTextBoxValueInputHost.ForeColor = System.Drawing.Color.Black;
            this.EOTextBoxValueInputHost.Location = new System.Drawing.Point(0, 0);
            this.EOTextBoxValueInputHost.MaxLength = 16;
            this.EOTextBoxValueInputHost.Multiline = false;
            this.EOTextBoxValueInputHost.Name = "EOTextBoxValueInputHost";
            this.EOTextBoxValueInputHost.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.EOTextBoxValueInputHost.ShortcutsEnabled = false;
            this.EOTextBoxValueInputHost.ShowSelectionMargin = true;
            this.EOTextBoxValueInputHost.Size = new System.Drawing.Size(96, 19);
            this.EOTextBoxValueInputHost.TabIndex = 0;
            this.EOTextBoxValueInputHost.Text = "";
            this.EOTextBoxValueInputHost.WordWrap = false;
            this.EOTextBoxValueInputHost.TextChanged += new System.EventHandler(this.EOTextBoxValueInputHost_TextChanged);
            this.EOTextBoxValueInputHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EOTextBoxValueInputHost_KeyDown);
            // 
            // CoverUpPanelLeft
            // 
            this.CoverUpPanelLeft.BackgroundImage = global::EndlessMarket.Properties.Resources.PurchaseDialogMarketBackground;
            this.CoverUpPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.CoverUpPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.CoverUpPanelLeft.Name = "CoverUpPanelLeft";
            this.CoverUpPanelLeft.Size = new System.Drawing.Size(26, 170);
            this.CoverUpPanelLeft.TabIndex = 3;
            // 
            // EOScrollBarHorizontal
            // 
            this.EOScrollBarHorizontal.Location = new System.Drawing.Point(22, 94);
            this.EOScrollBarHorizontal.Name = "EOScrollBarHorizontal";
            this.EOScrollBarHorizontal.Size = new System.Drawing.Size(129, 19);
            this.EOScrollBarHorizontal.TabIndex = 2;
            this.EOScrollBarHorizontal.Text = "eoScrollBarHorizontal1";
            this.EOScrollBarHorizontal.UnderlyingScrollBar = null;
            // 
            // EOScrollBarHost
            // 
            this.EOScrollBarHost.Location = new System.Drawing.Point(9, 94);
            this.EOScrollBarHost.Maximum = 10000;
            this.EOScrollBarHost.Minimum = 1;
            this.EOScrollBarHost.Name = "EOScrollBarHost";
            this.EOScrollBarHost.Size = new System.Drawing.Size(159, 19);
            this.EOScrollBarHost.TabIndex = 1;
            this.EOScrollBarHost.Value = 1;
            // 
            // ReturnDescription
            // 
            this.ReturnDescription.BackColor = System.Drawing.Color.Transparent;
            this.ReturnDescription.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnDescription.ForeColor = System.Drawing.Color.White;
            this.ReturnDescription.Location = new System.Drawing.Point(22, 43);
            this.ReturnDescription.Name = "ReturnDescription";
            this.ReturnDescription.Size = new System.Drawing.Size(224, 51);
            this.ReturnDescription.TabIndex = 0;
            this.ReturnDescription.Text = "How much Item Name\r\nwould you like to retrieve?";
            this.ReturnDescription.UseCompatibleTextRendering = true;
            // 
            // ReturnItemDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 170);
            this.Controls.Add(this.PurchaseDialogPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(265, 170);
            this.MinimumSize = new System.Drawing.Size(265, 170);
            this.Name = "ReturnItemDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PurchaseDialogForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ReturnDialogForm_Load);
            this.PurchaseDialogPanel.ResumeLayout(false);
            this.EOTextBoxPanel.ResumeLayout(false);
            this.EOTextBoxPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PurchaseDialogPanel;
        private System.Windows.Forms.HScrollBar EOScrollBarHost;
        private System.Windows.Forms.Label ReturnDescription;
        private Controls.EOScrollBarHorizontal EOScrollBarHorizontal;
        private System.Windows.Forms.Panel CoverUpPanelLeft;
        private System.Windows.Forms.Panel EOTextBoxPanel;
        private Controls.EOTextBox EOTextBoxValueInputHost;
        private Controls.EOTextBoxLabel EOTextBoxLabel;
        private Controls.EOButton CancelButton;
        private Controls.EOButton OkButton;
    }
}