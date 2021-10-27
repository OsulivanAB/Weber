namespace Chapter_19_Files_and_Streams
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
            this.cmdReadAllData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOpenFile = new System.Windows.Forms.Button();
            this.cmdReadNextLine = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCreateFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdAppend = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFileData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cmdReadAllData
            // 
            this.cmdReadAllData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReadAllData.Location = new System.Drawing.Point(21, 25);
            this.cmdReadAllData.Name = "cmdReadAllData";
            this.cmdReadAllData.Size = new System.Drawing.Size(145, 49);
            this.cmdReadAllData.TabIndex = 0;
            this.cmdReadAllData.Text = "Read all data from file";
            this.cmdReadAllData.UseVisualStyleBackColor = true;
            this.cmdReadAllData.Click += new System.EventHandler(this.cmdReadAllData_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(181, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 117);
            this.label1.TabIndex = 1;
            // 
            // cmdOpenFile
            // 
            this.cmdOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenFile.Location = new System.Drawing.Point(214, 25);
            this.cmdOpenFile.Name = "cmdOpenFile";
            this.cmdOpenFile.Size = new System.Drawing.Size(145, 49);
            this.cmdOpenFile.TabIndex = 2;
            this.cmdOpenFile.Text = "Open File for reading";
            this.cmdOpenFile.UseVisualStyleBackColor = true;
            this.cmdOpenFile.Click += new System.EventHandler(this.cmdOpenFile_Click);
            // 
            // cmdReadNextLine
            // 
            this.cmdReadNextLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReadNextLine.Location = new System.Drawing.Point(214, 93);
            this.cmdReadNextLine.Name = "cmdReadNextLine";
            this.cmdReadNextLine.Size = new System.Drawing.Size(145, 49);
            this.cmdReadNextLine.TabIndex = 3;
            this.cmdReadNextLine.Text = "Read next line in file";
            this.cmdReadNextLine.UseVisualStyleBackColor = true;
            this.cmdReadNextLine.Click += new System.EventHandler(this.cmdReadNextLine_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter the path of the file:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(234, 169);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(180, 26);
            this.txtFilePath.TabIndex = 5;
            this.txtFilePath.Text = "c:\\TextFile1.txt";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(436, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 167);
            this.label3.TabIndex = 6;
            // 
            // cmdCreateFile
            // 
            this.cmdCreateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCreateFile.Location = new System.Drawing.Point(520, 65);
            this.cmdCreateFile.Name = "cmdCreateFile";
            this.cmdCreateFile.Size = new System.Drawing.Size(145, 49);
            this.cmdCreateFile.TabIndex = 7;
            this.cmdCreateFile.Text = "Create a file with text below";
            this.cmdCreateFile.UseVisualStyleBackColor = true;
            this.cmdCreateFile.Click += new System.EventHandler(this.cmdCreateFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(487, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "File will be created at C:\\";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(557, 160);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(170, 26);
            this.txtFileName.TabIndex = 10;
            this.txtFileName.Text = "TextFile2.txt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(457, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "File Name:";
            // 
            // cmdAppend
            // 
            this.cmdAppend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAppend.Location = new System.Drawing.Point(777, 65);
            this.cmdAppend.Name = "cmdAppend";
            this.cmdAppend.Size = new System.Drawing.Size(145, 49);
            this.cmdAppend.TabIndex = 11;
            this.cmdAppend.Text = "Append text to file";
            this.cmdAppend.UseVisualStyleBackColor = true;
            this.cmdAppend.Click += new System.EventHandler(this.cmdAppend_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(788, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 44);
            this.label6.TabIndex = 12;
            this.label6.Text = "Uses path entered at left";
            // 
            // txtFileData
            // 
            this.txtFileData.Location = new System.Drawing.Point(12, 212);
            this.txtFileData.Name = "txtFileData";
            this.txtFileData.Size = new System.Drawing.Size(952, 546);
            this.txtFileData.TabIndex = 13;
            this.txtFileData.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 770);
            this.Controls.Add(this.txtFileData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdAppend);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdCreateFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdReadNextLine);
            this.Controls.Add(this.cmdOpenFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdReadAllData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdReadAllData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOpenFile;
        private System.Windows.Forms.Button cmdReadNextLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCreateFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdAppend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtFileData;
    }
}

