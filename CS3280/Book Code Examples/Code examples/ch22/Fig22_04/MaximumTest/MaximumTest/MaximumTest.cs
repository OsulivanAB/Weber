// Fig. 22.4: MaximumTest.cs
// Generic method Maximum returns the largest of three objects.
using System;

class MaximumTest
{
   public static void Main( string[] args )
   {
      Console.WriteLine( "Maximum of {0}, {1} and {2} is {3}\n",
         3, 4, 5, Maximum( 3, 4, 5 ) );
      Console.WriteLine( "Maximum of {0}, {1} and {2} is {3}\n",
         6.6, 8.8, 7.7, Maximum( 6.6, 8.8, 7.7 ) );
      Console.WriteLine( "Maximum of {0}, {1} and {2} is {3}\n",
         "pear", "apple", "orange",
         Maximum( "pear", "apple", "orange" ) );
   } // end Main

   // generic function determines the
   // largest of the IComparable objects
   private static T Maximum< T >( T x, T y, T z ) 
      where T : IComparable< T >
   {
      T max = x; // assume x is initially the largest

      // compare y with max
      if ( y.CompareTo( max ) > 0 )
         max = y; // y is the largest so far

      // compare z with max
      if ( z.CompareTo( max ) > 0 )
         max = z; // z is the largest

      return max; // return largest object
   } // end method Maximum
} // end class MaximumTest

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
