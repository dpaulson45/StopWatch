using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationUpdate; // Application Updater to allow the program to update automatically https://github.com/dpaulson45/ApplicationUpdate/releases 
using System.Reflection; 

namespace StopWatch
{
    public partial class StopWatch : Form, IApplicationUpdate
    {

        private List<StopWatchManager> StopWatches;
        private StopWatchPrimaryDisplay primaryDisplay;
        private StopWatchAdminTimer adminTimer;
        private ApplicationUpdater appUpdater;
        private BackgroundWorker bgWorker;
        private string AppName_AppID = "StopWatch";
       

        public StopWatch()
        {
            InitializeComponent();
            primaryDisplay = new StopWatchPrimaryDisplay(this);
            adminTimer = new StopWatchAdminTimer(this); 
            LoadStopWatchManager();
            LoadSavedStopWatchData();
            appUpdater = new ApplicationUpdater(this); 
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync(); 
            lblUpdate.Text = "Checking for updates...."; 
            
        }


        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (appUpdater.NewUpdate())
                lblUpdate.Text = "New Update Available";
            else
                lblUpdate.Text = " ";

        }
        
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(10000); 
        }


        private void LoadStopWatchManager()
        {
            StopWatches = new List<StopWatchManager>();
            StopWatches.Add(new StopWatchManager("StopWatch1", 100, this, new EventHandler(btnStartStop_Click), primaryDisplay));
            StopWatches.Add(new StopWatchManager("StopWatch2", 135, this, new EventHandler(btnStartStop_Click), primaryDisplay));
            StopWatches.Add(new StopWatchManager("StopWatch3", 170, this, new EventHandler(btnStartStop_Click), primaryDisplay));
            StopWatches.Add(new StopWatchManager("StopWatch4", 205, this, new EventHandler(btnStartStop_Click), primaryDisplay));
            StopWatches.Add(new StopWatchManager("StopWatch5", 240, this, new EventHandler(btnStartStop_Click), primaryDisplay));
        }

        public void btnStartStop_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            int iCount = 0; 
            //foreach stopwatch we are going to loop through 
            //to see if there is a timer enabled, if there is disabled it 
       
            foreach(StopWatchManager stopWatch in StopWatches)
            {
                if (stopWatch.stopWatchTimer.Enabled)
                {
                    if (btnSender.Name != (stopWatch.StopWatchSetName + "_StartStop"))
                    {
                        //If a timer is enabled and is not the sender we want to disable the timer and change the name of the lbl. 
                        stopWatch.stopWatchTimer.Enabled = false;
                        stopWatch.ToggleStartStopBtn();
                        stopWatch.SaveStopWatchPrimaryData();
                        stopWatch.UpdateLabelTimeString(); 
                    }
                    adminTimer.stopWatchTimer.Enabled = false;
                }
                else
                    iCount++; 
            }

            if (iCount == StopWatches.Count)
                adminTimer.stopWatchTimer.Enabled = true; 
           
        }

        public void LoadSavedStopWatchData()
        {
            foreach(StopWatchManager stopWatch in StopWatches)
            {
                stopWatch.LoadSavedData(); 
            }
        }

        public string ApplicationName
        {
            get {return AppName_AppID; }
        }

        public string ApplicationID
        {
            get { return AppName_AppID;  }
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
            get { return this;  }
        }

        public Uri ApplicationUpdaterXmlLocation
        {
            get { return new Uri("https://raw.githubusercontent.com/dpaulson45/StopWatch/UpdateFileBranch/update.xml");  }
        }
    }
}
