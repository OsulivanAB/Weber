// Fig. 16.12: StringBuilderAppendFormat.cs
// Demonstrating method AppendFormat.
using System;
using System.Text;

class StringBuilderAppendFormat
{
   public static void Main( string[] args )
   {
      StringBuilder buffer = new StringBuilder();

      // formatted string
      string string1 = "This {0} costs: {1:C}.\n";

      // string1 argument array
      object[] objectArray = new object[2];

      objectArray[0] = "car";
      objectArray[1] = 1234.56;

      // append to buffer formatted string with argument
      buffer.AppendFormat(string1, objectArray);

      // formatted string
      string string2 = "Number:{0:d3}.\n" +
         "Number right aligned with spaces:{0, 4}.\n" +
         "Number left aligned with spaces:{0, -4}.";

      // append to buffer formatted string with argument
      buffer.AppendFormat(string2, 5);

      // display formatted strings
      Console.WriteLine(buffer.ToString());
   } // end Main
} // end class StringBuilderAppendFormat

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