using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SAServiceManage.Tools.Converter
{
    public class ContentConverter : IMultiValueConverter
    {
        //源属性传给目标属性时，调用此方法ConvertBack
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values can not be null");

            string s = "";
            for (int i = 0; i < 1; i++)
            {
                s = System.Convert.ToString(values[i]);
            }
            //foreach (var item in values)
            //{
            //    s += System.Convert.ToString(item);
            //}

            return s;
        }

        //目标属性传给源属性时，调用此方法ConvertBack
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
