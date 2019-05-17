using System;
using System.Globalization;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    public class SkillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int skill = (int)value;
            string name;

            switch (skill)
            {
                case 0:
                    name = "Junior";
                    break;
                case 1:
                    name = "Middle";
                    break;
                case 2:
                    name = "Senior";
                    break;
                case 3:
                    name = "Lead";
                    break;
                default:
                    name = "LS";
                    break;
            }

            return name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

