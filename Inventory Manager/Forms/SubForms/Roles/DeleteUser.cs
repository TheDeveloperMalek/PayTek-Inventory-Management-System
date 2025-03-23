using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class DeleteUser : Form
    {

        #region Essential data
        readonly Customer callerForm;

        public DeleteUser(Customer r)
        {
            InitializeComponent();
            callerForm = r;
            Shared.TextBoxAutoCompleteFromColumnGuna("Roles", "username", UsernameTextBox);
        }
        #endregion

        #region Events

        #region Button Click
        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            Shared.ConnectionInitializer();
            if(UsernameTextBox.Text is "")
            {
                Shared.ErrorOccuredMessageBox("Please enter the username");
                return;
            }
            if ((UsernameTextBox.Text is "admin" || UsernameTextBox.Text is "developer" || UsernameTextBox.Text is "user") && Shared.currentUserType != "developer" )
            {
                Shared.IgnoredProcess("You can't delete default accounts");
                return;
            }
            if (Shared.DoesUserExists(UsernameTextBox.Text))
            {
                try
                {
                using (var cmd = new SqlCommand("DeleteUser", Shared.conn))
                {
                        cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text);
                if (cmd.ExecuteNonQuery() > 0)
                    Shared.ProcessIsDoneMessageBox("user", "deleted");
                else
                    Shared.IgnoredProcess("Nochange happened");
                }
                }
                catch(Exception exc)
                {
                    Shared.ErrorOccuredMessageBox(exc.Message);
                }
                finally { Shared.conn.Close(); }
            }
            else
                Shared.ErrorOccuredMessageBox("Username is not exists");
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }
 #endregion
        private void AddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            callerForm.ShowData();
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            DeleteBtn.Enabled = UsernameTextBox.TextLength > 0;
        }
        #endregion
    }
}
