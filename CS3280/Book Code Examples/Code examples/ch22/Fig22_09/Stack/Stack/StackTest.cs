// Fig. 22.9: StackTest.cs
// Testing generic class Stack.
using System;
using System.Collections.Generic;

class StackTest
{
   // create arrays of doubles and ints
   private static double[] doubleElements =
      new double[] { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
   private static int[] intElements =
      new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

   private static Stack< double > doubleStack; // stack stores doubles
   private static Stack< int > intStack; // stack stores int objects

   public static void Main( string[] args )
   {
      doubleStack = new Stack< double >( 5 ); // stack of doubles
      intStack = new Stack< int >( 10 ); // stack of ints

      // push doubles onto doubleStack
      TestPush( "doubleStack", doubleStack, doubleElements );
      // pop doubles from doubleStack
      TestPop( "doubleStack", doubleStack );
      // push ints onto intStack
      TestPush( "intStack", intStack, intElements );
      // pop ints from intStack
      TestPop( "intStack", intStack );
   } // end Main

   // test Push method
   private static void TestPush< T >( string name, Stack< T > stack,
      IEnumerable< T > elements )
   {
      // push elements onto stack
      try
      {
         Console.WriteLine( "\nPushing elements onto " + name );

         // push elements onto stack
         foreach ( var element in elements )
         {
            Console.Write( "{0} ", element );
            stack.Push( element ); // push onto stack
         } // end foreach
      } // end try
      catch ( FullStackException exception )
      {
         Console.Error.WriteLine();
         Console.Error.WriteLine( "Message: " + exception.Message );
         Console.Error.WriteLine( exception.StackTrace );
      } // end catch
   } // end method TestPush

   // test Pop method
   private static void TestPop< T >( string name, Stack< T > stack )
   {
      // push elements onto stack
      try
      {
         Console.WriteLine( "\nPopping elements from " + name );

         T popValue; // store element removed from stack

         // remove all elements from stack
         while ( true )
         {
            popValue = stack.Pop(); // pop from stack
            Console.Write( "{0} ", popValue );
         } // end while
      } // end try
      catch ( EmptyStackException exception )
      {
         Console.Error.WriteLine();
         Console.Error.WriteLine( "Message: " + exception.Message );
         Console.Error.WriteLine( exception.StackTrace );
      } // end catch
   } // end TestPop
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
