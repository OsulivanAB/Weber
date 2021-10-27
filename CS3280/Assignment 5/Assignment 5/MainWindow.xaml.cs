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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Class that manages data access
        /// </summary>
        clsDataAccess MyDataManager;
        /// <summary>
        /// Random Number Generator
        /// </summary>
        Random myRandomGenerator;

        public MainWindow()
        {
            InitializeComponent();
            // Instantiate the data access object
            MyDataManager = new clsDataAccess();
            myRandomGenerator = new Random();
        }

        /// <summary>
        /// Displays an error that the user name is invalid.
        /// </summary>
        private void displayUserNameError()
        {
            try
            {
                this.lblUserNameError.Content = "The user name can not be blank.";
                this.tbUserName.BorderBrush = Brushes.Red;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Clears an error that the user name is invalid.
        /// </summary>
        private void clearUserNameError()
        {
            try
            {
                this.lblUserNameError.Content = "";
                this.tbUserName.BorderBrush = Brushes.Gray;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Displays an error that the user age is invalid.
        /// </summary>
        private void displayUserAgeError()
        {
            try
            {
                this.lblAgeError.Content = "Age must be between 3 and 10.";
                this.tbAge.BorderBrush = Brushes.Red;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Clears an error that the user age is invalid.
        /// </summary>
        private void clearUserAgeError()
        {
            try
            {
                this.lblAgeError.Content = "";
                this.tbAge.BorderBrush = Brushes.Gray;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
        /// Handles text being put in the age textbox, only allows numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ageTextInput(object sender, TextCompositionEventArgs e)
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
        /// Handles text being put in the user name textbox, alows alphanumeric characters only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^A-Za-z0-9_]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Triggers if the enter key is pressed while in the user name or age textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    int iAge = -1;   // Will hold the user input for age

                    // Attempt to convert the age value to an intager
                    Int32.TryParse(tbAge.Text, out iAge);

                    // send info to the startgame function
                    startGame(tbUserName.Text, iAge, getGameType());
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Figures out which game type is selected
        /// </summary>
        string getGameType()
        {
            try
            {
                // Check if Add is selected
                if (rbAdd.IsChecked == true)
                {
                    return rbAdd.Tag.ToString();
                }
                // Check if Subtract is selected
                else if (rbSubtract.IsChecked == true)
                {
                    return rbSubtract.Tag.ToString();
                }
                // Check if Multiply is selected
                else if (rbMultiply.IsChecked == true)
                {
                    return rbMultiply.Tag.ToString();
                }
                // Return Divide if the others weren't selected
                else
                {
                    return rbDivide.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        private void startGame(string user, int age, string gameType)
        {
            try
            {
                // Validate User Name
                bool validUserFlag = clsUser.validateUserName(user);
                // Validate Age
                bool validAgeFlag = clsUser.validateUserAge(age);

                // Display error if the username is invalid
                if (!validUserFlag)
                {
                    displayUserNameError();
                }
                else
                {
                    clearUserNameError();
                }

                // Display error if Age is invalid
                if (!validAgeFlag)
                {
                    displayUserAgeError();
                }
                else
                {
                    clearUserAgeError();
                }

                // Start game if data is valid
                if (validUserFlag && validAgeFlag)
                {
                    clsGame newGame = new clsGame(gameType, user, age, myRandomGenerator);    // Create Game
                    GameWindow wndGame = new GameWindow(MyDataManager, newGame, myRandomGenerator);    // Create Game Window
                    this.Hide();    // Hide this window
                    wndGame.ShowDialog(); // Show Game Window
                    this.Show();    // Show this window again.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Handles the click of the "Begin Game" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_BeginGameClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int iAge = -1;   // Will hold the user input for age

                // Attempt to convert the age value to an intager
                Int32.TryParse(tbAge.Text, out iAge);

                // send info to the startgame function
                startGame(tbUserName.Text, iAge, getGameType());
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
