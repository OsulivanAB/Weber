// Fig. 23.5: ArrayListTest.cs
// Using class ArrayList.
using System;
using System.Collections;

public class ArrayListTest
{
   private static readonly string[] colors = 
      { "MAGENTA", "RED", "WHITE", "BLUE", "CYAN" };
   private static readonly string[] removeColors = 
      { "RED", "WHITE", "BLUE" };

   // create ArrayList, add colors to it and manipulate it
   public static void Main( string[] args )
   {
      ArrayList list = new ArrayList( 1 ); // initial capacity of 1  

      // add the elements of the colors array to the ArrayList list
      foreach ( var color in colors )
         list.Add( color ); // add color to the ArrayList list       

      // add elements in the removeColors array to 
      // the ArrayList removeList with the ArrayList constructor
      ArrayList removeList = new ArrayList( removeColors );

      Console.WriteLine( "ArrayList: " );
      DisplayInformation( list ); // output the list

      // remove from ArrayList list the colors in removeList
      RemoveColors( list, removeList );

      Console.WriteLine( "\nArrayList after calling RemoveColors: " );
      DisplayInformation( list ); // output list contents
   } // end Main

   // displays information on the contents of an array list
   private static void DisplayInformation( ArrayList arrayList )
   {
      // iterate through array list with a foreach statement
      foreach ( var element in arrayList )
         Console.Write( "{0} ", element ); // invokes ToString

      // display the size and capacity
      Console.WriteLine( "\nSize = {0}; Capacity = {1}",
         arrayList.Count, arrayList.Capacity );

      int index = arrayList.IndexOf( "BLUE" );

      if ( index != -1 )
         Console.WriteLine( "The array list contains BLUE at index {0}.",
            index );
      else
         Console.WriteLine( "The array list does not contain BLUE." );
   } // end method DisplayInformation

   // remove colors specified in secondList from firstList
   private static void RemoveColors( ArrayList firstList,
      ArrayList secondList )
   {
      // iterate through second ArrayList like an array
      for ( int count = 0; count < secondList.Count; count++ )
         firstList.Remove( secondList[ count ] );
   } // end method RemoveColors
} // end class ArrayListTest

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
