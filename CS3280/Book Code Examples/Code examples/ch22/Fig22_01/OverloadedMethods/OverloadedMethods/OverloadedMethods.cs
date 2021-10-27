// Fig. 22.1: OverloadedMethods.cs
// Using overloaded methods to display arrays of different types.
using System;

class OverloadedMethods
{
   public static void Main( string[] args )
   {
      // create arrays of int, double and char
      int[] intArray = { 1, 2, 3, 4, 5, 6 };
      double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7 };
      char[] charArray = { 'H', 'E', 'L', 'L', 'O' };

      Console.WriteLine( "Array intArray contains:" );
      DisplayArray( intArray ); // pass an int array argument
      Console.WriteLine( "Array doubleArray contains:" );
      DisplayArray( doubleArray ); // pass a double array argument
      Console.WriteLine( "Array charArray contains:" );
      DisplayArray( charArray ); // pass a char array argument
   } // end Main

   // output int array
   private static void DisplayArray( int[] inputArray )
   {
      foreach ( int element in inputArray )
         Console.Write( element + " " );

      Console.WriteLine( "\n" );
   } // end method DisplayArray

   // output double array
   private static void DisplayArray( double[] inputArray )
   {
      foreach ( double element in inputArray )
         Console.Write( element + " " );

      Console.WriteLine( "\n" );
   } // end method DisplayArray

   // output char array
   private static void DisplayArray( char[] inputArray )
   {
      foreach ( char element in inputArray )
         Console.Write( element + " " );

      Console.WriteLine( "\n" );
   } // end method DisplayArray
} // end class OverloadedMethods

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
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
