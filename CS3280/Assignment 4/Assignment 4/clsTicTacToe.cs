using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class clsTicTacToe
    {

        #region Attributes

        /// <summary>
        /// Array to hold the game board.
        /// </summary>
        private string[,] saBoard;

        /// <summary>
        /// Number of times that player 1 (X) has won.
        /// </summary>
        private int iPlayer1Wins;

        /// <summary>
        /// Number of times that player 2 (O) has won.
        /// </summary>
        private int iPlayer2Wins;

        /// <summary>
        /// Number of times that the game has ended in a tie.
        /// </summary>
        private int iTies;

        /// <summary>
        /// Holds the location of the winning move
        /// </summary>
        private WinningMove eWinningMove;

        /// <summary>
        /// List of possible winning moves.
        /// </summary>
        private enum WinningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        /// <summary>
        /// Keeps track of who's turn it is
        /// </summary>
        private int iActivePlayer;

        /// <summary>
        /// Keeps track of when there is an active game and when a game ends
        /// </summary>
        private bool bActiveGame;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates tic tac toe board and sets all "player win" variables to 0
        /// </summary>
        public clsTicTacToe()
        {
            // Create the board
            this.saBoard = new string[3, 3];

            // Set wins to 0
            this.iPlayer1Wins = 0;
            this.iPlayer2Wins = 0;
            this.iTies = 0;

            // Make sure the board is clear
            this.clearBoard();
        }

        #endregion

        #region Property

        /// <summary>
        /// Property that gets and sets the saBoard variable. Can set Board Variables using setSquareValue
        /// </summary>
        private string[,] Board
        {
            get
            {
                return saBoard;
            }
            set
            {
                saBoard = value;
            }
        }

        /// <summary>
        /// Gets and sets the value of iPlayer1Wins
        /// </summary>
        public int Player1Wins
        {
            get
            {
                return iPlayer1Wins;
            }
            set
            {
                iPlayer1Wins = value >= 0 ? value : throw new ArgumentOutOfRangeException("PlayerWins", value, "Player Wins can not be less than 0");
            }
        }

        /// <summary>
        /// Gets and sets the value of iPlayer2Wins
        /// </summary>
        public int Player2Wins
        {
            get
            {
                return iPlayer2Wins;
            }
            set
            {
                iPlayer2Wins = value >= 0 ? value : throw new ArgumentOutOfRangeException("PlayerWins", value, "Player Wins can not be less than 0");
            }
        }

        /// <summary>
        /// Gets and sets the value of iTies.
        /// </summary>
        public int Ties
        {
            get
            {
                return iTies;
            }
            set
            {
                iTies = value >= 0 ? value : throw new ArgumentOutOfRangeException("Ties", value, "Ties can not be less than 0");
            }
        }

        /// <summary>
        /// Returns whether or not there is an ongoing game or not
        /// </summary>
        public bool ActiveGame
        {
            get
            {
                return bActiveGame;
            }
        }

        /// <summary>
        /// Returns who's turn it is (Or if the game is over, then who won the last game)
        /// </summary>
        public int ActivePlayer
        {
            get
            {
                return iActivePlayer;
            }
        }

        /// <summary>
        /// Gets the number of games played by adding together the wins and ties
        /// </summary>
        public int GamesPlayed
        {
            get
            {
                return iPlayer1Wins + iPlayer2Wins + iTies;
            }
        }

        /// <summary>
        /// Returns the token value depending on who's turn it is
        /// </summary>
        public string Token
        {
            get
            {
                // Check who's turn it is and return X for player 1 and O for player 2
                return iActivePlayer == 1 ? "X" : "O";
            }
        }

        /// <summary>
        /// Returns the last winning move location
        /// </summary>
        public string winMove
        {
            get
            {
                return eWinningMove.ToString();
            }
        }

        #endregion
        
        #region Methods

        /// <summary>
        /// Check to see if there is a winning move
        /// </summary>
        /// <returns>True or False depending on if there has been a winning move</returns>
        private bool IsWinningMove()
        {
            // If there is a horizontal, vertical, or diagonal win then return true, otherwise return false
            return (IsHorizontalWin() || IsVerticalWin() || IsDiagonalWin()) ? true : false;
        }

        /// <summary>
        /// Check to see if there was a tie
        /// </summary>
        /// <returns>True if all spaces are filled and there is not a sinning move</returns>
        public bool IsTie()
        {
            // if the board is full, but there is no horizontal, vertical, or diagonal win then return true, otherwise return false
            return (isBoardFull() && !IsHorizontalWin() && !IsVerticalWin() && !IsDiagonalWin()) ? true : false;
        }

        /// <summary>
        /// Checks to see if there is a winning move for any of the horizontal rows.
        /// </summary>
        /// <returns>Returns true if there is a win on a horizontal row.</returns>
        private bool IsHorizontalWin()
        {
            // Check Row 1 for a win
            if ( isWin(saBoard[0, 0], saBoard[1, 0], saBoard[2, 0]) )
            {
                this.eWinningMove = WinningMove.Row1;
                return true;
            }

            // Check Row 2 for a win
            if (isWin(saBoard[0, 1], saBoard[1, 1], saBoard[2, 1]))
            {
                this.eWinningMove = WinningMove.Row2;
                return true;
            }

            // Check Row 3 for a win
            if (isWin(saBoard[0, 2], saBoard[1, 2], saBoard[2, 2]))
            {
                this.eWinningMove = WinningMove.Row3;
                return true;
            }

            // If there are no horizontal wins, return false
            return false;
        }

        /// <summary>
        /// Checks to see if there is a winning move for any of the vorizontal columns.
        /// </summary>
        /// <returns>Returns true if there is a win on a vertical columns.</returns>
        private bool IsVerticalWin()
        {
            // Check column 1 for a win
            if (isWin(saBoard[0, 0], saBoard[0, 1], saBoard[0, 2]))
            {
                this.eWinningMove = WinningMove.Col1;
                return true;
            }

            // Check column 2 for a win
            if (isWin(saBoard[1, 0], saBoard[1, 1], saBoard[1, 2]))
            {
                this.eWinningMove = WinningMove.Col2;
                return true;
            }

            // Check column 3 for a win
            if (isWin(saBoard[2, 0], saBoard[2, 1], saBoard[2, 2]))
            {
                this.eWinningMove = WinningMove.Col3;
                return true;
            }

            // If there are no vertical wins, return false
            return false;
        }

        /// <summary>
        /// Checks to see if there is a winning move for either diagonal line.
        /// </summary>
        /// <returns>Returns true if there is a win on a diagonal line.</returns>
        private bool IsDiagonalWin()
        {
            // Check for a win from the top left corner to the bottom right corner
            if (isWin(saBoard[0, 0], saBoard[1, 1], saBoard[2, 2]))
            {
                this.eWinningMove = WinningMove.Diag1;
                return true;
            }

            // Check for a win from the top right corner to the bottom left corner
            if (isWin(saBoard[2, 0], saBoard[1, 1], saBoard[0, 2]))
            {
                this.eWinningMove = WinningMove.Diag2;
                return true;
            }

            // If there are no horizontal wins, return false
            return false;
        }

        /// <summary>
        /// Checks 3 squares to see if they match.
        /// </summary>
        /// <param name="square1">Value in first square.</param>
        /// <param name="square2">Value in second square.</param>
        /// <param name="square3">Value in third square.</param>
        /// <returns>Returns true if the 3 squares match and they are not blank</returns>
        private bool isWin(string square1, string square2, string square3)
        {

            // Validate that Square1 is either an X or an O
            if (square1 != "X" && square1 != "O")
            {
                return false;
            }

            // if all squares match square1 return true, otherwise return false
            return (square1 == square2 && square1 == square3) ? true : false;

        }

        /// <summary>
        /// Checks the board to see if it is full.
        /// </summary>
        /// <returns>True if there are no empty spots left, otherwise false.</returns>
        private bool isBoardFull()
        {
            // Create flag variable that will indicate if the board is full
            bool flag = true;

            // Loop through each square on the board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // If the square is blank, set flag to false, otherwise retain flag value
                    flag = (this.saBoard[i, j] == null) ? false : flag;
                }
            }
            return flag;
        }

        /// <summary>
        /// Changes all values on the board to null
        /// </summary>
        private void clearBoard()
        {
            // Loop through all squares and set their value to null
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.saBoard[i, j] = null;
                }
            }
        }

        /// <summary>
        /// Sets the value of a square on the Tic Tac Toe Board
        /// </summary>
        /// <param name="row">Row of square to be changed (starts at 0)</param>
        /// <param name="column">Column of square to be changed (starts at 0)</param>
        /// <param name="value">Value to put in square (must be X or O)</param>
        public bool setSquareValue(int row, int column)
        {
            // Row number must be between 0 and 3
            if (row < 0 || row > 3) {
                throw new ArgumentOutOfRangeException("row", row, "Row number must be between 0 and 3");
            }

            // Column number must be between 0 and 3
            if (column < 0 || column > 3) {
                throw new ArgumentOutOfRangeException("column", column, "Column number must be between 0 and 3");
            }

            // Check to see if the square already has a value
            if (this.saBoard[row, column] != null)
            {
                return false;
            }

            // Update board if the selection is valid
            this.saBoard[row, column] = this.Token;
            
            // Check to see if that was a winning move or a tie, if it is then end the game and return true
            // If it isn't over then change the active player
            if ( IsWinningMove() || IsTie() )
            {
                endGame();
            } else
            {
                changePlayer();
            }

            return true;
        }

        /// <summary>
        /// Starts a new game by clearing the board, and setting the player to player 1 
        /// </summary>
        public void startGame()
        {
            // Check to see if there is already an active game
            if (this.bActiveGame) { throw new Exception("There is already an active game."); }

            // Set turn to Player 1
            this.iActivePlayer = 1;

            // Set bActiveGame to true
            this.bActiveGame = true;

            // Clear the board
            clearBoard();
        }

        /// <summary>
        /// Determines who the current player is and changes to the other player
        /// </summary>
        private void changePlayer()
        {
            // switch who's turn it is
            this.iActivePlayer = (this.iActivePlayer == 1) ? 2 : 1;
        }

        /// <summary>
        /// Sets the game status to over and adds the result to the game status variables
        /// </summary>
        private void endGame()
        {
            // Check to see if there is an active game
            if (!this.bActiveGame) { throw new Exception("There is not an active game."); }

            this.bActiveGame = false;

            // Add to Player wins or ties depending on the outcome
            if (IsTie())
            {
                this.iTies++;
            } else if (this.ActivePlayer == 1)
            {
                this.iPlayer1Wins++;
            } else
            {
                this.iPlayer2Wins++;
            }
        }

        #endregion

    }
}
