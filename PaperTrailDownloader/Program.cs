using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var occurDate = DateTime.Now.AddSeconds(10);
            Console.WriteLine("Planned time: " + occurDate.ToString());
            var scheduler = new TaskScheduler(occurDate);

            scheduler.Activate();
            Console.WriteLine("Waiting !!!! ");
            Console.Read();
        }
    }
}
