using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter_11_Inheritance
{
    class clsVehicle
    {

        #region attributes

        //NOTE: this has been changed to protected ///////////////////////////////////////////////////////////////////////////
        protected string sModel;
        
        //Color, Make, and Model of the Vehicle
        private string sMake;
        public string sColor;

        //Constant class level variable that declares that a vehicle has four wheels
        private const int iNumberOfWheels = 4;

        //Readonly class level variable that sets the Top Speed in the constructor
        private readonly string sTopSpeed;

        //Static variable that keeps track of the number of vehicle objects
        private static int iNumberOfVehicles;

        #endregion

        #region constructors

        //Default constructor
        public clsVehicle()
        {
            sColor = "";
            sMake = "";
            sModel = "";
            sTopSpeed = "100 mph";
            iNumberOfVehicles += 1;
        }

        //Constructor that takes one argument
        public clsVehicle(string sTopSpeed)
        {
            this.sTopSpeed = sTopSpeed;
            sColor = "";
            sMake = "";
            sModel = "";
            iNumberOfVehicles += 1;
        }

        //Constructor that takes one argument
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

        //Public static method to start the vehicle
        public static string StartVehicle()
        {
            return "The Vehicle is started" + " and the number of vehicles is " + iNumberOfVehicles;

            //NOTE: The following line is invalid.  Static methods may only access static attributes.
            //sColor = "Blue";
        }

       
        //Public static method to stop the vehicle
        public static string StopVehicle()
        {
            return "The Vehicle is stopped" + " and the number of vehicles is " + iNumberOfVehicles;
        }

        //A private method. This method may not be seen outside this class.
        private void ThisIsAPrivateMethod()
        {
            int MyInt;

            //NOTE: Normal methods may access and use static variables
            MyInt = iNumberOfVehicles;
        }

        //A public method.  This method may be seen outside this class.
        /// /////////////////////NOTE: This has been changed to a Virtual method ///////////////////////////////////////////////////////
        public virtual void ThisIsAPublicMethod()
        {
        }

        #endregion

    }
}
