using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class CustomerStatement : Form
    {
        ReportDocument rd;

        public CustomerStatement()
        {
            InitializeComponent();
        }

        private void CustomerStatement_Load(object sender, EventArgs e)
        {
            int CheckSuporCust = 0;
            if (AllReports.CustomerIDStatement != 0)
            {
                try
                {
                    MainClass.con.Open();
                    CheckSuporCust = 0;
                    SqlCommand cmd = new SqlCommand("select PersonType from Persons where PersonID = '" + AllReports.CustomerIDStatement + "'", MainClass.con);
                    int ob = int.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();
                    if (ob == 2)
                    {
                        CheckSuporCust = 1;
                    }
                    else
                    {
                        CheckSuporCust = 0;
                    }

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            if (CheckSuporCust == 1)
            {
                if (AllReports.VIEWINVOICEVIACUSTOMER != 0)
                {
                    rd = new ReportDocument();
                    MainClass.ShowInvoiceVIACustomer(rd, crystalReportViewer1, "InvoicesViaCustomer", "@CustomerID", AllReports.VIEWINVOICEVIACUSTOMER); // new report for Customer


                }
                else
                {
                    rd = new ReportDocument();
                    MainClass.ShowStatement(rd, crystalReportViewer1, "CustomerReportProc", "@CustomerID", AllReports.CustomerIDStatement); // new report for Customer
                }
            }
            else
            {
                rd = new ReportDocument();
                MainClass.ShowStatement(rd, crystalReportViewer1, "SupplierReportProc", "@SupplierID", AllReports.SupllierIDStatement); // new report for Supplier
            }
        }
    }
}
