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
            log.Debug("Reading parameters finished.");

            Console.WriteLine("Downloading. Please wait !!!");

            try
            {
                Download(7);
                Console.WriteLine("Files are downloaded.");
            }
            catch (Exception e)
            {
                log.Error("Error :", e);
                Console.WriteLine(e.Message);
            }


            //log.Info("Before Planning");
            //var startDate = DateTime.Now.AddSeconds(10);
            //var interval = new TimeSpan(0, 0, 10);
            //log.Info("First occur: " + startDate.ToString());

            //var task = new PlannedTask(startDate, interval, () => log.Info("jakies wykonanie"), "Task1");

            //TaskScheduler.Instance.AddTask(task);

            Console.WriteLine("Press any button to finish.");
            Console.Read();
        }

        private static void Download(int amountOfDays)
        {
            var downloader = new Downloader(Config.Address, Config.Directory, amountOfDays);

            if (Config.ApiToken != null)
            {
                downloader.DownloadByToken(Config.ApiToken);
            }
            else
            {
                downloader.DownloadByUser(Config.User, Config.Password);
            }
        }

    }
}
