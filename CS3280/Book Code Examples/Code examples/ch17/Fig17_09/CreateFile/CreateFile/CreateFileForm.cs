// Fig. 17.9: CreateFileForm.cs
// Creating a sequential-access file.
using System;
using System.Windows.Forms;
using System.IO;
using BankLibrary;

namespace CreateFile
{
   public partial class CreateFileForm : BankUIForm
   {
      private StreamWriter fileWriter; // writes data to text file

      // parameterless constructor
      public CreateFileForm()
      {
         InitializeComponent();
      } // end constructor

      // event handler for Save Button
      private void saveButton_Click( object sender, EventArgs e )
      {
         // create and show dialog box enabling user to save file
         DialogResult result; // result of SaveFileDialog
         string fileName; // name of file containing data

         using ( SaveFileDialog fileChooser = new SaveFileDialog() )
         {
            fileChooser.CheckFileExists = false; // let user create file
            result = fileChooser.ShowDialog();
            fileName = fileChooser.FileName; // name of file to save data
         } // end using

         // ensure that user clicked "OK"
         if ( result == DialogResult.OK )
         {
            // show error if user specified invalid file
            if ( fileName == string.Empty )
               MessageBox.Show( "Invalid File Name", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error );
            else
            {
               // save file via FileStream if user specified valid file
               try
               {
                  // open file with write access
                  FileStream output = new FileStream( fileName,
                     FileMode.OpenOrCreate, FileAccess.Write );

                  // sets file to where data is written
                  fileWriter = new StreamWriter( output );

                  // disable Save button and enable Enter button
                  saveButton.Enabled = false;
                  enterButton.Enabled = true;
               } // end try
               // handle exception if there is a problem opening the file
               catch ( IOException )
               {
                  // notify user if file does not exist
                  MessageBox.Show( "Error opening file", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error );
               } // end catch
            } // end else
         } // end if
      } // end method saveButton_Click

      // handler for enterButton Click
      private void enterButton_Click( object sender, EventArgs e )
      {
         // store TextBox values string array
         string[] values = GetTextBoxValues();

         // Record containing TextBox values to output
         Record record = new Record();

         // determine whether TextBox account field is empty
         if ( values[ ( int ) TextBoxIndices.ACCOUNT ] != string.Empty )
         {
            // store TextBox values in Record and output it
            try
            {
               // get account number value from TextBox
               int accountNumber = Int32.Parse(
                  values[ ( int ) TextBoxIndices.ACCOUNT ] );

               // determine whether accountNumber is valid
               if ( accountNumber > 0 )
               {
                  // store TextBox fields in Record
                  record.Account = accountNumber;
                  record.FirstName = values[ ( int )
                     TextBoxIndices.FIRST ];
                  record.LastName = values[ ( int )
                     TextBoxIndices.LAST ];
                  record.Balance = Decimal.Parse(
                     values[ ( int ) TextBoxIndices.BALANCE ] );

                  // write Record to file, fields separated by commas
                  fileWriter.WriteLine(
                     record.Account + "," + record.FirstName + "," +
                     record.LastName + "," + record.Balance );
               } // end if
               else
               {
                  // notify user if invalid account number
                  MessageBox.Show( "Invalid Account Number", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error );
               } // end else
            } // end try
            // notify user if error occurs during write operation
            catch ( IOException )
            {
               MessageBox.Show( "Error Writing to File", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error );
            } // end catch
            // notify user if error occurs regarding parameter format
            catch ( FormatException )
            {
               MessageBox.Show( "Invalid Format", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error );
            } // end catch
         } // end if

         ClearTextBoxes(); // clear TextBox values
      } // end method enterButton_Click

      // handler for exitButton Click
      private void exitButton_Click( object sender, EventArgs e )
      {
         // determine whether file exists
         if ( fileWriter != null )
         {
            try
            {
               // close StreamWriter and underlying file
               fileWriter.Close(); 
            } // end try
            // notify user of error closing file
            catch ( IOException )
            {
               MessageBox.Show( "Cannot close file", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error );
            } // end catch
         } // end if

         Application.Exit();
      } // end method exitButton_Click
   } // end class CreateFileForm
} // end namespace CreateFile


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