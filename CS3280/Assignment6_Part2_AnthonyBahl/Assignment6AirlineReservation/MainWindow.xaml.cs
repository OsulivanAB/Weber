using System;
using System.Collections.Generic;
using System.Data;
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

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes

        /// <summary>
        /// Window that can gather passenger information.
        /// </summary>
        private wndAddPassenger wndAddPass;

        /// <summary>
        /// Manages all non-UI related logic.
        /// </summary>
        private clsFlightManager myFlightManager;

        /// <summary>
        /// Holds the currently selected flight.
        /// </summary>
        internal clsFlight currentFlight { get; set; }

        /// <summary>
        /// Holds the currently selected passenger
        /// </summary>
        private clsPassenger CurrentPassenger;

        /// <summary>
        /// Holds the current canvas
        /// </summary>
        private Canvas currentCanvas;

        /// <summary>
        /// Indicates if the user is actively selecting a seat.
        /// </summary>
        private bool bSeatSelecting;

        #endregion

        #region Properties

        private bool _seatSelecting
        {
            get
            {
                return bSeatSelecting;
            }
            set
            {
                if (value)
                {
                    // Disable all combo boxes and buttons
                    cbChooseFlight.IsEnabled = false;
                    cbChoosePassenger.IsEnabled = false;
                    gPassengerCommands.IsEnabled = false;

                    // Set seatSeleciton status
                    bSeatSelecting = value;
                }
                else
                {
                    // Disable all combo boxes and buttons
                    cbChooseFlight.IsEnabled = true;
                    cbChoosePassenger.IsEnabled = true;
                    gPassengerCommands.IsEnabled = true;

                    // Set seatSeleciton status
                    bSeatSelecting = value;
                }
            }
        }

        #endregion

        #region Methods

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;  // Application will shut down if the main window closes, even if other windows are open.
                myFlightManager = new clsFlightManager();
                updateData();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Handles any necessary updates when the flight selection is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Validate that there is something selected
                if (cbChooseFlight.SelectedIndex != -1)
                {
                    // set up variable for the selected flight
                    currentFlight = (clsFlight)cbChooseFlight.SelectedItem;

                    // Populate Passenger combo box
                    cbChoosePassenger.ItemsSource = currentFlight.lstPassengers;

                    // Clear any selected passengers
                    clearCurrentPassenger();

                    // Set up the canvas to the left
                    setupUI();
                }
                else
                {
                    // If nothing is selected then make sure that the passenger commands and fields are disabled
                    cbChoosePassenger.IsEnabled = false;
                    gPassengerCommands.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles any necessary updates when the passenger slection is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbChoosePassenger.SelectedIndex != -1)
                {
                    CurrentPassenger = (clsPassenger)cbChoosePassenger.SelectedItem;
                    setupUI();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This section updates the entire UI based on the current selection of things
        /// </summary>
        private void setupUI()
        {
            try
            {
                // Check if there is a selected flight
                if (cbChooseFlight.SelectedIndex != -1)
                {
                    // Set up Seating Canvas
                    if (currentFlight.sAircraftType == "Boeing 767")
                    {
                        CanvasA380.Visibility = Visibility.Hidden;
                        Canvas767.Visibility = Visibility.Visible;
                        currentCanvas = c767_Seats;
                        setSeatStatuses();
                    }
                    else
                    {
                        Canvas767.Visibility = Visibility.Hidden;
                        CanvasA380.Visibility = Visibility.Visible;
                        currentCanvas = cA380_Seats;
                        setSeatStatuses();
                    }

                    // Set the buttons group to enabled
                    gPassengerCommands.IsEnabled = true;

                    // Set passenger combo box to active
                    cbChoosePassenger.IsEnabled = true;

                    // Check if there is a passenger selected
                    if (cbChoosePassenger.SelectedIndex != -1)
                    {
                        cmdDeletePassenger.IsEnabled = true;
                        cmdChangeSeat.IsEnabled = true;
                        lblPassengersSeatNumber.Content = CurrentPassenger.SeatNumber;
                    }
                    // If there is not a passenger selected.
                    else
                    {
                        cmdDeletePassenger.IsEnabled = false;
                        cmdChangeSeat.IsEnabled = false;
                        lblPassengersSeatNumber.Content = "";
                    }
                }
                // If no flight is selected
                else
                {
                    // Make sure no passenger is selected
                    clearCurrentPassenger();
                    // Set the buttons to disabled
                    gPassengerCommands.IsEnabled = false;
                    // Set passenger combo box to active
                    cbChoosePassenger.IsEnabled = false;
                    // Clear any content in the current seat label
                    lblPassengersSeatNumber.Content = "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Sets the colors for all the seats on the canvas.
        /// </summary>
        private void setSeatStatuses()
        {
            try
            {
                // Loop over all seats
                foreach (var child in currentCanvas.Children)
                {
                    Label _seat = (Label)child;
                    // Check each passenger to see if this seat is reserved
                    foreach (var _passenger in currentFlight.lstPassengers)
                    {
                        // Variable to hold passengers seat name
                        string _seatName = string.Format("Seat{0}{1}", currentCanvas.Tag, _passenger.SeatNumber);

                        // Check if this is the selected passenger's seat
                        if (_seat.Name == _seatName && _passenger == CurrentPassenger)
                        {
                            _seat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF00FD00"));
                            break;
                        }
                        // Check if this is a non-selected passenger's seat
                        else if (_seat.Name == _seatName)
                        {
                            _seat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFD0000"));
                            break;
                        }
                        else
                        {
                            _seat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF0023FD"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles when the Add Passenger button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger();

                // Send Flight info
                wndAddPass.currentFLight = currentFlight;

                wndAddPass.ShowDialog();

                // Make sure the form wasn't cancelled
                if (wndAddPass.PassengerID > 0)
                {
                    // Update Combo boxes
                    updateData();

                    // Set the selected Passenger to the new one
                    for (int i = 0; i < cbChoosePassenger.Items.Count; i++)
                    {
                        clsPassenger _passenger = (clsPassenger)cbChoosePassenger.Items[i];
                        if (_passenger.iPassenger_ID == wndAddPass.PassengerID)
                        {
                            cbChoosePassenger.SelectedIndex = i;
                            break;
                        }
                    }

                    // Set seat statuses to make sure we're showing current availability
                    setSeatStatuses();

                    // Turn on seat selecting
                    _seatSelecting = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Handles any base level errors.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles when the change seat button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check to make sure that a passenger is selected
                if (cbChoosePassenger.SelectedIndex == -1)
                {
                    throw new Exception("No passenger selected, can't change seat");
                }
                else
                {
                    _seatSelecting = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Changes the currently selected passengers seat to the one that is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seat_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Make sure we're actively doing a seat selection
                if (bSeatSelecting == true)
                {
                    Label _label = (Label)sender;
                    string sSeatSelection = _label.Content.ToString();

                    // Attempt to update seat
                    bool flag = myFlightManager.UpdateSeat(currentFlight, CurrentPassenger, sSeatSelection);

                    // If seat was updated successfully update UI
                    if (flag)
                    {
                        // Turn off seat selecting
                        _seatSelecting = false;

                        // Update UI
                        updateData();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates Flight and passenger dropdown boxes
        /// </summary>
        private void updateData()
        {
            try
            {
                // Create variables to hold the currently selected items
                int selectedFlight = (currentFlight == null) ? -1 : currentFlight.iFlightID;
                int selectedPassenger = (CurrentPassenger == null) ? -1 : CurrentPassenger.iPassenger_ID;

                // Get Flight Info and set it as the data source for the choose flight drop down
                cbChooseFlight.ItemsSource = myFlightManager.GetFlights();

                // return to selected flight if there had been one selected
                if (selectedFlight == -1)
                {
                    clearCurrentFlight();
                }
                else
                {
                    // Variable to hold the new index when we find it, defaulted to no selection.
                    int _newIndex = -1;

                    // Loop over each item to find the matching flight ID
                    for (int i = 0; i < cbChooseFlight.Items.Count; i++)
                    {
                        clsFlight _flight = (clsFlight)cbChooseFlight.Items[i];
                        if (_flight.iFlightID == selectedFlight)
                        {
                            _newIndex = i;
                            break;
                        }
                    }

                    // Set the index for Choose Flight
                    cbChooseFlight.SelectedIndex = _newIndex;
                }

                // return to selected passenger if there had been one selected
                if (selectedPassenger == -1)
                {
                    clearCurrentPassenger();
                }
                else
                {
                    // Variable to hold the new index when we find it, defaulted to no selection.
                    int _newIndex = -1;

                    // Loop over each item to find the matching flight ID
                    for (int i = 0; i < cbChoosePassenger.Items.Count; i++)
                    {
                        clsPassenger _passenger = (clsPassenger)cbChoosePassenger.Items[i];
                        if (_passenger.iPassenger_ID == selectedPassenger)
                        {
                            _newIndex = i;
                            break;
                        }
                    }

                    // Set the index for Choose Passenger
                    cbChoosePassenger.SelectedIndex = _newIndex;
                }

                // Update the UI
                setupUI();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Takes care of all the actions needed when clearing the current passenger selection.
        /// </summary>
        private void clearCurrentPassenger()
        {
            try
            {
                cbChoosePassenger.SelectedIndex = -1;
                CurrentPassenger = null;
                lblPassengersSeatNumber.Content = "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Takes care of all the actions needed when clearing the current flight selection.
        /// </summary>
        private void clearCurrentFlight()
        {
            try
            {
                cbChooseFlight.SelectedIndex = -1;
                currentFlight = null;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Occurs when main window is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // Clear out any passengers who didn't get assigned a seat
                myFlightManager.cleanFlightPassengers();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the Delete Passenger button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            myFlightManager.DeleteFlightPassenger(currentFlight, CurrentPassenger);
            clearCurrentPassenger();
            updateData();
        }

        #endregion
    }
}
