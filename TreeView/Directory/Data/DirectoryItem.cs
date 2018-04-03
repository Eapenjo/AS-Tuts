using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeView
{
    /// <summary>
    /// Information about a Directory Item, such as drive, item or folder
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        
        /// <summary>
        /// The absolute path to the item
        /// </summary>
        public string FullPath { get; set; }
        
        /// <summary>
        /// The name of this directory Item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

    }
}
