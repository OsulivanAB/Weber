using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MathGameOutline
{
    public partial class frmGame : Form
    {
        /// <summary>
        /// Variable to hold the high scores form.
        /// </summary>
        private frmHighScores frmCopyHighScores;

        /// <summary>
        /// Property to get and set the high scores.
        /// </summary>
        public frmHighScores CopyHighScores
        {
            get { return frmCopyHighScores; }
            set { frmCopyHighScores = value; }
        }

        public frmGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hide the game form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEndGame_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Show the high scores form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdShowHighScores_Click(object sender, EventArgs e)
        {
            //Hide the game form
            this.Hide();
            //Show the high scores
            frmCopyHighScores.ShowDialog();
        }
    }
}