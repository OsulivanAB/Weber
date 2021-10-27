using System;
using System.Collections.Generic;
using System.Text;

namespace Chpt_21_DB_and_Add_Object_Combobox
{
    /// <summary>
    /// Holds data for a passenger
    /// </summary>
    class clsPassenger
    {
        //Class variables
        public string sID;
        public string sFirstName;
        public string sLastName;
        public string sSeat;
        public string sFlight;

        /// <summary>
        /// Override the ToString method so that this string is displayed in the combo box.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return sFirstName + " " + sLastName;
        }
    }
}
