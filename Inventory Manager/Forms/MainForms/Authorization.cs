using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Authorization : Form
    {
        #region Essential Data
        string errorMessage = "";
        public Authorization()
        {
            InitializeComponent();
            Shared.FadeInEffect(this, 5);
            Shared.CreateDBIfNotExists();
            this.KeyDown += new KeyEventHandler(KeysShortcuts);
            this.KeyPreview = true;
            this.ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "view", "png"));
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
            if (e.KeyCode == Keys.Enter && PasswordTextBox.Text != "" && UserNameTextBox.Text != "")
            {
                e.SuppressKeyPress = true;
                LogintBtn_Click(sender, e);
            }
        }

        public bool IsPasswordCorrect()
        {
            Shared.ConnectionInitializer();
            using (var command = new SqlCommand("IsPasswordCorrect", Shared.conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", UserNameTextBox.Text);
                command.Parameters.AddWithValue("@password", Shared.Encrypt(PasswordTextBox.Text));
                var result = command.ExecuteScalar();
                return result != null && result.ToString() == "true";
            }

        }

        private async Task ShowErrorMessageWhileLogin()
        {
            await Task.Run(() =>
            {
                Shared.PlayWrongPasswordSound();
                MessageBox.Show(errorMessage, "Error");
            }
            );
        }

        public void DefaultUserTypeChanger()
        {
                Shared.ConnectionInitializer();
                using (var cmd = new SqlCommand("GetUserRole", Shared.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", UserNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@password", Shared.Encrypt(PasswordTextBox.Text));
                    var result = cmd.ExecuteScalar().ToString();
                    if (string.Compare(result, "developer", true) == 0)
                        Shared.defaultUserType = UserType.Developer;
                    else if (string.Compare(result, "admin", true) == 0)
                        Shared.defaultUserType = UserType.Admin;
                    Shared.currentUserType = result.ToLower();
                }
                Shared.HideComponentsByUserType();
                Shared.currentUserPassword = PasswordTextBox.Text;
                Shared.currentUserName = UserNameTextBox.Text;
                fadeOutHideTimer.Start();
                var h = new Homepage();
                h.FormClosed += Homepage_FormClosed;
                h.Show();
            Shared.defaultUserType = UserType.User;
        }

        #endregion

        #region Events

        #region Button Click
        public async void LogintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Shared.DoesUserExists(UserNameTextBox.Text))
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
                    errorMessage = "Username does not exist!";
            await ShowErrorMessageWhileLogin();
            }
            catch (Exception exc)
            {
                Shared.ErrorOccuredMessageBox(exc.Message);
            }
        }

        
        private void ViewPasswordButton_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            if (PasswordTextBox.PasswordChar is '•')
            {
                PasswordTextBox.PasswordChar = '\0';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "hide", "png"));
            }
            else
            {
                PasswordTextBox.PasswordChar = '•';
                ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "view", "png"));
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }
        #endregion

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

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoginBtn.Enabled = UserNameTextBox.TextLength > 0 && PasswordTextBox.TextLength > 0;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            LoginBtn.Enabled = UserNameTextBox.TextLength > 0 && PasswordTextBox.TextLength > 0;
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}