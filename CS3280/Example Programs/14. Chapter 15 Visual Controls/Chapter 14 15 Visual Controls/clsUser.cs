using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter_14_15_Visual_Controls
{
    /// <summary>
    /// User class
    /// </summary>
    class clsUser
    {
        /// <summary>
        /// User ID
        /// </summary>
        private string sID;

        /// <summary>
        /// First Name
        /// </summary>
        private string sFirstName;

        /// <summary>
        /// Last Name
        /// </summary>
        private string sLastName;

        /// <summary>
        /// Constructor
        /// </summary>
        public clsUser()
        {
            sID = "";
            sFirstName = "";
            sLastName = "";
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="sUserID"></param>
        /// <param name="sF_Name"></param>
        /// <param name="sL_Name"></param>
        public clsUser(string sUserID, string sF_Name, string sL_Name)
        {
            sID = sUserID;
            sFirstName = sF_Name;
            sLastName = sL_Name;
        }

        /// <summary>
        /// Property for the ID
        /// </summary>
        public string ID
        {
            get
            {
                return sID;
            }

            set
            {
                sID = value;
            }
        }

        public string DisplayText
        {
            get
            {
                return sID + " - " + sFirstName + " " + sLastName;
            }
        }

        /// <summary>
        /// Override the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return sFirstName + " " + sLastName;
        }
    }
}
