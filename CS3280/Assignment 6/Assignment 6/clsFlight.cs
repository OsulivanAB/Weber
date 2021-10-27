using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    /// <summary>
    /// Holds data associated with a flight.
    /// </summary>
    class clsFlight
    {
        #region Attributes
        /// <summary>
        /// Corresponds to the databases ID column
        /// </summary>
        private int iFlightID { get; set; }
        /// <summary>
        /// Holds the flight number
        /// </summary>
        internal string sFlightNumber { get; set; }
        /// <summary>
        /// Model of aircraft
        /// </summary>
        internal string sAircraftType { get; set; }
        /// <summary>
        /// List of passengers
        /// </summary>
        internal List<clsPassenger> lstPassengers { get; set; }
        #endregion

        #region Properties
        #endregion

        #region Methods
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="flightID">Flight ID that corresponds with the database.</param>
        /// <param name="FlightNumber">Flight Number</param>
        /// <param name="AircraftType">Aircraft Type</param>
        /// <param name="passengerList">List of clsPassenger Objects</param>
        internal clsFlight(int flightID, string FlightNumber, string AircraftType, List<clsPassenger> passengerList)
        {
            try
            {
                // Set Attributes
                this.iFlightID = flightID;
                this.sFlightNumber = FlightNumber;
                this.sAircraftType = AircraftType;
                this.lstPassengers = passengerList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Overrides the toString() method
        /// </summary>
        /// <returns>FlightNubmer - AircraftType</returns>
        public override string ToString()
        {
            try
            {
                return sFlightNumber + " - " + sAircraftType;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
