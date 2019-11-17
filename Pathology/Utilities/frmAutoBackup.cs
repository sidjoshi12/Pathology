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
    public partial class frmAutoBackup : Form
    {
        public frmAutoBackup()
        {
            InitializeComponent();
        }

        private void frmAutoBackup_Load(object sender, EventArgs e)
        {
            CreateStructure();
        }
        private void CreateStructure() {
            txtBackupPath.Text = Application.StartupPath + "\\Backup";
            DataRow dr = Engine.getDataRow("select top 1 * from BackupLog order by Row_id desc");
            if (dr == null)
            {
                if (!System.IO.Directory.Exists(txtBackupPath.Text))
                {
                    System.IO.Directory.CreateDirectory(txtBackupPath.Text);
                }
                Engine.ExecuteQry("create table BackupLog(Row_ID int identity(1,1),BackupPath varchar(200),FileName varchar(50),BackupDate datetime,Status varchar(20),Description varchar(50))");
                CreateBackup();
            }
            else
            {
                txtBackupPath.Text = dr["BackupPath"].ToString();
            }
            
        }
        private void CreateBackup()
        {
            string sql;
            string fileName = Engine.dbname + "_" + String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now)+".bak";
            sql = "backup database " + Engine.dbname + " to disk='" + txtBackupPath.Text + "\\" + fileName+"'";
            //sql[1] = "insert into BackupLog(BackupPath,BackupDate)values('" + txtBackupPath.Text + "\\" + Engine.dbname + "_" + DateTime.Now.ToString("ddd") + ".bak','" + String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now) + "')";
            Engine.ErrorMsg = "";
            if (Engine.ExecuteQry(sql))
            {
                sql = "insert into BackupLog(BackupPath,FileName,BackupDate,Status,Description)values('" + txtBackupPath.Text + "','" + fileName + "','" + String.Format("{0:dd/MMM/yyyy HH:mm:ss}", DateTime.Now) + "','Manual:Success','Backup Created')";
                Engine.ExecuteQry(sql);
                MessageBox.Show("Backup Created");
            }
            else
            {
                Engine.ErrorMsg = Engine.ErrorMsg.Replace("'", "''");
                sql = "insert into BackupLog(BackupPath,FileName,BackupDate,Status,Description)values('" + txtBackupPath.Text + "','" + fileName + "','" + String.Format("{0:dd/MMM/yyyy HH:mm:ss}", DateTime.Now) + "','Manual:Failed','" + Engine.ErrorMsg + "')";
                if (!Engine.ExecuteQry(sql))
                {
                    sql = "insert into BackupLog(BackupPath,FileName,BackupDate,Status,Description)values('" + txtBackupPath.Text + "','" + fileName + "','" + String.Format("{0:dd/MMM/yyyy HH:mm:ss}", DateTime.Now) + "','Manual:Failed','" + Engine.ErrorMsg.Substring(0, 35) + "')";
                    Engine.ExecuteQry(sql);
                }
                MessageBox.Show(Engine.ErrorMsg);
            }
        }
                

        
        
        private void btnBackupNow_Click(object sender, EventArgs e)
        {
            CreateBackup();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = dlg.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAutoBackup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


    }
}
