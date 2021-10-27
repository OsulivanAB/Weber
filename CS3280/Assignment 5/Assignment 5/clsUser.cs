using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment_5
{
    public class clsUser
    {
        #region Attributes
        /// <summary>
        /// Username of player
        /// </summary>
        public string sUserNmae { get; set; }

        /// <summary>
        /// Age of player
        /// </summary>
        int iAge;

        #endregion

        #region Properties

        /// <summary>
        /// Property to get and set the sUsername
        /// </summary>
        public string Name
        {
            get
            {
                return sUserNmae;
            }
            private set
            {
                if (value.Length > 0)
                {
                    sUserNmae = value;
                }
            }
        }

        /// <summary>
        /// Property to get and set iAge
        /// </summary>
        public int Age
        {
            get
            {
                return iAge;
            }
            private set
            {
                if (value >= 3 && value <= 10)
                {
                    iAge = value;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Constructor for clsUser
        /// </summary>
        public clsUser(string user, int age)
        {
			try
			{
                this.Name = user;
                this.Age = age;
            }
            catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

        /// <summary>
        /// Checks if a string is a valid user name
        /// </summary>
        /// <param name="user">User name</param>
        /// <returns>true = valid; false = invalid</returns>
        public static bool validateUserName(string user)
        {
            try
            {
                // Check to make sure length is greater than
                if (user.Length > 0)
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

        /// <summary>
        /// Checks if an int is a valid user age
        /// </summary>
        /// <param name="Age"></param>
        /// <returns>true = valid; false = invalid</returns>
        public static bool validateUserAge(int Age)
        {
            try
            {
                // Check to make sure the age is between 3 and 10
                if (Age >= 3 && Age <= 10)
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
