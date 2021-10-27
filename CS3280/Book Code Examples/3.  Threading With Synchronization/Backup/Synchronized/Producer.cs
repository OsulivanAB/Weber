// Fig. 15.5: Producer.cs
// Producer produces ten integer values in the shared buffer.
using System;
using System.Threading;

// class Producer's Produce method controls a thread that
// stores values from 1 to 10 in sharedLocation
public class Producer 
{
   private Buffer sharedLocation;
   private Random randomSleepTime;

   // constructor
   public Producer( Buffer shared, Random random )
   {
      sharedLocation = shared;
      randomSleepTime = random;
   } // end constructor

   // store values 1-10 in object sharedLocation
   public void Produce()
   {
      // sleep for random interval up to 3000 milliseconds
      // then set sharedLocation's Buffer property
      for ( int count = 1; count <= 10; count++ ) 
      {
         Thread.Sleep( randomSleepTime.Next( 1, 3001 ) );
         sharedLocation.Buffer = count; 
      } // end for

      Console.WriteLine( "{0} done producing.\nTerminating {0}.",
         Thread.CurrentThread.Name );
   } // end method Produce
} // end class Producer

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