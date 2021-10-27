// Fig. 23.12: SortedDictionaryTest.cs
// Application counts the number of occurrences of each word in a string
// and stores them in a generic sorted dictionary.
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class SortedDictionaryTest
{
   public static void Main( string[] args )
   {
      // create sorted dictionary based on user input
      SortedDictionary< string, int > dictionary = CollectWords();

      // display sorted dictionary content
      DisplayDictionary( dictionary );
   } // end Main

   // create sorted dictionary from user input
   private static SortedDictionary< string, int > CollectWords()
   {
      // create a new sorted dictionary
      SortedDictionary< string, int > dictionary =
         new SortedDictionary< string, int >();

      Console.WriteLine( "Enter a string: " ); // prompt for user input
      string input = Console.ReadLine(); // get input

      // split input text into tokens
      string[] words = Regex.Split( input, @"\s+" );

      // processing input words
      foreach ( var word in words )
      {
         string wordKey = word.ToLower(); // get word in lowercase

         // if the dictionary contains the word
         if ( dictionary.ContainsKey( wordKey ) )
         {
            ++dictionary[ wordKey ];
         } // end if
         else
            // add new word with a count of 1 to the dictionary
            dictionary.Add( wordKey, 1 );
      } // end foreach

      return dictionary;
   } // end method CollectWords

   // display dictionary content
   private static void DisplayDictionary< K, V >(
      SortedDictionary< K, V > dictionary )
   {
      Console.WriteLine( "\nSorted dictionary contains:\n{0,-12}{1,-12}",
         "Key:", "Value:" );

      // generate output for each key in the sorted dictionary
      // by iterating through the Keys property with a foreach statement
      foreach ( K key in dictionary.Keys )
         Console.WriteLine( "{0,-12}{1,-12}", key, dictionary[ key ] );

      Console.WriteLine( "\nsize: {0}", dictionary.Count );
   } // end method DisplayDictionary
} // end class SortedDictionaryTest


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
