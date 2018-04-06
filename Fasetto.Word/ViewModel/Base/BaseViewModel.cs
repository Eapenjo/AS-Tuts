using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq.Expressions;


namespace Fasetto.Word
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
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name">Name of property bring changed</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set
        /// If the flag is true (indicates the function is already running) then the action is not run
        /// If the flag is false (indicating no running function) then the action is run
        /// Once the action is finished if it was  run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
        /// <param name="action">The action to run if the command i snot already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //check if the flag property is true (meaning it is already running)
            if (updatingFlag.GetPropertyValue())
            {
                return;
            }

            //set the property flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true) ;

            try
            {
                //Run the passed in action
                await action();
            }
            finally
            {
                //set the property flag back to false now it's finished
                updatingFlag.SetPropertyValue(false);
            }

        }

        #endregion

    }


}
