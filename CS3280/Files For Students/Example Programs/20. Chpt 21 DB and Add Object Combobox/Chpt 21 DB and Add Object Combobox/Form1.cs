using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chpt_21_DB_and_Add_Object_Combobox
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Data access class.
        /// </summary>
        clsDataAccess db;

        public Form1()
        {
            InitializeComponent();

            db = new clsDataAccess();

            string sSQL;    //Holds an SQL statement
            int iRet = 0;   //Number of return values
            DataSet ds = new DataSet(); //Holds the return values
            clsPassenger Passenger; //Used to load the return values into the combo box

            //Create the SQL statement to extract the passengers
            sSQL = "SELECT Passenger.Passenger_ID, First_Name, Last_Name, Flight_ID, Seat_Number " +
                "FROM Passenger, Flight_Passenger_Link " +
                "WHERE Passenger.Passenger_ID = Flight_Passenger_Link.Passenger_ID AND " +
                "Flight_id = 1";

            //Extract the passengers and put them into the DataSet
            ds = db.ExecuteSQLStatement(sSQL, ref iRet);

            //Loop through the data and create passenger classes
            for (int i = 0; i < iRet; i++)
            {
                Passenger = new clsPassenger();
                Passenger.sID = ds.Tables[0].Rows[i][0].ToString();
                Passenger.sFirstName = ds.Tables[0].Rows[i]["First_Name"].ToString();
                Passenger.sLastName = ds.Tables[0].Rows[i]["Last_Name"].ToString();
                Passenger.sFlight = ds.Tables[0].Rows[i][3].ToString();
                Passenger.sSeat = ds.Tables[0].Rows[i][4].ToString();

                cboPassengers.Items.Add(Passenger);
            }
        }

        /// <summary>
        /// The user has clicked on a taken seat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Seat_Click(object sender, EventArgs e)
        {
            Label MyLabel = (Label)sender;  //Get the label that the user clicked
            string sSeatNumber; //The seat number
            clsPassenger Passenger; //The Passenger

            //Check to see if the seat backcolor is read
            if (MyLabel.BackColor == Color.Red)
            {
                //Turn the seat green
                MyLabel.BackColor = Color.Green;

                //Get the seat number
                sSeatNumber = MyLabel.Text;

                //Loop through the items in the combo box
                for (int i = 0; i < cboPassengers.Items.Count; i++)
                {
                    //Extract the passenger from the combo box
                    Passenger = (clsPassenger)cboPassengers.Items[i];

                    //If the seat number matches then select the passenger in the combo box
                    if (sSeatNumber == Passenger.sSeat)
                    {
                        cboPassengers.SelectedIndex = i;
                    }
                }
            }
        }

        /// <summary>
        /// The user has selected an item in the combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPassengers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create a Passenger object
            clsPassenger Passenger;

            //Extract the selected Passenger object from the combo box
            Passenger = (clsPassenger)cboPassengers.SelectedItem;

            //Set the seat label
            lblSeat.Text = Passenger.sSeat;
            
            //Need to find the selected seat in the panel.  Loop through each label in the panel.
            foreach (Label MyLabel in pnlSeats.Controls)
            {
                MyLabel.BackColor = Color.Blue;

                //Check to see if the passenger's seat matches the label
                if (MyLabel.Text == Passenger.sSeat)
                {
                    MyLabel.BackColor = Color.Green;
                }
            }
        }
    }
}