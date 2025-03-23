namespace Inventory_Manager
{
    partial class EncryptorDecryptor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptorDecryptor));
            this.DecryptRadio = new System.Windows.Forms.RadioButton();
            this.EncryptRadio = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InputTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.OutputTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ChangePasswordLabel = new System.Windows.Forms.Label();
            this.Start = new Guna.UI2.WinForms.Guna2GradientButton();
            this.CloseFormBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DecryptRadio
            // 
            this.DecryptRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DecryptRadio.AutoSize = true;
            this.DecryptRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DecryptRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecryptRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DecryptRadio.Location = new System.Drawing.Point(285, 198);
            this.DecryptRadio.Name = "DecryptRadio";
            this.DecryptRadio.Size = new System.Drawing.Size(104, 29);
            this.DecryptRadio.TabIndex = 1;
            this.DecryptRadio.Text = "Decrypt";
            this.DecryptRadio.UseVisualStyleBackColor = true;
            this.DecryptRadio.CheckedChanged += new System.EventHandler(this.DecryptRadio_CheckedChanged);
            // 
            // EncryptRadio
            // 
            this.EncryptRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EncryptRadio.AutoSize = true;
            this.EncryptRadio.Checked = true;
            this.EncryptRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EncryptRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EncryptRadio.Location = new System.Drawing.Point(70, 198);
            this.EncryptRadio.Name = "EncryptRadio";
            this.EncryptRadio.Size = new System.Drawing.Size(103, 29);
            this.EncryptRadio.TabIndex = 1;
            this.EncryptRadio.TabStop = true;
            this.EncryptRadio.Text = "Encrypt";
            this.EncryptRadio.UseVisualStyleBackColor = true;
            this.EncryptRadio.CheckedChanged += new System.EventHandler(this.EncryptRadio_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(170, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InputTextBox.AutoRoundedCorners = true;
            this.InputTextBox.BorderRadius = 30;
            this.InputTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.InputTextBox.DefaultText = "";
            this.InputTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.InputTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.InputTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.InputTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.InputTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.InputTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.InputTextBox.Location = new System.Drawing.Point(51, 236);
            this.InputTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.InputTextBox.MaxLength = 30;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.PasswordChar = '\0';
            this.InputTextBox.PlaceholderText = "Input";
            this.InputTextBox.SelectedText = "";
            this.InputTextBox.Size = new System.Drawing.Size(338, 62);
            this.InputTextBox.TabIndex = 45;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OutputTextBox.AutoRoundedCorners = true;
            this.OutputTextBox.BorderRadius = 30;
            this.OutputTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OutputTextBox.DefaultText = "";
            this.OutputTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.OutputTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.OutputTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OutputTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OutputTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.OutputTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.OutputTextBox.Location = new System.Drawing.Point(51, 310);
            this.OutputTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.OutputTextBox.MaxLength = 30;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.PasswordChar = '\0';
            this.OutputTextBox.PlaceholderText = "Output";
            this.OutputTextBox.SelectedText = "";
            this.OutputTextBox.Size = new System.Drawing.Size(338, 62);
            this.OutputTextBox.TabIndex = 44;
            // 
            // ChangePasswordLabel
            // 
            this.ChangePasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangePasswordLabel.AutoSize = true;
            this.ChangePasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChangePasswordLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(168)))), ((int)(((byte)(88)))));
            this.ChangePasswordLabel.Location = new System.Drawing.Point(48, 132);
            this.ChangePasswordLabel.Name = "ChangePasswordLabel";
            this.ChangePasswordLabel.Size = new System.Drawing.Size(341, 41);
            this.ChangePasswordLabel.TabIndex = 43;
            this.ChangePasswordLabel.Text = "Encrypt / Decrypt";
            // 
            // Start
            // 
            this.Start.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Start.BorderRadius = 20;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Start.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Start.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Start.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Start.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Start.Enabled = false;
            this.Start.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(118)))), ((int)(((byte)(94)))));
            this.Start.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(168)))), ((int)(((byte)(88)))));
            this.Start.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.Color.White;
            this.Start.Location = new System.Drawing.Point(152, 381);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(147, 45);
            this.Start.TabIndex = 42;
            this.Start.Text = "Start";
            this.Start.Click += new System.EventHandler(this.start_Click);
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
            this.CloseFormBtn.Location = new System.Drawing.Point(388, -2);
            this.CloseFormBtn.Name = "CloseFormBtn";
            this.CloseFormBtn.Size = new System.Drawing.Size(41, 37);
            this.CloseFormBtn.TabIndex = 46;
            this.CloseFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // EncryptorDecryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(425, 456);
            this.Controls.Add(this.CloseFormBtn);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.ChangePasswordLabel);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EncryptRadio);
            this.Controls.Add(this.DecryptRadio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptorDecryptor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Encrypt / Decrypt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton DecryptRadio;
        private System.Windows.Forms.RadioButton EncryptRadio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox InputTextBox;
        private Guna.UI2.WinForms.Guna2TextBox OutputTextBox;
        private System.Windows.Forms.Label ChangePasswordLabel;
        private Guna.UI2.WinForms.Guna2GradientButton Start;
        private Guna.UI2.WinForms.Guna2Button CloseFormBtn;
    }
}