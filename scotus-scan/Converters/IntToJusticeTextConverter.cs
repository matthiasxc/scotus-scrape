using scotus_scan.Model;
using scotus_scan.Model.ModelMaps;
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
    public class IntToJusticeTextConverter : DependencyObject, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int justiceInt = 0;
            if(value != null)
            {
                justiceInt = System.Convert.ToInt32(value);
                string justiceName = JusticeMap.GetJusticeLastName(justiceInt);

                return justiceName;
            }
            
            return "No Justice Found";

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return true;
        }
    }
}
