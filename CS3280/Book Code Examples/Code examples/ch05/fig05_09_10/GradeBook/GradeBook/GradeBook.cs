// Fig. 5.9: GradeBook.cs
// GradeBook class that solves class-average problem using 
// sentinel-controlled repetition.
using System;

public class GradeBook
{
   // auto-implemented property CourseName
   public string CourseName { get; set; }

   // constructor initializes the CourseName property
   public GradeBook( string name )
   {
      CourseName = name; // set CourseName to name
   } // end constructor

   // display a welcome message to the GradeBook user
   public void DisplayMessage()
   {
      Console.WriteLine( "Welcome to the grade book for\n{0}!\n",
         CourseName );
   } // end method DisplayMessage

   // determine the average of an arbitrary number of grades
   public void DetermineClassAverage()
   {
      int total; // sum of grades
      int gradeCounter; // number of grades entered
      int grade; // grade value
      double average; // number with decimal point for average

      // initialization phase
      total = 0; // initialize total
      gradeCounter = 0; // initialize loop counter

      // processing phase
      // prompt for and read a grade from the user
      Console.Write( "Enter grade or -1 to quit: " );
      grade = Convert.ToInt32( Console.ReadLine() );

      // loop until sentinel value is read from the user
      while ( grade != -1 )
      {
         total = total + grade; // add grade to total
         gradeCounter = gradeCounter + 1; // increment counter

         // prompt for and read the next grade from the user
         Console.Write( "Enter grade or -1 to quit: " );
         grade = Convert.ToInt32( Console.ReadLine() );
      } // end while

      // termination phase
      // if the user entered at least one grade...
      if ( gradeCounter != 0 )
      {
         // calculate the average of all the grades entered
         average = ( double ) total / gradeCounter;

         // display the total and average (with two digits of precision)
         Console.WriteLine( "\nTotal of the {0} grades entered is {1}",
            gradeCounter, total );
         Console.WriteLine( "Class average is {0:F}", average );
      } // end if
      else // no grades were entered, so output error message
         Console.WriteLine( "No grades were entered" );
   } // end method DetermineClassAverage
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
