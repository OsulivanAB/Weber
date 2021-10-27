// Fig. 8.8: StudentPoll.cs
// Poll analysis application.
using System;

public class StudentPoll
{
   public static void Main( string[] args )
   {
      // student response array (more typically, input at run time)
      int[] responses = { 1, 2, 5, 4, 3, 5, 2, 1, 3, 3, 1, 4, 3, 3, 3, 
         2, 3, 3, 2, 14 };
      int[] frequency = new int[ 6 ]; // array of frequency counters

      // for each answer, select responses element and use that value 
      // as frequency index to determine element to increment
      for ( int answer = 0; answer < responses.Length; answer++ )
      {
         try
         {
            ++frequency[ responses[ answer ] ];
         } // end try
         catch ( IndexOutOfRangeException ex )
         {
            Console.WriteLine( ex.Message );
            Console.WriteLine("   responses({0}) = {1}\n",
               answer, responses[ answer ] );
         } // end catch
      } // end for

      Console.WriteLine( "{0}{1,10}", "Rating", "Frequency" );

      // output each array element's value
      for ( int rating = 1; rating < frequency.Length; rating++ )
         Console.WriteLine( "{0,6}{1,10}", rating, frequency[ rating ] );
   } // end Main
} // end class StudentPoll


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
