﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class ChangeUsersPassword : Form
    {
        #region essential data
        static SqlConnection conn = new SqlConnection();
        static SqlCommand cmd = new SqlCommand();

        public ChangeUsersPassword()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
        }

        private void ChangeUsersPassword_Load(object sender, EventArgs e)
        {
            crrAdminPass.Text = TextCustomizer(newAdminPassGetter());
            crrUserPass.Text = TextCustomizer(newUserPassGetter());
        }

        #endregion

        #region startup functions

        private static void Open_Connection_If_Was_Closed()
        {

            if (conn.State != ConnectionState.Open)
            {
                conn.ConnectionString = conn.ConnectionString = "Data Source=DESKTOP-CM5BM88;Initial Catalog=Public;Integrated Security=True;Encrypt=False;";

                conn.Close();
                conn.Open();
            }

        }

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

            if(e.KeyCode == Keys.Enter) //click save button when click enter
            {
                LogintBtn_Click(sender, e);
                return;
            }
        }

        private void ShowToast(string message)
        {
            ToolTip toast = new ToolTip();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width,
            screenHeight = Screen.PrimaryScreen.Bounds.Height,
            toastWidth = 300,
            toastHeight = 50,
            x = (screenWidth - toastWidth) / 4,
            y = screenHeight - toastHeight - 265;
            toast.Show(message, this, x, y, 500);
        }

        string TextCustomizer(string input)
        {
            var output = "";
            if (input.Length > 15)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (i % 8 == 0)
                        output += "\n";
                    output += input[i];
                }
                return output;
            }
            else
                return input;
        }

        public static string newAdminPassGetter()
        {
            Open_Connection_If_Was_Closed();


            cmd.Connection = conn;

            cmd.CommandText = @"Select password 
                                FROM AuthPassword
                                WHERE user_type = 'Admin' ";
            return Decrypt((string)cmd.ExecuteScalar());
        }

        public static string newUserPassGetter()
        {
            Open_Connection_If_Was_Closed();

            cmd.Connection = conn;

            cmd.CommandText = @"Select password 
                                FROM AuthPassword
                                WHERE user_type = 'User' ";
            return Decrypt((string)cmd.ExecuteScalar());
        }

        public static string Encrypt(string plaintext, int shift = 3)
        {
            StringBuilder asciiValues = new StringBuilder();

            foreach (char c in plaintext)
            {
                char encryptedChar;

                if (char.IsUpper(c))
                {
                    encryptedChar = (char)((((c + shift) - 'A') % 26) + 'A');
                }
                else if (char.IsLower(c))
                {
                    encryptedChar = (char)((((c + shift) - 'a') % 26) + 'a');
                }
                else
                {
                    encryptedChar = c;
                }

                asciiValues.Append((int)encryptedChar + " ");
            }

            return asciiValues.ToString().Trim();
        }

        public static string Decrypt(string asciiValues, int shift = 3)
        {
            StringBuilder decryptedText = new StringBuilder();
            string[] asciiArray = asciiValues.Split(' ');

            foreach (string asciiValue in asciiArray)
            {
                if (int.TryParse(asciiValue, out int value))
                {
                    char decryptedChar;

                    if (value >= 'A' && value <= 'Z')
                    {
                        decryptedChar = (char)((((value - 'A') - shift + 26) % 26) + 'A');
                    }
                    else if (value >= 'a' && value <= 'z')
                    {
                        decryptedChar = (char)((((value - 'a') - shift + 26) % 26) + 'a');
                    }
                    else
                    {
                        decryptedChar = (char)value; // Non-alphabetic characters remain unchanged
                    }

                    decryptedText.Append(decryptedChar);
                }
            }

            return decryptedText.ToString(); // Return the decrypted string
        }

        #endregion

        #region buttons

        private void LogintBtn_Click(object sender, EventArgs e)
        {
            var orginalPassword = password_text_box.Text;
            var passwordLength = password_text_box.Text.Length;
            var minimumPasswordLength = 3;
            var maximumPasswordLength = 30;
            crrAdminPass.Text = TextCustomizer(Authorization.newAdminPassword);
            crrUserPass.Text = TextCustomizer(Authorization.newUserPassword);

            if (Admin_radio.Checked && passwordLength >= minimumPasswordLength && passwordLength <= maximumPasswordLength)
            {
                Open_Connection_If_Was_Closed();

                var encryptedPassword = Encrypt(orginalPassword);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE AuthPassword
                                        SET password = @password
                                        WHERE user_type = 'Admin' ";
                cmd.Parameters.AddWithValue("@password", encryptedPassword);

                cmd.ExecuteNonQuery();

                crrAdminPass.Text = TextCustomizer(newAdminPassGetter());
                crrUserPass.Text = TextCustomizer(newUserPassGetter());

                cmd.Dispose();
                conn.Dispose();

                MessageBox.Show("Updated successfully");

            }

            else if (User_radio.Checked && passwordLength >= minimumPasswordLength && passwordLength <= maximumPasswordLength)
            {
                Open_Connection_If_Was_Closed();

                var encryptedPassword = Encrypt(orginalPassword);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE AuthPassword
                                        SET password = @password
                                        WHERE user_type = 'User' ";
                cmd.Parameters.AddWithValue("@password", encryptedPassword);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated successfully");

                crrAdminPass.Text = TextCustomizer(newAdminPassGetter());
                crrUserPass.Text = TextCustomizer(newUserPassGetter());

                cmd.Dispose();
                conn.Dispose();
            }

            else
            {
                MessageBox.Show($"Password length is {passwordLength} , it should be between {minimumPasswordLength} and {maximumPasswordLength}");
            }

            cmd.Parameters.Clear();
        }

        #endregion

        #region entities
        private void password_text_box_TextChanged(object sender, EventArgs e) { }
        private void crrAdminPass_Click(object sender, EventArgs e) { }
        private void crrUserPass_Click(object sender, EventArgs e) { }
        #endregion
    }

}