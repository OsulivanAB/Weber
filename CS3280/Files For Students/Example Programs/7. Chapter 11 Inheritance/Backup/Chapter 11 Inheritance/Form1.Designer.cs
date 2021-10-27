namespace Chapter_11_Inheritance
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
            this.cmdCreateCar = new System.Windows.Forms.Button();
            this.lblCreateCar = new System.Windows.Forms.Label();
            this.cmdStop = new System.Windows.Forms.Button();
            this.lblStop = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCreateCar
            // 
            this.cmdCreateCar.Location = new System.Drawing.Point(213, 363);
            this.cmdCreateCar.Name = "cmdCreateCar";
            this.cmdCreateCar.Size = new System.Drawing.Size(75, 23);
            this.cmdCreateCar.TabIndex = 11;
            this.cmdCreateCar.Text = "Create Car";
            this.cmdCreateCar.UseVisualStyleBackColor = true;
            this.cmdCreateCar.Click += new System.EventHandler(this.cmdCreateCar_Click);
            // 
            // lblCreateCar
            // 
            this.lblCreateCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCar.Location = new System.Drawing.Point(141, 219);
            this.lblCreateCar.Name = "lblCreateCar";
            this.lblCreateCar.Size = new System.Drawing.Size(232, 136);
            this.lblCreateCar.TabIndex = 10;
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(333, 131);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 9;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // lblStop
            // 
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(269, 51);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(216, 64);
            this.lblStop.TabIndex = 8;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(109, 131);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 7;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(37, 51);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(208, 64);
            this.lblStart.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 436);
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

        private System.Windows.Forms.Button cmdCreateCar;
        private System.Windows.Forms.Label lblCreateCar;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label lblStart;
    }
}

