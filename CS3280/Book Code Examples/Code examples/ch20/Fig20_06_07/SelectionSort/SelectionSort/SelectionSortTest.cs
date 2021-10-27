// Fig. 20.7: SelectionSortTest.cs
// Testing the selection sort class.
using System;

public class SelectionSortTest
{
   public static void Main( string[] args )
   {
      // create object to perform selection sort
      SelectionSort sortArray = new SelectionSort( 10 );

      Console.WriteLine( "Unsorted array:" );
      Console.WriteLine( sortArray ); // print unsorted array

      sortArray.Sort(); // sort array

      Console.WriteLine( "Sorted array:" );
      Console.WriteLine( sortArray ); // print sorted array
   } // end Main
} // end class SelectionSortTest

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