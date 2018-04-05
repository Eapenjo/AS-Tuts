using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    
    /// <summary>
    /// The MonitorPassword attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool> {
        
        /// <summary>
        /// Overrides the OnValueChanged for passwordbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the caller
            var passwordBox = sender as PasswordBox;

            //make sure it is a password box
            if (passwordBox == null)
            {
                return;
            }

            //Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            //If the caller set MonitorPassword to true...
            if ((bool)e.NewValue)
            {
                //set defalt property
                HasTextProperty.SetValue(passwordBox);

                //start listening out for password change
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }

        }

        /// <summary>
        /// Fired when the password box password value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Set the attached HasText property
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }
    
    /// <summary>
    /// The HasText attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Sets the HasText property based on if the caller <see cref="PasswordBox"/> has any text
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            HasTextProperty.SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }

}
