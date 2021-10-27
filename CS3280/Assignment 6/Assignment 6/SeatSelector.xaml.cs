using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_6
{
    /// <summary>
    /// Interaction logic for SeatSelector.xaml
    /// </summary>
    public partial class SeatSelector : UserControl
    {
        /// <summary>
        /// Seating format for a Boeing_767
        /// </summary>
        private List<bool[]> Boeing_767 = new List<bool[]>
            {
            new bool[] {true,true,false,true,true},
            new bool[] { },
            new bool[] {true,true,false,true,true},
            new bool[] {true,true,false,true,true},
            new bool[] {true,true,false,true,true},
            new bool[] {true,true,false,true,true},
            new bool[] {true,true,false,true,true},
            };
        /// <summary>
        /// Seating format for a Boeing_767
        /// </summary>
        private List<bool[]> Airbus_A380 = new List<bool[]>
        {
            new bool[] {true,true,false,true,true},
            new bool[] { },
            new bool[] {true,true,false,true,true},
            new bool[] {true,true,false,true,true},
            new bool[] {true,true,false,true,true},
        };
        /// <summary>
        /// Dictionary to hold aircraft configurations
        /// </summary>
        Dictionary<string, List<bool[]>> aircraftStyles;
        /// <summary>
        /// Variable to hold a reference to the current flight
        /// </summary>
        clsFlight currentFlight;
        /// <summary>
        /// Variable to hold a reference to the current passenger
        /// </summary>
        clsPassenger currentPassenger;
        /// <summary>
        /// Create event for when a seat is changed
        /// </summary>
        public event MouseButtonEventHandler seatChanged;

        public SeatSelector()
        {
            try
            {
                InitializeComponent();
                aircraftStyles = new Dictionary<string, List<bool[]>>();
                aircraftStyles.Add("Boeing 767", Boeing_767);
                aircraftStyles.Add("Airbus A380", Airbus_A380);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Formats the User Control to the settings passed in.
        /// </summary>
        /// <param name="myFlight">clsFlight object of the selected flight.</param>
        internal void FormatSeating(clsFlight myFlight)
        {
            try
            {
                // Create Fake Passenger
                clsPassenger fakePassenger = new clsPassenger(-1, -1, "Fake", "Passenger", "abc");
                // Call function and pass in the fake passenger as the selected passenger
                FormatSeating(myFlight, fakePassenger, false);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Formats the User Control to the settings passed in.
        /// </summary>
        /// <param name="myFlight">clsFlight object of the selected flight.</param>
        /// <param name="selectedPassenger">clsPassenger object of the slected passenger</param>
        internal void FormatSeating(clsFlight myFlight, clsPassenger selectedPassenger)
        {
            FormatSeating(myFlight, selectedPassenger, false);
        }
        /// <summary>
        /// Formats the User Control to the settings passed in.
        /// </summary>
        /// <param name="myFlight">clsFlight object of the selected flight.</param>
        /// <param name="selectedPassenger">clsPassenger object of the slected passenger</param>
        /// <param name="isChangeSeat">true if you're doing a seat change</param>
        internal void FormatSeating(clsFlight myFlight, clsPassenger selectedPassenger, bool isChangeSeat)
        {
            try
            {
                // set current variables
                currentFlight = myFlight;
                currentPassenger = selectedPassenger;

                // Update header to aircraft name
                this.tblkFlightNumber.Text = myFlight.sAircraftType;

                // variable to hold the seating arrangement
                List<bool[]> seatingChart = new List<bool[]>();

                // Get the seating layout
                aircraftStyles.TryGetValue(myFlight.sAircraftType, out seatingChart);

                /// Clear out the contents of the grid currently
                ClearGrid();

                // Create Counter to keep track of seat numbers
                int counter = 1;

                /// Loop through list of rows
                for (int i = 0; i < seatingChart.Count; i++)
                {
                    // Create new row definition
                    this.MainGrid.RowDefinitions.Add(new RowDefinition());

                    // Create new Grid to serve as the row
                    Grid newGrid = new Grid();
                    newGrid.Style = (Style)this.Resources["RowGrid"];
                    this.MainGrid.Children.Add(newGrid);
                    Grid.SetRow(newGrid, i);

                    if (seatingChart[i].Length == 0)
                    {
                        Separator newSep = new Separator();
                        newGrid.Children.Add(newSep);
                    }

                    for (int j = 0; j < seatingChart[i].Length; j++)
                    {
                        newGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        switch (seatingChart[i][j])
                        {

                            /// Create new Seat
                            case true:
                                // Create Label
                                Label newLabel = new Label();

                                // Selected passengers seat
                                if (selectedPassenger.SeatNumber == counter.ToString())
                                {
                                    newLabel.Style = (Style)this.Resources["SelectedSeat"];
                                    if (isChangeSeat)
                                    {
                                        newLabel.MouseLeftButtonDown += seatChange_MouseLeftButtonDown;
                                    }
                                }
                                // Occuppied Seat
                                else if (myFlight.lstPassengers.Where(p => p.SeatNumber == counter.ToString()).Count() > 0)
                                {
                                    newLabel.Style = (Style)this.Resources["TakenSeat"];
                                }
                                // Empty Seat
                                else
                                {
                                    newLabel.Style = (Style)this.Resources["EmptySeat"];
                                    if (isChangeSeat)
                                    {
                                        newLabel.MouseLeftButtonDown += seatChange_MouseLeftButtonDown;
                                    }
                                }
                                newLabel.Tag = counter.ToString();
                                newLabel.Content = counter.ToString();
                                newGrid.Children.Add(newLabel);
                                Grid.SetColumn(newLabel, j);
                                counter++;
                                break;
                            case false:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Clears the current contents of the view
        /// </summary>
        private void ClearGrid()
        {
            try
            {
                this.MainGrid.Children.Clear();
                this.MainGrid.RowDefinitions.Clear();
                this.MainGrid.ColumnDefinitions.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Performs seat change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seatChange_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Creates a variable to hold the label that was clicked
                Label chosenSeat = (Label)sender;
                // Update the passengers seat
                currentPassenger.SeatNumber = chosenSeat.Tag.ToString();
                if (seatChanged == null) return;
                seatChanged(sender, e);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
