using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Chapter_21_DataGrid_Example
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Used to access the database
        /// </summary>
        clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// Holds the info from the database
        /// </summary>
        DataSet ds;

        /// <summary>
        /// Tells if the user is deleting a row.
        /// </summary>
        bool IsDeleting = false;

        public Form1()
        {
            try
            {
                InitializeComponent();

                //Number of return values
                int iRet = 0;
                //Get the data to be put into the DataGridView
                ds = db.ExecuteSQLStatement("Select AuthorID, firstname, lastname from Authors", ref iRet);
                //Set the table name in the DataSet
                ds.Tables[0].TableName = "Authors";
                //Bind the DataSet to the DataGridView
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables[0].TableName;
                //Select the first row of the DataGridView
                dataGridView1.Rows[0].Selected = true;

                //Don't allow sorting except for on column 2
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                //Hide the first column
                dataGridView1.Columns[0].Visible = false;

                //Change the header text of the second and third column
                dataGridView1.Columns[1].HeaderText = "First Name";
                dataGridView1.Columns[2].HeaderText = "Last Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// The current cell has changed.  This can be called by the user selecting a new row, or the user deleting a row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                //Make sure the current row is not null
                if (dataGridView1.CurrentRow != null)
                {
                    
                    //Check to see if the user is deleting a row
                    if (IsDeleting == false)
                    {
                        //Gives the current cell's row number
                        int iRowNum = dataGridView1.CurrentCell.RowIndex;
                        //or
                        iRowNum = dataGridView1.CurrentRow.Index;

                        //Make sure a valid row is selected
                        if (iRowNum < ds.Tables[0].Rows.Count)
                        {
                            //Put the highlighted row's data in the textboxes
                            txtUpdateFirstName.Text = ds.Tables[0].Rows[iRowNum][1].ToString();
                            txtUpdateLastName.Text = ds.Tables[0].Rows[iRowNum].ItemArray[2].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update the DataSet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Get the first and last name
                string first = txtUpdateFirstName.Text;
                string second = txtUpdateLastName.Text;

                //NOTE: The statement: 
                //ds.Tables[0].Rows[dataGridView1.CurrentRow.Index].ItemArray[1] = first;
                //Will not work.  It must be accessed with the brackets.

                //Update the DataSet with the new values
                ds.Tables[0].Rows[dataGridView1.CurrentRow.Index][1] = first;
                ds.Tables[0].Rows[dataGridView1.CurrentRow.Index][2] = second;

                //Accept the changes to the DataSet so it will show up in the DataGridView
                ds.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Add a new row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                //Get the first and last name
                string first = txtAddFirstName.Text;
                string second = txtAddLastName.Text;

                //Create a new DataRow from the DataSet
                DataRow DR = ds.Tables[0].NewRow();

                //This value needs to be a unique value
                DR[0] = Convert.ToString((ds.Tables[0].Rows.Count + 1));

                //Add the first and last names to the DataSet
                DR[1] = first;
                DR[2] = second;

                //Add the DataRow to the DataSet at the current row index
                ds.Tables[0].Rows.InsertAt(DR, dataGridView1.CurrentRow.Index);

                //This would add to the end
                //ds.Tables[0].Rows.Add(DR);

                //Accept the changes to the DataSet so it will show up in the DataGridView
                ds.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete a row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Make sure the current row is not null
                if (dataGridView1.CurrentRow != null)
                {
                    //Gives the current cell's row number
                    int iRowNum = dataGridView1.CurrentCell.RowIndex;
                    //or
                    iRowNum = dataGridView1.CurrentRow.Index;

                    //The user is deleting
                    IsDeleting = true;

                    //Delete the row
                    ds.Tables[0].Rows[iRowNum].Delete();

                    //Accept the changes to the DataSet so it will show up in the DataGridView
                    ds.AcceptChanges();

                    //Delete was successful
                    IsDeleting = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        
    }
}