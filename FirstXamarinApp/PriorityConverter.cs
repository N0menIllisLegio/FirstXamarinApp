using System;
using System.Globalization;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    public class PriorityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int priority = (int)value;
            Color color = new Color();

            switch (priority)
            {
                case 0:
                    color = Color.Green;
                    break;
                case 1:
                    color = Color.Yellow;
                    break;
                case 2:
                    color = Color.Red;
                    break;
                default:
                    color = Color.Gray;
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
