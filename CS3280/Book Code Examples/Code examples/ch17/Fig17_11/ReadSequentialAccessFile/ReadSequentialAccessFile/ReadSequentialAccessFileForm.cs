// Fig. 17.11: ReadSequentialAccessFileForm.cs
// Reading a sequential-access file.
using System;
using System.Windows.Forms;
using System.IO;
using BankLibrary;

namespace ReadSequentialAccessFile
{
   public partial class ReadSequentialAccessFileForm : BankUIForm
   {
      private StreamReader fileReader; // reads data from a text file

      // parameterless constructor
      public ReadSequentialAccessFileForm()
      {
         InitializeComponent();
      } // end constructor

      // invoked when user clicks the Open button
      private void openButton_Click( object sender, EventArgs e )
      {
         // create and show dialog box enabling user to open file         
         DialogResult result; // result of OpenFileDialog
         string fileName; // name of file containing data

         using ( OpenFileDialog fileChooser = new OpenFileDialog() )
         {
            result = fileChooser.ShowDialog();
            fileName = fileChooser.FileName; // get specified name
         } // end using

         // ensure that user clicked "OK"
         if ( result == DialogResult.OK )
         {
            ClearTextBoxes();

            // show error if user specified invalid file
            if ( fileName == string.Empty )
               MessageBox.Show( "Invalid File Name", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error );
            else
            {
               try
               {
                  // create FileStream to obtain read access to file
                  FileStream input = new FileStream( 
                     fileName, FileMode.Open, FileAccess.Read );

                  // set file from where data is read
                  fileReader = new StreamReader( input );

                  openButton.Enabled = false; // disable Open File button
                  nextButton.Enabled = true; // enable Next Record button
               } // end try
               catch ( IOException )
               {
                  MessageBox.Show( "Error reading from file",
                     "File Error", MessageBoxButtons.OK,
                     MessageBoxIcon.Error );
               } // end catch
            } // end else
         } // end if
      } // end method openButton_Click

      // invoked when user clicks Next button
      private void nextButton_Click( object sender, EventArgs e )
      {
         try
         {
            // get next record available in file
            string inputRecord = fileReader.ReadLine();
            string[] inputFields; // will store individual pieces of data

            if ( inputRecord != null )
            {
               inputFields = inputRecord.Split( ',' );

               Record record = new Record(
                  Convert.ToInt32( inputFields[ 0 ] ), inputFields[ 1 ],
                  inputFields[ 2 ], 
                  Convert.ToDecimal( inputFields[ 3 ] ) );

               // copy string array values to TextBox values
               SetTextBoxValues( inputFields );
            } // end if
            else
            {
               // close StreamReader and underlying file
               fileReader.Close();
               openButton.Enabled = true; // enable Open File button
               nextButton.Enabled = false; // disable Next Record button
               ClearTextBoxes();

               // notify user if no Records in file
               MessageBox.Show( "No more records in file", String.Empty,
                  MessageBoxButtons.OK, MessageBoxIcon.Information );
            } // end else
         } // end try
         catch ( IOException )
         {
            MessageBox.Show( "Error Reading from File", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error );
         } // end catch
      } // end method nextButton_Click
   } // end class ReadSequentialAccessFileForm
} // end namespace ReadSequentialAccessFile


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