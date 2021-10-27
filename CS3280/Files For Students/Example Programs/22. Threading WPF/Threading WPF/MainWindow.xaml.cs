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
using System.Threading;
using System.ComponentModel;

namespace Threading_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Delegate used to display a message on the UI thread
        /// </summary>
        private delegate void DisplayMessageDelegate();

        /// <summary>
        /// The background worker.
        /// </summary>
        BackgroundWorker backgroundWorker1;

        public MainWindow()
        {
            InitializeComponent();

            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        #region Example 1

        /// <summary>
        /// The user clicked the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStartThread_Click(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = "Begin Message";

            //Start a new Thread
            Thread MyThread = new Thread(new ThreadStart(MyThreadMethod));
            MyThread.Start();
        }

        /// <summary>
        /// This method makes the thread go to sleep for 3 seconds then invokes the delegate to call the DisplayMessage method.
        /// </summary>
        private void MyThreadMethod()
        {
            Thread.Sleep(3000);

            //This will throw and exception because it is updating the label which was created by the UI thread.
            //lblMessage.Text = "End Message";

            //Invoke the delegate method DisplayMessage
            this.Dispatcher.BeginInvoke(new DisplayMessageDelegate(DisplayMessage));
        }

        /// <summary>
        /// Update the label.
        /// </summary>
        private void DisplayMessage()
        {
            lblMessage.Content = "End Message";
        }

        #endregion

        #region Example 2

        /// <summary>
        /// This method starts the background worker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBackGroundWorker_Click(object sender, RoutedEventArgs e)
        {
            lblStatus.Content = "You have started";

            //Start the background worker
            backgroundWorker1.RunWorkerAsync();
        }

        /// <summary>
        /// This event handler was created with the visual designer.  It handles the DoWork event from the backgroundWorker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Put the thread to sleep to simulate work (like writing to a file or database), then report the current progress

            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(25);
            Thread.Sleep(1500);
            backgroundWorker1.ReportProgress(50);
            Thread.Sleep(1500);
            backgroundWorker1.ReportProgress(75);
            Thread.Sleep(1500);
            backgroundWorker1.ReportProgress(100);

            //We don't use a try/catch block around the entire method because if an exception occurs it will be 
            //handled in the backgroundWorker1_RunWorkerCompleted method.

            //Uncomment the following code to generate an error
            //int i = 0;
            //int j = 0;
            //int k = i / j;
        }

        /// <summary>
        /// The progress has been changed so report it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Content = "Percent Completed: " + e.ProgressPercentage.ToString() + "%";
        }

        /// <summary>
        /// The backgroundWorker has completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Content = "You have finished";

            //Check to see if an exception was thrown
            if (e.Error != null)
            {
                lblStatus.Content = e.Error.Message;
            }
        }

        #endregion
    }
}
