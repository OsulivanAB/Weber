// Ex. 5.25: Mystery2.cs
using System;

public class Mystery2
{
   public static void Main( string[] args )
   {
      int count = 1;

      while ( count <= 10 )
      {
         Console.WriteLine( count % 2 == 1 ? "****" : "++++++++" );
         ++count;
      } // end while
   } // end Main
} // end class Mystery2

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
