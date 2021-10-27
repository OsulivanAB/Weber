using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chapter_14_15_Visual_Controls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add the item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            //Add the item
            listBox1.Items.Add(txtItemToAdd.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelectedIndex.Text = "";

            //For single selected only
            lblSelectedIndex.Text = listBox1.SelectedIndex.ToString();

            /////Make sure to comment out one or the other//////////

            //For multiple selected items
            //ListBox.SelectedIndexCollection indexes = listBox1.SelectedIndices;

            //for (int i = 0; i < indexes.Count; i++)
            //{
            //    lblSelectedIndex.Text += indexes[i].ToString() + "   ";
            //}
        }

        private void cmdRemoveSelectedItem_Click(object sender, EventArgs e)
        {
            //Single Selection Only
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void cmdShowSelectedItems_Click(object sender, EventArgs e)
        {
            lblShowSelectedItems.Text = "";

            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                lblShowSelectedItems.Text += "\n" + listBox1.SelectedItems[i].ToString();
            }

            //OR

            //foreach (string MyItem in listBox1.SelectedItems)
            //{
            //    lblShowSelectedItems.Text += "\n" + MyItem;
            //}

            //OR

            //ListBox.SelectedObjectCollection SelectedItems = listBox1.SelectedItems;
            //for (int i = 0; i < SelectedItems.Count; i++)
            //{
            //    lblShowSelectedItems.Text += "\n" + SelectedItems[i].ToString();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Common mistake not to do this
            cboItems.Items.Clear();

            //Add the items to the combo box
            cboItems.Items.Add("A");
            cboItems.Items.Add("B");
            cboItems.Items.Add("C");
            cboItems.Items.Add("D");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected item
            lblSelectedItem.Text = cboItems.SelectedItem.ToString();
        }

        private void cmdAddRootNode_Click(object sender, EventArgs e)
        {
            //Create the node
            TreeNode MyNode = new TreeNode();
            MyNode.Text = txtAddRootNode.Text;

            //Add the root node
            treeView1.Nodes.Add(MyNode);
        }

        private void cmdAddChildNode_Click(object sender, EventArgs e)
        {
            //Create the child node
            TreeNode MyNode = new TreeNode(txtAddChildNode.Text);

            if (treeView1.SelectedNode != null)
            {
                //Add a child node to the selected Root Node
                treeView1.SelectedNode.Nodes.Add(MyNode);

                //Expand the node
                treeView1.SelectedNode.Expand();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Get the selected node
            TreeNode MyTreeNode = treeView1.SelectedNode;

            //Display the selected node
            lblSelectedNode.Text = MyTreeNode.Text;
        }

        private void cmdAddItemsFromObjects_Click(object sender, EventArgs e)
        {
            //Create 3 users
            clsUser clsUser1 = new clsUser("1", "Shawn", "Cowder");
            clsUser clsUser2 = new clsUser("2", "Mike", "Hoskins");
            clsUser clsUser3 = new clsUser("3", "Melissa", "Cowder");

            //Add the objects to the combo box
            cboObjects.Items.Add(clsUser1);
            cboObjects.Items.Add(clsUser2);
            cboObjects.Items.Add(clsUser3);
        }

        private void cmdShowSelectedItem_Click(object sender, EventArgs e)
        {
            //Create a user reference
            clsUser clsSelectedUser;

            //Get the user object out of the combo box
            clsSelectedUser = (clsUser)cboObjects.SelectedItem;

            if (clsSelectedUser != null)
            {
                //Display the User ID
                lblShowKeyFromItem.Text = clsSelectedUser.ID;
            }
        }

        /// <summary>
        /// This is a data binding example.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddItemsFromList_Click(object sender, EventArgs e)
        {
            //Create the generic list of clsUser
            List<clsUser> lstUsers = new List<clsUser>();
            
            //Create 3 users
            clsUser clsUser1 = new clsUser("1", "Shawn", "Cowder");
            clsUser clsUser2 = new clsUser("2", "Mike", "Hoskins");
            clsUser clsUser3 = new clsUser("3", "Melissa", "Cowder");

            //Add clsUser objects to the list
            lstUsers.Add(clsUser1);
            lstUsers.Add(clsUser2);
            lstUsers.Add(clsUser3);

            //Set the DataSource.  The DataSource is where the combobox should get its data from.  By default the combobox
            //will call the "ToString" method to display the data.  That is why we overrode it.
            cboObjects.DataSource = lstUsers;

            //Uncomment and you will see that we can set the text to display to a property from the class.
            //cboObjects.DisplayMember = "DisplayText";

        }
    }
}