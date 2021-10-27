using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment_5
{
    /// <summary>
    /// Math Problem Class.
    /// </summary>
    public class clsMathProblem
    {
        /// <summary>
        /// The problems first number
        /// </summary>
        public int iFirstNumber { get; set; }
        /// <summary>
        /// The problems second number
        /// </summary>
        public int iSecondNumber { get; set; }
        /// <summary>
        /// The problems answer
        /// </summary>
        public int iAnswer { get; set; }
        /// <summary>
        /// The opperator used in the math problem
        /// </summary>
        public string sOperator { get; set; }
        /// <summary>
        /// Random number generator
        /// </summary>
        private Random rndNumber;

        /// <summary>
        /// Constructor to create clsMathProblem
        /// </summary>
        /// <param name="">Opperator tag.</param>
        public clsMathProblem(string op, Random rnd)
        {
            try
            {
                rndNumber = rnd;
                switch (op)
                {
                    case "Add":
                        sOperator = "+";    // Set sOperator Value
                        generateAddition(); // Generate Random addition problem
                        break;
                    case "Sub":
                        sOperator = "-";    // Set sOperator Value
                        generateSubtraction();  // Generate random subtraction problem.
                        break;
                    case "Mul":
                        sOperator = "×";
                        generateMultiplication();   // Generate random multiplication problem.
                        break;
                    case "Div":
                        sOperator = "÷";
                        generateDivision(); // Generate a random division problem
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Generates an appropriate addition problem
        /// </summary>
        private void generateAddition()
        {
            try
            {
                iFirstNumber = rndNumber.Next(1, 11);   // Generate a random number for iFirstNumber
                iSecondNumber = rndNumber.Next(1, 11);  // Generate a random number for iSecondNumber
                iAnswer = iFirstNumber + iSecondNumber; // Calculate the answer
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Generates an appropriate subtraction problem
        /// </summary>
        private void generateSubtraction()
        {
            try
            {
                do
                {
                    iFirstNumber = rndNumber.Next(1, 11);   // Generate a random number for iFirstNumber
                    iSecondNumber = rndNumber.Next(1, 11);  // Generate a random number for iSecondNumber
                    iAnswer = iFirstNumber - iSecondNumber; // Calculate the answer
                } while (iAnswer < 0);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Generates an appropriate multiplication problem
        /// </summary>
        private void generateMultiplication()
        {
            try
            {
                iFirstNumber = rndNumber.Next(1, 11);   // Generate a random number for iFirstNumber
                iSecondNumber = rndNumber.Next(1, 11);  // Generate a random number for iSecondNumber
                iAnswer = iFirstNumber * iSecondNumber; // Calculate the answer
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Generates an appropriate division problem
        /// </summary>
        private void generateDivision()
        {
            try
            {
                do
                {
                    iFirstNumber = rndNumber.Next(1, 11);   // Generate a random number for iFirstNumber
                    iSecondNumber = rndNumber.Next(1, 11);  // Generate a random number for iSecondNumber
                    iAnswer = iFirstNumber / iSecondNumber; // Calculate the answer
                } while (iFirstNumber % iSecondNumber != 0);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Override the toString() method so that it works with our object.
        /// </summary>
        /// <returns>Formula string of the math problem.</returns>
        public override string ToString()
        {
            try
            {
                return iFirstNumber.ToString() + " " + sOperator + " " + iSecondNumber.ToString() + " = ";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
