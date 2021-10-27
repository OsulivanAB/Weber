using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//Need to add
using System.Threading;

namespace Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Example 1

        /// <summary>
        /// Delegate used to display a message on the UI thread
        /// </summary>
        private delegate void DisplayMessageDelegate();

        /// <summary>
        /// The user clicked the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStartThread_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Begin Message";

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
            lblMessage.Invoke(new DisplayMessageDelegate(DisplayMessage));
        }

        /// <summary>
        /// Update the label.
        /// </summary>
        private void DisplayMessage()
        {
            lblMessage.Text = "End Message";
        }

        #endregion

        #region Example 2

        /// <summary>
        /// This method starts the background worker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBackGroundWorker_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "You have started";

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
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(50);
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(75);
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(100);
        }

        /// <summary>
        /// The progress has been changed so report it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = "Percent Completed: " + e.ProgressPercentage.ToString() + "%";
        }

        /// <summary>
        /// The backgroundWorker has completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "You have finished";
        }

        #endregion

    }
}