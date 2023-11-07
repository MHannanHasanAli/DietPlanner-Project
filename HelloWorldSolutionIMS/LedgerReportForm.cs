using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace HelloWorldSolutionIMS
{
    public partial class LedgerReportForm : Form
    {
        ReportDocument rd;
        public LedgerReportForm()
        {
            InitializeComponent();
        }

        private void LedgerReportForm_Load(object sender, EventArgs e)
        {
            if (Ledgers.changedtype == 1)
            {
                rd = new ReportDocument();
                MainClass.ShowReportsLS(rd, crystalReportViewer1, "PrintSupplierLedger", "@SupplierLedgerID",Ledgers.SUPLEDGERID); // new report for supplier
            }
            else
            {
                rd = new ReportDocument();
                MainClass.ShowReportsL(rd, crystalReportViewer1, "PrintLedger", "@CustomerLedgerID",Ledgers.CUSTLEDGERID);
            }
        }

        private void LedgerReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
