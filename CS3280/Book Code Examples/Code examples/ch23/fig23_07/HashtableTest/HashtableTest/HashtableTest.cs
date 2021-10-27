// Fig. 23.7: HashtableTest.cs
// Application counts the number of occurrences of each word in a string
// and stores them in a hash table.
using System;
using System.Text.RegularExpressions;
using System.Collections;

public class HashtableTest
{
   public static void Main( string[] args )
   {
      // create hash table based on user input
      Hashtable table = CollectWords();

      // display hash table content
      DisplayHashtable( table );
   } // end Main

   // create hash table from user input
   private static Hashtable CollectWords()
   {
      Hashtable table = new Hashtable(); // create a new hash table

      Console.WriteLine( "Enter a string: " ); // prompt for user input
      string input = Console.ReadLine(); // get input

      // split input text into tokens
      string[] words = Regex.Split( input, @"\s+" );

      // processing input words
      foreach ( var word in words )
      {
         string wordKey = word.ToLower(); // get word in lowercase

         // if the hash table contains the word
         if ( table.ContainsKey( wordKey ) )
         {
            table[ wordKey ] = ( ( int ) table[ wordKey ] ) + 1;
         } // end if
         else
            // add new word with a count of 1 to hash table
            table.Add( wordKey, 1 );
      } // end foreach

      return table;
   } // end method CollectWords

   // display hash table content
   private static void DisplayHashtable( Hashtable table )
   {
      Console.WriteLine( "\nHashtable contains:\n{0,-12}{1,-12}",
         "Key:", "Value:" );

      // generate output for each key in hash table
      // by iterating through the Keys property with a foreach statement
      foreach ( var key in table.Keys )
         Console.WriteLine( "{0,-12}{1,-12}", key, table[ key ] );

      Console.WriteLine( "\nsize: {0}", table.Count );
   } // end method DisplayHashtable
} // end class HashtableTest


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
