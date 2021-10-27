// Fig. 15.6: Consumer.cs
// Consumer consumes ten integer values from the shared buffer.
using System;
using System.Threading;

// class Consumer's Consume method controls a thread that
// loops ten times and reads a value from sharedLocation
public class Consumer
{
   private Buffer sharedLocation;
   private Random randomSleepTime;

   // constructor
   public Consumer( Buffer shared, Random random )
   {
      sharedLocation = shared;
      randomSleepTime = random;
   } // end constructor

   // read sharedLocation's value ten times
   public void Consume()
   {
      int sum = 0;

      // sleep for random interval up to 3000 milliseconds then
      // add sharedLocation's Buffer property value to sum
      for ( int count = 1; count <= 10; count++ )
      {
         Thread.Sleep( randomSleepTime.Next( 1, 3001 ) );
         sum += sharedLocation.Buffer;
      } // end for

      Console.WriteLine(
         "{0} read values totaling: {1}.\nTerminating {0}.",
         Thread.CurrentThread.Name, sum );
   } // end method Consume
} // end class Consumer

/**************************************************************************
 * (C) Copyright 1992-2006 by Deitel & Associates, Inc. and               *
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