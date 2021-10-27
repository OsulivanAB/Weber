// Fig. 16.13: StringBuilderInsertRemove.cs
// Demonstrating methods Insert and Remove of the 
// StringBuilder class.
using System;
using System.Text;

class StringBuilderInsertRemove
{
   public static void Main( string[] args )
   {
      object objectValue = "hello";
      string stringValue = "good bye";
      char[] characterArray = { 'a', 'b', 'c', 'd', 'e', 'f' };
      bool booleanValue = true;
      char characterValue = 'K';
      int integerValue = 7;
      long longValue = 10000000;
      float floatValue = 2.5F; // F suffix indicates that 2.5 is a float
      double doubleValue = 33.333;
      StringBuilder buffer = new StringBuilder();

      // insert values into buffer
      buffer.Insert(0, objectValue);
      buffer.Insert(0, "  ");
      buffer.Insert(0, stringValue);
      buffer.Insert(0, "  ");
      buffer.Insert(0, characterArray);
      buffer.Insert(0, "  ");
      buffer.Insert(0, booleanValue);
      buffer.Insert(0, "  ");
      buffer.Insert(0, characterValue);
      buffer.Insert(0, "  ");
      buffer.Insert(0, integerValue);
      buffer.Insert(0, "  ");
      buffer.Insert(0, longValue);
      buffer.Insert(0, "  ");
      buffer.Insert(0, floatValue);
      buffer.Insert(0, "  ");
      buffer.Insert(0, doubleValue);
      buffer.Insert(0, "  ");

      Console.WriteLine("buffer after Inserts: \n" + buffer + "\n");

      buffer.Remove(10, 1); // delete 2 in 2.5
      buffer.Remove(4, 4);  // delete .333 in 33.333

      Console.WriteLine("buffer after Removes:\n" + buffer);
   } // end Main
} // end class StringBuilderInsertRemove

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
