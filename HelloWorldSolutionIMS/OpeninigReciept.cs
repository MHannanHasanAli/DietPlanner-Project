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
    public partial class OpeninigReciept : Form
    {
        ReportDocument rd;
        public OpeninigReciept()
        {
            InitializeComponent();
        }

        private void OpeninigReciept_Load(object sender, EventArgs e)
        {
            rd = new ReportDocument();
            if (OpeningBalance.Cust_ID != 0)
            {
                MainClass.CustomerOpeniningReport(rd, crystalReportViewer1, "OpeniningReports", "@CustomerID",OpeningBalance.Cust_ID);
            }
        }

        private void OpeninigReciept_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
