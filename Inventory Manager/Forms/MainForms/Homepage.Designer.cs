using System.Windows.Forms;

namespace Inventory_Manager
{
    partial class Homepage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.ProgramNameLabel = new System.Windows.Forms.Label();
            this.ProductsLabel = new System.Windows.Forms.Label();
            this.SalesLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ShortcutsGuidanceBtn = new System.Windows.Forms.Button();
            this.PurchasesLabel = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnsPanel = new System.Windows.Forms.Panel();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.ShowBtnsNamesBtn = new System.Windows.Forms.Button();
            this.ProductsPanel = new System.Windows.Forms.Panel();
            this.ProductsBtn = new System.Windows.Forms.Button();
            this.PurchasesPanel = new System.Windows.Forms.Panel();
            this.PurchasesBtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.SalesBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SaleLogBtn = new System.Windows.Forms.Button();
            this.OffersLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SuppliersBtn = new System.Windows.Forms.Button();
            this.SuppliersLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CustomersBtn = new System.Windows.Forms.Button();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ProductReportBtn = new System.Windows.Forms.Button();
            this.ProductsReportLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.InventoryReportBtn = new System.Windows.Forms.Button();
            this.InventoryReportLabel = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.HomepageBtn = new System.Windows.Forms.Button();
            this.HomepageLabel = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.PrefButton = new System.Windows.Forms.Button();
            this.PrefLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RolesBtn = new System.Windows.Forms.Button();
            this.RolesLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TerminalBtn = new System.Windows.Forms.Button();
            this.TerminalLabel = new System.Windows.Forms.Label();
            this.sideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.NoticeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangePasswordBtn = new System.Windows.Forms.Button();
            this.CompanyLogoPicture = new System.Windows.Forms.PictureBox();
            this.NoticeArrowPicture = new System.Windows.Forms.PictureBox();
            this.AsideCubesPicture = new System.Windows.Forms.PictureBox();
            this.ViewFormPanel = new System.Windows.Forms.Panel();
            this.sidebar.SuspendLayout();
            this.BtnsPanel.SuspendLayout();
            this.ProductsPanel.SuspendLayout();
            this.PurchasesPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeArrowPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AsideCubesPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgramNameLabel
            // 
            this.ProgramNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProgramNameLabel.AutoSize = true;
            this.ProgramNameLabel.Font = new System.Drawing.Font("Bauhaus 93", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramNameLabel.Location = new System.Drawing.Point(296, 9);
            this.ProgramNameLabel.Name = "ProgramNameLabel";
            this.ProgramNameLabel.Size = new System.Drawing.Size(412, 98);
            this.ProgramNameLabel.TabIndex = 9;
            this.ProgramNameLabel.Text = " Paytek Inventory \r\nManagement System";
            // 
            // ProductsLabel
            // 
            this.ProductsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductsLabel.AutoSize = true;
            this.ProductsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductsLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsLabel.ForeColor = System.Drawing.Color.White;
            this.ProductsLabel.Location = new System.Drawing.Point(73, 11);
            this.ProductsLabel.Name = "ProductsLabel";
            this.ProductsLabel.Size = new System.Drawing.Size(93, 21);
            this.ProductsLabel.TabIndex = 11;
            this.ProductsLabel.Text = "Products";
            this.ProductsLabel.Click += new System.EventHandler(this.ProductsLabel_Click);
            // 
            // SalesLabel
            // 
            this.SalesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SalesLabel.AutoSize = true;
            this.SalesLabel.BackColor = System.Drawing.Color.Transparent;
            this.SalesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SalesLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesLabel.ForeColor = System.Drawing.Color.White;
            this.SalesLabel.Location = new System.Drawing.Point(73, 15);
            this.SalesLabel.Name = "SalesLabel";
            this.SalesLabel.Size = new System.Drawing.Size(56, 21);
            this.SalesLabel.TabIndex = 14;
            this.SalesLabel.Text = "Sales";
            this.SalesLabel.Click += new System.EventHandler(this.SalesLabel_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Harlow Solid Italic", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(961, 616);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 45);
            this.label9.TabIndex = 23;
            this.label9.Text = "2025©";
            // 
            // ShortcutsGuidanceBtn
            // 
            this.ShortcutsGuidanceBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ShortcutsGuidanceBtn.BackColor = System.Drawing.Color.Silver;
            this.ShortcutsGuidanceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShortcutsGuidanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShortcutsGuidanceBtn.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortcutsGuidanceBtn.ForeColor = System.Drawing.Color.Black;
            this.ShortcutsGuidanceBtn.Location = new System.Drawing.Point(426, 658);
            this.ShortcutsGuidanceBtn.Name = "ShortcutsGuidanceBtn";
            this.ShortcutsGuidanceBtn.Size = new System.Drawing.Size(162, 44);
            this.ShortcutsGuidanceBtn.TabIndex = 6;
            this.ShortcutsGuidanceBtn.Text = "Shortcuts Guidance";
            this.ShortcutsGuidanceBtn.UseVisualStyleBackColor = false;
            this.ShortcutsGuidanceBtn.Click += new System.EventHandler(this.ShortCutGuidanceBtn_Click);
            // 
            // PurchasesLabel
            // 
            this.PurchasesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PurchasesLabel.AutoSize = true;
            this.PurchasesLabel.BackColor = System.Drawing.Color.Transparent;
            this.PurchasesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PurchasesLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurchasesLabel.ForeColor = System.Drawing.Color.White;
            this.PurchasesLabel.Location = new System.Drawing.Point(73, 13);
            this.PurchasesLabel.Name = "PurchasesLabel";
            this.PurchasesLabel.Size = new System.Drawing.Size(105, 21);
            this.PurchasesLabel.TabIndex = 31;
            this.PurchasesLabel.Text = "Purchases";
            this.PurchasesLabel.Click += new System.EventHandler(this.PurchasesLabel_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.sidebar.Controls.Add(this.BtnsPanel);
            this.sidebar.Controls.Add(this.ProductsPanel);
            this.sidebar.Controls.Add(this.PurchasesPanel);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Controls.Add(this.panel7);
            this.sidebar.Controls.Add(this.panel9);
            this.sidebar.Controls.Add(this.panel10);
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MaximumSize = new System.Drawing.Size(233, 800);
            this.sidebar.MinimumSize = new System.Drawing.Size(67, 676);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(67, 706);
            this.sidebar.TabIndex = 33;
            // 
            // BtnsPanel
            // 
            this.BtnsPanel.Controls.Add(this.MenuLabel);
            this.BtnsPanel.Controls.Add(this.ShowBtnsNamesBtn);
            this.BtnsPanel.Location = new System.Drawing.Point(3, 3);
            this.BtnsPanel.Name = "BtnsPanel";
            this.BtnsPanel.Size = new System.Drawing.Size(224, 58);
            this.BtnsPanel.TabIndex = 0;
            // 
            // MenuLabel
            // 
            this.MenuLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLabel.ForeColor = System.Drawing.Color.White;
            this.MenuLabel.Location = new System.Drawing.Point(73, 20);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(64, 21);
            this.MenuLabel.TabIndex = 12;
            this.MenuLabel.Text = "Menu";
            this.MenuLabel.Click += new System.EventHandler(this.MenuLabel_Click);
            // 
            // ShowBtnsNamesBtn
            // 
            this.ShowBtnsNamesBtn.BackColor = System.Drawing.Color.Transparent;
            this.ShowBtnsNamesBtn.BackgroundImage = global::Inventory_Manager.Properties.Resources.menu;
            this.ShowBtnsNamesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShowBtnsNamesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowBtnsNamesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowBtnsNamesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.ShowBtnsNamesBtn.Location = new System.Drawing.Point(3, 8);
            this.ShowBtnsNamesBtn.Name = "ShowBtnsNamesBtn";
            this.ShowBtnsNamesBtn.Size = new System.Drawing.Size(56, 47);
            this.ShowBtnsNamesBtn.TabIndex = 0;
            this.ShowBtnsNamesBtn.UseVisualStyleBackColor = false;
            this.ShowBtnsNamesBtn.Click += new System.EventHandler(this.Menu_Click);
            // 
            // ProductsPanel
            // 
            this.ProductsPanel.Controls.Add(this.ProductsBtn);
            this.ProductsPanel.Controls.Add(this.ProductsLabel);
            this.ProductsPanel.Location = new System.Drawing.Point(3, 67);
            this.ProductsPanel.Name = "ProductsPanel";
            this.ProductsPanel.Size = new System.Drawing.Size(224, 48);
            this.ProductsPanel.TabIndex = 2;
            // 
            // ProductsBtn
            // 
            this.ProductsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductsBtn.BackColor = System.Drawing.Color.Transparent;
            this.ProductsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProductsBtn.BackgroundImage")));
            this.ProductsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProductsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.ProductsBtn.Location = new System.Drawing.Point(2, 2);
            this.ProductsBtn.Name = "ProductsBtn";
            this.ProductsBtn.Size = new System.Drawing.Size(56, 47);
            this.ProductsBtn.TabIndex = 1;
            this.ProductsBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ProductsBtn.UseVisualStyleBackColor = false;
            this.ProductsBtn.Click += new System.EventHandler(this.ProductsBtn_Click);
            // 
            // PurchasesPanel
            // 
            this.PurchasesPanel.Controls.Add(this.PurchasesBtn);
            this.PurchasesPanel.Controls.Add(this.PurchasesLabel);
            this.PurchasesPanel.Location = new System.Drawing.Point(3, 121);
            this.PurchasesPanel.Name = "PurchasesPanel";
            this.PurchasesPanel.Size = new System.Drawing.Size(224, 48);
            this.PurchasesPanel.TabIndex = 5;
            // 
            // PurchasesBtn
            // 
            this.PurchasesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PurchasesBtn.BackColor = System.Drawing.Color.Transparent;
            this.PurchasesBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PurchasesBtn.BackgroundImage")));
            this.PurchasesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PurchasesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PurchasesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PurchasesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.PurchasesBtn.Location = new System.Drawing.Point(0, 1);
            this.PurchasesBtn.Name = "PurchasesBtn";
            this.PurchasesBtn.Size = new System.Drawing.Size(56, 47);
            this.PurchasesBtn.TabIndex = 28;
            this.PurchasesBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PurchasesBtn.UseVisualStyleBackColor = false;
            this.PurchasesBtn.Click += new System.EventHandler(this.PurchasesBtn_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.SalesBtn);
            this.panel6.Controls.Add(this.SalesLabel);
            this.panel6.Location = new System.Drawing.Point(3, 175);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(224, 48);
            this.panel6.TabIndex = 6;
            // 
            // SalesBtn
            // 
            this.SalesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SalesBtn.AutoSize = true;
            this.SalesBtn.BackColor = System.Drawing.Color.Transparent;
            this.SalesBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SalesBtn.BackgroundImage")));
            this.SalesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SalesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SalesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SalesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.SalesBtn.Location = new System.Drawing.Point(2, -1);
            this.SalesBtn.Name = "SalesBtn";
            this.SalesBtn.Size = new System.Drawing.Size(56, 47);
            this.SalesBtn.TabIndex = 2;
            this.SalesBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SalesBtn.UseVisualStyleBackColor = false;
            this.SalesBtn.Click += new System.EventHandler(this.SalesBtn_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.SaleLogBtn);
            this.panel5.Controls.Add(this.OffersLabel);
            this.panel5.Location = new System.Drawing.Point(3, 229);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(224, 48);
            this.panel5.TabIndex = 47;
            // 
            // SaleLogBtn
            // 
            this.SaleLogBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleLogBtn.BackColor = System.Drawing.Color.Transparent;
            this.SaleLogBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaleLogBtn.BackgroundImage")));
            this.SaleLogBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaleLogBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaleLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaleLogBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.SaleLogBtn.Location = new System.Drawing.Point(0, 0);
            this.SaleLogBtn.Name = "SaleLogBtn";
            this.SaleLogBtn.Size = new System.Drawing.Size(56, 47);
            this.SaleLogBtn.TabIndex = 4;
            this.SaleLogBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SaleLogBtn.UseVisualStyleBackColor = false;
            this.SaleLogBtn.Click += new System.EventHandler(this.OffersBtn_Click);
            // 
            // OffersLabel
            // 
            this.OffersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OffersLabel.AutoSize = true;
            this.OffersLabel.BackColor = System.Drawing.Color.Transparent;
            this.OffersLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OffersLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffersLabel.ForeColor = System.Drawing.Color.White;
            this.OffersLabel.Location = new System.Drawing.Point(74, 15);
            this.OffersLabel.Name = "OffersLabel";
            this.OffersLabel.Size = new System.Drawing.Size(68, 21);
            this.OffersLabel.TabIndex = 19;
            this.OffersLabel.Text = "Offers";
            this.OffersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OffersLabel.Click += new System.EventHandler(this.OffersLabel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SuppliersBtn);
            this.panel4.Controls.Add(this.SuppliersLabel);
            this.panel4.Location = new System.Drawing.Point(3, 283);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 48);
            this.panel4.TabIndex = 4;
            // 
            // SuppliersBtn
            // 
            this.SuppliersBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SuppliersBtn.BackColor = System.Drawing.Color.Transparent;
            this.SuppliersBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SuppliersBtn.BackgroundImage")));
            this.SuppliersBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SuppliersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SuppliersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SuppliersBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.SuppliersBtn.Location = new System.Drawing.Point(2, -2);
            this.SuppliersBtn.Name = "SuppliersBtn";
            this.SuppliersBtn.Size = new System.Drawing.Size(56, 47);
            this.SuppliersBtn.TabIndex = 27;
            this.SuppliersBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SuppliersBtn.UseVisualStyleBackColor = false;
            this.SuppliersBtn.Click += new System.EventHandler(this.SuppliersBtn_Click);
            // 
            // SuppliersLabel
            // 
            this.SuppliersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SuppliersLabel.AutoSize = true;
            this.SuppliersLabel.BackColor = System.Drawing.Color.Transparent;
            this.SuppliersLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SuppliersLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersLabel.ForeColor = System.Drawing.Color.White;
            this.SuppliersLabel.Location = new System.Drawing.Point(73, 17);
            this.SuppliersLabel.Name = "SuppliersLabel";
            this.SuppliersLabel.Size = new System.Drawing.Size(97, 21);
            this.SuppliersLabel.TabIndex = 29;
            this.SuppliersLabel.Text = "Suppliers";
            this.SuppliersLabel.Click += new System.EventHandler(this.SuppliersLabel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CustomersBtn);
            this.panel3.Controls.Add(this.CustomerLabel);
            this.panel3.Location = new System.Drawing.Point(3, 337);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 48);
            this.panel3.TabIndex = 3;
            // 
            // CustomersBtn
            // 
            this.CustomersBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomersBtn.BackColor = System.Drawing.Color.Transparent;
            this.CustomersBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CustomersBtn.BackgroundImage")));
            this.CustomersBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CustomersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomersBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.CustomersBtn.Location = new System.Drawing.Point(2, 2);
            this.CustomersBtn.Name = "CustomersBtn";
            this.CustomersBtn.Size = new System.Drawing.Size(56, 47);
            this.CustomersBtn.TabIndex = 3;
            this.CustomersBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CustomersBtn.UseVisualStyleBackColor = false;
            this.CustomersBtn.Click += new System.EventHandler(this.CustomersBtn_Click);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomerLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerLabel.ForeColor = System.Drawing.Color.White;
            this.CustomerLabel.Location = new System.Drawing.Point(73, 15);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(105, 21);
            this.CustomerLabel.TabIndex = 15;
            this.CustomerLabel.Text = "Customers";
            this.CustomerLabel.Click += new System.EventHandler(this.CustomerLabel_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ProductReportBtn);
            this.panel8.Controls.Add(this.ProductsReportLabel);
            this.panel8.Location = new System.Drawing.Point(3, 391);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(224, 48);
            this.panel8.TabIndex = 8;
            // 
            // ProductReportBtn
            // 
            this.ProductReportBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductReportBtn.AutoSize = true;
            this.ProductReportBtn.BackColor = System.Drawing.Color.Transparent;
            this.ProductReportBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProductReportBtn.BackgroundImage")));
            this.ProductReportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProductReportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductReportBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.ProductReportBtn.Location = new System.Drawing.Point(4, 0);
            this.ProductReportBtn.Name = "ProductReportBtn";
            this.ProductReportBtn.Size = new System.Drawing.Size(56, 47);
            this.ProductReportBtn.TabIndex = 5;
            this.ProductReportBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ProductReportBtn.UseVisualStyleBackColor = false;
            this.ProductReportBtn.Click += new System.EventHandler(this.ProductsReportBtn_Click);
            // 
            // ProductsReportLabel
            // 
            this.ProductsReportLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductsReportLabel.AutoSize = true;
            this.ProductsReportLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProductsReportLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductsReportLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsReportLabel.ForeColor = System.Drawing.Color.White;
            this.ProductsReportLabel.Location = new System.Drawing.Point(73, 2);
            this.ProductsReportLabel.Name = "ProductsReportLabel";
            this.ProductsReportLabel.Size = new System.Drawing.Size(112, 42);
            this.ProductsReportLabel.TabIndex = 16;
            this.ProductsReportLabel.Text = "Products\'s \nReport";
            this.ProductsReportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProductsReportLabel.Click += new System.EventHandler(this.ProductsReportLabel_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.InventoryReportBtn);
            this.panel7.Controls.Add(this.InventoryReportLabel);
            this.panel7.Location = new System.Drawing.Point(3, 445);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(224, 48);
            this.panel7.TabIndex = 19;
            // 
            // InventoryReportBtn
            // 
            this.InventoryReportBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InventoryReportBtn.BackColor = System.Drawing.Color.Transparent;
            this.InventoryReportBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InventoryReportBtn.BackgroundImage")));
            this.InventoryReportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InventoryReportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InventoryReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InventoryReportBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.InventoryReportBtn.Location = new System.Drawing.Point(2, 0);
            this.InventoryReportBtn.Name = "InventoryReportBtn";
            this.InventoryReportBtn.Size = new System.Drawing.Size(56, 47);
            this.InventoryReportBtn.TabIndex = 4;
            this.InventoryReportBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InventoryReportBtn.UseVisualStyleBackColor = false;
            this.InventoryReportBtn.Click += new System.EventHandler(this.InventoryReportBtn_Click);
            // 
            // InventoryReportLabel
            // 
            this.InventoryReportLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InventoryReportLabel.AutoSize = true;
            this.InventoryReportLabel.BackColor = System.Drawing.Color.Transparent;
            this.InventoryReportLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InventoryReportLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryReportLabel.ForeColor = System.Drawing.Color.White;
            this.InventoryReportLabel.Location = new System.Drawing.Point(73, 5);
            this.InventoryReportLabel.Name = "InventoryReportLabel";
            this.InventoryReportLabel.Size = new System.Drawing.Size(117, 42);
            this.InventoryReportLabel.TabIndex = 19;
            this.InventoryReportLabel.Text = "Inventory\'s\r\nReport";
            this.InventoryReportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InventoryReportLabel.Click += new System.EventHandler(this.InventoryReportLabel_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.HomepageBtn);
            this.panel9.Controls.Add(this.HomepageLabel);
            this.panel9.Location = new System.Drawing.Point(3, 499);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(224, 48);
            this.panel9.TabIndex = 21;
            // 
            // HomepageBtn
            // 
            this.HomepageBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HomepageBtn.AutoSize = true;
            this.HomepageBtn.BackColor = System.Drawing.Color.White;
            this.HomepageBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HomepageBtn.BackgroundImage")));
            this.HomepageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HomepageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomepageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomepageBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.HomepageBtn.Location = new System.Drawing.Point(3, -4);
            this.HomepageBtn.Name = "HomepageBtn";
            this.HomepageBtn.Size = new System.Drawing.Size(56, 47);
            this.HomepageBtn.TabIndex = 5;
            this.HomepageBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.HomepageBtn.UseVisualStyleBackColor = false;
            this.HomepageBtn.Click += new System.EventHandler(this.HomepageBtn_Click);
            // 
            // HomepageLabel
            // 
            this.HomepageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HomepageLabel.AutoSize = true;
            this.HomepageLabel.BackColor = System.Drawing.Color.Transparent;
            this.HomepageLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomepageLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomepageLabel.ForeColor = System.Drawing.Color.White;
            this.HomepageLabel.Location = new System.Drawing.Point(76, 14);
            this.HomepageLabel.Name = "HomepageLabel";
            this.HomepageLabel.Size = new System.Drawing.Size(109, 21);
            this.HomepageLabel.TabIndex = 16;
            this.HomepageLabel.Text = "Homepage\r\n";
            this.HomepageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HomepageLabel.Click += new System.EventHandler(this.HomepageLabel_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.PrefButton);
            this.panel10.Controls.Add(this.PrefLabel);
            this.panel10.Location = new System.Drawing.Point(3, 553);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(224, 48);
            this.panel10.TabIndex = 48;
            // 
            // PrefButton
            // 
            this.PrefButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrefButton.BackColor = System.Drawing.Color.Transparent;
            this.PrefButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PrefButton.BackgroundImage")));
            this.PrefButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PrefButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrefButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrefButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.PrefButton.Location = new System.Drawing.Point(0, -1);
            this.PrefButton.Name = "PrefButton";
            this.PrefButton.Size = new System.Drawing.Size(56, 47);
            this.PrefButton.TabIndex = 4;
            this.PrefButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PrefButton.UseVisualStyleBackColor = false;
            this.PrefButton.Click += new System.EventHandler(this.PrefButton_Click);
            // 
            // PrefLabel
            // 
            this.PrefLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrefLabel.AutoSize = true;
            this.PrefLabel.BackColor = System.Drawing.Color.Transparent;
            this.PrefLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrefLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrefLabel.ForeColor = System.Drawing.Color.White;
            this.PrefLabel.Location = new System.Drawing.Point(74, 15);
            this.PrefLabel.Name = "PrefLabel";
            this.PrefLabel.Size = new System.Drawing.Size(121, 21);
            this.PrefLabel.TabIndex = 19;
            this.PrefLabel.Text = "Preferences";
            this.PrefLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PrefLabel.Click += new System.EventHandler(this.PrefLabel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RolesBtn);
            this.panel1.Controls.Add(this.RolesLabel);
            this.panel1.Location = new System.Drawing.Point(3, 607);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 48);
            this.panel1.TabIndex = 45;
            // 
            // RolesBtn
            // 
            this.RolesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RolesBtn.BackColor = System.Drawing.Color.Transparent;
            this.RolesBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RolesBtn.BackgroundImage")));
            this.RolesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RolesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RolesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RolesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.RolesBtn.Location = new System.Drawing.Point(0, -1);
            this.RolesBtn.Name = "RolesBtn";
            this.RolesBtn.Size = new System.Drawing.Size(56, 47);
            this.RolesBtn.TabIndex = 4;
            this.RolesBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RolesBtn.UseVisualStyleBackColor = false;
            this.RolesBtn.Click += new System.EventHandler(this.RolesBtn_Click);
            // 
            // RolesLabel
            // 
            this.RolesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RolesLabel.AutoSize = true;
            this.RolesLabel.BackColor = System.Drawing.Color.Transparent;
            this.RolesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RolesLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RolesLabel.ForeColor = System.Drawing.Color.White;
            this.RolesLabel.Location = new System.Drawing.Point(74, 15);
            this.RolesLabel.Name = "RolesLabel";
            this.RolesLabel.Size = new System.Drawing.Size(59, 21);
            this.RolesLabel.TabIndex = 19;
            this.RolesLabel.Text = "Roles";
            this.RolesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RolesLabel.Click += new System.EventHandler(this.RolesLabel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TerminalBtn);
            this.panel2.Controls.Add(this.TerminalLabel);
            this.panel2.Location = new System.Drawing.Point(3, 661);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 48);
            this.panel2.TabIndex = 46;
            // 
            // TerminalBtn
            // 
            this.TerminalBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TerminalBtn.BackColor = System.Drawing.Color.Transparent;
            this.TerminalBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TerminalBtn.BackgroundImage")));
            this.TerminalBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TerminalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TerminalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TerminalBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.TerminalBtn.Location = new System.Drawing.Point(0, 0);
            this.TerminalBtn.Name = "TerminalBtn";
            this.TerminalBtn.Size = new System.Drawing.Size(56, 47);
            this.TerminalBtn.TabIndex = 4;
            this.TerminalBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TerminalBtn.UseVisualStyleBackColor = false;
            this.TerminalBtn.Click += new System.EventHandler(this.TerminalBtn_Click);
            // 
            // TerminalLabel
            // 
            this.TerminalLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TerminalLabel.AutoSize = true;
            this.TerminalLabel.BackColor = System.Drawing.Color.Transparent;
            this.TerminalLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TerminalLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TerminalLabel.ForeColor = System.Drawing.Color.White;
            this.TerminalLabel.Location = new System.Drawing.Point(74, 15);
            this.TerminalLabel.Name = "TerminalLabel";
            this.TerminalLabel.Size = new System.Drawing.Size(96, 21);
            this.TerminalLabel.TabIndex = 19;
            this.TerminalLabel.Text = "Terminal";
            this.TerminalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TerminalLabel.Click += new System.EventHandler(this.TerminalLabel_Click);
            // 
            // sideBarTimer
            // 
            this.sideBarTimer.Interval = 15;
            this.sideBarTimer.Tick += new System.EventHandler(this.sideBarTimer_Tick);
            // 
            // NoticeLabel
            // 
            this.NoticeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NoticeLabel.AutoSize = true;
            this.NoticeLabel.BackColor = System.Drawing.Color.Transparent;
            this.NoticeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoticeLabel.Location = new System.Drawing.Point(431, 238);
            this.NoticeLabel.Name = "NoticeLabel";
            this.NoticeLabel.Size = new System.Drawing.Size(408, 120);
            this.NoticeLabel.TabIndex = 35;
            this.NoticeLabel.Text = "On the left  you will find\r\nessential buttons for \r\nmanaging";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Harlow Solid Italic", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(901, 661);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 45);
            this.label3.TabIndex = 36;
            this.label3.Text = "V1.1 Beta";
            // 
            // ChangePasswordBtn
            // 
            this.ChangePasswordBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangePasswordBtn.BackColor = System.Drawing.Color.Silver;
            this.ChangePasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangePasswordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangePasswordBtn.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordBtn.ForeColor = System.Drawing.Color.Black;
            this.ChangePasswordBtn.Location = new System.Drawing.Point(594, 658);
            this.ChangePasswordBtn.Name = "ChangePasswordBtn";
            this.ChangePasswordBtn.Size = new System.Drawing.Size(162, 44);
            this.ChangePasswordBtn.TabIndex = 37;
            this.ChangePasswordBtn.Text = "Change Password";
            this.ChangePasswordBtn.UseVisualStyleBackColor = false;
            this.ChangePasswordBtn.Click += new System.EventHandler(this.ChangeUserPasswordBtn_Click);
            // 
            // CompanyLogoPicture
            // 
            this.CompanyLogoPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyLogoPicture.BackColor = System.Drawing.Color.Transparent;
            this.CompanyLogoPicture.Image = ((System.Drawing.Image)(resources.GetObject("CompanyLogoPicture.Image")));
            this.CompanyLogoPicture.Location = new System.Drawing.Point(767, 12);
            this.CompanyLogoPicture.Name = "CompanyLogoPicture";
            this.CompanyLogoPicture.Size = new System.Drawing.Size(287, 103);
            this.CompanyLogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CompanyLogoPicture.TabIndex = 10;
            this.CompanyLogoPicture.TabStop = false;
            // 
            // NoticeArrowPicture
            // 
            this.NoticeArrowPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NoticeArrowPicture.BackgroundImage = global::Inventory_Manager.Properties.Resources.curverArrow;
            this.NoticeArrowPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NoticeArrowPicture.Location = new System.Drawing.Point(239, 230);
            this.NoticeArrowPicture.Name = "NoticeArrowPicture";
            this.NoticeArrowPicture.Size = new System.Drawing.Size(254, 293);
            this.NoticeArrowPicture.TabIndex = 34;
            this.NoticeArrowPicture.TabStop = false;
            // 
            // AsideCubesPicture
            // 
            this.AsideCubesPicture.BackColor = System.Drawing.Color.Transparent;
            this.AsideCubesPicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.AsideCubesPicture.Image = ((System.Drawing.Image)(resources.GetObject("AsideCubesPicture.Image")));
            this.AsideCubesPicture.Location = new System.Drawing.Point(1077, 0);
            this.AsideCubesPicture.Name = "AsideCubesPicture";
            this.AsideCubesPicture.Size = new System.Drawing.Size(60, 706);
            this.AsideCubesPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AsideCubesPicture.TabIndex = 21;
            this.AsideCubesPicture.TabStop = false;
            // 
            // ViewFormPanel
            // 
            this.ViewFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewFormPanel.Location = new System.Drawing.Point(67, 0);
            this.ViewFormPanel.Name = "ViewFormPanel";
            this.ViewFormPanel.Size = new System.Drawing.Size(1010, 706);
            this.ViewFormPanel.TabIndex = 48;
            this.ViewFormPanel.Visible = false;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 706);
            this.Controls.Add(this.ViewFormPanel);
            this.Controls.Add(this.ChangePasswordBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NoticeLabel);
            this.Controls.Add(this.CompanyLogoPicture);
            this.Controls.Add(this.NoticeArrowPicture);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.ShortcutsGuidanceBtn);
            this.Controls.Add(this.ProgramNameLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AsideCubesPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1153, 726);
            this.Name = "Homepage";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sidebar.ResumeLayout(false);
            this.BtnsPanel.ResumeLayout(false);
            this.BtnsPanel.PerformLayout();
            this.ProductsPanel.ResumeLayout(false);
            this.ProductsPanel.PerformLayout();
            this.PurchasesPanel.ResumeLayout(false);
            this.PurchasesPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeArrowPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AsideCubesPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SalesBtn;
        private System.Windows.Forms.Button ProductsBtn;
        private System.Windows.Forms.Label ProgramNameLabel;
        private System.Windows.Forms.PictureBox CompanyLogoPicture;
        private System.Windows.Forms.Label ProductsLabel;
        private System.Windows.Forms.Label SalesLabel;
        private System.Windows.Forms.PictureBox AsideCubesPicture;
        private System.Windows.Forms.Label label9;
        private Button ShortcutsGuidanceBtn;
        private Button PurchasesBtn;
        private Label PurchasesLabel;
        private FlowLayoutPanel sidebar;
        private Timer sideBarTimer;
        private Panel BtnsPanel;
        private Button ShowBtnsNamesBtn;
        private PictureBox NoticeArrowPicture;
        private Label NoticeLabel;
        private Label label3;
        private Label MenuLabel;
        private Button ChangePasswordBtn;
        private Panel ProductsPanel;
        private Panel PurchasesPanel;
        private Panel panel6;
        private Panel panel5;
        private Button SaleLogBtn;
        private Label OffersLabel;
        private Panel panel4;
        private Button SuppliersBtn;
        private Label SuppliersLabel;
        private Panel panel8;
        private Button ProductReportBtn;
        private Label ProductsReportLabel;
        private Panel panel7;
        private Button InventoryReportBtn;
        private Label InventoryReportLabel;
        private Panel panel3;
        private Button CustomersBtn;
        private Label CustomerLabel;
        private Panel panel9;
        private Button HomepageBtn;
        private Label HomepageLabel;
        private Panel panel1;
        private Button RolesBtn;
        private Label RolesLabel;
        private Panel panel2;
        private Button TerminalBtn;
        private Label TerminalLabel;
        private Panel panel10;
        private Button PrefButton;
        private Label PrefLabel;
        private Panel ViewFormPanel;
    }
}

