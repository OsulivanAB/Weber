// Fig. 20.6: SelectionSort.cs
// Class that creates an array filled with random integers. 
// Provides a method to sort the array with selection sort.
using System;

public class SelectionSort
{
   private int[] data; // array of values
   private static Random generator = new Random();

   // create array of given size and fill with random integers
   public SelectionSort( int size )
   {
      data = new int[ size ]; // create space for array

      // fill array with random ints in range 10-99
      for ( int i = 0; i < size; i++ )
         data[ i ] = generator.Next( 10, 100 );
   } // end SelectionSort constructor

   // sort array using selection sort                               
   public void Sort()
   {
      int smallest; // index of smallest element                    

      // loop over data.Length - 1 elements                         
      for ( int i = 0; i < data.Length - 1; i++ )
      {
         smallest = i; // first index of remaining array            

         // loop to find index of smallest element                  
         for ( int index = i + 1; index < data.Length; index++ )
            if ( data[ index ] < data[ smallest ] )
               smallest = index;

         Swap( i, smallest ); // swap smallest element into position
         PrintPass( i + 1, smallest ); // output pass of algorithm  
      } // end outer for                                            
   } // end method Sort                                             

   // helper method to swap values in two elements                
   public void Swap( int first, int second )
   {
      int temporary = data[ first ]; // store first in temporary  
      data[ first ] = data[ second ]; // replace first with second
      data[ second ] = temporary; // put temporary in second      
   } // end method Swap                                           

   // print a pass of the algorithm
   public void PrintPass( int pass, int index )
   {
      Console.Write( "after pass {0}: ", pass );

      // output elements through the selected item
      for ( int i = 0; i < index; i++ )
         Console.Write( data[ i ] + "  " );

      Console.Write( data[ index ] + "* " ); // indicate swap

      // finish outputting array
      for ( int i = index + 1; i < data.Length; i++ )
         Console.Write( data[ i ] + "  " );

      Console.Write( "\n              " ); // for alignment

      // indicate amount of array that is sorted
      for ( int j = 0; j < pass; j++ )
         Console.Write( "--  " );
      Console.WriteLine( "\n" ); // skip a line in output
   } // end method PrintPass

   // method to output values in array
   public override string ToString()
   {
      string temporary = string.Empty;

      // iterate through array
      foreach ( int element in data )
         temporary += element + "  ";

      temporary += "\n"; // add newline character
      return temporary;
   } // end method ToString
} // end class SelectionSort

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
 **************************************************************************/