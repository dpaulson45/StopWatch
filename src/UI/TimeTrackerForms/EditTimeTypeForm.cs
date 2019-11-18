using System;
using System.Windows.Forms;

namespace StopWatch.TimeTracker
{
    public partial class EditTimeTypeForm : Form
    {
        public EditTimeTypeForm(object[] TimeTypes)
        {
            InitializeComponent();
            foreach (var timeType in TimeTypes)
            {
                lbTimeType.Items.Add(timeType.ToString());
            }
        }

        public object[] GetTimeTypeList
        {
            get
            {
                object[] obj = new object[lbTimeType.Items.Count];

                for (int i = 0; i < lbTimeType.Items.Count; i++)
                {
                    obj[i] = lbTimeType.Items[i];
                }

                return obj;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lbTimeType.Items.Add(tbEditTimeType.Text);
            tbEditTimeType.Text = "";
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lbTimeType.SelectedItem != null)
            {
                lbTimeType.Items.Remove(lbTimeType.SelectedItem);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lbTimeType.SelectedItem != null)
            {
                tbEditTimeType.Text = lbTimeType.SelectedItem.ToString();
            }
        }
    }
}
