using System;
using System.Collections.Generic;
using System.Windows;

namespace Generic_List_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Create the high scores list.
        /// </summary>
        List<Score> lstHighScores = new List<Score>();

        public MainWindow()
        {
            InitializeComponent();
            txtName.Focus();

            for (int i = 0; i < 10; i++)
            {
                ////////////////////////////////////////////////////////Creating 10 high scores but I am ordering them correctly
                lstHighScores.Add(new Score
                {
                    iScore = (10 - i),
                    iTime = (10 * (i + 1)),
                    Name = "Player " + (i + 1).ToString()
                });
            }

            DisplayTopTenHighScores();
        }

        /// <summary>
        /// Add the new high score to the list if it makes it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddSortAndDisplay_Click(object sender, RoutedEventArgs e)
        {
            //Get the user's name, number correct, and time the game was completed in
            string sUsersName = txtName.Text;
            int iUsersScore = int.Parse(txtNumberCorrect.Text);
            int iUsersTime = int.Parse(txtCompletedGameTime.Text);

            //Create a new Score object with the current users information
            Score CurrentUsersScore = new Score() { Name = sUsersName, iScore = iUsersScore, iTime = iUsersTime };

            //Loop through the top 10 high scores
            for (int i = 0; i < 10; i++)
            {
                //Is the user's score greater than the current top ten high score
                if (iUsersScore > lstHighScores[i].iScore)
                {
                    //The user's score has beat the current score in the list so insert the user's score
                    lstHighScores.Insert(i, CurrentUsersScore);
                    //Remove the last score in the list
                    lstHighScores.RemoveAt(10);
                    break;
                }
                else if (iUsersScore == lstHighScores[i].iScore)    //Are the scores the same
                {
                    //Did the user's time beat the current high scores time
                    if (lstHighScores[i].iTime > iUsersTime)
                    {
                        //User's time was less than the current high scores time
                        lstHighScores.Insert(i, CurrentUsersScore);
                        //Remove the last score in the list
                        lstHighScores.RemoveAt(10);
                        break;
                    }
                }
            }

            //Display top ten high scores
            DisplayTopTenHighScores();
        }

        /// <summary>
        /// Display top 10 high scores.
        /// </summary>
        private void DisplayTopTenHighScores()
        {
            txtHighScores.Text = "";

            //Loop through the top 10 high scores and display them
            for (int i = 0; i < 10; i++)
            {
                txtHighScores.Text += lstHighScores[i].Name.PadRight(10) + "\t\t" + lstHighScores[i].iScore.ToString() + "\t\t" + lstHighScores[i].iTime.ToString() + Environment.NewLine;
            }
        }
    }

    /// <summary>
    /// Holds a single score for the top 10 scores list.
    /// </summary>
    public class Score
    {
        public int iScore { get; set; }
        public int iTime { get; set; }
        public string Name { get; set; }
    }

}
