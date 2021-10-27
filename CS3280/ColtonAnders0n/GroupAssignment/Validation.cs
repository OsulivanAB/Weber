using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GroupAssignment
{

    /// <summary>
    /// This class sets input restrictions to textboxes and shows a dialog box when an exception occurs.
    /// </summary>
    static class Validation
    {


        #region Exception error dialog

        /// <summary>
        /// This method shows a dialog box with an error message.
        /// The error message is passed in using data from a handled exception.
        /// </summary>
        /// <param name="className">The class name passed in using reflection.</param>
        /// <param name="methodName">The method name passed in using reflection.</param>
        /// <param name="message">The error message passed in by the exception.</param>
        public static void showError(String className, String methodName, String message)
        {
            //Show error dialog if something went wrong
            String errorMsg = "An error has occurred!"
                + "\nClass: " + className
                + "\nLast Method: " + methodName
                + "\nTrace message: " + message;

            MessageBox.Show(errorMsg);
        }

        #endregion



        #region Textbox input restrictors

        ///// <summary>
        ///// This method restricts textboxes from only using numbers and symbols.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public static void LooseNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        //{
        //    try
        //    {
        //        Regex alphReg = new Regex("^[a-zA-Z]*$");
        //        e.Handled = alphReg.IsMatch(e.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
        //    }
        //}



        /// <summary>
        /// This method restricts textboxes from only using numbers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void StrictNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }



        /// <summary>
        /// This method restricts textboxes from only using alphabets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void StrictAlphabetValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex alphReg = new Regex("^[a-zA-Z]*$");
                e.Handled = !alphReg.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + MethodInfo.GetCurrentMethod().Name + " Details: " + ex.Message);
            }
        }

        #endregion

    }
}
