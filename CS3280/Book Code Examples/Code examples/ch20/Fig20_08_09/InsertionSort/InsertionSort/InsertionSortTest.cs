// Fig. 20.9: InsertionSortTest.cs
// Testing the insertion sort class.
using System;

public class InsertionSortTest
{
   public static void Main( string[] args )
   {
      // create object to perform insertion sort
      InsertionSort sortArray = new InsertionSort( 10 );
      
      Console.WriteLine( "Unsorted array:" );
      Console.WriteLine( sortArray ); // print unsorted array

      sortArray.Sort(); // sort array

      Console.WriteLine( "Sorted array:" );
      Console.WriteLine( sortArray ); // print sorted array
   } // end Main
} // end class InsertionSortTest