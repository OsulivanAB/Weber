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
using System.Windows.Threading;

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : UserControl
    {
        /// <summary>
        /// DispatcherTimer variable
        /// </summary>
        DispatcherTimer MyTimer;
        /// <summary>
        /// Holds the number of seconds elapsed
        /// </summary>
        private int secondsElapsed = 0;

        public Timer()
        {
            InitializeComponent();
            // Instantiate the dispatcherTimer
            MyTimer = new DispatcherTimer();

            // Make the timer go off every second
            MyTimer.Interval = TimeSpan.FromSeconds(1);

            // Tell it which method will handle the click event
            MyTimer.Tick += MyTimer_Tick;
        }

        /// <summary>
        /// Property to get the time on the stopwatch
        /// </summary>
        public int getTime
        {
            get
            {
                return secondsElapsed;
            }
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            secondsElapsed++;
            int minutes = secondsElapsed / 60;
            int seconds = minutes > 0 ? secondsElapsed % minutes : secondsElapsed;
            lblTimer.Content = String.Format("{0:00}:{1:00}",minutes,seconds);
        }
        /// <summary>
        /// Starts the timer
        /// </summary>
        public void startTimer()
        {
            MyTimer.Start();
        }
        /// <summary>
        /// Starts the timer
        /// </summary>
        public void stopTimer()
        {
            MyTimer.Stop();
        }
    }
}
