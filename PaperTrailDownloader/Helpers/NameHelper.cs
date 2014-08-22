using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader.Helpers
{
    public static class NameHelper
    {
        public static string GenerateFileAddress(string address, DateTime date)
        {
            return string.Format("{0}/api/v1/archives/{1}/download", address, date.ToShortDateString());
        }

        public static string GenerateFilePath(string directory, DateTime date)
        {
            return string.Format("{0}\\{1}.gz", directory, date.ToShortDateString());
        }
    }
}
