using NUnit.Framework;
using PaperTrailDownloader.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader.Tests
{
    [TestFixture]
    class NameHelperTests
    {
        [Test]
        public void GenerateFileAddress_valid()
        {
            var testDate = new DateTime(2014, 8, 18);
            var testAdress = "https://papertrailapp.com";
            var expectedAdress = "https://papertrailapp.com/api/v1/archives/2014-08-18/download";

            Assert.That(NameHelper.GenerateFileAddress(testAdress, testDate), Is.EqualTo(expectedAdress));
        }

        [Test]
        public void GenerateFilePath_valid()
        {
            var testDate = new DateTime(2014, 8, 18);
            var testDirectory = "D:\\PaperTrailLogs";
            var expectedAdress = "D:\\PaperTrailLogs\\2014-08-18.gz";

            Assert.That(NameHelper.GenerateFilePath(testDirectory, testDate), Is.EqualTo(expectedAdress));
        }
    }
}
