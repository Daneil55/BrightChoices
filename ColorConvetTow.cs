using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightChoices;

namespace ColorTwoConveterNameSpace
{
    internal class ColorConveterTwo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string username;
            string fullname = null;


            if (value != null)
            {
                username = (string)value;
                if (username == Forum.usernames)
                    fullname = "White";
                else
                    
                    fullname = "Green";

            }
            return fullname;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
