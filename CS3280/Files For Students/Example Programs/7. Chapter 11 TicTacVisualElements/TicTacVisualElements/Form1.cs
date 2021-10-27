using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TicTacVisualElements
{
    /// <summary>
    /// This form has four labels on it.  Each label's click event is handled by the method lblSpace_Click.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method handles the click event for the four labels.
        /// </summary>
        /// <param name="sender">This parameter holds the reference to the object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void lblSpace_Click(object sender, EventArgs e)
        {
            //Cast the sender into the label variable
            Label MyLabel = (Label)sender;

            MyLabel.Text = "X";

            SetBackgroundColor(MyLabel);
        }

        /// <summary>
        /// Set the background color of the label that is passed in.
        /// </summary>
        /// <param name="lblLabel"></param>
        private void SetBackgroundColor(Label lblLabel)
        {
            lblLabel.BackColor = Color.Yellow;
        }
    }
}