// Fig. 6.2: ForCounter.cs
// Counter-controlled repetition with the for repetition statement.
using System;

public class ForCounter
{
   public static void Main( string[] args )
   {
      // for statement header includes initialization,  
      // loop-continuation condition and increment
      for ( int counter = 1; counter <= 10; counter++ )
         Console.Write( "{0}  ", counter );

      Console.WriteLine(); // output a newline
   } // end Main
} // end class ForCounter


/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
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
