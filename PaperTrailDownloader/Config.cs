using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    /// <summary>
    /// Static class which contains settiongs of 
    /// </summary>
    public class Config
    {
        #region Properties

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public static string Address { get; private set; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public static string User { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public static string Password { get; private set; }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public static string Directory { get; private set; }

        /// <summary>
        /// Gets the API token.
        /// </summary>
        /// <value>
        /// The API token.
        /// </value>
        public static string ApiToken { get; private set; }

        /// <summary>
        /// Sets the command line arguments.
        /// </summary>
        /// <value>
        /// The command line arguments.
        /// </value>
        public static IList<string> CommandLineArguments { private get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Loads properties.
        /// </summary>
        public static void Load()
        {
            if (CommandLineArguments != null)
            {
                LoadFromCmd();
            }

            LoadFromConfigFile();
        }

        #endregion

        #region Private

        private static void LoadFromCmd()
        {
            var argumentsParser = new ArgumentsParser(CommandLineArguments);

            // Command line values have higher priority.
            if (argumentsParser.Address != null)
            {
                Address = argumentsParser.Address;
            }
            if (argumentsParser.User != null)
            {
                User = argumentsParser.User;
            }
            if (argumentsParser.Password != null)
            {
                Password = argumentsParser.Password;
            }

            if (argumentsParser.Directory != null)
            {
                Directory = argumentsParser.Directory;
            }

            if (argumentsParser.ApiToken != null)
            {
                Directory = argumentsParser.ApiToken;
            }
        }

        private static void LoadFromConfigFile()
        {
            var configProperties = new ConfigFileProperties();

            // existing values have higher priority.
            if (Address == null)
            {
                Address = configProperties.Address;
            }
            if (User == null)
            {
                User = configProperties.User;
            }
            if (Password == null)
            {
                Password = configProperties.Password;
            }

            if (Directory == null)
            {
                Directory = configProperties.Directory;
            }

            if (ApiToken == null)
            {
                ApiToken = configProperties.ApiToken;
            }
        }

        #endregion
    }
}
