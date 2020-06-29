namespace StopWatch.Data.Models
{
    public class TimeTracker
    {
        public string TimeType { get; set; }

        public string SubGroupTimeType { get; set; }

        public string Notes { get; set; }

        public string WorkedDate { get; set; }

        public int TimeWorkedAmount { get; set; }

        public string DateTimeEntered { get; set; }
    }
}
