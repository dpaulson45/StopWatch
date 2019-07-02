using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace StopWatch
{
    public class StopWatchPrimaryDisplay
    {
        public TextBox txtBxHour10, txtBxHour01, txtBxMin10, txtBxMin01, txtBxSec10, txtBxSec01;
        private TextBox txtBxDiv1, txtBxDiv2;
        private Form pform; 

        public StopWatchPrimaryDisplay(Form pform)
        {
            this.pform = pform;
            LoadTextBox(); 
        }


        private void LoadTextBox()
        {
            //Hour10
            txtBxHour10 = new TextBox();
            txtBxHour10.Name = "txtHour10";
            BasicTextBoxLoad(txtBxHour10);
            txtBxHour10.Location = new System.Drawing.Point(30, 10);
            pform.Controls.Add(txtBxHour10);

            //Hour01
            txtBxHour01 = new TextBox();
            txtBxHour01.Name = "txtHour01";
            BasicTextBoxLoad(txtBxHour01);
            txtBxHour01.Location = new System.Drawing.Point(65, 10);
            pform.Controls.Add(txtBxHour01);

            //First : 
            txtBxDiv1 = new TextBox();
            txtBxDiv1.Name = "txtBxDiv1";
            BasicTextBoxLoad(txtBxDiv1);
            txtBxDiv1.Text = ":";
            txtBxDiv1.Size = new System.Drawing.Size(18, 58);
            txtBxDiv1.Location = new System.Drawing.Point(100, 10);
            pform.Controls.Add(txtBxDiv1);

            //Min10
            txtBxMin10 = new TextBox();
            txtBxMin10.Name = "txtBxMin10";
            BasicTextBoxLoad(txtBxMin10);
            txtBxMin10.Location = new System.Drawing.Point(120, 10);
            pform.Controls.Add(txtBxMin10);

            //Min01
            txtBxMin01 = new TextBox();
            txtBxMin01.Name = "txtBxMin01";
            BasicTextBoxLoad(txtBxMin01);
            txtBxMin01.Location = new System.Drawing.Point(155, 10);
            pform.Controls.Add(txtBxMin01);

            //Second : 
            txtBxDiv2 = new TextBox();
            txtBxDiv2.Name = "txtBxDiv2";
            BasicTextBoxLoad(txtBxDiv2);
            txtBxDiv2.Text = ":";
            txtBxDiv2.Size = new System.Drawing.Size(18, 58);
            txtBxDiv2.Location = new System.Drawing.Point(190, 10);
            pform.Controls.Add(txtBxDiv2);

            //Sec10
            txtBxSec10 = new TextBox();
            txtBxSec10.Name = "txtBxSec10";
            BasicTextBoxLoad(txtBxSec10);
            txtBxSec10.Location = new System.Drawing.Point(210, 10);
            pform.Controls.Add(txtBxSec10);

            //Sec01
            txtBxSec01 = new TextBox();
            txtBxSec01.Name = "txtBxSec01";
            BasicTextBoxLoad(txtBxSec01);
            txtBxSec01.Location = new System.Drawing.Point(245, 10);
            pform.Controls.Add(txtBxSec01); 
            
        }

        private void BasicTextBoxLoad(TextBox textBox)
        {
            textBox.BackColor = System.Drawing.SystemColors.Menu;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new System.Drawing.Font("Segoe UI Black", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.Margin = new System.Windows.Forms.Padding(2);
            textBox.ReadOnly = true;
            textBox.Size = new System.Drawing.Size(30, 60);
            textBox.TabStop = false;
            textBox.Text = "0"; 
        }

    }
}
