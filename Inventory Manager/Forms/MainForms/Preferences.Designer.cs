namespace Inventory_Manager.Forms.MainForms
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.CompanyHeaderRichTextBox = new System.Windows.Forms.RichTextBox();
            this.pdfcompanyheader = new System.Windows.Forms.Label();
            this.pdfpaymentinfo = new System.Windows.Forms.Label();
            this.PaymentMethodRichTextBox = new System.Windows.Forms.RichTextBox();
            this.WordDate = new System.Windows.Forms.Label();
            this.PDFDateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.EditPrefBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // CompanyHeaderRichTextBox
            // 
            this.CompanyHeaderRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyHeaderRichTextBox.Location = new System.Drawing.Point(16, 36);
            this.CompanyHeaderRichTextBox.Name = "CompanyHeaderRichTextBox";
            this.CompanyHeaderRichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CompanyHeaderRichTextBox.Size = new System.Drawing.Size(339, 104);
            this.CompanyHeaderRichTextBox.TabIndex = 0;
            this.CompanyHeaderRichTextBox.Text = "";
            // 
            // pdfcompanyheader
            // 
            this.pdfcompanyheader.AutoSize = true;
            this.pdfcompanyheader.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfcompanyheader.ForeColor = System.Drawing.Color.White;
            this.pdfcompanyheader.Location = new System.Drawing.Point(12, 9);
            this.pdfcompanyheader.Name = "pdfcompanyheader";
            this.pdfcompanyheader.Size = new System.Drawing.Size(226, 24);
            this.pdfcompanyheader.TabIndex = 4;
            this.pdfcompanyheader.Text = "PDF Company Header";
            // 
            // pdfpaymentinfo
            // 
            this.pdfpaymentinfo.AutoSize = true;
            this.pdfpaymentinfo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfpaymentinfo.ForeColor = System.Drawing.Color.White;
            this.pdfpaymentinfo.Location = new System.Drawing.Point(12, 153);
            this.pdfpaymentinfo.Name = "pdfpaymentinfo";
            this.pdfpaymentinfo.Size = new System.Drawing.Size(226, 24);
            this.pdfpaymentinfo.TabIndex = 6;
            this.pdfpaymentinfo.Text = "PDF Payment Method";
            // 
            // PaymentMethodRichTextBox
            // 
            this.PaymentMethodRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentMethodRichTextBox.Location = new System.Drawing.Point(16, 180);
            this.PaymentMethodRichTextBox.Name = "PaymentMethodRichTextBox";
            this.PaymentMethodRichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PaymentMethodRichTextBox.Size = new System.Drawing.Size(339, 272);
            this.PaymentMethodRichTextBox.TabIndex = 5;
            this.PaymentMethodRichTextBox.Text = "";
            // 
            // WordDate
            // 
            this.WordDate.AutoSize = true;
            this.WordDate.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordDate.ForeColor = System.Drawing.Color.White;
            this.WordDate.Location = new System.Drawing.Point(410, 9);
            this.WordDate.Name = "WordDate";
            this.WordDate.Size = new System.Drawing.Size(118, 24);
            this.WordDate.TabIndex = 8;
            this.WordDate.Text = "Word Date";
            // 
            // PDFDateTimePicker
            // 
            this.PDFDateTimePicker.BorderRadius = 10;
            this.PDFDateTimePicker.Checked = true;
            this.PDFDateTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PDFDateTimePicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PDFDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PDFDateTimePicker.ForeColor = System.Drawing.Color.White;
            this.PDFDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.PDFDateTimePicker.Location = new System.Drawing.Point(414, 36);
            this.PDFDateTimePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.PDFDateTimePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.PDFDateTimePicker.Name = "PDFDateTimePicker";
            this.PDFDateTimePicker.Size = new System.Drawing.Size(200, 36);
            this.PDFDateTimePicker.TabIndex = 49;
            this.PDFDateTimePicker.Value = new System.DateTime(2023, 9, 18, 0, 0, 0, 0);
            this.PDFDateTimePicker.Click += new System.EventHandler(this.PDFDateTimePicker_Click);
            // 
            // EditPrefBtn
            // 
            this.EditPrefBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EditPrefBtn.AutoRoundedCorners = true;
            this.EditPrefBtn.BorderRadius = 24;
            this.EditPrefBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditPrefBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EditPrefBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EditPrefBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EditPrefBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EditPrefBtn.FillColor = System.Drawing.Color.LightBlue;
            this.EditPrefBtn.Font = new System.Drawing.Font("Lucida Sans Typewriter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditPrefBtn.ForeColor = System.Drawing.Color.Black;
            this.EditPrefBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditPrefBtn.Image")));
            this.EditPrefBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditPrefBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.EditPrefBtn.Location = new System.Drawing.Point(414, 454);
            this.EditPrefBtn.Name = "EditPrefBtn";
            this.EditPrefBtn.Size = new System.Drawing.Size(145, 50);
            this.EditPrefBtn.TabIndex = 50;
            this.EditPrefBtn.Text = "Edit";
            this.EditPrefBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditPrefBtn.Click += new System.EventHandler(this.EditPrefBtn_Click);
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(84)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(923, 516);
            this.Controls.Add(this.EditPrefBtn);
            this.Controls.Add(this.PDFDateTimePicker);
            this.Controls.Add(this.WordDate);
            this.Controls.Add(this.pdfpaymentinfo);
            this.Controls.Add(this.PaymentMethodRichTextBox);
            this.Controls.Add(this.pdfcompanyheader);
            this.Controls.Add(this.CompanyHeaderRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox CompanyHeaderRichTextBox;
        private System.Windows.Forms.Label pdfcompanyheader;
        private System.Windows.Forms.Label pdfpaymentinfo;
        private System.Windows.Forms.RichTextBox PaymentMethodRichTextBox;
        private System.Windows.Forms.Label WordDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker PDFDateTimePicker;
        private Guna.UI2.WinForms.Guna2Button EditPrefBtn;
    }
}