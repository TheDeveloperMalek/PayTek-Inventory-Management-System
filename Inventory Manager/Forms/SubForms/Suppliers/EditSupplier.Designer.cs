namespace Inventory_Manager
{
    partial class EditSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSupplier));
            this.ChangeSupplerNameBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.HeadingPicture = new System.Windows.Forms.PictureBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SupplierIdTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.NewSupplierNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeSupplerNameBtn
            // 
            this.ChangeSupplerNameBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChangeSupplerNameBtn.BorderRadius = 20;
            this.ChangeSupplerNameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeSupplerNameBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ChangeSupplerNameBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ChangeSupplerNameBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ChangeSupplerNameBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ChangeSupplerNameBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ChangeSupplerNameBtn.Enabled = false;
            this.ChangeSupplerNameBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(118)))), ((int)(((byte)(94)))));
            this.ChangeSupplerNameBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(168)))), ((int)(((byte)(88)))));
            this.ChangeSupplerNameBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeSupplerNameBtn.ForeColor = System.Drawing.Color.White;
            this.ChangeSupplerNameBtn.Location = new System.Drawing.Point(110, 320);
            this.ChangeSupplerNameBtn.Name = "ChangeSupplerNameBtn";
            this.ChangeSupplerNameBtn.Size = new System.Drawing.Size(212, 45);
            this.ChangeSupplerNameBtn.TabIndex = 6;
            this.ChangeSupplerNameBtn.Text = "Change Name";
            this.ChangeSupplerNameBtn.Click += new System.EventHandler(this.EditUserBtn_Click);
            // 
            // HeadingPicture
            // 
            this.HeadingPicture.Image = ((System.Drawing.Image)(resources.GetObject("HeadingPicture.Image")));
            this.HeadingPicture.Location = new System.Drawing.Point(154, 12);
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
            this.HeadingLabel.Location = new System.Drawing.Point(18, 131);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(398, 41);
            this.HeadingLabel.TabIndex = 20;
            this.HeadingLabel.Text = "Edit supplier\'s name";
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
            this.CloseFormBtn.Location = new System.Drawing.Point(389, 1);
            this.CloseFormBtn.Name = "CloseFormBtn";
            this.CloseFormBtn.Size = new System.Drawing.Size(41, 37);
            this.CloseFormBtn.TabIndex = 38;
            this.CloseFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // SupplierIdTextBox
            // 
            this.SupplierIdTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SupplierIdTextBox.AutoRoundedCorners = true;
            this.SupplierIdTextBox.BorderRadius = 30;
            this.SupplierIdTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SupplierIdTextBox.DefaultText = "";
            this.SupplierIdTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SupplierIdTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SupplierIdTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SupplierIdTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SupplierIdTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SupplierIdTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierIdTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SupplierIdTextBox.Location = new System.Drawing.Point(45, 176);
            this.SupplierIdTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SupplierIdTextBox.MaxLength = 30;
            this.SupplierIdTextBox.Name = "SupplierIdTextBox";
            this.SupplierIdTextBox.PasswordChar = '\0';
            this.SupplierIdTextBox.PlaceholderText = "Supplier\'s id";
            this.SupplierIdTextBox.SelectedText = "";
            this.SupplierIdTextBox.Size = new System.Drawing.Size(338, 62);
            this.SupplierIdTextBox.TabIndex = 41;
            this.SupplierIdTextBox.TextChanged += new System.EventHandler(this.SupplierIdTextBox_TextChanged);
            // 
            // NewSupplierNameTextBox
            // 
            this.NewSupplierNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NewSupplierNameTextBox.AutoRoundedCorners = true;
            this.NewSupplierNameTextBox.BorderRadius = 30;
            this.NewSupplierNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewSupplierNameTextBox.DefaultText = "";
            this.NewSupplierNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NewSupplierNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NewSupplierNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewSupplierNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewSupplierNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NewSupplierNameTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSupplierNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NewSupplierNameTextBox.Location = new System.Drawing.Point(45, 250);
            this.NewSupplierNameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.NewSupplierNameTextBox.MaxLength = 30;
            this.NewSupplierNameTextBox.Name = "NewSupplierNameTextBox";
            this.NewSupplierNameTextBox.PasswordChar = '\0';
            this.NewSupplierNameTextBox.PlaceholderText = "New supplier\'s name";
            this.NewSupplierNameTextBox.SelectedText = "";
            this.NewSupplierNameTextBox.Size = new System.Drawing.Size(338, 62);
            this.NewSupplierNameTextBox.TabIndex = 40;
            this.NewSupplierNameTextBox.TextChanged += new System.EventHandler(this.NewSupplierNameTextBox_TextChanged);
            // 
            // EditSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(428, 415);
            this.Controls.Add(this.SupplierIdTextBox);
            this.Controls.Add(this.NewSupplierNameTextBox);
            this.Controls.Add(this.CloseFormBtn);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.HeadingPicture);
            this.Controls.Add(this.ChangeSupplerNameBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit supplier name";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewUser_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton ChangeSupplerNameBtn;
        private System.Windows.Forms.PictureBox HeadingPicture;
        private System.Windows.Forms.Label HeadingLabel;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
        private Guna.UI2.WinForms.Guna2TextBox SupplierIdTextBox;
        private Guna.UI2.WinForms.Guna2TextBox NewSupplierNameTextBox;
    }
}