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
            this.newPassword = new System.Windows.Forms.Label();
            this.password_text_box = new System.Windows.Forms.TextBox();
            this.Autohrization = new System.Windows.Forms.Label();
            this.labelOfCurrentUserPassword = new System.Windows.Forms.Label();
            this.crrUserPass = new System.Windows.Forms.Label();
            this.changePasswordBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // newPassword
            // 
            this.newPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newPassword.AutoSize = true;
            this.newPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(70)))), ((int)(((byte)(156)))));
            this.newPassword.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.newPassword.Location = new System.Drawing.Point(87, 89);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(251, 37);
            this.newPassword.TabIndex = 18;
            this.newPassword.Text = "New Password:";
            // 
            // password_text_box
            // 
            this.password_text_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_text_box.Location = new System.Drawing.Point(94, 141);
            this.password_text_box.Name = "password_text_box";
            this.password_text_box.Size = new System.Drawing.Size(227, 31);
            this.password_text_box.TabIndex = 15;
            // 
            // Autohrization
            // 
            this.Autohrization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Autohrization.AutoSize = true;
            this.Autohrization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(125)))));
            this.Autohrization.Font = new System.Drawing.Font("Consolas", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Autohrization.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Autohrization.Location = new System.Drawing.Point(9, 9);
            this.Autohrization.Name = "Autohrization";
            this.Autohrization.Size = new System.Drawing.Size(382, 51);
            this.Autohrization.TabIndex = 19;
            this.Autohrization.Text = "Change Password";
            // 
            // labelOfCurrentUserPassword
            // 
            this.labelOfCurrentUserPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOfCurrentUserPassword.AutoSize = true;
            this.labelOfCurrentUserPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelOfCurrentUserPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfCurrentUserPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOfCurrentUserPassword.Location = new System.Drawing.Point(10, 234);
            this.labelOfCurrentUserPassword.Name = "labelOfCurrentUserPassword";
            this.labelOfCurrentUserPassword.Size = new System.Drawing.Size(274, 24);
            this.labelOfCurrentUserPassword.TabIndex = 21;
            this.labelOfCurrentUserPassword.Text = "Current user password:";
            // 
            // crrUserPass
            // 
            this.crrUserPass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.crrUserPass.AutoSize = true;
            this.crrUserPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.crrUserPass.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crrUserPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.crrUserPass.Location = new System.Drawing.Point(14, 267);
            this.crrUserPass.Name = "crrUserPass";
            this.crrUserPass.Size = new System.Drawing.Size(34, 24);
            this.crrUserPass.TabIndex = 23;
            this.crrUserPass.Tag = "";
            this.crrUserPass.Text = "  ";
            // 
            // changePasswordBtn
            // 
            this.changePasswordBtn.BorderRadius = 6;
            this.changePasswordBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.changePasswordBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.changePasswordBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.changePasswordBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.changePasswordBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.changePasswordBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordBtn.ForeColor = System.Drawing.Color.Black;
            this.changePasswordBtn.Location = new System.Drawing.Point(144, 178);
            this.changePasswordBtn.Name = "changePasswordBtn";
            this.changePasswordBtn.Size = new System.Drawing.Size(140, 43);
            this.changePasswordBtn.TabIndex = 24;
            this.changePasswordBtn.Text = "Save";
            this.changePasswordBtn.Click += new System.EventHandler(this.LogintBtn_Click);
            // 
            // ChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(410, 327);
            this.Controls.Add(this.changePasswordBtn);
            this.Controls.Add(this.crrUserPass);
            this.Controls.Add(this.labelOfCurrentUserPassword);
            this.Controls.Add(this.Autohrization);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.password_text_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ChangeUserPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.ChangeUsersPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label newPassword;
        private System.Windows.Forms.TextBox password_text_box;
        private System.Windows.Forms.Label Autohrization;
        private System.Windows.Forms.Label labelOfCurrentUserPassword;
        private System.Windows.Forms.Label crrUserPass;
        private Guna.UI2.WinForms.Guna2Button changePasswordBtn;
    }
}