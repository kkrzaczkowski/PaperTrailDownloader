using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperTrailDownloader.Utils
{
    /// <summary>
    /// A class contains files system functions.
    /// </summary>
    public static class FileSystem
    {
        /// <summary>
        /// Creates the directory structure.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void CreateDirectoryStructure(string path)
        {
            CreateDirectoryStructure(path, true);
        }

        /// <summary>
        /// Creates the directory structure.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="pathIncludeFile">if set to <c>true</c> [path include file].</param>
        public static void CreateDirectoryStructure(string path, bool pathIncludeFile)
        {
            string[] paths = path.Split(Path.DirectorySeparatorChar);

            // ignore the last split because its the filename
            int loopCount = paths.Length;
            if (pathIncludeFile)
                loopCount--;

            for (int ix = 0; ix < loopCount; ix++)
            {
                string newPath = paths[0] + @"\";
                for (int add = 1; add <= ix; add++)
                    newPath = Path.Combine(newPath, paths[add]);
                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);
            }
        }
    }
}
