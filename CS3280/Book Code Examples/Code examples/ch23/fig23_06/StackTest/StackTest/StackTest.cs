// Fig. 23.6: StackTest.cs
// Demonstrating class Stack.
using System;
using System.Collections;

public class StackTest
{
   public static void Main( string[] args )
   {
      Stack stack = new Stack(); // create an empty Stack

      // create objects to store in the stack
      bool aBoolean = true;
      char aCharacter = '$';
      int anInteger = 34567;
      string aString = "hello";

      // use method Push to add items to (the top of) the stack
      stack.Push( aBoolean );
      PrintStack( stack );
      stack.Push( aCharacter );
      PrintStack( stack );
      stack.Push( anInteger );
      PrintStack( stack );
      stack.Push( aString );
      PrintStack( stack );

      // check the top element of the stack
      Console.WriteLine( "The top element of the stack is {0}\n",
         stack.Peek() );

      // remove items from stack
      try
      {
         while ( true )
         {
            object removedObject = stack.Pop();
            Console.WriteLine( removedObject + " popped" );
            PrintStack( stack );
         } // end while
      } // end try
      catch ( InvalidOperationException exception )
      {
         // if exception occurs, output stack trace
         Console.Error.WriteLine( exception );
      } // end catch
   } // end Main

   // display the contents of a stack
   private static void PrintStack( Stack stack )
   {
      if ( stack.Count == 0 )
         Console.WriteLine( "stack is empty\n" ); // the stack is empty
      else
      {
         Console.Write( "The stack is: " );

         // iterate through the stack with a foreach statement
         foreach ( var element in stack )
            Console.Write( "{0} ", element ); // invokes ToString

         Console.WriteLine( "\n" );
      } // end else
   } // end method PrintStack
} // end class StackTest


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
