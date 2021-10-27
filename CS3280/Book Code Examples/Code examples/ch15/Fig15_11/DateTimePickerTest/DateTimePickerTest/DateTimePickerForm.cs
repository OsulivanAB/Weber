// Fig. 15.11: DateTimePickerForm.cs
// Using a DateTimePicker to select a drop off time.
using System;
using System.Windows.Forms;

namespace DateTimePickerTest
{
   // Form lets user select a drop off date using a DateTimePicker 
   // and displays an estimated delivery date
   public partial class DateTimePickerForm : Form
   {
      // constructor
      public DateTimePickerForm()
      {
         InitializeComponent();
      } // end constructor

      private void dropOffDateTimePicker_ValueChanged(
         object sender, EventArgs e )
      {
         DateTime dropOffDate = dropOffDateTimePicker.Value;

         // add extra time when items are dropped off around Sunday
         if ( dropOffDate.DayOfWeek == DayOfWeek.Friday ||
            dropOffDate.DayOfWeek == DayOfWeek.Saturday ||
            dropOffDate.DayOfWeek == DayOfWeek.Sunday )

            //estimate three days for delivery
            outputLabel.Text = 
               dropOffDate.AddDays( 3 ).ToLongDateString();
         else
            // otherwise estimate only two days for delivery
            outputLabel.Text = 
               dropOffDate.AddDays( 2 ).ToLongDateString();
      } // end method dropOffDateTimePicker_ValueChanged

      private void DateTimePickerForm_Load( object sender, EventArgs e )
      {
         // user cannot select days before today
         dropOffDateTimePicker.MinDate = DateTime.Today;

         // user can only select days of this year
         dropOffDateTimePicker.MaxDate = DateTime.Today.AddYears( 1 );
      } // end method DateTimePickerForm_Load
   } // end class DateTimePickerForm
} // end namepsace DateTimePickerTest

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

