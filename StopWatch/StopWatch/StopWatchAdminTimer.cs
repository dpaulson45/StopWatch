using System;
using System.Windows.Forms; 

namespace StopWatch
{
    class StopWatchAdminTimer : StopWatchTimerClass
    {
        private TextBox txtBox;
        private TextBox txtBoxAdminTitle; 
        private Form pForm;

        private string AdminDataSave;
        private string AdminStartTimeFile; 
        

        public StopWatchAdminTimer(Form pForm, string SaveLocation)
        {
            this.pForm = pForm;
            LoadTextBox();
            AdminDataSave = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\" + SaveLocation + "\\AdminData.dat";
            AdminStartTimeFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\" + SaveLocation + "\\StopWatchStartTime.dat";
            ReadAdminStopWatchData();
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
            SaveAdminTimer();
        }

        private void UpdateAdminTimer()
        {
            txtBox.Text = GetLabelTimeString(); 
        }

        private void ReadAdminStopWatchData()
        {
            if(ResetAdminTime())
            {
                WriteAdminStartTime(); 
            }
            else
            {
                ReadAdminTime();
                UpdateAdminTimer();
            }
        }

        private void ReadAdminTime()
        {
            CheckFile(AdminDataSave);
            System.IO.TextReader myFile = new System.IO.StreamReader(AdminDataSave);
            try
            {
                sec01 = Convert.ToInt32(myFile.ReadLine());
                sec10 = Convert.ToInt32(myFile.ReadLine());
                min01 = Convert.ToInt32(myFile.ReadLine());
                min10 = Convert.ToInt32(myFile.ReadLine());
                hour01 = Convert.ToInt32(myFile.ReadLine());
                hour10 = Convert.ToInt32(myFile.ReadLine());
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myFile.Close();
            }

        }


        private void SaveAdminTimer()
        {
            System.IO.TextWriter myFile = new System.IO.StreamWriter(AdminDataSave);
            try
            {
                myFile.WriteLine(sec01);
                myFile.WriteLine(sec10);
                myFile.WriteLine(min01);
                myFile.WriteLine(min10);
                myFile.WriteLine(hour01);
                myFile.WriteLine(hour10);
            }
            finally
            {
                myFile.Close();
            }
        }

        private void CheckFile(string location)
        {
            if(!System.IO.File.Exists(location))
            {
                System.IO.FileStream fs = System.IO.File.Create(location);
                fs.Close();
            }
        }

        private void WriteAdminStartTime()
        {
            CheckFile(AdminStartTimeFile);
            System.IO.TextWriter myFile = new System.IO.StreamWriter(AdminStartTimeFile);
            try
            {
                myFile.WriteLine(Convert.ToString(DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myFile.Close(); 
            }
        }

        private bool ResetAdminTime()
        {
            bool bResult = true ; 
            DateTime currentTime = DateTime.Now;
            DateTime fileTime;
            CheckFile(AdminStartTimeFile);
            System.IO.TextReader myFile = new System.IO.StreamReader(AdminStartTimeFile);
            try
            {
                fileTime = Convert.ToDateTime(myFile.ReadLine());
                if (currentTime.Date == fileTime.Date)
                    bResult = false; 
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myFile.Close(); 
            }
            return bResult; 
        }

    }
}
