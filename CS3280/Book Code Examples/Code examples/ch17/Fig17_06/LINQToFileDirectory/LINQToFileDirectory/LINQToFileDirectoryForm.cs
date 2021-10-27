﻿// Fig 19.6: LINQToFileDirectoryForm.cs
// Using LINQ to search directories and determine file types.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace LINQToFileDirectory
{
   public partial class LINQToFileDirectoryForm : Form
   {
      string currentDirectory; // directory to search

      // store extensions found, and number of each extension found
      Dictionary<string, int> found = new Dictionary<string, int>();

      // parameterless constructor
      public LINQToFileDirectoryForm()
      {
         InitializeComponent();
      } // end constructor

      // handles the Search Directory Button's Click event
      private void searchButton_Click( object sender, EventArgs e )
      {
         // check if user specified path exists
         if ( pathTextBox.Text != string.Empty &&
            !Directory.Exists( pathTextBox.Text ) )
         {
            // show error if user does not specify valid directory
            MessageBox.Show( "Invalid Directory", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error );
         } // end if
         else
         {
            // use current directory if no directory is specified
            if ( pathTextBox.Text == String.Empty )
               currentDirectory = Directory.GetCurrentDirectory();
            else
               currentDirectory = pathTextBox.Text;

            directoryTextBox.Text = currentDirectory; // show directory

            // clear TextBoxes
            pathTextBox.Clear();
            resultsTextBox.Clear();

            SearchDirectory( currentDirectory ); // search the directory

            // allow user to delete .bak files
            CleanDirectory( currentDirectory );

            // summarize and display the results
            foreach ( var current in found.Keys )
            {
               // display the number of files with current extension
               resultsTextBox.AppendText( String.Format(
                  "* Found {0} {1} files.\r\n", 
                  found[ current ], current ) );
            } // end foreach

            found.Clear(); // clear results for new search
         } // end else
      } // end method searchButton_Click

      // search directory using LINQ
      private void SearchDirectory( string folder )
      {
         // files contained in the directory
         string[] files = Directory.GetFiles( folder );

         // subdirectories in the directory
         string[] directories = Directory.GetDirectories( folder );

         // find all file extensions in this directory
         var extensions =
            ( from file in files
              select Path.GetExtension( file ) ).Distinct();

         // count the number of files using each extension
         foreach ( var extension in extensions )
         {
            var temp = extension;

            // count the number of files with the extension
            var extensionCount =
               ( from file in files
                 where Path.GetExtension( file ) == temp
                 select file ).Count();

            // if the Dictionary already contains a key for the extension
            if ( found.ContainsKey( extension ) )
               found[ extension ] += extensionCount; // update the count
            else
               found.Add( extension, extensionCount ); // add new count
         } // end foreach

         // recursive call to search subdirectories
         foreach ( var subdirectory in directories )
            SearchDirectory( subdirectory );
      } // end method SearchDirectory

      // allow user to delete backup files (.bak)
      private void CleanDirectory( string folder )
      {
         // files contained in the directory
         string[] files = Directory.GetFiles( folder );

         // subdirectories in the directory
         string[] directories = Directory.GetDirectories( folder );

         // select all the backup files in this directory
         var backupFiles =
            from file in files
            where Path.GetExtension( file ) == ".bak"
            select file;

         // iterate over all backup files (.bak)
         foreach ( var backup in backupFiles )
         {
            DialogResult result = MessageBox.Show( "Found backup file " +
               Path.GetFileName( backup ) + ". Delete?", "Delete Backup",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            // delete file if user clicked 'yes'
            if ( result == DialogResult.Yes )
            {
               File.Delete( backup ); // delete backup file
               --found[ ".bak" ]; // decrement count in Dictionary

               // if there are no .bak files, delete key from Dictionary
               if ( found[ ".bak" ] == 0 )
                  found.Remove( ".bak" );
            } // end if
         } // end foreach

         // recursive call to clean subdirectories
         foreach ( var subdirectory in directories )
            CleanDirectory( subdirectory );
      } // end method CleanDirectory
   } // end class LINQToFileDirectoryForm
} // end namespace LINQToFileDirectory

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
 *************************************************************************/