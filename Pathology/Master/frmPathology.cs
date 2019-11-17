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
    public partial class frmPathology : Form
    {
        ButtonControl b = new ButtonControl();
        public frmPathology()
        {
            InitializeComponent();
            this.b.SubmitClicked += new ButtonControl.SubmitClickedHandler(this.SubmitClicked);
        }
        #region Events
        private void frmPathology_Load(object sender, EventArgs e)
        {
            createTable();
            pnlButtons.Controls.Add(b);
            b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mode = FormMode.Normal;
            SetMode(false);
        }


        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SubmitClicked(string action)
        {
            switch (action)
            {
                case "Add":
                    this.Mode = FormMode.AddNew;
                    SetMode(true);
                    ScatterBlank();
                    txtPatientId.Enabled = true;
                    txtPatientId.Focus();
                    break;
                case "Save":
                    if (this.Mode == FormMode.AddNew)
                    {
                        if (SaveData())
                        {
                            ScatterBlank();
                            if (this.Mode == FormMode.AddNew)
                                txtPatientId.Focus();
                        }
                    }
                    else if (this.Mode == FormMode.Edit)
                    {
                        if (SaveData())
                        {
                            ScatterBlank();
                            SetMode(false);
                            this.Mode = FormMode.Normal;
                        }
                    }
                    break;
                case "Edit":
                    if (this.Mode == FormMode.Normal)
                    {
                        XHelp help = new XHelp();
                        help.Text = "Course / Standard";
                        help.TableName = "Pathology";
                        help.ColCollection = "Course, Fees, DurationDays, DurationMonths";
                        help.SearchOn = "Course";
                        help.Columns[1].DefaultCellStyle.Format = "###0.00";
                        help.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        help.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        help.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        help.Show = true;
                        if (help.Cancel == false)
                        {
                            txtPatientId.Text = help.SelectedValue[0].ToString();
                            //txtFees.NumValue = help.SelectedValue[1].ToString();
                            txtMonths.Text = help.SelectedValue[2].ToString();
                            txtDays.Text = help.SelectedValue[3].ToString();
                        }
                        help.Dispose();
                    }
                    this.Mode = FormMode.Edit;
                    SetMode(true);
                    //txtFees.Focus();
                    break;
                case "Delete":
                    if (DeleteData())
                    {
                        this.Mode = FormMode.Normal;
                        SetMode(false);
                        ScatterBlank();
                    }
                    else
                    {
                        this.Mode = FormMode.Delete;
                        SetMode(false);
                        txtPatientId.Enabled = true;
                        txtPatientId.Focus();
                    }
                    break;
                case "View":
                    this.Mode = FormMode.View;
                    ShowData("L");
                    break;
                case "First":
                    this.Mode = FormMode.View;
                    ShowData("F");
                    break;
                case "Back":
                    this.Mode = FormMode.View;
                    ShowData("P");
                    break;
                case "Next":
                    this.Mode = FormMode.View;
                    ShowData("N");
                    break;
                case "Last":
                    this.Mode = FormMode.View;
                    ShowData("L");
                    break;
                case "Cancel":
                    SetMode(false);
                    this.Mode = FormMode.Normal;
                    break;
                case "Exit":
                    this.Close();
                    break;
            }
        }
        private void frmPathology_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.Mode == FormMode.Normal)
                    this.Close();
                else if (this.Mode != FormMode.Normal)
                {
                    ScatterBlank();
                    SetMode(false);
                    this.Mode = FormMode.Normal;
                }
            }
        }
        private void txtCourse_Validating(object sender, CancelEventArgs e)
        {
            string course = Engine.getValue("select Course from Pathology where Course='" + txtPatientId.Text + "'");
            if (course != null)
            {
                txtPatientId.Focus();
                txtPatientId.ShowBalloon("Course Already Defined");
            }
        }
        #endregion

        #region Methods
        private void createTable()
        {
            bool flag = Engine.ExecuteQry("select top 1 * from Pathology");
            if (!flag)
                Engine.ExecuteQry("create table Pathology(id int identity(1,1),"
                    + "Course varchar(50),"
                    + "Fees money,"
                    + "DurationMonths int,"
                    + "DurationDays int)");
        }
        private bool SaveData()
        {
            string[] sql = null;
            int index = 0;
            string dbFields = "Course, Fees, DurationMonths, DurationDays";
            string values;


            if (ValidateControls())
            {
                if (this.Mode == FormMode.Edit)
                {
                    Array.Resize(ref sql, index + 1);
                    sql[index] = "delete Pathology where Course='" + txtPatientId.Text + "'";
                    index++;
                }
                Array.Resize(ref sql, index + 1);
                values = "'" + txtPatientId.Text + "',"  + txtMonths.Text + "," + txtDays.Text;
                sql[index] = "insert into Pathology(" + dbFields + ")values(" + values + ")";
                Engine.ErrorMsg = "";
                if (Engine.ValidateAndExecute(sql))
                {
                    sql = null;
                    return true;
                }
                else
                {
                    MessageBox.Show(Engine.ErrorMsg);
                    sql = null;
                    return false;
                }
            }
            else
                return false;
        }
        private void SetMode(bool mode)
        {
            txtPatientId.Enabled = false;
            //txtFees.Enabled = mode;
            txtMonths.Enabled = mode;
            txtDays.Enabled = mode;
        }
        private void ScatterBlank()
        {
            txtPatientId.Clear();
            //txtFees.Clear();
            txtMonths.Text = "0";
            txtDays.Text = "0";
        }
        private bool ValidateControls()
        {
            if (txtPatientId.Text == "")
            {
                MessageBox.Show("Course Can't be empty!");
                txtPatientId.Focus();
                return false;
            }
            //else if (txtFees.Text == "")
            //{
            //    MessageBox.Show("Fees Can't be empty!");
            //    txtFees.Focus();
            //    return false;
            //}
            else if (txtMonths.Text == "" & txtDays.Text == "")
            {
                MessageBox.Show("Please Specify Course Duration!");
                txtMonths.Focus();
                return false;
            }
            else
                return true;
        }
        private bool ShowData(string direction)
        {
            //bool functionReturnValue = false;
            string sql = "";
            switch (direction)
            {
                case "N":
                    sql = "select top 1 * from Pathology where Course > '" + txtPatientId.Text + "' order by Course asc";
                    break;
                case "P":
                    sql = "select top 1 * from Pathology where Course < '" + txtPatientId.Text + "' order by Course  desc";
                    break;
                case "F":
                    sql = "select top 1 * from Pathology order by Course asc";
                    break;                
                case "L":
                    sql = "select top 1 * from Pathology order by Course desc";
                    break;
                default:
                    sql = "select * from Pathology where Course='"+txtPatientId.Text+"'";
                    break;
            }
            DataTable dt = Engine.getDataTable(sql, "Pathology");
            if (dt.Rows.Count > 0)
            {
                ScatterBlank();
                DataRow dr = dt.Rows[0];
                txtPatientId.Text = dr["Course"].ToString();
                //txtFees.NumValue = dr["Fees"].ToString();
                txtMonths.Text = dr["DurationMonths"].ToString();
                txtDays.Text = dr["DurationDays"].ToString();
                if (direction != "")
                {
                    dt.Dispose();
                    dt = null;
                    return ShowData("");
                    //return functionReturnValue;
                }
                return true;
            }
            else
            {
                sql = string.Empty;
                dt.Dispose();
                dt = null;
                return false;
            }
            //return functionReturnValue;

        }
        private bool DeleteData()
        {
            string sql;
            if (this.Mode == FormMode.Delete)
            {
                DialogResult result = MessageBox.Show("Delete Current Record...", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sql = "delete Pathology where Course='" + txtPatientId.Text + "'";
                    Engine.ErrorMsg = "";
                    if (Engine.ExecuteQry(sql))
                    {
                        sql = null;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(Engine.ErrorMsg);
                        sql = null;
                        return false;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Properties
        public enum FormMode
        {
            AddNew,
            Delete,
            Edit,
            Normal,
            View

        }
        private FormMode _Mode;
        public FormMode Mode
        {
            get
            {
                return _Mode;
            }
            set
            {
                _Mode = value;
                if (_Mode == FormMode.Normal)
                {
                    this.b.ButtonText = "&Add;&Edit;&Delete;&View;E&xit";
                    lblMode.Text = "Normal";
                }
                else if (_Mode == FormMode.AddNew)
                {
                    this.b.ButtonText = "&Save;&Cancel";
                    lblMode.Text = "AddNew";
                }
                else if (_Mode == FormMode.Edit)
                {
                    this.b.ButtonText = "&Save;&Cancel";
                    lblMode.Text = "Edit";
                }
                else if (_Mode == FormMode.View)
                {
                    this.b.ButtonText = "&First;&Back;&Next;&Last;&Search;&Edit;&Delete;&History;E&xit";
                    lblMode.Text = "View";
                }
                else if (_Mode == FormMode.Delete)
                {
                    this.b.ButtonText = "&Cancel;&Delete";
                    lblMode.Text = "Delete";
                }
            }
        }
        #endregion        

    }
}
