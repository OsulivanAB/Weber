using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3
{
    public partial class Form1 : Form
    {
        clsGradebook gBook;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region Methods
        /// <summary>
        /// Create a new gradebook object, unlocks the rest of the form and locks the counts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_submit_counts_Click(object sender, EventArgs e)
        {
            #region Attributes

            int studentCount = 0;   // variable to hold user input for student count
            int assignmentCount = 0; // variable to hold user input for assignment count

            #endregion

            #region Get user Input

            // Attempt to Convert user input to Int Data Type
            Int32.TryParse(textBox_count_students.Text, out studentCount); 
            Int32.TryParse(textBox_count_assignments.Text, out assignmentCount);

            #endregion

            #region Validate User Input

            if (studentCount == 0 || studentCount < 1 || studentCount > 10)
            {
                throw_error("Student count must be between 1 and 10");
                return;
            }
            if (assignmentCount == 0 || assignmentCount < 1 || assignmentCount > 99)
            {
                throw_error("Assignment count must be between 1 and 99");
                return;
            }

            #endregion

            // Create gradebook class to hold info
            gBook = new clsGradebook(studentCount, assignmentCount);

            #region Enable/Disable Fields

            // Disable input in the count area
            textBox_count_students.Enabled = false;
            textBox_count_assignments.Enabled = false;
            label_Count_Students.Enabled = false;
            label_Count_Assignments.Enabled = false;
            button_submit_counts.Enabled = false;

            // Enable the rest of the fields
            button_reset_scores.Enabled = true;
            button_first_student.Enabled = true;
            button_prev_student.Enabled = true;
            button_next_student.Enabled = true;
            button_last_student.Enabled = true;
            label_student_info.Enabled = true;
            textBox_student_info.Enabled = true;
            button_save_name.Enabled = true;
            label_assignment_info_assignment_number.Enabled = true;
            label_assignment_info_score.Enabled = true;
            textBox_assignment_info_assignment_number.Enabled = true;
            textBox_Assignment_info_score.Enabled = true;
            button_save_score.Enabled = true;
            button_display_scores.Enabled = true;
            richTextBox_score_display.Enabled = true;

            #endregion

            // Call Function to update UI
            update_ui();

        }

        /// <summary>
        /// Updates all labels and textboxes in the UI
        /// </summary>
        private void update_ui()
        {
            string s;   // string to hold data before it's pushed to the UI
            int i = gBook.index + 1; // Indicates which student we're looking at
            int numAssignments = gBook.assignmentCount; // Number of Assignments in the gBook

            // Hide the error label
            label_errors.Visible = false;

            // Student Info Label
            s = "Student #" + i.ToString() + " :";
            label_student_info.Text = s;

            // Student Info Textbox
            textBox_student_info.Text = gBook.getCurrentStudent();

            // Enter Assignment Number Label
            s = "Enter Assignment Number (1-" + numAssignments.ToString() + "):";
            label_assignment_info_assignment_number.Text = s;

            // Clear Rich Text box because the data may no longer be accurate
            richTextBox_score_display.Text = "";

            // Disable "<< First Student" button and "< Prev Student" button if index is 0
            if (gBook.index == 0)
            {
                button_first_student.Enabled = false;
                button_prev_student.Enabled = false;
            }
            else
            {
                button_first_student.Enabled = true;
                button_prev_student.Enabled = true;
            }

            // Disable ">> Last Student" button and "> Next Student" button if index is at the end
            if (gBook.index == gBook.studentCount - 1)
            {
                button_last_student.Enabled = false;
                button_next_student.Enabled = false;
            }
            else
            {
                button_last_student.Enabled = true;
                button_next_student.Enabled = true;
            }

        }

        /// <summary>
        /// Disables all fields and requests new count values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_reset_scores_Click(object sender, EventArgs e)
        {
            // Disable input in the count area
            textBox_count_students.Enabled = true;
            textBox_count_assignments.Enabled = true;
            label_Count_Students.Enabled = true;
            label_Count_Assignments.Enabled = true;
            button_submit_counts.Enabled = true;

            // Enable the rest of the fields
            button_reset_scores.Enabled = false;
            button_first_student.Enabled = false;
            button_prev_student.Enabled = false;
            button_next_student.Enabled = false;
            button_last_student.Enabled = false;
            label_student_info.Enabled = false;
            textBox_student_info.Enabled = false;
            button_save_name.Enabled = false;
            label_assignment_info_assignment_number.Enabled = false;
            label_assignment_info_score.Enabled = false;
            textBox_assignment_info_assignment_number.Enabled = false;
            textBox_Assignment_info_score.Enabled = false;
            button_save_score.Enabled = false;
            button_display_scores.Enabled = false;
            richTextBox_score_display.Enabled = false;

            // Remove any values currently in count text boxes
            textBox_count_students.Text = "";
            textBox_count_assignments.Text = "";

            // Hide the error label
            label_errors.Visible = false;
        }

        /// <summary>
        /// Changes the index to 0 (the first student) and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_first_student_Click(object sender, EventArgs e)
        {
            gBook.index = 0;
            update_ui();
        }

        /// <summary>
        /// Changes the index to studentArray.Length minus 1 (The last student) and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_last_student_Click(object sender, EventArgs e)
        {
            gBook.index = gBook.studentCount - 1;
            update_ui();
        }

        /// <summary>
        /// Changes the index to the previous value (index - 1) and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_prev_student_Click(object sender, EventArgs e)
        {
            gBook.index--;
            update_ui();
        }

        /// <summary>
        /// Changes the index to the next value (index + 1) and updates the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_next_student_Click(object sender, EventArgs e)
        {
            gBook.index++;
            update_ui();
        }

        /// <summary>
        /// Updates the name of the current student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_name_Click(object sender, EventArgs e)
        {
            // Make sure that the student name field is not blank
            if (textBox_student_info.Text.Length == 0)
            {
                throw_error("Student name can not be blank.");
                return;
            }
            // Set the student name to the value of the text field
            gBook.studentName[gBook.index] = textBox_student_info.Text;
            // Update UI
            update_ui();
        }

        /// <summary>
        /// Updates the assignment score that the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_score_Click(object sender, EventArgs e)
        {
            int iAssignNum = -1; // Variable to hold assignment number
            int iScore = -1;    // Variable to hold score
            int iAssignIndex;   // Variable to hold the index of the assignment

            // Convert user input to Int and store in variables if successful
            Int32.TryParse(textBox_assignment_info_assignment_number.Text, out iAssignNum);
            Int32.TryParse(textBox_Assignment_info_score.Text, out iScore);

            // Check if Assignment Number is Valid
            if (iAssignNum <= 0 || iAssignNum > gBook.assignmentCount)
            {
                throw_error("Assignment number must be between 1 and " + gBook.assignmentCount.ToString());
                return;
            }
            // Check if Score is Valid
            if (iScore < 0 || iScore > 100)
            {
                throw_error("Score must be between 0 and 100");
                return;
            }
            else if (iScore == 0 && textBox_Assignment_info_score.Text != "0")
            {
                throw_error("Score must be a number");
                return;
            }
            // Update Score
            iAssignIndex = iAssignNum - 1;
            gBook.score[gBook.index, iAssignIndex] = iScore;

            // Clear Text Boxes
            textBox_assignment_info_assignment_number.Text = "";
            textBox_Assignment_info_score.Text = "";

            // Update Display
            update_ui();
        }

        /// <summary>
        /// Updates the Scores rich text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_display_scores_Click(object sender, EventArgs e)
        {
            // Score Display
            richTextBox_score_display.Text = gBook.getScores();
        }

        /// <summary>
        /// Un-hides the error label with a custom error message
        /// </summary>
        /// <param name="message">String message to display for error</param>
        private void throw_error(string message)
        {
            // Update the Error Label
            label_errors.Text = "Error:\n" + message;
            // Make Error Label visible
            label_errors.Visible = true;
        }
        #endregion
    }
}
