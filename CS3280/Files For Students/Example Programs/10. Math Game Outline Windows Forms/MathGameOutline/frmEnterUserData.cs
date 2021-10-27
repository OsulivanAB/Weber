using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MathGameOutline
{
    public partial class frmEnterUserData : Form
    {
        public frmEnterUserData()
        {
            InitializeComponent();
        }

        private void cmdCloseUserDataForm_Click(object sender, EventArgs e)
        {
            //Hide user data form
            this.Hide();
        }
    }
}