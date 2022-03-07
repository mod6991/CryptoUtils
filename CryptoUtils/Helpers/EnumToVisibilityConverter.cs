using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace CryptoUtils.Helpers
{
    public class EnumToVisibilityConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter is string param)
            {
                if (!Enum.IsDefined(EnumType, value))
                    throw new NotSupportedException("Value must be an Enum");

                object enumValue = Enum.Parse(EnumType, param);

                return enumValue.Equals(value) ? Visibility.Visible : Visibility.Collapsed;
            }

            throw new NotSupportedException("Parameter must be an Enum value");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
