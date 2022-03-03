using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace CryptoUtils.Helpers
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool Invert { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool b)
            {
                if (Invert)
                    b = !b;

                if (b)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            else
                throw new NotSupportedException("Value must be a boolean");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
