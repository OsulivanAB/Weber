// Ex. 5.6: Calculate.cs
// Calculate the sum of the integers from 1 to 10 
using System;

public class Calculate
{
   public static void Main( string[] args )
   {
      int sum;
      int x;

      x = 1; // initialize x to 1 for counting
      sum = 0; // initialize sum to 0 for totaling

      while ( x <= 10 ) // while x is less than or equal to 10      
      {
         sum += x; // add x to sum
         ++x; // increment x
      } // end while

      Console.WriteLine( "The sum is: {0}", sum );
   } // end Main
} // end class Calculate


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
