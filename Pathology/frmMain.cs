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
    public partial class frmMain : Form
    {
        public frmMain(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                if (args[0] == "-a")
                {
                    testFormToolStripMenuItem.Visible = true;
                    changePasswordToolStripMenuItem.Visible = true;
                }
            }
        }
        private bool IsAlreadyOpen(Type formType)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == formType)
                {
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;
                    isOpen = true;
                }
            }
            return isOpen;
        }

        private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

                
        private void marksheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAutoBackup backup = null;
            bool isFormOpen = IsAlreadyOpen(typeof(frmAutoBackup));
            if (isFormOpen == false)
            {
                backup = new frmAutoBackup();
                backup.MdiParent = this;
                backup.StartPosition = FormStartPosition.CenterScreen;
                backup.Show();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changepass = null;
            bool isFormOpen = IsAlreadyOpen(typeof(ChangePassword));
            if (isFormOpen == false)
            {
                changepass = new ChangePassword();
                changepass.MdiParent = this;
                changepass.StartPosition = FormStartPosition.CenterScreen;           
                changepass.Show();
            }
        }

        
        private void backupLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //frmBackupLog
            frmBackupLog register = null;
            bool isFormOpen = IsAlreadyOpen(typeof(frmBackupLog));
            if (isFormOpen == false)
            {
                register = new frmBackupLog();
                register.MdiParent = this;
                register.StartPosition = FormStartPosition.CenterScreen;
                register.WindowState = FormWindowState.Maximized;
                register.Show();
            }
        }

        private void queryTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQueryTest register = null;
            bool isFormOpen = IsAlreadyOpen(typeof(frmQueryTest));
            if (isFormOpen == false)
            {
                register = new frmQueryTest();
                register.MdiParent = this;
                register.StartPosition = FormStartPosition.CenterScreen;
                register.WindowState = FormWindowState.Maximized;
                register.Show();
            }
        }
               

        private void pathologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPathology pathology = null;
            bool isFormOpen = IsAlreadyOpen(typeof(frmPathology));
            if (isFormOpen == false)
            {
                pathology = new frmPathology();
                pathology.MdiParent = this;
                pathology.StartPosition = FormStartPosition.CenterScreen;
                pathology.WindowState = FormWindowState.Maximized;
                pathology.Show();
            }
        }      
    }
}
