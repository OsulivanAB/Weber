using System.Windows;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndGame.xaml
    /// </summary>
    public partial class wndGame : Window
    {
        /// <summary>
        /// Variable to hold the high scores form.
        /// </summary>
        private wndHighScores wndCopyHighScores;

        /// <summary>
        /// Property to get and set the high scores.
        /// </summary>
        public wndHighScores CopyHighScores
        {
            get { return wndCopyHighScores; }
            set { wndCopyHighScores = value; }
        }

        public wndGame()
        {
            InitializeComponent();
        }

        private void cmdEndGame_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            //Hide the game form
            this.Hide();
            //Show the high scores
            wndCopyHighScores.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
