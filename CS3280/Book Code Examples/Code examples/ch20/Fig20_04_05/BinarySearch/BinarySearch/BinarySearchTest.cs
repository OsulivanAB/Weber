// Fig. 20.5: BinarySearchTest.cs
// Using binary search to locate an item in an array.
using System;

public class BinarySearchTest
{
   public static void Main( string[] args )
   {
      int searchInt; // search key
      int position; // location of search key in array
   
      // create array and output it
      BinaryArray searchArray = new BinaryArray( 15 );
      Console.WriteLine( searchArray );

      // prompt and input first int from user
      Console.Write( "Please enter an integer value (-1 to quit): " );
      searchInt = Convert.ToInt32( Console.ReadLine() );
      Console.WriteLine();

      // repeatedly input an integer; -1 terminates the application
      while ( searchInt != -1 )
      {
         // use binary search to try to find integer
         position = searchArray.BinarySearch( searchInt );

         // return value of -1 indicates integer was not found
         if ( position == -1 )
            Console.WriteLine( "The integer {0} was not found.\n",
               searchInt );
         else
            Console.WriteLine( 
               "The integer {0} was found in position {1}.\n",
               searchInt, position);

         // prompt and input next int from user
         Console.Write( "Please enter an integer value (-1 to quit): " );
         searchInt = Convert.ToInt32( Console.ReadLine() );
         Console.WriteLine();
      } // end while
   } // end Main
} // end class BinarySearchTest

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