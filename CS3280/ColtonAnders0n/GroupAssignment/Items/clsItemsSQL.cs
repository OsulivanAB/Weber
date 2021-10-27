using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Items
{
    public static class clsItemsSQL
    {
        #region Methods
        /// <summary>
        /// This SQL gets all items from the product table.
        /// </summary>
        /// <returns>All items on the product table.</returns>
        public static string selectItemInfo()
        {
            try
            {
                string sSQL = "SELECT ProductID, ProductName, ProductDescription, ProductPrice, ProductActive FROM tblProduct";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end selectItemInfo()


        /// <summary>
        /// This method gets all invoice IDs whose invoices that contain a given item.
        /// </summary>
        /// <param name="sProductID">The ProductID for the given item.</param>
        /// <returns>All invoice IDs whose invoices contain a given item.</returns>
        public static string selectInvoicesWithItem(string sProductID)
        {
            try
            {
                string sSQL = "SELECT DISTINCT(InvoiceID) FROM tblInvoiceItem WHERE ProductID = " + sProductID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end selectInvoicesWithItem()


        /// <summary>
        /// This method updates a given item's description and price.
        /// </summary>
        /// <param name="sProductID">The item's ProductID.</param>
        /// <param name="sProductName">The item's name.</param>
        /// <param name="sDescription">The description of the item.</param>
        /// <param name="sPrice">The price of an item.</param>
        /// <returns>An updated item. </returns>
        public static string updateItemInfo(string sProductID, string sProductName, string sDescription, string sPrice)
        {
            try
            {
                string sSQL = "UPDATE tblProduct SET ProductName = '" + sProductName + "',  ProductDescription = '" + sDescription + "', ProductPrice = " +
                               sPrice + " WHERE ProductID = " + sProductID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end updateItemInfo()


        /// <summary>
        /// This method creates and inserts a new item into the Product table.
        /// </summary>
        /// <param name="sDescription">Product description.</param>
        /// <param name="sPrice">Product price.</param>
        /// <returns>SQL to insert an item.</returns>
        public static string insertNewItem(string sProductName, string sDescription, string sPrice)
        {
            try
            {
                string sSQL = "INSERT INTO tblProduct(ProductName, ProductDescription, ProductPrice, ProductActive)" +
                              " VALUES('" + sProductName + "', '" + sDescription + "', " + sPrice + ", " + 0 +")";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }// end insertNewItem()

        /// <summary>
        /// This SQL deletes an item from the product table.
        /// </summary>
        /// <param name="sProductID">A product's ID.</param>
        /// <returns>SQL to delete an item.</returns>
        public static string deleteItem(string sProductID)
        {
            try
            {
                string sSQL = "DELETE FROM tblProduct WHERE ProductID = " + sProductID;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        } // end deleteItem()

        #endregion // Methods
    } // end clsItemsSQL
} // end namespace
