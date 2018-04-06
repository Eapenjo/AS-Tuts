using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// The View Model for the login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        
        #region Public Properties

        /// <summary>
        /// The Email of the user
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// A flag indicating that the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands
        
        /// <summary>
        /// Command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel()
        {

            // Create commands
            LoginCommand = new RelayParameterizedCommand(async(parameter) => await Login(parameter));
            
        }

        #endregion

        #region 

        /// <summary>
        /// Attempt to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {

            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                var emaail = this.Email;

                //Never Do this. Never store unsecured passwords into variables
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                
            });

        }
        
        #endregion


    }
}
