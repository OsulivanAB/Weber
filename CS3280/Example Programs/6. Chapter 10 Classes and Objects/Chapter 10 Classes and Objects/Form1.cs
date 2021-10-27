using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_10_Classes_and_Objects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            //Declare three objects of class clsVehicle using the different constructors
            clsVehicle MyVehicle1 = new clsVehicle();
            clsVehicle MyVehicle2 = new clsVehicle("150");
            clsVehicle MyVehicle3 = new clsVehicle("200 mph", "Red", "Ford", "Mustang");

            //Set the first vehicles attributes
            MyVehicle1.Make = "Mitsubishi";	//using the property
            MyVehicle1.Model = "Eclipse";	//using the property
            MyVehicle1.sColor = "Red";		//accessing the class member directly

            //This is a static method from the class clsVehicle
            lblStart.Text = clsVehicle.StartVehicle();

            //Can only access the public methods
            MyVehicle2.ThisIsAPublicMethod();

        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            lblStop.Text = clsVehicle.StopVehicle();
        }
    }
}