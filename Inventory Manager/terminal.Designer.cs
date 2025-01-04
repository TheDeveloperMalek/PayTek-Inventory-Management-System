namespace Inventory_Manager
{
    partial class terminal
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
            this.cmdBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cmdBox
            // 
            this.cmdBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.cmdBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdBox.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBox.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmdBox.Location = new System.Drawing.Point(0, 0);
            this.cmdBox.Name = "cmdBox";
            this.cmdBox.Size = new System.Drawing.Size(800, 450);
            this.cmdBox.TabIndex = 0;
            this.cmdBox.Text = "";
            this.cmdBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdBox_KeyDown);
            // 
            // terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "terminal";
            this.Text = "terminal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cmdBox;
    }
}