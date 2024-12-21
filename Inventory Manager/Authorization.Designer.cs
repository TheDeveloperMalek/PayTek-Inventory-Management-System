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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.password_text_box = new System.Windows.Forms.TextBox();
            this.Admin_radio = new System.Windows.Forms.RadioButton();
            this.User_radio = new System.Windows.Forms.RadioButton();
            this.Autohrization = new System.Windows.Forms.Label();
            this.user_type = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.LogintBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // password_text_box
            // 
            this.password_text_box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_text_box.Location = new System.Drawing.Point(177, 266);
            this.password_text_box.Name = "password_text_box";
            this.password_text_box.Size = new System.Drawing.Size(284, 31);
            this.password_text_box.TabIndex = 0;
            // 
            // Admin_radio
            // 
            this.Admin_radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Admin_radio.AutoSize = true;
            this.Admin_radio.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold);
            this.Admin_radio.ForeColor = System.Drawing.Color.White;
            this.Admin_radio.Location = new System.Drawing.Point(177, 141);
            this.Admin_radio.Name = "Admin_radio";
            this.Admin_radio.Size = new System.Drawing.Size(113, 38);
            this.Admin_radio.TabIndex = 1;
            this.Admin_radio.Text = "Admin";
            this.Admin_radio.UseVisualStyleBackColor = true;
            // 
            // User_radio
            // 
            this.User_radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.User_radio.AutoSize = true;
            this.User_radio.Checked = true;
            this.User_radio.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold);
            this.User_radio.ForeColor = System.Drawing.Color.White;
            this.User_radio.Location = new System.Drawing.Point(177, 185);
            this.User_radio.Name = "User_radio";
            this.User_radio.Size = new System.Drawing.Size(97, 38);
            this.User_radio.TabIndex = 2;
            this.User_radio.TabStop = true;
            this.User_radio.Text = "User";
            this.User_radio.UseVisualStyleBackColor = true;
            // 
            // Autohrization
            // 
            this.Autohrization.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Autohrization.AutoSize = true;
            this.Autohrization.BackColor = System.Drawing.Color.Transparent;
            this.Autohrization.Font = new System.Drawing.Font("Consolas", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Autohrization.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Autohrization.Location = new System.Drawing.Point(47, 9);
            this.Autohrization.Name = "Autohrization";
            this.Autohrization.Size = new System.Drawing.Size(387, 51);
            this.Autohrization.TabIndex = 10;
            this.Autohrization.Text = "Login Window 🔑";
            // 
            // user_type
            // 
            this.user_type.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.user_type.AutoSize = true;
            this.user_type.BackColor = System.Drawing.Color.Transparent;
            this.user_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_type.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_type.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.user_type.Location = new System.Drawing.Point(5, 89);
            this.user_type.Name = "user_type";
            this.user_type.Size = new System.Drawing.Size(197, 37);
            this.user_type.TabIndex = 11;
            this.user_type.Text = "User type:";
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.password.Location = new System.Drawing.Point(5, 226);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(179, 37);
            this.password.TabIndex = 12;
            this.password.Text = "Password:";
            // 
            // LogintBtn
            // 
            this.LogintBtn.BackColor = System.Drawing.Color.LightGray;
            this.LogintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogintBtn.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogintBtn.ForeColor = System.Drawing.Color.Black;
            this.LogintBtn.Location = new System.Drawing.Point(150, 324);
            this.LogintBtn.Name = "LogintBtn";
            this.LogintBtn.Size = new System.Drawing.Size(140, 43);
            this.LogintBtn.TabIndex = 3;
            this.LogintBtn.Text = "Log in";
            this.LogintBtn.UseVisualStyleBackColor = false;
            this.LogintBtn.Click += new System.EventHandler(this.LogintBtn_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(471, 379);
            this.Controls.Add(this.LogintBtn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user_type);
            this.Controls.Add(this.Autohrization);
            this.Controls.Add(this.User_radio);
            this.Controls.Add(this.Admin_radio);
            this.Controls.Add(this.password_text_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Authorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_text_box;
        private System.Windows.Forms.RadioButton Admin_radio;
        private System.Windows.Forms.RadioButton User_radio;
        private System.Windows.Forms.Label Autohrization;
        private System.Windows.Forms.Label user_type;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Button LogintBtn;
    }
}