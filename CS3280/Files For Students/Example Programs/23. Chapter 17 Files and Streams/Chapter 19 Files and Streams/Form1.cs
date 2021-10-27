using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//Have to add for IO
using System.IO;

namespace Chapter_19_Files_and_Streams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Used to read data from a file
        /// </summary>
        StreamReader MyStream;

        /// <summary>
        /// Read all of the data from the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReadAllData_Click(object sender, EventArgs e)
        {
            string sFile = txtFilePath.Text;
            string sAllFileData;

            //Make sure the file exists
            if (File.Exists(sFile))
            {
                //Create a stream reader and pass in the file
                using(StreamReader FileRead = new StreamReader(sFile))
                {
                    //Read to the end of the file
                    sAllFileData = FileRead.ReadToEnd();

                    //Add the data to the textbox
                    txtFileData.Text = sAllFileData;

                    //Don't need to call "Close" because we use the "using" statement
                    //The "using" statement is the same as a try/catch block and putting the "FileRead.Dispose" method call in the "finally" statment
                    //FileRead.Close();
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }

        /// <summary>
        /// Open a file for reading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOpenFile_Click(object sender, EventArgs e)
        {
            //Get the file name
            string sFile = txtFilePath.Text;

            //Make sure file exists
            if (File.Exists(sFile))
            {
                //Create the stream reader to get the text
                MyStream = File.OpenText(sFile);
                //or
                //MyStream = new StreamReader(sFile);

                cmdReadNextLine.Enabled = true;
                cmdOpenFile.Enabled = false;
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }

        /// <summary>
        /// Read the next line of the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReadNextLine_Click(object sender, EventArgs e)
        {
            string sLine;

            //Read the next line in the file
            sLine = MyStream.ReadLine();

            //Make sure the line is not null
            if (sLine == null)
            {
                //No more data
                MessageBox.Show("At the end of the file, closing file");
                MyStream.Close();
                cmdReadNextLine.Enabled = false;
                cmdOpenFile.Enabled = true;
            }
            else
            {
                //Add the line to the textbox
                txtFileData.Text += Environment.NewLine + sLine;
            }
        }

        /// <summary>
        /// Create a file and write all of the data in the textbox to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateFile_Click(object sender, EventArgs e)
        {
            string sFile = @"C:\" + txtFileName.Text;

            //Make sure the file exists
            if (File.Exists(sFile))
            {
                MessageBox.Show("This file already exist");
            }
            else
            {
                //Create the stream writer

                //StreamWriter MyWriter = File.CreateText(sFile);
                //or
                using (StreamWriter MyWriter = new StreamWriter(sFile))
                {

                    //Write the data to the file
                    MyWriter.Write(txtFileData.Text);
                }
            }
        }

        /// <summary>
        /// Append the data to the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAppend_Click(object sender, EventArgs e)
        {
            string sFile = txtFilePath.Text;

            //Make sure the file exists
            if (File.Exists(sFile))
            {
                using (StreamWriter MyWriter = File.AppendText(sFile))
                {
                    //or
                    //StreamWriter MyWriter = new StreamWriter(sFile,true);

                    MyWriter.WriteLine("");
                    MyWriter.Write(txtFileData.Text);
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }
    }
}