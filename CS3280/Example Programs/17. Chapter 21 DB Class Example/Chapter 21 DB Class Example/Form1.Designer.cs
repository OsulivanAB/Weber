namespace Chapter_21_DB_Class_Example
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.txtNonQuery = new System.Windows.Forms.TextBox();
            this.cmdSubmitQuery = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdScalar = new System.Windows.Forms.Button();
            this.txtScalarValue = new System.Windows.Forms.TextBox();
            this.lstNames = new System.Windows.Forms.ListBox();
            this.cmdFillListBox = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNames = new System.Windows.Forms.ComboBox();
            this.cmdFillComboBox = new System.Windows.Forms.Button();
            this.lblRowsAffected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(526, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 324);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(260, 100);
            this.txtQuery.TabIndex = 1;
            // 
            // txtNonQuery
            // 
            this.txtNonQuery.Location = new System.Drawing.Point(278, 324);
            this.txtNonQuery.Multiline = true;
            this.txtNonQuery.Name = "txtNonQuery";
            this.txtNonQuery.Size = new System.Drawing.Size(260, 100);
            this.txtNonQuery.TabIndex = 2;
            // 
            // cmdSubmitQuery
            // 
            this.cmdSubmitQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubmitQuery.Location = new System.Drawing.Point(88, 430);
            this.cmdSubmitQuery.Name = "cmdSubmitQuery";
            this.cmdSubmitQuery.Size = new System.Drawing.Size(121, 57);
            this.cmdSubmitQuery.TabIndex = 3;
            this.cmdSubmitQuery.Text = "Submit the Query";
            this.cmdSubmitQuery.UseVisualStyleBackColor = true;
            this.cmdSubmitQuery.Click += new System.EventHandler(this.cmdSubmitQuery_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(372, 430);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(121, 57);
            this.cmdUpdate.TabIndex = 4;
            this.cmdUpdate.Text = "Execute Non-Query";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 10);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(558, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 646);
            this.label2.TabIndex = 6;
            // 
            // cmdScalar
            // 
            this.cmdScalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdScalar.Location = new System.Drawing.Point(158, 559);
            this.cmdScalar.Name = "cmdScalar";
            this.cmdScalar.Size = new System.Drawing.Size(185, 39);
            this.cmdScalar.TabIndex = 7;
            this.cmdScalar.Text = "Extract one value";
            this.cmdScalar.UseVisualStyleBackColor = true;
            this.cmdScalar.Click += new System.EventHandler(this.cmdScalar_Click);
            // 
            // txtScalarValue
            // 
            this.txtScalarValue.Location = new System.Drawing.Point(158, 608);
            this.txtScalarValue.Name = "txtScalarValue";
            this.txtScalarValue.Size = new System.Drawing.Size(185, 20);
            this.txtScalarValue.TabIndex = 8;
            // 
            // lstNames
            // 
            this.lstNames.FormattingEnabled = true;
            this.lstNames.Location = new System.Drawing.Point(603, 12);
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(218, 238);
            this.lstNames.TabIndex = 9;
            // 
            // cmdFillListBox
            // 
            this.cmdFillListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFillListBox.Location = new System.Drawing.Point(658, 261);
            this.cmdFillListBox.Name = "cmdFillListBox";
            this.cmdFillListBox.Size = new System.Drawing.Size(121, 57);
            this.cmdFillListBox.TabIndex = 10;
            this.cmdFillListBox.Text = "Fill ListBox";
            this.cmdFillListBox.UseVisualStyleBackColor = true;
            this.cmdFillListBox.Click += new System.EventHandler(this.cmdFillListBox_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(567, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(342, 10);
            this.label3.TabIndex = 11;
            // 
            // cboNames
            // 
            this.cboNames.FormattingEnabled = true;
            this.cboNames.Location = new System.Drawing.Point(631, 361);
            this.cboNames.Name = "cboNames";
            this.cboNames.Size = new System.Drawing.Size(243, 21);
            this.cboNames.TabIndex = 12;
            // 
            // cmdFillComboBox
            // 
            this.cmdFillComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFillComboBox.Location = new System.Drawing.Point(700, 407);
            this.cmdFillComboBox.Name = "cmdFillComboBox";
            this.cmdFillComboBox.Size = new System.Drawing.Size(121, 57);
            this.cmdFillComboBox.TabIndex = 13;
            this.cmdFillComboBox.Text = "Fill Combo Box";
            this.cmdFillComboBox.UseVisualStyleBackColor = true;
            this.cmdFillComboBox.Click += new System.EventHandler(this.cmdFillComboBox_Click);
            // 
            // lblRowsAffected
            // 
            this.lblRowsAffected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowsAffected.Location = new System.Drawing.Point(399, 496);
            this.lblRowsAffected.Name = "lblRowsAffected";
            this.lblRowsAffected.Size = new System.Drawing.Size(72, 23);
            this.lblRowsAffected.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 642);
            this.Controls.Add(this.lblRowsAffected);
            this.Controls.Add(this.cmdFillComboBox);
            this.Controls.Add(this.cboNames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdFillListBox);
            this.Controls.Add(this.lstNames);
            this.Controls.Add(this.txtScalarValue);
            this.Controls.Add(this.cmdScalar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdSubmitQuery);
            this.Controls.Add(this.txtNonQuery);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TextBox txtNonQuery;
        private System.Windows.Forms.Button cmdSubmitQuery;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdScalar;
        private System.Windows.Forms.TextBox txtScalarValue;
        private System.Windows.Forms.ListBox lstNames;
        private System.Windows.Forms.Button cmdFillListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNames;
        private System.Windows.Forms.Button cmdFillComboBox;
        private System.Windows.Forms.Label lblRowsAffected;
    }
}

