using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LayoutArticle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new Window();
            wnd.Title = "Naive Layout";
            wnd.Content = new NaiveLayout();
            wnd.DataContext = new Customer();
            wnd.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new Window();
            wnd.Title = "Slightly Better Layout";
            wnd.Content = new SlightlyBetter();
            wnd.DataContext = new Customer();
            wnd.Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new Window();
            wnd.Title = "Stacked Layout";
            wnd.Content = new StackedApproach();
            wnd.DataContext = new Customer();
            wnd.Show();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new Window();
            wnd.Title = "Customer View";
            wnd.Content = new CustomerView();
            wnd.DataContext = new Customer();
            wnd.Show();
        }
    }
}
