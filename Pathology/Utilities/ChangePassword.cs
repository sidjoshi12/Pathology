using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pathology
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            DataTable dt = Engine.getDataTable("select UserName from UserLogin", "UserLogin");
            foreach (DataRow dr in dt.Rows)
            {
                cboUserList.Items.Add(dr[0].ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented!!");
        }
    }
}
