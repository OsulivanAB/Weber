// Fig. 17.7: BankUIForm.cs
// A reusable Windows Form for the examples in this chapter.
using System;
using System.Windows.Forms;

namespace BankLibrary
{
   public partial class BankUIForm : Form
   {
      protected int TextBoxCount = 4; // number of TextBoxes on Form

      // enumeration constants specify TextBox indices
      public enum TextBoxIndices
      {
         ACCOUNT,
         FIRST,
         LAST,
         BALANCE
      } // end enum

      // parameterless constructor
      public BankUIForm()
      {
         InitializeComponent();
      } // end constructor

      // clear all TextBoxes
      public void ClearTextBoxes()
      {
         // iterate through every Control on form
         foreach ( Control guiControl in Controls )
         {
            // determine whether Control is TextBox
            if ( guiControl is TextBox )
            {
               // clear TextBox
               ( ( TextBox ) guiControl ).Clear();
            } // end if
         } // end for
      } // end method ClearTextBoxes

      // set text box values to string array values
      public void SetTextBoxValues( string[] values )
      {
         // determine whether string array has correct length
         if ( values.Length != TextBoxCount )
         {
            // throw exception if not correct length
            throw ( new ArgumentException( "There must be " +
               ( TextBoxCount + 1 ) + " strings in the array" ) );
         } // end if
         // set array values if array has correct length
         else
         {
            // set array values to TextBox values
            accountTextBox.Text = 
               values[ ( int ) TextBoxIndices.ACCOUNT ];
            firstNameTextBox.Text = 
               values[ ( int ) TextBoxIndices.FIRST ];
            lastNameTextBox.Text = 
               values[ ( int ) TextBoxIndices.LAST ];
            balanceTextBox.Text = 
               values[ ( int ) TextBoxIndices.BALANCE ];
         } // end else
      } // end method SetTextBoxValues

      // return TextBox values as string array
      public string[] GetTextBoxValues()
      {
         string[] values = new string[ TextBoxCount ];

         // copy TextBox fields to string array
         values[ ( int ) TextBoxIndices.ACCOUNT ] = accountTextBox.Text;
         values[ ( int ) TextBoxIndices.FIRST ] = firstNameTextBox.Text;
         values[ ( int ) TextBoxIndices.LAST ] = lastNameTextBox.Text;
         values[ ( int ) TextBoxIndices.BALANCE ] = balanceTextBox.Text;

         return values;
      } // end method GetTextBoxValues
   } // end class BankUIForm
} // end namespace BankLibrary


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