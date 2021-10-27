// Fig. 8.6: BarChart.cs
// Bar chart displaying application.
using System;

public class BarChart
{
   public static void Main( string[] args )
   {
      int[] array = { 0, 0, 0, 0, 0, 0, 1, 2, 4, 2, 1 }; // distribution

      Console.WriteLine( "Grade distribution:" );

      // for each array element, output a bar of the chart
      for ( int counter = 0; counter < array.Length; counter++ )
      {
         // output bar labels ( "00-09: ", ..., "90-99: ", "100: " )
         if ( counter == 10 )
            Console.Write( "  100: " );
         else
            Console.Write( "{0:D2}-{1:D2}: ",
               counter * 10, counter * 10 + 9 );

         // display bar of asterisks
         for ( int stars = 0; stars < array[ counter ]; stars++ )
            Console.Write( "*" );

         Console.WriteLine(); // start a new line of output
      } // end outer for
   } // end Main
} // end class BarChart


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
