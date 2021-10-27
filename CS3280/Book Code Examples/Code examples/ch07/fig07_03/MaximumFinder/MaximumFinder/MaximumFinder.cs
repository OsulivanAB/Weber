// Fig. 7.3: MaximumFinder.cs
// User-defined method Maximum.
using System;

public class MaximumFinder
{
   // obtain three floating-point values and determine maximum value
   public static void Main( string[] args )
   {
      // prompt for and input three floating-point values
      Console.WriteLine( "Enter three floating-point values,\n"
         + "  pressing 'Enter' after each one: " );
      double number1 = Convert.ToDouble( Console.ReadLine() );
      double number2 = Convert.ToDouble( Console.ReadLine() );
      double number3 = Convert.ToDouble( Console.ReadLine() );

      // determine the maximum value
      double result = Maximum( number1, number2, number3 );

      // display maximum value 
      Console.WriteLine( "Maximum is: " + result );
   } // end Main

   // returns the maximum of its three double parameters
   public static double Maximum( double x, double y, double z )
   {
      double maximumValue = x; // assume x is the largest to start

      // determine whether y is greater than maximumValue
      if ( y > maximumValue )
         maximumValue = y;

      // determine whether z is greater than maximumValue
      if ( z > maximumValue )
         maximumValue = z;

      return maximumValue;
   } // end method Maximum
} // end class MaximumFinder


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
