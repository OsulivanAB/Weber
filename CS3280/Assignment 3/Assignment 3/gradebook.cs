using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    /// <summary>
    /// Class that holds all the data for the Gradebook application
    /// </summary>
    class clsGradebook
    {
        #region attributes
        /// <summary>
        /// Number of Students in grade book.
        /// </summary>
        private int iNumStudents;

        /// <summary>
        /// Number of Assignments per student.
        /// </summary>
        private int iNumAssignments;

        /// <summary>
        /// Array to hold student names.
        /// </summary>
        private string[] sStudents;

        /// <summary>
        /// Array to hold assignment scores.
        /// </summary>
        private int[,] iAssignments;

        /// <summary>
        /// Index to track which student the user is looking at
        /// </summary>
        private int iIndex;

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public clsGradebook()
        {
            // set default (MAX) values for number of students and number of assignments
            iNumStudents = 10;
            iNumAssignments = 99;

            // Set index to the 0 (The first student in the array)
            index = 0;

            // create the default arrays
            sStudents = setupStudents(iNumStudents);
            iAssignments = setupAssignments(iNumStudents, iNumAssignments);
        }

        /// <summary>
        /// Overloaded constructor that takes custom student and assignment counts
        /// </summary>
        /// <param name="sCount">Int count of students (max 10)</param>
        /// <param name="aCount">Int count of assignments (Max 99)</param>
        public clsGradebook(int sCount, int aCount)
        {
            // set default (MAX) values for number of students and number of assignments
            studentCount = sCount;
            assignmentCount = aCount;

            // create the default arrays
            sStudents = setupStudents(iNumStudents);
            iAssignments = setupAssignments(iNumStudents, iNumAssignments);

            // Set index to the 0 (The first student in the array)
            index = 0;
        }

        #endregion

        #region properties

        /// <summary>
        /// Property that gets, sets, and validates iNumStudents values
        /// </summary>
        public int studentCount
        {
            get
            {
                return iNumStudents;
            }
            set
            {
                // Check to make sure value is within range
                if (value > 0 && value < 11)
                    iNumStudents = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "StudentCount", value, "Student count must be between 1 and 10");
            }
        }

        /// <summary>
        /// Property that gets, sets, and validates iNumAssignments values
        /// </summary>
        public int assignmentCount
        {
            get
            {
                return iNumAssignments;
            }
            set
            {
                // Check to make sure value is within range of 1 - 99
                if (value > 0 && value < 100)
                    iNumAssignments = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "assignmentCount", value, "Assignment count must be between 1 and 99");
            }
        }

        /// <summary>
        /// Property that gets, sets and validates sStudents values.
        /// </summary>
        public string[] studentName
        {
            get
            {
                return sStudents;
            }
            set
            {
                if (value.Length > 0)
                    sStudents = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "StudentName", value, "Student name can not be blank");
            }
        }

        /// <summary>
        /// Property that gets and sets assignment scores
        /// </summary>
        public int[,] score
        {
            get
            {
                return iAssignments;
            }
            set
            {
                iAssignments = value;
            }
        }

        /// <summary>
        /// Gets, sets, and validates the iIndex variable.
        /// </summary>
        public int index
        {
            get
            {
                return iIndex;
            }
            set
            {
                // Check if value is within range
                if (value >= 0 && value <= sStudents.Length)
                    iIndex = value;
                else
                    throw new ArgumentOutOfRangeException(
                        "index", value, "index count is invalid");
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Returns an array of students, defaulting each name to Student ##
        /// </summary>
        /// <param name="size">Number of students</param>
        /// <returns></returns>
        private string[] setupStudents(int size)
        {
            // create array
            string[] x = new string[size];

            // loop through array and set each default student name
            for ( int i = 0; i < size; i++ )
            {
                // Create variable to hold student number
                int iNumber = i + 1;

                // Create variable to hold student name
                string sName = "Student #" + iNumber.ToString();

                // Insert name into array
                x[i] = sName;
            }

            return x;
        }

        /// <summary>
        /// Returns a multidimensional array of assignments, defaulting each assignment score to 0.
        /// </summary>
        /// <param name="studentSize">Number of Students.</param>
        /// <param name="assignmentCount">Number of Assignments.</param>
        /// <returns></returns>
        private int[,] setupAssignments(int studentSize, int assignmentCount)
        {
            // create array
            int[,] x = new int[studentSize, assignmentCount];

            // loop through array and set each default score to 0
            for (int i = 0; i < studentSize; i++)
            {
                for (int j = 0; j < assignmentCount; j++)
                {
                    x[i, j] = 0;
                }
            }

            return x;
        }

        /// <summary>
        /// Function to get name of the student at the current index
        /// </summary>
        /// <returns>String of student name</returns>
        public string getCurrentStudent()
        {
            return sStudents[iIndex];
        }

        /// <summary>
        /// Gets the list of students and their scores and formats them for output
        /// </summary>
        /// <returns>String of  formatted students and scores</returns>
        public string getScores()
        {
            // Create string to build on with the data
            string s = "STUDENT";

            // Add Assignment Numbers to string to the title row of the string
            for (int i = 0; i < iNumAssignments; i++)
            {
                int num = i + 1;
                s = s + "\t#" + num.ToString();
            }

            // Add Average and Grade to the end of the title row of the string
            s = s + "\tAVG\tGRADE";

            // Loop Over each student
            for (int i = 0; i < iNumStudents; i++)
            {
                int iSum = 0;    // Variable to hold the sum of assignment scores
                decimal dAvg;    // Variable to hold the average of assignment scores
                s = s + "\n";   // Begin a new line
                s = s + sStudents[i];   // Enter Students Name

                // Loop through Assignment Scores
                for (int j = 0; j < iNumAssignments; j++)
                {
                    s = s + "\t" + iAssignments[i, j].ToString();   // Add Assignment Score to string
                    iSum = iSum + iAssignments[i, j];   // Add Assignment Score to Sum Variable
                }

                dAvg = Math.Round( (decimal) iSum / iNumAssignments, 2);   // Calculate the Average Score
                s = s + "\t" + dAvg.ToString(); // Add the average onto the string

                // Add Letter Grade onto the string
                if (dAvg >= 93)
                    s = s + "\tA";
                else if (dAvg >= 90)
                    s = s + "\tA-";
                else if (dAvg >= 87)
                    s = s + "\tB+";
                else if (dAvg >= 83)
                    s = s + "\tB";
                else if (dAvg >= 80)
                    s = s + "\tB-";
                else if (dAvg >= 77)
                    s = s + "\tC+";
                else if (dAvg >= 73)
                    s = s + "\tC";
                else if (dAvg >= 70)
                    s = s + "\tC-";
                else if (dAvg >= 67)
                    s = s + "\tD+";
                else if (dAvg >= 63)
                    s = s + "\tD";
                else if (dAvg >= 60)
                    s = s + "\tD-";
                else 
                    s = s + "\tE";
            }

            return s;
        }

        #endregion
    }
}
