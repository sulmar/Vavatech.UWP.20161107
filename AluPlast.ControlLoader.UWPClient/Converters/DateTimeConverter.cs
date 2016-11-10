using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AluPlast.ControlLoader.UWPClient.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;

            return new DateTimeOffset(date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var dateoffset = (DateTimeOffset)value;

            return dateoffset.Date;
        }
    }
}
