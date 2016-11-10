using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace AluPlast.ControlLoader.UWPClient.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var bytes = (byte[])value;

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                var bitmapImage = new BitmapImage();
                stream.Seek(0, SeekOrigin.Begin);
                bitmapImage.SetSource(stream.AsRandomAccessStream());

                return bitmapImage;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
