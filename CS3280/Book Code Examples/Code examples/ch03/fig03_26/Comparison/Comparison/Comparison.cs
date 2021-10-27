// Fig. 3.26: Comparison.cs
// Comparing integers using if statements, equality operators,
// and relational operators.
using System;

public class Comparison
{
   // Main method begins execution of C# application
   public static void Main(string[] args)
   {
      int number1; // declare first number to compare
      int number2; // declare second number to compare

      // prompt user and read first number
      Console.Write("Enter first integer: ");
      number1 = Convert.ToInt32(Console.ReadLine());

      // prompt user and read second number 
      Console.Write("Enter second integer: ");
      number2 = Convert.ToInt32(Console.ReadLine());

      if (number1 = number2)
         Console.WriteLine("{0} == {1}", number1, number2);

      if (number1 != number2)
         Console.WriteLine("{0} != {1}", number1, number2);

      if (number1 < number2)
         Console.WriteLine("{0} < {1}", number1, number2);

      if (number1 > number2)
         Console.WriteLine("{0} > {1}", number1, number2);

      if (number1 <= number2)
         Console.WriteLine("{0} <= {1}", number1, number2);

      if (number1 >= number2)
         Console.WriteLine("{0} >= {1}", number1, number2);
   } // end Main
} // end class Comparison

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
