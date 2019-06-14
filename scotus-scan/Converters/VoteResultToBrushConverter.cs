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
    public class VoteResultToBrushConverter : DependencyObject, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush returnBrush = new SolidColorBrush(Color.FromArgb(255,249,128,21));

            if(value is VoteResult)
            {
                VoteResult voteResultValue = (VoteResult)value;
                if(voteResultValue == VoteResult.TypicalSplit)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 212, 88, 70));
                } else if(voteResultValue == VoteResult.NonTypicalSplit)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 171, 113, 231));
                }
                else if (voteResultValue == VoteResult.LibMinority)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 236, 158, 158));
                }
                else if (voteResultValue == VoteResult.ConMinority)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 116, 159, 244));
                    
                }
                else if (voteResultValue == VoteResult.MixedMinority)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 140, 199, 136));
                }
                else if (voteResultValue == VoteResult.Even)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 158, 158, 158));
                }
                else if(voteResultValue == VoteResult.Unanimous)
                {
                    returnBrush = new SolidColorBrush(Color.FromArgb(255, 33, 102, 28));
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
