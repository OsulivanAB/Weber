// Fig. 10.6: Time2Test.cs
// Overloaded constructors used to initialize Time2 objects.
using System;

public class Time2Test
{
   public static void Main( string[] args )
   {
      Time2 t1 = new Time2(); // 00:00:00
      Time2 t2 = new Time2( 2 ); // 02:00:00
      Time2 t3 = new Time2( 21, 34 ); // 21:34:00
      Time2 t4 = new Time2( 12, 25, 42 ); // 12:25:42
      Time2 t5 = new Time2( t4 ); // 12:25:42
      Time2 t6; // initialized later in the program

      Console.WriteLine( "Constructed with:\n" );
      Console.WriteLine( "t1: all arguments defaulted" );
      Console.WriteLine( "   {0}", t1.ToUniversalString() ); // 00:00:00
      Console.WriteLine( "   {0}\n", t1.ToString() ); // 12:00:00 AM

      Console.WriteLine(
         "t2: hour specified; minute and second defaulted" );
      Console.WriteLine( "   {0}", t2.ToUniversalString() ); // 02:00:00
      Console.WriteLine( "   {0}\n", t2.ToString() ); // 2:00:00 AM

      Console.WriteLine(
         "t3: hour and minute specified; second defaulted" );
      Console.WriteLine( "   {0}", t3.ToUniversalString() ); // 21:34:00
      Console.WriteLine( "   {0}\n", t3.ToString() ); // 9:34:00 PM

      Console.WriteLine( "t4: hour, minute and second specified" );
      Console.WriteLine( "   {0}", t4.ToUniversalString() ); // 12:25:42
      Console.WriteLine( "   {0}\n", t4.ToString() ); // 12:25:42 PM

      Console.WriteLine( "t5: Time2 object t4 specified" );
      Console.WriteLine( "   {0}", t5.ToUniversalString() ); // 12:25:42
      Console.WriteLine( "   {0}", t5.ToString() ); // 12:25:42 PM

      // attempt to initialize t6 with invalid values
      try 
      {
         t6 = new Time2( 27, 74, 99 ); // invalid values
      } // end try
      catch ( ArgumentOutOfRangeException ex )
      {
         Console.WriteLine( "\nException while initializing t6:" );
         Console.WriteLine( ex.Message );
      } // end catch
   } // end Main
} // end class Time2Test


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
