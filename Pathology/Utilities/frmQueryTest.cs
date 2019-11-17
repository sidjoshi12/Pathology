using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pathology
{
    public partial class frmQueryTest : Form
    {
        public frmQueryTest()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void btnExecute_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            ds = Engine.getDataSet(sqlCode.Text);
            if (ds == null)
            {
                MessageBox.Show(Engine.ErrorMsg);
            }
            else
            {
                
                for (int i = 0; i < ds.Tables.Count; i++)
                    comboBox1.Items.Add("Table" + (i + 1).ToString());
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[comboBox1.SelectedIndex];
        }
        
    }
}
