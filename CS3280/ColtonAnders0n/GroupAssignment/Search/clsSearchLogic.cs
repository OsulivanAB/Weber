using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Data;

namespace GroupAssignment.Search
{
    class clsSearchLogic
    {
        #region Attributes
        /// <summary>
        /// List of all invoices
        /// </summary>
        private List<clsInvoice> myInvoices { get; set; }
        /// <summary>
        /// Class that handles all the database querying 
        /// </summary>
        private clsSearchSQL mySQL;
        /// <summary>
        /// Data access class
        /// </summary>
        clsDataAccess myDataAccess;
        #endregion

        #region Methods
        /// <summary>
        ///  Default Constructor
        /// </summary>
        public clsSearchLogic()
        {
            try
            {
                // Instantiate the sql class
                mySQL = new clsSearchSQL();

                // Instantiate the data access class
                myDataAccess = new clsDataAccess();

                // Get all invoices from the database
                myInvoices = getAllInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Gets all invoices
        /// </summary>
        /// <returns>List of Invoice Objects.</returns>
        public List<clsInvoice> getAllInvoices()
        {
            try
            {
                // Create list to hold the invoices
                List<clsInvoice> lstInvoiceList = new List<clsInvoice>();
                int iRetVal = -1;

                // Get Invoice Data from database
                string sSQL = mySQL.GetInvoiceData();
                DataSet dsInvoices = myDataAccess.ExecuteSQLStatement(sSQL, ref iRetVal);

                // Loop through Invoices and create an invoice item for each
                for (int i = 0; i < iRetVal; i++)
                {
                    // Create variable to hold the data row
                    DataRow myRow = dsInvoices.Tables[0].Rows[i];

                    // Create variables for each column in the row and convert them to the appropriate data types
                    int InvoiceID = (int)myRow[0];
                    string FirstName = (string)myRow[1];
                    string LastName = (string)myRow[2];
                    DateTime InvoiceDate = (DateTime)myRow[3];
                    bool IsOnline = (bool)myRow[4];
                    string PaymentMethod = (string)myRow[5];
                    string InvoiceStatus = (string)myRow[6];

                    // Create list of items associated with this invoice
                    List<clsItem> lstItems = getItems(InvoiceID);
                    // Create new invoice Item
                    clsInvoice myInvoice = new clsInvoice(InvoiceID, FirstName, LastName, InvoiceDate, IsOnline, PaymentMethod, InvoiceStatus, lstItems);

                    // Add this invoice to the list of invoices
                    lstInvoiceList.Add(myInvoice);
                }

                // Return invoices
                return lstInvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Gather the list of items for a given invoice.
        /// </summary>
        /// <param name="invoiceID">Corresponds to [tblInvoice].[InvoiceID]</param>
        /// <returns>List of Item objects</returns>
        private List<clsItem> getItems(int invoiceID)
        {
            try
            {
                // Create list to hold the items
                List<clsItem> lstItems = new List<clsItem>();
                // Create Variable to hold the nubmer of rows returned
                int iRetVal = -1;

                // Get Item Data from database
                DataSet dsItems = myDataAccess.ExecuteSQLStatement(mySQL.GetLineItemeData(invoiceID), ref iRetVal);

                // Loop through Items and create an item object for each
                for (int i = 0; i < iRetVal; i++)
                {
                    // Create variable to hold the data row
                    DataRow myRow = dsItems.Tables[0].Rows[i];

                    // Create variables for each of the columns and convert the values
                    int ProductID = (int)myRow[0];
                    string ProductName = (string)myRow[1];
                    string ProductDescription = (string)myRow[2];
                    double ItemPrice = (double)myRow[3];
                    bool ProductActive = (bool)myRow[4];

                    // Create the item object
                    clsItem myItem = new clsItem(ProductID, ProductName, ProductDescription, ItemPrice, ProductActive);

                    // Add the item to the list
                    lstItems.Add(myItem);
                }
                return lstItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Gets the data to display on screen but applys the necessary filters
        /// </summary>
        /// <param name="sInvoiceID">User Input for user ID text box.</param>
        /// <param name="sFirstName">User Input for First name text box.</param>
        /// <param name="sLastName">User Input for Last name text box.</param>
        /// <param name="selectedDate">User input for Date.</param>
        /// <param name="PaymentIndex">User input for payment method</param>
        /// <param name="OnlineIndex">User input for online order?</param>
        /// <param name="StatusIndex">User input for order status</param>
        /// <returns>Filtered list of invoices</returns>
        internal IEnumerable getFilteredData(
                                             string sInvoiceID,
                                             string sFirstName,
                                             string sLastName,
                                             DateTime? selectedDate,
                                             int PaymentIndex,
                                             int OnlineIndex,
                                             int StatusIndex)
        {
            try
            {
                // Create initial query that has no conditions
                var query =
                    from i in myInvoices
                    select i;

                // Check if the user input an Invoice ID
                if (sInvoiceID.Length > 0 && sInvoiceID != "Invoice ID")
                {
                    int iInvoiceID = -1;

                    Int32.TryParse(sInvoiceID, out iInvoiceID);

                    query = query.Where(w => w.invoice == iInvoiceID);
                }

                // Add first name filter if necessary
                if (sFirstName.Length > 0 && sFirstName != "First Name")
                {
                    query = query.Where(w => w.firstName == sFirstName);
                }

                // Add Last Name Filter if necessary
                if (sLastName.Length > 0 && sLastName != "Last Name")
                {
                    query = query.Where(w => w.lastName == sLastName);
                }

                // Add date filter if necessary
                if (selectedDate != null)
                {
                    query = query.Where(w => w.invoiceDate == selectedDate);
                }

                /// add Payment filter if necessary
                /// -1 = No Selection
                ///  0 = Cash
                ///  1 = Card
                ///  2 = Check
                switch (PaymentIndex)
                {
                    case -1:
                        // No Action Needed
                        break;
                    case 0:
                        query = query.Where(w => w.PaymentMethod == "Cash");
                        break;
                    case 1:
                        query = query.Where(w => w.PaymentMethod == "Card");
                        break;
                    case 2:
                        query = query.Where(w => w.PaymentMethod == "Check");
                        break;
                }

                /// add Online filter if necessary
                /// -1 = No Selection
                ///  0 = True (Online only)
                ///  1 = False (In-Store Only)
                switch (OnlineIndex)
                {
                    case -1:
                        // No Action Needed
                        break;
                    case 0:
                        query = query.Where(w => w.IsOnline == true);
                        break;
                    case 1:
                        query = query.Where(w => w.IsOnline == false);
                        break;
                }

                /// add Payment filter if necessary
                /// -1 = No Selection
                ///  0 = "Paid"
                ///  1 = "Unpaid"
                switch (StatusIndex)
                {
                    case -1:
                        // No Action Needed
                        break;
                    case 0:
                        query = query.Where(w => w.status == "Paid");
                        break;
                    case 1:
                        query = query.Where(w => w.status == "Unpaid");
                        break;
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Calculates the minimum date from a list of invoices
        /// </summary>
        /// <param name="myInvoiceList">List of invoices.</param>
        /// <returns>Minimum Invoice Date.</returns>
        internal DateTime getMinDate(IEnumerable myInvoiceList)
        {
            try
            {
                DateTime minDate = DateTime.Today;
                foreach (clsInvoice invoice in myInvoiceList)
                {
                    minDate = (invoice.invoiceDate < minDate) ? invoice.invoiceDate : minDate;
                }
                return minDate;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Calculates the minimum date from a list of invoices
        /// </summary>
        /// <param name="myInvoiceList">List of invoices.</param>
        /// <returns>Maximum Invoice Date</returns>
        internal DateTime getMaxDate(IEnumerable myInvoiceList)
        {
            try
            {
                // variable to keep track of the maximum date. Default = Minimum date
                DateTime maxDate = getMinDate(myInvoiceList);
                foreach (clsInvoice invoice in myInvoiceList)
                {
                    maxDate = (invoice.invoiceDate > maxDate) ? invoice.invoiceDate : maxDate;
                }
                return maxDate;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
