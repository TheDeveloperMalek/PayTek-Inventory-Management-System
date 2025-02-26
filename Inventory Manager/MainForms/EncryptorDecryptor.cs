using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class EncryptorDecryptor : Form
    {
        #region Form loading
        public EncryptorDecryptor()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Shortcuts);
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, KeyEventArgs e) { }
        #endregion

        #region buttons
        private void start_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            if (InputTextBox.Text != "")
                if (DecryptRadio.Checked)
                    OutputTextBox.Text = Shared.Decrypt(InputTextBox.Text);
                else
                    OutputTextBox.Text = Shared.Encrypt(InputTextBox.Text);
            else
                MessageBox.Show("Please input text to perform this action");
        }
        #endregion

        #region functions
        void Shortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this, false);
            if (e.KeyCode == Keys.Enter)
                start_Click(sender, e);
        }
        #endregion

    }
}
