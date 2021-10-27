using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace GroupAssignment.Search
{
    public class clsSearchSQL
    {
        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public clsSearchSQL() {}

        /// <summary>
        /// Queries the database for all invoices.
        /// </summary>
        /// <param name="iRetVal">Int Variable to store the returned rows</param>
        /// <returns></returns>
        internal string GetInvoiceData()
        {
            try
            {
                // SQL Query that will return all invoices
                return "SELECT InvoiceID, FirstName, LastName, InvoiceDate, IsOnline, PaymentMethod, InvoiceStatus FROM tblInvoice;";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Creates a SQL query to get the items on an invoice.
        /// </summary>
        /// <param name="invoiceID">Invoice ID.</param>
        /// <returns>SQL String</returns>
        internal string GetLineItemeData(int invoiceID)
        {
            try
            {
                // Create SQL Query to get all items for an invoice
                return String.Format(
                                            "SELECT b.* " +
                                            "FROM tblInvoiceItem a " +
                                            "INNER JOIN tblProduct b ON a.ProductID = b.ProductID " +
                                            "WHERE InvoiceID = {0}",
                                            invoiceID);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
