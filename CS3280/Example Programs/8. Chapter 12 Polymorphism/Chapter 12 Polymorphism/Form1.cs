using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_12_Polymorphism
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //NOTE: Since we changed clsVehicle to an Abstract class we can NOT instaniate it. ////////////////////////////////////////
        //COMMENT OUT EVERYTHING
        private void cmdStart_Click(object sender, EventArgs e)
        {
            //Declare three objects of class clsVehicle using the different constructors
            //clsVehicle MyVehicle1 = new clsVehicle();
            //clsVehicle MyVehicle2 = new clsVehicle("150");
            //clsVehicle MyVehicle3 = new clsVehicle("200 mph", "Red", "Ford", "Mustang");

            //Set the first vehicles attributes
            //MyVehicle1.Make = "Mitsubishi";	//using the property
            //MyVehicle1.Model = "Eclipse";	//using the property
            //MyVehicle1.sColor = "Red";		//accessing the class member directly

            //This is a static method from the class clsVehicle
            //lblStart.Text = clsVehicle.StartVehicle();

            //Can only access the public methods
            //MyVehicle2.ThisIsAPublicMethod();
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

        private void cmdPoly_Click(object sender, EventArgs e)
        {
            //Declare an array of class clsVehicle
            clsVehicle[] MyVehicleArray = new clsVehicle[3];

            //Declar three objects of type Car and Truck
            clsCar MyCar1 = new clsCar();
            clsTruck MyTruck1 = new clsTruck();
            clsCar MyCar2 = new clsCar();

            //Add the objects to the array of Vehicle objects
            MyVehicleArray[0] = MyCar1;
            MyVehicleArray[1] = MyTruck1;
            MyVehicleArray[2] = MyCar2;

            //Loop through the array
            for (int i = 0; i < MyVehicleArray.Length; i++)
            {
                //Call the abstract Method
                lblPoly.Text += MyVehicleArray[i].AbstractMethodExample(i.ToString());
                lblPoly.Text += "\n\n";
            }
        }
    }
}