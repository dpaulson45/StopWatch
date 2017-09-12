using System;
using System.Windows.Forms; 

namespace StopWatch
{
    class StopWatchManager : StopWatchTimerClass 
    {
        public string StopWatchSetName;
        private Button btnStartStop;
        private Button btnReset;
        private Label lbl;
        private TextBox txtBox;
        

        private int Location_Y;
        private int Location_X = 10;

        private const int btnWidth = 45;
        private const int btnHeight = 20; 

        private Form pform;

        private string PrimarySaveLocation, SecondarySaveLocation;

        private EventHandler buttonClicks;
        private StopWatchPrimaryDisplay primaryDisplay;

        private bool LoadingFiles = true; 

        internal StopWatchManager(string StopWatchSetName, 
            int StartingYLocation, 
            Form pform, 
            EventHandler buttonClicks, 
            StopWatchPrimaryDisplay primaryDisplay)
        {
            this.StopWatchSetName = StopWatchSetName;
            Location_Y = StartingYLocation;
            this.pform = pform;
            this.primaryDisplay = primaryDisplay; 
            PrimarySaveLocation = StopWatchSetName + "_Primary.dat";
            SecondarySaveLocation = StopWatchSetName + "_Backup.dat";
            this.buttonClicks = buttonClicks; 
            LoadButton(); 
        }

        public void SaveStopWatchPrimaryData()
        {
            SaveStopWatchData(PrimarySaveLocation);
            SaveStopWatchData(SecondarySaveLocation); 
        }

        private void ReadStopWatchData(string location, out bool bResults)
        {
            bResults = true; 
            System.IO.TextReader myFile = new System.IO.StreamReader(location);

            try
            {
                sec01 = Convert.ToInt32(myFile.ReadLine());
                sec10 = Convert.ToInt32(myFile.ReadLine());
                min01 = Convert.ToInt32(myFile.ReadLine());
                min10 = Convert.ToInt32(myFile.ReadLine());
                hour01 = Convert.ToInt32(myFile.ReadLine());
                hour10 = Convert.ToInt32(myFile.ReadLine());
                txtBox.Text = myFile.ReadLine();

            }

            catch (Exception ex)
            {
                bResults = false;  
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {
                myFile.Close();
            }

        }

        private void SaveStopWatchData(string location)
        {
            System.IO.TextWriter myFile = new System.IO.StreamWriter(location);

            try
            {
                myFile.WriteLine(sec01);
                myFile.WriteLine(sec10);
                myFile.WriteLine(min01);
                myFile.WriteLine(min10);
                myFile.WriteLine(hour01);
                myFile.WriteLine(hour10);
                myFile.WriteLine(txtBox.Text); 
            }

            finally
            {
                myFile.Close(); 
            }
        }

        public void LoadSavedData()
        {
            //First check the data files 
            CheckForDataFiles();
            ReadStopWatchData(PrimarySaveLocation, out bool pSuccess);
            if(!pSuccess)
            {
                ReadStopWatchData(SecondarySaveLocation, out pSuccess); 
            }
            UpdateLabelTimeString();
            LoadingFiles = false; 
        }


        private void CheckForDataFiles()
        {
            //Need to move the data files to the AppData location in order to avoid permissions issues. https://stackoverflow.com/questions/915210/how-can-i-get-the-path-of-the-current-users-application-data-folder
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\StopWatch";
            //Check to see if the directory is there and if we need to create it. 
            if(!System.IO.Directory.Exists(appDataDirectory))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(appDataDirectory);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
            //Update the Save Locations
            PrimarySaveLocation = appDataDirectory + "\\" + PrimarySaveLocation;
            SecondarySaveLocation = appDataDirectory + "\\" + SecondarySaveLocation; 
            CheckForDataFiles(PrimarySaveLocation);
            CheckForDataFiles(SecondarySaveLocation); 
        }

        private void CheckForDataFiles(string checkLocation)
        {
            if(!System.IO.File.Exists(checkLocation))
            {
                System.IO.FileStream fs = System.IO.File.Create(checkLocation);
                fs.Close(); 
            }
        }

        internal override void ResetTime()
        {
            base.ResetTime();
            txtBox.Text = "";
            UpdateLabelTimeString();
        }

        public void UpdateLabelTimeString()
        {
            lbl.Text = GetLabelTimeString(); 
        }

        private void LoadButton()
        {
            //TextBox 
            txtBox = new TextBox();
            txtBox.Name = StopWatchSetName + "_TextBox";
            txtBox.Size = new System.Drawing.Size(211, 20);
            txtBox.Margin = new Padding(2, 2, 2, 2);
            txtBox.Location = new System.Drawing.Point(Location_X, Location_Y);
            txtBox.TextChanged += new EventHandler(txtBox_TextChanged);
            pform.Controls.Add(txtBox); 

            //Button Start Stop 
            btnStartStop = new Button();
            btnStartStop.Name = StopWatchSetName + "_StartStop";
            btnStartStop.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btnStartStop.Margin = new Padding(2, 2, 2, 2);
            btnStartStop.Text = "Start";
            btnStartStop.Click += new EventHandler(btnStartStop_Click);
            btnStartStop.Click += buttonClicks;
            
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Location = new System.Drawing.Point(Location_X + 225, Location_Y);
            pform.Controls.Add(btnStartStop); 

            //Button Reset 
            btnReset = new Button();
            btnReset.Name = StopWatchSetName + "_Reset";
            btnReset.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btnReset.Margin = new Padding(2, 2, 2, 2);
            btnReset.Text = "Reset";
            btnReset.Click += new EventHandler(btnReset_Click); 
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Location = new System.Drawing.Point(Location_X + 280, Location_Y);
            pform.Controls.Add(btnReset);

            //Label 
            lbl = new Label();
            lbl.Name = StopWatchSetName + "_Label";
            lbl.Text = "0:0:0:0"; 
            lbl.Size = new System.Drawing.Size(135, 14);
            lbl.Margin = new Padding(2, 0, 2, 0);
            lbl.Location = new System.Drawing.Point(Location_X + 330, Location_Y);
            pform.Controls.Add(lbl);

            

            //Construct a timer
            stopWatchTimer = new Timer();
            stopWatchTimer.Interval = 1000;
            stopWatchTimer.Enabled = false;
            stopWatchTimer.Tick += new System.EventHandler(IncreaseTimers);

        }

        protected override void IncreaseTimers(object s, EventArgs e)
        {
            base.IncreaseTimers(s, e);
            UpdateMainDisplay();
            SaveStopWatchData(PrimarySaveLocation); 
            
        }


        private void btnStartStop_Click(object s, EventArgs e)
        {
            UpdateMainDisplay();
            //If it is enabled, start them
            if(!stopWatchTimer.Enabled)
                btnStartStop.Text = "Stop";
            else
                btnStartStop.Text = "Start";
            TimerStartStop();
            UpdateLabelTimeString(); 
        }

        public void ToggleStartStopBtn()
        {
            if (btnStartStop.Text == "Start")
                btnStartStop.Text = "Stop";
            else
                btnStartStop.Text = "Start"; 
        }

        private void btnReset_Click(object s, EventArgs e)
        {
            ResetTime();
            UpdateMainDisplay(); 
        }

        private void txtBox_TextChanged(object s, EventArgs e)
        {
            if (!stopWatchTimer.Enabled && !LoadingFiles)
            {
                SaveStopWatchData(PrimarySaveLocation);
                SaveStopWatchData(SecondarySaveLocation);
            }
        }

        private void UpdateMainDisplay()
        {
            primaryDisplay.txtBxHour10.Text = Convert.ToString(hour10);
            primaryDisplay.txtBxHour01.Text = Convert.ToString(hour01);
            primaryDisplay.txtBxMin10.Text = Convert.ToString(min10);
            primaryDisplay.txtBxMin01.Text = Convert.ToString(min01);
            primaryDisplay.txtBxSec10.Text = Convert.ToString(sec10);
            primaryDisplay.txtBxSec01.Text = Convert.ToString(sec01); 

        }

    }
}
