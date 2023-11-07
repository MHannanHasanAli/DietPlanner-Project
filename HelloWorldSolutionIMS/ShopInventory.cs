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
    public partial class ShopInventory : Form
    {
        public ShopInventory()
        {
            InitializeComponent();
        }

        private void ShowGoInventory(DataGridView dgv, DataGridViewColumn Pcode, DataGridViewColumn ProductName, DataGridViewColumn BRate, DataGridViewColumn Qty, DataGridViewColumn Unit, string searchdata = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                searchdata = textBox1.Text.ToString();
                if (searchdata.ToString() != "")
                {
                    cmd = new SqlCommand("select p.Pcode, p.ProductName,i.BaseRate,i.st_Qty,i.st_Unit from Stocks i inner join Products p on p.Pcode = i.st_Pcode where p.ProductName like '%" + searchdata.ToString() + "%' order by Pcode", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.Pcode, p.ProductName,i.BaseRate,i.st_Qty,i.st_Unit from Stocks i inner join Products p on p.Pcode = i.st_Pcode order by Pcode", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Pcode.DataPropertyName = dt.Columns["Pcode"].ToString();
                ProductName.DataPropertyName = dt.Columns["ProductName"].ToString();
                BRate.DataPropertyName = dt.Columns["BaseRate"].ToString();
                Qty.DataPropertyName = dt.Columns["st_Qty"].ToString();
                Unit.DataPropertyName = dt.Columns["st_Unit"].ToString();
                dgv.DataSource = dt;
                LoadTotalStock();

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowShopInventory(DataGridView dgv, DataGridViewColumn Pcode, DataGridViewColumn ProductName, DataGridViewColumn BRate, DataGridViewColumn Qty, DataGridViewColumn Unit, string searchata = null)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = null;
                searchata = txtSearch.Text.ToString();
                if (searchata.ToString() == "")
                {
                    cmd = new SqlCommand("select p.Pcode, p.ProductName,i.BaseRate,i.sh_Qty,i.sh_Unit from ShopStocks i inner join Products p on p.Pcode = i.sh_Pcode order by Pcode", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.Pcode, p.ProductName,i.BaseRate,i.sh_Qty,i.sh_Unit from ShopStocks i inner join Products p on p.Pcode = i.sh_Pcode where p.ProductName like '%" + searchata.ToString() + "%' order by Pcode", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Pcode.DataPropertyName = dt.Columns["Pcode"].ToString();
                ProductName.DataPropertyName = dt.Columns["ProductName"].ToString();
                BRate.DataPropertyName = dt.Columns["BaseRate"].ToString();
                Qty.DataPropertyName = dt.Columns["sh_Qty"].ToString();
                Unit.DataPropertyName = dt.Columns["sh_Unit"].ToString();
                dgv.DataSource = dt;
               LoadTotalShopStock();
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
            Dashboard isi = new Dashboard();
            MainClass.showWindow(isi, this, MDI.ActiveForm);
        }

        public void Delete0Ones()
        {

            if (dgInventoryS.Rows.Count > 0)
            {
                foreach (DataGridViewRow dataGridViewRow in dgInventoryS.Rows)
                {
                    if (dataGridViewRow.Cells["shQty"].Value.ToString() == "0")
                    {
                        dgInventoryS.Rows.Remove(dataGridViewRow);
                    }
                }
            }
            if (dgvInventory.Rows.Count > 0)
            {
                foreach (DataGridViewRow dataGridViewRow in dgvInventory.Rows)
                {
                    if (dataGridViewRow.Cells["stQty"].Value.ToString() == "0")
                    {
                        dgvInventory.Rows.Remove(dataGridViewRow);
                    }
                }
            }

        }


        private void LoadTotalStock()
        {
            object totalstocks = null;
            SqlCommand cmd = null;
            int total = 0;


            cmd = new SqlCommand("select sum(st_Qty*1.0*BaseRate ) from Stocks", MainClass.con);
            totalstocks = cmd.ExecuteScalar().ToString();
            if (totalstocks.ToString() != "")
            {
                total += int.Parse(totalstocks.ToString());
            }
            txtttotstock.Text = total.ToString();
        }

       private void LoadTotalShopStock()
       {
           object totalstocks = null;
           SqlCommand cmd = null;
           int total = 0;
           foreach (DataGridViewRow item in dgvInventory.Rows)
           {

               cmd = new SqlCommand("select sum(sh_Qty*1.0*BaseRate ) from ShopStocks", MainClass.con);
               totalstocks = cmd.ExecuteScalar().ToString();
               if (totalstocks.ToString() != "")
               {
                   total += int.Parse(totalstocks.ToString());
               }
               txtTotal.Text = total.ToString();

           }
       }

        private void ShopInventory_Load(object sender, EventArgs e)
        {
            ShowGoInventory(dgvInventory, stPcode, StName, stRate, stQty, stUnit);
            ShowShopInventory(dgInventoryS, shPcode, shName, shRate, shQty, shUnit);
            Delete0Ones();
        }







        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ShowGoInventory(dgvInventory, stPcode, StName, stRate, stQty, stUnit);
            Delete0Ones();
        }

       private void btnScrapItems_Click(object sender, EventArgs e)
       {
           ScrapItems scr = new ScrapItems();
           scr.ShowDialog();
       }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            ShowShopInventory(dgInventoryS, shPcode, shName, shRate, shQty, shUnit);
            Delete0Ones();
        }
    }
}
