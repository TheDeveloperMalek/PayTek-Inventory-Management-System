namespace Inventory_Manager
{
    partial class AddNewProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewProduct));
            this.AddBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.HeadingPicture = new System.Windows.Forms.PictureBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ProductBarcodeTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ProductNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SpecificationRichBox = new System.Windows.Forms.RichTextBox();
            this.withPhoto = new System.Windows.Forms.CheckBox();
            this.SpecificationLabel = new System.Windows.Forms.Label();
            this.ProductImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductImage)).BeginInit();
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
            this.AddBtn.Location = new System.Drawing.Point(327, 433);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(136, 45);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Add";
            this.AddBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
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
            this.HeadingLabel.Size = new System.Drawing.Size(341, 41);
            this.HeadingLabel.TabIndex = 20;
            this.HeadingLabel.Text = "Add a new product";
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
            this.ProductBarcodeTextBox.Location = new System.Drawing.Point(30, 216);
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
            this.ProductNameTextBox.Location = new System.Drawing.Point(30, 290);
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
            // SpecificationRichBox
            // 
            this.SpecificationRichBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecificationRichBox.Location = new System.Drawing.Point(435, 216);
            this.SpecificationRichBox.Name = "SpecificationRichBox";
            this.SpecificationRichBox.Size = new System.Drawing.Size(338, 136);
            this.SpecificationRichBox.TabIndex = 46;
            this.SpecificationRichBox.Text = "";
            // 
            // withPhoto
            // 
            this.withPhoto.AutoSize = true;
            this.withPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(66)))));
            this.withPhoto.Location = new System.Drawing.Point(435, 370);
            this.withPhoto.Name = "withPhoto";
            this.withPhoto.Size = new System.Drawing.Size(129, 29);
            this.withPhoto.TabIndex = 47;
            this.withPhoto.Text = "Add photo";
            this.withPhoto.UseVisualStyleBackColor = true;
            this.withPhoto.CheckedChanged += new System.EventHandler(this.AddWithPhotoRadio_CheckedChanged);
            // 
            // SpecificationLabel
            // 
            this.SpecificationLabel.AutoSize = true;
            this.SpecificationLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecificationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(66)))));
            this.SpecificationLabel.Location = new System.Drawing.Point(431, 189);
            this.SpecificationLabel.Name = "SpecificationLabel";
            this.SpecificationLabel.Size = new System.Drawing.Size(166, 24);
            this.SpecificationLabel.TabIndex = 48;
            this.SpecificationLabel.Text = "Specification";
            // 
            // ProductImage
            // 
            this.ProductImage.Location = new System.Drawing.Point(633, 56);
            this.ProductImage.Name = "ProductImage";
            this.ProductImage.Size = new System.Drawing.Size(157, 157);
            this.ProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductImage.TabIndex = 49;
            this.ProductImage.TabStop = false;
            // 
            // AddNewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(802, 491);
            this.Controls.Add(this.ProductImage);
            this.Controls.Add(this.SpecificationLabel);
            this.Controls.Add(this.withPhoto);
            this.Controls.Add(this.SpecificationRichBox);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.ProductBarcodeTextBox);
            this.Controls.Add(this.CloseFormBtn);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.HeadingPicture);
            this.Controls.Add(this.AddBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new product";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewUser_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton AddBtn;
        private System.Windows.Forms.PictureBox HeadingPicture;
        private System.Windows.Forms.Label HeadingLabel;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
        private Guna.UI2.WinForms.Guna2TextBox ProductBarcodeTextBox;
        private Guna.UI2.WinForms.Guna2TextBox ProductNameTextBox;
        private System.Windows.Forms.RichTextBox SpecificationRichBox;
        private System.Windows.Forms.CheckBox withPhoto;
        private System.Windows.Forms.Label SpecificationLabel;
        private System.Windows.Forms.PictureBox ProductImage;
    }
}