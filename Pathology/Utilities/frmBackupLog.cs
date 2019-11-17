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
    public partial class frmBackupLog : Form
    {
        public frmBackupLog()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtTop.Text == "0")
                txtTop.Text = "50";
            string sql;
            if(radSuccess.Checked)
                sql = "select top " + txtTop.Text + " * from BackupLog where Status like '%Success' order by BackupDate desc";
            else if (radFailed.Checked)
                sql = "select top " + txtTop.Text + " * from BackupLog where Status like '%Failed' order by BackupDate desc";
            else
                sql = "select top " + txtTop.Text + " * from BackupLog order by BackupDate desc";
            dataGridView1.DataSource = Engine.getDataTable(sql, "BackupLog");
            if(dataGridView1.RowCount>0){
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        
        }
    }
}
