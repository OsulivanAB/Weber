namespace Chpt_21_DB_and_Add_Object_Combobox
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboPassengers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSeat = new System.Windows.Forms.Label();
            this.pnlSeats = new System.Windows.Forms.Panel();
            this.lblSeat4 = new System.Windows.Forms.Label();
            this.lblSeat3 = new System.Windows.Forms.Label();
            this.lblSeat2 = new System.Windows.Forms.Label();
            this.lblSeat1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSeats.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. When you select a passenger from the combo box their seat will turn green";
            // 
            // cboPassengers
            // 
            this.cboPassengers.FormattingEnabled = true;
            this.cboPassengers.Location = new System.Drawing.Point(161, 89);
            this.cboPassengers.Name = "cboPassengers";
            this.cboPassengers.Size = new System.Drawing.Size(294, 21);
            this.cboPassengers.TabIndex = 1;
            this.cboPassengers.SelectedIndexChanged += new System.EventHandler(this.cboPassengers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seat:";
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat.Location = new System.Drawing.Point(224, 128);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(0, 20);
            this.lblSeat.TabIndex = 3;
            // 
            // pnlSeats
            // 
            this.pnlSeats.Controls.Add(this.lblSeat4);
            this.pnlSeats.Controls.Add(this.lblSeat3);
            this.pnlSeats.Controls.Add(this.lblSeat2);
            this.pnlSeats.Controls.Add(this.lblSeat1);
            this.pnlSeats.Location = new System.Drawing.Point(165, 169);
            this.pnlSeats.Name = "pnlSeats";
            this.pnlSeats.Size = new System.Drawing.Size(266, 226);
            this.pnlSeats.TabIndex = 4;
            // 
            // lblSeat4
            // 
            this.lblSeat4.BackColor = System.Drawing.Color.Red;
            this.lblSeat4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeat4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat4.Location = new System.Drawing.Point(159, 121);
            this.lblSeat4.Name = "lblSeat4";
            this.lblSeat4.Size = new System.Drawing.Size(89, 80);
            this.lblSeat4.TabIndex = 7;
            this.lblSeat4.Text = "4";
            this.lblSeat4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeat4.Click += new System.EventHandler(this.Seat_Click);
            // 
            // lblSeat3
            // 
            this.lblSeat3.BackColor = System.Drawing.Color.Blue;
            this.lblSeat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeat3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat3.Location = new System.Drawing.Point(22, 121);
            this.lblSeat3.Name = "lblSeat3";
            this.lblSeat3.Size = new System.Drawing.Size(89, 80);
            this.lblSeat3.TabIndex = 6;
            this.lblSeat3.Text = "3";
            this.lblSeat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeat3.Click += new System.EventHandler(this.Seat_Click);
            // 
            // lblSeat2
            // 
            this.lblSeat2.BackColor = System.Drawing.Color.Blue;
            this.lblSeat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat2.Location = new System.Drawing.Point(159, 27);
            this.lblSeat2.Name = "lblSeat2";
            this.lblSeat2.Size = new System.Drawing.Size(89, 80);
            this.lblSeat2.TabIndex = 5;
            this.lblSeat2.Text = "2";
            this.lblSeat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeat2.Click += new System.EventHandler(this.Seat_Click);
            // 
            // lblSeat1
            // 
            this.lblSeat1.BackColor = System.Drawing.Color.Blue;
            this.lblSeat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat1.Location = new System.Drawing.Point(22, 27);
            this.lblSeat1.Name = "lblSeat1";
            this.lblSeat1.Size = new System.Drawing.Size(89, 80);
            this.lblSeat1.TabIndex = 4;
            this.lblSeat1.Text = "1";
            this.lblSeat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeat1.Click += new System.EventHandler(this.Seat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(522, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "2. The red seat is taken, so if you click on it, you will select that passenger";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 454);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlSeats);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPassengers);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlSeats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPassengers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.Panel pnlSeats;
        private System.Windows.Forms.Label lblSeat4;
        private System.Windows.Forms.Label lblSeat3;
        private System.Windows.Forms.Label lblSeat2;
        private System.Windows.Forms.Label lblSeat1;
        private System.Windows.Forms.Label label4;
    }
}

