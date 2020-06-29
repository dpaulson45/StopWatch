using System;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class EditUserSettingsForm : Form
    {
        public EditUserSettingsForm(string SettingName)
        {
            InitializeComponent();
            lblSettingName.Text = SettingName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
