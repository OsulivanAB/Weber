// Fig. 29.8: WeatherDetailsView.xaml.cs
// WeatherViewer's WeatherDetailsView custom control (code-behind).
using System.Windows;
using System.Windows.Controls;

namespace WeatherViewer
{
   public partial class WeatherDetailsView : UserControl
   {
      // constructor
      public WeatherDetailsView()
      {
         InitializeComponent();
      } // end constructor

      // close the details view
      private void closeButton_Click( object sender, RoutedEventArgs e )
      {
         this.Visibility = Visibility.Collapsed;
      } // end method closeButton_Click
   } // end class WeatherDetailsView
} // end namespace WeatherViewer

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