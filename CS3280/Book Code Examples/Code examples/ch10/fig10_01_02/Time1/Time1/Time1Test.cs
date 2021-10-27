// Fig. 10.2: Time1Test.cs
// Time1 object used in an application.
using System;

public class Time1Test
{
   public static void Main( string[] args )
   {
      // create and initialize a Time1 object
      Time1 time = new Time1(); // invokes Time1 constructor

      // output string representations of the time
      Console.Write( "The initial universal time is: " );
      Console.WriteLine( time.ToUniversalString() );
      Console.Write( "The initial standard time is: " );
      Console.WriteLine( time.ToString() );
      Console.WriteLine(); // output a blank line

      // change time and output updated time 
      time.SetTime( 13, 27, 6 );
      Console.Write( "Universal time after SetTime is: " );
      Console.WriteLine( time.ToUniversalString() );
      Console.Write( "Standard time after SetTime is: " );
      Console.WriteLine( time.ToString() );
      Console.WriteLine(); // output a blank line

      // attempt to set time with invalid values
      try
      {
         time.SetTime( 99, 99, 99 );
      } // end try
      catch ( ArgumentOutOfRangeException ex )
      {
         Console.WriteLine( ex.Message + "\n" );
      } // end catch

      // display time after attempt to set invalid values
      Console.WriteLine( "After attempting invalid settings:" );
      Console.Write( "Universal time: " );
      Console.WriteLine( time.ToUniversalString() );
      Console.Write( "Standard time: " );
      Console.WriteLine( time.ToString() );
   } // end Main
} // end class Time1Test


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
