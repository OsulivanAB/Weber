using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GroupAssignment.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        #region Attributes
        /// <summary>
        /// Class where logic for the items window takes place.
        /// </summary>
        private clsItemsLogic itemLogic;

        /// <summary>
        /// The item the user selects to add / edit / delete.
        /// </summary>
        private clsItem item;

        /// <summary>
        /// List of all items.
        /// </summary>
        private static ObservableCollection<clsItem> lstItems;

        /// <summary>
        /// The current mode the window is in. (add, edit, or delete). "" = none.
        /// </summary>
        private string mode;

        /// <summary>
        /// List of invoice IDs that include a specified item.
        /// </summary>
        private ObservableCollection<int> lstInvoicesWithItem;

        /// <summary>
        /// Whether or not an item was deleted.
        /// </summary>
        private bool bItemWasDeleted;

        /// <summary>
        /// Regular expression used to format and validate user input for item cost.
        /// Source for regex is found User Input Validation region below.
        /// </summary>
        private static readonly Regex numRegex = new Regex(@"^[0-9 $]\d*(\.\d{0,2})?$");
        #endregion // Attributes


        #region Constructor(s)
        /// <summary>
        /// Default constructor for wndItems.
        /// </summary>
        public wndItems()
        {
            try
            {
                InitializeComponent();

                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                itemLogic = new clsItemsLogic();
                item = new clsItem();

                lstItems = new ObservableCollection<clsItem>();
                lstInvoicesWithItem = new ObservableCollection<int>();

                bItemWasDeleted = false;

                fillDataGridAndListBox();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        #endregion // Constructor(s)


        #region Methods


        #region Misc. Methods
        /// <summary>
        /// This method fills the data grid on the items window with all items in database.
        /// </summary>
        private void fillDataGridAndListBox()
        {
            try
            {
                itemLogic.getItems(ref lstItems);
                dgItems.ItemsSource = lstItems;
                lbInvoices.ItemsSource = lstInvoicesWithItem;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end fillDataGrid()


        /// <summary>
        /// This method clears all text boxes.
        /// </summary>
        private void clearTextboxes()
        {
            try
            {
                tbEditItemID.Text = "";
                tbEditItemName.Text = "";
                tbEditItemDescription.Text = "";
                tbEditItemCost.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end clearTextBoxes()


        /// <summary>
        /// This method removes the drop-down arrow from the tool bar.
        /// Source: https://stackoverflow.com/questions/4662428/how-to-hide-arrow-on-right-side-of-a-toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbarItems_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ToolBar toolBar = sender as ToolBar;
                var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
                if (overflowGrid != null)
                {
                    overflowGrid.Visibility = Visibility.Collapsed;
                }

                var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
                if (mainPanelBorder != null)
                {
                    mainPanelBorder.Margin = new Thickness(0);
                }
            }
            catch (Exception ex)
            {

                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }// end toolbarItems_Loaded()


        /// <summary>
        /// This method Handles errors and/or exceptions.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        /// <param name="sMessage">The message that describes the type of exception.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        } // end HandleError()
        #endregion // Misc. Methods


        #region Event Methods
        /// <summary>
        /// This method returns the user to the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();               
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end btnMainMenu_Click()


        /// <summary>
        /// This method is called when the "Add Item" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                // Enable data grid.
                dgItems.IsEnabled = true;

                // Switch to "add" mode.
                mode = "add";

                // Enable text boxes.
                tbEditItemName.IsReadOnly = false;
                tbEditItemDescription.IsReadOnly = false;
                tbEditItemCost.IsReadOnly = false;

                // Clear all text boxes.
                clearTextboxes();

                // Reset invalid section.
                tbInvalidInput.Text = "";
                lstInvoicesWithItem.Clear();
                lbInvoices.Visibility = Visibility.Hidden;

                // Product ID is auto-generated and therefore TBD.
                tbEditItemID.Text = "TBD";

                // Enable Submit changes button.
                btnSubmitChanges.IsEnabled = true;
                btnSubmitChanges.Content = "Add New Item";

                // Let the user know which mode they are in.
                lblMode.Content = "Add mode. Enter Item details below.";

                // Prevent the user from selecting items while adding an item.
                dgItems.IsEnabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }// end btnAddItemClick()


        /// <summary>
        /// This method is called when the "Edit Item" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Enable data grid.
                dgItems.IsEnabled = true;

                // Switch to edit mode.
                mode = "edit";
                lblMode.Content = "Edit mode. Choose an item to edit.";

                // Remove any selection.
                dgItems.SelectedItem = null;

                // Disable submit button until the user selects an item.
                btnSubmitChanges.IsEnabled = false;
                btnSubmitChanges.Content = "Update this item";

                // Reset invalid section.
                tbInvalidInput.Text = "";
                lstInvoicesWithItem.Clear();
                lbInvoices.Visibility = Visibility.Hidden;

                clearTextboxes();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end btnEditItem_Click()


        /// <summary>
        /// This method is called when the "Delete Item" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Enable data grid.
                dgItems.IsEnabled = true;

                // Update mode.
                mode = "delete";
                lblMode.Content = "Delete mode. Choose an item to delete.";

                // Remove any selection.
                dgItems.SelectedItem = null;

                clearTextboxes();

                // Clear invalid section.
                lstInvoicesWithItem.Clear();
                tbInvalidInput.Text = "";
                lbInvoices.Visibility = Visibility.Hidden;

                // Disable submit button until the user selects an item.
                btnSubmitChanges.IsEnabled = false;
                btnSubmitChanges.Content = "Delete this item";

                // Disable text boxes.
                tbEditItemName.IsReadOnly = true;
                tbEditItemDescription.IsReadOnly = true;
                tbEditItemCost.IsReadOnly = true;

                // Allow user to choose an item.
                grdItems.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end btnDeleteItem_Click()


        /// <summary>
        /// This method is called when the SubmitChanges button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // If the text box is not empty nor does it only contain spaces, nor is the item cost in an incorrect format.
                if (!(tbEditItemCost.Text.Trim() == "" || 
                    tbEditItemDescription.Text.Trim() == "" || 
                    tbEditItemName.Text.Trim() == ""  || 
                    tbEditItemCost.Text == "$" ||
                    tbEditItemCost.Text == "." || 
                    tbEditItemCost.Text == "$." || 
                    tbEditItemCost.Text == "," || 
                    tbEditItemCost.Text == "$,"))
                {
                    if (mode == "add")
                    {
                        // Clear error message.
                        tbInvalidInput.Text = "";

                        // Add new item to database and Update lstItems ObservableCollection to show changes on items data grid.
                        itemLogic.addNewItem(tbEditItemName.Text, tbEditItemDescription.Text, tbEditItemCost.Text, ref lstItems); // added

                        // Reset window.
                        //dgItems.IsEnabled = true;
                        clearTextboxes();
                        tbEditItemID.Text = "TBD";
                    } // end add section

                    else if (mode == "delete")
                    {
                        // Attempt to delete the item.
                        bItemWasDeleted = itemLogic.deleteItem((clsItem)dgItems.SelectedItem, ref lstInvoicesWithItem, ref lstItems);

                        if (bItemWasDeleted)
                        {
                            // Reset invalid section.
                            tbInvalidInput.Text = "";
                            lstInvoicesWithItem.Clear();
                            clearTextboxes();
                            lbInvoices.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            tbInvalidInput.Text = "Unable to delete item. This item is on invoice(s):";
                            lbInvoices.Visibility = Visibility.Visible;
                        }
                    } // end delete section

                    else if (mode == "edit")
                    {
                        // Update the item.
                        itemLogic.editItem(dgItems.SelectedIndex, tbEditItemID.Text, tbEditItemName.Text, tbEditItemDescription.Text, tbEditItemCost.Text, ref lstItems);

                        // Reset invalid section.
                        tbInvalidInput.Text = "";
                    } // end edit section
                }

                else
                {
                    tbInvalidInput.Text = "Please enter a value for all item attributes.";
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end btnSubmitChanges_Click


        /// Source for currency format: https://www.codeproject.com/Questions/1172204/Change-text-box-value-to-currency-format-in-csharp
        /// <summary>
        /// This method is called when an item is selected in the items data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgItems.SelectedItem == null)
                {
                    // If an item isn't selected, don't do anything.
                    return;
                }

                if (mode != "add")
                {
                    // Display item details in item info text boxes.
                    tbEditItemID.Text = ((clsItem)dgItems.SelectedItem).SProductID.ToString();
                    tbEditItemName.Text = ((clsItem)dgItems.SelectedItem).SProductName;
                    tbEditItemDescription.Text = ((clsItem)dgItems.SelectedItem).SProductDescription;

                    // Get the selected item's cost from the items data grid and format it as currency.
                    string itemCost = $"{(((clsItem)dgItems.SelectedItem).DProductPrice):C2}";

                    // Display Item Cost in the edit item cost text box.
                    tbEditItemCost.Text = itemCost;
                }


                if (mode == "delete")
                {
                    // Clear error messages.
                    lstInvoicesWithItem.Clear();
                    tbInvalidInput.Text = "";
                    lbInvoices.Visibility = Visibility.Hidden;

                    lblMode.Content = "Deleting this item:";
                    btnSubmitChanges.IsEnabled = true;
                }

                if (mode == "edit")
                {
                    // Enable text boxes.
                    tbEditItemName.IsReadOnly = false;
                    tbEditItemDescription.IsReadOnly = false;
                    tbEditItemCost.IsReadOnly = false;

                    lblMode.Content = "Editing this item:";
                    btnSubmitChanges.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end dgItems_SelectionChanged()
        #endregion // Event Methods


        #region User Input Validation
        /// <summary>
        /// This method validates user input for the item name and item description text boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEditItemNameOrDescrp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters to be entered
                if (!(e.Key >= Key.A && e.Key <= Key.Z))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter || e.Key == Key.Space))
                    {
                        //No other keys allowed besides numbers, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end tbEditItemNameOrDescrp_PreviewKeyDown()


        /// Source for the following three validation functions:
        /// https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf/65964280#65964280
        /// <summary>
        /// This method determines if item cost text input matches numRegex.
        /// </summary>
        /// <param name="text">The text being entered.</param>
        /// <returns>If the text matches the format of numRegex.</returns>
        private static bool IsTextAllowed(string text)
        {
            try
            {
                return numRegex.IsMatch(text);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end IsTextAllowed()


        /// <summary>
        /// This method determines if item cost test input is allowed.
        /// </summary>
        /// <param name="tb">The item cost text box being checked.</param>
        /// <param name="text">The text in the item cost text box.</param>
        /// <returns>Whether or not the text is allowed.</returns>
        private bool IsAllowed(TextBox tb, string text)
        {
            try
            {
                bool isAllowed = true;
                if (tb != null)
                {
                    string currentText = tb.Text;
                    if (!string.IsNullOrEmpty(tb.SelectedText))
                        currentText = currentText.Remove(tb.CaretIndex, tb.SelectedText.Length);
                    isAllowed = IsTextAllowed(currentText.Insert(tb.CaretIndex, text));
                }
                return isAllowed;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end IsAllowed()


        /// <summary>
        /// This method validates user input for the item cost text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEditItemCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                tbEditItemCost.IsReadOnly = false;
                e.Handled = !IsAllowed(sender as TextBox, e.Text);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end tbEditItemCost_PreviewTextInput()


        /// <summary>
        /// This method is called when a key is pressed in the the edit item cost text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEditItemCost_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Space)
                {
                    // Don't allow spaces.
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end tbEditItemCost_PreviewKeyDown()


        /// Source: https://stackoverflow.com/questions/3051144/how-to-suppress-cut-copy-and-paste-operations-in-textbox-in-wpf
        /// <summary>
        /// This method is used to keep the user from pasting incorrectly formatted data into the item cost text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                if (e.Command == ApplicationCommands.Cut ||
                    e.Command == ApplicationCommands.Copy ||
                    e.Command == ApplicationCommands.Paste)
                {
                    e.CanExecute = false;
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        } // end HandleCanExecute
        #endregion // User Input Validation

        #endregion // Methods
    } // end wndItems
} // end namespace
