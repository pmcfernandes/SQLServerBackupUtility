using System.Collections.Generic;

namespace SQLServerBackupUtility.Helpers
{
    public class AppState
    {
        public string ConnectionString
        {
            get;
            set;
        } = "";

        public string BackupFolder
        {
            get;
            set;
        } = "";

        public List<string> SelectedDatabases { 
            get; 
            set;
        } = new List<string>();

        public ScheduleEntry Schedule
        {
            get;
            set;
        } = new ScheduleEntry();
    }
}