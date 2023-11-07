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
    public partial class OpeningBalanceReport : Form
    {
        ReportDocument rd;
        public OpeningBalanceReport()
        {
            InitializeComponent();
        }

        private void OpeningBalanceReport_Load(object sender, EventArgs e)
        {
            rd = new ReportDocument();
            if (AllReports.Customer_ID != 0)
            {
                MainClass.ShowReportsOP(rd, crystalReportViewer1, "GetOpeniningReport","@CustomerID", AllReports.Customer_ID,"@InfoID",AllReports.InfoID);
            }
            else
            {
                MainClass.ShowReportsOP(rd, crystalReportViewer1, "GetOpeningReciept", "@VoucherID",OpeningBalance.VOUCHERID);
            }
        }

        private void OpeningBalanceReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
