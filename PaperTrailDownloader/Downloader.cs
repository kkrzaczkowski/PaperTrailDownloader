using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    public class Downloader
    {
        private string userLogin;
        private string userPassword;

        public Downloader(string login, string password)
        {
            this.userLogin = login;
            this.userPassword = password;
        }

        public void DownloadData()
        {
            
        }
    }
}
