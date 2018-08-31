namespace EndlessMarket
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.categoryPanel = new System.Windows.Forms.Panel();
            this.tabMisc = new EndlessMarket.EOTabButton();
            this.tabUsables = new EndlessMarket.EOTabButton();
            this.tabArmor = new EndlessMarket.EOTabButton();
            this.tabWeapons = new EndlessMarket.EOTabButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EOItemScrollBar = new CustomScrollBar.ScrollBarEx();
            this.ShopOwnerLabel = new System.Windows.Forms.Label();
            this.flowItemPanel = new EndlessMarket.CustomFlowLayoutPanel();
            this.btnAddItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.categoryPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(41)))), ((int)(((byte)(16)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.categoryPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(623, 291);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // categoryPanel
            // 
            this.categoryPanel.AutoSize = true;
            this.categoryPanel.BackgroundImage = global::EndlessMarket.Properties.Resources.box_bg3;
            this.categoryPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.categoryPanel.Controls.Add(this.tabMisc);
            this.categoryPanel.Controls.Add(this.tabUsables);
            this.categoryPanel.Controls.Add(this.tabArmor);
            this.categoryPanel.Controls.Add(this.tabWeapons);
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryPanel.Location = new System.Drawing.Point(0, 0);
            this.categoryPanel.MinimumSize = new System.Drawing.Size(227, 291);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(227, 291);
            this.categoryPanel.TabIndex = 7;
            // 
            // tabMisc
            // 
            this.tabMisc.BackColor = System.Drawing.Color.Transparent;
            this.tabMisc.FlatAppearance.BorderSize = 0;
            this.tabMisc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tabMisc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tabMisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMisc.ForeColor = System.Drawing.Color.White;
            this.tabMisc.Image = global::EndlessMarket.Properties.Resources.tab2;
            this.tabMisc.Location = new System.Drawing.Point(172, 12);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Size = new System.Drawing.Size(39, 24);
            this.tabMisc.TabIndex = 3;
            this.tabMisc.Text = "Misc";
            this.tabMisc.UseCompatibleTextRendering = true;
            this.tabMisc.UseVisualStyleBackColor = false;
            this.tabMisc.Click += new System.EventHandler(this.tabMisc_Click);
            // 
            // tabUsables
            // 
            this.tabUsables.BackColor = System.Drawing.Color.Transparent;
            this.tabUsables.FlatAppearance.BorderSize = 0;
            this.tabUsables.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tabUsables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tabUsables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabUsables.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabUsables.ForeColor = System.Drawing.Color.White;
            this.tabUsables.Image = global::EndlessMarket.Properties.Resources.tab;
            this.tabUsables.Location = new System.Drawing.Point(118, 12);
            this.tabUsables.Name = "tabUsables";
            this.tabUsables.Size = new System.Drawing.Size(54, 24);
            this.tabUsables.TabIndex = 2;
            this.tabUsables.Text = "Usables";
            this.tabUsables.UseCompatibleTextRendering = true;
            this.tabUsables.UseVisualStyleBackColor = false;
            this.tabUsables.Click += new System.EventHandler(this.tabUsables_Click);
            // 
            // tabArmor
            // 
            this.tabArmor.BackColor = System.Drawing.Color.Transparent;
            this.tabArmor.FlatAppearance.BorderSize = 0;
            this.tabArmor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tabArmor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tabArmor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabArmor.ForeColor = System.Drawing.Color.White;
            this.tabArmor.Image = global::EndlessMarket.Properties.Resources.tab;
            this.tabArmor.Location = new System.Drawing.Point(69, 12);
            this.tabArmor.Name = "tabArmor";
            this.tabArmor.Size = new System.Drawing.Size(50, 24);
            this.tabArmor.TabIndex = 1;
            this.tabArmor.Text = "Armor";
            this.tabArmor.UseCompatibleTextRendering = true;
            this.tabArmor.UseVisualStyleBackColor = false;
            this.tabArmor.Click += new System.EventHandler(this.tabArmor_Click);
            // 
            // tabWeapons
            // 
            this.tabWeapons.BackColor = System.Drawing.Color.Transparent;
            this.tabWeapons.FlatAppearance.BorderSize = 0;
            this.tabWeapons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tabWeapons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tabWeapons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabWeapons.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabWeapons.ForeColor = System.Drawing.Color.White;
            this.tabWeapons.Image = global::EndlessMarket.Properties.Resources.tab;
            this.tabWeapons.Location = new System.Drawing.Point(14, 12);
            this.tabWeapons.Name = "tabWeapons";
            this.tabWeapons.Size = new System.Drawing.Size(55, 24);
            this.tabWeapons.TabIndex = 0;
            this.tabWeapons.Text = "Weapons";
            this.tabWeapons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tabWeapons.UseCompatibleTextRendering = true;
            this.tabWeapons.UseVisualStyleBackColor = false;
            this.tabWeapons.Click += new System.EventHandler(this.tabWeapons_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(-10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 291);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(41)))), ((int)(((byte)(16)))));
            this.panel2.BackgroundImage = global::EndlessMarket.Properties.Resources.itembg3;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.EOItemScrollBar);
            this.panel2.Controls.Add(this.ShopOwnerLabel);
            this.panel2.Controls.Add(this.flowItemPanel);
            this.panel2.Controls.Add(this.btnAddItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(2, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(412, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 291);
            this.panel2.TabIndex = 0;
            // 
            // EOItemScrollBar
            // 
            this.EOItemScrollBar.Location = new System.Drawing.Point(377, 43);
            this.EOItemScrollBar.Name = "EOItemScrollBar";
            this.EOItemScrollBar.Size = new System.Drawing.Size(19, 201);
            this.EOItemScrollBar.TabIndex = 4;
            // 
            // ShopOwnerLabel
            // 
            this.ShopOwnerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ShopOwnerLabel.ForeColor = System.Drawing.Color.White;
            this.ShopOwnerLabel.Location = new System.Drawing.Point(12, 15);
            this.ShopOwnerLabel.Name = "ShopOwnerLabel";
            this.ShopOwnerLabel.Size = new System.Drawing.Size(385, 17);
            this.ShopOwnerLabel.TabIndex = 2;
            this.ShopOwnerLabel.Text = "Xiee\'s Shop";
            this.ShopOwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowItemPanel
            // 
            this.flowItemPanel.AutoScroll = true;
            this.flowItemPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowItemPanel.Location = new System.Drawing.Point(15, 43);
            this.flowItemPanel.Name = "flowItemPanel";
            this.flowItemPanel.Size = new System.Drawing.Size(381, 201);
            this.flowItemPanel.TabIndex = 1;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.Transparent;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Image = global::EndlessMarket.Properties.Resources.add_btn;
            this.btnAddItem.Location = new System.Drawing.Point(306, 250);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(90, 30);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Visible = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            this.btnAddItem.MouseEnter += new System.EventHandler(this.btnAddItem_MouseEnter);
            this.btnAddItem.MouseLeave += new System.EventHandler(this.btnAddItem_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 291);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(723, 330);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Endless Market";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Startup);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.categoryPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddItem;
        private CustomFlowLayoutPanel flowItemPanel;
        private System.Windows.Forms.Panel categoryPanel;
        private System.Windows.Forms.Label ShopOwnerLabel;
        private EOTabButton tabMisc;
        private EOTabButton tabUsables;
        private EOTabButton tabArmor;
        private EOTabButton tabWeapons;
        private CustomScrollBar.ScrollBarEx EOItemScrollBar;
    }
}

