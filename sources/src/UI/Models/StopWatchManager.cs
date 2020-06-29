using System;
using System.IO;
using System.Windows.Forms;
using StopWatch.Data.Models;
using StopWatch.UI.Views;

namespace StopWatch.UI.Models
{
    public class StopWatchManager
    {
        private const int BtnWidth = 45;
        private const int BtnHeight = 20;

        private readonly string stopWatchSetName;

        private readonly StopWatchTimer stopWatch;

        private readonly Form mainForm;
        private readonly Label lblPrimaryDisplay;
        private readonly string tbSaveLocation;
        private readonly string saveDirectoryPath;
        private readonly bool databaseCommitOption;

        private readonly int locationY;
        private readonly int locationX = 10;

        private Button btnStartStop;
        private Button btnReset;
        private Button btnCommit;
        private Label lblCurrentTime;
        private TextBox tbQuickNotes;

        private bool initialSave = true;

        internal StopWatchManager(
            string stopWatchSetName,
            string saveDirectoryPath,
            int startingYLocation,
            Form form,
            Label primaryDisplay,
            bool includeMicroseconds,
            bool databaseCommitOption,
            EventHandler startStopClickEvents,
            EventHandler resetClickEvents)
        {
            this.stopWatchSetName = stopWatchSetName;
            this.databaseCommitOption = databaseCommitOption;
            this.saveDirectoryPath = saveDirectoryPath;
            stopWatch = new StopWatchTimer(
                saveDirectoryPath +
                "\\" +
                stopWatchSetName +
                ".dat",
                includeMicroseconds);
            locationY = startingYLocation;
            mainForm = form;
            lblPrimaryDisplay = primaryDisplay;
            tbSaveLocation = saveDirectoryPath + "\\" + StopWatchSetName + "_QuickNotes.dat";
            LoadFormInfo(startStopClickEvents, resetClickEvents);
            StopWatch.DisplayUpdateTimer.Tick += new EventHandler(TimerTickIncrease);
            UpdateCurrentTimeLabel();
        }

        internal StopWatchManager(
            string stopWatchSetName,
            string saveDirectoryPath,
            Label displayLabel,
            bool includeMicroseconds)
        {
            this.stopWatchSetName = stopWatchSetName;
            stopWatch = new StopWatchTimer(
                saveDirectoryPath +
                "\\" +
                StopWatchSetName +
                ".dat",
                includeMicroseconds);
            lblCurrentTime = displayLabel;
            StopWatch.DisplayUpdateTimer.Tick += new EventHandler(TimerTickIncreaseNoMainDisplay);
        }

        public StopWatchTimer StopWatch
        {
            get
            {
                return stopWatch;
            }
        }

        public string StopWatchSetName
        {
            get
            {
                return stopWatchSetName;
            }
        }

        public void SetStartButton()
        {
            btnStartStop.Text = "Start";
        }

        protected void TimerTickIncreaseNoMainDisplay(object s, EventArgs e)
        {
            UpdateCurrentTimeLabel();
            StopWatch.SaveStopWatchData();
        }

        // Event Handlers
        protected void TimerTickIncrease(object s, EventArgs e)
        {
            UpdateMainDisplay();
            UpdateCurrentTimeLabel();
            StopWatch.SaveStopWatchData(); // Don't like this in the quick update view
        }

        private Button CreateButtonBasics(string name, int location_X_Padding, int widthPadding = 0)
        {
            Button btn = new Button();
            btn.Name = StopWatchSetName + "_" + name;
            btn.Size = new System.Drawing.Size(BtnWidth + widthPadding, BtnHeight);
            btn.Margin = new Padding(2, 2, 2, 2);
            btn.Text = name;
            btn.UseVisualStyleBackColor = true;
            btn.Location = new System.Drawing.Point(locationX + location_X_Padding, locationY);

            return btn;
        }

        private void LoadFormInfo(EventHandler startStopClickEvents, EventHandler resetClickEvents)
        {
            // Quick Notes
            tbQuickNotes = new TextBox();
            tbQuickNotes.Name = StopWatchSetName + "_TextBox";
            tbQuickNotes.Size = new System.Drawing.Size(211, 20);
            tbQuickNotes.Margin = new Padding(2, 2, 2, 2);
            tbQuickNotes.Location = new System.Drawing.Point(locationX, locationY);
            tbQuickNotes.TextChanged += new EventHandler(TbQuickNotes_TextChange);
            mainForm.Controls.Add(tbQuickNotes);

            if (!File.Exists(tbSaveLocation))
            {
                try
                {
                    FileStream fileStream = File.Create(tbSaveLocation);
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            ReadQuickNotes();

            // Button Start Stop
            btnStartStop = CreateButtonBasics("Start", 230);
            btnStartStop.Click += new EventHandler(BtnStartStop_Click);
            btnStartStop.Click += startStopClickEvents;
            mainForm.Controls.Add(btnStartStop);

            // Button Reset
            btnReset = CreateButtonBasics("Reset", 280);
            btnReset.Click += new EventHandler(BtnReset_Click);
            btnReset.Click += resetClickEvents;
            mainForm.Controls.Add(btnReset);

            if (databaseCommitOption)
            {
                // Button Commit
                btnCommit = CreateButtonBasics("Commit", 330, 4);
                btnCommit.Click += new EventHandler(BtnCommit_Click);
                mainForm.Controls.Add(btnCommit);
            }

            // Label Current Time
            lblCurrentTime = new Label();
            lblCurrentTime.Name = StopWatchSetName + "_Label";
            lblCurrentTime.Text = "0:0:0:0";
            lblCurrentTime.Size = new System.Drawing.Size(135, 14);
            lblCurrentTime.Margin = new Padding(2, 0, 2, 0);
            lblCurrentTime.Location = new System.Drawing.Point(locationX + 400, locationY + 5);
            mainForm.Controls.Add(lblCurrentTime);
        }

        private void ReadQuickNotes()
        {
            TextReader textReader = new StreamReader(tbSaveLocation);
            try
            {
                tbQuickNotes.Text = textReader.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                textReader.Close();
                initialSave = false;
            }
        }

        private void ResetTimerAndNotes()
        {
            if (StopWatch.DisplayUpdateTimer.Enabled)
            {
                StopWatch.Restart();
            }
            else
            {
                StopWatch.Reset();
                UpdateCurrentTimeLabel();
            }

            tbQuickNotes.Text = string.Empty;
            StopWatch.SaveStopWatchData();
        }

        private void TbQuickNotes_TextChange(object s, EventArgs e)
        {
            if (initialSave)
            {
                return;
            }

            TextWriter textWriter = new StreamWriter(tbSaveLocation);
            try
            {
                textWriter.WriteLine(tbQuickNotes.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                textWriter.Close();
            }
        }

        private void BtnReset_Click(object s, EventArgs e)
        {
            ResetTimerAndNotes();
        }

        private void BtnStartStop_Click(object s, EventArgs e)
        {
            if (!StopWatch.DisplayUpdateTimer.Enabled)
            {
                btnStartStop.Text = "Stop";
            }
            else
            {
                btnStartStop.Text = "Start";
            }

            StopWatch.StartStop();
            StopWatch.SaveStopWatchData();
            UpdateCurrentTimeLabel();
            UpdateMainDisplay();
        }

        private void BtnCommit_Click(object s, EventArgs e)
        {
            InsertForm insertForm = new InsertForm(
                saveDirectoryPath,
                StopWatch.GetTotalMinutes,
                tbQuickNotes.Text);
            if (insertForm.ShowDialog() == DialogResult.OK)
            {
                ResetTimerAndNotes();
            }
        }

        // Class Methods
        private void UpdateMainDisplay()
        {
            lblPrimaryDisplay.Text = StopWatch.GetTime;
        }

        private void UpdateCurrentTimeLabel()
        {
            lblCurrentTime.Text = StopWatch.GetTime;
        }
    }
}
