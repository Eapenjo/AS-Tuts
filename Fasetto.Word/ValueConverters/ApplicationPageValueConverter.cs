﻿using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasetto.Word
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to a actial view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueCOnverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Finds the apporopriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}