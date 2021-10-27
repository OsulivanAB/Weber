using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Chapter_14_15_User_Control_and_Event
{
    public partial class ctrlMyUserControl : UserControl
    {

        /// <summary>
        /// Create a delegate for your event.
        /// This just sets up the format that we expect out event handler on the 
        /// main form to have.  So the method that handles our event has to except
        /// a string as a paramter.  You can pass whatever you want.
        /// </summary>
        /// <param name="SeatNumber"></param>
        public delegate void SeatClickDelegate(string SeatNumber);

        /// <summary>
        /// Delegate for the button click.
        /// </summary>
        /// <param name="SeatNumber"></param>
        public delegate void ButtonClickDelegate(string SeatNumber);

        /// <summary>
        /// Create the event that is raised when a seat is clicked.
        /// </summary>
        public event SeatClickDelegate SeatClickEvent;

        /// <summary>
        /// Create the event for the button click.
        /// </summary>
        public event ButtonClickDelegate ButtonClickEvent;

        public ctrlMyUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The user has clicked on a seat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Seat_Click(object sender, EventArgs e)
        {
            Label MyLabel = (Label)sender;

            //This is what raises the event, just like as if a button had been 
            //clicked.  In our case we are telling our problem that a label has 
            //been clicked, and who ever is supposed to handle this event should 
            //hangle it, and by the way here is the seat number.
            if (SeatClickEvent != null)
            {
                SeatClickEvent(MyLabel.Tag.ToString());
            }
        }

        /// <summary>
        /// The user clicked the button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRaiseButtonEvent_Click(object sender, EventArgs e)
        {
            if (ButtonClickEvent != null)
            {
                ButtonClickEvent("User clicked the button");
            }	
        }


    }
}
