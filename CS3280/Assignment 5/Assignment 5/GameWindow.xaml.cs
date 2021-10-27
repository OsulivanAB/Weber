using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// Manages Access to database
        /// </summary>
        clsDataAccess MyDataManager;
        /// <summary>
        /// Holds the current game
        /// </summary>
        clsGame myGame;
        /// <summary>
        /// Logic behind the scenarios
        /// </summary>
        clsScenario ScenarioLogic;
        /// <summary>
        /// Holds info about the scenario
        /// </summary>
        int scenario;
        /// <summary>
        /// Random Number Generator
        /// </summary>
        Random myRandomGenerator;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataManager">Class that will manage data</param>
        /// <param name="currentGame">Class that will manage the game</param>
        public GameWindow(clsDataAccess dataManager, clsGame currentGame, Random rnd)
        {
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/main_background.png")));   // Set Background
            MyDataManager = dataManager; // Set the data manager
            myGame = currentGame;   // Set the game to our variable
            myRandomGenerator = rnd; // Create the random number generator
            ScenarioLogic = new clsScenario();  // Create scenario logic class
            ScenarioLogic.MyDataManager = dataManager;  // Send Data Manager to Scenario Logic
            myGame.setRandomGenerator = myRandomGenerator;  // Pass the game the random number generator
            ScenarioLogic.myRandomGenerator = myRandomGenerator; // Pass the scenario logic the random number generator
            ucScenarioWindow.ScenarioLogic = this.ScenarioLogic;    // Pass the Scenario window the scenario logic
        }

        /// <summary>
        /// Property where our data access manager can be passed in
        /// </summary>
        public clsDataAccess SetMyDataAccess
        {
            set
            {
                MyDataManager = value;
            }
        }

        /// <summary>
        /// Previews input to textbox and verify's that it's a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Method to handle errors.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            //Try Catch/finally
            try
            {
                // Would write to a file or database here
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "handleError Exception: " + ex.Message);
            }
        }
        /// <summary>
        /// Updates the page scenario.
        /// </summary>
        /// <param name="questionStatus">1- New Question 2- Submit Question</param>
        /// <param name="bResult">Result if you are submitting a question. True if you are not.</param>
        private void updateScenario(int questionStatus, bool bResult)
        {
            try
            {
                // Check Question Status
                // 1- New Question
                // 2- Submit Question
                switch (questionStatus)
                {
                    // New Question
                    case 1:
                        // Generate random scenario
                        scenario = ScenarioLogic.getRandomScenario(myGame.getGametype);
                        // Update Background
                        this.Background = ScenarioLogic.getScenarioBackground(scenario);
                        // Update Scenario Pictures
                        ucScenarioWindow.updatePictures(scenario, questionStatus, myGame.getGametype, myGame.getCurrentProblem, bResult);
                        // Update billboard
                        tbSignInfo.Text = ScenarioLogic.getBillboardInfo(scenario, myGame.getGametype, myGame.getCurrentProblem);
                        break;
                    // Submit Question
                    case 2:
                        // Update Scenario Pictures
                        ucScenarioWindow.updatePictures(scenario, questionStatus, myGame.getGametype, myGame.getCurrentProblem, bResult);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Clears the answer field on the game window
        /// </summary>
        private void resetAnswerField()
        {
            try
            {
                tbAnswers.Text = "";    // Clear the Answers Field
                tbAnswers.IsEnabled = true; // Activate the Answers Field
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Sets the progress button to now perform the btnProgress_SubmitQuestion task and removes any other tasks
        /// </summary>
        private void setProgressButton_Submit()
        {
            try
            {
                btnProgress.Content = "Submit"; // Update Button Text
                btnProgress.Click -= btnProgress_StartGame; // Remove this function from the btnProgress.Click Event
                btnProgress.Click -= btnProgress_NextQuestion; // Removes the btnProgress_NextQuestion function from the btnProgress.Click Event
                btnProgress.Click += btnProgress_SubmitQuestion; // Add Submit Question function from the btnProgress.Click Event
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Sets the progress button to now perform the btnProgress_NextQuestion task and removes any other tasks
        /// </summary>
        private void setProgressButton_NextQuestion()
        {
            try
            {
                btnProgress.Content = "Next Question"; // Update Button Text
                btnProgress.Click -= btnProgress_StartGame; // Remove this function from the btnProgress.Click Event
                btnProgress.Click -= btnProgress_SubmitQuestion; // Removes the btnProgress_SubmitQuestion function from the btnProgress.Click Event
                btnProgress.Click += btnProgress_NextQuestion; // Adds the btnProgress_NextQuestion function to the btnProgress.Click Event
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Sets the progress button to now perform the btnProgress_NextQuestion task and removes any other tasks
        /// </summary>
        private void setProgressButton_ViewFinalScore()
        {
            try
            {
                btnProgress.Content = "View Final Score"; // Update Button Text
                btnProgress.Click -= btnProgress_StartGame; // Remove this function from the btnProgress.Click Event
                btnProgress.Click -= btnProgress_SubmitQuestion; // Removes the btnProgress_SubmitQuestion function from the btnProgress.Click Event
                btnProgress.Click -= btnProgress_NextQuestion; // Removes the btnProgress_NextQuestion function from the btnProgress.Click Event
                btnProgress.Click += btnProgress_FinalScore; // Adds the btnProgress_NextQuestion function to the btnProgress.Click Event
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Starts a new game after the user has read the instructions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgress_StartGame(object sender, RoutedEventArgs e)
        {
            lblQuestionsNum.Content = "Quesiont " + myGame.getProblemNumber + ":";  // Update Question #
            resetAnswerField(); // Reset the Answer Field
            lblFolrmula.Content = myGame.getQuestion(); // Update the Probblem
            setProgressButton_Submit();
            updateScenario(1, true);   // Update Scenario
            myGame.bActiveGame = true;  // set the game to active
            gameTimer.startTimer(); // Start Timer
            tbAnswers.Focus();
        }
        /// <summary>
        /// Pull up the next question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgress_NextQuestion(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check for user input
                switch (tbAnswers.Text)
                {
                    // If the user hasn't entered anything
                    case "":
                        tbAnswers.BorderBrush = Brushes.Red;
                        break;
                    default:
                        tbAnswers.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#FFABADB3"));   // Clear red boarder if it was set due to no input previously
                        tbAnswers.BorderBrush = Brushes.Gray;   // Clear red boarder if it was set due to no input previously
                        clearResults(); // Clear previous questions Results
                        resetAnswerField(); // Reset the Answer Field
                        lblQuestionsNum.Content = "Quesiont " + myGame.getProblemNumber + ":";  // Update Question #
                        lblFolrmula.Content = myGame.getQuestion(); // Update the Probblem
                        setProgressButton_Submit();
                        updateScenario(1, true);   // Update Scenario
                        tbAnswers.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Submits a Question and shows if the user was correct or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgress_SubmitQuestion(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check for User input
                switch (tbAnswers.Text)
                {
                    // If the user hasn't entered anything
                    case "":
                        tbAnswers.BorderBrush = Brushes.Red;
                        break;
                    default:
                        tbAnswers.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#FFABADB3"));   // Clear red boarder if it was set due to no input previously
                        tbAnswers.IsEnabled = false; // Locks Answer field
                        // Check to see if this is the last question
                        switch (myGame.getProblemNumber)
                        {
                            // If that was the last question
                            case 10:
                                setProgressButton_ViewFinalScore(); // Set progress button to "View Final Score"
                                gameTimer.stopTimer();   // Stop Timer
                                myGame.bActiveGame = false; // set the game to not active
                                myGame.Timer = gameTimer.getTime;   // Pass ending time over to the game
                                break;
                            // If that was not the last question
                            default:
                                setProgressButton_NextQuestion();   // Set Progress button to "Next Question"
                                break;
                        }

                        int iAnswer = -1;   // Variable to hold Answer
                        Int32.TryParse(tbAnswers.Text, out iAnswer);    // Attempt to parse answer
                        bool bResult = myGame.checkAnswer(iAnswer);
                        updateScenario(2, bResult);   // Update Scenario
                        setResults(bResult);   // Display Result to player
                        myGame.submitAnswer(iAnswer);    // Submit Answer
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Sets a banner at the top of the question box stating whether or not the answer was correct
        /// </summary>
        /// <param name="bResult">True or false result of answer</param>
        private void setResults(bool bResult)
        {
            try
            {
                switch (bResult)
                {
                    case true:
                        lblResults.Content = "Correct!!!";
                        lblResults.Foreground = Brushes.Green;
                        break;
                    case false:
                        lblResults.Content = "Incorrect";
                        lblResults.Foreground = Brushes.Red;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// clears a banner at the top of the question box stating whether or not the answer was correct
        /// </summary>
        private void clearResults()
        {
            try
            {
                lblResults.Content = "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Pulls up the final score window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgress_FinalScore(object sender, RoutedEventArgs e)
        {
            try
            {
                FinalScoreWindow wndFinal = new FinalScoreWindow(MyDataManager, myGame); // Create Final Score Window
                this.Hide();    // Hide this window
                wndFinal.ShowDialog(); // Show Game Window
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Checks to see if the user presses the Enter Key and treats that as if it were a button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    // Raise button click event on the progress button
                    btnProgress.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
