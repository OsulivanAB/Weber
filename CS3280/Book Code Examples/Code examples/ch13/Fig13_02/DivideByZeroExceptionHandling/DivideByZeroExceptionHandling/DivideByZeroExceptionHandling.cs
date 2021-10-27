// Fig. 13.2: DivideByZeroExceptionHandling.cs
// FormatException and DivideByZeroException handlers.
using System;

class DivideByZeroExceptionHandling
{
   static void Main( string[] args )
   {
      bool continueLoop = true; // determines whether to keep looping

      do
      {
         // retrieve user input and calculate quotient                   
         try
         { 
            // Convert.ToInt32 generates FormatException                 
            // if argument cannot be converted to an integer
            Console.Write( "Enter an integer numerator: " );
            int numerator = Convert.ToInt32( Console.ReadLine() );
            Console.Write( "Enter an integer denominator: " );
            int denominator = Convert.ToInt32( Console.ReadLine() );

            // division generates DivideByZeroException                  
            // if denominator is 0                                       
            int result = numerator / denominator;

            // display result 
            Console.WriteLine( "\nResult: {0} / {1} = {2}", 
               numerator, denominator, result );
            continueLoop = false;
         } // end try  
         catch ( FormatException formatException )
         {
            Console.WriteLine( "\n" + formatException.Message );
            Console.WriteLine( 
               "You must enter two integers. Please try again.\n" );
         } // end catch                                                  
         catch ( DivideByZeroException divideByZeroException )
         {
            Console.WriteLine( "\n" + divideByZeroException.Message );
            Console.WriteLine( 
               "Zero is an invalid denominator. Please try again.\n" );
         } // end catch
      } while ( continueLoop ); // end do...while
   } // end Main
} // end class DivideByZeroExceptionHandling


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

