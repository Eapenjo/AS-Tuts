using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PropertyChanged;

namespace TreeView
{
    /// <summary>
    /// A Base View Model that filres property changed events as needed
    /// </summary>
    ///[ImplementPropertyChanged]
    
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property that changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }
}
