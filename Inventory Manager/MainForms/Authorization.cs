using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Authorization : Form
    {
        #region essential data
        string errorMessage = "";
        public Authorization()
        {
            InitializeComponent();
            Shared.FadeInEffect(this, 5);
            Shared.CreateDBIfNotExists();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            this.ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.FileGetterFromAssembly("Icons", "view", "png"));
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            try
            {
                Shared.DeveloperPasswordSetter();
            }
            catch { }
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
            }
        }

        public bool AreUserAndPasswordTextBoxesFilled()
        {
            if (UserNameTextBox.Text == "" && PasswordTextBox.Text == "")
            {
                errorMessage = "Please enter username and password to login";
                return false;
            }
            else if (UserNameTextBox.Text == "")
            {
                errorMessage = "Please enter username to login";
                return false;
            }
            else if (PasswordTextBox.Text == "")
            {
                errorMessage = "Please enter password to login";
                return false;
            }

            return true;
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

                command.Parameters.AddWithValue("@username", UserNameTextBox.Text);
                command.Parameters.AddWithValue("@password", Shared.Encrypt(PasswordTextBox.Text));
                var result = command.ExecuteScalar();
                return result != null && result.ToString() == "true";
            }

        }

        public void DefaultUserTypeChanger()
        {
            Shared.ConnectionInitializer();
            Shared.cmd.Parameters.Clear();
            Shared.cmd.CommandText = @"SELECT Usertype 
                                        FROM Roles
                                        WHERE Username = @username
                                        AND Password = @password";

            Shared.cmd.Parameters.AddWithValue("@username", UserNameTextBox.Text);
            Shared.cmd.Parameters.AddWithValue("@password", Shared.Encrypt(PasswordTextBox.Text));
            var result = Shared.cmd.ExecuteScalar().ToString();
            if (string.Compare(result, "developer", true) == 0)
                Shared.defaultUserType = UserType.Developer;
            else if (string.Compare(result, "admin", true) == 0)
                Shared.defaultUserType = UserType.Admin;
            Shared.HideComponentsByUserType();
            Shared.currentUserPassword = PasswordTextBox.Text;
            Shared.currentUserName = UserNameTextBox.Text;
            Shared.currentUserType = result.ToLower();
            fadeOutHideTimer.Start();
            var h = new Homepage();
            h.FormClosed += Homepage_FormClosed;
            h.Show();
            Shared.defaultUserType = UserType.User;
        }

        #endregion

        #region buttons
        public async void  LogintBtn_Click(object sender, EventArgs e)
        {
            
            if (AreUserAndPasswordTextBoxesFilled())
                if (Shared.IsUserExists(UserNameTextBox.Text))
                    if (IsPasswordCorrect())
                    {
                        Shared.currentUserName = UserNameTextBox.Text;
                        Shared.currentUserPassword = PasswordTextBox.Text;
                        DefaultUserTypeChanger();
                        Shared.PlayStartupSound();
                        return;
                    }
                    else
                        errorMessage = "Password is not correct!";
                else
                    errorMessage = "Username is not exists!";
            await test();
        }

        private async Task test()
        {
            await Task.Run(() =>
            {
                Shared.PlayWrongPasswordSound();
                MessageBox.Show(errorMessage , "Error");
            }
            );
        }
        private void ViewPasswordButton_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            if (PasswordTextBox.PasswordChar == '•')
            {
                PasswordTextBox.PasswordChar = '\0';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.FileGetterFromAssembly("Icons", "hide", "png"));
            }
            else
            {
                PasswordTextBox.PasswordChar = '•';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.FileGetterFromAssembly("Icons", "view", "png"));
            }
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }
        #endregion

        #region timers

        private void fadeOutHideTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
                this.Opacity -= 0.025;
            else
            {
                fadeOutHideTimer.Stop();
                this.Hide();
            }
        }

        #endregion
    }
}