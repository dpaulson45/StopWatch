using System;
using System.Windows.Forms;
using StopWatchTime;

namespace StopWatch
{
    class StopWatchManager  
    {
        public string stopWatchSetName;

        public StopWatchTimer stopWatch;

        private Button btnStartStop;
        private Button btnReset;
        private Button btnCommit;
        private Label lblCurrentTime;
        private TextBox tbQuickNotes;
        private Form mainForm;
        private Label lblPrimaryDisplay;

        private int location_Y;
        private int location_X = 10;
        private const int btnWidth = 45;
        private const int btnHeight = 20; 

        internal StopWatchManager(string StopWatchSetName, 
            string SaveDirectoryPath,
            int StartingYLocation,
            Form form, 
            Label primaryDisplay,
            EventHandler StartStopClickEvents,
            EventHandler ResetClickEvents)
        {
            stopWatchSetName = StopWatchSetName;
            stopWatch = new StopWatchTimer(SaveDirectoryPath +
                "\\" +
                StopWatchSetName +
                ".dat");
            location_Y = StartingYLocation;
            mainForm = form;
            lblPrimaryDisplay = primaryDisplay;
            LoadFormInfo(StartStopClickEvents, ResetClickEvents);
            stopWatch.displayUpdateTimer.Tick += new EventHandler(TimerTickIncrease);
            UpdateCurrentTimeLabel();
        }

        internal StopWatchManager(string StopWatchSetName,
            string SaveDirectoryPath,
            Label displayLabel)
        {
            stopWatchSetName = StopWatchSetName;
            stopWatch = new StopWatchTimer(SaveDirectoryPath +
                "\\" +
                StopWatchSetName +
                ".dat");
            lblCurrentTime = displayLabel;
            stopWatch.displayUpdateTimer.Tick += new EventHandler(TimerTickIncreaseNoMainDisplay);
        }

        private Button CreateButtonBasics(string name, int location_X_Padding)
        {
            Button btn = new Button();
            btn.Name = stopWatchSetName + "_" + name;
            btn.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btn.Margin = new Padding(2, 2, 2, 2);
            btn.Text = name;
            btn.UseVisualStyleBackColor = true;
            btn.Location = new System.Drawing.Point(location_X + location_X_Padding, location_Y);

            return btn;
        }

        private void LoadFormInfo(EventHandler StartStopClickEvents, EventHandler ResetClickEvents)
        {
            //Quick Notes
            tbQuickNotes = new TextBox();
            tbQuickNotes.Name = stopWatchSetName + "_TextBox";
            tbQuickNotes.Size = new System.Drawing.Size(211, 20);
            tbQuickNotes.Margin = new Padding(2, 2, 2, 2);
            tbQuickNotes.Location = new System.Drawing.Point(location_X, location_Y);
            tbQuickNotes.TextChanged += new EventHandler(tbQuickNotes_TextChange);
            mainForm.Controls.Add(tbQuickNotes);

            //Button Start Stop 
            btnStartStop = CreateButtonBasics("Start", 230);
            btnStartStop.Click += new EventHandler(btnStartStop_Click);
            btnStartStop.Click += StartStopClickEvents;
            mainForm.Controls.Add(btnStartStop);

            //Button Reset 
            btnReset = CreateButtonBasics("Reset", 280);
            btnReset.Click += new EventHandler(btnReset_Click);
            btnReset.Click += ResetClickEvents;
            mainForm.Controls.Add(btnReset);

            //Button Commit
            btnCommit = CreateButtonBasics("Commit", 330);
            btnCommit.Click += new EventHandler(btnCommit_Click);
            mainForm.Controls.Add(btnCommit);

            //Label Current Time
            lblCurrentTime = new Label();
            lblCurrentTime.Name = stopWatchSetName + "_Label";
            lblCurrentTime.Text = "0:0:0:0";
            lblCurrentTime.Size = new System.Drawing.Size(135, 14);
            lblCurrentTime.Margin = new Padding(2, 0, 2, 0);
            lblCurrentTime.Location = new System.Drawing.Point(location_X + 400, location_Y + 5);
            mainForm.Controls.Add(lblCurrentTime);

        }

        protected void TimerTickIncreaseNoMainDisplay(object s, EventArgs e)
        {
            UpdateCurrentTimeLabel();
            stopWatch.SaveStopWatchData();
        }


        // Event Handlers 
        protected void TimerTickIncrease(object s, EventArgs e)
        {
            UpdateMainDisplay();
            UpdateCurrentTimeLabel();
            stopWatch.SaveStopWatchData(); //Don't like this in the quick update view
        }
        private void tbQuickNotes_TextChange(object s, EventArgs e)
        {

        }

        private void btnReset_Click(object s, EventArgs e)
        {
            if (stopWatch.displayUpdateTimer.Enabled)
            {
                stopWatch.Restart();
            }
            else
            {
                stopWatch.Reset();
                UpdateCurrentTimeLabel();
            }
            stopWatch.SaveStopWatchData();
        }

        private void btnStartStop_Click(object s, EventArgs e)
        {
            if (!stopWatch.displayUpdateTimer.Enabled)
                btnStartStop.Text = "Stop";
            else
                btnStartStop.Text = "Start";
            stopWatch.StartStop();
            stopWatch.SaveStopWatchData();
            UpdateCurrentTimeLabel();
            UpdateMainDisplay();
        }

        private void btnCommit_Click(object s, EventArgs e)
        {
            //InsertForm test = new InsertForm(tbQuickNotes.Text, stopWatch.GetTotalMinutes);
            //test.Show();
        }

        //Class Methods 
        private void UpdateMainDisplay()
        {
            lblPrimaryDisplay.Text = stopWatch.GetTime;
        }

        private void UpdateCurrentTimeLabel()
        {
            lblCurrentTime.Text = stopWatch.GetTime;
        }

        public void SetStartButton()
        {
            btnStartStop.Text = "Start";
        }

    }
}
