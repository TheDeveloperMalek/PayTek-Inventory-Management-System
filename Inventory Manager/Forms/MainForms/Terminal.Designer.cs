namespace Inventory_Manager
{
    partial class Terminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.cmdBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cmdBox
            // 
            this.cmdBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.cmdBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.cmdBox, "cmdBox");
            this.cmdBox.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmdBox.Name = "cmdBox";
            this.cmdBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmdBox_KeyDown);
            // 
            // Terminal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Terminal";
            this.Opacity = 0D;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cmdBox;
    }
}