using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    /// <summary>
    /// Class to manage flights with.
    /// </summary>
    class clsFlightManager
    {
        #region Attributes
        /// <summary>
        /// Object that will allow us to access the database.
        /// </summary>
        clsDataAccess myDataAccess;
        #endregion

        #region Properties
        #endregion

        #region Methods
        internal clsFlightManager()
        {
            try
            {
                // Set up data access
                myDataAccess = new clsDataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// Create a constructor

        /// <summary>
        /// Gets the list of flights from the database and returns them 
        /// </summary>
        /// <returns>List of Flight Objects for all flights.</returns>
        internal List<clsFlight> GetFlights()
        {
            try
            {
                // List to hold flights
                List<clsFlight> lstFlights = new List<clsFlight>();
                // String to hold SQL statement
                string sSQL = "Select * from Flight";
                // Int variable to hold returned rows
                int iRetVal = 0;
                // Execute SQL
                DataSet myFlightData = myDataAccess.ExecuteSQLStatement(sSQL, ref iRetVal);
                // Populate List
                foreach (DataRow row in myFlightData.Tables[0].Rows)
                {
                    // Get FLight info from the table
                    int flightID = (int)row[0];
                    string FlightNumber = (string)row[1];
                    string AircraftType = (string)row[2];
                    // Get Passenger info
                    List<clsPassenger> passengerList = getPassengers(flightID);
                    // Create clsFlight object
                    clsFlight newFlight = new clsFlight(flightID, FlightNumber, AircraftType, passengerList);
                    lstFlights.Add(newFlight);
                }

                return lstFlights;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// gets a list of passengers from the database
        /// </summary>
        /// <param name="flightID">Flight ID corresponding to the database</param>
        /// <returns>List of clsPassenger objects for each passenger on the flight</returns>
        private List<clsPassenger> getPassengers(int flightID)
        {
            try
            {
                // List to hold the clsPassenger objects
                List<clsPassenger> lstPassengers = new List<clsPassenger>();
                // String to hold SQL statement
                string sSQL = String.Format(
                    "SELECT a.Passenger_ID, b.First_Name, b.Last_Name, a.Seat_Number " +
                    "FROM Flight_Passenger_Link a " +
                    "INNER JOIN Passenger b ON a.Passenger_ID = b.Passenger_ID " +
                    "WHERE a.Flight_ID = {0}", flightID.ToString());
                // Variable to hold the returned row count
                int iRetVal = 0;
                // Execute SQL
                DataSet myPassengerSet = myDataAccess.ExecuteSQLStatement(sSQL, ref iRetVal);

                // Loop through results to create clsPassenger objects and populate our list
                foreach (DataRow row in myPassengerSet.Tables[0].Rows)
                {
                    // Create variable to hold the data row
                    int passengerID = (int)row.ItemArray[0];
                    string firstName = (string)row.ItemArray[1];
                    string lastName = (string)row.ItemArray[2];
                    string seatNumber = (string)row.ItemArray[3];
                    // Create clsPassenger Object
                    clsPassenger newPassenger = new clsPassenger(flightID, passengerID, firstName, lastName, seatNumber);
                    // Add passenger to our list
                    lstPassengers.Add(newPassenger);
                }

                return lstPassengers;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Deletes a passenger from the database
        /// </summary>
        /// <param name="currentPassenger"></param>
        internal void DeletePassenger(clsFlight currentFlight, clsPassenger currentPassenger)
        {
            try
            {
                //Delete the passenger on database end
                string sSQL = string.Format("Delete FROM FLight_Passenger_link WHERE PASSENGER_ID = {0} AND FLIGHT_ID = {1}", currentPassenger.iPassenger_ID, currentPassenger.iflightID);
                myDataAccess.ExecuteNonQuery(sSQL);

                currentFlight.lstPassengers = getPassengers(currentPassenger.iflightID);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
