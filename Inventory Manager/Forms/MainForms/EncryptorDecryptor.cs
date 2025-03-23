using System;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class EncryptorDecryptor : Form
    {
        #region Essential Data
        public EncryptorDecryptor()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Shortcuts);
            this.KeyPreview = true;
        }

        #endregion

        #region Startup Functions
        void Shortcuts(object sender, KeyEventArgs e)
        {
            Shared.KeysShortcuts(sender, e, this, false);
            if (e.KeyCode == Keys.Enter)
                start_Click(sender, e);
        }
        #endregion

        #region Events
        #region Button Click
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
        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this, 5);
        }
        #endregion
        private void DecryptRadio_CheckedChanged(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }

        private void EncryptRadio_CheckedChanged(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            Start.Enabled = InputTextBox.TextLength > 0;
        }

        #endregion

    }
}
