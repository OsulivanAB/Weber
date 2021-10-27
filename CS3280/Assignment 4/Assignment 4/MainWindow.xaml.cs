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

namespace Assignment_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create a variable to hold our Tic Tac Toe class
        clsTicTacToe clsTicTac;

        /// <summary>
        /// Loads when the program starts up
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Instantiate the Tic Tac Toe instance
            clsTicTac = new clsTicTacToe();

        }

        /// <summary>
        /// When the Start Game Button is clicked,  sets up the class and UI for a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            // Check to see if there is already an active game
            if (clsTicTac.ActiveGame)
            {
                displayError("There is already an active Game.");
                return;
            }
            // Clear Board
            clearUIBoard();

            // Start Game
            clsTicTac.startGame();

            // Update Game Status
            updateGameStatus();
        }

        /// <summary>
        /// Sets the background of all squares to Gray and removes the text.
        /// </summary>
        private void clearUIBoard()
        {
            // Clear Color on all Squares
            textblockBoard00.Background = Brushes.LightGray;
            textblockBoard10.Background = Brushes.LightGray;
            textblockBoard20.Background = Brushes.LightGray;
            textblockBoard01.Background = Brushes.LightGray;
            textblockBoard11.Background = Brushes.LightGray;
            textblockBoard21.Background = Brushes.LightGray;
            textblockBoard02.Background = Brushes.LightGray;
            textblockBoard12.Background = Brushes.LightGray;
            textblockBoard22.Background = Brushes.LightGray;

            // Clear Value on all squares
            textblockBoard00.Text = " ";
            textblockBoard10.Text = " ";
            textblockBoard20.Text = " ";
            textblockBoard01.Text = " ";
            textblockBoard11.Text = " ";
            textblockBoard21.Text = " ";
            textblockBoard02.Text = " ";
            textblockBoard12.Text = " ";
            textblockBoard22.Text = " ";
        }

        /// <summary>
        /// Updates the status section of the game board
        /// </summary>
        private void updateGameStatus()
        {
            // Set text color to black (in case the last message was an error)
            labelGameStatus.Foreground = Brushes.Black;

            // If no games have been played and there isn't one active
            if (!clsTicTac.ActiveGame && clsTicTac.GamesPlayed == 0) {
                labelGameStatus.Content = "Game has not started.";
            }
            // If a game is not active and the last game was a tie
            else if (!clsTicTac.ActiveGame && clsTicTac.GamesPlayed > 0 && clsTicTac.IsTie())
            {
                labelGameStatus.Content = "Tie!";
            }
            // If a game is not active, and it wasn't a tie, then the last active player won
            else if (!clsTicTac.ActiveGame && clsTicTac.GamesPlayed > 0 && !clsTicTac.IsTie())
            {
                labelGameStatus.Content = "Player " + clsTicTac.ActivePlayer.ToString() + " Wins!";
            }
            else if  (clsTicTac.ActiveGame)
            {
                labelGameStatus.Content = "Player " + clsTicTac.ActivePlayer.ToString() + "'s turn";
            } else
            {
                labelGameStatus.Content = "Unsure what the status of this game is";
            }
        }

        /// <summary>
        /// Retrieves the game statistics from our Tic Tac Toe class and updates the game statistics group box
        /// </summary>
        private void updateGameStatistics()
        {
            // Update Player 1 Wins
            labelPlayerOneWinsData.Content = clsTicTac.Player1Wins.ToString();
            // Update Player 2 Wins
            labelPlayerTwoWinsData.Content = clsTicTac.Player2Wins.ToString();
            // Update Ties
            labelTiesData.Content = clsTicTac.Ties.ToString();
        }

        /// <summary>
        /// Processes the users click (if there is a game started)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boardClick(object sender, MouseButtonEventArgs e)
        {
            // Check to see if there is an Active Game
            if (!clsTicTac.ActiveGame)
            {
                displayError("There is not an active game.");
                return;
            }

            // Cast the sender into a TextBlock variable
            TextBlock square = (TextBlock)sender;

            // Get Row Value
            int row = getRowValue(square.Tag.ToString());
            
            // Get Column Value
            int column = getColumnValue(square.Tag.ToString());

            // Get Token value from the class
            string token = clsTicTac.Token;

            // Attempt to commit selection, store result in flag variable
            bool flag = clsTicTac.setSquareValue(row, column);

            // If failed, display error message
            if (!flag)
            {
                displayError("Invalid selection.");
                return;
            } else
            {
                UpdateSquareVisual(square, token);
            }

            // if the game is now over, update game statistics
            if (!clsTicTac.ActiveGame)
            {
                // Update Game Statistics
                updateGameStatistics();
                // Identify Winning Move
                identifyWinningMove();
            }

            // Update game status
            updateGameStatus();
        }

        /// <summary>
        /// Parses the tag (string) and returns the int value of the row
        /// </summary>
        /// <param name="tag">Tag AB. where A = Column and B = Row</param>
        /// <returns>Row number</returns>
        private int getRowValue(string tag)
        {
            // Variable to hold the value of tag after we convert it to an int
            int x;
            Int32.TryParse(tag, out x);
            return x % 10;
        }

        /// <summary>
        /// Parses the tag (string) and returns the int value of the column
        /// </summary>
        /// <param name="tag">Tag AB. where A = Column and B = Row</param>
        /// <returns>Column number</returns>
        private int getColumnValue(string tag)
        {
            // Variable to hold the value of tag after we convert it to an int
            int x;
            Int32.TryParse(tag, out x);
            return x / 10;
        }

        /// <summary>
        /// Displays an error message in the 'Game Status' section
        /// </summary>
        /// <param name="errorMessage">Error Message</param>
        private void displayError(string errorMessage)
        {
            // Set Game Status text to Red
            labelGameStatus.Foreground = Brushes.Red;
            // Display error message
            labelGameStatus.Content = errorMessage;
        }

        /// <summary>
        /// Updates a square on the board with a players token and changes the color value
        /// </summary>
        /// <param name="tb">Text Box that was clicked</param>
        /// <param name="token">X for player 1 and O for Player 2</param>
        private void UpdateSquareVisual(TextBlock tb, string token)
        {
            // Update the text to the token value
            tb.Text = token;
            // Update background color based on token value
            tb.Foreground = token == "X" ? Brushes.Red : Brushes.Blue;
        }

        /// <summary>
        /// gets the winning move from the tic tac toe class and updates the winning move to yellow background
        /// </summary>
        private void identifyWinningMove()
        {
            // Check if the result was a tie
            if (clsTicTac.IsTie())
            {
                return;
            }
            // Update the background color of the winning set (if any)
            else if (clsTicTac.winMove == "Row1")
            {
                textblockBoard00.Background = Brushes.Yellow;
                textblockBoard10.Background = Brushes.Yellow;
                textblockBoard20.Background = Brushes.Yellow;
            } else if (clsTicTac.winMove == "Row2")
            {
                textblockBoard01.Background = Brushes.Yellow;
                textblockBoard11.Background = Brushes.Yellow;
                textblockBoard21.Background = Brushes.Yellow;
            }
            else if (clsTicTac.winMove == "Row3")
            {
                textblockBoard02.Background = Brushes.Yellow;
                textblockBoard12.Background = Brushes.Yellow;
                textblockBoard22.Background = Brushes.Yellow;
            }
            else if (clsTicTac.winMove == "Col1")
            {
                textblockBoard00.Background = Brushes.Yellow;
                textblockBoard01.Background = Brushes.Yellow;
                textblockBoard02.Background = Brushes.Yellow;
            }
            else if (clsTicTac.winMove == "Col2")
            {
                textblockBoard10.Background = Brushes.Yellow;
                textblockBoard11.Background = Brushes.Yellow;
                textblockBoard12.Background = Brushes.Yellow;
            }
            else if (clsTicTac.winMove == "Col3")
            {
                textblockBoard20.Background = Brushes.Yellow;
                textblockBoard21.Background = Brushes.Yellow;
                textblockBoard22.Background = Brushes.Yellow;
            }
            else if (clsTicTac.winMove == "Diag1")
            {
                textblockBoard00.Background = Brushes.Yellow;
                textblockBoard11.Background = Brushes.Yellow;
                textblockBoard22.Background = Brushes.Yellow;
            }
            else if (clsTicTac.winMove == "Diag2")
            {
                textblockBoard20.Background = Brushes.Yellow;
                textblockBoard11.Background = Brushes.Yellow;
                textblockBoard02.Background = Brushes.Yellow;
            }
        }
    }
}
