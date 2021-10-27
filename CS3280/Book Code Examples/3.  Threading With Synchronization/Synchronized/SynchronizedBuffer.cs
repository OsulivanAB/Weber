// Fig. 15.9: SynchronizedBuffer.cs
// A synchronized shared buffer implementation.
using System;
using System.Threading;

// this class represents a single shared int
public class SynchronizedBuffer : Buffer
{
   // buffer shared by producer and consumer threads
   private int buffer = -1; 

   // occupiedBufferCount maintains count of occupied buffers
   private int occupiedBufferCount = 0;  

   // property Buffer
   public int Buffer
   {      
      get
      { 
         // obtain lock on this object
         Monitor.Enter( this );

         // if there is no data to read, place invoking 
         // thread in WaitSleepJoin state
         if ( occupiedBufferCount == 0 )
         {
            Console.WriteLine( 
               Thread.CurrentThread.Name + " tries to read." );
            DisplayState( "Buffer empty. " + 
               Thread.CurrentThread.Name + " waits." );
            Monitor.Wait( this ); // enter WaitSleepJoin state
         } // end if

         // indicate that producer can store another value 
         // because consumer is about to retrieve a buffer value
         --occupiedBufferCount;    
                              
         DisplayState( Thread.CurrentThread.Name + " reads " + buffer );

         // tell waiting thread (if there is one) to 
         // become ready to execute (Running state)
         Monitor.Pulse( this );

         // Get copy of buffer before releasing lock. 
         // It is possible that the producer could be
         // assigned the processor immediately after the
         // monitor is released and before the return 
         // statement executes. In this case, the producer 
         // would assign a new value to buffer before the 
         // return statement returns the value to the 
         // consumer. Thus, the consumer would receive the 
         // new value. Making a copy of buffer and 
         // returning the copy ensures that the
         // consumer receives the proper value.
         int bufferCopy = buffer;

         // release lock on this object
         Monitor.Exit( this );

         return bufferCopy;
      } // end get
      set
      {
         // acquire lock for this object
         Monitor.Enter( this );

         // if there are no empty locations, place invoking
         // thread in WaitSleepJoin state
         if ( occupiedBufferCount == 1 )
         {
            Console.WriteLine( 
               Thread.CurrentThread.Name + " tries to write." );
            DisplayState( "Buffer full. " + 
               Thread.CurrentThread.Name + " waits." );
            Monitor.Wait( this );// enter WaitSleepJoin state
         } // end if

         // set new buffer value
         buffer = value;

         // indicate consumer can retrieve another value 
         // because producer has just stored a buffer value
         ++occupiedBufferCount;

         DisplayState( Thread.CurrentThread.Name + " writes " + buffer );

         // tell waiting thread (if there is one) to 
         // become ready to execute (Running state)
         Monitor.Pulse( this );

         // release lock on this object
         Monitor.Exit( this );
      } // end set
   } // end property Buffer

   // display current operation and buffer state
   public void DisplayState( string operation )
   {
      Console.WriteLine( "{0,-35}{1,-9}{2}\n", 
         operation, buffer, occupiedBufferCount );
   } // end method DisplayState
} // end class SynchronizedBuffer

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