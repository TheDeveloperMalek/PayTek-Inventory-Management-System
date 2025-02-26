namespace Inventory_Manager
{
    partial class ChangeUserPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserPassword));
            this.ChangePasswordLabel = new System.Windows.Forms.Label();
            this.CurrentUserPasswordLabel = new System.Windows.Forms.Label();
            this.CurrentUserPassword = new System.Windows.Forms.Label();
            this.ChangeUserPasswordBtn = new Guna.UI2.WinForms.Guna2Button();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.NewPasswordTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ViewPasswordBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangePasswordLabel
            // 
            this.ChangePasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangePasswordLabel.AutoSize = true;
            this.ChangePasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChangePasswordLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(66)))));
            this.ChangePasswordLabel.Location = new System.Drawing.Point(26, 188);
            this.ChangePasswordLabel.Name = "ChangePasswordLabel";
            this.ChangePasswordLabel.Size = new System.Drawing.Size(398, 41);
            this.ChangePasswordLabel.TabIndex = 19;
            this.ChangePasswordLabel.Text = "Change your password";
            // 
            // CurrentUserPasswordLabel
            // 
            this.CurrentUserPasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CurrentUserPasswordLabel.AutoSize = true;
            this.CurrentUserPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentUserPasswordLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUserPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.CurrentUserPasswordLabel.Location = new System.Drawing.Point(0, 348);
            this.CurrentUserPasswordLabel.Name = "CurrentUserPasswordLabel";
            this.CurrentUserPasswordLabel.Size = new System.Drawing.Size(274, 24);
            this.CurrentUserPasswordLabel.TabIndex = 21;
            this.CurrentUserPasswordLabel.Text = "Current user password:";
            // 
            // CurrentUserPassword
            // 
            this.CurrentUserPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CurrentUserPassword.AutoSize = true;
            this.CurrentUserPassword.BackColor = System.Drawing.Color.Transparent;
            this.CurrentUserPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUserPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.CurrentUserPassword.Location = new System.Drawing.Point(0, 372);
            this.CurrentUserPassword.Name = "CurrentUserPassword";
            this.CurrentUserPassword.Size = new System.Drawing.Size(82, 24);
            this.CurrentUserPassword.TabIndex = 23;
            this.CurrentUserPassword.Tag = "";
            this.CurrentUserPassword.Text = "  test";
            // 
            // ChangeUserPasswordBtn
            // 
            this.ChangeUserPasswordBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(235)))), ((int)(((byte)(199)))));
            this.ChangeUserPasswordBtn.BorderRadius = 6;
            this.ChangeUserPasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeUserPasswordBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ChangeUserPasswordBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ChangeUserPasswordBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ChangeUserPasswordBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ChangeUserPasswordBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(176)))), ((int)(((byte)(64)))));
            this.ChangeUserPasswordBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeUserPasswordBtn.ForeColor = System.Drawing.Color.White;
            this.ChangeUserPasswordBtn.Location = new System.Drawing.Point(132, 294);
            this.ChangeUserPasswordBtn.Name = "ChangeUserPasswordBtn";
            this.ChangeUserPasswordBtn.Size = new System.Drawing.Size(193, 43);
            this.ChangeUserPasswordBtn.TabIndex = 24;
            this.ChangeUserPasswordBtn.Text = "Confirm Change";
            this.ChangeUserPasswordBtn.Click += new System.EventHandler(this.LogintBtn_Click);
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
            this.CloseFormBtn.ForeColor = System.Drawing.Color.Transparent;
            this.CloseFormBtn.Location = new System.Drawing.Point(405, -3);
            this.CloseFormBtn.Name = "CloseFormBtn";
            this.CloseFormBtn.Size = new System.Drawing.Size(41, 37);
            this.CloseFormBtn.TabIndex = 37;
            this.CloseFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // NewPasswordTextBox
            // 
            this.NewPasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NewPasswordTextBox.AutoRoundedCorners = true;
            this.NewPasswordTextBox.BorderRadius = 25;
            this.NewPasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewPasswordTextBox.DefaultText = "";
            this.NewPasswordTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NewPasswordTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NewPasswordTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewPasswordTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewPasswordTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NewPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NewPasswordTextBox.Location = new System.Drawing.Point(33, 235);
            this.NewPasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.NewPasswordTextBox.MaxLength = 30;
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.PasswordChar = '•';
            this.NewPasswordTextBox.PlaceholderText = "Enter new password";
            this.NewPasswordTextBox.SelectedText = "";
            this.NewPasswordTextBox.Size = new System.Drawing.Size(377, 52);
            this.NewPasswordTextBox.TabIndex = 38;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(151, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
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
            this.ViewPasswordBtn.Location = new System.Drawing.Point(379, 249);
            this.ViewPasswordBtn.Name = "ViewPasswordBtn";
            this.ViewPasswordBtn.Size = new System.Drawing.Size(25, 22);
            this.ViewPasswordBtn.TabIndex = 40;
            this.ViewPasswordBtn.Click += new System.EventHandler(this.ViewPasswordBtn_Click);
            // 
            // ChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(442, 422);
            this.Controls.Add(this.ViewPasswordBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NewPasswordTextBox);
            this.Controls.Add(this.CloseFormBtn);
            this.Controls.Add(this.ChangeUserPasswordBtn);
            this.Controls.Add(this.CurrentUserPassword);
            this.Controls.Add(this.CurrentUserPasswordLabel);
            this.Controls.Add(this.ChangePasswordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangeUserPassword";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.ChangeUsersPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ChangePasswordLabel;
        private System.Windows.Forms.Label CurrentUserPasswordLabel;
        private System.Windows.Forms.Label CurrentUserPassword;
        private Guna.UI2.WinForms.Guna2Button ChangeUserPasswordBtn;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
        private Guna.UI2.WinForms.Guna2TextBox NewPasswordTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button ViewPasswordBtn;
    }
}