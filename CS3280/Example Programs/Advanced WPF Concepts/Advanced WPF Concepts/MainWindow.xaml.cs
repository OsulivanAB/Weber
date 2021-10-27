using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.ObjectModel; //Must be added to use ObservableCollection
using System.ComponentModel;          //Must be added for interface INotifyPropertyChanged

namespace Advanced_WPF_Concepts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// An ObservableCollection to hold clsPerson objects.  An ObservableCollection is a list that 
        /// provides notifications when items get added, removed, or the whole list is refreshed.
        /// http://msdn.microsoft.com/en-us/library/ms668604.aspx
        /// </summary>
        ObservableCollection<clsPerson1> lstPeople1;

        /// <summary>
        /// An ObservableCollection to hold clsPerson objects.  An ObservableCollection is a list that 
        /// provides notifications when items get added, removed, or the whole list is refreshed.
        /// http://msdn.microsoft.com/en-us/library/ms668604.aspx
        /// </summary>
        ObservableCollection<clsPerson1> lstPeople2;

        /// <summary>
        /// List of people that also has a list of companies.
        /// </summary>
        ObservableCollection<clsPerson2> lstPeople3;

        /// <summary>
        /// An ObservableCollection to hold clsPerson2 objects. 
        /// </summary>
        ObservableCollection<clsPerson3> lstPeople4;

        

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowBinding_Loaded(object sender, RoutedEventArgs e)
        {
            //Create some data in the list
            lstPeople1 = new ObservableCollection<clsPerson1> { new clsPerson1 
                                                                  { sName = "Person 1", sJobTitle = "Engineer", sJobLevel = "2", sNumberOfYearsWithCompany = "6"},
                                                                new clsPerson1 
                                                                  { sName = "Person 2", sJobTitle = "Teacher", sJobLevel = "3", sNumberOfYearsWithCompany = "4"},
                                                                new clsPerson1 
                                                                  { sName = "Person 3", sJobTitle = "Mechanic", sJobLevel = "4", sNumberOfYearsWithCompany = "1"}};

            //Create some data in the list
            lstPeople2 = new ObservableCollection<clsPerson1> { new clsPerson1 
                                                                  { sName = "Person 1", sJobTitle = "Engineer", sJobLevel = "2", sNumberOfYearsWithCompany = "6"},
                                                              new clsPerson1 
                                                                  { sName = "Person 2", sJobTitle = "Teacher", sJobLevel = "3", sNumberOfYearsWithCompany = "4"},
                                                              new clsPerson1 
                                                                  { sName = "Person 3", sJobTitle = "Mechanic", sJobLevel = "4", sNumberOfYearsWithCompany = "1"}};

            //Create some data in the list
            lstPeople3 = new ObservableCollection<clsPerson2> { new clsPerson2
                                                                  { sName = "Person 1", sJobTitle = "Engineer", sJobLevel = "2", sNumberOfYearsWithCompany = "6"},
                                                                new clsPerson2 
                                                                  { sName = "Person 2", sJobTitle = "Teacher", sJobLevel = "3", sNumberOfYearsWithCompany = "4"},
                                                                new clsPerson2 
                                                                  { sName = "Person 3", sJobTitle = "Mechanic", sJobLevel = "4", sNumberOfYearsWithCompany = "1"}};

            //Create some data in the list
            lstPeople4 = new ObservableCollection<clsPerson3> { new clsPerson3 
                                                                  { Name = "Person 4", JobTitle = "Professor", JobLevel = "2", NumberOfYearsWithCompany = "8"},
                                                                new clsPerson3 
                                                                  { Name = "Person 5", JobTitle = "Sales", JobLevel = "3", NumberOfYearsWithCompany = "12"},
                                                                new clsPerson3 
                                                                  { Name = "Person 6", JobTitle = "Tech", JobLevel = "4", NumberOfYearsWithCompany = "15"}};

            

            //Bind the ListBoxes to the ObservableCollection
            listBoxIncorrect.ItemsSource = lstPeople1;
            listBoxCorrect.ItemsSource = lstPeople1;

            //Bind the DataGrids to the ObservableCollections
            dgDefaultDataGrid.ItemsSource = lstPeople2;
            dgCustomColumns.ItemsSource = lstPeople2;
            dgRowDetailsTemplate.ItemsSource = lstPeople3;
            dgINotify.ItemsSource = lstPeople4;
            
        }

        /// <summary>
        /// Update some data in the DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUpdateData_Click(object sender, RoutedEventArgs e)
        {
            //When these properties are set the PropertyChanged event is raised.  This tells the DataGrid to update the display.
            lstPeople4[0].Name = "New Name";
            lstPeople4[0].JobTitle = "New Job Title";

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            lstPeople2[0].sName = "hello";
        }
    }

    /// <summary>
    /// A person class used to display people information.  This class will be stored in a collection.
    /// </summary>
    public class clsPerson1
    {
        public string sName { get; set; }
        public string sJobTitle { get; set; }
        public string sJobLevel { get; set; }
        public string sNumberOfYearsWithCompany { get; set; }

        /// <summary>
        /// The Tostring method has been overridden to show that this is the default method that is called when controls are bound to collections.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "clsPerson -> Shows ToString Method for person: " + sName;
        }
    }

    /// <summary>
    /// This person class also holds a collection a companies.  This collection will be used as the details row view.
    /// </summary>
    public class clsPerson2
    {
        public string sName { get; set; }
        public string sJobTitle { get; set; }
        public string sJobLevel { get; set; }
        public string sNumberOfYearsWithCompany { get; set; }

        /// <summary>
        /// A list of companies
        /// </summary>
        private List<clsCompany> lstCompanies = new List<clsCompany>();

        /// <summary>
        /// Property to get the companies.
        /// </summary>
        public List<clsCompany> Companies
        {
            get { return lstCompanies; }
            set { lstCompanies = value; }
        }

        /// <summary>
        /// Constructor that sets some companies.
        /// </summary>
        public clsPerson2()
        {
            lstCompanies.Add(new clsCompany { sCompanyName = "Company 1", sContact = "Contact 1", sPhone = "555-555-5555" });
            lstCompanies.Add(new clsCompany { sCompanyName = "Company 2", sContact = "Contact 2", sPhone = "555-555-5555" });
            lstCompanies.Add(new clsCompany { sCompanyName = "Company 3", sContact = "Contact 3", sPhone = "555-555-5555" });
        }
    }

    /// <summary>
    /// Class used to hold company information.
    /// </summary>
    public class clsCompany
    {
        public string sCompanyName { get; set; }
        public string sContact { get; set; }
        public string sPhone { get; set; }
    }

    /// <summary>
    /// A person class used to display people information.  This class implements the interface INotifyPropertyChanged.
    /// This is done so that if data in one of our classes changes the DataGrid can be notified of the change.
    /// </summary>
    public class clsPerson3 : INotifyPropertyChanged
    {
        private string sName;
        private string sJobTitle;
        private string sJobLevel;
        private string sNumberOfYearsWithCompany;

        /// <summary>
        /// Each of the properties set raises the event PropertyChanged.  This tells the DataGrid that data has changed.
        /// </summary>
        public string Name
        {
            get
            {
                return sName;
            }

            set
            {
                sName = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public string JobTitle
        {
            get
            {
                return sJobTitle;
            }

            set
            {
                sJobTitle = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("JobTitle"));
                }
            }
        }

        public string JobLevel
        {
            get
            {
                return sJobLevel;
            }

            set
            {
                sJobLevel = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("JobLevel"));
                }
            }
        }

        public string NumberOfYearsWithCompany
        {
            get
            {
                return sNumberOfYearsWithCompany;
            }

            set
            {
                sNumberOfYearsWithCompany = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NumberOfYearsWithCompany"));
                }
            }
        }

        /// <summary>
        /// This is the contract you make with the compiler because we are implementing the interface so
        /// we must have this event defined.  We will raise this event anytime one of our properties changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }

   
}
