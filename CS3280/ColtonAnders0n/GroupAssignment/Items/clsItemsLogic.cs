using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Items
{


    public class clsItemsLogic
    {

        #region Attributes
        /// <summary>
        /// The database accessed by the data access class.
        /// </summary>
        private static clsDataAccess database;
        #endregion // Attributes


        #region Constructor(s)
        /// <summary>
        /// The default constructor for clsItemsLogic.
        /// </summary>
        public clsItemsLogic()
        {
            try
            {
                database = new clsDataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end clsItemsLogic()
        #endregion // Constructor(s)


        #region Methods

        /// <summary>
        /// This method gets all items from the database and adds them to an Observable Collection of items.
        /// </summary>
        /// <param name="lstItems">The Observable Collection to be loaded.</param>
        public void getItems(ref ObservableCollection<clsItem> lstItems)
        {
            try
            {
                // Number of rows returned from a query.
                int iNumRetValues = 0;

                // A dataset of items in the database.
                DataSet dsItems;

                string sSQL = clsItemsSQL.selectItemInfo();

                dsItems = database.ExecuteSQLStatement(sSQL, ref iNumRetValues);

                for (int i = 0; i < iNumRetValues; i++)
                {
                    lstItems.Add(new clsItem
                    {
                        SProductID = (int)dsItems.Tables[0].Rows[i][0],
                        SProductName = dsItems.Tables[0].Rows[i][1].ToString(),
                        SProductDescription = dsItems.Tables[0].Rows[i][2].ToString(),
                        DProductPrice = (double)dsItems.Tables[0].Rows[i][3],
                        BProductActive = (bool)dsItems.Tables[0].Rows[i][4]
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end getItems()


        /// <summary>
        /// This method adds the invoice ID of any invoice that includes a specified item.
        /// </summary>
        /// <param name="item">The specified item.</param>
        /// <param name="lstInvoicesWithItem">A list of invoice IDs belonging to Invoices containing the specified item.</param>
        public void invoicesWithItem(clsItem item, ref ObservableCollection<int> lstInvoicesWithItem)
        {
            try
            {
                int iNumRetVals = 0;

                DataSet dsInvoices;

                string sSQL = clsItemsSQL.selectInvoicesWithItem(item.SProductID.ToString());

                // Put selected Invoice IDs in data set.
                dsInvoices = database.ExecuteSQLStatement(sSQL, ref iNumRetVals);

                // Add invoice IDs to list.
                for (int i = 0; i < iNumRetVals; i++)
                {
                    lstInvoicesWithItem.Add((int)dsInvoices.Tables[0].Rows[i][0]);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end invoicesWithItem()


        /// <summary>
        /// This method adds a new item to the table and database.
        /// </summary>
        /// <param name="itemName">The new item's name.</param>
        /// <param name="itemDesc">The new item's description.</param>
        /// <param name="itemCost">The new item's cost.</param>
        /// <param name="lstItems">The Observable Collection of items to be updated.</param>
        public void  addNewItem(string itemName, string itemDesc, string itemCost, ref ObservableCollection<clsItem> lstItems)
        {
            try
            {
                //Convert itemCost to Double.
                double dItemCost = double.Parse(itemCost, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);

                // add item
                string sSQL = clsItemsSQL.insertNewItem(itemName, itemDesc, dItemCost.ToString());
                database.ExecuteNonQuery(sSQL);

                // Clear the list so the entire product table isn't added again.
                lstItems.Clear();

                // Add the updated product table to lstItems.
                getItems(ref lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end addNewItem()


        /// Source for converting string with dollar sign to double: https://stackoverflow.com/questions/14162357/convert-currency-string-to-decimal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedIndex">The index of the items data grid that was selected.</param>
        /// <param name="itemID">The item's ID.</param>
        /// <param name="itemName">The item's name.</param>
        /// <param name="itemDesc">The item's description.</param>
        /// <param name="itemCost">The item's cost.</param>
        /// <param name="lstItems">The observable collection of items to be updated.</param>
        public void editItem(int selectedIndex, string itemID, string itemName, string itemDesc, string itemCost, ref ObservableCollection<clsItem> lstItems)
        {
            try
            {
                //Convert itemCost to Double.
                double dItemCost  = double.Parse(itemCost, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);

                // Edit item in database.
                string sSQL = clsItemsSQL.updateItemInfo(itemID, itemName, itemDesc, dItemCost.ToString());
                database.ExecuteNonQuery(sSQL);

                // Update lstItems to reflect the changes.
                lstItems[selectedIndex].SProductName = itemName;
                lstItems[selectedIndex].SProductDescription = itemDesc;
                lstItems[selectedIndex].DProductPrice = dItemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end editItem()


        /// <summary>
        /// This method deletes an item if it is not on an invoice.
        /// </summary>
        /// <param name="item">The item to be deleted.</param>
        /// <param name="lstInvoicesWithItem">The list of invoice ID(s) whose Invoice(s) contain(s) the selected item.</param>
        /// <param name="lstItems">The observable collection of items to be updated.</param>
        /// <returns>True if item can be deleted. False if not.</returns>
        public bool deleteItem(clsItem item, ref ObservableCollection<int> lstInvoicesWithItem, ref ObservableCollection<clsItem> lstItems)
        {
            try
            {
                lstInvoicesWithItem.Clear();
                invoicesWithItem(item, ref lstInvoicesWithItem);

                // If the item is not part of an Invoice.
                if (lstInvoicesWithItem.Count == 0)
                {
                    // Delete the item.
                    string sSQL = clsItemsSQL.deleteItem(item.SProductID.ToString());
                    database.ExecuteNonQuery(sSQL);

                    // Clear the list of items
                    lstItems.Clear();

                    // Add the updated product table to lstItems.
                    getItems(ref lstItems);

                    // Let the main window know that the item was not on an invoice and was deleted.
                    return true;
                }
                // If the item is on an invoice.
                else
                {
                    // Do not delete the item and let the main window know that the item was on an invoice.
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end deleteItem()
        #endregion // Methods
    } // end clsItemsLogic
}// end namespace
