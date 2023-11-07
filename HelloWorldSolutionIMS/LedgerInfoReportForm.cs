using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class LedgerInfoReportForm : Form
    {
        ReportDocument rd;

        public LedgerInfoReportForm()
        {
            InitializeComponent();
        }

        private void LedgerInfoReportForm_Load(object sender, EventArgs e)
        {
            rd = new ReportDocument();

            if (AllReports.PType == 1)
            {
                MainClass.ShowInfoReportSup(rd, crystalReportViewer1, "GetLedgerReportSuppl", "@SupplierID", AllReports.SupID, "@LedgerInfoID", AllReports.SupInfoID);
            }
            else
            {
               MainClass.ShowInfoReportCust(rd, crystalReportViewer1, "GetLedgerReportCust", "@CustomerID", AllReports.CustID, "@LedgerInfoID", AllReports.CusInfoID);

            }
        }

        private void LedgerInfoReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
