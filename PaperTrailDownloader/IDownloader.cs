using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    /// <summary>
    /// Interface for downloader.
    /// </summary>
    public interface IDownloader
    {
        /// <summary>
        /// Downloads the by token.
        /// </summary>
        /// <param name="token">The token.</param>
        void DownloadByToken(string token);

        /// <summary>
        /// Downloads the by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="pass">The pass.</param>
        void DownloadByUser(string user, string pass);
    }
}
