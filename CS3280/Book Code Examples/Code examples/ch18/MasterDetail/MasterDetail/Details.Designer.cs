namespace MasterDetail
{
   partial class Details
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
         this.components = new System.ComponentModel.Container();
         this.booksDataGridView = new System.Windows.Forms.DataGridView();
         this.titleComboBox = new System.Windows.Forms.ComboBox();
         this.titleBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.titleLabel = new System.Windows.Forms.Label();
         this.authorBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.authorComboBox = new System.Windows.Forms.ComboBox();
         this.authorLabel = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // booksDataGridView
         // 
         this.booksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.booksDataGridView.Location = new System.Drawing.Point(11, 41);
         this.booksDataGridView.Name = "booksDataGridView";
         this.booksDataGridView.ReadOnly = true;
         this.booksDataGridView.Size = new System.Drawing.Size(471, 215);
         this.booksDataGridView.TabIndex = 14;
         // 
         // titleComboBox
         // 
         this.titleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.titleComboBox.FormattingEnabled = true;
         this.titleComboBox.Location = new System.Drawing.Point(294, 12);
         this.titleComboBox.Name = "titleComboBox";
         this.titleComboBox.Size = new System.Drawing.Size(189, 23);
         this.titleComboBox.TabIndex = 13;
         this.titleComboBox.SelectedIndexChanged += new System.EventHandler(this.titleComboBox_SelectedIndexChanged);
         // 
         // titleLabel
         // 
         this.titleLabel.AutoSize = true;
         this.titleLabel.Location = new System.Drawing.Point(255, 15);
         this.titleLabel.Name = "titleLabel";
         this.titleLabel.Size = new System.Drawing.Size(33, 15);
         this.titleLabel.TabIndex = 12;
         this.titleLabel.Text = "Title:";
         // 
         // authorComboBox
         // 
         this.authorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.authorComboBox.FormattingEnabled = true;
         this.authorComboBox.Location = new System.Drawing.Point(61, 12);
         this.authorComboBox.Name = "authorComboBox";
         this.authorComboBox.Size = new System.Drawing.Size(184, 23);
         this.authorComboBox.TabIndex = 11;
         this.authorComboBox.SelectedIndexChanged += new System.EventHandler(this.authorComboBox_SelectedIndexChanged);
         // 
         // authorLabel
         // 
         this.authorLabel.AutoSize = true;
         this.authorLabel.Location = new System.Drawing.Point(8, 15);
         this.authorLabel.Name = "authorLabel";
         this.authorLabel.Size = new System.Drawing.Size(47, 15);
         this.authorLabel.TabIndex = 10;
         this.authorLabel.Text = "Author:";
         // 
         // Details
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(495, 269);
         this.Controls.Add(this.booksDataGridView);
         this.Controls.Add(this.titleComboBox);
         this.Controls.Add(this.titleLabel);
         this.Controls.Add(this.authorComboBox);
         this.Controls.Add(this.authorLabel);
         this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "Details";
         this.Text = "Master/Detail";
         this.Load += new System.EventHandler(this.Details_Load);
         ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      internal System.Windows.Forms.DataGridView booksDataGridView;
      internal System.Windows.Forms.ComboBox titleComboBox;
      internal System.Windows.Forms.BindingSource titleBindingSource;
      internal System.Windows.Forms.Label titleLabel;
      internal System.Windows.Forms.BindingSource authorBindingSource;
      internal System.Windows.Forms.ComboBox authorComboBox;
      internal System.Windows.Forms.Label authorLabel;
   }
}

