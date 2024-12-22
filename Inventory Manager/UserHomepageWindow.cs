using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class UserHomepageWindow : Form
    {
        #region essential_data
        public UserHomepageWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }
        #endregion

        #region startup functions
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
            if(e.Alt && e.KeyCode == Keys.S) //switch to login form again
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
            int screenWidth = Screen.PrimaryScreen.Bounds.Width ,
            screenHeight = Screen.PrimaryScreen.Bounds.Height ,
            toastWidth = 300 ,
            toastHeight = 50 ,
            x = (screenWidth - toastWidth) / 2 ,
            y = screenHeight - toastHeight - 75;
            toast.Show(message, this, x, y, 1500); 
        }

        private void Auth_FormClosed(object sender , EventArgs e) //event when the auth is closed
        {
            this.Close(); 
        }
    
        #endregion

        #region buttons
        private void button2_Click(object sender, EventArgs e)
        {
            var p = new Customers();
            p.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var s = new UserProductsWindow();
            s.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var C = new Customers();
            C.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var p = new Purchases();
            p.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var p = new ProductsReport();
            p.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var ir = new InventoryReport();
            ir.Show();
        }

        private void changeUserPassword_Click(object sender, EventArgs e)
        {
            var ch = new ChangeUserPassword();
            ch.ShowDialog();
        }


        #region shortcut guidance 

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

        #region entities
        private void label5_Click_1(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void label4_Click(object sender, EventArgs e){}
        private void pictureBox1_Click(object sender, EventArgs e){}
        private void label7_Click(object sender, EventArgs e){}
        private void pictureBox2_Click(object sender, EventArgs e){}
        private void pictureBox1_Click_1(object sender, EventArgs e){}
        private void pictureBox3_Click(object sender, EventArgs e){}
        private void label9_Click(object sender, EventArgs e){}
        private void label6_Click(object sender, EventArgs e){}
        private void label3_Click_1(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
        private void label3_Click(object sender, EventArgs e){}
        private void label5_Click(object sender, EventArgs e){}
        private void button4_Click(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e){}
        private void panel1_Paint(object sender, PaintEventArgs e){}
        private void button8_Click(object sender, EventArgs e){}
        #endregion

    }
}
