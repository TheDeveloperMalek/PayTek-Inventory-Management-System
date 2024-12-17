namespace Inventory_Manager
{
    partial class ChangeUsersPassword
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
            this.user_type = new System.Windows.Forms.Label();
            this.User_radio = new System.Windows.Forms.RadioButton();
            this.Admin_radio = new System.Windows.Forms.RadioButton();
            this.password_text_box = new System.Windows.Forms.TextBox();
            this.Autohrization = new System.Windows.Forms.Label();
            this.labelOfCurrentAdminPassword = new System.Windows.Forms.Label();
            this.labelOfCurrentUserPassword = new System.Windows.Forms.Label();
            this.crrAdminPass = new System.Windows.Forms.Label();
            this.crrUserPass = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // LogintBtn
            // 
            this.LogintBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.LogintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogintBtn.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogintBtn.ForeColor = System.Drawing.Color.Black;
            this.LogintBtn.Location = new System.Drawing.Point(452, 318);
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
            this.newPassword.Location = new System.Drawing.Point(395, 218);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(251, 37);
            this.newPassword.TabIndex = 18;
            this.newPassword.Text = "New Password:";
            // 
            // user_type
            // 
            this.user_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.user_type.AutoSize = true;
            this.user_type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(70)))), ((int)(((byte)(156)))));
            this.user_type.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_type.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.user_type.Location = new System.Drawing.Point(395, 74);
            this.user_type.Name = "user_type";
            this.user_type.Size = new System.Drawing.Size(197, 37);
            this.user_type.TabIndex = 17;
            this.user_type.Text = "User type:";
            // 
            // User_radio
            // 
            this.User_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.User_radio.AutoSize = true;
            this.User_radio.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold);
            this.User_radio.ForeColor = System.Drawing.Color.White;
            this.User_radio.Location = new System.Drawing.Point(404, 167);
            this.User_radio.Name = "User_radio";
            this.User_radio.Size = new System.Drawing.Size(97, 38);
            this.User_radio.TabIndex = 14;
            this.User_radio.TabStop = true;
            this.User_radio.Text = "User";
            this.User_radio.UseVisualStyleBackColor = true;
            // 
            // Admin_radio
            // 
            this.Admin_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Admin_radio.AutoSize = true;
            this.Admin_radio.Checked = true;
            this.Admin_radio.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold);
            this.Admin_radio.ForeColor = System.Drawing.Color.White;
            this.Admin_radio.Location = new System.Drawing.Point(404, 123);
            this.Admin_radio.Name = "Admin_radio";
            this.Admin_radio.Size = new System.Drawing.Size(113, 38);
            this.Admin_radio.TabIndex = 13;
            this.Admin_radio.TabStop = true;
            this.Admin_radio.Text = "Admin";
            this.Admin_radio.UseVisualStyleBackColor = true;
            // 
            // password_text_box
            // 
            this.password_text_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_text_box.Location = new System.Drawing.Point(404, 270);
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
            this.Autohrization.Location = new System.Drawing.Point(317, 9);
            this.Autohrization.Name = "Autohrization";
            this.Autohrization.Size = new System.Drawing.Size(382, 51);
            this.Autohrization.TabIndex = 19;
            this.Autohrization.Text = "Change Password";
            // 
            // labelOfCurrentAdminPassword
            // 
            this.labelOfCurrentAdminPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOfCurrentAdminPassword.AutoSize = true;
            this.labelOfCurrentAdminPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelOfCurrentAdminPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfCurrentAdminPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOfCurrentAdminPassword.Location = new System.Drawing.Point(12, 189);
            this.labelOfCurrentAdminPassword.Name = "labelOfCurrentAdminPassword";
            this.labelOfCurrentAdminPassword.Size = new System.Drawing.Size(286, 24);
            this.labelOfCurrentAdminPassword.TabIndex = 20;
            this.labelOfCurrentAdminPassword.Text = "Current admin password:";
            // 
            // labelOfCurrentUserPassword
            // 
            this.labelOfCurrentUserPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOfCurrentUserPassword.AutoSize = true;
            this.labelOfCurrentUserPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelOfCurrentUserPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfCurrentUserPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOfCurrentUserPassword.Location = new System.Drawing.Point(12, 1);
            this.labelOfCurrentUserPassword.Name = "labelOfCurrentUserPassword";
            this.labelOfCurrentUserPassword.Size = new System.Drawing.Size(274, 24);
            this.labelOfCurrentUserPassword.TabIndex = 21;
            this.labelOfCurrentUserPassword.Text = "Current user password:";
            // 
            // crrAdminPass
            // 
            this.crrAdminPass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.crrAdminPass.AutoSize = true;
            this.crrAdminPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.crrAdminPass.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crrAdminPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.crrAdminPass.Location = new System.Drawing.Point(12, 236);
            this.crrAdminPass.Name = "crrAdminPass";
            this.crrAdminPass.Size = new System.Drawing.Size(34, 24);
            this.crrAdminPass.TabIndex = 22;
            this.crrAdminPass.Tag = "";
            this.crrAdminPass.Text = "  ";
            this.crrAdminPass.Click += new System.EventHandler(this.crrAdminPass_Click);
            // 
            // crrUserPass
            // 
            this.crrUserPass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.crrUserPass.AutoSize = true;
            this.crrUserPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.crrUserPass.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crrUserPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.crrUserPass.Location = new System.Drawing.Point(12, 43);
            this.crrUserPass.Name = "crrUserPass";
            this.crrUserPass.Size = new System.Drawing.Size(34, 24);
            this.crrUserPass.TabIndex = 23;
            this.crrUserPass.Tag = "";
            this.crrUserPass.Text = "  ";
            this.crrUserPass.Click += new System.EventHandler(this.crrUserPass_Click);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(303, 372);
            this.splitter1.TabIndex = 24;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // ChangeUsersPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(718, 372);
            this.Controls.Add(this.crrUserPass);
            this.Controls.Add(this.crrAdminPass);
            this.Controls.Add(this.labelOfCurrentUserPassword);
            this.Controls.Add(this.labelOfCurrentAdminPassword);
            this.Controls.Add(this.Autohrization);
            this.Controls.Add(this.LogintBtn);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.user_type);
            this.Controls.Add(this.User_radio);
            this.Controls.Add(this.Admin_radio);
            this.Controls.Add(this.password_text_box);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ChangeUsersPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Users Password";
            this.Load += new System.EventHandler(this.ChangeUsersPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogintBtn;
        private System.Windows.Forms.Label newPassword;
        private System.Windows.Forms.Label user_type;
        private System.Windows.Forms.RadioButton User_radio;
        private System.Windows.Forms.RadioButton Admin_radio;
        private System.Windows.Forms.TextBox password_text_box;
        private System.Windows.Forms.Label Autohrization;
        private System.Windows.Forms.Label labelOfCurrentAdminPassword;
        private System.Windows.Forms.Label labelOfCurrentUserPassword;
        private System.Windows.Forms.Label crrAdminPass;
        private System.Windows.Forms.Label crrUserPass;
        private System.Windows.Forms.Splitter splitter1;
    }
}