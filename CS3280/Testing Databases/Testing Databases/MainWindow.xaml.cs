using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testing_Databases
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Testing_Databases.MagicalDatabaseDataSet magicalDatabaseDataSet = ((Testing_Databases.MagicalDatabaseDataSet)(this.FindResource("magicalDatabaseDataSet")));
            // Load data into the table tblProduct. You can modify this code as needed.
            Testing_Databases.MagicalDatabaseDataSetTableAdapters.tblProductTableAdapter magicalDatabaseDataSettblProductTableAdapter = new Testing_Databases.MagicalDatabaseDataSetTableAdapters.tblProductTableAdapter();
            magicalDatabaseDataSettblProductTableAdapter.Fill(magicalDatabaseDataSet.tblProduct);
            System.Windows.Data.CollectionViewSource tblProductViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tblProductViewSource")));
            tblProductViewSource.View.MoveCurrentToFirst();
        }
    }
}
