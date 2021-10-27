using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
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
        internal void DeleteFlightPassenger(clsFlight currentFlight, clsPassenger currentPassenger)
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
        /// <summary>
        /// Attempts to update the passengers current seat.
        /// </summary>
        /// <param name="currentFlight">Flight to change seat on.</param>
        /// <param name="currentPassenger">Passenger who's seat is changing.</param>
        /// <param name="sSeatSelection">Seat Selection.</param>
        /// <returns>True for successful update, false for failure.</returns>
        internal bool UpdateSeat(clsFlight currentFlight, clsPassenger currentPassenger, string sSeatSelection)
        {
            try
            {
                // Validate selected seat as a valid number
                if (!Int32.TryParse(sSeatSelection, out int iSeatSelection) || iSeatSelection <= 0)
                {
                    throw new Exception();
                }
                // Validate that the seat isn't already taken
                foreach (var _passenger in currentFlight.lstPassengers)
                {
                    if (_passenger.SeatNumber == sSeatSelection && _passenger.iPassenger_ID != currentPassenger.iPassenger_ID)
                    {
                        throw new Exception();
                    }
                }

                // Create SQL String
                string sSQL = string.Format(
                    "Update Flight_Passenger_Link " +
                    "Set Seat_Number = {0} " +
                    "WHERE Flight_ID = {1} AND Passenger_ID = {2}", sSeatSelection, currentPassenger.iflightID, currentPassenger.iPassenger_ID);

                // Execute Query
                myDataAccess.ExecuteNonQuery(sSQL);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Creates new passenger on a given flight.
        /// </summary>
        /// <param name="flightID">Flight ID</param>
        /// <param name="Firstname">Passenger First Name.</param>
        /// <param name="Lastname">Passenger Last Name</param>
        /// <returns>Passenger ID, or -1 for failure.</returns>
        internal int addPassenger(int flightID, string Firstname, string Lastname)
        {
            try
            {
                // Validate the Flight ID
                if (!validateFlightID(flightID))
                {
                    return -1;
                }

                // Create Passenger
                int _passengerID = createPassenger(Firstname, Lastname);

                // Add Passender to flight
                addPassengerToFlight(_passengerID, flightID);

                return _passengerID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Adds an existing passenger to an existing flight.
        /// </summary>
        /// <param name="passengerID">Passenger ID.</param>
        /// <param name="flightID">Flidght ID.</param>
        private void addPassengerToFlight(int passengerID, int flightID)
        {
            try
            {
                if (validateFlightID(flightID) && validatePassengerID(passengerID) && !checkForFlightPassengerLink(passengerID, flightID))
                {
                    string sSQL = String.Format("INSERT INTO Flight_Passenger_Link (Flight_ID, Passenger_ID, Seat_Number) VALUES ({0}, {1}, 0)", flightID, passengerID);
                    int result = myDataAccess.ExecuteNonQuery(sSQL);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks if a passenger is already on a flight
        /// </summary>
        /// <param name="passengerID"></param>
        /// <param name="flightID"></param>
        /// <returns></returns>
        private bool checkForFlightPassengerLink(int passengerID, int flightID)
        {
            try
            {
                string sSQL = string.Format("SELECT COUNT(*) FROM Flight_Passenger_Link WHERE Flight_ID = {0} AND Passenger_ID = {1}", flightID, passengerID);
                string result = myDataAccess.ExecuteScalarSQL(sSQL);

                return (result == "1") ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks for passenger in database, if they don't exist then it creates a passenger.
        /// </summary>
        /// <param name="firstname">Passenger's First Name.</param>
        /// <param name="lastname">Passenger's Last Name.</param>
        /// <returns>Passenger ID</returns>
        private int createPassenger(string firstname, string lastname)
        {
            try
            {
                // Check to see if the passenger already exists
                string sSQL = String.Format("SELECT Passenger_ID FROM Passenger WHERE FIRST_NAME = '{0}' AND LAST_NAME = '{1}'", firstname, lastname);
                string result = myDataAccess.ExecuteScalarSQL(sSQL);

                // If there was not already a passenger in the database, create one
                if (result == "")
                {
                    // Create sql string to add Passenger to the database
                    sSQL = String.Format("INSERT INTO Passenger (FIRST_NAME, LAST_NAME) VALUES('{0}', '{1}')", firstname, lastname);
                    myDataAccess.ExecuteNonQuery(sSQL);


                    // Get passenger id from the database
                    sSQL = String.Format("SELECT Passenger_ID FROM Passenger WHERE FIRST_NAME = '{0}' AND LAST_NAME = '{1}'", firstname, lastname);
                    result = myDataAccess.ExecuteScalarSQL(sSQL);
                }

                // Convert string to an int value
                Int32.TryParse(result, out int iResult);
                return iResult;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Validates that a flight ID is real
        /// </summary>
        /// <param name="flightID">Flight ID to validate.</param>
        private bool validateFlightID(int flightID)
        {
            try
            {
                string sSQL = string.Format("SELECT COUNT(*) FROM Flight WHERE Flight_ID = {0}", flightID);
                string result = myDataAccess.ExecuteScalarSQL(sSQL);
                if (result != "1")
                {
                    throw new Exception("Invalid Flight ID");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Validates that a Passenger ID is real
        /// </summary>
        /// <param name="passengerID">Passenger ID to validate.</param>
        private bool validatePassengerID(int passengerID)
        {
            try
            {
                string sSQL = string.Format("SELECT COUNT(*) FROM Passenger WHERE Passenger_ID = {0}", passengerID);
                string result = myDataAccess.ExecuteScalarSQL(sSQL);
                if (result != "1")
                {
                    throw new Exception("Invalid Flight ID");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks for Passengers without flights and flight_passenger Links with invalid seats and removes them.
        /// </summary>
        internal void cleanFlightPassengers()
        {
            try
            {
                // Delete any Passenger / Flight Links where the seat number is 0. Seat 0 is used as a place holder while we wait for a seat to be chosen.
                myDataAccess.ExecuteNonQuery("DELETE FROM Flight_Passenger_Link WHERE Seat_Number = '0'");

                int iRetVal = -1;

                // Get list of Passengers without any flights
                DataSet ds = myDataAccess.ExecuteSQLStatement(
                    "SELECT Passenger.Passenger_ID " +
                    "FROM Passenger LEFT JOIN Flight_Passenger_Link ON Passenger.Passenger_ID = Flight_Passenger_Link.Passenger_ID " +
                    "GROUP BY Passenger.Passenger_ID " +
                    "HAVING COUNT(Flight_ID) <= 0", ref iRetVal);

                // Remove Passenger
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow _row = ds.Tables[0].Rows[i];
                    Int32.TryParse(_row.ItemArray[0].ToString(), out int _passengerID);
                    deletePassenger(_passengerID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Attempts to remove a passenger from the database.
        /// </summary>
        /// <param name="passengerID"></param>
        /// <returns></returns>
        internal bool deletePassenger(int passengerID)
        {
            try
            {
                if (myDataAccess.ExecuteNonQuery("DELETE FROM Passenger WHERE Passenger_ID = " + passengerID.ToString()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
