using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ApplicationUpdate; // Application Updater to allow the program to update automatically https://github.com/dpaulson45/ApplicationUpdate/releases
using StopWatch.Data.Models;
using StopWatch.Data.Services;
using StopWatch.UI.Models;

namespace StopWatch.UI.Views
{
    /// <summary>
    /// Main Windows Form.
    /// </summary>
    public partial class MainWindow : Form, IApplicationUpdate
    {
        private const bool DefaultDatabaseCommitOption = true;
        private const int DefaultStopWatchInstances = 5;
        private const bool DefaultIncludeMicroseconds = true;

        private const int StartingYLocation = 140;
        private const int YPadding = 35;

        private readonly List<StopWatchManager> stopWatches;
        private readonly StopWatchManager adminTimer;
        private readonly ApplicationUpdater appUpdater;
        private readonly BackgroundWorker bgWorker;
        private readonly string primarySaveDirectory;
        private readonly string xmlUserSettingsLocation;
        private readonly XmlUserSettings xmlUserSettings;

#if DEBUG
        private readonly string appNameAppID = "StopWatch-Dev";
#else
      private readonly string appNameAppID = "StopWatch";
#endif

        private UserSettings stopWatchUserSettings;
        private List<TimeTracker> weekTimeTrackers;

        public MainWindow()
        {
            InitializeComponent();
            primarySaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + appNameAppID;

            if (!System.IO.Directory.Exists(primarySaveDirectory))
            {
                System.IO.Directory.CreateDirectory(primarySaveDirectory);
            }

            xmlUserSettingsLocation = primarySaveDirectory + "\\UserSettings.xml";
            stopWatchUserSettings = new UserSettings();
            xmlUserSettings = new XmlUserSettings(
                xmlUserSettingsLocation,
                stopWatchUserSettings);

            LoadUserPreferences();

            SqliteDatabase.ReadySqliteDatabase(primarySaveDirectory, "TimeTracker.db");
            SqliteDataAccess.DefaultConnectionString = "Data Source=" + System.IO.Path.Combine(primarySaveDirectory, "TimeTracker.db");

            stopWatches = new List<StopWatchManager>();
            for (int i = 1; i <= stopWatchUserSettings.StopWatchInstances; i++)
            {
                stopWatches.Add(new StopWatchManager(
                    "StopWatch" + i,
                    primarySaveDirectory,
                    StartingYLocation + ((i - 1) * YPadding),
                    this,
                    lblMainDisplay,
                    stopWatchUserSettings.IncludeMicroseconds,
                    stopWatchUserSettings.DatabaseCommitOption,
                    BtnStartStop_Click,
                    BtnReset_Click));
            }

            adminTimer = new StopWatchManager(
                "AdminStopWatch",
                primarySaveDirectory,
                lblAdminTimer,
                stopWatchUserSettings.IncludeMicroseconds);

            string adminStartTimeLocation = primarySaveDirectory + "\\AdminStartTime.dat";
            if (!System.IO.File.Exists(adminStartTimeLocation))
            {
                System.IO.FileStream fs = System.IO.File.Create(adminStartTimeLocation);
                fs.Close();
            }

            System.IO.TextReader textReader = new System.IO.StreamReader(adminStartTimeLocation);
            try
            {
                if (DateTime.Now.Date != Convert.ToDateTime(textReader.ReadLine()).Date)
                {
                    adminTimer.StopWatch.Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                textReader.Close();
            }

            System.IO.TextWriter textWriter = new System.IO.StreamWriter(adminStartTimeLocation);
            try
            {
                textWriter.WriteLine(Convert.ToString(DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                textWriter.Close();
            }

            adminTimer.StopWatch.StartStop();

            appUpdater = new ApplicationUpdater(this);
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync();
            lblUpdate.Text = "Checking for updates....";

            LoadInitialDataFromDatabase();
            LoadStats();
        }

        public string ApplicationName
        {
            get { return appNameAppID; }
        }

        public string ApplicationID
        {
            get { return appNameAppID; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return Icon; }
        }

        public Form ApplicationForm
        {
            get { return this; }
        }

        public Uri ApplicationUpdaterXmlLocation
        {
            get { return new Uri("https://raw.githubusercontent.com/dpaulson45/StopWatch/UpdateFileBranch/update.xml"); }
        }

        public void AddAndSetDayStats()
        {
            var currentDay = System.DateTime.Now;
            var query = new List<string>();
            query.Add(
                string.Format(
                "{0}/{1}/{2}",
                currentDay.Month,
                currentDay.Day,
                currentDay.Year));

            var results = SqliteDataAccess.ReadLaborEntries(query);

            foreach (var result in results)
            {
                var foundItem = false;

                foreach (var timeTrackerItem in weekTimeTrackers)
                {
                    if (timeTrackerItem.DateTimeEntered == result.DateTimeEntered &&
                        timeTrackerItem.TimeWorkedAmount == result.TimeWorkedAmount &&
                        timeTrackerItem.SubGroupTimeType == result.SubGroupTimeType)
                    {
                        foundItem = true;
                        break;
                    }
                }

                if (!foundItem)
                {
                    if (result.TimeType == "Case")
                    {
                        LaborTracker.UtilizedDayLabor += result.TimeWorkedAmount;
                        LaborTracker.UtilizedWeekLabor += result.TimeWorkedAmount;
                    }

                    LaborTracker.TotalDayLabor += result.TimeWorkedAmount;
                    LaborTracker.TotalWeekLabor += result.TimeWorkedAmount;

                    weekTimeTrackers.Add(result);
                }
            }

            LoadStats();
        }

        protected void BtnStartStop_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;

            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if (stopWatch.StopWatch.DisplayUpdateTimer.Enabled)
                {
                    // This is for when a user selects a Start/Stop button that isn't currently active.
                    if (btnSender.Name != (stopWatch.StopWatchSetName + "_Start"))
                    {
                        stopWatch.StopWatch.StartStop();
                        stopWatch.SetStartButton();
                    }
                }
            }

            StartStopAdminTimer();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            bool timerIsRunning = false;
            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if (stopWatch.StopWatch.DisplayUpdateTimer.Enabled)
                {
                    timerIsRunning = true;
                    break;
                }
            }

            if (!timerIsRunning)
            {
                lblMainDisplay.Text = "00:00:00";
            }
        }

        private void LoadUserPreferences()
        {
            if (!System.IO.File.Exists(xmlUserSettingsLocation))
            {
                stopWatchUserSettings.DatabaseCommitOption = DefaultDatabaseCommitOption;
                stopWatchUserSettings.IncludeMicroseconds = DefaultIncludeMicroseconds;
                stopWatchUserSettings.StopWatchInstances = DefaultStopWatchInstances;
                SaveUserPreferences();
            }
            else
            {
                stopWatchUserSettings = xmlUserSettings.ReadFromFile() as UserSettings;
            }
        }

        private void SaveUserPreferences()
        {
            xmlUserSettings.SaveToFile(stopWatchUserSettings);
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (appUpdater.NewUpdate())
            {
                lblUpdate.Text = "New Update Available";
            }
            else
            {
                lblUpdate.Text = " ";
            }
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(10000);
        }

        private void DownloadUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appUpdater.DoUpdate();
        }

        private void ToggleAdminEnabledWording(bool enabled)
        {
            if (enabled)
            {
                enableTimerToolStripMenuItem.Text = "Disable Timer";
            }
            else
            {
                enableTimerToolStripMenuItem.Text = "Enable Timer";
            }
        }

        private void StartStopAdminTimer()
        {
            bool stopWatchInstanceRunning = false;
            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if (stopWatch.StopWatch.DisplayUpdateTimer.Enabled)
                {
                    stopWatchInstanceRunning = true;
                    break;
                }
            }

            if (stopWatchInstanceRunning)
            {
                if (adminTimer.StopWatch.DisplayUpdateTimer.Enabled)
                {
                    adminTimer.StopWatch.StartStop();
                }
            }
            else
            {
                if (!adminTimer.StopWatch.DisplayUpdateTimer.Enabled)
                {
                    adminTimer.StopWatch.StartStop();
                }
            }

            ToggleAdminEnabledWording(true);
        }

        private void EnableTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool stopWatchInstanceRunning = false;
            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if (stopWatch.StopWatch.DisplayUpdateTimer.Enabled)
                {
                    stopWatchInstanceRunning = true;
                    break;
                }
            }

            if (!stopWatchInstanceRunning)
            {
                ToggleAdminEnabledWording(!adminTimer.StopWatch.DisplayUpdateTimer.Enabled);
                adminTimer.StopWatch.StartStop();
            }
            else
            {
                ToggleAdminEnabledWording(true);
            }
        }

        private void ResetTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adminTimer.StopWatch.DisplayUpdateTimer.Enabled)
            {
                adminTimer.StopWatch.Restart();
            }
            else
            {
                adminTimer.StopWatch.Reset();
                lblAdminTimer.Text = adminTimer.StopWatch.GetTime;
            }
        }

        private void CommitAdminTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertForm insertForm = new InsertForm(
                primarySaveDirectory,
                adminTimer.StopWatch.GetTotalMinutes);
            if (insertForm.ShowDialog() == DialogResult.OK)
            {
                adminTimer.StopWatch.Restart();
                AddAndSetDayStats();
            }
        }

        private void LoadInitialDataFromDatabase()
        {
            weekTimeTrackers = new List<TimeTracker>();
            var currentDate = System.DateTime.Now;
            var currentDay = string.Format("{0}/{1}/{2}", currentDate.Month, currentDate.Day, currentDate.Year);
            var queryDates = new List<string>();

            for (int day = 0; day <= (int)currentDate.DayOfWeek; day++)
            {
                var date = System.DateTime.Now.AddDays(-((int)currentDate.DayOfWeek - day));
                var value = string.Format("{0}/{1}/{2}", date.Month, date.Day, date.Year);
                queryDates.Add(value);
            }

            var results = SqliteDataAccess.ReadLaborEntries(queryDates);

            foreach (var entry in results)
            {
                if (entry.WorkedDate == currentDay)
                {
                    LaborTracker.TotalDayLabor += entry.TimeWorkedAmount;

                    if (entry.TimeType == "Case")
                    {
                        LaborTracker.UtilizedDayLabor += entry.TimeWorkedAmount;
                    }
                }

                if (entry.TimeType == "Case")
                {
                    LaborTracker.UtilizedWeekLabor += entry.TimeWorkedAmount;
                }

                LaborTracker.TotalWeekLabor += entry.TimeWorkedAmount;
                weekTimeTrackers.Add(entry);
            }
        }

        private void LoadStats()
        {
            lblDayTotal.Text = Math.Round(LaborTracker.TotalDayLabor / 60, 2).ToString();
            lblDayUtilized.Text = Math.Round(LaborTracker.UtilizedDayLabor / 60, 2).ToString();
            lblWeekTotal.Text = Math.Round(LaborTracker.TotalWeekLabor / 60, 2).ToString();
            lblWeekUtilized.Text = Math.Round(LaborTracker.UtilizedWeekLabor / 60, 2).ToString();
        }

        private void StopWatchInstancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void TimeDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
