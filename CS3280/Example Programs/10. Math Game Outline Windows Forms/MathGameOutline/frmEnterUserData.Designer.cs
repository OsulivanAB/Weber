namespace MathGameOutline
{
    partial class frmEnterUserData
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
            this.cmdCloseUserDataForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCloseUserDataForm
            // 
            this.cmdCloseUserDataForm.Location = new System.Drawing.Point(67, 164);
            this.cmdCloseUserDataForm.Name = "cmdCloseUserDataForm";
            this.cmdCloseUserDataForm.Size = new System.Drawing.Size(145, 23);
            this.cmdCloseUserDataForm.TabIndex = 3;
            this.cmdCloseUserDataForm.Text = "Close User Data Form";
            this.cmdCloseUserDataForm.UseVisualStyleBackColor = true;
            this.cmdCloseUserDataForm.Click += new System.EventHandler(this.cmdCloseUserDataForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Data";
            // 
            // frmEnterUserData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCloseUserDataForm);
            this.Name = "frmEnterUserData";
            this.Text = "Enter User Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCloseUserDataForm;
        private System.Windows.Forms.Label label1;
    }
}