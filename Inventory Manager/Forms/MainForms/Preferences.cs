using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Inventory_Manager.Forms.MainForms
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
            PDFDateTimePicker.MaxDate = DateTime.Now;
            InitializeFields();
        }

        #region Startup Functions
        public static string GetPrefValue(string name)
        {
            using (var cmd = new SqlCommand("GetPrefValue", Shared.conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();
            }
        }

        public static void SetPrefValue(string name, string value)
        {
            using (var cmd = new SqlCommand("SetPrefValue", Shared.conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@value", value);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        void InitializeFields()
        {
            try
            {
                CompanyHeaderRichTextBox.Text = GetPrefValue("CompanyHeader");
                PaymentMethodRichTextBox.Text = GetPrefValue("CompanyPaymentInfo");
                PDFDateTimePicker.Value = DateTime.Parse(GetPrefValue("WordDate"));
            }
            catch (Exception ex)
            {
                Shared.ErrorOccuredMessageBox(ex.Message);
            }

        }

        #endregion

        #region Events
        private void EditPrefBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SetPrefValue("CompanyHeader", CompanyHeaderRichTextBox.Text);
                SetPrefValue("CompanyPaymentInfo", PaymentMethodRichTextBox.Text);
                SetPrefValue("WordDate", PDFDateTimePicker.Value.ToShortDateString());
                Shared.ProcessIsDoneMessageBox("new preferences", "saved");
            }
            catch (Exception ex)
            {
                Shared.ErrorOccuredMessageBox(ex.Message);
            }
        }
        private void PDFDateTimePicker_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }
        #endregion
    }
}
