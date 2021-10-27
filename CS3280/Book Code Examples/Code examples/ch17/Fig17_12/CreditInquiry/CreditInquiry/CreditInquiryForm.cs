// Fig. 17.12: CreditInquiryForm.cs
// Read a file sequentially and display contents based on
// account type specified by user ( credit, debit or zero balances ).
using System;
using System.Windows.Forms;
using System.IO;
using BankLibrary;

namespace CreditInquiry
{
   public partial class CreditInquiryForm : Form
   {
      private FileStream input; // maintains the connection to the file
      private StreamReader fileReader; // reads data from text file

      // name of file that stores credit, debit and zero balances
      private string fileName;

      // parameterless constructor
      public CreditInquiryForm()
      {
         InitializeComponent();
      } // end constructor

      // invoked when user clicks Open File button
      private void openButton_Click( object sender, EventArgs e )
      {
         // create dialog box enabling user to open file         
         DialogResult result;

         using ( OpenFileDialog fileChooser = new OpenFileDialog() )
         {
            result = fileChooser.ShowDialog();
            fileName = fileChooser.FileName;
         } // end using

         // exit event handler if user clicked Cancel
         if ( result == DialogResult.OK )
         {
            // show error if user specified invalid file
            if ( fileName == string.Empty )
               MessageBox.Show( "Invalid File Name", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error );
            else
            {
               // create FileStream to obtain read access to file
               input = new FileStream( fileName,
                  FileMode.Open, FileAccess.Read );

               // set file from where data is read
               fileReader = new StreamReader( input );

               // enable all GUI buttons, except for Open File button
               openButton.Enabled = false;
               creditButton.Enabled = true;
               debitButton.Enabled = true;
               zeroButton.Enabled = true;
            } // end else
         } // end if
      } // end method openButton_Click

      // invoked when user clicks credit balances,
      // debit balances or zero balances button
      private void getBalances_Click( object sender, System.EventArgs e )
      {
         // convert sender explicitly to object of type button
         Button senderButton = ( Button ) sender;

         // get text from clicked Button, which stores account type
         string accountType = senderButton.Text;

         // read and display file information
         try
         {
            // go back to the beginning of the file
            input.Seek( 0, SeekOrigin.Begin );

            displayTextBox.Text = "The accounts are:\r\n";

            // traverse file until end of file
            while ( true )
            {
               string[] inputFields; // stores individual pieces of data
               Record record; // store each Record as file is read
               decimal balance; // store each Record's balance

               // get next Record available in file
               string inputRecord = fileReader.ReadLine();

               // when at the end of file, exit method
               if ( inputRecord == null )
                  return;

               inputFields = inputRecord.Split( ',' ); // parse input

               // create Record from input
               record = new Record(
                  Convert.ToInt32( inputFields[ 0 ] ), inputFields[ 1 ],
                  inputFields[ 2 ], Convert.ToDecimal( inputFields[ 3 ] ) );

               // store record's last field in balance
               balance = record.Balance;

               // determine whether to display balance
               if ( ShouldDisplay( balance, accountType ) )
               {
                  // display record
                  string output = record.Account + "\t" +
                     record.FirstName + "\t" + record.LastName + "\t";

                  // display balance with correct monetary format
                  output += String.Format( "{0:F}", balance ) + "\r\n";

                  // copy output to screen
                  displayTextBox.AppendText( output );
               } // end if
            } // end while
         } // end try
         // handle exception when file cannot be read
         catch ( IOException )
         {
            MessageBox.Show( "Cannot Read File", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error );
         } // end catch
      } // end method getBalances_Click

      // determine whether to display given record
      private bool ShouldDisplay( decimal balance, string accountType )
      {
         if ( balance > 0M )
         {
            // display credit balances
            if ( accountType == "Credit Balances" )
               return true;
         } // end if
         else if ( balance < 0M )
         {
            // display debit balances
            if ( accountType == "Debit Balances" )
               return true;
         } // end else if
         else // balance == 0
         {
            // display zero balances
            if ( accountType == "Zero Balances" )
               return true;
         } // end else

         return false;
      } // end method ShouldDisplay

      // invoked when user clicks Done button
      private void doneButton_Click( object sender, EventArgs e )
      {
         if ( input != null )
         {
            // close file and StreamReader
            try
            {
               // close StreamReader and underlying file
               fileReader.Close();
            } // end try
            // handle exception if FileStream does not exist
            catch ( IOException )
            {
               // notify user of error closing file
               MessageBox.Show( "Cannot close file", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error );
            } // end catch
         } // end if

         Application.Exit();
      } // end method doneButton_Click
   } // end class CreditInquiryForm
} // end namespace CreditInquiry

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