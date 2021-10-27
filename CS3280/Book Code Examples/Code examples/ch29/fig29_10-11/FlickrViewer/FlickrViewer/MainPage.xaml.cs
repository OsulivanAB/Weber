// Fig. 29.11: MainPage.xaml.cs
// FlickrViewer allows users to search for photos (code-behind).
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace FlickrViewer
{
   public partial class MainPage : UserControl
   {
      // Flickr API key
      private const string KEY = "YOUR API KEY HERE";

      // object used to invoke Flickr web service
      private WebClient flickr = new WebClient();

      // constructor
      public MainPage()
      {
         InitializeComponent();
         flickr.DownloadStringCompleted += 
            new DownloadStringCompletedEventHandler(
               flickr_DownloadStringCompleted );
      } // end constructor

      // when the photo selection has changed
      private void thumbsListBox_SelectionChanged( object sender,
         SelectionChangedEventArgs e )
      {
         // set the height back to a value so that it can be animated
         largeCoverImage.Height = largeCoverImage.ActualHeight;

         animateOut.Begin(); // begin shrinking animation
      } // end method thumbsListBox_SelectionChanged

      // this makes sure that the border will resize with the window
      private void animateIn_Completed( object sender, EventArgs e )
      {
         largeCoverImage.Height = double.NaN; // image height = *
      } // end method animateIn_Completed

      // once the nested image is no longer visible
      private void animateOut_Completed( object sender, EventArgs e )
      {
         if ( thumbsListBox.SelectedItem != null )
         {
            // grab the URL of the selected item's full image
            string photoURL =
               thumbsListBox.SelectedItem.ToString().Replace(
               "_t.jpg", ".jpg" );

            largeCoverImage.DataContext = photoURL;

            animate.To = imageRow.ActualHeight - 20;
            animateIn.Begin();
         } // end if
      } // end method animateOut_Completed

      // begin the search when the user clicks the search button
      private void searchButton_Click( object sender, RoutedEventArgs e )
      {
         // if network is available, get images
         if ( NetworkInterface.GetIsNetworkAvailable() )
         {
            // Flickr's web service URL for searches
            var flickrURL = string.Format( 
               "http://api.flickr.com/services/rest/?" +
               "method=flickr.photos.search&api_key={0}&tags={1}" +
               "&tag_mode=all&per_page=20&privacy_filter=1", KEY,
               searchBox.Text.Replace( " ", "," ) );

            // invoke the web service
            flickr.DownloadStringAsync( new Uri( flickrURL ) );

            // disable the search button
            searchButton.Content = "Loading...";
            searchButton.IsEnabled = false;

            flipButton(); // start 3D Button rotation animation
         } // end if
         else
            MessageBox.Show( "ERROR: Network not available!" );
      } // end method searchButton_Click

      // once we have received the XML file from Flickr
      private void flickr_DownloadStringCompleted( object sender,
         DownloadStringCompletedEventArgs e )
      {
         searchButton.Content = "Search";
         searchButton.IsEnabled = true;

         if ( e.Error == null )
         {
            // parse the data with LINQ
            XDocument flickrXML = XDocument.Parse( e.Result );

            // gather information on all photos
            var flickrPhotos =
               from photo in flickrXML.Descendants( "photo" )
               let id = photo.Attribute( "id" ).Value
               let secret = photo.Attribute( "secret" ).Value
               let server = photo.Attribute( "server" ).Value
               let farm = photo.Attribute( "farm" ).Value
               select string.Format(
                  "http://farm{0}.static.flickr.com/{1}/{2}_{3}_t.jpg",
                  farm, server, id, secret);

            // set thumbsListBox's item source to the URLs we received
            thumbsListBox.ItemsSource = flickrPhotos;
         } // end if
      } // end method flickr_DownloadStringCompleted

      // perform 3D Button rotation animation
      void flipButton()
      {
         // give all the animations a new goal
         rotX.To = buttonProjection.RotationX + 360;
         rotY.To = buttonProjection.RotationY + 360;
         rotZ.To = buttonProjection.RotationZ + 360;

         buttonRotate.Begin(); // start the animation
      } // end method flipButton
   } // end class MainPage
} // end namespace FlickrViewer

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