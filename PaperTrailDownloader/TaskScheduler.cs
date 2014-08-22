using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    /// <summary>
    /// A TaskScheduler class is a singleton class handling the execute process.
    /// </summary>
    public class TaskScheduler
    {
        #region Singleton Stuff

        private static readonly TaskScheduler instance = new TaskScheduler();

        /// <summary>
        /// The singleton task scheduler instance to used by consumer applications
        /// </summary>
        public static TaskScheduler Instance
        {
            get { return instance; }
        }

        private TaskScheduler()
        { }

        #endregion

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Public methods

        /// <summary>
        /// Adds the task.
        /// </summary>
        /// <param name="task">The planned task.</param>
        public void AddTask(PlannedTask task)
        {
            this.ScheduleTask(task);
        }

        #endregion

        #region Privates methods

        /// <summary>
        /// Runs the specified task.
        /// </summary>
        /// <param name="task">The task.</param>
        private void Run(PlannedTask task)
        {
            log.Debug("Run task: " + task.Description);
            // run pllaned action
            task.Execute();
            log.Info("Executed task: " + task.Description);
            // Schedule next execution
            this.ScheduleTask(task);
        }

        /// <summary>
        /// Schedules the task.
        /// </summary>
        /// <param name="task">The task.</param>
        private void ScheduleTask(PlannedTask task)
        {
            TimeSpan ts;
            var now = DateTime.Now;
            if (task.StartDate > now)
                ts = task.StartDate - now;
            else
            {
                task.StartDate = task.StartDate.Add(task.Interval);
                ts = task.StartDate - now;
            }

            //waits certan time and run the code
            Task.Delay(ts).ContinueWith((x) => Run(task));
            log.Info(string.Format("Scheduled task: {0}     at: {1}", task.Description, task.StartDate));
        }

        #endregion
    }
}
