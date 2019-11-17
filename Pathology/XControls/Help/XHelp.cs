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
    //bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
    public partial class XHelp : Form
    {
        public XHelp()
        {
            InitializeComponent();
        }

        #region Declarations
        DataTable dt;
        bool firstLoad = true;
        //int MaxRows = 10;
        //int curr = 0;
        //select top MaxRows ID,CreatedDate,ModifiedDate from PhysicalDelivery 
        //where id not in(select top curr ID from PhysicalDelivery order by id asc) order by id asc
        #endregion
        
        #region Events
        private void XHelp_Move(object sender, EventArgs e)
        {
            if (firstLoad)
            {
                FillGrid();
                firstLoad = false;
            }
        }
        private void XHelp_Load(object sender, EventArgs e)
        {
            //FillGrid();
            //dataGridView1.DataSource = dt;
            //for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //{
            //    dataGridView1.Columns[i].Width = _Columns[i].Width;
            //    dataGridView1.Columns[i].Visible = _Columns[i].Visible;
            //    dataGridView1.Columns[i].DefaultCellStyle = _Columns[i].DefaultCellStyle;
            //}
            //foreach (Control ctrl in dataGridView1.Controls)
            //    if (ctrl.GetType() == typeof(VScrollBar))
            //        ((VScrollBar)ctrl).Width = 5;
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                _SelectedValue = ToDataRow(dataGridView1.SelectedRows[0]);
                this.DialogResult = DialogResult.OK;
            }
            //else if (e.KeyCode == Keys.Down & dataGridView1.CurrentRow.Index == (dataGridView1.Rows.Count - 1))
            //{
            //    rowIndex++;
            //    FillGrid();
            //    dataGridView1.Focus();
            //    //dataGridView1.Rows[pageSize - 1].Selected = true;
            //    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            //}
            //else if (e.KeyCode == Keys.Up & dataGridView1.CurrentRow.Index==0)
            //{
            //    rowIndex--;
            //    FillGrid();
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _SelectedValue = ToDataRow(dataGridView1.SelectedRows[0]);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //dt = Engine.getDataTable(getSQL(), TableName);
            //dataGridView1.DataSource = dt;
            //rowIndex = 0;
            FillGrid();
        }
        private void XHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_SelectedValue == null)
            {
                Cancel = true;
                this.DialogResult = DialogResult.OK;
                
            }
        }
        private void XHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region Properties
        public string TableName { get; set; }
        private string _ColCollection;
        public string ColCollection
        {
            get
            {
                return _ColCollection;
            }
            set
            {
                _ColCollection = value;
                int count = _ColCollection.Split(',').Length;
                Array.Resize(ref _Columns, count);
                for (int i = 0; i < count; i++)
                {
                    _Columns[i] = new XColumns();
                }

            }
        }
        

        private XColumns[] _Columns;
        public XColumns[] Columns
        {
            get
            {
                return _Columns;
            }
            set
            {
                _Columns = value;
            }
        }
        private DataRow _SelectedValue;
        public DataRow SelectedValue
        {
            get
            {
                return _SelectedValue;
            }
            set
            {
                _SelectedValue = value;
            }
        }
        public string SearchOn { get; set; }
        public bool Distinct { get; set; }
        private string _SortOrder = "asc";
        public string SortOrder
        {
            get
            {
                return _SortOrder;
            }
            set
            {
                _SortOrder = value;
            }
        }
        public string SortOn { get; set; }
        public string Filter { get; set; }
        public bool Cancel { get; set; }
        private bool _Show;
        public bool Show
        {
            get
            {
                return _Show;
            }
            set
            {
                _Show = value;
                if (_Show)
                {
                    this.ShowDialog();
                }
            }
        }
        #endregion

        #region Methods
        private DataRow ToDataRow(DataGridViewRow value)
        {
            try
            {
                System.Data.DataRowView dv = (DataRowView)value.DataBoundItem;
                return dv.Row;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private string getSQL()
        {
            string sql = "select ";
            if (Distinct)
                sql += " distinct ";

            sql += ColCollection + " from " + TableName + " where " + SearchOn + " like '" + textBox1.Text + "%' ";
            if (Filter != null)
                sql += " and " + Filter;


            if (SortOn != null)
                sql += " order by " + SortOn + " " + SortOrder;
            return sql;
        }
        //int rowIndex = 0;
        //int pageSize = 10;
        public void FillGrid()
        {
            try
            {
                dt = Engine.getDataTable(getSQL(), TableName);
                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("0 records to view");
                    return;
                }
                
                //DataTable dtPage = dt.Rows.Cast<System.Data.DataRow>().Skip(rowIndex).Take(pageSize).CopyToDataTable();
                //DataTable dtPage = dt.Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();

                dataGridView1.DataSource = dt;

                //rowIndex = 0;
                //dataGridView1.Columns[0].Width = _Columns[0].Width;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (_Columns[i].Width == 0)
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    else
                        //if (_Columns[i].Width != 0)
                            dataGridView1.Columns[i].Width = _Columns[i].Width;
                    dataGridView1.Columns[i].Visible = _Columns[i].Visible;
                    dataGridView1.Columns[i].DefaultCellStyle = _Columns[i].DefaultCellStyle;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cancel = true;
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion            
        
    }
}
