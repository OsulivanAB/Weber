// Fig. 8.20: GradeBook.cs
// Grade book using rectangular array to store grades.
using System;

public class GradeBook
{
   private int[ , ] grades; // rectangular array of student grades

   // auto-implemented property CourseName
   public string CourseName { get; set; }

   // two-parameter constructor initializes 
   // auto-implemented property CourseName and grades array
   public GradeBook( string name, int[ , ] gradesArray )
   {
      CourseName = name; // set CourseName to name
      grades = gradesArray; // initialize grades array
   } // end two-parameter GradeBook constructor

   // display a welcome message to the GradeBook user
   public void DisplayMessage()
   {
      // auto-implemented property CourseName gets the name of course
      Console.WriteLine( "Welcome to the grade book for\n{0}!\n",
         CourseName );
   } // end method DisplayMessage

   // perform various operations on the data
   public void ProcessGrades()
   {
      // output grades array
      OutputGrades();

      // call methods GetMinimum and GetMaximum
      Console.WriteLine( "\n{0} {1}\n{2} {3}\n",
         "Lowest grade in the grade book is", GetMinimum(),
         "Highest grade in the grade book is", GetMaximum() );

      // output grade distribution chart of all grades on all tests
      OutputBarChart();
   } // end method ProcessGrades

   // find minimum grade
   public int GetMinimum()
   {
      // assume first element of grades array is smallest
      int lowGrade = grades[ 0, 0 ];

      // loop through elements of rectangular grades array
      foreach ( int grade in grades )
      {
         // if grade less than lowGrade, assign it to lowGrade
         if ( grade < lowGrade )
            lowGrade = grade;
      } // end foreach

      return lowGrade; // return lowest grade
   } // end method GetMinimum

   // find maximum grade
   public int GetMaximum()
   {
      // assume first element of grades array is largest
      int highGrade = grades[ 0, 0 ];

      // loop through elements of rectangular grades array
      foreach ( int grade in grades )
      {
         // if grade greater than highGrade, assign it to highGrade
         if ( grade > highGrade )
            highGrade = grade;
      } // end foreach

      return highGrade; // return highest grade
   } // end method GetMaximum

   // determine average grade for particular student
   public double GetAverage( int student )
   {
      // get the number of grades per student
      int amount = grades.GetLength( 1 );
      int total = 0; // initialize total

      // sum grades for one student
      for ( int exam = 0; exam < amount; exam++ )
         total += grades[ student, exam ];

      // return average of grades
      return ( double ) total / amount;
   } // end method GetAverage

   // output bar chart displaying overall grade distribution
   public void OutputBarChart()
   {
      Console.WriteLine( "Overall grade distribution:" );

      // stores frequency of grades in each range of 10 grades
      int[] frequency = new int[ 11 ];

      // for each grade in GradeBook, increment the appropriate frequency 
      foreach ( int grade in grades )
      {
         ++frequency[ grade / 10 ];
      } // end foreach

      // for each grade frequency, display bar in chart
      for ( int count = 0; count < frequency.Length; count++ )
      {
         // output bar label ( "00-09: ", ..., "90-99: ", "100: " )
         if ( count == 10 )
            Console.Write( "  100: " );
         else
            Console.Write( "{0:D2}-{1:D2}: ",
               count * 10, count * 10 + 9 );

         // display bar of asterisks
         for ( int stars = 0; stars < frequency[ count ]; stars++ )
            Console.Write( "*" );

         Console.WriteLine(); // start a new line of output
      } // end outer for
   } // end method OutputBarChart

   // output the contents of the grades array
   public void OutputGrades()
   {
      Console.WriteLine( "The grades are:\n" );
      Console.Write( "            " ); // align column heads

      // create a column heading for each of the tests
      for ( int test = 0; test < grades.GetLength( 1 ); test++ )
         Console.Write( "Test {0}  ", test + 1 );

      Console.WriteLine( "Average" ); // student average column heading

      // create rows/columns of text representing array grades
      for ( int student = 0; student < grades.GetLength( 0 ); student++ )
      {
         Console.Write( "Student {0,2}", student + 1 );

         // output student's grades
         for ( int grade = 0; grade < grades.GetLength( 1 ); grade++ )
            Console.Write( "{0,8}", grades[ student, grade ] );

         // call method GetAverage to calculate student's average grade;
         // pass row number as the argument to GetAverage
         Console.WriteLine( "{0,9:F}", GetAverage( student ) );
      } // end outer for
   } // end method OutputGrades
} // end class GradeBook


/**************************************************************************
 * (C) Copyright 1992-2011 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
