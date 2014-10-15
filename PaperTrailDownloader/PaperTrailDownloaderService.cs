using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    public class DownloaderService : ServiceBase
    {
        #region Private members

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DateTime dateOfLastDownload;
        
        #endregion

        #region .ctor

        public DownloaderService()
        {
            ServiceName = "PaperTrail.Downloader.Service";
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Starts the service.
        /// </summary>
        /// <param name="args">The args.</param>
        public void Start(params string[] args)
        {
            OnStart(args);
        }

        /// <summary>
        /// Execute during start procedure.
        /// </summary>
        /// <param name="args">The args.</param>
        public virtual void PerformStartup(string[] args)
        {
            log.Debug("Reading parameters.");
            // Load application parameters.
            Config.CommandLineArguments = args;
            Config.Load();
            log.Debug("Reading parameters finished.");
            try
            {
                log.Info("Before Planning");
                var startDate = DateTime.Now.AddSeconds(10);
                var interval = new TimeSpan(24, 0, 0);
                log.Info("First occur: " + startDate.ToString());

                var task = new PlannedTask(startDate, interval, () => Download(7), "Task");

                TaskScheduler.Instance.AddTask(task);
                this.dateOfLastDownload = startDate;
            }
            catch (Exception e)
            {
                log.Error("Error :", e);
            }
        }

        /// <summary>
        /// Execute during stop procedure.
        /// </summary>
        public virtual void PerformStop()
        {
            var now = DateTime.Now;
            log.Debug("Write to dateOfLastDownload: " + now);
            this.dateOfLastDownload = now;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Start handler.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
                PerformStartup(args);
                log.Warn("Downloader Service was started");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                log.Error(ex);

                //
                //Pass exception to another handler
                //throw;
            }
        }

        /// <summary>
        /// Stop handler.
        /// </summary>
        protected override void OnStop()
        {
            try
            {
                PerformStop();
                log.Warn("Downloader Service was stoped");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                log.Error(ex);
                //
                //Pass exception to another handler
                //throw;
            }
        }

        #endregion

        private void Download(int amountOfDays)
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

        private void InitializeComponent()
        {

        }
    }
}
