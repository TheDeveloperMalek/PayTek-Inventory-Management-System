using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Authorization : Form
    {
        #region essential data
        public Authorization()
        {
            InitializeComponent();
            Shared.CreateDBIfNotExists();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            this.viewPasswordButton.CustomImages.Image = Shared.ImageGetterFromAssembly("Icons", "view", "png");
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            Shared.DeveloperPasswordSetter();
        }
        #endregion

        #region Startup Functions
        private void KeysShortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this, false);
            if (e.KeyCode == Keys.Enter) //click login button when click enter
            {
                e.SuppressKeyPress = true;
                LogintBtn_Click(sender, e);
                return;
            }
        }


        public bool TextBoxNotEmpty()
        {
            if (usernameTextBox.Text == "" && password_text_box.Text == "")
            {
                MessageBox.Show("Please enter username and password to login");
                return false;
            }
            else if (usernameTextBox.Text == "")
            {
                MessageBox.Show("Please enter username to login");
                return false;
            }
            else if (password_text_box.Text == "")
            {
                MessageBox.Show("Please enter password to login");
                return false;
            }

            return true;
        }

        public bool IsUserExists()
        {
            Shared.ConnectionInitializer();
            Shared.cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
            Shared.cmd.Connection = Shared.conn;
            Shared.cmd.CommandText = $@"IF (SELECT username 
                                            FROM Roles
                                            WHERE username = @username) = @username
                                SELECT 'true'
                                ELSE 
                                SELECT 'false'";
            return bool.Parse(Shared.cmd.ExecuteScalar().ToString());
        }

        public bool IsPasswordCorrect()
        {
            Shared.ConnectionInitializer();
            using (var command = Shared.conn.CreateCommand())
            {
                command.CommandText = @"IF EXISTS (SELECT 1 
                                        FROM Roles 
                                        WHERE username = @username AND Password = @password)
                                        SELECT 'true'
                                        ELSE 
                                        SELECT 'false'";

                command.Parameters.AddWithValue("@username", usernameTextBox.Text);
                command.Parameters.AddWithValue("@password", Shared.Encrypt(password_text_box.Text));
                var result = command.ExecuteScalar();
                return result != null && result.ToString() == "true";
            }

        }

        public void UserTypeParser()
        {
            Shared.ConnectionInitializer();
            Shared.cmd.Parameters.Clear();
            Shared.cmd.CommandText = @"SELECT Usertype 
                                            FROM Roles
                                            WHERE Username = @username
                                            AND Password = @password";

            Shared.cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
            Shared.cmd.Parameters.AddWithValue("@password", Shared.Encrypt(password_text_box.Text));
            var result = Shared.cmd.ExecuteScalar().ToString();
            if (string.Compare(result, "developer", true) == 0)
                Shared.defaultUserType = UserType.Developer;
            else if (string.Compare(result, "admin", true) == 0)
                Shared.defaultUserType = UserType.Admin;
            Shared.HideComponentsByUserType();
            Shared.Password = password_text_box.Text;
            Shared.UserName = usernameTextBox.Text;
            Shared.Usertype = result.ToLower();
            this.Hide();
            var h = new Homepage();
            h.FormClosed += Homepage_FormClosed;
            h.Show();
            Shared.defaultUserType = UserType.User;
        }

        #endregion

        #region buttons
        public void LogintBtn_Click(object sender, EventArgs e)
        {
            if (TextBoxNotEmpty())
                if (IsUserExists())
                    if (IsPasswordCorrect())
                    {
                        Shared.UserName = usernameTextBox.Text;
                        Shared.Password = password_text_box.Text;
                        UserTypeParser();
                    }
                    else
                        MessageBox.Show("Password is not correct!");
                else
                    MessageBox.Show("Username is not exists!");
        }

        private void ViewPasswordButton_Click(object sender, EventArgs e)
        {

            if (password_text_box.PasswordChar == '•')
            {
                password_text_box.PasswordChar = '\0';
                viewPasswordButton.CustomImages.Image = Shared.ImageGetterFromAssembly("Icons", "hide", "png");
            }
            else
            {
                password_text_box.PasswordChar = '•';
                viewPasswordButton.CustomImages.Image = Shared.ImageGetterFromAssembly("Icons", "view", "png");
            }
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}