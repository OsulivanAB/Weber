using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_14_Windows_Form_Timer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// A timer.
        /// </summary>
        Timer MyTimer;

        public Form1()
        {
            InitializeComponent();

            ///Set up the timer
            MyTimer = new Timer();
            MyTimer.Interval = 1000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
        }       

        /// <summary>
        /// Start the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MyTimer.Start();
        }

        /// <summary>
        /// Display the date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// Handle input of the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only numbers and backspace
            if (!(Char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)8))
            {
                if (e.KeyChar == (char)13)
                {
                    MessageBox.Show("Pressed the enter key");
                }
                else
                {
                    // the pressed key is not a number or backspace
                    //prevent the character from being displayed in the textbox
                    e.Handled = true;
                }
            }

        }
    }
}
