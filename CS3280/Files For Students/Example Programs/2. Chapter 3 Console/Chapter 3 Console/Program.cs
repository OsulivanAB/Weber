using System;
using System.Collections.Generic;
using System.Text;

//Add this reference
using System.Windows.Forms;

namespace Chapter_3_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //This is a comment
            Console.WriteLine("Hello World");
            Console.ReadLine();

            //Shows escape characters
            Console.WriteLine("Hello\t World \nprogram test");
            Console.ReadLine();

            //Create variables
            string sFirstNumber;
            string sSecondNumber;
            int iFirstNumber;
            int iSecondNumber;
            int iSum;

            //Get the numbers
            Console.Write("Enter First Number: ");
            sFirstNumber = Console.ReadLine();
            Console.Write("Enter Second Number: ");
            sSecondNumber = Console.ReadLine();

            //Convert the numbers
            Int32.TryParse(sFirstNumber, out iFirstNumber);
            //iFirstNumber = Int32.Parse(sFirstNumber);     //Don't use
            iSecondNumber = Convert.ToInt32(sSecondNumber);

            //Add the numbers
            iSum = iFirstNumber + iSecondNumber;

            //Display the total
            MessageBox.Show("The sum of " + sFirstNumber + " and " + sSecondNumber + " is " + iSum, "Sum",
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            
            //If statements
            if (iFirstNumber > iSecondNumber)
            {
                MessageBox.Show(sFirstNumber + " is greater than " + iSecondNumber);
            }

            if (iFirstNumber < iSecondNumber)
            {
                MessageBox.Show(sFirstNumber + " is less than " + iSecondNumber);
            }

        }
    }
}
