using PaperTrailDownloader.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    /// <summary>
    /// A class responsibles for getting data from server and saving its.
    /// </summary>
    public class Downloader
    {
        private const string PapertrailToken = "X-Papertrail-Token";
        private const int BufferSize = 1024;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string address;
        private string directory;
        private int amountOfDays;

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Downloader"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="directory">The directory.</param>
        /// <param name="amountOfDays">The amount of days.</param>
        public Downloader(string address, string directory, int amountOfDays)
        {
            this.address = address;
            this.directory = directory;
            this.amountOfDays = amountOfDays;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Downloads the by token.
        /// </summary>
        /// <param name="token">The token.</param>
        public void DownloadByToken(string token)
        {
            this.DownloadLogs(token, null, null);
        }

        /// <summary>
        /// Downloads the by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="pass">The pass.</param>
        public void DownloadByUser(string user, string pass)
        {
            this.DownloadLogs(null, user, pass);
        }

        #endregion

        #region Private methods

        private void DownloadLogs(string token, string user, string pass)
        {
            for (int i = 0; i < this.amountOfDays; i++)
            {
                // start download form yesterday
                var dateOfFile = DateTime.Now.AddDays(-(i + 1));
                var fileAdress = NameHelper.GenerateFileAddress(this.address, dateOfFile);
                var filePath = NameHelper.GenerateFilePath(this.directory, dateOfFile);

                this.Download(token, user, pass, fileAdress, filePath);
            }
        }

        private void Download(string token, string user, string pass, string fileAdress, string fileName)
        {
            if (!Directory.Exists(directory))
                Utils.FileSystem.CreateDirectoryStructure(directory, false);

            var request = WebRequest.Create(fileAdress);

            if (token != null)
            {
                request.Headers.Add(PapertrailToken, token);
            }
            else
            {
                if (user == null || pass == null)
                {
                    throw new ArgumentException("User data are not valid.");
                }

                request.Credentials = new NetworkCredential(user, pass);
            }

            try
            {
                log.Debug("Request to server for file: " + fileName);
                using (var response = request.GetResponse())
                using (var file = File.Create(fileName))
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var buffer = new byte[BufferSize];
                        int bytesRead;
                        do
                        {
                            bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                            file.Write(buffer, 0, bytesRead);
                        } while (bytesRead > 0);

                    }
                }

                log.Info("Downloaded file: " + fileName);
            }
            catch (WebException e)
            {
                if (((System.Net.HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    log.Info("This file does not exist: " + fileName);
                    return;
                }

                log.Error("WebException during downloading.", e);
                throw;
            }
        }

        #endregion
    }
}
