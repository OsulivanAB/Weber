// Fig. 20.4: BinaryArray.cs
// Class that contains an array of random integers and a method 
// that uses binary search to find an integer.
using System;

public class BinaryArray
{
   private int[] data; // array of values
   private static Random generator = new Random();

   // create array of given size and fill with random integers
   public BinaryArray( int size )
   {
      data = new int[ size ]; // create space for array

      // fill array with random ints in range 10-99
      for ( int i = 0; i < size; i++ )
         data[ i ] = generator.Next( 10, 100 );

      Array.Sort( data );
   } // end BinaryArray constructor

   // perform a binary search on the data                          
   public int BinarySearch( int searchElement )
   {
      int low = 0; // low end of the search area                   
      int high = data.Length - 1; // high end of the search area   
      int middle = ( low + high + 1 ) / 2; // middle element       
      int location = -1; // return value; -1 if not found          

      do // loop to search for element                             
      {
         // print remaining elements of array                      
         Console.Write( RemainingElements( low, high ) );

         // output spaces for alignment                            
         for ( int i = 0; i < middle; i++ )
            Console.Write( "   " );

         Console.WriteLine( " * " ); // indicate current middle    

         // if the element is found at the middle                  
         if ( searchElement == data[ middle ] )
            location = middle; // location is the current middle   

         // middle element is too high                             
         else if ( searchElement < data[ middle ] )
            high = middle - 1; // eliminate the higher half        
         else // middle element is too low                         
            low = middle + 1; // eliminate the lower half          

         middle = ( low + high + 1 ) / 2; // recalculate the middle
      } while ( ( low <= high ) && ( location == -1 ) );

      return location; // return location of search key            
   } // end method BinarySearch                                    

   // method to output certain values in array
   public string RemainingElements( int low, int high )
   {
      string temporary = string.Empty;

      // output spaces for alignment
      for ( int i = 0; i < low; i++ )
         temporary += "   ";

      // output elements left in array
      for ( int i = low; i <= high; i++ )
         temporary += data[ i ] + " ";

      temporary += "\n";
      return temporary;
   } // end method RemainingElements

   // method to output values in array
   public override string ToString()
   {
      return RemainingElements( 0, data.Length - 1 );
   } // end method ToString   
} // end class BinaryArray

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