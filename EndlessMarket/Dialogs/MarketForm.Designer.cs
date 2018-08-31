using EndlessMarket.Controls;

namespace EndlessMarket
{
    partial class MarketForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketForm));
            this.MainFormSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CategoryBoxPanel = new System.Windows.Forms.Panel();
            this.CategoryBoxEOScrollBarRender = new EndlessMarket.Controls.EOScrollBar();
            this.CategoryBoxScrollBarHost = new System.Windows.Forms.VScrollBar();
            this.CategoryBoxFlowLayoutPanel = new EndlessMarket.Controls.EOFlowItemPanel();
            this.TabMisc = new EndlessMarket.Controls.EOTabButton();
            this.TabUsables = new EndlessMarket.Controls.EOTabButton();
            this.TabArmor = new EndlessMarket.Controls.EOTabButton();
            this.TabWeapons = new EndlessMarket.Controls.EOTabButton();
            this.ItemBoxPanel = new System.Windows.Forms.Panel();
            this.ItemDeleteButton = new EndlessMarket.Controls.EOButton();
            this.ItemAddButton = new EndlessMarket.Controls.EOButton();
            this.ExitButton = new EndlessMarket.Controls.EOButton();
            this.ItemBoxEOScrollBarRender = new EndlessMarket.Controls.EOScrollBar();
            this.AccountButton = new EndlessMarket.Controls.EOButton();
            this.ShopOwnerLabel = new System.Windows.Forms.Label();
            this.ItemBoxEOScrollBarHost = new System.Windows.Forms.VScrollBar();
            this.ItemBoxFlowLayoutPanel = new EndlessMarket.Controls.EOFlowItemPanel();
            ((System.ComponentModel.ISupportInitialize)(this.MainFormSplitContainer)).BeginInit();
            this.MainFormSplitContainer.Panel1.SuspendLayout();
            this.MainFormSplitContainer.Panel2.SuspendLayout();
            this.MainFormSplitContainer.SuspendLayout();
            this.CategoryBoxPanel.SuspendLayout();
            this.ItemBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormSplitContainer
            // 
            this.MainFormSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainFormSplitContainer.Name = "MainFormSplitContainer";
            // 
            // MainFormSplitContainer.Panel1
            // 
            this.MainFormSplitContainer.Panel1.Controls.Add(this.CategoryBoxPanel);
            // 
            // MainFormSplitContainer.Panel2
            // 
            this.MainFormSplitContainer.Panel2.Controls.Add(this.ItemBoxPanel);
            this.MainFormSplitContainer.Size = new System.Drawing.Size(624, 291);
            this.MainFormSplitContainer.SplitterDistance = 211;
            this.MainFormSplitContainer.SplitterWidth = 1;
            this.MainFormSplitContainer.TabIndex = 0;
            this.MainFormSplitContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            // 
            // CategoryBoxPanel
            // 
            this.CategoryBoxPanel.BackgroundImage = global::EndlessMarket.Properties.Resources.MainFormCategoryMenuBox;
            this.CategoryBoxPanel.Controls.Add(this.CategoryBoxEOScrollBarRender);
            this.CategoryBoxPanel.Controls.Add(this.CategoryBoxScrollBarHost);
            this.CategoryBoxPanel.Controls.Add(this.CategoryBoxFlowLayoutPanel);
            this.CategoryBoxPanel.Controls.Add(this.TabMisc);
            this.CategoryBoxPanel.Controls.Add(this.TabUsables);
            this.CategoryBoxPanel.Controls.Add(this.TabArmor);
            this.CategoryBoxPanel.Controls.Add(this.TabWeapons);
            this.CategoryBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.CategoryBoxPanel.MaximumSize = new System.Drawing.Size(226, 290);
            this.CategoryBoxPanel.MinimumSize = new System.Drawing.Size(226, 290);
            this.CategoryBoxPanel.Name = "CategoryBoxPanel";
            this.CategoryBoxPanel.Size = new System.Drawing.Size(226, 290);
            this.CategoryBoxPanel.TabIndex = 0;
            this.CategoryBoxPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            // 
            // CategoryBoxEOScrollBarRender
            // 
            this.CategoryBoxEOScrollBarRender.Location = new System.Drawing.Point(189, 34);
            this.CategoryBoxEOScrollBarRender.MultiplierOffset = 188;
            this.CategoryBoxEOScrollBarRender.Name = "CategoryBoxEOScrollBarRender";
            this.CategoryBoxEOScrollBarRender.Size = new System.Drawing.Size(18, 237);
            this.CategoryBoxEOScrollBarRender.TabIndex = 8;
            this.CategoryBoxEOScrollBarRender.UnderlyingScrollBar = null;
            // 
            // CategoryBoxScrollBarHost
            // 
            this.CategoryBoxScrollBarHost.Location = new System.Drawing.Point(189, 34);
            this.CategoryBoxScrollBarHost.Maximum = 200;
            this.CategoryBoxScrollBarHost.Name = "CategoryBoxScrollBarHost";
            this.CategoryBoxScrollBarHost.Size = new System.Drawing.Size(18, 237);
            this.CategoryBoxScrollBarHost.TabIndex = 7;
            // 
            // CategoryBoxFlowLayoutPanel
            // 
            this.CategoryBoxFlowLayoutPanel.AutoScroll = true;
            this.CategoryBoxFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.CategoryBoxFlowLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CategoryBoxFlowLayoutPanel.Location = new System.Drawing.Point(21, 34);
            this.CategoryBoxFlowLayoutPanel.Name = "CategoryBoxFlowLayoutPanel";
            this.CategoryBoxFlowLayoutPanel.Size = new System.Drawing.Size(185, 237);
            this.CategoryBoxFlowLayoutPanel.TabIndex = 4;
            // 
            // TabMisc
            // 
            this.TabMisc.BackColor = System.Drawing.Color.Transparent;
            this.TabMisc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabMisc.FlatAppearance.BorderSize = 0;
            this.TabMisc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TabMisc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TabMisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TabMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabMisc.ForeColor = System.Drawing.Color.White;
            this.TabMisc.Image = ((System.Drawing.Image)(resources.GetObject("TabMisc.Image")));
            this.TabMisc.Location = new System.Drawing.Point(167, 12);
            this.TabMisc.Name = "TabMisc";
            this.TabMisc.Size = new System.Drawing.Size(43, 24);
            this.TabMisc.TabIndex = 3;
            this.TabMisc.Text = "Misc";
            this.TabMisc.UseCompatibleTextRendering = true;
            this.TabMisc.UseVisualStyleBackColor = false;
            this.TabMisc.Click += new System.EventHandler(this.TabMisc_Click);
            // 
            // TabUsables
            // 
            this.TabUsables.BackColor = System.Drawing.Color.Transparent;
            this.TabUsables.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabUsables.FlatAppearance.BorderSize = 0;
            this.TabUsables.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TabUsables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TabUsables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TabUsables.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabUsables.ForeColor = System.Drawing.Color.White;
            this.TabUsables.Image = ((System.Drawing.Image)(resources.GetObject("TabUsables.Image")));
            this.TabUsables.Location = new System.Drawing.Point(119, 12);
            this.TabUsables.Name = "TabUsables";
            this.TabUsables.Size = new System.Drawing.Size(50, 24);
            this.TabUsables.TabIndex = 2;
            this.TabUsables.Text = "Usable";
            this.TabUsables.UseCompatibleTextRendering = true;
            this.TabUsables.UseVisualStyleBackColor = false;
            this.TabUsables.Click += new System.EventHandler(this.TabUsables_Click);
            // 
            // TabArmor
            // 
            this.TabArmor.BackColor = System.Drawing.Color.Transparent;
            this.TabArmor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabArmor.FlatAppearance.BorderSize = 0;
            this.TabArmor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TabArmor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TabArmor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TabArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabArmor.ForeColor = System.Drawing.Color.White;
            this.TabArmor.Image = ((System.Drawing.Image)(resources.GetObject("TabArmor.Image")));
            this.TabArmor.Location = new System.Drawing.Point(68, 12);
            this.TabArmor.Name = "TabArmor";
            this.TabArmor.Size = new System.Drawing.Size(50, 24);
            this.TabArmor.TabIndex = 1;
            this.TabArmor.Text = "Armor";
            this.TabArmor.UseCompatibleTextRendering = true;
            this.TabArmor.UseVisualStyleBackColor = false;
            this.TabArmor.Click += new System.EventHandler(this.TabArmor_Click);
            // 
            // TabWeapons
            // 
            this.TabWeapons.BackColor = System.Drawing.Color.Transparent;
            this.TabWeapons.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabWeapons.FlatAppearance.BorderSize = 0;
            this.TabWeapons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TabWeapons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TabWeapons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TabWeapons.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabWeapons.ForeColor = System.Drawing.Color.White;
            this.TabWeapons.Image = ((System.Drawing.Image)(resources.GetObject("TabWeapons.Image")));
            this.TabWeapons.Location = new System.Drawing.Point(14, 12);
            this.TabWeapons.Name = "TabWeapons";
            this.TabWeapons.Size = new System.Drawing.Size(55, 24);
            this.TabWeapons.TabIndex = 0;
            this.TabWeapons.Text = "Weapons";
            this.TabWeapons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TabWeapons.UseCompatibleTextRendering = true;
            this.TabWeapons.UseVisualStyleBackColor = false;
            this.TabWeapons.Click += new System.EventHandler(this.TabWeapons_Click);
            // 
            // ItemBoxPanel
            // 
            this.ItemBoxPanel.BackColor = System.Drawing.Color.Transparent;
            this.ItemBoxPanel.BackgroundImage = global::EndlessMarket.Properties.Resources.MainFormItemBox;
            this.ItemBoxPanel.Controls.Add(this.ItemDeleteButton);
            this.ItemBoxPanel.Controls.Add(this.ItemAddButton);
            this.ItemBoxPanel.Controls.Add(this.ExitButton);
            this.ItemBoxPanel.Controls.Add(this.ItemBoxEOScrollBarRender);
            this.ItemBoxPanel.Controls.Add(this.AccountButton);
            this.ItemBoxPanel.Controls.Add(this.ShopOwnerLabel);
            this.ItemBoxPanel.Controls.Add(this.ItemBoxEOScrollBarHost);
            this.ItemBoxPanel.Controls.Add(this.ItemBoxFlowLayoutPanel);
            this.ItemBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.ItemBoxPanel.MaximumSize = new System.Drawing.Size(412, 290);
            this.ItemBoxPanel.MinimumSize = new System.Drawing.Size(412, 290);
            this.ItemBoxPanel.Name = "ItemBoxPanel";
            this.ItemBoxPanel.Size = new System.Drawing.Size(412, 290);
            this.ItemBoxPanel.TabIndex = 0;
            this.ItemBoxPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            // 
            // ItemDeleteButton
            // 
            this.ItemDeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.ItemDeleteButton.ButtonType = EndlessMarket.Controls.ButtonType.Delete;
            this.ItemDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ItemDeleteButton.FlatAppearance.BorderSize = 0;
            this.ItemDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("ItemDeleteButton.Image")));
            this.ItemDeleteButton.Location = new System.Drawing.Point(195, 250);
            this.ItemDeleteButton.Name = "ItemDeleteButton";
            this.ItemDeleteButton.Size = new System.Drawing.Size(91, 29);
            this.ItemDeleteButton.TabIndex = 7;
            this.ItemDeleteButton.UseVisualStyleBackColor = false;
            this.ItemDeleteButton.Visible = false;
            this.ItemDeleteButton.Click += new System.EventHandler(this.ItemDeleteButton_Click);
            // 
            // ItemAddButton
            // 
            this.ItemAddButton.BackColor = System.Drawing.Color.Transparent;
            this.ItemAddButton.ButtonType = EndlessMarket.Controls.ButtonType.Add;
            this.ItemAddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ItemAddButton.FlatAppearance.BorderSize = 0;
            this.ItemAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemAddButton.Image = ((System.Drawing.Image)(resources.GetObject("ItemAddButton.Image")));
            this.ItemAddButton.Location = new System.Drawing.Point(101, 250);
            this.ItemAddButton.Name = "ItemAddButton";
            this.ItemAddButton.Size = new System.Drawing.Size(91, 29);
            this.ItemAddButton.TabIndex = 2;
            this.ItemAddButton.UseVisualStyleBackColor = false;
            this.ItemAddButton.Visible = false;
            this.ItemAddButton.Click += new System.EventHandler(this.ItemAddButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.ButtonType = EndlessMarket.Controls.ButtonType.Exit;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(309, 250);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(91, 29);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ItemBoxEOScrollBarRender
            // 
            this.ItemBoxEOScrollBarRender.Location = new System.Drawing.Point(377, 43);
            this.ItemBoxEOScrollBarRender.MultiplierOffset = 152;
            this.ItemBoxEOScrollBarRender.Name = "ItemBoxEOScrollBarRender";
            this.ItemBoxEOScrollBarRender.Size = new System.Drawing.Size(18, 201);
            this.ItemBoxEOScrollBarRender.TabIndex = 6;
            this.ItemBoxEOScrollBarRender.UnderlyingScrollBar = null;
            // 
            // AccountButton
            // 
            this.AccountButton.BackColor = System.Drawing.Color.Transparent;
            this.AccountButton.ButtonType = EndlessMarket.Controls.ButtonType.Account;
            this.AccountButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AccountButton.FlatAppearance.BorderSize = 0;
            this.AccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountButton.Image = ((System.Drawing.Image)(resources.GetObject("AccountButton.Image")));
            this.AccountButton.Location = new System.Drawing.Point(7, 250);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AccountButton.Size = new System.Drawing.Size(91, 29);
            this.AccountButton.TabIndex = 4;
            this.AccountButton.UseVisualStyleBackColor = false;
            this.AccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // ShopOwnerLabel
            // 
            this.ShopOwnerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ShopOwnerLabel.ForeColor = System.Drawing.Color.White;
            this.ShopOwnerLabel.Location = new System.Drawing.Point(15, 14);
            this.ShopOwnerLabel.Name = "ShopOwnerLabel";
            this.ShopOwnerLabel.Size = new System.Drawing.Size(381, 17);
            this.ShopOwnerLabel.TabIndex = 1;
            this.ShopOwnerLabel.Text = "Username\'s Shop";
            this.ShopOwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ShopOwnerLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            // 
            // ItemBoxEOScrollBarHost
            // 
            this.ItemBoxEOScrollBarHost.Location = new System.Drawing.Point(377, 43);
            this.ItemBoxEOScrollBarHost.Maximum = 200;
            this.ItemBoxEOScrollBarHost.Name = "ItemBoxEOScrollBarHost";
            this.ItemBoxEOScrollBarHost.Size = new System.Drawing.Size(18, 201);
            this.ItemBoxEOScrollBarHost.TabIndex = 5;
            // 
            // ItemBoxFlowLayoutPanel
            // 
            this.ItemBoxFlowLayoutPanel.AutoScroll = true;
            this.ItemBoxFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.ItemBoxFlowLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ItemBoxFlowLayoutPanel.Location = new System.Drawing.Point(15, 43);
            this.ItemBoxFlowLayoutPanel.Name = "ItemBoxFlowLayoutPanel";
            this.ItemBoxFlowLayoutPanel.Size = new System.Drawing.Size(380, 201);
            this.ItemBoxFlowLayoutPanel.TabIndex = 0;
            // 
            // MarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(49)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(624, 291);
            this.Controls.Add(this.MainFormSplitContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(624, 291);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(624, 291);
            this.Name = "MarketForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Endless Market";
            this.Load += new System.EventHandler(this.LoadForm);
            this.VisibleChanged += new System.EventHandler(this.FormVisibilityChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.MainFormSplitContainer.Panel1.ResumeLayout(false);
            this.MainFormSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainFormSplitContainer)).EndInit();
            this.MainFormSplitContainer.ResumeLayout(false);
            this.CategoryBoxPanel.ResumeLayout(false);
            this.ItemBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer MainFormSplitContainer;
        internal System.Windows.Forms.Panel CategoryBoxPanel;
        internal System.Windows.Forms.Panel ItemBoxPanel;
        internal System.Windows.Forms.Label ShopOwnerLabel;
        internal EOFlowItemPanel ItemBoxFlowLayoutPanel;
        internal EOTabButton TabWeapons;
        internal EOTabButton TabMisc;
        internal EOTabButton TabUsables;
        internal EOTabButton TabArmor;
        private EOButton ItemAddButton;
        private System.Windows.Forms.VScrollBar ItemBoxEOScrollBarHost;
        private EOScrollBar ItemBoxEOScrollBarRender;
        private EOButton ExitButton;
        private EOButton AccountButton;
        private EOScrollBar CategoryBoxEOScrollBarRender;
        private System.Windows.Forms.VScrollBar CategoryBoxScrollBarHost;
        internal EOFlowItemPanel CategoryBoxFlowLayoutPanel;
        private EOButton ItemDeleteButton;
    }
}

