using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter_12_Polymorphism
{
    class clsCar : clsVehicle
    {
        #region attributes

            //Attributes
            private string sSpoilerType;
            private bool bHas4WheelDrive;

            #endregion

        #region constructors

            //Default constructor
            public clsCar()
            {
                sSpoilerType = "";
                bHas4WheelDrive = false;
            }

            //Constructor that uses the base class constructor
            public clsCar(string SpoilerType, bool Has4WheelDrive, string sVehicleTopSpeed, string sVehicleColor, string sVehicleMake, string sVehicleModel)
                : base(sVehicleTopSpeed, sVehicleColor, sVehicleMake, sVehicleModel)
            {
                sSpoilerType = SpoilerType;
                bHas4WheelDrive = Has4WheelDrive;
            }

        #endregion

        #region properties

            public string SpoilerType
            {
                get
                {
                    return sSpoilerType;
                }

                set
                {
                    sSpoilerType = value;
                }
            }

            public bool Has4WheelDrive
        {
            get
            {
                return bHas4WheelDrive;
            }

            set
            {
                bHas4WheelDrive = value;
            }
        }

        #endregion

        #region methods

            //Overrides the public method in the base class
            public override void ThisIsAPublicMethod()
            {
                //Put in code for this class here

                //This class can access protected members of the base class
                base.sModel = "Ford";

                //Call the base class method
                base.ThisIsAPublicMethod();
            }

            //NOTE: Must override the abstract method ///////////////////////////////////////////////////////////////////////////////
            public override string AbstractMethodExample(string Mystring)
            {
                return "Class Car abstract method example, plus the string " + Mystring;
            }

        #endregion
    }
}
