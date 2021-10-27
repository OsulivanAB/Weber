using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_14_15_User_Control_and_Event
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Just another way to assign a delegate to the seat clicked event.
            //ctrlMyUserControl.SeatClickDelegate MySeatDelegate = new ctrlMyUserControl.SeatClickDelegate(ctrlMyUserControl1_SeatClickEvent);
            //ctrlMyUserControl1.SeatClickEvent += MySeatDelegate;

            //Assign a delegate to the seat clicked event.
            ctrlMyUserControl1.SeatClickEvent += new ctrlMyUserControl.SeatClickDelegate(ctrlMyUserControl1_SeatClickEvent);
        }

        /// <summary>
        /// This method handles the string clicked event.
        /// </summary>
        /// <param name="SeatNumber"></param>
        void ctrlMyUserControl1_SeatClickEvent(string SeatNumber)
        {
            lblStatus.Text = "Seat Number: " + SeatNumber + " was clicked";
        }

        /// <summary>
        /// This method handles the button clicked event from the user control.
        /// This was setup via the visual designer and not written manually.
        /// </summary>
        /// <param name="SeatNumber"></param>
        private void ctrlMyUserControl1_ButtonClickEvent(string SeatNumber)
        {
            lblStatus.Text = "The button was clicked";
        }

    }
}