using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pathology
{
    class AutoBackup:IDisposable
    {
        public  AutoBackup()
        {
            if (!CreateStructure())
            {
                CreateBackup();
            }
        }
        public void Dispose()
        {
            //Dispose();
            GC.SuppressFinalize(this);
        }
        string BackupPath;
        private bool CreateStructure()
        {
            BackupPath= Application.StartupPath + "\\Backup";
            DataRow dr = Engine.getDataRow("select top 1 * from BackupLog order by Row_id desc");
            if (dr == null)
            {
                if (!System.IO.Directory.Exists(BackupPath))
                {
                    System.IO.Directory.CreateDirectory(BackupPath);
                }
                Engine.ExecuteQry("create table BackupLog(Row_ID int identity(1,1),BackupPath varchar(200),FileName varchar(50),BackupDate datetime,Status varchar(50))");
                CreateBackup();
                return true;
            }
            else
            {
                BackupPath = dr["BackupPath"].ToString();
                return false;
            }
            
        }
        private void CreateBackup()
        {
            string sql;
            string fileName = Engine.dbname + "_" + String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now) + ".bak";
            sql = "backup database " + Engine.dbname + " to disk='" + BackupPath + "\\" + fileName + "'";
            //sql[1] = "insert into BackupLog(BackupPath,BackupDate)values('" + txtBackupPath.Text + "\\" + Engine.dbname + "_" + DateTime.Now.ToString("ddd") + ".bak','" + String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now) + "')";
            Engine.ErrorMsg = "";
            if (Engine.ExecuteQry(sql))
            {
                sql = "insert into BackupLog(BackupPath,FileName,BackupDate,Status,Description)values('" + BackupPath + "','" + fileName + "','" + String.Format("{0:dd/MMM/yyyy HH:mm:ss}", DateTime.Now) + "','Auto:Success','Backup Created')";
                Engine.ExecuteQry(sql);
                //MessageBox.Show("Backup Created");
            }
            else
            {
                Engine.ErrorMsg = Engine.ErrorMsg.Replace("'", "''");
                sql = "insert into BackupLog(BackupPath,FileName,BackupDate,Status,Description)values('" + BackupPath + "','" + fileName + "','" + String.Format("{0:dd/MMM/yyyy HH:mm:ss}", DateTime.Now) + "','Auto:Failed','" + Engine.ErrorMsg + "')";
                if (!Engine.ExecuteQry(sql))
                {
                    sql = "insert into BackupLog(BackupPath,FileName,BackupDate,Status,Description)values('" + BackupPath + "','" + fileName + "','" + String.Format("{0:dd/MMM/yyyy HH:mm:ss}", DateTime.Now) + "','Auto:Failed','" + Engine.ErrorMsg.Substring(0, 35) + "')";
                    Engine.ExecuteQry(sql);
                }
                //MessageBox.Show(Engine.ErrorMsg);
            }
        }
    }
}
