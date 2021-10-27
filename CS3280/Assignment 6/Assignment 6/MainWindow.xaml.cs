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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes

        /// <summary>
        /// Class to manage flights
        /// </summary>
        clsFlightManager myFlightManager;

        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                spSeatSelector.seatChanged += new MouseButtonEventHandler(seatChangeComplete);
                // Set up flight manager
                myFlightManager = new clsFlightManager();

                // Get the flight list for the drop down menu from the flight manager.
                cboFlights.ItemsSource = myFlightManager.GetFlights();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Disable Passenger fields
                this.cboPassengers.IsEnabled = false;
                this.btnChange_Seat.IsEnabled = false;
                this.btnDelete_Passenger.IsEnabled = false;

                // set up variable for the selected flight
                clsFlight selectedFlight = (clsFlight)this.cboFlights.SelectedItem;

                /// Display the appropriate flight on the left
                this.spSeatSelector.FormatSeating(selectedFlight);

                /// Choose Passenger combo box should be enabled and loaded with the passengers on the selected flight from the database
                this.cboPassengers.ItemsSource = selectedFlight.lstPassengers;
                this.cboPassengers.IsEnabled = true;

                /// Enable the "Add Passenger Button"
                btnAdd_Passenger.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Handles when the passengers dropdown menu is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbocboPassengers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Only need to do this if the combo box is enabled
                if (this.cboPassengers.IsEnabled)
                {
                    // Set up variable for the selected flight
                    clsFlight selectedFlight = (clsFlight)this.cboFlights.SelectedItem;
                    // Set up variable for the selected passenger
                    clsPassenger selectedPassenger = (clsPassenger)this.cboPassengers.SelectedItem;
                    // Update the flight display on the left
                    this.spSeatSelector.FormatSeating(selectedFlight, selectedPassenger);
                    // Update Seat Textbox
                    tblkPassengers_Seat.Text = selectedPassenger.SeatNumber;
                    // Enable "Delete Passenger" Button
                    this.btnDelete_Passenger.IsEnabled = true;
                    // Enable "Change Seat" Button
                    this.btnChange_Seat.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Handles the click event for the Change Seat Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Seat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Disable everything
                this.cboFlights.IsEnabled = false;
                this.cboPassengers.IsEnabled = false;
                this.btnAdd_Passenger.IsEnabled = false;
                this.btnDelete_Passenger.IsEnabled = false;
                this.btnChange_Seat.IsEnabled = false;
                // Set up variable for the selected flight
                clsFlight selectedFlight = (clsFlight)this.cboFlights.SelectedItem;
                // Set up variable for the selected passenger
                clsPassenger selectedPassenger = (clsPassenger)this.cboPassengers.SelectedItem;
                // Update the flight display on the left so that the available seats are clickable
                this.spSeatSelector.FormatSeating(selectedFlight, selectedPassenger, true);
                // Add instructions for the user
                this.tblkInstruction.Text = "Please select an empty seat.";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Verify's that the user wants to delete user then lets teh flight manager know.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Passenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verify that they want to delete the passenger
                switch (MessageBox.Show("Are you sure you want to delete this passenger?", "Delete Confirmation", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:

                        // Lock Passenger fields
                        this.cboPassengers.IsEnabled = false;
                        this.btnChange_Seat.IsEnabled = false;
                        this.btnDelete_Passenger.IsEnabled = false;

                        // Create variables for the passenger object
                        clsPassenger currentPassenger = (clsPassenger)this.cboPassengers.SelectedItem;
                        // Set up variable for the selected flight
                        clsFlight selectedFlight = (clsFlight)this.cboFlights.SelectedItem;

                        // Have Flight Manager delete the passenger
                        myFlightManager.DeletePassenger(selectedFlight, currentPassenger);

                        // Update passenger list
                        this.cboPassengers.ItemsSource = selectedFlight.lstPassengers;

                        // Unlock Passenger combo box
                        this.cboPassengers.IsEnabled = true;

                        // Update Seating on the left
                        this.spSeatSelector.FormatSeating(selectedFlight);

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        private void seatChangeComplete(object sender, MouseButtonEventArgs e)
        {
            // Set up variable for the selected flight
            clsFlight selectedFlight = (clsFlight)this.cboFlights.SelectedItem;
            // Set up variable for the selected passenger
            clsPassenger selectedPassenger = (clsPassenger)this.cboPassengers.SelectedItem;
            // Update the flight display on the left
            this.spSeatSelector.FormatSeating(selectedFlight, selectedPassenger);
            // Update Seat Textbox
            tblkPassengers_Seat.Text = selectedPassenger.SeatNumber;
            // Enable the things again
            this.cboFlights.IsEnabled = true;
            this.cboPassengers.IsEnabled = true;
            this.btnAdd_Passenger.IsEnabled = true;
            this.btnDelete_Passenger.IsEnabled = true;
            this.btnChange_Seat.IsEnabled = true;
        }
        /// <summary>
        /// Method to handle errors.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            //Try Catch/finally
            try
            {
                // Would write to a file or database here
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "handleError Exception: " + ex.Message);
            }
        }
        #endregion
        /// <summary>
        /// Opens the Add Passenger form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Passenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PassengerInfo myPassengerForm = new PassengerInfo();
                myPassengerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
