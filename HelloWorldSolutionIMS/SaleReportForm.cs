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
    public partial class SaleReportForm : Form
    {
        ReportDocument rd;

        public SaleReportForm()
        {
            InitializeComponent();
        }

        private void SaleReportForm_Load(object sender, EventArgs e)
        {
            rd = new ReportDocument();
            if (AllReports.Invoice_ID != 0)
            {
                MainClass.ShowReports(rd, crystalReportViewer1, "GetSaleRecieptWRTCustomerInvoiceID", "@CustomerInvoice_ID", AllReports.Invoice_ID);
            }
            else if (SaleInvoice.SaleID != 0)
            {
                MainClass.ShowReports(rd, crystalReportViewer1, "GetSaleReceipt2", "@SaleID", SaleInvoice.SaleID);
            }
            else
            {
                MainClass.ShowReports(rd, crystalReportViewer1, "GetSaleReciept" ,"@SaleInvoiceNo", SaleInvoice.SALEINVOICENO);
            }
        }

        private void SaleReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
