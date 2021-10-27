using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;

namespace Assignment_5
{
    public class clsGame
    {
        #region Attributes
        /// <summary>
        /// Holds user information.
        /// </summary>
        private clsUser myUser;
        /// <summary>
        /// The number of answers the player has answered correctly
        /// </summary>
        private int iCorrectAnswers;
        /// <summary>
        /// The number of answers the player has answered incorrectly
        /// </summary>
        private int iIncorrectAnswers;
        /// <summary>
        /// Holds the game type 
        /// </summary>
        private string sGameType;
        /// <summary>
        /// Holds the list of math problems
        /// </summary>
        private clsMathProblem[] lstProblems;
        /// <summary>
        /// Keeps track of which problem the player is on.
        /// </summary>
        private int iCounter;
        /// <summary>
        /// Keeps track of if the game is active or not
        /// </summary>
        public bool bActiveGame { get; set; }
        /// <summary>
        /// Keeps track of if there is a question active or not
        /// </summary>
        public bool bActiveQuestion { get; set; }
        /// <summary>
        /// Random Number Generator
        /// </summary>
        private Random randomGenerator;
        /// <summary>
        /// Time in seconds.
        /// </summary>
        private int iSeconds;

        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets the timer value
        /// </summary>
        public int Timer
        {
            get
            {
                return iSeconds;
            }
            set
            {
                if (value >= 0)
                {
                    iSeconds = value;
                }
            }
        }
        /// <summary>
        /// Gets the username
        /// </summary>
        public string getUserName
        {
            get
            {
                return myUser.sUserNmae;
            }
        }
        /// <summary>
        /// Gets the user age
        /// </summary>
        public int getUserAge
        {
            get
            {
                return myUser.Age;
            }
        }
        /// <summary>
        /// Returns the problem number that the user is on.
        /// </summary>
        public int getProblemNumber
        {
            get
            {
                try
                {
                    // return 1 higher than iCounter, since iCounter is an index.
                    return iCounter + 1;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Returns the number of questions the player has answered correct
        /// </summary>
        public int correctAnswers
        {
            get
            {
                return iCorrectAnswers;
            }
        }
        /// <summary>
        /// Returns the number of questions the player has answered incorrectly
        /// </summary>
        public int incorrectAnswers
        {
            get
            {
                return iIncorrectAnswers;
            }
        }
        /// <summary>
        /// Returns the type of game
        /// </summary>
        public string getGametype
        {
            get
            {
                return sGameType;
            }
        }
        /// <summary>
        /// Gets the first number in the current problem
        /// </summary>
        public int getFirstNumber
        {
            get
            {
                return lstProblems[iCounter].iFirstNumber;
            }
        }
        /// <summary>
        /// Gets the second number in the current problem
        /// </summary>
        public int getSecondNumber
        {
            get
            {
                return lstProblems[iCounter].iSecondNumber;
            }
        }
        /// <summary>
        /// Gets the Answer in the current problem
        /// </summary>
        public int getAnswerNumber
        {
            get
            {
                return lstProblems[iCounter].iAnswer;
            }
        }
        public clsMathProblem getCurrentProblem
        {
            get
            {
                return lstProblems[iCounter];
            }
        }
        /// <summary>
        /// Property to set the random number generator
        /// </summary>
        public Random setRandomGenerator
        {
            set
            {
                randomGenerator = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Game Constructor
        /// </summary>
        public clsGame(string gameType, string user, int age, Random rnd)
        {
            try
            {
                randomGenerator = rnd;  // Set Random Generator
                bActiveGame = false;    // Set Active Game to false (will start when the timer does)
                bActiveQuestion = false;    // Set Active Question to false
                myUser = new clsUser(user, age);  // Set username
                sGameType = gameType;   // Set gametype
                iCorrectAnswers = 0;    // Set iCorrectAnswers to 0
                iIncorrectAnswers = 0;  // Set iIncorrectAnswers to 0.
                iCounter = 0;   // Initializes the counter at 0.
                lstProblems = new clsMathProblem[10];   // Set up the math problems list
                // Populate lstProblems
                for (int i = 0; i < 10; i++)
                {
                    lstProblems[i] = new clsMathProblem(sGameType, randomGenerator);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Checks to see if the user got the answer correct.
        /// </summary>
        /// <param name="answer">Users Answer</param>
        /// <returns>True if correct, false if not correct.</returns>
        public bool submitAnswer(int answer)
        {
            try
            {
                // Variable to hold the results
                bool results;   

                // Check to see if answer is correct
                if (answer == lstProblems[iCounter].iAnswer)
                {
                    iCorrectAnswers++;
                    results = true;
                }
                else
                {
                    iIncorrectAnswers++;
                    results = false;
                }

                iCounter++; // Incrament the counter
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Gets the current math question.
        /// </summary>
        /// <returns>String.</returns>
        public string getQuestion()
        {
            try
            {
                return lstProblems[iCounter].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }
        /// <summary>
        /// Checks to see if the value is the correct answer
        /// </summary>
        /// <param name="value">Integer to check against the answer</param>
        /// <returns>True: Correct, False: Incorrect</returns>
        public bool checkAnswer(int value)
        {
            return lstProblems[iCounter].iAnswer == value ? true : false;
        }

        #endregion
    }
}
