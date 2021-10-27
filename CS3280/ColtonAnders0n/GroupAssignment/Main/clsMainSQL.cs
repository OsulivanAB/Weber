using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Main
{
    /// <summary>
    /// This class handles pulling and saving data to the database using sql statements.
    /// Pulled data is formatted into a model object and returned to the caller.
    /// </summary>
    class clsMainSQL
    {

        #region SQL Statements

        /// <summary>
        /// Builds an sql statement that returns all items.
        /// </summary>
        /// <returns>The custom sql statement.</returns>
        public string allItemSql() {

            try
            {
                //Hold the sql statement
                string sql = "SELECT * " +
                             "FROM tblProduct";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Builds an sql statement that updates an existing invoice.
        /// </summary>
        /// <param name="existingInvoice"></param>
        /// <returns>The custom sql statement.</returns>
        public string updateInvoiceSql(clsInvoice existingInvoice) {

            try
            {
                //Hold the sql statement
                string sql = "UPDATE tblInvoice" + " " +
                             "SET FirstName = '" + existingInvoice.firstName + "', " +
                                 "LastName = '" + existingInvoice.lastName + "', " +
                                 "InvoiceDate = '" + existingInvoice.invoiceDate + "', " +
                                 "IsOnline = " + existingInvoice.IsOnline + ", " +
                                 "PaymentMethod = '" + existingInvoice.PaymentMethod + "', " +
                                 "InvoiceStatus = '" + existingInvoice.status + "' " +
                             "WHERE InvoiceID = " + existingInvoice.invoice;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Builds an sql statement that adds a new invoice.
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <returns>The custom sql statement.</returns>
        public string newInvoiceSql(clsInvoice newInvoice) {

            try
            {
                //Hold the sql statement
                string sql = "INSERT INTO tblInvoice" +
                             "(FirstName, LastName, InvoiceDate, IsOnline, PaymentMethod, InvoiceStatus)" + " " +
                             "VALUES (" + "'" + newInvoice.firstName + "', "
                                        + "'" + newInvoice.lastName + "', "
                                        + "'" + newInvoice.invoiceDate + "', "
                                        + "" + newInvoice.IsOnline + ", "
                                        + "'" + newInvoice.PaymentMethod + "', "
                                        + "'" + newInvoice.status + "')";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }   
        }



        /// <summary>
        /// Adds one item associated with an existing invoice.
        /// </summary>
        /// <param name="invoiceId">The id of the existing invoice.</param>
        /// <param name="productId">The id of the product being added</param>
        /// <returns>The custom sql statement.</returns>
        public string addItem(int invoiceId, int productId)
        {
            try
            {
                //Hold the sql statement
                string sql = sql = "INSERT INTO tblInvoiceItem(invoiceID, ProductID) " +
                    "VALUES (" + invoiceId + ", " + productId + ")";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Removes all items associated with an existing invoice.
        /// </summary>
        /// <param name="invoiceId">The id of the existing invoice.</param>
        /// <returns>The custom sql statement.</returns>
        public string removeAllItems(int invoiceId)
        {
            try
            {
                //Hold the sql statement
                string sql = "DELETE FROM tblInvoiceItem WHERE InvoiceID = " + invoiceId;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Deletes the given invoice.
        /// </summary>
        /// <param name="invoice">The invoice to be deleted.</param>
        /// <returns>The custom sql statement.</returns>
        public string removeInvoice(clsInvoice invoice)
        {
            try
            {
                //Hold the sql statement
                string sql = "DELETE FROM tblInvoice WHERE InvoiceID = " + invoice.invoice;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Gets the newest id.
        /// </summary>
        /// <returns>The custom sql statement.</returns>
        public string findInvoiceIdForNewestInvoice() {

            try
            {
                //Hold the sql statement
                string sql = "SELECT MAX(InvoiceID) FROM tblInvoice";

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

    }
}
