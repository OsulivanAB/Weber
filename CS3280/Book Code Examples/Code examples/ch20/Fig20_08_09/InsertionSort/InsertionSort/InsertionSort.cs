// Fig. 20.8: InsertionSort.cs
// Class that creates an array filled with random integers.  
// Provides a method to sort the array with insertion sort.
using System;

public class InsertionSort
{
   private int[] data; // array of values
   private static Random generator = new Random();

   // create array of given size and fill with random integers
   public InsertionSort( int size )
   {
      data = new int[ size ]; // create space for array

      // fill array with random ints in range 10-99
      for ( int i = 0; i < size; i++ )
         data[ i ] = generator.Next( 10, 100 );
   } // end InsertionSort constructor

   // sort array using insertion sort                            
   public void Sort()
   {
      int insert; // temporary variable to hold element to insert

      // loop over data.Length - 1 elements                      
      for ( int next = 1; next < data.Length; next++ )
      {
         // store value in current element                       
         insert = data[ next ];

         // initialize location to place element                 
         int moveItem = next;

         // search for place to put current element              
         while ( moveItem > 0 && data[ moveItem - 1 ] > insert )
         {
            // shift element right one slot                      
            data[ moveItem ] = data[ moveItem - 1 ];
            moveItem--;
         } // end while                                          

         data[ moveItem ] = insert; // place inserted element    
         PrintPass( next, moveItem ); // output pass of algorithm
      } // end for                                               
   } // end method Sort                                          

   // print a pass of the algorithm
   public void PrintPass( int pass, int index )
   {
      Console.Write( "after pass {0}: ", pass );

      // output elements till swapped item
      for ( int i = 0; i < index; i++ )
         Console.Write( data[ i ] + "  " );

      Console.Write( data[ index ] + "* " ); // indicate swap

      // finish outputting array
      for ( int i = index + 1; i < data.Length; i++ )
         Console.Write( data[ i ] + "  " );

      Console.Write( "\n              " ); // for alignment

      // indicate amount of array that is sorted
      for ( int i = 0; i <= pass; i++ )
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
} // end class InsertionSort