// Fig. 18.34: Contact.cs
// Manipulating an address book.
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook
{
   public partial class Contacts : Form
   {
      public Contacts()
      {
         InitializeComponent();
      } // end constructor

      // LINQ to SQL data context
      private AddressBookDataContext database =
         new AddressBookDataContext();

      // fill our addressBindingSource with all rows, ordered by name
      private void RefreshContacts()
      {
         // use LINQ to create a data source from the database
         addressBindingSource.DataSource =
            from address in database.Addresses
            orderby address.LastName, address.FirstName
            select address;

         addressBindingSource.MoveFirst(); // go to the first result
         findTextBox.Clear(); // clear the Find TextBox
      } // end method RefreshContacts

      // when the form loads, fill it with data from the database
      private void Contacts_Load( object sender, EventArgs e )
      {
         RefreshContacts(); // fill binding with data from database
      } // end method Contacts_Load

      // Click event handler for the Save Button in the 
      // BindingNavigator saves the changes made to the data
      private void addressBindingNavigatorSaveItem_Click( 
         object sender, EventArgs e )
      {
         Validate(); // validate input fields
         addressBindingSource.EndEdit(); // indicate edits are complete
         database.SubmitChanges(); // write changes to database file

         RefreshContacts(); // change back to initial unfiltered data 
      } // end method addressBindingNavigatorSaveItem_Click

      // use LINQ to create a data source that contains only people
      // with last names that start with the specified text
      private void findButton_Click( object sender, EventArgs e )
      {
         // use LINQ to create a data source from the database
         addressBindingSource.DataSource =
            from address in database.Addresses
            where address.LastName.StartsWith( findTextBox.Text )
            orderby address.LastName, address.FirstName
            select address;

         addressBindingSource.MoveFirst(); // go to first result
      } // end method findButton_Click

      // reload addressBindingSource with all rows
      private void browseButton_Click( object sender, EventArgs e )
      {
         RefreshContacts(); // change back to initial unfiltered data
      } // end method browseButton_Click
   } // end class Contacts
} // end namespace AddressBook



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
