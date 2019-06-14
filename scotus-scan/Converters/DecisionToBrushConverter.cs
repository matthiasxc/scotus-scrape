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
    public class DecisionToBrushConverter : DependencyObject, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush returnBrush = new SolidColorBrush(Color.FromArgb(0,0,0,0));

            if(value is int)
            {
                int decisionValue = (int)value;
                if(decisionValue == 1)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 215, 48, 31));
                } else if(decisionValue ==2)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 54, 144, 192));
                }
                else if (decisionValue == 3)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180));
                }
            }

            return returnBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return true;
        }
    }
}
