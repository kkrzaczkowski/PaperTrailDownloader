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
            log.Info("Before in main class");
            var occurDate = DateTime.Now.AddSeconds(10);
            Console.WriteLine("Planned time: " + occurDate.ToString());
            var scheduler = new TaskScheduler(occurDate);

            scheduler.Activate();
            Console.WriteLine("Waiting !!!! ");
            log.Info("Waiting in main class");
            Console.Read();
        }
    }
}
