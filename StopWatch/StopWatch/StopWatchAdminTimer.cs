using System;
using System.Windows.Forms; 

namespace StopWatch
{
    class StopWatchAdminTimer : StopWatchTimerClass
    {
        private TextBox txtBox;
        private TextBox txtBoxAdminTitle; 
        private Form pForm; 
        

        public StopWatchAdminTimer(Form pForm)
        {
            this.pForm = pForm;
            LoadTextBox();
        }

        private void LoadTextBox()
        {
            //Dislay Admin Box 
            txtBox = new TextBox();
            txtBox.Name = "Admin_TextBox";
            txtBox.Margin = new Padding(2, 2, 2, 2);
            txtBox.Size = new System.Drawing.Size(135, 15);
            txtBox.Location = new System.Drawing.Point(340, 65);
            txtBox.BackColor = System.Drawing.SystemColors.Menu;
            txtBox.BorderStyle = BorderStyle.None;
            txtBox.TabStop = false;
            txtBox.ReadOnly = true;
            txtBox.TextAlign = HorizontalAlignment.Right;
            txtBox.Text = GetLabelTimeString(); 
            pForm.Controls.Add(txtBox);

            //Admin Timer
            txtBoxAdminTitle = new TextBox();
            txtBoxAdminTitle.Name = "Admin_Display";
            txtBoxAdminTitle.Text = "Admin Time";
            txtBoxAdminTitle.BackColor = System.Drawing.SystemColors.Menu;
            txtBoxAdminTitle.BorderStyle = BorderStyle.None;
            txtBoxAdminTitle.Location = new System.Drawing.Point(370, 50);
            txtBoxAdminTitle.Margin = new Padding(2, 2, 2, 2);
            txtBoxAdminTitle.Size = new System.Drawing.Size(75, 15);
            txtBoxAdminTitle.TabStop = false;
            txtBoxAdminTitle.TextAlign = HorizontalAlignment.Center;
            pForm.Controls.Add(txtBoxAdminTitle);

            //Timer
            stopWatchTimer = new Timer();
            stopWatchTimer.Interval = 1000;
            stopWatchTimer.Enabled = true;
            stopWatchTimer.Tick += new EventHandler(IncreaseTimers); 
                        
        }

        protected override void IncreaseTimers(object s, EventArgs e)
        {
            base.IncreaseTimers(s, e);
            UpdateAdminTimer(); 
        }

        private void UpdateAdminTimer()
        {
            txtBox.Text = GetLabelTimeString(); 
        }


    }
}
