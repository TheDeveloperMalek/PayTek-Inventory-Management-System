namespace Inventory_Manager
{
    partial class AddNewSaleLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewSale));
            this.AddBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ProductIdTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.HeadingPicture = new System.Windows.Forms.PictureBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ProductBarcodeTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ProductNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.CustomerIdTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.UnitPriceTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.QuantityTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.CustomerNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddBtn.BorderRadius = 20;
            this.AddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddBtn.Enabled = false;
            this.AddBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(118)))), ((int)(((byte)(94)))));
            this.AddBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(168)))), ((int)(((byte)(88)))));
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(327, 474);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(136, 45);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Add";
            this.AddBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // ProductIdTextBox
            // 
            this.ProductIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductIdTextBox.AutoRoundedCorners = true;
            this.ProductIdTextBox.BorderRadius = 30;
            this.ProductIdTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProductIdTextBox.DefaultText = "";
            this.ProductIdTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ProductIdTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ProductIdTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductIdTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductIdTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductIdTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.ProductIdTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductIdTextBox.Location = new System.Drawing.Point(30, 182);
            this.ProductIdTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ProductIdTextBox.MaxLength = 30;
            this.ProductIdTextBox.Name = "ProductIdTextBox";
            this.ProductIdTextBox.PasswordChar = '\0';
            this.ProductIdTextBox.PlaceholderText = "Product\'s id";
            this.ProductIdTextBox.SelectedText = "";
            this.ProductIdTextBox.Size = new System.Drawing.Size(338, 62);
            this.ProductIdTextBox.TabIndex = 4;
            this.ProductIdTextBox.TextChanged += new System.EventHandler(this.ProductIdTextBox_TextChanged);
            // 
            // HeadingPicture
            // 
            this.HeadingPicture.Image = ((System.Drawing.Image)(resources.GetObject("HeadingPicture.Image")));
            this.HeadingPicture.Location = new System.Drawing.Point(344, 12);
            this.HeadingPicture.Name = "HeadingPicture";
            this.HeadingPicture.Size = new System.Drawing.Size(119, 109);
            this.HeadingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HeadingPicture.TabIndex = 7;
            this.HeadingPicture.TabStop = false;
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeadingLabel.AutoSize = true;
            this.HeadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.HeadingLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(168)))), ((int)(((byte)(88)))));
            this.HeadingLabel.Location = new System.Drawing.Point(258, 135);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(284, 41);
            this.HeadingLabel.TabIndex = 20;
            this.HeadingLabel.Text = "Add a new sale";
            // 
            // CloseFormBtn
            // 
            this.CloseFormBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseFormBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseFormBtn.BackgroundImage")));
            this.CloseFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseFormBtn.BorderRadius = 15;
            this.CloseFormBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseFormBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CloseFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseFormBtn.FillColor = System.Drawing.Color.Transparent;
            this.CloseFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseFormBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CloseFormBtn.Location = new System.Drawing.Point(758, 3);
            this.CloseFormBtn.Name = "CloseFormBtn";
            this.CloseFormBtn.Size = new System.Drawing.Size(41, 37);
            this.CloseFormBtn.TabIndex = 38;
            this.CloseFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // ProductBarcodeTextBox
            // 
            this.ProductBarcodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductBarcodeTextBox.AutoRoundedCorners = true;
            this.ProductBarcodeTextBox.BorderRadius = 30;
            this.ProductBarcodeTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProductBarcodeTextBox.DefaultText = "";
            this.ProductBarcodeTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ProductBarcodeTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ProductBarcodeTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductBarcodeTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductBarcodeTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductBarcodeTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductBarcodeTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductBarcodeTextBox.Location = new System.Drawing.Point(30, 256);
            this.ProductBarcodeTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ProductBarcodeTextBox.MaxLength = 30;
            this.ProductBarcodeTextBox.Name = "ProductBarcodeTextBox";
            this.ProductBarcodeTextBox.PasswordChar = '\0';
            this.ProductBarcodeTextBox.PlaceholderText = "Product\'s barcode";
            this.ProductBarcodeTextBox.SelectedText = "";
            this.ProductBarcodeTextBox.Size = new System.Drawing.Size(338, 62);
            this.ProductBarcodeTextBox.TabIndex = 39;
            this.ProductBarcodeTextBox.TextChanged += new System.EventHandler(this.ProductBarcodeTextBox_TextChanged);
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductNameTextBox.AutoRoundedCorners = true;
            this.ProductNameTextBox.BorderRadius = 30;
            this.ProductNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProductNameTextBox.DefaultText = "";
            this.ProductNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ProductNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ProductNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductNameTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductNameTextBox.Location = new System.Drawing.Point(30, 330);
            this.ProductNameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ProductNameTextBox.MaxLength = 30;
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.PasswordChar = '\0';
            this.ProductNameTextBox.PlaceholderText = "Product\'s name";
            this.ProductNameTextBox.SelectedText = "";
            this.ProductNameTextBox.Size = new System.Drawing.Size(338, 62);
            this.ProductNameTextBox.TabIndex = 40;
            this.ProductNameTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
            // 
            // CustomerIdTextBox
            // 
            this.CustomerIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CustomerIdTextBox.AutoRoundedCorners = true;
            this.CustomerIdTextBox.BorderRadius = 30;
            this.CustomerIdTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CustomerIdTextBox.DefaultText = "";
            this.CustomerIdTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CustomerIdTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CustomerIdTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerIdTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerIdTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerIdTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerIdTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerIdTextBox.Location = new System.Drawing.Point(437, 182);
            this.CustomerIdTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CustomerIdTextBox.MaxLength = 30;
            this.CustomerIdTextBox.Name = "CustomerIdTextBox";
            this.CustomerIdTextBox.PasswordChar = '\0';
            this.CustomerIdTextBox.PlaceholderText = "Customer\'s id";
            this.CustomerIdTextBox.SelectedText = "";
            this.CustomerIdTextBox.Size = new System.Drawing.Size(338, 62);
            this.CustomerIdTextBox.TabIndex = 42;
            this.CustomerIdTextBox.TextChanged += new System.EventHandler(this.CustomerIdTextBox_TextChanged);
            // 
            // UnitPriceTextBox
            // 
            this.UnitPriceTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UnitPriceTextBox.AutoRoundedCorners = true;
            this.UnitPriceTextBox.BorderRadius = 30;
            this.UnitPriceTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UnitPriceTextBox.DefaultText = "";
            this.UnitPriceTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UnitPriceTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UnitPriceTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UnitPriceTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UnitPriceTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UnitPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnitPriceTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UnitPriceTextBox.Location = new System.Drawing.Point(235, 404);
            this.UnitPriceTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.UnitPriceTextBox.MaxLength = 30;
            this.UnitPriceTextBox.Name = "UnitPriceTextBox";
            this.UnitPriceTextBox.PasswordChar = '\0';
            this.UnitPriceTextBox.PlaceholderText = "Unit price";
            this.UnitPriceTextBox.SelectedText = "";
            this.UnitPriceTextBox.Size = new System.Drawing.Size(338, 62);
            this.UnitPriceTextBox.TabIndex = 45;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QuantityTextBox.AutoRoundedCorners = true;
            this.QuantityTextBox.BorderRadius = 30;
            this.QuantityTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.QuantityTextBox.DefaultText = "";
            this.QuantityTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.QuantityTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.QuantityTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.QuantityTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.QuantityTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.QuantityTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.QuantityTextBox.Location = new System.Drawing.Point(437, 330);
            this.QuantityTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.QuantityTextBox.MaxLength = 30;
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.PasswordChar = '\0';
            this.QuantityTextBox.PlaceholderText = "Quantity";
            this.QuantityTextBox.SelectedText = "";
            this.QuantityTextBox.Size = new System.Drawing.Size(338, 62);
            this.QuantityTextBox.TabIndex = 44;
            this.QuantityTextBox.TextChanged += new System.EventHandler(this.QuantityTextBox_TextChanged);
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CustomerNameTextBox.AutoRoundedCorners = true;
            this.CustomerNameTextBox.BorderRadius = 30;
            this.CustomerNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CustomerNameTextBox.DefaultText = "";
            this.CustomerNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CustomerNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CustomerNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerNameTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerNameTextBox.Location = new System.Drawing.Point(437, 256);
            this.CustomerNameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CustomerNameTextBox.MaxLength = 30;
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.PasswordChar = '\0';
            this.CustomerNameTextBox.PlaceholderText = "Customer\'s name";
            this.CustomerNameTextBox.SelectedText = "";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(338, 62);
            this.CustomerNameTextBox.TabIndex = 41;
            this.CustomerNameTextBox.TextChanged += new System.EventHandler(this.CustomerNameTextBox_TextChanged);
            // 
            // AddNewSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(802, 531);
            this.Controls.Add(this.UnitPriceTextBox);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.CustomerIdTextBox);
            this.Controls.Add(this.CustomerNameTextBox);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.ProductBarcodeTextBox);
            this.Controls.Add(this.CloseFormBtn);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.HeadingPicture);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ProductIdTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new sale";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewUser_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton AddBtn;
        private Guna.UI2.WinForms.Guna2TextBox ProductIdTextBox;
        private System.Windows.Forms.PictureBox HeadingPicture;
        private System.Windows.Forms.Label HeadingLabel;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
        private Guna.UI2.WinForms.Guna2TextBox ProductBarcodeTextBox;
        private Guna.UI2.WinForms.Guna2TextBox ProductNameTextBox;
        private Guna.UI2.WinForms.Guna2TextBox CustomerIdTextBox;
        private Guna.UI2.WinForms.Guna2TextBox UnitPriceTextBox;
        private Guna.UI2.WinForms.Guna2TextBox QuantityTextBox;
        private Guna.UI2.WinForms.Guna2TextBox CustomerNameTextBox;
    }
}