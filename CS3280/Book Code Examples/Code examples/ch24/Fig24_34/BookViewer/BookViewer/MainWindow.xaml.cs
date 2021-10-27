// Fig. 24.32: MainWindow.xaml.cs
// Using data binding (code-behind).
using System.Collections.Generic;
using System.Windows;

namespace BookViewer
{
   public partial class MainWindow : Window
   {
      private List< Book > books = new List< Book >();

      public MainWindow()
      {
         InitializeComponent();

         // add Book objects to the List
         books.Add( new Book( "AJAX, Rich Internet Applications, " +
            "and Web Development for Programmers", "0131587382",
            "images/small/ajax.jpg", "images/large/ajax.jpg" ) );
         books.Add( new Book( "C++ How to Program", "0136152503",
            "images/small/cppHTP6e.jpg", "images/large/cppHTP6e.jpg" ) );
         books.Add( new Book(
            "Internet and World Wide Web How to Program", "0131752421", 
            "images/small/iw3htp4.jpg", "images/large/iw3htp4.jpg" ) );
         books.Add( new Book( "Java How to Program", "0132222205",
            "images/small/jhtp7.jpg", "images/large/jhtp7.jpg" ) );
         books.Add( new Book( "Operating Systems", "0131828274",
            "images/small/os3e.jpg", "images/large/os3e.jpg" ) );
         books.Add( new Book( "Visual C++ 2008 How to Program",
            "0136151574", "images/small/vcpp2008htp2e.jpg",
            "images/large/vcpp2008htp2e.jpg" ) );

         booksListView.ItemsSource = books; // bind data to the list
      } // end constructor
   } // end class MainWindow
} // end namespace BookViewer

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
 **************************************************************************/