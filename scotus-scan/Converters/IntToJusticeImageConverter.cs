using scotus_scan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace scotus_scan.Converters
{
    public class IntToJusticeImageConverter : DependencyObject, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value != null)
            {
                string justiceInt = value.ToString();
                Uri imageUri = new Uri(String.Format("ms-appx:///Assets/Justices/{0}.jpg", justiceInt));

                return imageUri;
            }
            
            return new Uri("ms-appx:///Assets/Justices/116.jpg");

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return true;
        }
    }
}
