namespace Chapter_14_15_User_Control_and_Event
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
            this.Label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ctrlMyUserControl1 = new Chapter_14_15_User_Control_and_Event.ctrlMyUserControl();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(252, 295);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(186, 329);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(293, 24);
            this.lblStatus.TabIndex = 1;
            // 
            // ctrlMyUserControl1
            // 
            this.ctrlMyUserControl1.Location = new System.Drawing.Point(107, 12);
            this.ctrlMyUserControl1.Name = "ctrlMyUserControl1";
            this.ctrlMyUserControl1.Size = new System.Drawing.Size(338, 264);
            this.ctrlMyUserControl1.TabIndex = 2;
            this.ctrlMyUserControl1.ButtonClickEvent += new Chapter_14_15_User_Control_and_Event.ctrlMyUserControl.ButtonClickDelegate(this.ctrlMyUserControl1_ButtonClickEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 370);
            this.Controls.Add(this.ctrlMyUserControl1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label lblStatus;
        private ctrlMyUserControl ctrlMyUserControl1;
    }
}

