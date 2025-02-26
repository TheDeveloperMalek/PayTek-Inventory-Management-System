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
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.DecryptRadio = new System.Windows.Forms.RadioButton();
            this.EncryptRadio = new System.Windows.Forms.RadioButton();
            this.StartEncryptDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTextBox.Location = new System.Drawing.Point(9, 156);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(319, 31);
            this.OutputTextBox.TabIndex = 4;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(9, 82);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(319, 31);
            this.InputTextBox.TabIndex = 0;
            // 
            // DecryptRadio
            // 
            this.DecryptRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DecryptRadio.AutoSize = true;
            this.DecryptRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecryptRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DecryptRadio.Location = new System.Drawing.Point(124, 47);
            this.DecryptRadio.Name = "DecryptRadio";
            this.DecryptRadio.Size = new System.Drawing.Size(104, 29);
            this.DecryptRadio.TabIndex = 1;
            this.DecryptRadio.Text = "Decrypt";
            this.DecryptRadio.UseVisualStyleBackColor = true;
            // 
            // EncryptRadio
            // 
            this.EncryptRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EncryptRadio.AutoSize = true;
            this.EncryptRadio.Checked = true;
            this.EncryptRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EncryptRadio.Location = new System.Drawing.Point(125, 12);
            this.EncryptRadio.Name = "EncryptRadio";
            this.EncryptRadio.Size = new System.Drawing.Size(103, 29);
            this.EncryptRadio.TabIndex = 1;
            this.EncryptRadio.TabStop = true;
            this.EncryptRadio.Text = "Encrypt";
            this.EncryptRadio.UseVisualStyleBackColor = true;
            // 
            // StartEncryptDecrypt
            // 
            this.StartEncryptDecrypt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StartEncryptDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartEncryptDecrypt.Location = new System.Drawing.Point(124, 119);
            this.StartEncryptDecrypt.Name = "StartEncryptDecrypt";
            this.StartEncryptDecrypt.Size = new System.Drawing.Size(104, 31);
            this.StartEncryptDecrypt.TabIndex = 3;
            this.StartEncryptDecrypt.Text = "Start";
            this.StartEncryptDecrypt.UseVisualStyleBackColor = true;
            this.StartEncryptDecrypt.Click += new System.EventHandler(this.start_Click);
            // 
            // EncryptorDecryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(338, 204);
            this.Controls.Add(this.StartEncryptDecrypt);
            this.Controls.Add(this.EncryptRadio);
            this.Controls.Add(this.DecryptRadio);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.OutputTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptorDecryptor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Encrypt / Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.RadioButton DecryptRadio;
        private System.Windows.Forms.RadioButton EncryptRadio;
        private System.Windows.Forms.Button StartEncryptDecrypt;
    }
}