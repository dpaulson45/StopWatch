namespace StopWatch.Data.Models
{
    public class UserSettings
    {
        public bool DatabaseCommitOption { get; set; }

        public int StopWatchInstances { get; set; }

        public bool IncludeMicroseconds { get; set; }
    }
}
