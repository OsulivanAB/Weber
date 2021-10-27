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

namespace PassingDataAround
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EmployeeMenu : Window
    {
        /// <summary>
        /// Since this is our "main" form, we can create the list of our employees here.  This is the one main list of employees for our entire program.
        /// So that we have created this object of employees, we pass this one list around to the other windows and classes to be used.
        /// </summary>
        clsEmployeeObjectManager clsMyEmployeeObjectManager;

        public EmployeeMenu()
        {
            InitializeComponent();
            //Instantiate the employee object manager
            clsMyEmployeeObjectManager = new clsEmployeeObjectManager();
        }

        /// <summary>
        /// Open the Manage employee window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdManageEmployees_Click(object sender, RoutedEventArgs e)
        {
            //Since we don't care about the "state" of the window, just create a new window each time the button is pressed
            //However we want to pass in our employee object manager to the window.  We do this via the class constructor
            wndManageEmployees wndMyManageEmployeeWindow = new wndManageEmployees(clsMyEmployeeObjectManager);
            wndMyManageEmployeeWindow.ShowDialog();
        }

        private void cmdEmployeeReport_Click(object sender, RoutedEventArgs e)
        {
            //Since we don't care about the "state" of the window, just create a new window each time the button is pressed
            wndEmployeeReport wndMyEmployeeReportWindow = new wndEmployeeReport();
            //Behind this window we created a property where we could pass in the employee object manager
            wndMyEmployeeReportWindow.SetMyEmployeeObjectManager = clsMyEmployeeObjectManager;
            wndMyEmployeeReportWindow.ShowDialog();
        }
    }
}
