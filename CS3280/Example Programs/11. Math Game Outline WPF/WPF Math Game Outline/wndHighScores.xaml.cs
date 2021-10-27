using System.Windows;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndHighScores.xaml
    /// </summary>
    public partial class wndHighScores : Window
    {
        public wndHighScores()
        {
            InitializeComponent();
        }

        private void cmdCloseHighScores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
