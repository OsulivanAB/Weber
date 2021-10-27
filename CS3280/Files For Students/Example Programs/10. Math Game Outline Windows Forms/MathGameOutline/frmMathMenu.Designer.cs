namespace MathGameOutline
{
    partial class frmMathMenu
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
            this.cmdPlayGame = new System.Windows.Forms.Button();
            this.cmdHighScores = new System.Windows.Forms.Button();
            this.cmdEnterUserData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdPlayGame
            // 
            this.cmdPlayGame.Location = new System.Drawing.Point(33, 103);
            this.cmdPlayGame.Name = "cmdPlayGame";
            this.cmdPlayGame.Size = new System.Drawing.Size(97, 31);
            this.cmdPlayGame.TabIndex = 0;
            this.cmdPlayGame.Text = "Play Game";
            this.cmdPlayGame.UseVisualStyleBackColor = true;
            this.cmdPlayGame.Click += new System.EventHandler(this.cmdPlayGame_Click);
            // 
            // cmdHighScores
            // 
            this.cmdHighScores.Location = new System.Drawing.Point(165, 103);
            this.cmdHighScores.Name = "cmdHighScores";
            this.cmdHighScores.Size = new System.Drawing.Size(97, 31);
            this.cmdHighScores.TabIndex = 1;
            this.cmdHighScores.Text = "High Scores";
            this.cmdHighScores.UseVisualStyleBackColor = true;
            this.cmdHighScores.Click += new System.EventHandler(this.cmdHighScores_Click);
            // 
            // cmdEnterUserData
            // 
            this.cmdEnterUserData.Location = new System.Drawing.Point(297, 103);
            this.cmdEnterUserData.Name = "cmdEnterUserData";
            this.cmdEnterUserData.Size = new System.Drawing.Size(97, 31);
            this.cmdEnterUserData.TabIndex = 2;
            this.cmdEnterUserData.Text = "Enter User Data";
            this.cmdEnterUserData.UseVisualStyleBackColor = true;
            this.cmdEnterUserData.Click += new System.EventHandler(this.cmdEnterUserData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Math Main Menu";
            // 
            // frmMathMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 274);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdEnterUserData);
            this.Controls.Add(this.cmdHighScores);
            this.Controls.Add(this.cmdPlayGame);
            this.Name = "frmMathMenu";
            this.Text = "Math Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPlayGame;
        private System.Windows.Forms.Button cmdHighScores;
        private System.Windows.Forms.Button cmdEnterUserData;
        private System.Windows.Forms.Label label1;
    }
}