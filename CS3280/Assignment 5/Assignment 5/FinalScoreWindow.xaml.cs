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
using System.Windows.Shapes;
using System.Reflection;
using System.Windows.Navigation;

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for FinalScoreWindow.xaml
    /// </summary>
    public partial class FinalScoreWindow : Window
    {
        private clsDataAccess myDataManager;
        private clsGame myGame;

        public FinalScoreWindow()
        {
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/main_background.png")));   // Set Background
        }

        public FinalScoreWindow(clsDataAccess myDataManager, clsGame myGame)
        {
            InitializeComponent();
            this.myDataManager = myDataManager;
            this.myGame = myGame;
            setBackground();    // Sets the background based on the players score
            populateLabels();   // Populate the labels on the page with user data
        }

        private void populateLabels()
        {
            try
            {
                lblCorrectScore.Content = String.Format("Correct Answers: {0}", myGame.correctAnswers.ToString());
                lblIncorrectScore.Content = String.Format("Incorrect Answers: {0}", myGame.incorrectAnswers.ToString());
                int minutes = myGame.Timer / 60;
                int seconds = myGame.Timer % 60;
                lblTimeScore.Content = String.Format("You finished in: {0:00}:{1:00}", minutes, seconds);
                UserInfo.Content = string.Format("User: {0}\tAge: {1}", myGame.getUserName, myGame.getUserAge.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void setBackground()
        {
            try
            {
                // If player gets a score between 10 and 8
                if (myGame.correctAnswers >= 8)
                {
                    this.Background = Brushes.Gold;
                    lblCongrats.Content = "HIGH SCORE!!!";
                }
                // If the player gets a score between 5 and 7
                else if (myGame.correctAnswers >= 5)
                {
                    this.Background = Brushes.LightGreen;
                    lblCongrats.Content = "Great Job!";
                }
                // If the player gets a score between 0 and 4
                else
                {
                    this.Background = Brushes.DarkGray;
                    lblCongrats.Content = "Better Luck Next Time!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
