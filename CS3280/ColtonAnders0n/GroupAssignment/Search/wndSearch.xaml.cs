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
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using GroupAssignment.Main;

namespace GroupAssignment.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        #region Attributes
        /// <summary>
        /// Logic that will run the smarts behind the Search Window
        /// </summary>
        clsSearchLogic mySearchLogic;
        #endregion
        #region Methods
        /// <summary>
        /// Default constructor for window.
        /// </summary>
        public wndSearch()
        {
            try
            {
                InitializeComponent();


                mySearchLogic = new clsSearchLogic();

                // Populate Data
                populateData();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Populates the data grid with data based on current filters
        /// </summary>
        private void populateData()
        {
            try
            {
                // Get a filtered List of invoices
                IEnumerable myInvoiceList = mySearchLogic.getFilteredData(
                                                                        tbInvoiceID.Text,
                                                                        tbFirstName.Text,
                                                                        tbLastName.Text,
                                                                        dpDate.SelectedDate,
                                                                        cbPayment.SelectedIndex,
                                                                        cbOnline.SelectedIndex,
                                                                        cbStatus.SelectedIndex);

                // Update Datepicker so the minimum selectable date is the lowest date
                dpDate.DisplayDateStart = mySearchLogic.getMinDate(myInvoiceList);
                // Update Datepicker so the maximum selectable date is the highest date
                dpDate.DisplayDateEnd = mySearchLogic.getMaxDate(myInvoiceList);
                // Update Data Grid
                myDataGrid.ItemsSource = myInvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Handles when any of the search controls gets keyboard focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                var myString = sender.GetType().ToString();
                // Check the senders Control Type
                switch (sender.GetType().ToString())
                {
                    // Text Box
                    case "System.Windows.Controls.TextBox":

                        // create variable to hold textbox object
                        TextBox myTextBox = (TextBox)sender;

                        // Check to see if the foreground is silver, meaning that the user has not input anything
                        if (myTextBox.Foreground == Brushes.Silver)
                        {
                            // Clear Contents
                            myTextBox.Text = "";
                        }

                        // Change text color to black
                        myTextBox.Foreground = Brushes.Black;

                        break;

                    // Date Picker
                    case "System.Windows.Controls.DatePicker":

                        // Create variable to hold datepicker object
                        DatePicker myDatePicker = (DatePicker)sender;

                        // Change text color to black
                        myDatePicker.Foreground = Brushes.Black;

                        break;

                    // Combo Box
                    case "System.Windows.Controls.ComboBox":

                        // Create variable to hold Combobox
                        ComboBox myComboBox = (ComboBox)sender;

                        // Check to see if selected item is -1 (User hasn't selected anything)
                        if (myComboBox.SelectedIndex == -1)
                        {
                            // Clear Preview Text
                            myComboBox.Text = "";
                        }

                        // Change text color to black
                        myComboBox.Foreground = Brushes.Black;

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Handles when any of the search controls loses keyboard focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                // Determine control type
                switch (sender.GetType().ToString())
                {
                    case "System.Windows.Controls.TextBox":
                        // cast sender to a textbox object
                        TextBox myTextBox = (TextBox)sender;

                        // Check to see if the textbox is blank 
                        if (myTextBox.Text == "")
                        {
                            // Reset the control
                            reset_control(sender);
                        }
                        break;

                    // Date Picker
                    case "System.Windows.Controls.DatePicker":

                        // Create variable to hold datepicker object
                        DatePicker myDatePicker = (DatePicker)sender;

                        // Check to see if the user left without selecting a date
                        if (myDatePicker.SelectedDate == null)
                        {
                            // Reset Control
                            reset_control(sender);
                        }

                        break;

                    // Combo Box
                    case "System.Windows.Controls.ComboBox":

                        // Create variable to hold Combobox
                        ComboBox myComboBox = (ComboBox)sender;

                        // Check to see if selected item is -1 (User didn't select anything)
                        if (myComboBox.SelectedIndex == -1)
                        {
                            // Reset Control
                            reset_control(sender);
                        }

                        break;

                    default:
                        break;
                }

                // Re-Populate data
                populateData();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Method to handle errors.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
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
        /// <summary>
        /// Method to handle when a key is pressed while selecting a control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Check to see if the delete key was pressed
                if (e.Key == Key.Delete)
                {
                    reset_control(sender);
                }

                // Check to see if the enter key was pressed
                if (e.Key == Key.Enter)
                {
                    // Clear Keyboard Focus
                    Keyboard.ClearFocus();

                    // Re-Populate data
                    populateData();
                }

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Handles when a selection is changed (mainly in Combo Boxes)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender.GetType().ToString() == "System.Windows.Controls.ComboBox")
                {
                    // Create variable for combobox
                    var myComboBox = (ComboBox)sender;

                    // Set Foreground color to silver if the foreground was deleted and black if it was not
                    myComboBox.Foreground = (myComboBox.SelectedIndex == -1) ? Brushes.Silver : Brushes.Black;

                }

                // Re-Populate data
                populateData();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Clears a control, resets color and sets its value to the tag.
        /// </summary>
        /// <param name="sender">Control Object</param>
        private void reset_control(object sender)
        {
            try
            {
                // Clear Keyboard Focus
                Keyboard.ClearFocus();

                switch (sender.GetType().ToString())
                {
                    // Text Box
                    case "System.Windows.Controls.TextBox":

                        // cast sender to a textbox object
                        TextBox myTextBox = (TextBox)sender;

                        // Clear Text
                        myTextBox.Text = myTextBox.Tag.ToString();

                        // Set Foreground color to Silver
                        myTextBox.Foreground = Brushes.Silver;

                        // Re-Populate data
                        populateData();

                        break;

                    // Date Picker
                    case "System.Windows.Controls.DatePicker":

                        // Create variable to hold datepicker object
                        DatePicker myDatePicker = (DatePicker)sender;

                        myDatePicker.SelectedDate = null;

                        // Re-Populate data
                        populateData();

                        // Set Brush Color to silver
                        myDatePicker.Foreground = Brushes.Silver;

                        break;

                    // Combo Box
                    case "System.Windows.Controls.ComboBox":

                        // Create variable to hold Combobox
                        ComboBox myComboBox = (ComboBox)sender;

                        // Clear combo box selection
                        myComboBox.SelectedIndex = -1;

                        // Set to default value
                        myComboBox.Text = myComboBox.Tag.ToString();

                        // Set Foreground to Silver
                        myComboBox.Foreground = Brushes.Silver;

                        // Re-Populate data
                        populateData();

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Handles the button click event for the "Select Invoice" Button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Send selected invoice back to the main window's logic.
                clsMainLogic.setCurrentInvoice((clsInvoice)myDataGrid.SelectedItem);

                // CLose window
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Closes the window and returns to the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles when the clear selection button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set each value to blank
                reset_control(tbInvoiceID);
                reset_control(tbFirstName);
                reset_control(tbLastName);
                reset_control(dpDate);
                reset_control(cbPayment);
                reset_control(cbOnline);
                reset_control(cbStatus);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion
    }
}
