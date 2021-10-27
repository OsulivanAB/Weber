// Fig. 14.36: interestCalculatorForm.cs
// Demonstrating the NumericUpDown control.
using System;
using System.Windows.Forms;

namespace NumericUpDownTest
{
   public partial class InterestCalculatorForm : Form
   {
      // default constructor
      public InterestCalculatorForm()
      {
         InitializeComponent();
      } // end constructor

      private void calculateButton_Click(
         object sender, EventArgs e )
      {
         // declare variables to store user input
         decimal principal; // store principal
         double rate; // store interest rate
         int year; // store number of years
         decimal amount; // store amount
         string output; // store output

         // retrieve user input
         principal = Convert.ToDecimal( principalTextBox.Text );
         rate = Convert.ToDouble( interestTextBox.Text );
         year = Convert.ToInt32( yearUpDown.Value );

         // set output header
         output = "Year\tAmount on Deposit\r\n";

         // calculate amount after each year and append to output
         for ( int yearCounter = 1; yearCounter <= year; yearCounter++ )
         {
            amount = principal *
               ( ( decimal ) Math.Pow( ( 1 + rate / 100 ), yearCounter ) );
            output += ( yearCounter + "\t" +
               String.Format( "{0:C}", amount ) + "\r\n" );
         } // end for

         displayTextBox.Text = output; // display result
      } // end method calculateButton_Click 
   } // end class interestCalculatorForm
} // end namespace NumericUpDownTest

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