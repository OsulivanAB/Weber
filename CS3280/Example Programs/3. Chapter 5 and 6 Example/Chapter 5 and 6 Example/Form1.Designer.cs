namespace Chapter_5_and_6_Example
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
            this.txtMyTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmdMyButton = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cmdChangeImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMyTextbox
            // 
            this.txtMyTextbox.Location = new System.Drawing.Point(130, 392);
            this.txtMyTextbox.Name = "txtMyTextbox";
            this.txtMyTextbox.Size = new System.Drawing.Size(272, 20);
            this.txtMyTextbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(170, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 23);
            this.label1.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(66, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(440, 336);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // cmdMyButton
            // 
            this.cmdMyButton.Location = new System.Drawing.Point(226, 488);
            this.cmdMyButton.Name = "cmdMyButton";
            this.cmdMyButton.Size = new System.Drawing.Size(75, 23);
            this.cmdMyButton.TabIndex = 4;
            this.cmdMyButton.Text = "Click Me";
            this.cmdMyButton.Click += new System.EventHandler(this.cmdMyButton_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(631, 83);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(113, 102);
            this.pbImage.TabIndex = 8;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // cmdChangeImage
            // 
            this.cmdChangeImage.Location = new System.Drawing.Point(656, 223);
            this.cmdChangeImage.Name = "cmdChangeImage";
            this.cmdChangeImage.Size = new System.Drawing.Size(75, 23);
            this.cmdChangeImage.TabIndex = 9;
            this.cmdChangeImage.Text = "button1";
            this.cmdChangeImage.UseVisualStyleBackColor = true;
            this.cmdChangeImage.Click += new System.EventHandler(this.cmdChangeImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 557);
            this.Controls.Add(this.cmdChangeImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.txtMyTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cmdMyButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMyTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button cmdMyButton;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button cmdChangeImage;
    }
}

