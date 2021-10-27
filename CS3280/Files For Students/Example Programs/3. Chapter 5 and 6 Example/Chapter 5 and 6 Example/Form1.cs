using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//Need to include to use threading
using System.Threading;

namespace Chapter_5_and_6_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdMyButton_Click(object sender, EventArgs e)
        {
            //This section shows the use of "if", "else", and "if then else" statements
            //////////////////////////////////////////////////////////////////////////////////////////////////
            int iNumber;

            //Extract the number from the textbox
            iNumber = Convert.ToInt32(txtMyTextbox.Text);

            if (iNumber > 5)
            {
                label1.Text = "Number is greater than 5";
            }
            else if (iNumber < 5)
            {
                label1.Text = "Number is less than 5";
            }
            else
            {
                label1.Text = "Number is equal to 5";
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////



            //This section shows the use of the "while" loop
            //////////////////////////////////////////////////////////////////////////////////////////////////
            int iCounter = 0;

            //This will loop until this condition is false
            while (iCounter < 10)
            {

                //This line prints the loop variable and a newline character
                richTextBox1.Text += iCounter.ToString() + Environment.NewLine;

                //We need to increment the variable
                iCounter++;

                //These statements just show the use of the increment and decrement operators
                //iCounter = iCounter + 1;
                //iCounter -= 1;
                //iCounter--;
                //iCounter++;
                //--iCounter;
                //++iCounter;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////



            //This section shows the use of the "for" loop
            //////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < 10; i++)
            {
                richTextBox1.Text += i.ToString() + "\n";
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            

            //This section shows the use of String.Format()
            //////////////////////////////////////////////////////////////////////////////////////////////////
            richTextBox1.Text += String.Format("{0:c}", 23.34);
            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += String.Format("{0:f}", 23.347636);
            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += String.Format("{0:f3}", 23.347636);
            //////////////////////////////////////////////////////////////////////////////////////////////////



            //This section shows the use of multiple condition statements in an "if" statement
            //////////////////////////////////////////////////////////////////////////////////////////////////
            int j = 4;
            int k = 5;

            //The first if will result in a false statement and will not get executed.  The second if statement
            //does result in a true value and therefore will get executed.
            if ((j == 3) && (k == 4))
            {
                //won't get executed
            }
            else if ((j == 4) && (k == 5))
            {
                //will get executed

            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// This method changes the dice face.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeImage_Click(object sender, EventArgs e)
        {
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

            for (int i = 1; i < 7; i++)
            {
                pbImage.Image = Image.FromFile("die" + i.ToString() + ".gif");
                pbImage.Refresh();
                Thread.Sleep(300);
            }
        }
    }
}