
namespace Assignment_2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_numTimesLost_data = new System.Windows.Forms.Label();
            this.label_numTimesPlayed_data = new System.Windows.Forms.Label();
            this.label_numTimesWon_data = new System.Windows.Forms.Label();
            this.label_numTimesLost = new System.Windows.Forms.Label();
            this.label_numTimesWon = new System.Windows.Forms.Label();
            this.label_numTimesPlayed = new System.Windows.Forms.Label();
            this.Prompt = new System.Windows.Forms.Label();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btn_Roll = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.richTextBox_results = new System.Windows.Forms.RichTextBox();
            this.label_error = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_numTimesLost_data);
            this.groupBox1.Controls.Add(this.label_numTimesPlayed_data);
            this.groupBox1.Controls.Add(this.label_numTimesWon_data);
            this.groupBox1.Controls.Add(this.label_numTimesLost);
            this.groupBox1.Controls.Add(this.label_numTimesWon);
            this.groupBox1.Controls.Add(this.label_numTimesPlayed);
            this.groupBox1.Location = new System.Drawing.Point(9, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Info";
            // 
            // label_numTimesLost_data
            // 
            this.label_numTimesLost_data.AutoSize = true;
            this.label_numTimesLost_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numTimesLost_data.Location = new System.Drawing.Point(158, 82);
            this.label_numTimesLost_data.Name = "label_numTimesLost_data";
            this.label_numTimesLost_data.Size = new System.Drawing.Size(14, 13);
            this.label_numTimesLost_data.TabIndex = 5;
            this.label_numTimesLost_data.Text = "0";
            // 
            // label_numTimesPlayed_data
            // 
            this.label_numTimesPlayed_data.AutoSize = true;
            this.label_numTimesPlayed_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numTimesPlayed_data.Location = new System.Drawing.Point(158, 30);
            this.label_numTimesPlayed_data.Name = "label_numTimesPlayed_data";
            this.label_numTimesPlayed_data.Size = new System.Drawing.Size(14, 13);
            this.label_numTimesPlayed_data.TabIndex = 3;
            this.label_numTimesPlayed_data.Text = "0";
            // 
            // label_numTimesWon_data
            // 
            this.label_numTimesWon_data.AutoSize = true;
            this.label_numTimesWon_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numTimesWon_data.Location = new System.Drawing.Point(158, 56);
            this.label_numTimesWon_data.Name = "label_numTimesWon_data";
            this.label_numTimesWon_data.Size = new System.Drawing.Size(14, 13);
            this.label_numTimesWon_data.TabIndex = 4;
            this.label_numTimesWon_data.Text = "0";
            // 
            // label_numTimesLost
            // 
            this.label_numTimesLost.AutoSize = true;
            this.label_numTimesLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numTimesLost.Location = new System.Drawing.Point(6, 82);
            this.label_numTimesLost.Name = "label_numTimesLost";
            this.label_numTimesLost.Size = new System.Drawing.Size(134, 13);
            this.label_numTimesLost.TabIndex = 2;
            this.label_numTimesLost.Text = "Number of Times Lost:";
            // 
            // label_numTimesWon
            // 
            this.label_numTimesWon.AutoSize = true;
            this.label_numTimesWon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numTimesWon.Location = new System.Drawing.Point(6, 56);
            this.label_numTimesWon.Name = "label_numTimesWon";
            this.label_numTimesWon.Size = new System.Drawing.Size(136, 13);
            this.label_numTimesWon.TabIndex = 1;
            this.label_numTimesWon.Text = "Number of Times Won:";
            // 
            // label_numTimesPlayed
            // 
            this.label_numTimesPlayed.AutoSize = true;
            this.label_numTimesPlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numTimesPlayed.Location = new System.Drawing.Point(6, 30);
            this.label_numTimesPlayed.Name = "label_numTimesPlayed";
            this.label_numTimesPlayed.Size = new System.Drawing.Size(148, 13);
            this.label_numTimesPlayed.TabIndex = 0;
            this.label_numTimesPlayed.Text = "Number of Times Played:";
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prompt.Location = new System.Drawing.Point(6, 155);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(136, 13);
            this.Prompt.TabIndex = 6;
            this.Prompt.Text = "Enter your guess (1-6):";
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Location = new System.Drawing.Point(148, 152);
            this.textBoxGuess.MaxLength = 1;
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(33, 20);
            this.textBoxGuess.TabIndex = 7;
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(18, 187);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(105, 105);
            this.pbImage.TabIndex = 8;
            this.pbImage.TabStop = false;
            // 
            // btn_Roll
            // 
            this.btn_Roll.Location = new System.Drawing.Point(134, 218);
            this.btn_Roll.Name = "btn_Roll";
            this.btn_Roll.Size = new System.Drawing.Size(75, 23);
            this.btn_Roll.TabIndex = 9;
            this.btn_Roll.Text = "Roll";
            this.btn_Roll.UseVisualStyleBackColor = true;
            this.btn_Roll.Click += new System.EventHandler(this.btn_Roll_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(134, 262);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 10;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // richTextBox_results
            // 
            this.richTextBox_results.Location = new System.Drawing.Point(9, 318);
            this.richTextBox_results.Name = "richTextBox_results";
            this.richTextBox_results.Size = new System.Drawing.Size(410, 123);
            this.richTextBox_results.TabIndex = 11;
            this.richTextBox_results.SelectionTabs = new int[] { 10, 80, 155, 290 };
            this.richTextBox_results.Text = "";
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.BackColor = System.Drawing.SystemColors.Control;
            this.label_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_error.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_error.Location = new System.Drawing.Point(196, 155);
            this.label_error.MaximumSize = new System.Drawing.Size(235, 0);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(233, 26);
            this.label_error.TabIndex = 12;
            this.label_error.Text = "Error: Guess must be a number between 1-6";
            this.label_error.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 458);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.richTextBox_results);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_Roll);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.textBoxGuess);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_numTimesPlayed;
        private System.Windows.Forms.Label label_numTimesLost_data;
        private System.Windows.Forms.Label label_numTimesPlayed_data;
        private System.Windows.Forms.Label label_numTimesWon_data;
        private System.Windows.Forms.Label label_numTimesLost;
        private System.Windows.Forms.Label label_numTimesWon;
        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btn_Roll;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.RichTextBox richTextBox_results;
        private System.Windows.Forms.Label label_error;
    }
}

