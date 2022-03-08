using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace CryptoUtils.Helpers
{
    public class PercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int i)
                return $"{i}%";
            else if (value is long l)
                return $"{l}%";
            else if (value is double d)
                return $"{d:N0}%";
            else if (value is decimal dec)
                return $"{dec:N0}%";
            else if (value is float f)
                return $"{f:N0}%";

            throw new NotSupportedException($"Type '{value.GetType()}' not supported");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
