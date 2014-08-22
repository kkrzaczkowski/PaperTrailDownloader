using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    /// <summary>
    /// A class for reading properties from config file.
    /// </summary>
    public class ConfigFileProperties
    {
        #region Properties 

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; private set; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public string User { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; private set; }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public string Directory { get; private set; }

        /// <summary>
        /// Gets the API token.
        /// </summary>
        /// <value>
        /// The API token.
        /// </value>
        public string ApiToken { get; private set; }

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigFileProperties"/> class.
        /// </summary>
        public ConfigFileProperties()
        {
            this.LoadProperties();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the properties.
        /// </summary>
        private void LoadProperties()
        {
            //TODO:  Get values using reflection

            this.Address = ConfigurationManager.AppSettings["Address"];
            this.User = ConfigurationManager.AppSettings["User"];
            this.Password = ConfigurationManager.AppSettings["Password"];
            this.Directory = ConfigurationManager.AppSettings["Directory"];
            this.ApiToken = ConfigurationManager.AppSettings["ApiToken"];
        }

        #endregion
    }
}
