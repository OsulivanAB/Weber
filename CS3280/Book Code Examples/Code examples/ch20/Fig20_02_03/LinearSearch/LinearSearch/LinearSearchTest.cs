// Fig. 20.3: LinearSearchTest.cs
// Sequentially search an array for an item.
using System;

public class LinearSearchTest
{
   public static void Main( string[] args )
   {
      int searchInt; // search key
      int position; // location of search key in array

      // create array and output it
      LinearArray searchArray = new LinearArray( 10 );
      Console.WriteLine( searchArray ); // print array

      // input first int from user
      Console.Write( "Please enter an integer value (-1 to quit): " );
      searchInt = Convert.ToInt32( Console.ReadLine() );

      // repeatedly input an integer; -1 terminates the application
      while ( searchInt != -1 )
      {
         // perform linear search
         position = searchArray.LinearSearch( searchInt );

         if ( position != -1 ) // integer was not found
            Console.WriteLine(
               "The integer {0} was found in position {1}.\n",
               searchInt, position );
         else // integer was found
            Console.WriteLine( "The integer {0} was not found.\n",
               searchInt );

         // input next int from user
         Console.Write( "Please enter an integer value (-1 to quit): " );
         searchInt = Convert.ToInt32( Console.ReadLine() );
      } // end while
   } // end Main
} // end class LinearSearchTest

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
 **************************************************************************/