using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HelloWorldSolutionIMS
{
    public partial class ScrapItems : Form
    {
        public ScrapItems()
        {
            InitializeComponent();
        }
        void ShowScrapItems(DataGridView dgv, DataGridViewColumn SC_Pcode, DataGridViewColumn SC_Qty, DataGridViewColumn SC_Unit)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select p.ProductName,sc.SC_Qty,sc.SC_Unit from Scraps sc inner join Products p on sc.SC_Pcode = p.Pcode where sc.SC_Qty > 0 order by sc.SC_Pcode", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SC_Pcode.DataPropertyName = dt.Columns["ProductName"].ToString();
                SC_Qty.DataPropertyName = dt.Columns["SC_Qty"].ToString();
                SC_Unit.DataPropertyName = dt.Columns["SC_Unit"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScrapItems_Load(object sender, EventArgs e)
        {
            ShowScrapItems(guna2DataGridView1, PCodeGV, QtyGV, UnitGV);
        }
    }
}
