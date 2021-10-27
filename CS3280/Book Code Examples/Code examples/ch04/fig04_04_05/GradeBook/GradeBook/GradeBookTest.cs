// Fig. 4.5: GradeBookTest.cs
// Create a GradeBook object and pass a string to 
// its DisplayMessage method.
using System;

public class GradeBookTest
{
   // Main method begins program execution
   public static void Main( string[] args )
   {
      // create a GradeBook object and assign it to myGradeBook
      GradeBook myGradeBook = new GradeBook();

      // prompt for and input course name
      Console.WriteLine( "Please enter the course name:" );
      string nameOfCourse = Console.ReadLine(); // read a line of text
      Console.WriteLine(); // output a blank line

      // call myGradeBook's DisplayMessage method 
      // and pass nameOfCourse as an argument
      myGradeBook.DisplayMessage( nameOfCourse );
   } // end Main
} // end class GradeBookTest


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
