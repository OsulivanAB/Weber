// Fig. 29.4: MainPage.xaml.cs
// WeatherViewer displays day-by-day weather data (code-behind).
using System;
using System.Linq;
using System.Net; 
using System.Text.RegularExpressions; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace WeatherViewer
{
   public partial class MainPage : UserControl
   {
      // object to invoke weather forecast web service
      private WebClient weatherService = new WebClient();
      private const string APIKey = "YOUR API KEY HERE";
      private const int messageRowHeight = 35;

      // constructor
      public MainPage()
      {
         InitializeComponent();

         weatherService.DownloadStringCompleted += 
            new DownloadStringCompletedEventHandler( 
               weatherService_DownloadStringCompleted );
      } // end constructor

      // process getWeatherButton's Click event
      private void getWeatherButton_Click(
         object sender, RoutedEventArgs e )
      {
         // make sure the input string contains a five-digit number
         if ( Regex.IsMatch( inputTextBox.Text, @"\d{5}" ) )
         {
            string zipcode =
               Regex.Match( inputTextBox.Text, @"\d{5}" ).ToString();

            // URL to pass to the WebClient to get our weather, complete
            // with API key. OutputType=1 specifies XML data is needed.
            string forecastURL = 
               "http://" + APIKey + ".api.wxbug.net/" +
               "getForecastRSS.aspx?ACode=" + APIKey +
               "&ZipCode=" + zipcode + "&OutputType=1";

            // asynchronously invoke the web service
            weatherService.DownloadStringAsync( new Uri( forecastURL ) );

            // set the cursor to the wait symbol
            this.Cursor = Cursors.Wait;
         } // end if
         else // if input string does not contain a five-digit number,
         {    // output an error message and do nothing else
            messageBlock.Text = "Please enter a valid zipcode.";
            messageRow.Height = new GridLength( messageRowHeight );
            messageBorder.Width = forecastList.ActualWidth;
         } // end else      
      } // end method getWeatherButton_Click

      // when download is complete for web service result
      private void weatherService_DownloadStringCompleted( object sender,
         DownloadStringCompletedEventArgs e )
      {
         if ( e.Error == null )
            DisplayWeatherForecast( e.Result );

         this.Cursor = Cursors.Arrow; // arrow cursor
      } // end method weatherService_DownloadStringCompleted

      // display the received weather data
      private void DisplayWeatherForecast( string xmlData )
      {
         // parse the XML data for use with LINQ
         XDocument weatherXML = XDocument.Parse( xmlData );

         XNamespace weatherNamespace = 
            XNamespace.Get( "http://www.aws.com/aws" );

         // find out if the data describes the same zipcode the user
         // entered and get the location information via LINQ to XML
         var locationInformation =
            from item in weatherXML.Descendants( 
               weatherNamespace + "location" )
            select item;

         string xmlZip = string.Empty;
         string xmlCity = string.Empty;
         string xmlState = string.Empty;

         foreach ( var item in locationInformation )
         {
            xmlZip = item.Element( weatherNamespace + "zip" ).Value;
            xmlCity = item.Element( weatherNamespace + "city" ).Value;
            xmlState = item.Element( weatherNamespace + "state" ).Value;
         } // end for

         // if the zipcodes don't match, display the data anyway,
         // but display a message informing them of it
         if ( !xmlZip.Equals( inputTextBox.Text ) )
         {
            messageBlock.Text = "Zipcode not valid; " +
               "displaying data for closest valid match: " +
               xmlCity + ", " + xmlState + ", " + xmlZip;
            messageRow.Height = new GridLength( messageRowHeight );
            messageBorder.Width = forecastList.ActualWidth;
         } // end if

         // store all the data into WeatherData objects
         var weatherInformation =
            from item in weatherXML.Descendants( 
               weatherNamespace + "forecast" )
            select new WeatherData 
            {
               DayOfWeek = 
                  item.Element( weatherNamespace + "title" ).Value,
               WeatherImage = "http://img.weather.weatherbug.com/" +
                  "forecast/icons/localized/65x55/en/trans/" +
                  ( ( item.Element( weatherNamespace + "image" ).Value).
                     Substring( 51 ).Replace( ".gif", ".png" ) ),
               MaxTemperatureF = 
                  item.Element( weatherNamespace + "high" ).Value,
               MaxTemperatureC = convertToCelsius(
                  item.Element( weatherNamespace + "high" ).Value),
               MinTemperatureF = 
                  item.Element( weatherNamespace + "low" ).Value,
               MinTemperatureC = convertToCelsius(
                  item.Element( weatherNamespace + "low" ).Value),
               Description = 
                  item.Element( weatherNamespace + "prediction" ).Value
            }; // end LINQ to XML that creates WeatherData objects

         // bind forecastList.ItemSource to the weatherInformation
         forecastList.ItemsSource = weatherInformation;
      } // end method DisplayWeatherForecast

      // convert the temperature into Celsius if it's a number;
      // cast as Integer to avoid long decimal values
      string convertToCelsius( string fahrenheit ) 
      {
         if ( fahrenheit != "--" ) 
            return ( ( Int32.Parse( fahrenheit ) - 32) * 
               5 / 9 ).ToString();

         return fahrenheit;
      } // end methodconvertToCelsius

      // show details of the selected day
      private void forecastList_SelectionChanged(
         object sender, SelectionChangedEventArgs e )
      {
         // specify the WeatherData object containing the details
         if ( forecastList.SelectedItem != null )
            completeDetails.DataContext = forecastList.SelectedItem;

         // show the complete weather details
         completeDetails.Visibility = Visibility.Visible;
      } // end method forecastList_SelectionChanged

      // remove displayed weather information when input zip code changes
      private void inputTextBox_TextChanged( object sender, 
         TextChangedEventArgs e )
      {
         forecastList.ItemsSource = null;

         // also clear the message by getting rid of its row
         messageRow.Height = new System.Windows.GridLength( 0 );
      } // end method inputTextBox_TextChanged
   } // end class MainPage
} // end namespace WeatherViewer

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