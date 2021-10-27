using System;
using System.Windows.Forms;

namespace MathGameOutline
{
    public partial class frmMathMenu : Form
    {

        /// <summary>
        /// Class that holds the high scores.
        /// </summary>
        frmHighScores frmHighScoresForm;

        /// <summary>
        /// Class that holds the user data.
        /// </summary>
        frmEnterUserData frmEnterUserDataForm;

        /// <summary>
        /// Class where the game is played.
        /// </summary>
        frmGame frmGameForm;

        public frmMathMenu()
        {
            InitializeComponent();

            frmHighScoresForm = new frmHighScores();
            frmEnterUserDataForm = new frmEnterUserData();
            frmGameForm = new frmGame();

            //Pass the high scores form to the game form.  This way the high scores form may be displayed via the game form.
            frmGameForm.CopyHighScores = frmHighScoresForm;
        }

        /// <summary>
        /// Show the high scores screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHighScores_Click(object sender, EventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the high scores screen
            frmHighScoresForm.ShowDialog();
            //Show the main form
            this.Show();
        }

        /// <summary>
        /// Play the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlayGame_Click(object sender, EventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the game form
            frmGameForm.ShowDialog();
            //Show the main form
            this.Show();
        }

        /// <summary>
        /// Show the user data form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnterUserData_Click(object sender, EventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the user data form
            frmEnterUserDataForm.ShowDialog();
            //Show the main form
            this.Show();
        }



    }
}