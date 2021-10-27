using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PassingDataAround
{
    /// <summary>
    /// Interaction logic for wndEmployeeReport.xaml
    /// </summary>
    public partial class wndEmployeeReport : Window
    {
        /// <summary>
        /// This is an object reference to our employee object manager.  Note that we do not create/instantiate the object here.  This object gets
        /// passed into this class via the property below.  That way we are only using one copy of our list of employees for our whole application.
        /// </summary>
        clsEmployeeObjectManager clsMyEmployeeObjectManager;

        public wndEmployeeReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Property where our employee object manager gets passed in.
        /// </summary>
        public clsEmployeeObjectManager SetMyEmployeeObjectManager
        {
            set
            {
                clsMyEmployeeObjectManager = value;
            }
        }

        /// <summary>
        /// Create the report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateReport_Click(object sender, RoutedEventArgs e)
        {
            txtReport.Text = clsMyEmployeeObjectManager.CreateReportString();
        }

        /// <summary>
        /// Create the report from static data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateStaticReport_Click(object sender, RoutedEventArgs e)
        {
            txtStaticReport.Text = clsEmployeeObjectManager.CreateReportStringForStaticData();
        }
    }
}
