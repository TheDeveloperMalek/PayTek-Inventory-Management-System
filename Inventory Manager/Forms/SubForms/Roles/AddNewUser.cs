using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class AddNewUser : Form
    {

        #region Essential data
        string usertype = "";
        readonly Customer callerForm;

        public AddNewUser(Customer r)
        {
            InitializeComponent();
            this.ViewPasswordBtn.CustomImages.Image = System.Drawing.Image.FromStream(Shared.StreamMakerFromAssemblyFile("Resources.Icons", "view", "png"));
            callerForm = r;
        }
        #endregion

        #region Startup functions
        void UsertypeCheck()
        {
            usertype = AdminRadio.Checked ? "admin" : "user";
        }
        #endregion

        #region Validation functions
        private bool Chech_If_Text_Boxes_Were_Empty()
        {
            if (UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                if (UsernameTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please enter username");
                    return true;
                }
                if (PasswordTextBox.Text == "")
                {
                    Shared.ErrorOccuredMessageBox("Please enter password");
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Events

        #region Button Click
        private void AddUserBtn_Click(object sender, EventArgs e)
        {

            if (Shared.ArePasswordConditionsFulfilled(PasswordTextBox.Text))
                if (!Chech_If_Text_Boxes_Were_Empty())
                    if (!Shared.DoesUserExists(UsernameTextBox.Text))
                    {
                        try
                        {
                            Shared.ConnectionInitializer();
                            using (var cmd = new SqlCommand("AddNewUser", Shared.conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                UsertypeCheck();
                                cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                                cmd.Parameters.AddWithValue("@password", Shared.Encrypt(PasswordTextBox.Text));
                                cmd.Parameters.AddWithValue("@usertype", usertype);
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                if (cmd.ExecuteNonQuery() > 0)
                                    Shared.ProcessIsDoneMessageBox("user", "added");
                            }

                        }
                        catch (Exception exc)
                        {
                            Shared.ErrorOccuredMessageBox(exc.Message);
                        }
                        finally
                        {
                            Shared.conn.Close();
                        }
                    }
                    else
                        Shared.IgnoredProcess("Username is already exist , please pick another username");
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }
        #endregion
        private void UserRadio_CheckedChanged(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }

        private void AdminRadio_CheckedChanged(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }

        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }
        private void ViewPasswordBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            if (PasswordTextBox.PasswordChar == '•')
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

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled = UsernameTextBox.TextLength > 0 && PasswordTextBox.TextLength > 0;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled = UsernameTextBox.TextLength > 0 && PasswordTextBox.TextLength > 0;
        }
        #endregion
    }
}
