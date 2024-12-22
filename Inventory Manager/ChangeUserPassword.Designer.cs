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
            this.LogintBtn = new System.Windows.Forms.Button();
            this.newPassword = new System.Windows.Forms.Label();
            this.password_text_box = new System.Windows.Forms.TextBox();
            this.Autohrization = new System.Windows.Forms.Label();
            this.labelOfCurrentUserPassword = new System.Windows.Forms.Label();
            this.crrUserPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogintBtn
            // 
            this.LogintBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.LogintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogintBtn.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogintBtn.ForeColor = System.Drawing.Color.Black;
            this.LogintBtn.Location = new System.Drawing.Point(144, 178);
            this.LogintBtn.Name = "LogintBtn";
            this.LogintBtn.Size = new System.Drawing.Size(140, 43);
            this.LogintBtn.TabIndex = 16;
            this.LogintBtn.Text = "Save";
            this.LogintBtn.UseVisualStyleBackColor = false;
            this.LogintBtn.Click += new System.EventHandler(this.LogintBtn_Click);
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
            this.password_text_box.TextChanged += new System.EventHandler(this.password_text_box_TextChanged);
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
            this.crrUserPass.Click += new System.EventHandler(this.crrUserPass_Click);
            // 
            // ChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(410, 327);
            this.Controls.Add(this.crrUserPass);
            this.Controls.Add(this.labelOfCurrentUserPassword);
            this.Controls.Add(this.Autohrization);
            this.Controls.Add(this.LogintBtn);
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

        private System.Windows.Forms.Button LogintBtn;
        private System.Windows.Forms.Label newPassword;
        private System.Windows.Forms.TextBox password_text_box;
        private System.Windows.Forms.Label Autohrization;
        private System.Windows.Forms.Label labelOfCurrentUserPassword;
        private System.Windows.Forms.Label crrUserPass;
    }
}