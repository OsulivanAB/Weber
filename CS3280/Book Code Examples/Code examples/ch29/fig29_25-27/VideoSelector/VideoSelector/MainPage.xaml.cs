// Fig. 29.26: MainPage.xaml.cs
// VideoSelector lets users watch several videos (code-behind).
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace VideoSelector
{
   public partial class MainPage : UserControl
   {
      private MediaElement currentVideo = new MediaElement();

      // constructor
      public MainPage()
      {
         InitializeComponent();

         // sources.xml contains the sources for all the videos
         XDocument sources = XDocument.Load( "sources.xml" );

         // LINQ to XML to create new MediaElements
         var videos =
            from video in sources.Descendants( "video" )
            where video.Element( "uri" ).Value != string.Empty
            select new MediaElement()
            {
               Source = new Uri( video.Element( "uri" ).Value,
                  UriKind.Relative ),
               Width = 150,
               Margin = new Thickness( 10 ),
               IsMuted = true
            };

         // send all videos to the ListBox
         previewListBox.ItemsSource = videos;
      } // end constructor

      // when the user makes a new selection
      private void previewListBox_SelectionChanged( object sender, 
         SelectionChangedEventArgs e )
      {
         fadeOut.Begin(); // begin fade out animation
      } // end method previewListBox_SelectionChanged

      // change the video if there is a new selection
      private void fadeOut_Completed( object sender, EventArgs e )
      {
         // if there is a selection
         if ( previewListBox.SelectedItem != null )
         {
            // grab the new video to be played
            MediaElement newVideo = 
               ( MediaElement ) previewListBox.SelectedItem;

            // if new video has finished playing, restart it
            if ( newVideo.CurrentState == MediaElementState.Paused )
            {
               newVideo.Stop();
               newVideo.Play();
            } // end if

            currentVideo.IsMuted = true; // mute the old video
            newVideo.IsMuted = false; // play audio for main video

            currentVideo = newVideo; // set the currently playing video
            brush.SetSource( newVideo ); // set source of video brush
         } // end if

         fadeIn.Begin(); // begin fade in animation
      } // end method fadeOut_Completed
   } // end class MainPage
} // end namespace VideoSelector

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