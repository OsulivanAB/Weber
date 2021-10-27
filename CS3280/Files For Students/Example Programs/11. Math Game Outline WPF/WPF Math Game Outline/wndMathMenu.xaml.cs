using System.Windows;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndMathMenu.xaml
    /// </summary>
    public partial class wndMathMenu : Window
    {
        /// <summary>
        /// Class that holds the high scores.
        /// </summary>
        wndHighScores wndHighScoresForm;

        /// <summary>
        /// Class that holds the user data.
        /// </summary>
        wndEnterUserData wndEnterUserDataForm;

        /// <summary>
        /// Class where the game is played.
        /// </summary>
        wndGame wndGameForm;

        public wndMathMenu()
        {
            InitializeComponent();

            //MAKE SURE TO INCLUDE THIS LINE OR THE APPLICATION WILL NOT CLOSE
            //BECAUSE THE WINDOWS ARE STILL IN MEMORY
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;///////////////////////////////////////////////////////////

            wndHighScoresForm = new wndHighScores();
            wndEnterUserDataForm = new wndEnterUserData();
            wndGameForm = new wndGame();

            //Pass the high scores form to the game form.  This way the high scores form may be displayed via the game form.
            wndGameForm.CopyHighScores = wndHighScoresForm;
        }

        private void cmdPlayGame_Click(object sender, RoutedEventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the game form
            wndGameForm.ShowDialog();
            //Show the main form
            this.Show();
        }

        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the high scores screen
            wndHighScoresForm.ShowDialog();
            //Show the main form
            this.Show();
        }

        private void cmdEnterUserData_Click(object sender, RoutedEventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the user data form
            wndEnterUserDataForm.ShowDialog();
            //Show the main form
            this.Show();
        }
    }
}
