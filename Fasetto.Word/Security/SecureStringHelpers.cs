using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Fasetto.Word
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> Class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// unsecures a <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="secureString">The secure String</param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            //make sure we have a secure stign
            if (secureString == null)
            {
                return string.Empty;
            }

            // Get a pointer for an unsecure string in memeory
            var unmanagedString = IntPtr.Zero;

            try
            {
                //unsecures password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //Clean up any Memory Allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

        }
    }
}
