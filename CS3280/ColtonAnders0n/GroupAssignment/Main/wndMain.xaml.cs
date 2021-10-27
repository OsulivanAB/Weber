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
using GroupAssignment.Search;
using GroupAssignment.Items;
using System.Reflection;
using GroupAssignment.Main;

namespace GroupAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Variables

        /// <summary>
        /// Holds the search form object.
        /// </summary>
        private wndSearch search;

        /// <summary>
        /// Holds the item editing form object.
        /// </summary>
        private wndItems items;

        /// <summary>
        /// See if the user has not saved their input.
        /// </summary>
        private bool changesMade = false;

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor that initializes variables and sets textbox behavior.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Bind event listener for text box to validator
            textBoxQuantity.PreviewTextInput += Validation.StrictNumberValidationTextBox;
            textBoxFirstName.PreviewTextInput += Validation.StrictAlphabetValidationTextBox;
            textBoxLastName.PreviewTextInput += Validation.StrictAlphabetValidationTextBox;

            //Allow main window to exit application on exit button
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //Reset the UI to 'Add Mode'
            clearUI();
            uiToAddMode(false);

            //Set combo boxes
            comboBoxItem.ItemsSource = clsMainLogic.getAllItems();
            comboBoxStatus.ItemsSource = clsMainLogic.getStatusTypes();
            comboBoxPayment.ItemsSource = clsMainLogic.getPaymentTypes();

            //Initialize new working invoice
            clsMainLogic.setWorkingInvoice(new clsInvoice(1, "null", "null", new DateTime(), false, "Cash", "Unpaid", new List<clsItem>()));
        }

        #endregion


        #region Buttons (open forms)

        /// <summary>
        /// Opens the search form to allow the user to select an invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSearchForm(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                 * Note: this search window UPDATES the static
                 * invoice property in 'clsMainSql.cs'.
                 */

                //Prevent losing changes
                if (!checkForChanges()) {
                    return;
                }

                //Create search form
                search = new wndSearch();

                //Hide main window
                this.Hide();

                //Show search form
                search.ShowDialog();

                //Reload the invoice object
                uiToEditMode(true);

                //Show the main window
                this.Show();
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Opens the item editing form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openDefTable(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                 * Note: this item window RETRIEVES the static
                 * invoice property in 'clsMainSql.cs'.
                 */

                //Prevent losing changes
                if (!checkForChanges())
                {
                    return;
                }

                //Create item editing form
                items = new wndItems();

                //Hide main window
                this.Hide();

                //Show item editing form
                items.ShowDialog();

                //Reload the invoice object
                uiToAddMode(true);

                //Show the main window
                this.Show();
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion




        #region Item editing buttons

        /// <summary>
        /// Adds the selected item and quantity to the invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get item from drop down box
                clsItem product = (clsItem)comboBoxItem.SelectedItem;

                //Get quantity from text box
                int quantity = int.Parse(textBoxQuantity.Text);


                //Get the current mode
                string currentMode = lblInputMode.Content.ToString();

                //Hold invoice to update
                clsInvoice invoice;

                //Get correct invoice
                if (currentMode == "Edit Mode")
                {
                    invoice = clsMainLogic.getCurrentInvoice();
                    
                    //Try and add the item to the invoice
                    clsMainLogic.AddItem("current", product, quantity);
                }
                else
                {
                    invoice = clsMainLogic.getWorkingInvoice();
                    
                    //Try and add the item to the invoice
                    clsMainLogic.AddItem("working", product, quantity);
                }

                

                //Set the correct invoice
                if (currentMode == "Edit Mode")
                {
                    clsMainLogic.setCurrentInvoice(invoice);
                }
                else
                {
                    clsMainLogic.setWorkingInvoice(invoice);
                }




                //Calculate total item cost
                double totalCost = 0.0;

                foreach (clsItem item in invoice.items)
                {
                    totalCost += item.DProductPrice;
                }

                //Update total cost
                textBoxTotal.Text = totalCost.ToString("0.##") + "$";



                //Refresh the UI

                //Refresh the UI
                if (currentMode == "Edit Mode")
                {
                    //Refresh 'edit mode'
                    uiToEditMode(false);
                }
                else
                {
                    //Refresh to 'add mode'
                    uiToAddMode(false);
                }
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Removes the selected item and quantity to the invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDropItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get item from drop down box
                clsItem product = (clsItem)comboBoxItem.SelectedItem;

                //Get quantity from text box
                int quantity = int.Parse(textBoxQuantity.Text);

                
                //Get the current mode
                string currentMode = lblInputMode.Content.ToString();
                
                //Hold invoice to update
                clsInvoice invoice;

                bool success = false;

                //Get correct invoice
                if (currentMode == "Edit Mode")
                {
                    invoice = clsMainLogic.getCurrentInvoice();

                    success = clsMainLogic.DropItem("current", invoice, product, quantity);
                }
                else
                {
                    invoice = clsMainLogic.getWorkingInvoice();

                    success = clsMainLogic.DropItem("working", invoice, product, quantity);
                }

                //Try and add the item to the invoice
                if (!success)
                {
                    //Show error message
                    String errorMsg = "Product does not exist in invoice!";
                    MessageBox.Show(errorMsg);

                    //Stop processing
                    return;
                }
                else {

                    //Set the correct invoice
                    if (currentMode == "Edit Mode")
                    {
                        clsMainLogic.setCurrentInvoice(invoice);
                    }
                    else
                    {
                        clsMainLogic.setWorkingInvoice(invoice);
                    }
                }




                //Calculate total item cost
                double totalCost = 0.0;

                foreach (clsItem item in invoice.items)
                {
                    totalCost += item.DProductPrice;
                }

                //Update total cost
                textBoxTotal.Text = totalCost.ToString("0.##") + "$";



                //Refresh the UI

                //Refresh the UI
                if (currentMode == "Edit Mode")
                {
                    //Refresh 'edit mode'
                    uiToEditMode(false);
                }
                else
                {
                    //Refresh to 'add mode'
                    uiToAddMode(false);
                }
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion


        #region Invoice editing buttons

        /// <summary>
        /// Changes the mode for the form to allow adding an item, or editing an existing item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Prevent losing changes
                if (!checkForChanges())
                {
                    return;
                }

                //Get the current mode
                string currentMode = lblInputMode.Content.ToString();

                //Update UI to 'edit' mode if possible
                if (currentMode != "Edit Mode")
                {
                    //Switch to 'edit mode'
                    uiToEditMode(true);
                }
                else
                {
                    //Switch to 'add mode'
                    uiToAddMode(true);
                }
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing invoice or saves a new invoice depending on the mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get the current mode
                string currentMode = lblInputMode.Content.ToString();

                //See if data was sucessfully saved
                bool success = false;

                if (currentMode == "Add Mode")
                {
                    //Hande adding a new invoice

                    //Get the invoice
                    clsInvoice invoice = clsMainLogic.getWorkingInvoice();

                    //Add data to invoice
                    success = retrieveInput(ref invoice);

                    if (success)
                    {
                        //Save the invoice
                        clsMainLogic.saveNewInvoice(invoice);
                    }
                }
                else {

                    //Handle updating a new invoice

                    //Get the invoice
                    clsInvoice invoice = clsMainLogic.getCurrentInvoice();

                    //Add data to invoice
                    success = retrieveInput(ref invoice);

                    if (success)
                    {
                        //Save the invoice
                        clsMainLogic.updateInvoice(invoice);
                    }
                }


                //Reset the working invoice
                clsMainLogic.setWorkingInvoice(new clsInvoice(1, "null", "null", new DateTime(), false, "Cash", "Unpaid", new List<clsItem>()));

                String errorMsg = "";

                //Refresh the UI to allow user to input new invoice
                if (success && currentMode == "Add Mode")
                {
                    uiToAddMode(true);

                    //Set success message
                    errorMsg = "Sucess! The new invoice was saved!";
                }
                else if (success)
                {
                    uiToEditMode(true);

                    //Set success message
                    errorMsg = "Sucess! The new invoice was updated!";
                }
                else {
                    //Set success message
                    errorMsg = "Fail! Could not save the invoice!";
                }

                //Show user sucessess message
                MessageBox.Show(errorMsg);
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the selcted invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Prevent losing changes
                if (!checkForChanges())
                {
                    return;
                }

                //Remove the current invoice
                bool success = clsMainLogic.removeInvoice(clsMainLogic.getCurrentInvoice());

                //Show message
                if (success) {
                    //Show user success message
                    MessageBox.Show("Success! Invoice deleted!");
                }

                //Switch to add mode
                uiToAddMode(true);
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region UI Updaters

        /// <summary>
        /// Loads the invoice into the data grid for editing.
        /// </summary>
        /// <returns>Returns true if invoice was sucessfully loaded.</returns>
        private bool loadInvoiceUI(clsInvoice invoice, bool clearControls)
        {
            try
            {
                //Prevent loading empty invoice
                if (invoice == null)
                {
                    //Warn user that invoice is not selected
                    String errorMsg = "Warning! You must select an invoice from\n" +
                                      "the 'Search' window to enter 'Edit Mode'!";

                    MessageBox.Show(errorMsg);

                    //Reset changes made
                    changesMade = false;

                    //End execution
                    return false;
                }
                else
                {
                    //Hold invoice for data grid
                    List<clsInvoice> invoiceHolder = new List<clsInvoice>();
                    invoiceHolder.Add(invoice);

                    //Calculate total item cost
                    double totalCost = 0.0;

                    foreach (clsItem product in invoice.items)
                    {
                        totalCost += product.DProductPrice;
                    }

                    
                    //Set the data grid
                    invoiceGrid.ItemsSource = invoiceHolder;
                    invoiceGrid.SelectedIndex = 0;

                    //Get the current mode
                    string currentMode = lblInputMode.Content.ToString();

                    //Set the controls based on edit mode
                    if (clearControls)
                    {
                        //Format controls based on mode
                        if (currentMode == "EditMode")
                        {
                            textBoxInvoiceID.Text = invoice.invoice + "";
                            calendarDate.SelectedDate = invoice.invoiceDate;
                            
                            textBoxFirstName.Text = invoice.firstName;
                            textBoxLastName.Text = invoice.lastName;
                        }
                        else
                        {
                            textBoxInvoiceID.Text = "N/A";
                            
                            textBoxFirstName.Text = "";
                            textBoxLastName.Text = "";
                        }

                        comboBoxItem.SelectedIndex = 0;
                        textBoxQuantity.Text = "0";

                        textBoxTotal.Text = totalCost.ToString("0.##") + "$";
                        comboBoxStatus.SelectedIndex = 0;
                        checkBoxOnline.IsChecked = invoice.IsOnline;
                        comboBoxPayment.SelectedIndex = 0;
                    }

                    //Reset changes made
                    changesMade = false;
                }
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            //Could not load invoice
            return true;
        }


        /// <summary>
        /// Refreshes the UI into 'Edit Mode'. This allows the
        /// user to edit an existing invoice that was selected
        /// from the 'Search' window.
        /// </summary>
        /// <returns>Returns true if UI sucessfully updated.</returns>
        private bool uiToEditMode(bool clearControls)
        {
            try
            {
                if (clearControls)
                {
                    //Reset the UI
                    clearUI();
                }
                
                //Reload the selected invoice
                if (!loadInvoiceUI(clsMainLogic.getCurrentInvoice(), clearControls))
                {
                    return false;
                }

                //Update UI mode text
                lblInputMode.Content = "Edit Mode";
                btnMode.Content = "Add Mode";

                //Enable delete invoice button
                btnDelete.Visibility = Visibility.Visible;

                //UI updated successfully
                return true;

            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            //UI not updated
            return false;
        }


        /// <summary>
        /// Refreshes the UI into 'Add Mode'. This allows the
        /// user to create a new invoice and save it.
        /// </summary>
        /// <returns>Returns true if UI sucessfully updated.</returns>
        private bool uiToAddMode(bool clearControls)
        {
            try
            {
                if (clearControls)
                {
                    //Reset the UI
                    clearUI();
                }

                //Reload the selected invoice
                if (!loadInvoiceUI(clsMainLogic.getWorkingInvoice(), clearControls))
                {
                    return false;
                }

                //Update UI mode text
                lblInputMode.Content = "Add Mode";
                btnMode.Content = "Edit Mode";

                //Disable delete invoice button
                btnDelete.Visibility = Visibility.Hidden;

                //UI updated successfully
                return true;
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            //UI not updated
            return false;
        }



        /// <summary>
        /// Resets the UI controls to their default state.
        /// </summary>
        private void clearUI()
        {
            try
            {
                //Reset all UI values to default
                textBoxInvoiceID.Text = "N/A";

                comboBoxItem.SelectedIndex = 0;
                textBoxQuantity.Text = "0";

                textBoxFirstName.Text = "";
                textBoxLastName.Text = "";

                textBoxTotal.Text = "0.00$";
                comboBoxStatus.SelectedIndex = 0;
                checkBoxOnline.IsChecked = false;
                comboBoxPayment.SelectedIndex = 0;

                invoiceGrid.ItemsSource = null;

                comboBoxItem.ItemsSource = clsMainLogic.getAllItems();
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Gets input from the UI controls.
        /// </summary>
        /// <param name="invoice">The invoice that will hold the users data input.</param>
        /// <returns>Returns true if the data was read in properly.</returns>
        public bool retrieveInput(ref clsInvoice invoice)
        {
            try
            {
                //Get input
                string firstName = textBoxFirstName.Text;
                string lastName = textBoxLastName.Text;

                DateTime date = calendarDate.SelectedDate.Value.Date;
                string status = (string)comboBoxStatus.SelectedItem;
                bool isOnline = (bool)checkBoxOnline.IsChecked;
                string payment = (string)comboBoxPayment.SelectedItem;


                //Get the current time for the date
                DateTime currentTime = DateTime.Now;

                int x = currentTime.Hour;
                int y = currentTime.Minute;
                int z = currentTime.Second;

                date = date.Date.AddHours(x).AddMinutes(y).AddSeconds(z);


                //Add input to invoice object
                invoice.firstName = firstName;
                invoice.lastName = lastName;
                invoice.invoiceDate = date;
                invoice.status = status;
                invoice.IsOnline = isOnline;
                invoice.PaymentMethod = payment;
            }
            catch (Exception ex)
            {
                //Show error dialog if something went wrong
                Validation.showError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Warns users if changes have been made if they try to navigate away.
        /// </summary>
        /// <returns>False if the user doesn't want to navigate away.</returns>
        public bool checkForChanges()
        {
            //See if any changes were made
            if (changesMade) {
                
                //Set message
                string errorMsg = "Changes have been made that were not saved!\n" +
                                  "Discard changes?";
                
                //Show user sucessess message
                MessageBoxResult result = MessageBox.Show(errorMsg, "Warning! Unsaved changes!", MessageBoxButton.YesNo);

                //Allow user navigation/action
                if (result == MessageBoxResult.Yes){

                    changesMade = false;
                    return true;
                }
            }

            //Prevent user navigation/action
            return true;
        }

        #endregion



        #region Listeners for controls

        /// <summary>
        /// Sees if the combo box selection have been changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Flag that changes have been made
            changesMade = true;
        }

        /// <summary>
        /// Sees if the check box has been changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxOnline_Checked(object sender, RoutedEventArgs e)
        {
            //Flag that changes have been made
            changesMade = true;
        }

        /// <summary>
        /// Sees if the text boxes have been changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Flag that changes have bene made
            changesMade = true;
        }

        #endregion
    }
}
