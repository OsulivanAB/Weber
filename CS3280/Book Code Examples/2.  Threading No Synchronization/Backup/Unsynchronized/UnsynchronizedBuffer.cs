// Fig. 15.7: UnsynchronizedBuffer.cs
// An unsynchronized shared buffer implementation.
using System;
using System.Threading;

// this class represents a single shared int
public class UnsynchronizedBuffer : Buffer
{
   // buffer shared by producer and consumer threads
   private int buffer = -1; 

   // property Buffer
   public int Buffer
   {      
      get
      {
         Console.WriteLine( "{0} reads {1}",  
            Thread.CurrentThread.Name, buffer );
         return buffer;
      } // end get
      set
      {
         Console.WriteLine( "{0} writes {1}", 
            Thread.CurrentThread.Name, value );
         buffer = value;
      } // end set
   } // end property Buffer
} // end class UnsynchronizedBuffer

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