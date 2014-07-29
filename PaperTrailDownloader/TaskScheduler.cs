using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    public class TaskScheduler
    {
        private DateTime startTime;
        //private TimeSpan timePeriod = new TimeSpan(7, 0, 0, 0);
        private TimeSpan timePeriod = new TimeSpan(0, 0, 0, 20);

        public TaskScheduler(DateTime startTime)
        {
            this.startTime = startTime;
        }

        public void Activate()
        {
            this.ScheduleTask();
        }

        public void Run()
        {
            this.ScheduleTask();
            Console.WriteLine("Bogdan: " + DateTime.Now.ToString());
            // TO DO: Add sending request to server and saving
        }

        private void ScheduleTask()
        {
            TimeSpan ts;
            var now = DateTime.Now;
            if (this.startTime > now)
                ts = this.startTime - now;
            else
            {
                this.startTime = this.startTime.Add(timePeriod);
                ts = this.startTime - now;
            }

            //waits certan time and run the code
            Task.Delay(ts).ContinueWith((x) => Run());
        }
    }
}
