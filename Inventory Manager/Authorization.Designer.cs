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
            this.Autohrization = new System.Windows.Forms.Label();
            this.LogintBtn = new Guna.UI2.WinForms.Guna2Button();
            this.password_text_box = new Guna.UI2.WinForms.Guna2TextBox();
            this.viewPasswordButton = new Guna.UI2.WinForms.Guna2Button();
            this.usernameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // Autohrization
            // 
            this.Autohrization.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Autohrization.AutoSize = true;
            this.Autohrization.BackColor = System.Drawing.Color.Transparent;
            this.Autohrization.Font = new System.Drawing.Font("Segoe Script", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Autohrization.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Autohrization.Location = new System.Drawing.Point(43, 9);
            this.Autohrization.Name = "Autohrization";
            this.Autohrization.Size = new System.Drawing.Size(358, 106);
            this.Autohrization.TabIndex = 10;
            this.Autohrization.Text = "Welcome!";
            // 
            // LogintBtn
            // 
            this.LogintBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogintBtn.AutoRoundedCorners = true;
            this.LogintBtn.BorderRadius = 28;
            this.LogintBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LogintBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LogintBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LogintBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LogintBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LogintBtn.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogintBtn.ForeColor = System.Drawing.Color.White;
            this.LogintBtn.Location = new System.Drawing.Point(147, 303);
            this.LogintBtn.Name = "LogintBtn";
            this.LogintBtn.Size = new System.Drawing.Size(123, 58);
            this.LogintBtn.TabIndex = 2;
            this.LogintBtn.Text = "Login";
            this.LogintBtn.Click += new System.EventHandler(this.LogintBtn_Click);
            // 
            // password_text_box
            // 
            this.password_text_box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password_text_box.AutoRoundedCorners = true;
            this.password_text_box.BorderRadius = 30;
            this.password_text_box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password_text_box.DefaultText = "";
            this.password_text_box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password_text_box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password_text_box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password_text_box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password_text_box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password_text_box.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_text_box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password_text_box.Location = new System.Drawing.Point(35, 232);
            this.password_text_box.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.password_text_box.MaxLength = 30;
            this.password_text_box.Name = "password_text_box";
            this.password_text_box.PasswordChar = '•';
            this.password_text_box.PlaceholderText = "Password";
            this.password_text_box.SelectedText = "";
            this.password_text_box.Size = new System.Drawing.Size(338, 62);
            this.password_text_box.TabIndex = 1;
            // 
            // viewPasswordButton
            // 
            this.viewPasswordButton.BackColor = System.Drawing.SystemColors.Window;
            this.viewPasswordButton.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.viewPasswordButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewPasswordButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewPasswordButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewPasswordButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewPasswordButton.FillColor = System.Drawing.Color.Transparent;
            this.viewPasswordButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.viewPasswordButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.viewPasswordButton.Location = new System.Drawing.Point(345, 254);
            this.viewPasswordButton.Name = "viewPasswordButton";
            this.viewPasswordButton.Size = new System.Drawing.Size(25, 22);
            this.viewPasswordButton.TabIndex = 12;
            this.viewPasswordButton.Click += new System.EventHandler(this.ViewPasswordButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usernameTextBox.AutoRoundedCorners = true;
            this.usernameTextBox.BorderRadius = 30;
            this.usernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTextBox.DefaultText = "";
            this.usernameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.usernameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.usernameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernameTextBox.Location = new System.Drawing.Point(35, 157);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.usernameTextBox.MaxLength = 30;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PasswordChar = '\0';
            this.usernameTextBox.PlaceholderText = "Username";
            this.usernameTextBox.SelectedText = "";
            this.usernameTextBox.Size = new System.Drawing.Size(338, 62);
            this.usernameTextBox.TabIndex = 0;
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(424, 413);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.viewPasswordButton);
            this.Controls.Add(this.password_text_box);
            this.Controls.Add(this.LogintBtn);
            this.Controls.Add(this.Autohrization);
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
        private System.Windows.Forms.Label Autohrization;
        private Guna.UI2.WinForms.Guna2Button LogintBtn;
        private Guna.UI2.WinForms.Guna2TextBox password_text_box;
        private Guna.UI2.WinForms.Guna2Button viewPasswordButton;
        private Guna.UI2.WinForms.Guna2TextBox usernameTextBox;
    }
}