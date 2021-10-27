// Fig. 15.8: UnsynchronizedBufferTest.cs
// Showing multiple threads modifying a shared object without
// synchronization.
using System;
using System.Threading;

// this class creates producer and consumer threads
class UnsynchronizedBufferTest
{
   // create producer and consumer threads and start them
   static void Main( string[] args )
   {
      // create shared object used by threads
      UnsynchronizedBuffer shared = new UnsynchronizedBuffer();

      // Random object used by each thread
      Random random = new Random();

      // create Producer and Consumer objects
      Producer producer = new Producer( shared, random );
      Consumer consumer = new Consumer( shared, random );

      // create threads for producer and consumer and set 
      // delegates for each thread
      Thread producerThread = 
         new Thread( new ThreadStart( producer.Produce ) );
      producerThread.Name = "Producer";

      Thread consumerThread = 
         new Thread( new ThreadStart( consumer.Consume ) );
      consumerThread.Name = "Consumer";

      // start each thread
      producerThread.Start();
      consumerThread.Start();

      Console.Read();
   } // end Main
} // end class UnsynchronizedBufferTest

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