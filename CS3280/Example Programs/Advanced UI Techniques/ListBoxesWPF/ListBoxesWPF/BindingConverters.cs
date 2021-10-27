using System.Windows;
using System.Windows.Data;

namespace ListBoxesWPF
{
    public class StarWidthConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var stars = (decimal)value;
                var width = (double)(80 / 5 * stars);
                return new Rect(0, 0, width, 16);
            }
            catch
            {
                return new Rect(0, 0, 80, 16);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

    public class StarHeightConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var stars = (decimal)value;
                var height = (double)(200 / 5 * stars);
                return height;
            }
            catch
            {
                return 200d;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
