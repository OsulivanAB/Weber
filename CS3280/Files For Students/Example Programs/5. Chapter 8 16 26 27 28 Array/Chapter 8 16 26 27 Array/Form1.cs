using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_8_16_26_27_Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Single Dimension Array

        private void cmdSingle_Click(object sender, EventArgs e)
        {
            //Declare the single dimension array
            int[] MyArray = new int[4];

            //Load with values
            MyArray[0] = 8;
            MyArray[1] = 3;
            MyArray[2] = 10;
            MyArray[3] = 1;

            //Loop through using numbers
            for (int i = 0; i < 4; i++)
            {
                lblSingle1.Text += MyArray[i].ToString();
                lblSingle1.Text += "\n";
            }

            //Loop through using the Length method
            for (int i = 0; i < MyArray.Length; i++)
            {
                lblSingle2.Text += MyArray[i].ToString();
                lblSingle2.Text += "\n";
            }

            //Loop through using the GetLowerBound and GetUpperBound methods
            for (int i = MyArray.GetLowerBound(0); i <= MyArray.GetUpperBound(0); i++)
            {
                lblSingle3.Text += MyArray[i].ToString();
                lblSingle3.Text += "\n";
            }

            //Pass the array to a method by reference
            MethodToPassAnArray(MyArray);
        }

        //Method that has a single dimensional array passed in
        private void MethodToPassAnArray(int[] PassedArray)
        {
            foreach (int MyInt in PassedArray)
            {
                lblSingle4.Text += MyInt.ToString();
                lblSingle4.Text += "\n";
            }
        }

        #endregion


        #region Multi Dimensional Array

        private void cmdMultiple_Click(object sender, EventArgs e)
        {
            //Declare the multi dimensional array
            int[,] MyMult = new int[3, 4];

            //Load with values
            MyMult[0, 0] = 1;
            MyMult[0, 1] = 2;
            MyMult[0, 2] = 3;
            MyMult[0, 3] = 4;

            MyMult[1, 0] = 5;
            MyMult[1, 1] = 6;
            MyMult[1, 2] = 7;
            MyMult[1, 3] = 8;

            MyMult[2, 0] = 9;
            MyMult[2, 1] = 10;
            MyMult[2, 2] = 11;
            MyMult[2, 3] = 12;

            MessageBox.Show(MyMult.Length.ToString());

            //Loop through using numbers
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    lblMultiple1.Text += MyMult[i, j].ToString() + "  ";

                }
                lblMultiple1.Text += "\n";
            }

            //Loop through using the GetLength method
            for (int i = 0; i < MyMult.GetLength(0); i++)
            {
                for (int j = 0; j < MyMult.GetLength(1); j++)
                {
                    lblMultiple2.Text += MyMult[i, j].ToString() + "  ";
                }
                lblMultiple2.Text += "\n";
            }

            //Loop through using the GetLowerBound and GetUpperBound methods
            for (int i = MyMult.GetLowerBound(0); i <= MyMult.GetUpperBound(0); i++)
            {
                for (int j = MyMult.GetLowerBound(1); j <= MyMult.GetUpperBound(1); j++)
                {
                    lblMultiple3.Text += MyMult[i, j].ToString() + "  ";
                }
                lblMultiple3.Text += "\n";
            }

            //Pass the array to a method by reference
            MethodToPassAnArray2(MyMult);

        }

        //Method that has a multi dimensional array passed in
        private void MethodToPassAnArray2(int[,] PassedArray)
        {
            foreach (int a in PassedArray)
            {
                lblMultiple4.Text += a.ToString() + " ";
            }
        }

        #endregion


        #region HashTable

        private void cmdHashTable_Click(object sender, EventArgs e)
        {

            //Declare the hash table
            Hashtable MyHash = new Hashtable();

            //Add some values to it
            MyHash.Add("528-99-999", "Shawn");
            MyHash.Add("528-88-888", "Mike");
            MyHash.Add("528-77-777", "John");

            //Display the values using the keys
            lblHash.Text += MyHash["528-99-999"].ToString();
            lblHash.Text += "\n";

            lblHash.Text += MyHash["528-88-888"].ToString();
            lblHash.Text += "\n";

            lblHash.Text += MyHash["528-77-777"].ToString();
            lblHash.Text += "\n";

            //See if the hash table contains the string
            lblHash.Text += MyHash.Contains("528-77-777").ToString();
            lblHash.Text += "\n";

            //Remove the string
            MyHash.Remove("528-77-777");

            //See if the hash table contains the string
            if (MyHash["abc"] != null)
            {
                lblHash.Text += "True";
            }
            else
            {
                lblHash.Text += "False";
            }
        }

        #endregion


        #region ArrayList

        private void cmdArrayList_Click(object sender, EventArgs e)
        {
            //Declare the ArrayList
            ArrayList MyArrayList = new ArrayList();
            
            //Add some values
            MyArrayList.Add("E");
            MyArrayList.Add("A");
            MyArrayList.Add("Z");
            MyArrayList.Add("J");
            MyArrayList.Add("B");

            //Insert a value
            MyArrayList.Insert(1, "C");

            //Remove a value
            MyArrayList.Remove("J");

            //Sort the ArrayList
            MyArrayList.Sort();

            //Display the contents
            foreach (string MyString in MyArrayList)
            {
                lblArrayList.Text += MyString;
                lblArrayList.Text += "\n";
            }
        }

        #endregion

       
        #region Generics

        private void cmdGenerics_Click(object sender, EventArgs e)
        {
            //Declare the dictionary
            Dictionary<string, string> MyDictionary = new Dictionary<string, string>();

            //Add some values to it
            MyDictionary.Add("528-99-999", "Shawn");
            MyDictionary.Add("528-88-888", "Mike");

            //Remove a value
            MyDictionary.Remove("528-88-888");

            //Get the value using the key
            MessageBox.Show(MyDictionary["528-99-999"]);


            //Declare the List
            List<string> MyList = new List<string>();

            //Add some values
            MyList.Add("E");
            MyList.Add("A");

            //Remove a value
            MyList.Remove("A");

            //Get the value using the key
            MessageBox.Show(MyList[0]);
        }

        #endregion

    }
}