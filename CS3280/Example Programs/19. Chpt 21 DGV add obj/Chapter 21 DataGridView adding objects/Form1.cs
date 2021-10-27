using System.ComponentModel;
using System.Windows.Forms;

namespace Chapter_21_DataGridView_adding_objects
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Use the BindingList class instead of the List class when you are going to bind data to a DataGridView.  The BindingList
        /// class allows for communication between it and the DataGridView.  This communication allows items to be added or removed
        /// from the BindingList or DataGridView.
        /// </summary>
        BindingList<Employee> lstEmployees = new BindingList<Employee>();

        public Form1()
        {
            InitializeComponent();

            //Create 4 columns to be displayed in the DataGridView
            DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewButtonColumn Column4 = new System.Windows.Forms.DataGridViewButtonColumn();

            //Set the properties of the columns.
            //Note the property "DataPropertyName".  
            //The value of this property corresponds to the name of the property in the class Employee.  
            //This binds this column to that field in the class.

            Column1.DataPropertyName = "ID";
            Column1.HeaderText = "Employee ID";
            Column1.Name = "EmployeeID";

            Column2.DataPropertyName = "FirstName";
            Column2.HeaderText = "First Name";
            Column2.Name = "FirstName";
            Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

            Column3.DataPropertyName = "LastName";
            Column3.HeaderText = "Last Name";
            Column3.Name = "LastName";

            Column4.HeaderText = "Delete Employee";
            Column4.Name = "DeleteEmployee";
            Column4.Text = "Delete the Employee";
            Column4.UseColumnTextForButtonValue = true;
            Column4.Width = 200;

            //Add the columns to the DataGridView
            dataGridView1.Columns.Add(Column1);
            dataGridView1.Columns.Add(Column2);
            dataGridView1.Columns.Add(Column3);
            dataGridView1.Columns.Add(Column4);

            //Create three employee objects and set their data
            Employee emp1 = new Employee();
            emp1.ID = 123;
            emp1.FirstName = "Shawn";
            emp1.LastName = "Cowder";

            Employee emp2 = new Employee();
            emp2.ID = 456;
            emp2.FirstName = "Melissa";
            emp2.LastName = "Cowder";

            Employee emp3 = new Employee();
            emp3.ID = 789;
            emp3.FirstName = "John";
            emp3.LastName = "Smith";

            //Add the employee objects to the BindingList
            lstEmployees.Add(emp1);
            lstEmployees.Add(emp2);
            lstEmployees.Add(emp3);

            //Don't generate columns automatically
            dataGridView1.AutoGenerateColumns = false;

            //Set the DataSource for the DataGridView
            dataGridView1.DataSource = lstEmployees;
        }

        /// <summary>
        /// This method handles the CellClick event for the DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Extract the employee that corresponds to the row that was clicked
            Employee emp = (Employee)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            //Make sure there is an employee
            if (emp != null)
            {
                //Determine if the "Delete" button was clicked
                if (e.ColumnIndex == dataGridView1.Columns["DeleteEmployee"].Index)
                {
                    //Remove the employee from the list
                    lstEmployees.Remove(emp);
                    //or
                    //dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                }
                else
                {
                    //A row was selected so display the employee's information
                    lblID.Text = emp.ID.ToString();
                    lblFirstName.Text = emp.FirstName;
                    lblLastName.Text = emp.LastName;
                }
            }
        }
    }

    /// <summary>
    /// Class used to hold Employee data
    /// </summary>
    public class Employee
    {
        private int iID;
        private string sFirstName;
        private string sLastName;

        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }

        public string FirstName
        {
            get { return sFirstName; }
            set { sFirstName = value; }
        }

        public string LastName
        {
            get { return sLastName; }
            set { sLastName = value; }
        }
    }
}

