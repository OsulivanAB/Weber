// Fig. 25.19: MainWindow.xaml.cs
// Changing the axis of rotation for a 3-D animation.
using System.Windows;
using System.Windows.Media.Media3D;

namespace Application3D
{
   public partial class MainWindow : Window
   {
      // constructor
      public MainWindow()
      {
         InitializeComponent();
      } // end constructor

      // when user selects xRadio, set axis of rotation
      private void xRadio_Checked( object sender, RoutedEventArgs e )
      {
         rotation.Axis = new Vector3D( 1, 0, 0 ); // set rotation axis
         camera.Position = new Point3D( 6, 0, 0 ); // set camera position
      } // end method xRadio_Checked

      // when user selects yRadio, set axis of rotation
      private void yRadio_Checked( object sender, RoutedEventArgs e )
      {
         rotation.Axis = new Vector3D( 0, 1, 0 ); // set rotation axis
         camera.Position = new Point3D( 6, 0, 0 ); // set camera position
      } // end method yRadio_Checked

      // when user selects zRadio, set axis of rotation
      private void zRadio_Checked( object sender, RoutedEventArgs e )
      {
         rotation.Axis = new Vector3D( 0, 0, 1 ); // set rotation axis
         camera.Position = new Point3D( 6, 0, 1 ); // set camera position
      } // end method zRadio_Checked
   } // end class MainWindow
} // end namespace Application3D

/*************************************************************************
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