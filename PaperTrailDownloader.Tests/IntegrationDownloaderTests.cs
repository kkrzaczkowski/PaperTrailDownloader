using NUnit.Framework;
using PaperTrailDownloader.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader.Tests
{
    [TestFixture]
    public class IntegrationDownloaderTests
    {
        private IDownloader downloader;
        string tempPath;
        string testToken = "X582v9Etzr0D5bkfaStg";

        [SetUp]
        public void Init()
        {
            this.tempPath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "\\";
            this.downloader = new Downloader("https://papertrailapp.com", this.tempPath, 1);
        }

        [TearDown]
        public void Cleanup()
        {
            // Removing files and directiries
            System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(tempPath);
            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        [Test]
        public void Downloader_DownloadByToken_FileExists()
        {
            var dateOfFile = DateTime.Now.AddDays(-1);
            var filePath = NameHelper.GenerateFilePath(this.tempPath, dateOfFile);
            
            this.downloader.DownloadByToken(this.testToken);
            
            // Asserts
            Assert.IsTrue(File.Exists(filePath), "File should exist.");
        }

        [Test]
        public void Downloader_DownloadByToken_FileNotExists()
        {
            var dateOfFile = DateTime.Now.AddDays(-12);
            var filePath = NameHelper.GenerateFilePath(this.tempPath, dateOfFile);

            this.downloader.DownloadByToken(this.testToken);

            // Asserts
            Assert.IsFalse(File.Exists(filePath), "File should not exist.");
        }
    }
}
