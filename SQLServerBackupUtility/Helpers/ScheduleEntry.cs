using System;

namespace SQLServerBackupUtility.Helpers
{
    public class ScheduleEntry
    {
        public string Name 
        { 
            get;
            set;
        } = "";

        public DateTime StartDateTime
        {
            get;
            set;
        }

        public string Recurrence
        {
            get;
            set;
        } = "";

        public int Interval
        {
            get;
            set;
        }

        public string DaysOfWeek
        {
            get;
            set;
        } = "";

        public int DayOfMonth
        {
            get;
            set;
        }

        public bool RunAsCurrentUser
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        } = "";

        public string Password
        {
            get;
            set;
        } = "";

        public DateTime? LastRun { get; set; }
    }
}
