using System.Windows;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndEnterUserData.xaml
    /// </summary>
    public partial class wndEnterUserData : Window
    {
        public wndEnterUserData()
        {
            InitializeComponent();
        }

        private void cmdCloseUserDataForm_Click(object sender, RoutedEventArgs e)
        {
            //Hide user data form
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
