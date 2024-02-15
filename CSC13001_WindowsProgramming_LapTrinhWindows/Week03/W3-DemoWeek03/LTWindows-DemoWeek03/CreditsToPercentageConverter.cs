using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LTWindows_DemoWeek03
{
    class CreditsToPercentageConverter : IValueConverter
    {
        public int Max { get; set; } = 1;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int credits = (int)value;
            
            float percent = (float) (credits * 100.0 / Max);
            string result = $"{credits} - {percent:0.00} %";
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
