namespace Chapter_12_Polymorphism
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
            this.cmdPoly = new System.Windows.Forms.Button();
            this.lblPoly = new System.Windows.Forms.Label();
            this.cmdCreateCar = new System.Windows.Forms.Button();
            this.lblCreateCar = new System.Windows.Forms.Label();
            this.cmdStop = new System.Windows.Forms.Button();
            this.lblStop = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdPoly
            // 
            this.cmdPoly.Location = new System.Drawing.Point(424, 348);
            this.cmdPoly.Name = "cmdPoly";
            this.cmdPoly.Size = new System.Drawing.Size(80, 23);
            this.cmdPoly.TabIndex = 15;
            this.cmdPoly.Text = "Polymorphism";
            this.cmdPoly.UseVisualStyleBackColor = true;
            this.cmdPoly.Click += new System.EventHandler(this.cmdPoly_Click);
            // 
            // lblPoly
            // 
            this.lblPoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoly.Location = new System.Drawing.Point(352, 196);
            this.lblPoly.Name = "lblPoly";
            this.lblPoly.Size = new System.Drawing.Size(232, 136);
            this.lblPoly.TabIndex = 14;
            // 
            // cmdCreateCar
            // 
            this.cmdCreateCar.Location = new System.Drawing.Point(152, 348);
            this.cmdCreateCar.Name = "cmdCreateCar";
            this.cmdCreateCar.Size = new System.Drawing.Size(75, 23);
            this.cmdCreateCar.TabIndex = 13;
            this.cmdCreateCar.Text = "Create Car";
            this.cmdCreateCar.UseVisualStyleBackColor = true;
            this.cmdCreateCar.Click += new System.EventHandler(this.cmdCreateCar_Click);
            // 
            // lblCreateCar
            // 
            this.lblCreateCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCar.Location = new System.Drawing.Point(64, 196);
            this.lblCreateCar.Name = "lblCreateCar";
            this.lblCreateCar.Size = new System.Drawing.Size(232, 136);
            this.lblCreateCar.TabIndex = 12;
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(360, 116);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 11;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // lblStop
            // 
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(296, 36);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(216, 64);
            this.lblStop.TabIndex = 10;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(136, 116);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 9;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(64, 36);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(208, 64);
            this.lblStart.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 424);
            this.Controls.Add(this.cmdPoly);
            this.Controls.Add(this.lblPoly);
            this.Controls.Add(this.cmdCreateCar);
            this.Controls.Add(this.lblCreateCar);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.lblStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPoly;
        private System.Windows.Forms.Label lblPoly;
        private System.Windows.Forms.Button cmdCreateCar;
        private System.Windows.Forms.Label lblCreateCar;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label lblStart;
    }
}

