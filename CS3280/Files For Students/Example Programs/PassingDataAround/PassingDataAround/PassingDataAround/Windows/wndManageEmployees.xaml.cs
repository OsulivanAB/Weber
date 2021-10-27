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
using System.Windows.Shapes;

namespace PassingDataAround
{
    /// <summary>
    /// Interaction logic for wndManageEmployees.xaml
    /// </summary>
    public partial class wndManageEmployees : Window
    {
        /// <summary>
        /// This is an object reference to our employee object manager.  Note that we do not create/instantiate the object here.  This object gets
        /// passed into this class via the constructor below.  That way we are only using one copy of our list of employees for our whole application.
        /// </summary>
        clsEmployeeObjectManager clsMyEmployeeObjectManager;

        /// <summary>
        /// Constructor where the employee object manager is passed in.
        /// </summary>
        /// <param name="EmployeeObjectManager"></param>
        public wndManageEmployees(clsEmployeeObjectManager EmployeeObjectManager)
        {
            InitializeComponent();
            //Set the object
            clsMyEmployeeObjectManager = EmployeeObjectManager;
        }

        /// <summary>
        /// Add a new employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            //Use the object reference to add the new employee
            clsMyEmployeeObjectManager.AddNewEmployee(txtFirstName.Text, txtLastName.Text, Convert.ToInt32(txtSalary.Text));
            lblMessage.Content = "Created new employee: " + txtFirstName.Text + " " + txtLastName.Text + " " + txtSalary.Text;
        }

        /// <summary>
        /// Add a new static employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddNewEmployeeStatic_Click(object sender, RoutedEventArgs e)
        {
            //Don't use an object reference for static objects.  Just use the class name to reference the static list of employees.
            clsEmployeeObjectManager.AddNewStaticEmployee(txtFirstNameStatic.Text, txtLastNameStatic.Text, Convert.ToInt32(txtSalaryStatic.Text));
            lblMessageStatic.Content = "Created new employee: " + txtFirstNameStatic.Text + " " + txtLastNameStatic.Text + " " + txtSalaryStatic.Text;
        }
    }
}
