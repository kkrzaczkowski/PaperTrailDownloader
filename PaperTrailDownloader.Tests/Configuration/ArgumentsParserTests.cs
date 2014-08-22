using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader.Tests.Configuration
{
    [TestFixture]
    class ArgumentsParserTests
    {
        [Test]
        public void ParaseArguments_Assigns_values()
        {
            var testAddress = "testAddress";
            var testUser = "testUser";
            var testPass = "testPassword";
            var testDirectory = "C:\asdasd";
            var testToken = "asdagsdghADFSGesg";

            var args = new List<string>()
            {
                "-address", testAddress,
                "-user", testUser,
                "-password", testPass,
                "-directory", testDirectory,
                "-token", testToken
            };

            var argumentsParser = new ArgumentsParser(args);

            Assert.That(testAddress, Is.EqualTo(argumentsParser.Address));
            Assert.That(testUser, Is.EqualTo(argumentsParser.User));
            Assert.That(testPass, Is.EqualTo(argumentsParser.Password));
            Assert.That(testDirectory, Is.EqualTo(argumentsParser.Directory));
            Assert.That(testToken, Is.EqualTo(argumentsParser.ApiToken));
        }

    }
}
