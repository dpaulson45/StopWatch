using System;
using System.Windows.Forms;

namespace StopWatch
{
    class StopWatchTimerClass
    {
        public int sec01, sec10, min01, min10, hour01, hour10;
        public Timer stopWatchTimer;
        public System.DateTime EnabledTime;

        internal void TimerStartStop()
        {
            if(!stopWatchTimer.Enabled)
            {
                stopWatchTimer.Enabled = true;
                EnabledTime = System.DateTime.Now; 
            }
            else
            {
                stopWatchTimer.Enabled = false; 
            }
        }

        internal string GetLabelTimeString()
        {
            return Convert.ToString(hour10 + hour01 + "hrs " + min10 + min01 + "mins " + sec10 + sec01 + "secs");
        }

        internal virtual void ResetTime()
        {
            sec01 = 0;
            sec10 = 0;
            min01 = 0;
            min10 = 0;
            hour01 = 0;
            hour10 = 0;   
        }

        protected virtual void IncreaseTimers(object s, EventArgs e)
        {
            sec01++; 

            if(sec01 == 10 &&
                sec10 != 5)
            {
                sec10++;
                sec01 = 0; 
            }
            else if(sec01 == 10 &&
                sec10 == 5)
            {
                min01++;
                sec01 = 0;
                sec10 = 0; 
            }
            if(min01 == 10 &&
                min10 != 5)
            {
                min10++;
                min01 = 0; 
            }
            if(min01 == 10 &&
                min10 == 5)
            {
                hour01++;
                min01 = 0;
                min10 = 0; 
            }
            if(hour01 == 10)
            {
                hour10++;
                hour01 = 0; 
            }

        }

    }
}
