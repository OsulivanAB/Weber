using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_3_Example_Messagebox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //This is what gets called when the user clicks the button
        private void cmdClickMe_Click(object sender, EventArgs e)
        {
            //This variable is of type "DialogResult".  It tells you which button the user clicked on the message box.
            DialogResult MyResult;

            //This statement does a few things.  First the "Show" method is called to pop up a message box.  Then we pass the "Show"
            //method the text from the textbox.  Next we tell it what the caption should be.  Then we tell it what type of buttons
            //we want on the message box.  Then we tell it what kind of icon we want on the message box.  When the user clicks a 
            //button on the message box the result goes into the variable MyResult.
            MyResult = MessageBox.Show("You typed: " + textBox1.Text, "This is a caption", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            //We can then print out which button the user clicked.
            label1.Text = "You clicked the " + MyResult.ToString() + " button";
        }
    }
}