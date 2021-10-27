using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpAdvancedConcepts
{
    /// <summary>
    /// A static class that is used to create two extension methods for the string and integer types.
    /// </summary>
    public static class clsExtensionMethodds
    {

        /// <summary>
        /// Add one to the integer value that is contained in the string.  This method extends the string type.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int AddOneToStringValue(this string sMyString)
        {
            return Int32.Parse(sMyString) + 1;
        }

        /// <summary>
        /// Subtract one to the integer value.  This method extends the integer type. 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int SubtractOneToIntValue(this int iMyInt)
        {
            return iMyInt - 1;
        }

    }
}
