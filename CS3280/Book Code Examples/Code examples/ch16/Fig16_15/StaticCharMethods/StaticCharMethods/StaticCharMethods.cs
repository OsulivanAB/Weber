// Fig. 16.15: StaticCharMethods.cs
// Demonstrates static character testing and case conversion methods 
// from Char struct
using System;

class StaticCharMethods
{
   static void Main( string[] args )
   {
      Console.Write( "Enter a character: " );
      char character = Convert.ToChar( Console.ReadLine() );

      Console.WriteLine( "is digit: {0}", Char.IsDigit( character ) );
      Console.WriteLine( "is letter: {0}", Char.IsLetter( character )  );
      Console.WriteLine( "is letter or digit: {0}", 
         Char.IsLetterOrDigit( character ) );
      Console.WriteLine( "is lower case: {0}", 
         Char.IsLower( character ) );
      Console.WriteLine( "is upper case: {0}",
         Char.IsUpper( character ) );
      Console.WriteLine( "to upper case: {0}",
         Char.ToUpper( character ) );
      Console.WriteLine( "to lower case: {0}",
         Char.ToLower( character ) );
      Console.WriteLine( "is punctuation: {0}",
         Char.IsPunctuation( character ) );
      Console.WriteLine( "is symbol: {0}", Char.IsSymbol( character ) );
   } // end Main
} // end class StaticCharMethods

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