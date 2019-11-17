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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pass = Engine.getValue("select password from UserLogin where userName='" + txtUserName.Text + "'");
            if (pass == null)
            {
                MessageBox.Show("Invalid User Name", "Login Failed", 0, MessageBoxIcon.Error);
                txtUserName.Focus();
                SendKeys.Send("{Home}{End}");
            }
            else if (txtPassword.Text == pass.Asc())
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Wrong Password", "Login Failed", 0, MessageBoxIcon.Error);
                txtPassword.Focus();
                SendKeys.Send("{Home}{End}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            createTable();
        }
        private void createTable()
        {
            bool flag = Engine.ExecuteQry("select top 1 * from UserLogin");
            if (!flag)
            {
                Engine.ExecuteQry("create table UserLogin(UserName varchar(50),"
                    + "Password varchar(50))");
                Engine.ExecuteQry("insert into UserLogin(UserName,Password)"
                    +"values('Administrator','"+"admin".Asc()+"')");
                Engine.ExecuteQry("insert into UserLogin(UserName,Password)"
    + "values('admin','" + "admin".Asc() + "')");
            }

        }
    }
}
