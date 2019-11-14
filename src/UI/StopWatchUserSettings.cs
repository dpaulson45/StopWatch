using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    public class StopWatchUserSettings
    {
        public bool DatabaseCommitOption { get; set; }

        public int StopWatchInstances { get; set; }

        public bool IncludeMicroseconds { get; set; }
    }

}
