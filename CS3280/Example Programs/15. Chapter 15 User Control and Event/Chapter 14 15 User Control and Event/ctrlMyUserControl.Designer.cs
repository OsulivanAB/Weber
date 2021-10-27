namespace Chapter_14_15_User_Control_and_Event
{
    partial class ctrlMyUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblSeat1 = new System.Windows.Forms.Label();
            this.lblSeat2 = new System.Windows.Forms.Label();
            this.lblSeat3 = new System.Windows.Forms.Label();
            this.cmdRaiseButtonEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "My User Control";
            // 
            // lblSeat1
            // 
            this.lblSeat1.BackColor = System.Drawing.Color.Blue;
            this.lblSeat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat1.Location = new System.Drawing.Point(40, 69);
            this.lblSeat1.Name = "lblSeat1";
            this.lblSeat1.Size = new System.Drawing.Size(66, 59);
            this.lblSeat1.TabIndex = 1;
            this.lblSeat1.Tag = "1";
            this.lblSeat1.Text = "1";
            this.lblSeat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeat1.Click += new System.EventHandler(this.Seat_Click);
            // 
            // lblSeat2
            // 
            this.lblSeat2.BackColor = System.Drawing.Color.Red;
            this.lblSeat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat2.Location = new System.Drawing.Point(142, 69);
            this.lblSeat2.Name = "lblSeat2";
            this.lblSeat2.Size = new System.Drawing.Size(66, 59);
            this.lblSeat2.TabIndex = 2;
            this.lblSeat2.Tag = "2";
            this.lblSeat2.Text = "2";
            this.lblSeat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeat2.Click += new System.EventHandler(this.Seat_Click);
            // 
            // lblSeat3
            // 
            this.lblSeat3.BackColor = System.Drawing.Color.Lime;
            this.lblSeat3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeat3.Location = new System.Drawing.Point(244, 69);
            this.lblSeat3.Name = "lblSeat3";
            this.lblSeat3.Size = new System.Drawing.Size(66, 59);
            this.lblSeat3.TabIndex = 3;
            this.lblSeat3.Tag = "3";
            this.lblSeat3.Text = "3";
            this.lblSeat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeat3.Click += new System.EventHandler(this.Seat_Click);
            // 
            // cmdRaiseButtonEvent
            // 
            this.cmdRaiseButtonEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRaiseButtonEvent.Location = new System.Drawing.Point(97, 171);
            this.cmdRaiseButtonEvent.Name = "cmdRaiseButtonEvent";
            this.cmdRaiseButtonEvent.Size = new System.Drawing.Size(150, 58);
            this.cmdRaiseButtonEvent.TabIndex = 4;
            this.cmdRaiseButtonEvent.Text = "Raise Button Event";
            this.cmdRaiseButtonEvent.UseVisualStyleBackColor = true;
            this.cmdRaiseButtonEvent.Click += new System.EventHandler(this.cmdRaiseButtonEvent_Click);
            // 
            // ctrlMyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdRaiseButtonEvent);
            this.Controls.Add(this.lblSeat3);
            this.Controls.Add(this.lblSeat2);
            this.Controls.Add(this.lblSeat1);
            this.Controls.Add(this.label1);
            this.Name = "ctrlMyUserControl";
            this.Size = new System.Drawing.Size(338, 264);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSeat1;
        private System.Windows.Forms.Label lblSeat2;
        private System.Windows.Forms.Label lblSeat3;
        private System.Windows.Forms.Button cmdRaiseButtonEvent;
    }
}
