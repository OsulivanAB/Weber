// Fig. 20.2: LinearArray.cs
// Class that contains an array of random integers and a method 
// that will search that array sequentially.
using System;

public class LinearArray
{
   private int[] data; // array of values
   private static Random generator = new Random();

   // create array of given size and fill with random integers
   public LinearArray( int size )
   {
      data = new int[ size ]; // create space for array

      // fill array with random ints in range 10-99
      for ( int i = 0; i < size; i++ )
         data[ i ] = generator.Next( 10, 100 );
   } // end LinearArray constructor

   // perform a linear search on the data                
   public int LinearSearch( int searchKey )
   {
      // loop through array sequentially                 
      for ( int index = 0; index < data.Length; index++ )
         if ( data[ index ] == searchKey )
            return index; // return index of integer     

      return -1; // integer was not found                
   } // end method LinearSearch                          

   // method to output values in array
   public override string ToString()
   {
      string temporary = string.Empty;

      // iterate through array
      foreach ( int element in data )
         temporary += element + " ";

      temporary += "\n"; // add newline character
      return temporary;
   } // end method ToString
} // end class LinearArray

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