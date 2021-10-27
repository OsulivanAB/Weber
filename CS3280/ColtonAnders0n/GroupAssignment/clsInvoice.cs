using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace GroupAssignment
{
    public class clsInvoice
    {
        #region Attributes
        /// <summary>
        /// Invoice ID
        /// </summary>
        private int iInvoiceNumber;
        /// <summary>
        /// First name
        /// </summary>
        private string sFirstName;
        /// <summary>
        /// Last Name
        /// </summary>
        private string sLastName;
        /// <summary>
        /// Date and time of the invoice
        /// </summary>
        private DateTime dtInvoiceDate;
        /// <summary>
        /// Payment Method used
        /// </summary>
        private string sPaymentMethod;
        /// <summary>
        /// Invoice Status
        /// </summary>
        private string sStatus;
        /// <summary>
        /// List of items on the invoice
        /// </summary>
        private List<clsItem> lstItems;
        /// <summary>
        /// True = Online Order, False = In-Person Order
        /// </summary>
        public bool IsOnline { get; set; }
        #endregion
        #region Properties
        /// <summary>
        /// Property to get invoice number. Invoice number shouldn't be changed from when it's used in the constructor though, so only get included.
        /// </summary>
        public int invoice
        {
            get
            {
                return iInvoiceNumber;
            }
            // Private so that the constructor can access it (and use it to validate input), but we don't want invoice numbers changing randomly.
            private set
            {
                try
                {
                    // Verify that the invoice number is positive and non-zero
                    if (value > 0)
                    {
                        iInvoiceNumber = value;
                    }
                    else
                    {
                        throw new Exception("Invoice number must be greater than 0.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Gets and sets the first name value
        /// </summary>
        public string firstName
        {
            get
            {
                return sFirstName;
            }
            set
            {
                try
                {
                    // Verify that the string is not blank
                    if (value.Length > 0)
                    {
                        sFirstName = value;
                    }
                    else
                    {
                        throw new Exception("firstName cannot be blank");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Gets and sets the last name value
        /// </summary>
        public string lastName
        {
            get
            {
                return sLastName;
            }
            set
            {
                try
                {
                    // Verify that the string is not blank
                    if (value.Length > 0)
                    {
                        sLastName = value;
                    }
                    else
                    {
                        throw new Exception("lastName cannot be blank");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Property to get and set the invoice date
        /// </summary>
        public DateTime invoiceDate
        {
            get
            {
                return dtInvoiceDate;
            }
            set
            {
                try
                {
                    // Verify that the date is not in the future
                    if (value <= DateTime.Now)
                    {
                        dtInvoiceDate = value;
                    }
                    else
                    {
                        throw new Exception("Invoice date cannot be in the future");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Property to get and set the payment method
        /// </summary>
        public string PaymentMethod
        {
            get
            {
                return sPaymentMethod;
            }
            set
            {
                try
                {
                    // Validate payment method string
                    if (value == "Card" || value == "Check" || value == "Cash")
                    {
                        sPaymentMethod = value;
                    }
                    else
                    {
                        throw new Exception("Invalid payment method. Payment Methods: {Card, Check, Cash}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Property to get and set the status of the invoice
        /// </summary>
        public string status
        {
            get
            {
                return sStatus;
            }
            set
            {
                try
                {
                    // Verify that the string is not blank
                    if (value == "Paid" || value == "Unpaid")
                    {
                        sStatus = value;
                    }
                    else
                    {
                        throw new Exception("Invalid status. Status: {Paid, Unpaid}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Property to get and set invoice items
        /// </summary>
        public List<clsItem> items
        {
            get
            {
                return lstItems;
            }
            set
            {
                try
                {
                    lstItems = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Sum of all items
        /// </summary>
        public double totalBalance
        {
            get
            {
                // Create variable to hold total balance
                double totalBalance = 0;

                // Loop through each item and add it to the total balance
                foreach (clsItem item in lstItems)
                {
                    totalBalance += item.DProductPrice;
                }

                totalBalance = Math.Round(totalBalance, 2);

                return totalBalance;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Constructor for the clsInvoice class.
        /// </summary>
        /// <param name="invoiceNumber">Corresponds to [tblInvoice].[InvoiceID]</param>
        /// <param name="firstName">Corresponds to [tblInvoice].[FirstName]</param>
        /// <param name="lastName">Corresponds to [tblInvoice].[LastName]</param>
        /// <param name="invoiceDate">Corresponds to [tblInvoice].[InvoiceDate]</param>
        /// <param name="isOnline">Corresponds to [tblInvoice].[IsOnline]</param>
        /// <param name="paymentMethod">Corresponds to [tblInvoice].[PaymentMethod]</param>
        /// <param name="InvoiceStatus">Corresponds to [tblInvoice].[InvoiceStatus]</param>
        /// <param name="items">List of clsItem objects from [tblInvoiceItem]</param>
        public clsInvoice(int invoiceNumber, string firstName, string lastName, DateTime invoiceDate, bool isOnline, string paymentMethod, string InvoiceStatus, List<clsItem> items)
        {
            try
            {
                // Set Variables using properties so that the info is validated as well
                this.invoice = invoiceNumber;
                this.firstName = firstName;
                this.lastName = lastName;
                this.invoiceDate = invoiceDate;
                this.IsOnline = isOnline;
                this.PaymentMethod = paymentMethod;
                this.status = InvoiceStatus;
                this.items = items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}