using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader
{
    /// <summary>
    /// A class for parasing arguments from command line.
    /// </summary>
    public class ArgumentsParser
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
        /// Initializes a new instance of the <see cref="ArgumentsParser"/> class.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public ArgumentsParser(IList<string> args)
        {
            this.ParaseArguments(args);
        }

        #endregion

        #region Private

        /// <summary>
        /// Parases the arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void ParaseArguments(IList<string> args)
        {
            for (int i = 0; i < args.Count; i = i +2)
            {
                string argName = args[i]; 
                string argValue = args[i + 1];

                switch (argName.ToLower())
                {
                    case "-address":
                        this.Address = argValue;
                        break;
                    case "-user":
                        this.User = argValue;
                        break;
                    case "-password":
                        this.Password = argValue;
                        break;
                    case "-directory":
                        this.Directory = argValue;
                        break;
                    case "-token":
                        this.ApiToken = argValue;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
