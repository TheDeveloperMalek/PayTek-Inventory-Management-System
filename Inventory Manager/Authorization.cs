using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Authorization : Form
    {
        #region essential data
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        string DefaultAdminPassword = "1";
        string DefaultUserPassword = "2";
        public static string newAdminPassword = "";
        public static string newUserPassword = "";

        public Authorization()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            newAdminPassword = ChangeUsersPassword.newAdminPassGetter();
            
            newUserPassword = ChangeUsersPassword.newUserPassGetter();

            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
        #endregion

        #region startup_functions
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E) //exit
            {
                this.Close();
                return;
            }

            if (e.Control && e.KeyCode == Keys.I) // show information about the devleoper
            {
                ShowToast("The Developer: Muhammad Malek Alset");
                return;
            }

            if (e.KeyCode == Keys.Enter) //click login button when click enter
            {
                LogintBtn_Click(sender, e);
                return;
            }

            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.R) //to reset the password if the admin forgets it
            {
                this.Hide();
                var h = new Homepage();
                h.FormClosed += Homepage_FormClosed;
                h.Show();
            }
        }

        private void ShowToast(string message)
        {
            ToolTip toast = new ToolTip();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width,
            screenHeight = Screen.PrimaryScreen.Bounds.Height,
            toastWidth = 300,
            toastHeight = 50,
            x = (screenWidth - toastWidth) / 8,
            y = screenHeight - toastHeight - 265;
            toast.Show(message, this, x, y, 500);
        }
        #endregion

        #region buttons
        public void LogintBtn_Click(object sender, EventArgs e)
        {
            if (password_text_box.Text != "")
            {
                if (Admin_radio.Checked)
                {
                    if (newAdminPassword != "" && password_text_box.Text == newAdminPassword)
                    {
                        this.Hide();
                        var h = new Homepage();
                        h.FormClosed += Homepage_FormClosed;
                        h.Show();
                    }

                    else if (newAdminPassword == "" && password_text_box.Text == DefaultAdminPassword)
                    {
                        this.Hide();
                        var h = new Homepage();
                        h.FormClosed += Homepage_FormClosed;
                        h.Show();
                    }

                    else
                        MessageBox.Show("Incorrect Password", "Error");
                }

                if (User_radio.Checked)
                {
                        if (newUserPassword != "" && password_text_box.Text == newUserPassword)
                        {
                            this.Hide();
                            var c = new UserHomepageWindow();
                            c.FormClosed += Products_FormClosed;
                            c.Show();
                        }

                        else if (newUserPassword == "" && password_text_box.Text == DefaultUserPassword)
                        {
                            this.Hide();
                            var c = new UserHomepageWindow();
                            c.FormClosed += Products_FormClosed;
                            c.Show();
                        }

                        else
                            MessageBox.Show("Incorrect Password", "Error");
                }
            }
            else
                MessageBox.Show("Password can't be empty", "Error");
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
