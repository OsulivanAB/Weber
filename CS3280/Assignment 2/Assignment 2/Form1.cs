using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        #region Attributes

        /// <summary>
        /// Number of games played.
        /// </summary>
        private int iNumPlayed = 0;

        /// <summary>
        /// Number of Games Won
        /// </summary>
        private int iNumWon = 0;

        /// <summary>
        /// Number of Games Lost
        /// </summary>
        private int iNumLost = 0;

        /// <summary>
        /// Array to hold the frequency that each die face occurs
        /// </summary>
        int[] iFrequency = { 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Array to keep track of the users guesses
        /// </summary>
        int[] iGuesses = { 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Array to keep track of the % of times each face appears
        /// </summary>
        decimal[] dPercent = { 0, 0, 0, 0, 0, 0 };

        #endregion

        #region Methods

        /// <summary>
        /// Initialize the actual UI and form with all the correct settings
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method generates a random roll of the dice, displays the dice, and updates the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Roll_Click(object sender, EventArgs e)
        {
            #region Attributes

            int iUserGuess = 0;     // The user's guess
            int iResult;    // Die Roll Result

            #endregion

            #region Get User Input
            // Get User Input
            Int32.TryParse(textBoxGuess.Text, out iUserGuess); // Attempt to Convert to Int Data Type
            if (iUserGuess == 0 || iUserGuess < 1 || iUserGuess > 6) // Check for Invalid Input
            {
                this.label_error.Visible = true;
                return; // If Invalid Input then do not proceed to dice roll
            }
            else // Clear Errors if valid input
            {
                this.label_error.Visible = false;
            }
            #endregion

            // Roll the dice
            iResult = RollDice();

            // Update Variables
            UpdateVariables(iUserGuess, iResult);

            // Output Results
            OutputResults();

            // Clear Input Textbox
            textBoxGuess.Text = "";

        }

        /// <summary>
        /// This method Resets the playing board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// This method Resets the playing board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_Click(object sender, EventArgs e)
        {
            // Reset all Labels
            label_numTimesPlayed_data.Text = "0";
            label_numTimesWon_data.Text = "0";
            label_numTimesLost_data.Text = "0";
            textBoxGuess.Text = "";
            richTextBox_results.Text = "";

            // Reset all Variables
            iNumPlayed = 0;
            iNumWon = 0;
            iNumLost = 0;

            // Reset values in iFrequency
            for (int i = 0; i < iFrequency.Length; i++)
            {
                iFrequency[i] = 0;
            }

            // Reset values in iGuesses
            for (int i = 0; i < iGuesses.Length; i++)
            {
                iGuesses[i] = 0;
            }

            // Reset values in dPercent
            for (int i = 0; i < dPercent.Length; i++)
            {
                dPercent[i] = 0;
            }
        }

        /// <summary>
        /// This method simulates a single dice roll.
        /// </summary>
        /// <returns>The integer value of the result of the dice roll</returns>
        private int RollDice()
        {
            Random rndNumber = new Random(); // Create a random number object
            int iRollLength = genRollLength(); // Number of times the die changes faces while rolling
            int iFace = 0; // Represents the current die face that is showing
            int iPreviousFace = 0; // Represents the previous die face that was showing

            // Loop to represent the die rolling
            for (int i = 0; i < iRollLength; i++)
            {
                iPreviousFace = iFace; // Set Previous Face Value

                // Loop to ensure each face change is a new number
                do
                {
                    iFace = rndNumber.Next(1, 7); // Generate random number between 1 and 6
                } while (iFace == iPreviousFace);   // If the new value is the same as the previous value, then re-generate

                // Update die image
                pbImage.Image = Image.FromFile("die" + iFace.ToString() + ".gif" );
                pbImage.Refresh();

                // Wait 300 milliseconds to allow for picture change
                Thread.Sleep(300);
            }

            // Return the value that the die ended on
            return iFace;
        }

        /// <summary>
        /// This method is used to determine how many times the dice changes faces while rolling. To replicate throwing the dice harder sometimes than others
        /// </summary>
        /// <returns>An Integer between 3 and 10</returns>
        private int genRollLength()
        {
            // Create a random number object;
            Random rndNumber = new Random();

            // Return a random number between 3 and 10
            return rndNumber.Next(3, 11);
        }

        /// <summary>
        /// This method updates the iNumPlayed, iNumWon, and iNumLost variables and the iFrequency, iGuessed, and dPercent arrays.
        /// </summary>
        /// <param name="iUserGuess">The Guess that the user made</param>
        /// <param name="iResult">The result of the dice roll</param>
        private void UpdateVariables(int iUserGuess, int iResult)
        {
            iNumPlayed++; // Increment the number of times played
            if (iUserGuess == iResult) // Check to see if the user guessed correctly
            {
                iNumWon++; // If the user guesed correctly, increment the nubmer of times won
            }
            else
            {
                iNumLost++; // If the user did not guess correctly, increment the number of times lost
            }

            iFrequency[iResult - 1]++; // Update the Frequency Array witht he latest value
            iGuesses[iUserGuess - 1]++; // Update the User Guesses Array with the latest guess

            // Update Percent Array with new values
            for (int i = 0; i < dPercent.Length; i++)
            {
                dPercent[i] = Math.Round( ( (decimal) iFrequency[i] / iNumPlayed ) * 100, 2); // Frequency divided by number of times played then multiplied by 100 (to make it a percent format) and rounded to 2 decimal places
            }
        }

        /// <summary>
        /// This method updates the labels and the textbox with the updated results
        /// </summary>
        private void OutputResults()
        {
            string sTextBox = "FACE        FREQUENCY        PERCENT        NUMBER OF TIMES GUESSED\n"; // String to hold the output for the results textbox

            label_numTimesPlayed_data.Text = iNumPlayed.ToString(); // Update Number of Times Played Text
            label_numTimesPlayed_data.Refresh(); // Update Number of Times Played on UI
            label_numTimesWon_data.Text = iNumWon.ToString(); // Update Number of Times Won Text
            label_numTimesWon_data.Refresh(); // Update Number of Times Played on UI
            label_numTimesLost_data.Text = iNumLost.ToString(); // Update Number of Times Lost Text
            label_numTimesLost_data.Refresh(); // Update Number of Times Played on UI

            // Loop to populate the results textbox
            for (int i = 0; i < 6; i++)
            {
                int iFace = i + 1; // Integer value of die face
                string sFace = iFace.ToString(); // String representation of die face
                string sFrequency = iFrequency[i].ToString(); // String representation of Frequency
                string sPercent = dPercent[i].ToString(); // String representation of Percent
                string sGuess = iGuesses[i].ToString(); // String representation of Guesses

                sTextBox = sTextBox + "\t" + sFace + "\t" + sFrequency + "\t" + sPercent + "%\t" + sGuess + "\n"; // Combine variables
            }

            richTextBox_results.Text = sTextBox; // Populate rich textbox with the string we created
        }

        #endregion
    }
}
