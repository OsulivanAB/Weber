namespace Chapter_14_15_Visual_Controls
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmdRemoveSelectedItem = new System.Windows.Forms.Button();
            this.cmdShowSelectedItems = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemToAdd = new System.Windows.Forms.TextBox();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.lblShowSelectedItems = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelectedIndex = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.cmdAddRootNode = new System.Windows.Forms.Button();
            this.cmdAddChildNode = new System.Windows.Forms.Button();
            this.txtAddRootNode = new System.Windows.Forms.TextBox();
            this.txtAddChildNode = new System.Windows.Forms.TextBox();
            this.cboItems = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelectedItem = new System.Windows.Forms.Label();
            this.cboObjects = new System.Windows.Forms.ComboBox();
            this.cmdAddItemsFromObjects = new System.Windows.Forms.Button();
            this.cmdShowSelectedItem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShowKeyFromItem = new System.Windows.Forms.Label();
            this.cmdAddItemsFromList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 212);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cmdRemoveSelectedItem
            // 
            this.cmdRemoveSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveSelectedItem.Location = new System.Drawing.Point(238, 12);
            this.cmdRemoveSelectedItem.Name = "cmdRemoveSelectedItem";
            this.cmdRemoveSelectedItem.Size = new System.Drawing.Size(133, 63);
            this.cmdRemoveSelectedItem.TabIndex = 1;
            this.cmdRemoveSelectedItem.Text = "Remove Selected Item";
            this.cmdRemoveSelectedItem.UseVisualStyleBackColor = true;
            this.cmdRemoveSelectedItem.Click += new System.EventHandler(this.cmdRemoveSelectedItem_Click);
            // 
            // cmdShowSelectedItems
            // 
            this.cmdShowSelectedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowSelectedItems.Location = new System.Drawing.Point(408, 12);
            this.cmdShowSelectedItems.Name = "cmdShowSelectedItems";
            this.cmdShowSelectedItems.Size = new System.Drawing.Size(133, 63);
            this.cmdShowSelectedItems.TabIndex = 2;
            this.cmdShowSelectedItems.Text = "Show Selected Items";
            this.cmdShowSelectedItems.UseVisualStyleBackColor = true;
            this.cmdShowSelectedItems.Click += new System.EventHandler(this.cmdShowSelectedItems_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Item to add:";
            // 
            // txtItemToAdd
            // 
            this.txtItemToAdd.Location = new System.Drawing.Point(111, 247);
            this.txtItemToAdd.Name = "txtItemToAdd";
            this.txtItemToAdd.Size = new System.Drawing.Size(168, 20);
            this.txtItemToAdd.TabIndex = 4;
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddItem.Location = new System.Drawing.Point(285, 235);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(90, 40);
            this.cmdAddItem.TabIndex = 5;
            this.cmdAddItem.Text = "Add Item";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // lblShowSelectedItems
            // 
            this.lblShowSelectedItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShowSelectedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowSelectedItems.Location = new System.Drawing.Point(404, 78);
            this.lblShowSelectedItems.Name = "lblShowSelectedItems";
            this.lblShowSelectedItems.Size = new System.Drawing.Size(164, 212);
            this.lblShowSelectedItems.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selected Index:";
            // 
            // lblSelectedIndex
            // 
            this.lblSelectedIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedIndex.Location = new System.Drawing.Point(152, 295);
            this.lblSelectedIndex.Name = "lblSelectedIndex";
            this.lblSelectedIndex.Size = new System.Drawing.Size(134, 20);
            this.lblSelectedIndex.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1112, 10);
            this.label5.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(574, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 649);
            this.label6.TabIndex = 10;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(594, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(275, 212);
            this.treeView1.TabIndex = 11;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(884, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Selected Node:";
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedNode.Location = new System.Drawing.Point(884, 43);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(162, 20);
            this.lblSelectedNode.TabIndex = 13;
            // 
            // cmdAddRootNode
            // 
            this.cmdAddRootNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddRootNode.Location = new System.Drawing.Point(594, 271);
            this.cmdAddRootNode.Name = "cmdAddRootNode";
            this.cmdAddRootNode.Size = new System.Drawing.Size(133, 32);
            this.cmdAddRootNode.TabIndex = 14;
            this.cmdAddRootNode.Text = "Add Root Node";
            this.cmdAddRootNode.UseVisualStyleBackColor = true;
            this.cmdAddRootNode.Click += new System.EventHandler(this.cmdAddRootNode_Click);
            // 
            // cmdAddChildNode
            // 
            this.cmdAddChildNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddChildNode.Location = new System.Drawing.Point(736, 271);
            this.cmdAddChildNode.Name = "cmdAddChildNode";
            this.cmdAddChildNode.Size = new System.Drawing.Size(133, 32);
            this.cmdAddChildNode.TabIndex = 15;
            this.cmdAddChildNode.Text = "Add Child Node";
            this.cmdAddChildNode.UseVisualStyleBackColor = true;
            this.cmdAddChildNode.Click += new System.EventHandler(this.cmdAddChildNode_Click);
            // 
            // txtAddRootNode
            // 
            this.txtAddRootNode.Location = new System.Drawing.Point(594, 235);
            this.txtAddRootNode.Name = "txtAddRootNode";
            this.txtAddRootNode.Size = new System.Drawing.Size(133, 20);
            this.txtAddRootNode.TabIndex = 16;
            // 
            // txtAddChildNode
            // 
            this.txtAddChildNode.Location = new System.Drawing.Point(736, 235);
            this.txtAddChildNode.Name = "txtAddChildNode";
            this.txtAddChildNode.Size = new System.Drawing.Size(133, 20);
            this.txtAddChildNode.TabIndex = 17;
            // 
            // cboItems
            // 
            this.cboItems.FormattingEnabled = true;
            this.cboItems.Location = new System.Drawing.Point(16, 356);
            this.cboItems.Name = "cboItems";
            this.cboItems.Size = new System.Drawing.Size(191, 21);
            this.cboItems.TabIndex = 18;
            this.cboItems.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(238, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 40);
            this.button1.TabIndex = 19;
            this.button1.Text = "Add Some Items";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Selected Item:";
            // 
            // lblSelectedItem
            // 
            this.lblSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedItem.Location = new System.Drawing.Point(145, 431);
            this.lblSelectedItem.Name = "lblSelectedItem";
            this.lblSelectedItem.Size = new System.Drawing.Size(134, 20);
            this.lblSelectedItem.TabIndex = 21;
            // 
            // cboObjects
            // 
            this.cboObjects.FormattingEnabled = true;
            this.cboObjects.Location = new System.Drawing.Point(624, 363);
            this.cboObjects.Name = "cboObjects";
            this.cboObjects.Size = new System.Drawing.Size(191, 21);
            this.cboObjects.TabIndex = 22;
            // 
            // cmdAddItemsFromObjects
            // 
            this.cmdAddItemsFromObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddItemsFromObjects.Location = new System.Drawing.Point(844, 356);
            this.cmdAddItemsFromObjects.Name = "cmdAddItemsFromObjects";
            this.cmdAddItemsFromObjects.Size = new System.Drawing.Size(152, 50);
            this.cmdAddItemsFromObjects.TabIndex = 23;
            this.cmdAddItemsFromObjects.Text = "Add Items from Objects";
            this.cmdAddItemsFromObjects.UseVisualStyleBackColor = true;
            this.cmdAddItemsFromObjects.Click += new System.EventHandler(this.cmdAddItemsFromObjects_Click);
            // 
            // cmdShowSelectedItem
            // 
            this.cmdShowSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowSelectedItem.Location = new System.Drawing.Point(624, 468);
            this.cmdShowSelectedItem.Name = "cmdShowSelectedItem";
            this.cmdShowSelectedItem.Size = new System.Drawing.Size(152, 50);
            this.cmdShowSelectedItem.TabIndex = 24;
            this.cmdShowSelectedItem.Text = "Show Selected Item";
            this.cmdShowSelectedItem.UseVisualStyleBackColor = true;
            this.cmdShowSelectedItem.Click += new System.EventHandler(this.cmdShowSelectedItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(620, 541);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Show Key from Item:";
            // 
            // lblShowKeyFromItem
            // 
            this.lblShowKeyFromItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowKeyFromItem.Location = new System.Drawing.Point(800, 541);
            this.lblShowKeyFromItem.Name = "lblShowKeyFromItem";
            this.lblShowKeyFromItem.Size = new System.Drawing.Size(162, 20);
            this.lblShowKeyFromItem.TabIndex = 26;
            // 
            // cmdAddItemsFromList
            // 
            this.cmdAddItemsFromList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddItemsFromList.Location = new System.Drawing.Point(844, 416);
            this.cmdAddItemsFromList.Name = "cmdAddItemsFromList";
            this.cmdAddItemsFromList.Size = new System.Drawing.Size(152, 50);
            this.cmdAddItemsFromList.TabIndex = 27;
            this.cmdAddItemsFromList.Text = "Add Items from List";
            this.cmdAddItemsFromList.UseVisualStyleBackColor = true;
            this.cmdAddItemsFromList.Click += new System.EventHandler(this.cmdAddItemsFromList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 650);
            this.Controls.Add(this.cmdAddItemsFromList);
            this.Controls.Add(this.lblShowKeyFromItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdShowSelectedItem);
            this.Controls.Add(this.cmdAddItemsFromObjects);
            this.Controls.Add(this.cboObjects);
            this.Controls.Add(this.lblSelectedItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboItems);
            this.Controls.Add(this.txtAddChildNode);
            this.Controls.Add(this.txtAddRootNode);
            this.Controls.Add(this.cmdAddChildNode);
            this.Controls.Add(this.cmdAddRootNode);
            this.Controls.Add(this.lblSelectedNode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSelectedIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblShowSelectedItems);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.txtItemToAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdShowSelectedItems);
            this.Controls.Add(this.cmdRemoveSelectedItem);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button cmdRemoveSelectedItem;
        private System.Windows.Forms.Button cmdShowSelectedItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemToAdd;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.Label lblShowSelectedItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelectedIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSelectedNode;
        private System.Windows.Forms.Button cmdAddRootNode;
        private System.Windows.Forms.Button cmdAddChildNode;
        private System.Windows.Forms.TextBox txtAddRootNode;
        private System.Windows.Forms.TextBox txtAddChildNode;
        private System.Windows.Forms.ComboBox cboItems;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelectedItem;
        private System.Windows.Forms.ComboBox cboObjects;
        private System.Windows.Forms.Button cmdAddItemsFromObjects;
        private System.Windows.Forms.Button cmdShowSelectedItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblShowKeyFromItem;
        private System.Windows.Forms.Button cmdAddItemsFromList;
    }
}

