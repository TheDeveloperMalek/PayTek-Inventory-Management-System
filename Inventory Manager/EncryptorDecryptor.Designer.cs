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
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.decrypt = new System.Windows.Forms.RadioButton();
            this.encrypt = new System.Windows.Forms.RadioButton();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTextBox.Location = new System.Drawing.Point(9, 156);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(319, 31);
            this.resultTextBox.TabIndex = 4;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(9, 82);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(319, 31);
            this.inputTextBox.TabIndex = 0;
            // 
            // decrypt
            // 
            this.decrypt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.decrypt.AutoSize = true;
            this.decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decrypt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.decrypt.Location = new System.Drawing.Point(124, 47);
            this.decrypt.Name = "decrypt";
            this.decrypt.Size = new System.Drawing.Size(104, 29);
            this.decrypt.TabIndex = 1;
            this.decrypt.Text = "Decrypt";
            this.decrypt.UseVisualStyleBackColor = true;
            // 
            // encrypt
            // 
            this.encrypt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.encrypt.AutoSize = true;
            this.encrypt.Checked = true;
            this.encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encrypt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.encrypt.Location = new System.Drawing.Point(125, 12);
            this.encrypt.Name = "encrypt";
            this.encrypt.Size = new System.Drawing.Size(103, 29);
            this.encrypt.TabIndex = 1;
            this.encrypt.TabStop = true;
            this.encrypt.Text = "Encrypt";
            this.encrypt.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(124, 119);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(104, 31);
            this.start.TabIndex = 3;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(338, 204);
            this.Controls.Add(this.start);
            this.Controls.Add(this.encrypt);
            this.Controls.Add(this.decrypt);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.resultTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Encrypt / Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.RadioButton decrypt;
        private System.Windows.Forms.RadioButton encrypt;
        private System.Windows.Forms.Button start;
    }
}