namespace CsharpAdvancedConcepts
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
            this.cmdImplicitlyTypedLocalVariables = new System.Windows.Forms.Button();
            this.lblImplicityTyped = new System.Windows.Forms.Label();
            this.cmdAnonymousTypes = new System.Windows.Forms.Button();
            this.lblAnonymousTypes = new System.Windows.Forms.Label();
            this.cmdExtensionMethods = new System.Windows.Forms.Button();
            this.lblExtensionMethods = new System.Windows.Forms.Label();
            this.lblAnonymousMethods = new System.Windows.Forms.Label();
            this.cmdAnonymousMethods = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdImplicitlyTypedLocalVariables
            // 
            this.cmdImplicitlyTypedLocalVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImplicitlyTypedLocalVariables.Location = new System.Drawing.Point(12, 12);
            this.cmdImplicitlyTypedLocalVariables.Name = "cmdImplicitlyTypedLocalVariables";
            this.cmdImplicitlyTypedLocalVariables.Size = new System.Drawing.Size(147, 75);
            this.cmdImplicitlyTypedLocalVariables.TabIndex = 1;
            this.cmdImplicitlyTypedLocalVariables.Text = "Implicitly Typed Local Variables";
            this.cmdImplicitlyTypedLocalVariables.UseVisualStyleBackColor = true;
            this.cmdImplicitlyTypedLocalVariables.Click += new System.EventHandler(this.cmdImplicitlyTypedLocalVariables_Click);
            // 
            // lblImplicityTyped
            // 
            this.lblImplicityTyped.AutoSize = true;
            this.lblImplicityTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImplicityTyped.Location = new System.Drawing.Point(180, 39);
            this.lblImplicityTyped.Name = "lblImplicityTyped";
            this.lblImplicityTyped.Size = new System.Drawing.Size(0, 20);
            this.lblImplicityTyped.TabIndex = 2;
            // 
            // cmdAnonymousTypes
            // 
            this.cmdAnonymousTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAnonymousTypes.Location = new System.Drawing.Point(12, 112);
            this.cmdAnonymousTypes.Name = "cmdAnonymousTypes";
            this.cmdAnonymousTypes.Size = new System.Drawing.Size(147, 75);
            this.cmdAnonymousTypes.TabIndex = 3;
            this.cmdAnonymousTypes.Text = "Anonymous Types";
            this.cmdAnonymousTypes.UseVisualStyleBackColor = true;
            this.cmdAnonymousTypes.Click += new System.EventHandler(this.cmdAnonymousTypes_Click);
            // 
            // lblAnonymousTypes
            // 
            this.lblAnonymousTypes.AutoSize = true;
            this.lblAnonymousTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnonymousTypes.Location = new System.Drawing.Point(180, 143);
            this.lblAnonymousTypes.Name = "lblAnonymousTypes";
            this.lblAnonymousTypes.Size = new System.Drawing.Size(0, 20);
            this.lblAnonymousTypes.TabIndex = 4;
            // 
            // cmdExtensionMethods
            // 
            this.cmdExtensionMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExtensionMethods.Location = new System.Drawing.Point(12, 214);
            this.cmdExtensionMethods.Name = "cmdExtensionMethods";
            this.cmdExtensionMethods.Size = new System.Drawing.Size(147, 75);
            this.cmdExtensionMethods.TabIndex = 5;
            this.cmdExtensionMethods.Text = "Extension Methods";
            this.cmdExtensionMethods.UseVisualStyleBackColor = true;
            this.cmdExtensionMethods.Click += new System.EventHandler(this.cmdExtensionMethods_Click);
            // 
            // lblExtensionMethods
            // 
            this.lblExtensionMethods.AutoSize = true;
            this.lblExtensionMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtensionMethods.Location = new System.Drawing.Point(180, 241);
            this.lblExtensionMethods.Name = "lblExtensionMethods";
            this.lblExtensionMethods.Size = new System.Drawing.Size(0, 20);
            this.lblExtensionMethods.TabIndex = 6;
            // 
            // lblAnonymousMethods
            // 
            this.lblAnonymousMethods.AutoSize = true;
            this.lblAnonymousMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnonymousMethods.Location = new System.Drawing.Point(180, 342);
            this.lblAnonymousMethods.Name = "lblAnonymousMethods";
            this.lblAnonymousMethods.Size = new System.Drawing.Size(0, 20);
            this.lblAnonymousMethods.TabIndex = 8;
            // 
            // cmdAnonymousMethods
            // 
            this.cmdAnonymousMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAnonymousMethods.Location = new System.Drawing.Point(12, 315);
            this.cmdAnonymousMethods.Name = "cmdAnonymousMethods";
            this.cmdAnonymousMethods.Size = new System.Drawing.Size(147, 95);
            this.cmdAnonymousMethods.TabIndex = 7;
            this.cmdAnonymousMethods.Text = "Anonymous Methods and Lamda Expressions";
            this.cmdAnonymousMethods.UseVisualStyleBackColor = true;
            this.cmdAnonymousMethods.Click += new System.EventHandler(this.cmdAnonymousMethods_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 431);
            this.Controls.Add(this.lblAnonymousMethods);
            this.Controls.Add(this.cmdAnonymousMethods);
            this.Controls.Add(this.lblExtensionMethods);
            this.Controls.Add(this.cmdExtensionMethods);
            this.Controls.Add(this.lblAnonymousTypes);
            this.Controls.Add(this.cmdAnonymousTypes);
            this.Controls.Add(this.lblImplicityTyped);
            this.Controls.Add(this.cmdImplicitlyTypedLocalVariables);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdImplicitlyTypedLocalVariables;
        private System.Windows.Forms.Label lblImplicityTyped;
        private System.Windows.Forms.Button cmdAnonymousTypes;
        private System.Windows.Forms.Label lblAnonymousTypes;
        private System.Windows.Forms.Button cmdExtensionMethods;
        private System.Windows.Forms.Label lblExtensionMethods;
        private System.Windows.Forms.Label lblAnonymousMethods;
        private System.Windows.Forms.Button cmdAnonymousMethods;
    }
}

