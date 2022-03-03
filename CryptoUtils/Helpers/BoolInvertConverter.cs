using System;
using Microsoft.UI.Xaml.Data;

namespace CryptoUtils.Helpers
{
    public class BoolInvertConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool b)
                return !b;
            else
                throw new NotSupportedException("Value must be a boolean");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
