using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Pathology
{
    public partial class frmReportViewer : Form
    {
        public DataTable ReportSource { get; set; }
        public ReportDocument ReportDocument { get; set; }
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            //rptPrintForm report = new rptPrintForm();
            ReportDocument.SetDataSource(ReportSource);
            crystalReportViewer1.ReportSource = ReportDocument;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }

        private void frmPrintPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            this.Close();
        }



        private void btnFirst_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowFirstPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowNextPage();
        }

        private void btnPreviuos_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowPreviousPage();
        }

        private void btnTPrint_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }
    }
}
