using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MathGameOutline
{
    public partial class frmHighScores : Form
    {
        public frmHighScores()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hide the high scores form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCloseHighScores_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}