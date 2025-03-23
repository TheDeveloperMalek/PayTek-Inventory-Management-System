namespace Inventory_Manager
{
    partial class AddNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewUser));
            this.AddBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.UsernameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.HeadingPicture = new System.Windows.Forms.PictureBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.UserRadio = new Guna.UI2.WinForms.Guna2RadioButton();
            this.AdminRadio = new Guna.UI2.WinForms.Guna2RadioButton();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.PasswordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ViewPasswordBtn = new Guna.UI2.WinForms.Guna2Button();
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
            this.AddBtn.Location = new System.Drawing.Point(121, 371);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(136, 45);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Add";
            this.AddBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UsernameTextBox.AutoRoundedCorners = true;
            this.UsernameTextBox.BorderRadius = 30;
            this.UsernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernameTextBox.DefaultText = "";
            this.UsernameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UsernameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UsernameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UsernameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UsernameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UsernameTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UsernameTextBox.Location = new System.Drawing.Point(8, 180);
            this.UsernameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.UsernameTextBox.MaxLength = 30;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.PasswordChar = '\0';
            this.UsernameTextBox.PlaceholderText = "Username";
            this.UsernameTextBox.SelectedText = "";
            this.UsernameTextBox.Size = new System.Drawing.Size(338, 62);
            this.UsernameTextBox.TabIndex = 4;
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // HeadingPicture
            // 
            this.HeadingPicture.Image = ((System.Drawing.Image)(resources.GetObject("HeadingPicture.Image")));
            this.HeadingPicture.Location = new System.Drawing.Point(120, 12);
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
            this.HeadingLabel.Location = new System.Drawing.Point(48, 133);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(284, 41);
            this.HeadingLabel.TabIndex = 20;
            this.HeadingLabel.Text = "Add a new user";
            // 
            // UserRadio
            // 
            this.UserRadio.AutoSize = true;
            this.UserRadio.Checked = true;
            this.UserRadio.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserRadio.CheckedState.BorderThickness = 0;
            this.UserRadio.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserRadio.CheckedState.InnerColor = System.Drawing.Color.White;
            this.UserRadio.CheckedState.InnerOffset = -4;
            this.UserRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRadio.Location = new System.Drawing.Point(202, 325);
            this.UserRadio.Name = "UserRadio";
            this.UserRadio.Size = new System.Drawing.Size(75, 29);
            this.UserRadio.TabIndex = 37;
            this.UserRadio.TabStop = true;
            this.UserRadio.Text = "User";
            this.UserRadio.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.UserRadio.UncheckedState.BorderThickness = 2;
            this.UserRadio.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.UserRadio.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.UserRadio.CheckedChanged += new System.EventHandler(this.UserRadio_CheckedChanged);
            // 
            // AdminRadio
            // 
            this.AdminRadio.AutoSize = true;
            this.AdminRadio.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AdminRadio.CheckedState.BorderThickness = 0;
            this.AdminRadio.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.AdminRadio.CheckedState.InnerColor = System.Drawing.Color.White;
            this.AdminRadio.CheckedState.InnerOffset = -4;
            this.AdminRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminRadio.Location = new System.Drawing.Point(82, 325);
            this.AdminRadio.Name = "AdminRadio";
            this.AdminRadio.Size = new System.Drawing.Size(90, 29);
            this.AdminRadio.TabIndex = 36;
            this.AdminRadio.Text = "Admin";
            this.AdminRadio.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.AdminRadio.UncheckedState.BorderThickness = 2;
            this.AdminRadio.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.AdminRadio.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.AdminRadio.CheckedChanged += new System.EventHandler(this.AdminRadio_CheckedChanged);
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
            this.CloseFormBtn.Location = new System.Drawing.Point(320, 1);
            this.CloseFormBtn.Name = "CloseFormBtn";
            this.CloseFormBtn.Size = new System.Drawing.Size(41, 37);
            this.CloseFormBtn.TabIndex = 38;
            this.CloseFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordTextBox.AutoRoundedCorners = true;
            this.PasswordTextBox.BorderRadius = 30;
            this.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTextBox.DefaultText = "";
            this.PasswordTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PasswordTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PasswordTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(8, 254);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PasswordTextBox.MaxLength = 30;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '•';
            this.PasswordTextBox.PlaceholderText = "Password";
            this.PasswordTextBox.SelectedText = "";
            this.PasswordTextBox.Size = new System.Drawing.Size(338, 62);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // ViewPasswordBtn
            // 
            this.ViewPasswordBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ViewPasswordBtn.BackColor = System.Drawing.SystemColors.Window;
            this.ViewPasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ViewPasswordBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ViewPasswordBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ViewPasswordBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ViewPasswordBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ViewPasswordBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ViewPasswordBtn.FillColor = System.Drawing.Color.Transparent;
            this.ViewPasswordBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ViewPasswordBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ViewPasswordBtn.Location = new System.Drawing.Point(314, 275);
            this.ViewPasswordBtn.Name = "ViewPasswordBtn";
            this.ViewPasswordBtn.Size = new System.Drawing.Size(25, 22);
            this.ViewPasswordBtn.TabIndex = 41;
            this.ViewPasswordBtn.Click += new System.EventHandler(this.ViewPasswordBtn_Click);
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(360, 435);
            this.Controls.Add(this.ViewPasswordBtn);
            this.Controls.Add(this.CloseFormBtn);
            this.Controls.Add(this.UserRadio);
            this.Controls.Add(this.AdminRadio);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.HeadingPicture);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new user";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewUser_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.HeadingPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton AddBtn;
        private Guna.UI2.WinForms.Guna2TextBox UsernameTextBox;
        private System.Windows.Forms.PictureBox HeadingPicture;
        private System.Windows.Forms.Label HeadingLabel;
        private Guna.UI2.WinForms.Guna2RadioButton UserRadio;
        private Guna.UI2.WinForms.Guna2RadioButton AdminRadio;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
        private Guna.UI2.WinForms.Guna2TextBox PasswordTextBox;
        private Guna.UI2.WinForms.Guna2Button ViewPasswordBtn;
    }
}