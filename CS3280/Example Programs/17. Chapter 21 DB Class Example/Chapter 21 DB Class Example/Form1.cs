using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

namespace Chapter_21_DB_Class_Example
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Create an object of type clsDataAccess to access the database
        /// </summary>
        clsDataAccess db = new clsDataAccess();

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdSubmitQuery_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Execute the statement and get the data
                ds = db.ExecuteSQLStatement(txtQuery.Text, ref iRet);

                //Show the data
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables[0].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Number of values affected by the non-query statement
                int iRet = 0;

                //Execute the non-query
                iRet = db.ExecuteNonQuery(txtNonQuery.Text);

                //Show how many rows have been affected
                lblRowsAffected.Text = iRet.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void cmdScalar_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL;		//Holds the SQL statement
                string sFirstName;	//Holds the first name

                //Setup the SQL statement
                sSQL = "SELECT firstname FROM authors WHERE authorid = 2";

                //Retrive the first name
                sFirstName = db.ExecuteScalarSQL(sSQL);

                //Put the first name in the textbox
                txtScalarValue.Text = sFirstName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void cmdFillListBox_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Get all the values from the Authors table
                ds = db.ExecuteSQLStatement("SELECT * FROM authors", ref iRet);

                //Loop through all the values returned
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Add the first and last name to the list box
                    lstNames.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void cmdFillComboBox_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Get all the values from the Authors table
                ds = db.ExecuteSQLStatement("SELECT * FROM authors", ref iRet);

                //Loop through all the values returned
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Add the first and last name to the list box
                    cboNames.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


    }
}