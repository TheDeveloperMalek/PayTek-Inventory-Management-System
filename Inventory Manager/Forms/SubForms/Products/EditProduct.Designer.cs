namespace Inventory_Manager
{
    partial class EditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProduct));
            this.EditBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.HeadingPicture = new System.Windows.Forms.PictureBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.withPhoto = new System.Windows.Forms.CheckBox();
            this.SpecificationRichBox = new System.Windows.Forms.RichTextBox();
            this.ProductNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ProductBarcodeTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ProductIdTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.withSpecification = new System.Windows.Forms.CheckBox();
            this.withName = new System.Windows.Forms.CheckBox();
            this.SpecificationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EditBtn.BorderRadius = 20;
            this.EditBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EditBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EditBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EditBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EditBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EditBtn.Enabled = false;
            this.EditBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(118)))), ((int)(((byte)(94)))));
            this.EditBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(168)))), ((int)(((byte)(88)))));
            this.EditBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.White;
            this.EditBtn.Location = new System.Drawing.Point(359, 428);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(158, 45);
            this.EditBtn.TabIndex = 6;
            this.EditBtn.Text = "Edit";
            this.EditBtn.Click += new System.EventHandler(this.EditUserBtn_Click);
            // 
            // HeadingPicture
            // 
            this.HeadingPicture.Image = ((System.Drawing.Image)(resources.GetObject("HeadingPicture.Image")));
            this.HeadingPicture.Location = new System.Drawing.Point(398, 7);
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
            this.HeadingLabel.Location = new System.Drawing.Point(325, 119);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(246, 41);
            this.HeadingLabel.TabIndex = 20;
            this.HeadingLabel.Text = "Edit product";
            // 
            // CloseFormBtn
            // 
            this.CloseFormBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.CloseFormBtn.Location = new System.Drawing.Point(857, 1);
            this.CloseFormBtn.Name = "CloseFormBtn";
            this.CloseFormBtn.Size = new System.Drawing.Size(41, 37);
            this.CloseFormBtn.TabIndex = 38;
            this.CloseFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // withPhoto
            // 
            this.withPhoto.AutoSize = true;
            this.withPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withPhoto.Enabled = false;
            this.withPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(66)))));
            this.withPhoto.Location = new System.Drawing.Point(737, 380);
            this.withPhoto.Name = "withPhoto";
            this.withPhoto.Size = new System.Drawing.Size(128, 29);
            this.withPhoto.TabIndex = 52;
            this.withPhoto.Text = "Edit photo";
            this.withPhoto.UseVisualStyleBackColor = true;
            this.withPhoto.CheckedChanged += new System.EventHandler(this.UpdateWithPhotoRadio_CheckedChanged);
            // 
            // SpecificationRichBox
            // 
            this.SpecificationRichBox.Enabled = false;
            this.SpecificationRichBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecificationRichBox.Location = new System.Drawing.Point(459, 202);
            this.SpecificationRichBox.Name = "SpecificationRichBox";
            this.SpecificationRichBox.Size = new System.Drawing.Size(405, 136);
            this.SpecificationRichBox.TabIndex = 51;
            this.SpecificationRichBox.Text = "";
            this.SpecificationRichBox.TextChanged += new System.EventHandler(this.SpecificationRichBox_TextChanged);
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
            this.ProductNameTextBox.Enabled = false;
            this.ProductNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductNameTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductNameTextBox.Location = new System.Drawing.Point(14, 350);
            this.ProductNameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ProductNameTextBox.MaxLength = 30;
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.PasswordChar = '\0';
            this.ProductNameTextBox.PlaceholderText = "Product\'s name";
            this.ProductNameTextBox.SelectedText = "";
            this.ProductNameTextBox.Size = new System.Drawing.Size(338, 62);
            this.ProductNameTextBox.TabIndex = 50;
            this.ProductNameTextBox.TextChanged += new System.EventHandler(this.ProductNameTextBox_TextChanged);
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
            this.ProductBarcodeTextBox.Location = new System.Drawing.Point(14, 276);
            this.ProductBarcodeTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ProductBarcodeTextBox.MaxLength = 30;
            this.ProductBarcodeTextBox.Name = "ProductBarcodeTextBox";
            this.ProductBarcodeTextBox.PasswordChar = '\0';
            this.ProductBarcodeTextBox.PlaceholderText = "Product\'s barcode";
            this.ProductBarcodeTextBox.SelectedText = "";
            this.ProductBarcodeTextBox.Size = new System.Drawing.Size(338, 62);
            this.ProductBarcodeTextBox.TabIndex = 49;
            this.ProductBarcodeTextBox.TextChanged += new System.EventHandler(this.ProductBarcodeTextBox_TextChanged);
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
            this.ProductIdTextBox.Location = new System.Drawing.Point(14, 202);
            this.ProductIdTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ProductIdTextBox.MaxLength = 30;
            this.ProductIdTextBox.Name = "ProductIdTextBox";
            this.ProductIdTextBox.PasswordChar = '\0';
            this.ProductIdTextBox.PlaceholderText = "Product\'s id";
            this.ProductIdTextBox.SelectedText = "";
            this.ProductIdTextBox.Size = new System.Drawing.Size(338, 62);
            this.ProductIdTextBox.TabIndex = 48;
            this.ProductIdTextBox.TextChanged += new System.EventHandler(this.ProductIdTextBox_TextChanged);
            // 
            // withSpecification
            // 
            this.withSpecification.AutoSize = true;
            this.withSpecification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withSpecification.Enabled = false;
            this.withSpecification.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withSpecification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(66)))));
            this.withSpecification.Location = new System.Drawing.Point(459, 344);
            this.withSpecification.Name = "withSpecification";
            this.withSpecification.Size = new System.Drawing.Size(197, 29);
            this.withSpecification.TabIndex = 55;
            this.withSpecification.Text = "Edit Specification";
            this.withSpecification.UseVisualStyleBackColor = true;
            this.withSpecification.CheckedChanged += new System.EventHandler(this.UpdateWithSpecificationRadio_CheckedChanged);
            // 
            // withName
            // 
            this.withName.AutoSize = true;
            this.withName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withName.Enabled = false;
            this.withName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(66)))));
            this.withName.Location = new System.Drawing.Point(737, 345);
            this.withName.Name = "withName";
            this.withName.Size = new System.Drawing.Size(127, 29);
            this.withName.TabIndex = 54;
            this.withName.Text = "Edit name";
            this.withName.UseVisualStyleBackColor = true;
            this.withName.CheckedChanged += new System.EventHandler(this.UpdateWithNameRadio_CheckedChanged);
            // 
            // SpecificationLabel
            // 
            this.SpecificationLabel.AutoSize = true;
            this.SpecificationLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecificationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(66)))));
            this.SpecificationLabel.Location = new System.Drawing.Point(584, 175);
            this.SpecificationLabel.Name = "SpecificationLabel";
            this.SpecificationLabel.Size = new System.Drawing.Size(166, 24);
            this.SpecificationLabel.TabIndex = 56;
            this.SpecificationLabel.Text = "Specification";
            // 
            // EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(896, 506);
            this.Controls.Add(this.SpecificationLabel);
            this.Controls.Add(this.withSpecification);
            this.Controls.Add(this.withName);
            this.Controls.Add(this.withPhoto);
            this.Controls.Add(this.SpecificationRichBox);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.ProductBarcodeTextBox);
            this.Controls.Add(this.ProductIdTextBox);
            this.Controls.Add(this.CloseFormBtn);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.HeadingPicture);
            this.Controls.Add(this.EditBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit product";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewUser_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton EditBtn;
        private System.Windows.Forms.PictureBox HeadingPicture;
        private System.Windows.Forms.Label HeadingLabel;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
        private System.Windows.Forms.CheckBox withPhoto;
        private System.Windows.Forms.RichTextBox SpecificationRichBox;
        private Guna.UI2.WinForms.Guna2TextBox ProductNameTextBox;
        private Guna.UI2.WinForms.Guna2TextBox ProductBarcodeTextBox;
        private Guna.UI2.WinForms.Guna2TextBox ProductIdTextBox;
        private System.Windows.Forms.CheckBox withSpecification;
        private System.Windows.Forms.CheckBox withName;
        private System.Windows.Forms.Label SpecificationLabel;
    }
}