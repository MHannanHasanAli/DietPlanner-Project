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
    public partial class Transfer : Form
    {

        public Transfer()
        {
            InitializeComponent();
        }
        private void Transfer_Load(object sender, EventArgs e)
        {
            ShowGoInventory(DgvInventory, PcodeGV, ProductGV, QtyGV, UnitGV,BaseRateGV);
        }

        private void ShowGoInventory(DataGridView dgv, DataGridViewColumn Pcode, DataGridViewColumn ProductName, DataGridViewColumn Qty, DataGridViewColumn Unit, DataGridViewColumn BaseRate)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select p.Pcode, p.ProductName,i.st_Qty as 'Qty',i.st_Unit as 'Unit',i.BaseRate from Stocks i inner join Products p on p.Pcode = i.st_Pcode order by Pcode", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Pcode.DataPropertyName = dt.Columns["Pcode"].ToString();
                ProductName.DataPropertyName = dt.Columns["ProductName"].ToString();
                Qty.DataPropertyName = dt.Columns["Qty"].ToString();
                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                BaseRate.DataPropertyName = dt.Columns["BaseRate"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            Delete0Ones();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }

        
        private void DgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblPcode.Text = DgvInventory.CurrentRow.Cells[0].Value.ToString();
            txtProduct.Text = DgvInventory.CurrentRow.Cells[1].Value.ToString();
            txtQty.Text = DgvInventory.CurrentRow.Cells[2].Value.ToString();
            txtUnit.Text = DgvInventory.CurrentRow.Cells[3].Value.ToString();
            lblBaseRate.Text = DgvInventory.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtQty.Text.ToString()) > int.Parse(lblInGodown.Text))
            {
                MessageBox.Show("Not Enough Stocks");
                return;
            }
            if (txtProduct.Text != "" || txtQty.Text == "" || txtUnit.Text == "")
            {
                // int quantity;
                DataGridViewRow createrow = new DataGridViewRow();
                createrow.CreateCells(DGVTransfer);
                createrow.Cells[0].Value = lblPcode.Text;
                createrow.Cells[1].Value = txtProduct.Text;
                createrow.Cells[2].Value = txtQty.Text;
                createrow.Cells[3].Value = txtUnit.Text;
                createrow.Cells[4].Value = cboType.Text;
                createrow.Cells[5].Value = lblBaseRate.Text;
                DGVTransfer.Rows.Add(createrow);
                ClearF();
            }
            else
            {
                MessageBox.Show("Please Select Product");
                return;
            }
            Delete0Ones();
            CalculateTransfertotal();
        }

        private void CalculateTransfertotal()
        {
            float total = 0;
            foreach (DataGridViewRow item in DGVTransfer.Rows)
            {
                MainClass.con.Open();
                SqlCommand cmd = null;
                cmd = new SqlCommand("select BaseQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                object baseqt = cmd.ExecuteScalar();

                cmd = new SqlCommand("select DefaultQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                object defqty = cmd.ExecuteScalar();

                cmd = new SqlCommand("select SubQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                object subq = cmd.ExecuteScalar();


                MainClass.con.Close();
                if (cboType.Text == "Base")
                {
                    total += float.Parse(item.Cells[5].Value.ToString()) * float.Parse(baseqt.ToString()) * float.Parse(item.Cells[2].Value.ToString());
                }
                else if(cboType.Text == "Default")
                {
                    total += float.Parse(item.Cells[5].Value.ToString()) * float.Parse(defqty.ToString()) * float.Parse(item.Cells[2].Value.ToString());
                }
                else
                {
                    total += float.Parse(item.Cells[5].Value.ToString()) * float.Parse(subq.ToString()) * float.Parse(item.Cells[2].Value.ToString());
                }
            }
            txtTransferTotal.Text = total.ToString();
        }

        private string[] ProductsData = new string[6];
        object BaseU = null;
        object DefaultU = null;
        object SubU = null;
        object BaseQty = null;
        object DefaultQty = null;
        object stockqty = null;
        object SubQty = null;
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select BaseU,DefaultU,SubU,BaseQty,DefaultQty,SubQty from Products where ProductName = '" + txtProduct.Text.ToString() + "' ", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProductsData[0] = dr[0].ToString();
                        ProductsData[1] = dr[1].ToString();
                        ProductsData[2] = dr[2].ToString();
                        ProductsData[3] = dr[3].ToString();
                        ProductsData[4] = dr[4].ToString();
                        ProductsData[5] = dr[5].ToString();
                        BaseU = ProductsData[0].ToString();
                        DefaultU = ProductsData[1].ToString();
                        SubU = ProductsData[2].ToString();
                        BaseQty = ProductsData[3].ToString();
                        DefaultQty = ProductsData[4].ToString();
                        SubQty = ProductsData[5].ToString();
                    }
                    if (cboType.Text == "Base")
                    {
                        txtUnit.Text = BaseU.ToString();
                    }
                    else if (cboType.Text == "Default")
                    {
                        txtUnit.Text = DefaultU.ToString();
                    }
                    else if (cboType.Text == "Sub")
                    {
                        txtUnit.Text = SubU.ToString();
                    }

                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select st_Qty from Stocks where st_Pcode = (select Pcode from Products where ProductName = '" + txtProduct.Text.ToString() + "')", MainClass.con);
                stockqty = cmd.ExecuteScalar();
                if (cboType.Text == "Base")
                {
                    stockqty = int.Parse(stockqty.ToString()) / int.Parse(BaseQty.ToString());
                }
                else if (cboType.Text == "Default")
                {
                    if (DefaultQty.ToString() == "0")
                    {
                        stockqty = 0;
                    }
                    else
                    {
                        stockqty = int.Parse(stockqty.ToString()) / int.Parse(DefaultQty.ToString());
                    }
                }

                if (cboType.Text == "Sub")
                {
                    if (SubQty.ToString() == "0")
                    {
                        stockqty = 0;
                    }
                    else
                    {
                        stockqty = int.Parse(stockqty.ToString()) / int.Parse(SubQty.ToString());
                    }
                }
                lblInGodown.Text = stockqty.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } //Get Stock Qty

        }


        private void btnTransfer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            object stockqty = null;
            object shopqty = null;
            object baseunit = null;
            object baseqty = null;
            object defaultqty = null;
            object subqty = null;
            int baseunitID = 0;
            object baserate = null;
            MainClass.con.Open();
            foreach (DataGridViewRow item in DGVTransfer.Rows)
            {
                try
                {
                    cmd = new SqlCommand("select st_Qty from Stocks where st_Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    stockqty = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } //Get Stock Qty
                try
                {
                    cmd = new SqlCommand("select sh_Qty from ShopStocks where sh_Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    shopqty = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } //Get Shop Qty
                try
                {
                    cmd = new SqlCommand("select BaseU from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    baseunit = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } // get Base Unit


                try
                {
                    cmd = new SqlCommand("select BaseUnit from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    baseunitID = int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } // get Base Unit

                try
                {
                    cmd = new SqlCommand("select BaseQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    baseqty = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } // get Base Unit

                try
                {
                    cmd = new SqlCommand("select DefaultQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    defaultqty = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } // get Base Unit

                try
                {
                    cmd = new SqlCommand("select SubQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    subqty = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } // get Base Unit


                try
                {
                    cmd = new SqlCommand("select BaseCP from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                    baserate = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } //Get Base rate

                int q = Convert.ToInt32(stockqty);

                

                if (item.Cells[4].Value.ToString() == "Base")
                {
                    q -= int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(baseqty.ToString());
                }
                else if (item.Cells[4].Value.ToString() == "Default")
                {
                    q -= int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(defaultqty.ToString());
                }
                else if(item.Cells[4].Value.ToString() == "Sub")
                {
                    q -= int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(subqty.ToString());
                }
                else
                {
                    q -= int.Parse(item.Cells["QtyTGV"].Value.ToString());
                }
                MainClass.UpdateStock(int.Parse(item.Cells[0].Value.ToString()), q);

                int q2 = Convert.ToInt32(shopqty);
                if (shopqty == null)
                {
                    cmd = new SqlCommand("Insert into ShopStocks (sh_Pcode,BaseRate,sh_Qty,sh_Unit) values(@sh_Pcode,@BaseRate,@sh_Qty,@sh_Unit)", MainClass.con);
                    cmd.Parameters.AddWithValue("@sh_Pcode", item.Cells[0].Value.ToString());
                    if (item.Cells[4].Value.ToString() == "Base")
                    {
                        q2 += int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(baseqty.ToString());
                    }
                    else if (item.Cells[4].Value.ToString() == "Default")
                    {
                        q2 += int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(defaultqty.ToString());
                    }
                    else if (item.Cells[4].Value.ToString() == "Sub")
                    {
                        q2 += int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(subqty.ToString());
                    }
                    else
                    {
                        q2 += int.Parse(item.Cells["QtyTGV"].Value.ToString());
                    }
                    cmd.Parameters.AddWithValue("@sh_Qty", q2);
                    cmd.Parameters.AddWithValue("@BaseRate", baserate);
                    cmd.Parameters.AddWithValue("@sh_Unit", baseunit);
                    cmd.ExecuteNonQuery();
                } //Inserting
                else
                {
                    if (cboType.Text == "Base")
                    {
                        q2 += int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(baseqty.ToString());
                    }
                    else if (cboType.Text == "Default")
                    {
                        q2 += int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(defaultqty.ToString());
                    }
                    else
                    {
                        q2 += int.Parse(item.Cells["QtyTGV"].Value.ToString()) * int.Parse(subqty.ToString());
                    }
                    MainClass.UpdateShop(int.Parse(item.Cells[0].Value.ToString()), q2);
                } //Updating

                cmd = new SqlCommand("insert into Transfers (Pcode,TransferQty,FromWarehouseID,ToWarehouseID,TransferUnit,TransferTotal,Date) values (@Pcode,@TransferQty,@FromWarehouseID,@ToWarehouseID,@TransferUnit,@TransferTotal,@Date)", MainClass.con);
                cmd.Parameters.AddWithValue("@Pcode", int.Parse(item.Cells[0].Value.ToString()));
                cmd.Parameters.AddWithValue("@TransferQty", q2);
                cmd.Parameters.AddWithValue("@FromWarehouseID",1);
                cmd.Parameters.AddWithValue("@ToWarehouseID", 2);
                cmd.Parameters.AddWithValue("@TransferUnit", baseunitID);
                cmd.Parameters.AddWithValue("@TransferTotal",txtTransferTotal.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString());
                cmd.ExecuteNonQuery();

            }


            MainClass.con.Close();
            MessageBox.Show("DONE");
            ClearF();
        }



        private void Delete0Ones()
        {
            foreach (DataGridViewRow dataGridViewRow in DgvInventory.Rows)
            {
                if (dataGridViewRow.Cells[2].Value.ToString() == "0")
                {
                    DgvInventory.Rows.Remove(dataGridViewRow);
                }
            }
        }




        private void ClearF()
        {
            txtProduct.Text = "";
            txtQty.Text = "";
            txtUnit.Text = "";
            cboType.Text = "";
            lblInGodown.Text = "000";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            object stock = null;
            object ScrapQty = null;
            MainClass.con.Open();
            try
            {
                cmd = new SqlCommand("select st_Qty from Stocks where st_Pcode = (select Pcode from Products where ProductName = '" + txtProduct.Text.ToString() + "')", MainClass.con);
                stock = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //Stock

            int q = Convert.ToInt32(stock);
            if (cboType.Text == "Base")
            {
                q -= int.Parse(txtQty.Text.ToString()) * int.Parse(BaseQty.ToString());
            }
            else if (cboType.Text == "Default")
            {
                q -= int.Parse(txtQty.Text.ToString()) * int.Parse(DefaultQty.ToString());

            }
            else
            {
                q -= int.Parse(txtQty.Text.ToString()) * int.Parse(SubQty.ToString());
            }
            MainClass.UpdateStock(int.Parse(lblPcode.Text.ToString()), q);

            try
            {
                cmd = new SqlCommand("select SC_Qty from Scraps  where SC_Pcode = '" + lblPcode.Text.ToString() + "'", MainClass.con);
                ScrapQty = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } //Get Scrap Qty


            if (ScrapQty == null)
            {

                cmd = new SqlCommand("Insert into Scraps (SC_Pcode,SC_Qty,SC_Unit) values(@SC_Pcode,@SC_Qty,@SC_Unit)", MainClass.con);
                cmd.Parameters.AddWithValue("@SC_Pcode", lblPcode.Text);
                if (cboType.Text == "Base")
                {
                    cmd.Parameters.AddWithValue("@SC_Qty", int.Parse(txtQty.Text.ToString()) * int.Parse(BaseQty.ToString()));
                }
                else if (cboType.Text == "Default")
                {
                    cmd.Parameters.AddWithValue("@SC_Qty", int.Parse(txtQty.Text.ToString()) * int.Parse(DefaultQty.ToString()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SC_Qty", int.Parse(txtQty.Text.ToString()) * int.Parse(SubQty.ToString()));

                }
                cmd.Parameters.AddWithValue("@SC_Unit", BaseU);
                cmd.ExecuteNonQuery();
            }

            else //Updating Scrap
            {
                int q2 = Convert.ToInt32(ScrapQty);
                if (cboType.Text == "Base")
                {
                    q2 += int.Parse(txtQty.Text.ToString()) * int.Parse(BaseQty.ToString());
                }
                else if (cboType.Text == "Default")
                {
                    q2 += int.Parse(txtQty.Text.ToString()) * int.Parse(DefaultQty.ToString());

                }
                else
                {
                    q2 += int.Parse(txtQty.Text.ToString()) * int.Parse(SubQty.ToString());

                }
                MainClass.UpdateScrap(int.Parse(lblPcode.Text.ToString()), q2);
            }
            MessageBox.Show("DONE");
            MainClass.con.Close();
        }
    }
}


