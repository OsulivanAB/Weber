// Fig. 24.20: MainPage.xaml.cs
// DeepZoomCoverCollage employs Silverlight's deep zoom (code-behind).
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace DeepZoomCoverCollage
{
   public partial class MainPage : UserControl
   {
      private const double ZOOMFACTOR = 2.0;

      private bool zoomIn = false; // true if Up button is pressed 
      private bool zoomOut = false; // true if Down button is pressed 
      private bool mouseDown = false; // true if mouse button is down 
      private Point currentPosition; // position of viewport when clicked
      private Point dragOffset; // mouse offset used for panning 

      // constructor
      public MainPage()
      {
         InitializeComponent();
      } // end constructor

      //  when a key is pressed, set the correct variables to true
      private void mainPage_KeyDown( object sender, KeyEventArgs e )
      {
         if ( e.Key == Key.Up ) // button pressed is Up
         {
            zoomIn = true; // prepare to zoom in 
         } // end if 
         else if ( e.Key == Key.Down ) // button pressed is Down
         {
            zoomOut = true; // prepare to zoom out 
         } // end else if
      } // end method mainPage_KeyDown

      // when a key is released, set the correct variables to false
      private void mainPage_KeyUp( object sender, KeyEventArgs e )
      {
         if ( e.Key == Key.Up ) // button released is I 
         {
            zoomIn = false; // don't zoom in 
         } // end if
         else if ( e.Key == Key.Down ) // button released is O 
         {
            zoomOut = false; // don't zoom out 
         } // end else if
      } // end method mainPage_KeyUp

      // when the mouse leaves the area of the image we don't want to pan
      private void Image_MouseLeave( object sender, MouseEventArgs e )
      {
         mouseDown = false; // if mouse leaves area, no more panning
      } // end method Image_MouseLeave

      // handle events when user clicks the mouse
      private void Image_MouseLeftButtonDown( object sender,
         MouseButtonEventArgs e )
      {
         mouseDown = true; // mouse button is down 
         currentPosition = Image.ViewportOrigin; // viewport position
         dragOffset = e.GetPosition( Image ); // mouse position 

         // logical position (between 0 and 1) of mouse 
         Point click = Image.ElementToLogicalPoint( dragOffset );

         if ( zoomIn ) // zoom in when Up key is pressed 
         {
            Image.ZoomAboutLogicalPoint( ZOOMFACTOR, click.X, click.Y );
         } // end if
         else if ( zoomOut ) // zoom out when Down key is pressed 
         {
            Image.ZoomAboutLogicalPoint( 1 / ZOOMFACTOR,
               click.X, click.Y );
         } // end else if

         // determine which book cover was pressed to display the title
         int index = SubImageIndex( click );

         if ( index > -1 )
         {
            titleTextBlock.Text = string.Format( 
               "Title: {0}", GetTitle( index ) );
         }
         else // user clicked a blank space
         {
            titleTextBlock.Text = "Title:";
         } // end else
      } // end method Image_MouseLeftButtonDown

      // if the mouse button is released, we don't want to pan anymore
      private void Image_MouseLeftButtonUp( object sender,
         MouseButtonEventArgs e )
      {
         mouseDown = false; // no more panning
      } // end method Image_MouseLeftButtonUp

      // handle when the mouse moves: panning
      private void Image_MouseMove( object sender, MouseEventArgs e )
      {
         // if no zoom occurs, we want to pan 
         if ( mouseDown && !zoomIn && !zoomOut )
         {
            Point click = new Point(); // records point to move to
            click.X = currentPosition.X - Image.ViewportWidth * (
               e.GetPosition( Image ).X - dragOffset.X ) /
               Image.ActualWidth;
            click.Y = currentPosition.Y - Image.ViewportWidth * (
               e.GetPosition( Image ).Y - dragOffset.Y ) /
               Image.ActualWidth;
            Image.ViewportOrigin = click; // pans the image 
         } // end if
      } // end method Image_MouseMove

      // returns the index of the clicked subimage
      private int SubImageIndex( Point click )
      {
         // go through images such that images on top are processed first
         for ( int i = Image.SubImages.Count - 1; i >= 0; i-- )
         {
            // select a single subimage 
            MultiScaleSubImage subImage = Image.SubImages[ i ];

            // create a rect around the area of the cover 
            double scale = 1 / subImage.ViewportWidth;
            Rect area = new Rect( -subImage.ViewportOrigin.X * scale,
               -subImage.ViewportOrigin.Y * scale, scale, scale /
               subImage.AspectRatio );

            if ( area.Contains( click ) )
            {
               return i; // return the index of the clicked cover
            } // end if
         } // end for
         return -1; // if no cover was clicked, return -1
      } // end method SubImageIndex

      // returns the title of the subimage with the given index
      private string GetTitle( int index )
      {
         // XDocument that contains info on all subimages in the collage
         XDocument xmlDocument = 
            XDocument.Load( "SparseImageSceneGraph.xml" );

         // LINQ to XML to find the title based on index of clicked image
         var bookTitle =
            from info in xmlDocument.Descendants( "SceneNode" )
            let order = Convert.ToInt32( info.Element( "ZOrder" ).Value )
            where order == index + 1
            select info.Element( "FileName" ).Value;

         string title = bookTitle.Single(); // gets book title

         // only want title of book, not the rest of the file name
         title = Path.GetFileName( title );

         // make slight changes to the file name
         title = title.Replace( ".jpg", string.Empty );
         title = title.Replace( "pp", "++" );
         title = title.Replace( "sharp", "#" );
         
         // display the title on the page
         return title.ToUpper();
      } // end method GetTitle
   } // end class MainPage
} // end namespace DeepZoomCoverCollage

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
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