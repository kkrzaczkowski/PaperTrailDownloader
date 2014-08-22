using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Debug("Reading parameters.");
            Config.CommandLineArguments = args;
            Config.Load();

            ReadLogs();

            log.Info("Before Planning");
            var startDate = DateTime.Now.AddSeconds(10);
            var interval = new TimeSpan(0, 0, 10);
            log.Info("First occur: " + startDate.ToString());

            var task = new PlannedTask(startDate, interval, () => log.Info("jakies wykonanie"), "Task1");

            TaskScheduler.Instance.AddTask(task);

            log.Info("Waiting in main class");
            Console.Read();
        }

        private static void ReadLogs()
        {
            if (Config.ApiToken != null)
            {
                
            }
            else
            {

            }
        }


    }
}
