using System.Windows;
using System.Windows.Controls;

namespace ListBoxesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RestaurantList.ItemsSource = RestaurantModel.Restaurants;
        }

        private void SwitchStyle(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            if (combobox == null || RestaurantList == null) return;

            Style = null;
            RestaurantList.Style = null;

            switch (combobox.SelectedIndex)
            {
                case 1:
                    RestaurantList.Style = GetStyle("List-Simple");
                    break;
                case 2:
                    RestaurantList.Style = GetStyle("List-Columns");
                    break;
                case 3:
                    RestaurantList.Style = GetStyle("List-Modern");
                    Style = GetStyle("Window-Black");
                    break;
                case 4:
                    RestaurantList.Style = GetStyle("List-Grid");
                    break;
                case 5:
                    RestaurantList.Style = GetStyle("List-Float");
                    Style = GetStyle("Window-Glass");
                    break;
                case 6:
                    RestaurantList.Style = GetStyle("List-Map");
                    break;
                case 7:
                    RestaurantList.Style = GetStyle("List-Ratings");
                    break;
                case 8:
                    RestaurantList.Style = GetStyle("List-Scatter");
                    Style = GetStyle("Window-Black");
                    break;
                case 9:
                    RestaurantList.Style = GetStyle("List-3D");
                    Style = GetStyle("Window-Glass");
                    break;
            }
        }

        private static Style GetStyle(string key)
        {
            var resource = Application.Current.FindResource(key);
            return resource as Style;
        }
    }
}
