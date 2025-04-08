namespace Inventory_Manager
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.PasswordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ViewPasswordBtn = new Guna.UI2.WinForms.Guna2Button();
            this.UserNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.LoginBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.AvatarPicture = new System.Windows.Forms.PictureBox();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.fadeOutHideTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ManifestPanel = new System.Windows.Forms.Panel();
            this.ManifestPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.LandingPicture = new System.Windows.Forms.PictureBox();
            this.CompanyLogoPicture = new System.Windows.Forms.PictureBox();
            this.ProgramNameLabel = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.ManifestPanel.SuspendLayout();
            this.ManifestPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LandingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogoPicture)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordTextBox.AutoRoundedCorners = true;
            this.PasswordTextBox.BackColor = System.Drawing.Color.Transparent;
            this.PasswordTextBox.BorderRadius = 30;
            this.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTextBox.DefaultText = "";
            this.PasswordTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PasswordTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PasswordTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.PasswordTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(46, 258);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.PasswordTextBox.MaxLength = 30;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '•';
            this.PasswordTextBox.PlaceholderText = "Password";
            this.PasswordTextBox.SelectedText = "";
            this.PasswordTextBox.Size = new System.Drawing.Size(338, 62);
            this.PasswordTextBox.TabIndex = 2;
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
            this.ViewPasswordBtn.Location = new System.Drawing.Point(337, 276);
            this.ViewPasswordBtn.Name = "ViewPasswordBtn";
            this.ViewPasswordBtn.Size = new System.Drawing.Size(41, 26);
            this.ViewPasswordBtn.TabIndex = 4;
            this.ViewPasswordBtn.Click += new System.EventHandler(this.ViewPasswordButton_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UserNameTextBox.AutoRoundedCorners = true;
            this.UserNameTextBox.BackColor = System.Drawing.Color.Transparent;
            this.UserNameTextBox.BorderRadius = 30;
            this.UserNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserNameTextBox.DefaultText = "";
            this.UserNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UserNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UserNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserNameTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.UserNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserNameTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserNameTextBox.Location = new System.Drawing.Point(46, 189);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.UserNameTextBox.MaxLength = 30;
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.PasswordChar = '\0';
            this.UserNameTextBox.PlaceholderText = "Username";
            this.UserNameTextBox.SelectedText = "";
            this.UserNameTextBox.Size = new System.Drawing.Size(338, 62);
            this.UserNameTextBox.TabIndex = 1;
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoginBtn.BackColor = System.Drawing.Color.Transparent;
            this.LoginBtn.BorderRadius = 20;
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LoginBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LoginBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LoginBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LoginBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LoginBtn.Enabled = false;
            this.LoginBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(78)))), ((int)(((byte)(80)))));
            this.LoginBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(212)))), ((int)(((byte)(35)))));
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.Color.White;
            this.LoginBtn.Location = new System.Drawing.Point(147, 329);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(136, 45);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.Click += new System.EventHandler(this.LogintBtn_Click);
            // 
            // AvatarPicture
            // 
            this.AvatarPicture.BackColor = System.Drawing.Color.Transparent;
            this.AvatarPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AvatarPicture.Image = ((System.Drawing.Image)(resources.GetObject("AvatarPicture.Image")));
            this.AvatarPicture.Location = new System.Drawing.Point(187, 39);
            this.AvatarPicture.Name = "AvatarPicture";
            this.AvatarPicture.Size = new System.Drawing.Size(57, 61);
            this.AvatarPicture.TabIndex = 14;
            this.AvatarPicture.TabStop = false;
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeLabel.Location = new System.Drawing.Point(107, 126);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(225, 50);
            this.WelcomeLabel.TabIndex = 16;
            this.WelcomeLabel.Text = "Welcome";
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
            this.CloseFormBtn.Location = new System.Drawing.Point(373, 1);
            this.CloseFormBtn.Name = "CloseFormBtn";
            this.CloseFormBtn.Size = new System.Drawing.Size(41, 37);
            this.CloseFormBtn.TabIndex = 17;
            this.CloseFormBtn.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // fadeOutHideTimer
            // 
            this.fadeOutHideTimer.Interval = 5;
            this.fadeOutHideTimer.Tick += new System.EventHandler(this.fadeOutHideTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(337, 367);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // ManifestPanel
            // 
            this.ManifestPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.ManifestPanel.Controls.Add(this.ManifestPanel1);
            this.ManifestPanel.Location = new System.Drawing.Point(-2, -2);
            this.ManifestPanel.Name = "ManifestPanel";
            this.ManifestPanel.Size = new System.Drawing.Size(478, 454);
            this.ManifestPanel.TabIndex = 15;
            // 
            // ManifestPanel1
            // 
            this.ManifestPanel1.Controls.Add(this.LandingPicture);
            this.ManifestPanel1.Controls.Add(this.CompanyLogoPicture);
            this.ManifestPanel1.Controls.Add(this.ProgramNameLabel);
            this.ManifestPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(72)))));
            this.ManifestPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(108)))), ((int)(((byte)(183)))));
            this.ManifestPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(72)))));
            this.ManifestPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(108)))), ((int)(((byte)(183)))));
            this.ManifestPanel1.Location = new System.Drawing.Point(3, -130);
            this.ManifestPanel1.Name = "ManifestPanel1";
            this.ManifestPanel1.Size = new System.Drawing.Size(472, 554);
            this.ManifestPanel1.TabIndex = 15;
            // 
            // LandingPicture
            // 
            this.LandingPicture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LandingPicture.BackColor = System.Drawing.Color.Transparent;
            this.LandingPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LandingPicture.BackgroundImage")));
            this.LandingPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LandingPicture.Location = new System.Drawing.Point(8, 265);
            this.LandingPicture.Name = "LandingPicture";
            this.LandingPicture.Size = new System.Drawing.Size(459, 360);
            this.LandingPicture.TabIndex = 14;
            this.LandingPicture.TabStop = false;
            // 
            // CompanyLogoPicture
            // 
            this.CompanyLogoPicture.BackColor = System.Drawing.Color.Transparent;
            this.CompanyLogoPicture.Image = ((System.Drawing.Image)(resources.GetObject("CompanyLogoPicture.Image")));
            this.CompanyLogoPicture.Location = new System.Drawing.Point(100, 141);
            this.CompanyLogoPicture.Name = "CompanyLogoPicture";
            this.CompanyLogoPicture.Size = new System.Drawing.Size(281, 59);
            this.CompanyLogoPicture.TabIndex = 11;
            this.CompanyLogoPicture.TabStop = false;
            // 
            // ProgramNameLabel
            // 
            this.ProgramNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProgramNameLabel.AutoSize = true;
            this.ProgramNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgramNameLabel.Font = new System.Drawing.Font("Bauhaus 93", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramNameLabel.ForeColor = System.Drawing.Color.White;
            this.ProgramNameLabel.Location = new System.Drawing.Point(63, 203);
            this.ProgramNameLabel.Name = "ProgramNameLabel";
            this.ProgramNameLabel.Size = new System.Drawing.Size(378, 30);
            this.ProgramNameLabel.TabIndex = 13;
            this.ProgramNameLabel.Text = "Inventory Management System";
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.ViewPasswordBtn);
            this.guna2CustomGradientPanel1.Controls.Add(this.CloseFormBtn);
            this.guna2CustomGradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2CustomGradientPanel1.Controls.Add(this.pictureBox2);
            this.guna2CustomGradientPanel1.Controls.Add(this.AvatarPicture);
            this.guna2CustomGradientPanel1.Controls.Add(this.WelcomeLabel);
            this.guna2CustomGradientPanel1.Controls.Add(this.UserNameTextBox);
            this.guna2CustomGradientPanel1.Controls.Add(this.LoginBtn);
            this.guna2CustomGradientPanel1.Controls.Add(this.PasswordTextBox);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(48)))), ((int)(((byte)(134)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(108)))), ((int)(((byte)(183)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(48)))), ((int)(((byte)(134)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(471, -2);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(409, 424);
            this.guna2CustomGradientPanel1.TabIndex = 21;
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(84)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(881, 422);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.ManifestPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authorization";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Authorization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ManifestPanel.ResumeLayout(false);
            this.ManifestPanel1.ResumeLayout(false);
            this.ManifestPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LandingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogoPicture)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox PasswordTextBox;
        private Guna.UI2.WinForms.Guna2Button ViewPasswordBtn;
        private Guna.UI2.WinForms.Guna2TextBox UserNameTextBox;
        private Guna.UI2.WinForms.Guna2GradientButton LoginBtn;
        private System.Windows.Forms.PictureBox AvatarPicture;
        private System.Windows.Forms.Label WelcomeLabel;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
        private System.Windows.Forms.Timer fadeOutHideTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel ManifestPanel;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel ManifestPanel1;
        private System.Windows.Forms.PictureBox LandingPicture;
        private System.Windows.Forms.PictureBox CompanyLogoPicture;
        private System.Windows.Forms.Label ProgramNameLabel;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}