namespace TicTacVisualElements
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
            this.lblSpace1 = new System.Windows.Forms.Label();
            this.lblSpace2 = new System.Windows.Forms.Label();
            this.lblSpace4 = new System.Windows.Forms.Label();
            this.lblSpace3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSpace1
            // 
            this.lblSpace1.BackColor = System.Drawing.Color.White;
            this.lblSpace1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace1.Location = new System.Drawing.Point(34, 27);
            this.lblSpace1.Name = "lblSpace1";
            this.lblSpace1.Size = new System.Drawing.Size(144, 127);
            this.lblSpace1.TabIndex = 0;
            this.lblSpace1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpace1.Click += new System.EventHandler(this.lblSpace_Click);
            // 
            // lblSpace2
            // 
            this.lblSpace2.BackColor = System.Drawing.Color.White;
            this.lblSpace2.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace2.Location = new System.Drawing.Point(208, 27);
            this.lblSpace2.Name = "lblSpace2";
            this.lblSpace2.Size = new System.Drawing.Size(144, 127);
            this.lblSpace2.TabIndex = 0;
            this.lblSpace2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpace2.Click += new System.EventHandler(this.lblSpace_Click);
            // 
            // lblSpace4
            // 
            this.lblSpace4.BackColor = System.Drawing.Color.White;
            this.lblSpace4.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace4.Location = new System.Drawing.Point(208, 176);
            this.lblSpace4.Name = "lblSpace4";
            this.lblSpace4.Size = new System.Drawing.Size(144, 127);
            this.lblSpace4.TabIndex = 2;
            this.lblSpace4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpace4.Click += new System.EventHandler(this.lblSpace_Click);
            // 
            // lblSpace3
            // 
            this.lblSpace3.BackColor = System.Drawing.Color.White;
            this.lblSpace3.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace3.Location = new System.Drawing.Point(34, 176);
            this.lblSpace3.Name = "lblSpace3";
            this.lblSpace3.Size = new System.Drawing.Size(144, 127);
            this.lblSpace3.TabIndex = 1;
            this.lblSpace3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpace3.Click += new System.EventHandler(this.lblSpace_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(183, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 276);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 21);
            this.label2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 336);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSpace4);
            this.Controls.Add(this.lblSpace3);
            this.Controls.Add(this.lblSpace2);
            this.Controls.Add(this.lblSpace1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSpace1;
        private System.Windows.Forms.Label lblSpace2;
        private System.Windows.Forms.Label lblSpace4;
        private System.Windows.Forms.Label lblSpace3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

