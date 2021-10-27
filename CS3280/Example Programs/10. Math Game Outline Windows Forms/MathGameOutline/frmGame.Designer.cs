namespace MathGameOutline
{
    partial class frmGame
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
            this.cmdEndGame = new System.Windows.Forms.Button();
            this.cmdShowHighScores = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is where the game is played";
            // 
            // cmdEndGame
            // 
            this.cmdEndGame.Location = new System.Drawing.Point(187, 91);
            this.cmdEndGame.Name = "cmdEndGame";
            this.cmdEndGame.Size = new System.Drawing.Size(75, 23);
            this.cmdEndGame.TabIndex = 1;
            this.cmdEndGame.Text = "End Game";
            this.cmdEndGame.UseVisualStyleBackColor = true;
            this.cmdEndGame.Click += new System.EventHandler(this.cmdEndGame_Click);
            // 
            // cmdShowHighScores
            // 
            this.cmdShowHighScores.Location = new System.Drawing.Point(187, 206);
            this.cmdShowHighScores.Name = "cmdShowHighScores";
            this.cmdShowHighScores.Size = new System.Drawing.Size(75, 23);
            this.cmdShowHighScores.TabIndex = 2;
            this.cmdShowHighScores.Text = "High Scores";
            this.cmdShowHighScores.UseVisualStyleBackColor = true;
            this.cmdShowHighScores.Click += new System.EventHandler(this.cmdShowHighScores_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Simulate that the game has ended and the high scores need to be shown";
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 266);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdShowHighScores);
            this.Controls.Add(this.cmdEndGame);
            this.Controls.Add(this.label1);
            this.Name = "frmGame";
            this.Text = "frmGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEndGame;
        private System.Windows.Forms.Button cmdShowHighScores;
        private System.Windows.Forms.Label label2;
    }
}