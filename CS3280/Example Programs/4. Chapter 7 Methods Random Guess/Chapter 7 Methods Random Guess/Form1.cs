using System;
using System.Windows.Forms;

namespace Chapter_7_Methods_Random_Guess
{
    public partial class Form1 : Form
    {
        #region  Attributes

        /// <summary>
        /// First number displayed
        /// </summary>
        private int iFirstNumber;

        /// <summary>
        /// Second number displayed
        /// </summary>
        private int iSecondNumber;

        #endregion

        #region Methods

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method picks two random numbers and displays them to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlay_Click(object sender, System.EventArgs e)
        {
            //Create a random number object
            Random rndNumber = new Random();

            //Using the random number object create two random numbers between 1 and 10
            iFirstNumber = rndNumber.Next(1, 11);
            iSecondNumber = rndNumber.Next(1, 11);

            //Displays the numbers to the user
            DisplayNumbers();

            //Clear the screen
            txtUserGuess.Text = "";
            lblAnswer.Text = "";
            lblRightWrong.Text = "";
        }

        /// <summary>
        /// This method displays the two random numbers.
        /// </summary>
        private void DisplayNumbers()
        {
            lblNumber1.Text = iFirstNumber.ToString();
            lblNumber2.Text = Convert.ToString(iSecondNumber);
        }

        /// <summary>
        /// This method gets the user's guess and calculates the result by calling the method
        /// CalculateResult.  The CalculateResult method also returns whether or not the
        /// user's guess is correct.  Based on if the user is right or wrong the appropriate
        /// message is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmit_Click(object sender, System.EventArgs e)
        {
            int iUserGuess = 0;				 //The user's guess
            bool bNumbersMatch = false;  //Whether or not the numbers match
            int iResult;				 //The result of the numbers

            //Get the user's guess
            iUserGuess = Int32.Parse(txtUserGuess.Text);

            //Calculate the result and find out if the user's guess is correct
            iResult = CalculateResult(iUserGuess, ref bNumbersMatch);

            //Display the answer
            lblAnswer.Text = iResult.ToString();

            //Display the appropriate message
            if (bNumbersMatch == true)
            {
                lblRightWrong.Text = "You are right!!!";
            }
            else
            {
                lblRightWrong.Text = "You are wrong!!!";
            }
        }

        /// <summary>
        /// This method calculates the result of the two random numbers and returns the result.
        /// This method also returns whether or not the user's guess is correct through a 
        /// reference parameter.
        /// </summary>
        /// <param name="iGuessedNumber">The number that the user guessed.</param>
        /// <param name="bIsMatch">A reference paramter that returns whether or not the user's guess was correct.</param>
        /// <returns>Result</returns>
        private int CalculateResult(int iGuessedNumber, ref bool bIsMatch)
        {
            int iCalcResult;	//The result of the addition

            //Calculate the Result
            iCalcResult = iFirstNumber + iSecondNumber;

            //Determine if the result of the addition matches the user's guess and set the 
            //reference parameter accordingly
            if (iCalcResult == iGuessedNumber)
            {
                bIsMatch = true;
            }
            else
            {
                bIsMatch = false;
            }

            //return the result of the calculation
            return iCalcResult;
        }

        #endregion
    }
}