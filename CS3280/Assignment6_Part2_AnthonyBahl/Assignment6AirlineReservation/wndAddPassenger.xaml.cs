using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for wndAddPassenger.xaml
    /// </summary>
    public partial class wndAddPassenger : Window
    {
        /// <summary>
        /// Flight Manager.
        /// </summary>
        private clsFlightManager myFlightManager;

        internal int PassengerID { get; private set; }
        internal clsFlight currentFLight { get; set; }

        /// <summary>
        /// constructor for the add passenger window
        /// </summary>
        public wndAddPassenger()
        {
            try
            {
                InitializeComponent();
                myFlightManager = new clsFlightManager();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// only allows letters to be input
        /// </summary>
        /// <param name="sender">sent object</param>
        /// <param name="e">key argument</param>
        private void txtLetterInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters to be entered
                if (!(e.Key >= Key.A && e.Key <= Key.Z))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter))
                    {
                        //No other keys allowed besides numbers, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// exception handler that shows the error
        /// </summary>
        /// <param name="sClass">the class</param>
        /// <param name="sMethod">the method</param>
        /// <param name="sMessage">the error message</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Submits the new passenger for the current flight.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Flag to keep track of whether or not we're ok to move forward with adding the passenger
                bool _flag = true;

                // Verify that first and last name are not blank
                if (txtFirstName.Text.Length < 1)
                {
                    // Set flag to false because of invalid first name lengeth
                    _flag = false;
                    // Set First name field border to red
                    txtFirstName.BorderBrush = Brushes.Red;
                    txtFirstName.BorderThickness = new Thickness(2);
                }
                else
                {
                    // Clear red boarder if there is not an issue with First name
                    txtFirstName.BorderThickness = new Thickness(1);
                    txtFirstName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFABADB3"));
                }
                if (txtLastName.Text.Length < 1)
                {
                    // Set flag to false because of invalid last name length
                    _flag = false;
                    // Set Last name field border to red
                    txtLastName.BorderBrush = Brushes.Red;
                    txtLastName.BorderThickness = new Thickness(2);
                }
                else
                {
                    // Clear red boarder if there is not an issue with Last name
                    txtLastName.BorderThickness = new Thickness(1);
                    txtLastName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFABADB3"));
                }

                // If data passed tests then attempt to create new Passenger
                if (_flag)
                {
                    // Create new Passenger and assign it to the PassengerID Value
                    PassengerID = myFlightManager.addPassenger(currentFLight.iFlightID, txtFirstName.Text, txtLastName.Text);

                    // Close this window
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
