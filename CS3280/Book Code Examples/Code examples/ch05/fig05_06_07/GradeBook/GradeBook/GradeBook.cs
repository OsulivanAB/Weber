// Fig. 5.6: GradeBook.cs
// GradeBook class that solves class-average problem using 
// counter-controlled repetition.
using System;

public class GradeBook
{
   // auto-implemented property CourseName
   public string CourseName { get; set; }

   // constructor initializes CourseName property
   public GradeBook( string name )
   {
      CourseName = name; // set CourseName to name
   } // end constructor

   // display a welcome message to the GradeBook user
   public void DisplayMessage()
   {
      // property CourseName gets the name of the course
      Console.WriteLine( "Welcome to the grade book for\n{0}!\n",
         CourseName );
   } // end method DisplayMessage

   // determine class average based on 10 grades entered by user
   public void DetermineClassAverage()
   {
      int total; // sum of the grades entered by user
      int gradeCounter; // number of the grade to be entered next
      int grade; // grade value entered by the user
      int average; // average of the grades

      // initialization phase
      total = 0; // initialize the total
      gradeCounter = 1; // initialize the loop counter

      // processing phase
      while ( gradeCounter <= 10 ) // loop 10 times
      {
         Console.Write( "Enter grade: " ); // prompt the user
         grade = Convert.ToInt32( Console.ReadLine() ); // read grade
         total = total + grade; // add the grade to total
         gradeCounter = gradeCounter + 1; // increment the counter by 1
      } // end while

      // termination phase
      average = total / 10; // integer division yields integer result

      // display total and average of grades
      Console.WriteLine( "\nTotal of all 10 grades is {0}", total );
      Console.WriteLine( "Class average is {0}", average );
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
