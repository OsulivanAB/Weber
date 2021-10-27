// Fig. 13.7: SquareRootTest.cs
// Demonstrating a user-defined exception class.
using System;

class SquareRootTest
{
   static void Main( string[] args )
   {
      bool continueLoop = true;

      do
      {
         // catch any NegativeNumberException thrown
         try
         {
            Console.Write( 
               "Enter a value to calculate the square root of: " );
            double inputValue = Convert.ToDouble( Console.ReadLine() );
            double result = SquareRoot( inputValue );

            Console.WriteLine( "The square root of {0} is {1:F6}\n", 
               inputValue, result );
            continueLoop = false; 
         } // end try
         catch ( FormatException formatException )
         {
            Console.WriteLine( "\n" + formatException.Message );
            Console.WriteLine( "Please enter a double value.\n" );
         } // end catch
         catch ( NegativeNumberException negativeNumberException )                        
         {                                                            
            Console.WriteLine( "\n" + negativeNumberException.Message );
            Console.WriteLine( "Please enter a non-negative value.\n" );
         } // end catch          
      } while ( continueLoop );
   } // end Main

   // computes square root of parameter; throws 
   // NegativeNumberException if parameter is negative
   public static double SquareRoot( double value )
   {
      // if negative operand, throw NegativeNumberException
      if ( value < 0 )
         throw new NegativeNumberException(                  
            "Square root of negative number not permitted" );
      else
         return Math.Sqrt( value ); // compute square root
   } // end method SquareRoot
} // end class SquareRootTest



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