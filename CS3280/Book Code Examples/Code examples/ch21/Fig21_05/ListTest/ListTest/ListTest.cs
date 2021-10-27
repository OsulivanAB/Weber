// Fig. 21.5: ListTest.cs 
// Testing class List.
using System;
using LinkedListLibrary;

// class to test List class functionality
class ListTest
{
   public static void Main( string[] args )
   {
      List list = new List(); // create List container

      // create data to store in List
      bool aBoolean = true;
      char aCharacter = '$';
      int anInteger = 34567;
      string aString = "hello";

      // use List insert methods
      list.InsertAtFront( aBoolean );
      list.Display();
      list.InsertAtFront( aCharacter );
      list.Display();
      list.InsertAtBack( anInteger );
      list.Display();
      list.InsertAtBack( aString );
      list.Display();

      // use List remove methods
      object removedObject;

      // remove data from list and display after each removal
      try
      {
         removedObject = list.RemoveFromFront();
         Console.WriteLine( removedObject + " removed" );
         list.Display();

         removedObject = list.RemoveFromFront();
         Console.WriteLine( removedObject + " removed" );
         list.Display();

         removedObject = list.RemoveFromBack();
         Console.WriteLine( removedObject + " removed" );
         list.Display();

         removedObject = list.RemoveFromBack();
         Console.WriteLine( removedObject + " removed" );
         list.Display();
      } // end try
      catch ( EmptyListException emptyListException )
      {
         Console.Error.WriteLine( "\n" + emptyListException );
      } // end catch
   } // end Main
} // end class ListTest

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