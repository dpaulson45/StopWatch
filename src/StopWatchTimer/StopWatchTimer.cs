using System;
using System.Diagnostics;
using System.Windows.Forms; 

namespace StopWatchTime
{
    public class StopWatchTimer
    {
        public Timer displayUpdateTimer;
        private Stopwatch stopWatch;
        private TimeSpan loadedTimeSpan;
        private string primarySaveLocation; 

        public string GetTime
        {
            get
            {
                return (Convert.ToString(stopWatch.Elapsed.Add(loadedTimeSpan)));
            }
        }

        public int GetTotalMinutes
        {
            get
            {
                TimeSpan timeSpan = stopWatch.Elapsed.Add(loadedTimeSpan);
                int minutes = (Convert.ToInt32(timeSpan.TotalMinutes));
                if(timeSpan.Seconds != 0)
                    minutes++;
                return minutes;
            }
        }

        public StopWatchTimer(string SaveFullPath)
        {
            displayUpdateTimer = new Timer();
            stopWatch = new Stopwatch();
            primarySaveLocation = SaveFullPath;

            displayUpdateTimer.Interval = 100; 

            if(!System.IO.File.Exists(primarySaveLocation))
            {
                try
                {
                    System.IO.FileStream fileStream = System.IO.File.Create(primarySaveLocation);
                    fileStream.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            ReadStopWatchData();
        }

        private void ReadStopWatchData()
        {
            string readLine;
            System.IO.TextReader myFile = new System.IO.StreamReader(primarySaveLocation);
            try
            {
                readLine = myFile.ReadLine();
                if(readLine != null)
                {
                    string[] splitRead = readLine.Split(':');
                    loadedTimeSpan = new TimeSpan(Convert.ToInt32(splitRead[0]),
                        Convert.ToInt32(splitRead[1]),
                        Convert.ToInt32((Convert.ToDouble(splitRead[2]))));
                }
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

        public void Restart()
        {
            stopWatch.Restart();
            loadedTimeSpan = new TimeSpan();
        }

        public void Reset()
        {
            stopWatch.Reset();
            loadedTimeSpan = new TimeSpan();
        }

        public void StartStop()
        {
            if(!displayUpdateTimer.Enabled ||
                !stopWatch.IsRunning)
            {
                displayUpdateTimer.Enabled = true;
                stopWatch.Start();
            }
            else
            {
                displayUpdateTimer.Enabled = false;
                stopWatch.Stop();
            }
        }

        public void SaveStopWatchData()
        {
            System.IO.TextWriter myFile = new System.IO.StreamWriter(primarySaveLocation);
            try
            {
                myFile.WriteLine(GetTime);
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

    }
}
