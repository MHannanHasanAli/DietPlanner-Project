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
    public partial class PurchaseReportForm : Form
    {
        ReportDocument rd;
        public PurchaseReportForm()
        {
            InitializeComponent();
        }

        private void PurchaseReportForm_Load(object sender, EventArgs e)
        {
            rd = new ReportDocument();
            if (AllReports.Invoice_ID != 0)
            {
                MainClass.ShowReportsp(rd, crystalReportViewer1, "GetPurchaseRecieptWRTSuipplierInvoiceID", "@SupplierInvoice_ID",AllReports.Invoice_ID);
            }
            else if(PurchaseInvoice.PurUpdateID != 0)
            {
                MainClass.ShowReportsp(rd, crystalReportViewer1, "GetPurchaseReciept2", "@PurUpdateID", PurchaseInvoice.PurUpdateID);
            }
            else
            {
                MainClass.ShowReportsp(rd, crystalReportViewer1, "GetPurchaseReciept");
            }
        }

        private void PurchaseReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
