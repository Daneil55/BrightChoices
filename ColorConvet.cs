using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightChoices;

namespace ColorConveterNameSpace
{
    internal class ColorConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string username;
            string fullname = null;
           

            if (value != null)
            {
                username = (string)value;
                if (username == Forum.usernames) 
                    fullname = MainPage.fullname;
                else
                    fullname = Forum.fullname;


            }
            return fullname;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
