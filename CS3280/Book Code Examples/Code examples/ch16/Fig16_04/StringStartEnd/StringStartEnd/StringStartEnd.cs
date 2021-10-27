// Fig. 16.4: StringStartEnd.cs
// Demonstrating StartsWith and EndsWith methods.
using System;

class StringStartEnd
{
   public static void Main( string[] args )
   {
      string[] strings = { "started", "starting", "ended", "ending" };

      // test every string to see if it starts with "st"
      for ( int i = 0; i < strings.Length; i++ )
         if ( strings[i].StartsWith( "st" ) )
            Console.WriteLine( "\"" + strings[ i ] + "\"" +
               " starts with \"st\"" );

      Console.WriteLine();

      // test every string to see if it ends with "ed"
      for ( int i = 0; i < strings.Length; i++ )
         if ( strings[i].EndsWith( "ed" ) )
            Console.WriteLine( "\"" + strings[ i ] + "\"" +
               " ends with \"ed\"" );

      Console.WriteLine();
   } // end Main
} // end class StringStartEnd

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