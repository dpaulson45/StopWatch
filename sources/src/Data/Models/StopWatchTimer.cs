using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StopWatch.Data.Models
{
    public class StopWatchTimer
    {
#pragma warning disable SA1401 // Fields should be private
        public Timer DisplayUpdateTimer;
#pragma warning restore SA1401 // Fields should be private

        private readonly Stopwatch stopWatch;
        private readonly string primarySaveLocation;
        private readonly bool includeMicroseconds;

        private TimeSpan loadedTimeSpan;

        public StopWatchTimer(
            string saveFullPath,
            bool includeMicroseconds)
        {
            this.includeMicroseconds = includeMicroseconds;
            DisplayUpdateTimer = new Timer();
            stopWatch = new Stopwatch();
            primarySaveLocation = saveFullPath;

            DisplayUpdateTimer.Interval = 100;

            if (!System.IO.File.Exists(primarySaveLocation))
            {
                try
                {
                    System.IO.FileStream fileStream = System.IO.File.Create(primarySaveLocation);
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            ReadStopWatchData();
        }

        public string GetTime
        {
            get
            {
                return includeMicroseconds ?
                    Convert.ToString(stopWatch.Elapsed.Add(loadedTimeSpan)) :
                    Convert.ToString(stopWatch.Elapsed.Add(loadedTimeSpan)).Split('.')[0];
            }
        }

        public int GetTotalMinutes
        {
            get
            {
                TimeSpan timeSpan = stopWatch.Elapsed.Add(loadedTimeSpan);
                int minutes = Convert.ToInt32(timeSpan.TotalMinutes);
                if (timeSpan.Seconds != 0)
                {
                    minutes++;
                }

                return minutes;
            }
        }

        public void Restart()
        {
            stopWatch.Restart();
            loadedTimeSpan = default;
        }

        public void Reset()
        {
            stopWatch.Reset();
            loadedTimeSpan = default;
        }

        public void StartStop()
        {
            if (!DisplayUpdateTimer.Enabled ||
                !stopWatch.IsRunning)
            {
                DisplayUpdateTimer.Enabled = true;
                stopWatch.Start();
            }
            else
            {
                DisplayUpdateTimer.Enabled = false;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                myFile.Close();
            }
        }

        private void ReadStopWatchData()
        {
            string readLine;
            System.IO.TextReader myFile = new System.IO.StreamReader(primarySaveLocation);
            try
            {
                readLine = myFile.ReadLine();
                if (readLine != null)
                {
                    string[] splitRead = readLine.Split(':');
                    loadedTimeSpan = new TimeSpan(
                        Convert.ToInt32(splitRead[0]),
                        Convert.ToInt32(splitRead[1]),
                        Convert.ToInt32(Convert.ToDouble(splitRead[2])));
                }
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
    }
}
