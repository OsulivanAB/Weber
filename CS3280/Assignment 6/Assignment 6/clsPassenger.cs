using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class clsPassenger
    {
        #region Attributes
        /// <summary>
        /// COrresponds to the database flightID
        /// </summary>
        internal int iflightID { get; set; }
        /// <summary>
        /// Corresponds to the database passenger id
        /// </summary>
        internal int iPassenger_ID { get; set; }
        /// <summary>
        /// Corresponds to the passengers First Name
        /// </summary>
        internal string FirstName { get; set; }
        /// <summary>
        /// Corresponds to the passengers Last Name
        /// </summary>
        internal string LastName { get; set; }
        /// <summary>
        /// Seat number on flight
        /// </summary>
        internal string SeatNumber { get; set; }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// Constructor
        public clsPassenger(int flightID, int passengerID, string firstName, string lastName, string seatNumber)
        {
            try
            {
                iflightID = flightID;
                iPassenger_ID = passengerID;
                FirstName = firstName;
                LastName = lastName;
                SeatNumber = seatNumber;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Overrides the toString() method
        /// </summary>
        /// <returns>LastName, FirstName</returns>
        public override string ToString()
        {
            try
            {
                return LastName + ", " + FirstName;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
