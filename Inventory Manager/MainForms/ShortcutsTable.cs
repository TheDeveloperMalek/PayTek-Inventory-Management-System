using System;
using System.Windows.Forms;

namespace Inventory_Manager.MainForms
{
    public partial class ShortcutsTable : Form
    {
        public ShortcutsTable()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Shared.PlayClickSound();
            Shared.FadeOutEffect(this);
        }
    }
}
