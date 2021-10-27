using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_11_Inheritance
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

        private void cmdCreateCar_Click(object sender, EventArgs e)
        {
            //Declare two objects of type class clsCar
            clsCar Car1 = new clsCar();
            clsCar Car2 = new clsCar("Wing", true, "125 mph", "Blue", "Mazda", "6");

            //Set the attributes using the properties
            Car2.Has4WheelDrive = true;
            Car2.SpoilerType = "Wing";

            //Set the base class attributes
            Car2.Make = "Mazda";
            Car2.Model = "RX8";

            //Call the public method
            Car2.ThisIsAPublicMethod();

            //Call the static methods
            lblCreateCar.Text = clsCar.StartVehicle();
            lblCreateCar.Text += "\n\n";

            lblCreateCar.Text += clsCar.StopVehicle();

            //A derived class is a type of the base class
            //So a Car is a Vehicle
            if (Car1 is clsVehicle)
            {
                lblCreateCar.Text += "\n\n";
                lblCreateCar.Text += "A Car is a Vehicle";
            }
        }
    }
}