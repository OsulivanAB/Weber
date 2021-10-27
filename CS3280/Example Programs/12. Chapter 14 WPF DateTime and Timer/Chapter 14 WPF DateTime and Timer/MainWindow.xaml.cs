using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Must include this to use the DispatcherTimer //////////////////////////////////////////////////////////////////////////////////////
using System.Windows.Threading;

namespace Chapter_14_WPF_DateTime_and_Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer MyTimer;

        public MainWindow()
        {
            InitializeComponent();

            //Instantiate the DispatcherTimer
            MyTimer = new DispatcherTimer();
            //Make the timer go off every second
            MyTimer.Interval = TimeSpan.FromSeconds(1);
            //Tell it which method will handle the click event
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
        }

        /// <summary>
        /// Dates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDates_Click(object sender, RoutedEventArgs e)
        {
            //Create a DateTime object and set it to the current Date/Time
            DateTime dt1 = new DateTime();
            dt1 = DateTime.Now;

            //Create a DateTime object and set it to the current Date/Time
            DateTime dt2 = new DateTime();
            dt2 = DateTime.Now;
            //Add three days to the second date
            dt2 = dt2.AddDays(3);

            //Create a TimeSpan object and subtract the two dates
            TimeSpan ts = new TimeSpan();
            ts = dt2.Subtract(dt1);

            //Display the  total days
            lblDates.Content = ts.TotalDays.ToString();
        }

        /// <summary>
        /// Start the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdTimer_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Start();
        }

        /// <summary>
        /// Goes off when the timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString();
        }

        /// <summary>
        /// Restrict user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Only allow numbers to be entered
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                  e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                //Allow the user to use the backspace and delete keys
                if (!(e.Key == Key.Back || e.Key == Key.Delete))
                {
                    //No other keys allowed besides numbers, backspace, and delete
                    e.Handled = true;
                }
            }
        }
    }
}
