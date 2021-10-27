
namespace Assignment_3
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
            this.groupBox_Counts = new System.Windows.Forms.GroupBox();
            this.button_submit_counts = new System.Windows.Forms.Button();
            this.textBox_count_assignments = new System.Windows.Forms.TextBox();
            this.textBox_count_students = new System.Windows.Forms.TextBox();
            this.label_Count_Assignments = new System.Windows.Forms.Label();
            this.label_Count_Students = new System.Windows.Forms.Label();
            this.button_reset_scores = new System.Windows.Forms.Button();
            this.groupBox_navigate = new System.Windows.Forms.GroupBox();
            this.button_prev_student = new System.Windows.Forms.Button();
            this.button_next_student = new System.Windows.Forms.Button();
            this.button_last_student = new System.Windows.Forms.Button();
            this.button_first_student = new System.Windows.Forms.Button();
            this.groupBox_student_info = new System.Windows.Forms.GroupBox();
            this.button_save_name = new System.Windows.Forms.Button();
            this.textBox_student_info = new System.Windows.Forms.TextBox();
            this.label_student_info = new System.Windows.Forms.Label();
            this.groupBox_assignment_info = new System.Windows.Forms.GroupBox();
            this.button_save_score = new System.Windows.Forms.Button();
            this.textBox_Assignment_info_score = new System.Windows.Forms.TextBox();
            this.textBox_assignment_info_assignment_number = new System.Windows.Forms.TextBox();
            this.label_assignment_info_score = new System.Windows.Forms.Label();
            this.label_assignment_info_assignment_number = new System.Windows.Forms.Label();
            this.button_display_scores = new System.Windows.Forms.Button();
            this.richTextBox_score_display = new System.Windows.Forms.RichTextBox();
            this.label_errors = new System.Windows.Forms.Label();
            this.groupBox_Counts.SuspendLayout();
            this.groupBox_navigate.SuspendLayout();
            this.groupBox_student_info.SuspendLayout();
            this.groupBox_assignment_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Counts
            // 
            this.groupBox_Counts.Controls.Add(this.button_submit_counts);
            this.groupBox_Counts.Controls.Add(this.textBox_count_assignments);
            this.groupBox_Counts.Controls.Add(this.textBox_count_students);
            this.groupBox_Counts.Controls.Add(this.label_Count_Assignments);
            this.groupBox_Counts.Controls.Add(this.label_Count_Students);
            this.groupBox_Counts.Location = new System.Drawing.Point(13, 13);
            this.groupBox_Counts.Name = "groupBox_Counts";
            this.groupBox_Counts.Size = new System.Drawing.Size(413, 100);
            this.groupBox_Counts.TabIndex = 0;
            this.groupBox_Counts.TabStop = false;
            this.groupBox_Counts.Text = "Counts";
            // 
            // button_submit_counts
            // 
            this.button_submit_counts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_submit_counts.Location = new System.Drawing.Point(295, 41);
            this.button_submit_counts.Name = "button_submit_counts";
            this.button_submit_counts.Size = new System.Drawing.Size(101, 29);
            this.button_submit_counts.TabIndex = 5;
            this.button_submit_counts.Text = "Submit Counts";
            this.button_submit_counts.UseVisualStyleBackColor = true;
            this.button_submit_counts.Click += new System.EventHandler(this.button_submit_counts_Click);
            // 
            // textBox_count_assignments
            // 
            this.textBox_count_assignments.Location = new System.Drawing.Point(207, 59);
            this.textBox_count_assignments.Name = "textBox_count_assignments";
            this.textBox_count_assignments.Size = new System.Drawing.Size(72, 20);
            this.textBox_count_assignments.TabIndex = 3;
            this.textBox_count_assignments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_count_students
            // 
            this.textBox_count_students.Location = new System.Drawing.Point(207, 30);
            this.textBox_count_students.Name = "textBox_count_students";
            this.textBox_count_students.Size = new System.Drawing.Size(72, 20);
            this.textBox_count_students.TabIndex = 2;
            this.textBox_count_students.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Count_Assignments
            // 
            this.label_Count_Assignments.AutoSize = true;
            this.label_Count_Assignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Count_Assignments.Location = new System.Drawing.Point(19, 59);
            this.label_Count_Assignments.Name = "label_Count_Assignments";
            this.label_Count_Assignments.Size = new System.Drawing.Size(183, 17);
            this.label_Count_Assignments.TabIndex = 1;
            this.label_Count_Assignments.Text = "Number of assignments:";
            // 
            // label_Count_Students
            // 
            this.label_Count_Students.AutoSize = true;
            this.label_Count_Students.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Count_Students.Location = new System.Drawing.Point(45, 30);
            this.label_Count_Students.Name = "label_Count_Students";
            this.label_Count_Students.Size = new System.Drawing.Size(155, 17);
            this.label_Count_Students.TabIndex = 0;
            this.label_Count_Students.Text = "Number of students:";
            // 
            // button_reset_scores
            // 
            this.button_reset_scores.Enabled = false;
            this.button_reset_scores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reset_scores.Location = new System.Drawing.Point(492, 71);
            this.button_reset_scores.Name = "button_reset_scores";
            this.button_reset_scores.Size = new System.Drawing.Size(95, 42);
            this.button_reset_scores.TabIndex = 4;
            this.button_reset_scores.Text = "Reset Scores";
            this.button_reset_scores.UseVisualStyleBackColor = true;
            this.button_reset_scores.Click += new System.EventHandler(this.button_reset_scores_Click);
            // 
            // groupBox_navigate
            // 
            this.groupBox_navigate.Controls.Add(this.button_prev_student);
            this.groupBox_navigate.Controls.Add(this.button_next_student);
            this.groupBox_navigate.Controls.Add(this.button_last_student);
            this.groupBox_navigate.Controls.Add(this.button_first_student);
            this.groupBox_navigate.Location = new System.Drawing.Point(13, 121);
            this.groupBox_navigate.Name = "groupBox_navigate";
            this.groupBox_navigate.Size = new System.Drawing.Size(574, 62);
            this.groupBox_navigate.TabIndex = 5;
            this.groupBox_navigate.TabStop = false;
            this.groupBox_navigate.Text = "Navigate";
            // 
            // button_prev_student
            // 
            this.button_prev_student.Enabled = false;
            this.button_prev_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_prev_student.Location = new System.Drawing.Point(157, 19);
            this.button_prev_student.Name = "button_prev_student";
            this.button_prev_student.Size = new System.Drawing.Size(114, 29);
            this.button_prev_student.TabIndex = 9;
            this.button_prev_student.Text = "< Prev Student";
            this.button_prev_student.UseVisualStyleBackColor = true;
            this.button_prev_student.Click += new System.EventHandler(this.button_prev_student_Click);
            // 
            // button_next_student
            // 
            this.button_next_student.Enabled = false;
            this.button_next_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_next_student.Location = new System.Drawing.Point(303, 19);
            this.button_next_student.Name = "button_next_student";
            this.button_next_student.Size = new System.Drawing.Size(114, 29);
            this.button_next_student.TabIndex = 8;
            this.button_next_student.Text = "> Next Student";
            this.button_next_student.UseVisualStyleBackColor = true;
            this.button_next_student.Click += new System.EventHandler(this.button_next_student_Click);
            // 
            // button_last_student
            // 
            this.button_last_student.Enabled = false;
            this.button_last_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_last_student.Location = new System.Drawing.Point(449, 19);
            this.button_last_student.Name = "button_last_student";
            this.button_last_student.Size = new System.Drawing.Size(114, 29);
            this.button_last_student.TabIndex = 7;
            this.button_last_student.Text = ">> Last Student";
            this.button_last_student.UseVisualStyleBackColor = true;
            this.button_last_student.Click += new System.EventHandler(this.button_last_student_Click);
            // 
            // button_first_student
            // 
            this.button_first_student.Enabled = false;
            this.button_first_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_first_student.Location = new System.Drawing.Point(11, 19);
            this.button_first_student.Name = "button_first_student";
            this.button_first_student.Size = new System.Drawing.Size(114, 29);
            this.button_first_student.TabIndex = 6;
            this.button_first_student.Text = "<< First Student";
            this.button_first_student.UseVisualStyleBackColor = true;
            this.button_first_student.Click += new System.EventHandler(this.button_first_student_Click);
            // 
            // groupBox_student_info
            // 
            this.groupBox_student_info.Controls.Add(this.button_save_name);
            this.groupBox_student_info.Controls.Add(this.textBox_student_info);
            this.groupBox_student_info.Controls.Add(this.label_student_info);
            this.groupBox_student_info.Location = new System.Drawing.Point(13, 189);
            this.groupBox_student_info.Name = "groupBox_student_info";
            this.groupBox_student_info.Size = new System.Drawing.Size(574, 62);
            this.groupBox_student_info.TabIndex = 6;
            this.groupBox_student_info.TabStop = false;
            this.groupBox_student_info.Text = "Student Info";
            // 
            // button_save_name
            // 
            this.button_save_name.Enabled = false;
            this.button_save_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save_name.Location = new System.Drawing.Point(438, 21);
            this.button_save_name.Name = "button_save_name";
            this.button_save_name.Size = new System.Drawing.Size(101, 29);
            this.button_save_name.TabIndex = 6;
            this.button_save_name.Text = "Save Name";
            this.button_save_name.UseVisualStyleBackColor = true;
            this.button_save_name.Click += new System.EventHandler(this.button_save_name_Click);
            // 
            // textBox_student_info
            // 
            this.textBox_student_info.Enabled = false;
            this.textBox_student_info.Location = new System.Drawing.Point(133, 27);
            this.textBox_student_info.Name = "textBox_student_info";
            this.textBox_student_info.Size = new System.Drawing.Size(263, 20);
            this.textBox_student_info.TabIndex = 2;
            // 
            // label_student_info
            // 
            this.label_student_info.Enabled = false;
            this.label_student_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_student_info.Location = new System.Drawing.Point(9, 27);
            this.label_student_info.Name = "label_student_info";
            this.label_student_info.Size = new System.Drawing.Size(122, 17);
            this.label_student_info.TabIndex = 1;
            this.label_student_info.Text = "Student #:";
            this.label_student_info.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox_assignment_info
            // 
            this.groupBox_assignment_info.Controls.Add(this.button_save_score);
            this.groupBox_assignment_info.Controls.Add(this.textBox_Assignment_info_score);
            this.groupBox_assignment_info.Controls.Add(this.textBox_assignment_info_assignment_number);
            this.groupBox_assignment_info.Controls.Add(this.label_assignment_info_score);
            this.groupBox_assignment_info.Controls.Add(this.label_assignment_info_assignment_number);
            this.groupBox_assignment_info.Location = new System.Drawing.Point(13, 258);
            this.groupBox_assignment_info.Name = "groupBox_assignment_info";
            this.groupBox_assignment_info.Size = new System.Drawing.Size(574, 87);
            this.groupBox_assignment_info.TabIndex = 7;
            this.groupBox_assignment_info.TabStop = false;
            this.groupBox_assignment_info.Text = "Assignment Info";
            // 
            // button_save_score
            // 
            this.button_save_score.Enabled = false;
            this.button_save_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save_score.Location = new System.Drawing.Point(366, 36);
            this.button_save_score.Name = "button_save_score";
            this.button_save_score.Size = new System.Drawing.Size(101, 29);
            this.button_save_score.TabIndex = 8;
            this.button_save_score.Text = "Save Score";
            this.button_save_score.UseVisualStyleBackColor = true;
            this.button_save_score.Click += new System.EventHandler(this.button_save_score_Click);
            // 
            // textBox_Assignment_info_score
            // 
            this.textBox_Assignment_info_score.Enabled = false;
            this.textBox_Assignment_info_score.Location = new System.Drawing.Point(267, 57);
            this.textBox_Assignment_info_score.Name = "textBox_Assignment_info_score";
            this.textBox_Assignment_info_score.Size = new System.Drawing.Size(72, 20);
            this.textBox_Assignment_info_score.TabIndex = 9;
            // 
            // textBox_assignment_info_assignment_number
            // 
            this.textBox_assignment_info_assignment_number.Enabled = false;
            this.textBox_assignment_info_assignment_number.Location = new System.Drawing.Point(267, 25);
            this.textBox_assignment_info_assignment_number.Name = "textBox_assignment_info_assignment_number";
            this.textBox_assignment_info_assignment_number.Size = new System.Drawing.Size(72, 20);
            this.textBox_assignment_info_assignment_number.TabIndex = 8;
            // 
            // label_assignment_info_score
            // 
            this.label_assignment_info_score.AutoSize = true;
            this.label_assignment_info_score.Enabled = false;
            this.label_assignment_info_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_assignment_info_score.Location = new System.Drawing.Point(118, 57);
            this.label_assignment_info_score.Name = "label_assignment_info_score";
            this.label_assignment_info_score.Size = new System.Drawing.Size(143, 17);
            this.label_assignment_info_score.TabIndex = 7;
            this.label_assignment_info_score.Text = "Assignment Score:";
            // 
            // label_assignment_info_assignment_number
            // 
            this.label_assignment_info_assignment_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_assignment_info_assignment_number.Enabled = false;
            this.label_assignment_info_assignment_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_assignment_info_assignment_number.Location = new System.Drawing.Point(6, 25);
            this.label_assignment_info_assignment_number.Name = "label_assignment_info_assignment_number";
            this.label_assignment_info_assignment_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_assignment_info_assignment_number.Size = new System.Drawing.Size(253, 20);
            this.label_assignment_info_assignment_number.TabIndex = 6;
            this.label_assignment_info_assignment_number.Text = "Enter Assignment Number ():";
            this.label_assignment_info_assignment_number.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button_display_scores
            // 
            this.button_display_scores.Enabled = false;
            this.button_display_scores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_display_scores.Location = new System.Drawing.Point(294, 351);
            this.button_display_scores.Name = "button_display_scores";
            this.button_display_scores.Size = new System.Drawing.Size(101, 29);
            this.button_display_scores.TabIndex = 10;
            this.button_display_scores.Text = "Display Scores";
            this.button_display_scores.UseVisualStyleBackColor = true;
            this.button_display_scores.Click += new System.EventHandler(this.button_display_scores_Click);
            // 
            // richTextBox_score_display
            // 
            this.richTextBox_score_display.Enabled = false;
            this.richTextBox_score_display.Location = new System.Drawing.Point(12, 389);
            this.richTextBox_score_display.Name = "richTextBox_score_display";
            this.richTextBox_score_display.Size = new System.Drawing.Size(665, 170);
            this.richTextBox_score_display.TabIndex = 11;
            this.richTextBox_score_display.Text = "";
            this.richTextBox_score_display.WordWrap = false;
            // 
            // label_errors
            // 
            this.label_errors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_errors.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_errors.Location = new System.Drawing.Point(451, 24);
            this.label_errors.Name = "label_errors";
            this.label_errors.Size = new System.Drawing.Size(226, 39);
            this.label_errors.TabIndex = 12;
            this.label_errors.Text = "Error Error Error";
            this.label_errors.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 571);
            this.Controls.Add(this.label_errors);
            this.Controls.Add(this.richTextBox_score_display);
            this.Controls.Add(this.button_display_scores);
            this.Controls.Add(this.groupBox_assignment_info);
            this.Controls.Add(this.groupBox_student_info);
            this.Controls.Add(this.groupBox_navigate);
            this.Controls.Add(this.button_reset_scores);
            this.Controls.Add(this.groupBox_Counts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Counts.ResumeLayout(false);
            this.groupBox_Counts.PerformLayout();
            this.groupBox_navigate.ResumeLayout(false);
            this.groupBox_student_info.ResumeLayout(false);
            this.groupBox_student_info.PerformLayout();
            this.groupBox_assignment_info.ResumeLayout(false);
            this.groupBox_assignment_info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Counts;
        private System.Windows.Forms.Button button_submit_counts;
        private System.Windows.Forms.TextBox textBox_count_assignments;
        private System.Windows.Forms.TextBox textBox_count_students;
        private System.Windows.Forms.Label label_Count_Assignments;
        private System.Windows.Forms.Label label_Count_Students;
        private System.Windows.Forms.Button button_reset_scores;
        private System.Windows.Forms.GroupBox groupBox_navigate;
        private System.Windows.Forms.Button button_prev_student;
        private System.Windows.Forms.Button button_next_student;
        private System.Windows.Forms.Button button_last_student;
        private System.Windows.Forms.Button button_first_student;
        private System.Windows.Forms.GroupBox groupBox_student_info;
        private System.Windows.Forms.Button button_save_name;
        private System.Windows.Forms.TextBox textBox_student_info;
        private System.Windows.Forms.Label label_student_info;
        private System.Windows.Forms.GroupBox groupBox_assignment_info;
        private System.Windows.Forms.TextBox textBox_Assignment_info_score;
        private System.Windows.Forms.TextBox textBox_assignment_info_assignment_number;
        private System.Windows.Forms.Label label_assignment_info_score;
        private System.Windows.Forms.Label label_assignment_info_assignment_number;
        private System.Windows.Forms.Button button_save_score;
        private System.Windows.Forms.Button button_display_scores;
        private System.Windows.Forms.RichTextBox richTextBox_score_display;
        private System.Windows.Forms.Label label_errors;
    }
}

