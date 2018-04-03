using System.Collections.ObjectModel;
using System.Linq;

namespace TreeView
{
    /// <summary>
    /// View model for the applications main directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();

            this.Items = new ObservableCollection<DirectoryItemViewModel>(
               children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive))    
            );
        }
        #endregion


    }
}
