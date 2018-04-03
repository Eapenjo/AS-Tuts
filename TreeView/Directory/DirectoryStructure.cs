using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeView
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            //get each logical drive on machine
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();     
        }
        
        /// <summary>
        /// Gets the directory top level contents
        /// </summary>
        /// <param name="fullPath">The full path to the directory </param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // create an empty list
            var items = new List<DirectoryItem>();

            #region Get Folders

            //try and get directories, ignore any issues
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch { }
            #endregion
            #region Get Files

            //try and get files, ignore any issues
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
                }
            }
            catch { }
            #endregion

            return items;
        }

        #region Helpers
        /// <summary>
        /// Find the file or folder name froma full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            //Possible entries
            // C:\Something\a folder
            // C:\Something\a file.png
            // a file file.png

            //If we have no path, return empty
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            //make all slashes backslashes
            var normalizePath = path.Replace('/', '\\');

            //get last index/position
            var lastIndex = normalizePath.LastIndexOf('\\');

            //if cant find folder, return path itself
            if (lastIndex <= 0)
            {
                return path;
            }

            //return name after last backslash
            return path.Substring(lastIndex + 1);

        }
        #endregion

    }
}
