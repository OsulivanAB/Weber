// Fig. 18.28: Details.cs
// Using a DataGridView to display details based on a selection.
using System;
using System.Linq;
using System.Windows.Forms;

namespace MasterDetail
{
   public partial class Details : Form
   {
      public Details()
      {
         InitializeComponent();
      } // end constructor

      // connection to database
      private BooksDataContext database = new BooksDataContext();

      // this class helps us display each author's first
      // and last name in the authors drop-down list
      private class AuthorBinding
      {
         public Author Author { get; set; } // contained Author object
         public string Name { get; set; } // author's full name
      } // end class AuthorBinding

      // initialize data sources when the Form is loaded
      private void Details_Load( object sender, EventArgs e )
      {
         // display AuthorBinding.Name
         authorComboBox.DisplayMember = "Name";

         // set authorComboBox's DataSource to the list of authors
         authorComboBox.DataSource =
            from author in database.Authors
            orderby author.LastName, author.FirstName
            select new AuthorBinding { Author = author, 
               Name = author.FirstName + " " + author.LastName };

         // display Title.Title1
         titleComboBox.DisplayMember = "Title1";

         // set titleComboBox's DataSource to the list of titles
         titleComboBox.DataSource =
            from title in database.Titles
            orderby title.Title1
            select title;

         // initially, display no "detail" data
         booksDataGridView.DataSource = null;
      } // end method Details_Load

      // display titles that were co-authored by the selected author
      private void authorComboBox_SelectedIndexChanged(
         object sender, EventArgs e )
      {
         // get the selected Author object from the ComboBox
         Author currentAuthor =
            ( ( AuthorBinding ) authorComboBox.SelectedItem ).Author;

         // set titleBindingSource's DataSource to the
         // list of titles written by the selected author
         titleBindingSource.DataSource =
            from book in currentAuthor.AuthorISBNs
            select book.Title;

         // display the titles in the DataGridView
         booksDataGridView.DataSource = titleBindingSource;
      } // end method authorComboBox_SelectedIndexChanged

      // display the authors of the selected title
      private void titleComboBox_SelectedIndexChanged(
         object sender, EventArgs e )
      {
         // get the selected Title object from the ComboBox
         Title currentTitle = ( Title ) titleComboBox.SelectedItem;

         // set authorBindingSource's DataSource to the
         // list of authors for the selected title
         authorBindingSource.DataSource =
            from book in currentTitle.AuthorISBNs
            select book.Author;

         // display the authors in the DataGridView
         booksDataGridView.DataSource = authorBindingSource;
      } // end method titleComboBox_SelectedIndexChanged   
   } // end class Details
} // end namespace MasterDetail



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
