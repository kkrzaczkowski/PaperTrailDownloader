using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    public class PlannedTask
    {
        public PlannedTask(DateTime startTime, TimeSpan interval, Action action, string description = "")
        {
            this.StartDate = startTime;
            this.Interval = interval;
            this.Execute = action;
            this.Description = description;
        }

        public DateTime StartDate { get; set; }
        public TimeSpan Interval { get; private set; }
        public Action Execute { get; private set; }
        public string Description { get; private set; }
    }
}
