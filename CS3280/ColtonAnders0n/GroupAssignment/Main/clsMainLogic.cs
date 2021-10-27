using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GroupAssignment.Main
{
    /// <summary>
    /// This class handles the business logic for retrieving invoice
    /// objects and items, as well as updating and saving invoice
    /// objects.
    /// </summary>
    static class clsMainLogic
    {

        #region Variables

        /// <summary>
        /// Object that manages access to sql database.
        /// </summary>
        private static clsMainSQL dataManager;

        /// <summary>
        /// Allows accessing the database handler class.
        /// </summary>
        private static clsDataAccess repo;

        /// <summary>
        /// Holds a public property of the current invoice being viewed.
        /// This object is updated by the search form.
        /// This object is used by the item form.
        /// </summary>
        private static clsInvoice currentInvoice;

        /// <summary>
        /// Holds a new invoice being created by the user.
        /// </summary>
        private static clsInvoice workingInvoice;

        /// <summary>
        /// Hold the status types of the invoice.
        /// </summary>
        private static List<string> statusTypes = new List<string>();

        /// <summary>
        /// Hold the payment types of the invoice.
        /// </summary>
        private static List<string> paymentTypes = new List<string>();

        #endregion



        #region Constructor

        /// <summary>
        /// Constructor that initalizes variables.
        /// </summary>
        static clsMainLogic()
        {
            try
            {
                //Initialize sql handler
                dataManager = new clsMainSQL();

                //Initialize database access object
                repo = new clsDataAccess();

                //Initialize empty invoice object
                currentInvoice = null;

                //Initialize possible statuses
                statusTypes.Add("Unpaid");
                statusTypes.Add("Paid");

                //Initialize possible payment types
                paymentTypes.Add("Cash");
                paymentTypes.Add("Card");
                paymentTypes.Add("Check");

                //Initialize the working invoice
                setWorkingInvoice(new clsInvoice(1, "null", "null", new DateTime(), false, "Cash", "Unpaid", new List<clsItem>()));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }

        #endregion



        #region Invoice Getters/Setters

        /// <summary>
        /// Gets the current invoice.
        /// </summary>
        /// <returns></returns>
        public static clsInvoice getCurrentInvoice()
        {
            try
            {
                return currentInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }

        /// <summary>
        /// Sets the current invoice.
        /// </summary>
        /// <param name="newInvoice"></param>
        public static void setCurrentInvoice(clsInvoice newInvoice)
        {
            try
            {
                currentInvoice = newInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the current invoice.
        /// </summary>
        /// <returns></returns>
        public static clsInvoice getWorkingInvoice()
        {
            try
            {
                return workingInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }

        /// <summary>
        /// Sets the current invoice.
        /// </summary>
        /// <param name="newInvoice"></param>
        public static void setWorkingInvoice(clsInvoice newInvoice)
        {
            try
            {
                workingInvoice = newInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }

        /// <summary>
        /// Get the status types of the invoice.
        /// </summary>
        /// <returns>A list of status types.</returns>
        public static List<string> getStatusTypes()
        {

            return statusTypes;
        }

        /// <summary>
        /// Get the payment types of the invoice.
        /// </summary>
        /// <returns>A list of payment types.</returns>
        public static List<string> getPaymentTypes()
        {

            return paymentTypes;
        }

        #endregion



        #region SQL methods

        /// <summary>
        /// Get a list of all available items.
        /// </summary>
        /// <returns></returns>
        public static List<clsItem> getAllItems()
        {
            try
            {
                //Number of return rows
                int numRows = 0;

                //Hold the returned query data
                DataSet foundItems;

                //Hold the found items
                List<clsItem> itemDataList = new List<clsItem>();

                //TODO: Actually get the items from the database
                foundItems = repo.ExecuteSQLStatement(dataManager.allItemSql(), ref numRows);


                //Loop through each row and convert to a model object
                for (int i = 0; i < numRows; i++)
                {

                    //Get data from row
                    int productId = int.Parse(foundItems.Tables[0].Rows[i][0].ToString());
                    string productName = foundItems.Tables[0].Rows[i][1].ToString();
                    string productDescription = foundItems.Tables[0].Rows[i][2].ToString();
                    double productPrice = double.Parse(foundItems.Tables[0].Rows[i][3].ToString());
                    bool active = bool.Parse(foundItems.Tables[0].Rows[i][4].ToString());

                    //Add new item to list
                    itemDataList.Add(new clsItem(productId, productName, productDescription, productPrice, active));
                }


                //Return the found items
                return itemDataList;
            }
            catch (Exception ex)
            {
                //Prevent shit hitting the fan
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }

        }



        /// <summary>
        /// Update an existing invoice.
        /// </summary>
        /// <param name="existingInvoice">The data object for the existing invoice.</param>
        public static void updateInvoice(clsInvoice existingInvoice)
        {
            try
            {
                //Save the invoice data to the database
                repo.ExecuteNonQuery(dataManager.updateInvoiceSql(existingInvoice));

                //Reset items associated with invoice
                repo.ExecuteNonQuery(dataManager.removeAllItems(existingInvoice.invoice));

                //Loop through each item
                foreach (clsItem item in existingInvoice.items)
                {
                    //Add item to database
                    repo.ExecuteNonQuery(dataManager.addItem(existingInvoice.invoice, item.SProductID));
                }

                //Update current invoice
                currentInvoice = existingInvoice;
            }
            catch (Exception ex)
            {
                //Prevent shit hitting the fan
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }



        /// <summary>
        /// Save a new invoice.
        /// </summary>
        /// <param name="newInvoice">The data object for the new invoice.</param>
        /// <returns>Returns true if the invoice was saved successfully.</returns>
        public static bool saveNewInvoice(clsInvoice newInvoice)
        {
            try
            {
                //Save the invoice data to the database
                repo.ExecuteNonQuery(dataManager.newInvoiceSql(newInvoice));

                //Get the invoice again (We need the invoices newly generated id)
                int id = int.Parse(repo.ExecuteScalarSQL(dataManager.findInvoiceIdForNewestInvoice()));

                //Reset items associated with invoice
                repo.ExecuteNonQuery(dataManager.removeAllItems(id));

                //Loop through each item
                foreach (clsItem item in newInvoice.items)
                {
                    //Add item to database
                    repo.ExecuteNonQuery(dataManager.addItem(id, item.SProductID));
                }

                //Update the correct working invoice and current invoice
                currentInvoice = newInvoice;
                workingInvoice = newInvoice;
            }
            catch (Exception ex)
            {
                //Prevent shit hitting the fan
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }

            //Return success
            return true;
        }



        /// <summary>
        /// Adds an item to the existing invoice and then saves the invoice
        /// to the database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static void AddItem(string invoice, clsItem product, int quantity)
        {
            try
            {
                //Add items to the invoice
                for (int i = 0; i < quantity; i++)
                {
                    if (invoice == "current")
                    {
                        currentInvoice.items.Add(product);
                    }
                    else
                    {
                        workingInvoice.items.Add(product);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                //Prevent shit hitting the fan
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }



        /// <summary>
        /// Reduces the quantity of a product. If the quantity is less
        /// than the total numbers of products, it removes the product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Returns false if the product is not in the invoice.</returns>
        public static bool DropItem(string invoiceType, clsInvoice invoice, clsItem product, int quantity)
        {
            try
            {
                //Get number of products in invoice currently
                int currentQuantity = 0;

                foreach (clsItem item in invoice.items)
                {
                    if (product.SProductID == item.SProductID)
                    {
                        currentQuantity++;
                    }
                }


                //Handle product removals
                if (currentQuantity == 0)
                {
                    //Product doesn't exist in invoice
                    return false;
                }
                else if (currentQuantity < quantity)
                {
                    //Track number of items deleted
                    int itemsDeleted = 0;

                    //Remove all found items
                    for (int i = 0; i < invoice.items.Count(); i++)
                    {
                        //Remove item
                        if (product.SProductID == invoice.items[i].SProductID)
                        {
                            //Remove the item
                            invoice.items.RemoveAt(i);

                            //Update tracker
                            itemsDeleted++;

                            //Reset index (length of list has changed!)
                            i = 0;
                        }

                        //End of removal
                        if (itemsDeleted == currentQuantity)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    //Track number of items deleted
                    int itemsDeleted = 0;

                    //Remove all found items
                    for (int i = 0; i < invoice.items.Count(); i++)
                    {
                        //Remove item
                        if (product.SProductID == invoice.items[i].SProductID)
                        {
                            //Remove the item
                            invoice.items.RemoveAt(i);

                            //Update tracker
                            itemsDeleted++;

                            //Reset index (length of list has changed!)
                            i = 0;
                        }

                        //End of removal
                        if (itemsDeleted == quantity)
                        {
                            break;
                        }
                    }
                }


                //Update actual invoice list
                if (invoiceType == "current")
                {
                    currentInvoice.items = invoice.items;
                }
                else
                {
                    workingInvoice.items = invoice.items;
                }

            }
            catch (Exception ex)
            {
                //Prevent shit hitting the fan
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }

            //Return success
            return true;
        }


        /// <summary>
        /// Deletes the given invoice.
        /// </summary>
        /// <param name="invoice">The invoice to be deleted.</param>
        /// <returns>Returns true if invoice was successfully deleted.</returns>
        public static bool removeInvoice(clsInvoice invoice)
        {
            try
            {
                //Remove invoice items
                repo.ExecuteNonQuery(dataManager.removeAllItems(invoice.invoice));

                //Remove the invoice
                repo.ExecuteNonQuery(dataManager.removeInvoice(invoice));
            }
            catch {
            
            }
            return true;
        }

        #endregion

    }
}
