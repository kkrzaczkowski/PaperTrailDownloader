using System;
using System.ServiceProcess;

namespace PaperTrailDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((args.Length > 0))
            {
                // start in test mode (console)
                new DownloaderService().Start(args);
            }
            else
            {
                // start in service mode
                Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                ServiceBase.Run(new DownloaderService());
            }
        }
    }
}
