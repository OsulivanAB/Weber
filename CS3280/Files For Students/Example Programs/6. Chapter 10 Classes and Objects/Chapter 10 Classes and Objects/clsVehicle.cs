using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter_10_Classes_and_Objects
{
    class clsVehicle
    {

        #region attributes

        /// <summary>
        /// Make
        /// </summary>
        private string sMake;

        /// <summary>
        /// Model
        /// </summary>
        private string sModel;

        /// <summary>
        /// Color
        /// </summary>
        public string sColor;

        /// <summary>
        /// Constant class level variable that declares that a vehicle has four wheels
        /// </summary>
        private const int iNumberOfWheels = 4;

        /// <summary>
        /// Readonly class level variable that sets the Top Speed in the constructor
        /// </summary>
        private readonly string sTopSpeed;

        /// <summary>
        /// Static variable that keeps track of the number of vehicle objects
        /// </summary>
        private static int iNumberOfVehicles;

        #endregion

        #region constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public clsVehicle()
        {
            sColor = "";
            sMake = "";
            sModel = "";
            sTopSpeed = "100 mph";
            iNumberOfVehicles += 1;
        }

        /// <summary>
        /// Constructor that takes one argument
        /// </summary>
        /// <param name="sTopSpeed"></param>
        public clsVehicle(string sTopSpeed)
        {
            this.sTopSpeed = sTopSpeed;
            sColor = "";
            sMake = "";
            sModel = "";
            iNumberOfVehicles += 1;
        }

        /// <summary>
        /// Constructor that takes four arguments
        /// </summary>
        /// <param name="sVehicleTopSpeed"></param>
        /// <param name="sVehicleColor"></param>
        /// <param name="sVehicleMake"></param>
        /// <param name="sVehicleModel"></param>
        public clsVehicle(string sVehicleTopSpeed, string sVehicleColor, string sVehicleMake, string sVehicleModel)
        {
            sColor = sVehicleColor;
            sMake = sVehicleMake;
            sModel = sVehicleModel;
            sTopSpeed = sVehicleTopSpeed;
            iNumberOfVehicles += 1;
        }

        #endregion

        #region properties

        public string Make
        {
            get
            {
                return sMake;
            }

            set
            {
                sMake = value;
            }

        }

        public string Model
        {
            get
            {
                return sModel;
            }

            set
            {
                sModel = value;
            }

        }

        //Static property for the variable iNumberOfVehicles
        public static int NumberOfVehicles
        {
            get
            {
                return iNumberOfVehicles;
            }

            set
            {
                iNumberOfVehicles = value;
            }
        }


        #endregion

        #region methods

        /// <summary>
        /// Public static method to start the vehicle
        /// </summary>
        /// <returns></returns>
        public static string StartVehicle()
        {
            return "The Vehicle is started" + " and the number of vehicles is " + iNumberOfVehicles;

            //NOTE: The following line is invalid.  Static methods may only access static attributes.
            //sColor = "Blue";
        }

        /// <summary>
        /// Public static method to stop the vehicle
        /// </summary>
        /// <returns></returns>
        public static string StopVehicle()
        {
            return "The Vehicle is stopped" + " and the number of vehicles is " + iNumberOfVehicles;
        }

        /// <summary>
        /// A private method. This method may not be seen outside this class.
        /// </summary>
        private void ThisIsAPrivateMethod()
        {
            int MyInt;

            //NOTE: Normal methods may access and use static variables
            MyInt = iNumberOfVehicles;
        }

        /// <summary>
        /// A public method.  This method may be seen outside this class.
        /// </summary>
        public void ThisIsAPublicMethod()
        {
        }

        #endregion

    }
}
