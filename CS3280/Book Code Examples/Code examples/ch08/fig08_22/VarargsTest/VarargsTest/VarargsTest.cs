// Fig. 8.22: VarargsTest.cs
// Using variable-length argument lists.
using System;

public class VarargsTest
{
   // calculate average
   public static double Average( params double[] numbers )
   {
      double total = 0.0; // initialize total

      // calculate total using the foreach statement
      foreach ( double d in numbers )
         total += d;

      return total / numbers.Length;
   } // end method Average

   public static void Main( string[] args )
   {
      double d1 = 10.0;
      double d2 = 20.0;
      double d3 = 30.0;
      double d4 = 40.0;

      Console.WriteLine(
         "d1 = {0:F1}\nd2 = {1:F1}\nd3 = {2:F1}\nd4 = {3:F1}\n",
         d1, d2, d3, d4 );

      Console.WriteLine( "Average of d1 and d2 is {0:F1}",
         Average( d1, d2 ) );
      Console.WriteLine( "Average of d1, d2 and d3 is {0:F1}",
         Average( d1, d2, d3 ) );
      Console.WriteLine( "Average of d1, d2, d3 and d4 is {0:F1}",
         Average( d1, d2, d3, d4 ) );
   } // end Main
} // end class VarargsTest


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
