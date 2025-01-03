﻿using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Homepage : Form
    {
        #region essential_data
        public Homepage()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }
        #endregion

        #region startup_functions
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F) //make full screen
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Normal;
                    this.Location = new System.Drawing.Point(0, 0);
                    this.Size = Screen.PrimaryScreen.Bounds.Size;
                }
                return;
            }
            if (e.Control && e.KeyCode == Keys.E) //exit
            {
                this.Close();
                return;
            }
            if (e.Alt && e.KeyCode == Keys.S) //switch to login form again
            {
                this.Hide();
                var a = new Authorization();
                a.FormClosed += Auth_FormClosed;
                a.Show();
            }
            if (e.Control && e.KeyCode == Keys.M) //minimize
            {
                this.WindowState = FormWindowState.Minimized;
                return;
            }

            if (e.Control && e.KeyCode == Keys.I) // show information about the devleoper
            {
                ShowToast("The Developer: Muhammad Malek Alset");
                return;
            }
            if (e.Control && e.KeyCode == Keys.H)
            {
                Homepage f = new Homepage();
                f.Show();
            }
        }

        private void ShowToast(string message)
        {
            ToolTip toast = new ToolTip();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width,
            screenHeight = Screen.PrimaryScreen.Bounds.Height,
            toastWidth = 300,
            toastHeight = 50,
            x = (screenWidth - toastWidth) / 2,
            y = screenHeight - toastHeight - 75;
            toast.Show(message, this, x, y, 1500);
        }

        private void Auth_FormClosed(object sender, EventArgs e) //event when the auth is closed
        {
            this.Close();
        }

        #endregion

        #region buttons
        private void button2_Click(object sender, EventArgs e)
        {
            Customers p = new Customers();
            p.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Products s = new Products();
            s.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Customers C = new Customers();
            C.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Purchases p = new Purchases();
            p.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProductsReport p = new ProductsReport();
            p.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            InventoryReport ir = new InventoryReport();
            ir.Show();
        }

        private void changeUserPassword_Click(object sender, EventArgs e)
        {
            var changeUsersPassword = new ChangeUsersPassword();
            changeUsersPassword.Show();
        }

        #region shortcut guidance button
        private void shortcutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Ctrl + f => Toggle full screen
Ctrl + m => Minimize the form
Ctrl + e => Close the form
Alt + s => Switch to login form (just for homepage)
Ctrl + p => To save the table as an excel file (just for reports)
Ctrl + i => infromation about the developer
                            ", "Shortcuts Table");
        }
        #endregion

        #endregion

    }
}
