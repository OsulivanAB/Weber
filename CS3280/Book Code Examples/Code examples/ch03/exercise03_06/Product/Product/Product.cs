// Exercise 3.6: Product.cs
// Calculating the product of three integers.
using System;

public class Product
{
   public static void Main(string[] args)
   {
      int x; // stores first number to be entered by user
      int y; // stores second number to be entered by user
      int z; // stores third number to be entered by user
      int result; // product of numbers

      Console.Write("Enter first integer: "); // prompt for input
      x = Convert.ToInt32(Console.ReadLine()); // read first integer

      Console.Write("Enter second integer: "); // prompt for input
      y = Convert.ToInt32(Console.ReadLine()); // read second integer

      Console.Write("Enter third integer: "); // prompt for input
      z = Convert.ToInt32(Console.ReadLine()); // read third integer

      result = x * y * z; // calculate the product of the numbers

      Console.WriteLine("Product is {0}", result);
   } // end Main
} // end class Product


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