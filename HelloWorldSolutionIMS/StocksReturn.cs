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
    public partial class StocksReturn : Form
    {
        bool productcheck = false;
        bool found = false;
        int scrap = 0;
        public StocksReturn()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            cboProductName.SelectedIndex = 0;
            cboWarehouse.SelectedIndex = 0;
            cboType.SelectedIndex = 0;

            if (txtQuantity.Text != "")
            {
                txtQuantity.TextChanged -= txtQuantity_TextChanged;
                txtQuantity.Clear();
                txtQuantity.TextChanged += txtQuantity_TextChanged;

            }

            if (txtPurchaseRate.Text != "")
            {
                txtPurchaseRate.TextChanged -= txtPurchaseRate_TextChanged;
                txtPurchaseRate.Clear();
                txtPurchaseRate.TextChanged += txtPurchaseRate_TextChanged;

            }

            if (txtProductTot.Text != "")
            {
                txtProductTot.TextChanged -= txtProductTot_TextChanged;
                txtProductTot.Clear();
                txtProductTot.TextChanged += txtProductTot_TextChanged;

            }
        }

        private void StocksReturn_Load(object sender, EventArgs e)
        {
            MainClass.FillCustomer(cboPerson);
            MainClass.FillWarehouses(cboWarehouse);
            MainClass.FillProducts2Sal(cboProductName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "" && txtQuantity.Text != "0")
            {
                Int32 rate = Convert.ToInt32(txtPurchaseRate.Text);
                int qty;
                int.TryParse(txtQuantity.Text.Trim(), out qty);
                txtProductTot.Text = Convert.ToString(qty * rate);
            }
            else
            {
                txtProductTot.Text = "0";
            }
        }

        private void txtPurchaseRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductTot_TextChanged(object sender, EventArgs e)
        {

        }

        private string[] ProductsData = new string[3];

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {

            object stocks = "";
            if (cboProductName.SelectedIndex != 0)
            {
                SqlDataReader dr;
                if (cboType.Text == "Base")
                {
                    try
                    {
                        MainClass.con.Open();
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("select BaseCP,BaseU,BaseSP from Products where Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[0] = dr[0].ToString();
                                ProductsData[1] = dr[1].ToString();
                                ProductsData[2] = dr[2].ToString();
                                found = true;
                                txtPurchaseRate.Text = ProductsData[0].ToString();
                                txtUnit.Text = ProductsData[1].ToString();
                                lblSaleRates.Text = ProductsData[2].ToString();
                            }
                        }

                        dr.Close();
                        if (cboType.Text == "Base")
                        {
                            if (cboWarehouse.Text == "Godown")
                            {
                                cmd = new SqlCommand("select i.st_Qty/pm.BaseQty as 'Qty' from Products pm inner join Stocks i on i.st_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else
                            {
                                cmd = new SqlCommand("select i.sh_Qty/pm.BaseQty as 'Qty' from Products pm inner join ShopStocks i on i.sh_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            stocks = cmd.ExecuteScalar();

                        }

                        if (stocks == null)
                        {
                            txtStockInfo.Text = "0";
                        }
                        else
                        {
                            txtStockInfo.Text = stocks.ToString();
                        }
                        MainClass.con.Close();
                    }


                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                if (cboType.Text == "Default")
                {
                    try
                    {
                        MainClass.con.Open();
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("select DefaultCP,DefaultU,DefaultSP from Products where Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[0] = dr[0].ToString();
                                ProductsData[1] = dr[1].ToString();
                                ProductsData[2] = dr[2].ToString();
                                found = true;
                                txtPurchaseRate.Text = ProductsData[0].ToString();
                                txtUnit.Text = ProductsData[1].ToString();
                                lblSaleRates.Text = ProductsData[2].ToString();
                            }
                        }
                        dr.Close();
                        if (cboType.Text == "Default")
                        {

                            if (cboWarehouse.Text == "Godown")
                            {
                                cmd = new SqlCommand("select i.st_Qty/pm.DefaultQty as 'Qty' from Products pm inner join Stocks i on i.st_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else
                            {
                                cmd = new SqlCommand("select i.sh_Qty/pm.DefaultQty as 'Qty' from Products pm inner join ShopStocks i on i.sh_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            stocks = cmd.ExecuteScalar();

                        }
                        if (stocks == null)
                        {
                            txtStockInfo.Text = "0";
                        }
                        else
                        {
                            txtStockInfo.Text = stocks.ToString();
                        }
                        MainClass.con.Close();
                    }


                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                if (cboType.Text == "Sub")
                {
                    try
                    {
                        MainClass.con.Open();
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("select SubCP,SubU,SubSP from Products where Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[0] = dr[0].ToString();
                                ProductsData[1] = dr[1].ToString();
                                ProductsData[2] = dr[2].ToString();
                                found = true;
                                txtPurchaseRate.Text = ProductsData[0].ToString();
                                txtUnit.Text = ProductsData[1].ToString();
                                lblSaleRates.Text = ProductsData[2].ToString();
                            }
                        }
                        dr.Close();
                        if (cboType.Text == "Sub")
                        {

                            if (cboWarehouse.Text == "Godown")
                            {
                                cmd = new SqlCommand("select i.st_Qty/pm.SubQty as 'Qty' from Products pm inner join Stocks i on i.st_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else
                            {
                                cmd = new SqlCommand("select i.sh_Qty/pm.SubQty as 'Qty' from Products pm inner join ShopStocks i on i.sh_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            stocks = cmd.ExecuteScalar();

                        }
                        if (stocks == null)
                        {
                            txtStockInfo.Text = "0";
                        }
                        else
                        {
                            txtStockInfo.Text = stocks.ToString();
                        }
                        MainClass.con.Close();
                    }


                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtProductTot.Text == "0" || txtProductTot.Text == "")
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txtPurchaseRate.Text == "")
                {
                    MessageBox.Show("Please Get Rate", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                float quantity;
                float totalofproduct, grandtotal, puchaserate, salerate;

                float.TryParse(txtQuantity.Text.Trim(), out quantity);
                float.TryParse(txtPurchaseRate.Text.Trim(), out puchaserate);
                float.TryParse(lblSaleRates.Text.Trim(), out salerate);
                float.TryParse(txtProductTot.Text.Trim(), out totalofproduct);
                float.TryParse(txtGrandTotal.Text.Trim(), out grandtotal);



                if (dgvPurchaseItems.Rows.Count == 0)
                {
                    DataGridViewRow createrow = new DataGridViewRow();
                    createrow.CreateCells(dgvPurchaseItems);
                    createrow.Cells[0].Value = cboProductName.SelectedValue;
                    createrow.Cells[1].Value = cboProductName.Text;
                    createrow.Cells[2].Value = cboWarehouse.SelectedValue;
                    createrow.Cells[3].Value = cboWarehouse.Text;
                    createrow.Cells[4].Value = quantity;
                    createrow.Cells[5].Value = txtUnit.Text;
                    createrow.Cells[6].Value = puchaserate;
                    createrow.Cells[7].Value = totalofproduct;
                    createrow.Cells[8].Value = cboPerson.SelectedValue;
                    createrow.Cells[9].Value = cboPerson.Text;
                    createrow.Cells[12].Value = cboType.Text;
                    createrow.Cells[11].Value = salerate;
                    dgvPurchaseItems.Rows.Add(createrow);
                    cboProductName.Focus();
                }
                else
                {
                    foreach (DataGridViewRow check in dgvPurchaseItems.Rows)
                    {
                        if (Convert.ToString(check.Cells[0].Value) == Convert.ToString(cboProductName.SelectedValue) &&
                            Convert.ToString(check.Cells[5].Value) == Convert.ToString(cboType.SelectedValue))
                        {
                            productcheck = true;
                        }
                    }
                    if (productcheck == true)
                    {
                        foreach (DataGridViewRow row in dgvPurchaseItems.Rows)
                        {
                            if (Convert.ToString(row.Cells[0].Value) == Convert.ToString(cboProductName.SelectedValue))
                            {
                                row.Cells["QtyGVC"].Value = float.Parse(row.Cells["QtyGVC"].Value.ToString()) + quantity;
                                row.Cells["TotalGV"].Value = float.Parse(row.Cells["QtyGVC"].Value.ToString()) * Convert.ToInt32(row.Cells["PurchaseRateGVC"].Value.ToString());
                                ClearForm();
                            }
                        }
                    }
                    else
                    {
                        if (productcheck == false)
                        {
                            DataGridViewRow createrow = new DataGridViewRow();
                            createrow.Cells[0].Value = cboProductName.SelectedValue;
                            createrow.Cells[1].Value = cboProductName.Text;
                            createrow.Cells[2].Value = cboWarehouse.SelectedValue;
                            createrow.Cells[3].Value = cboWarehouse.Text;
                            createrow.Cells[4].Value = quantity;
                            createrow.Cells[5].Value = txtUnit.Text;
                            createrow.Cells[6].Value = puchaserate;
                            createrow.Cells[7].Value = totalofproduct;
                            createrow.Cells[8].Value = cboPerson.SelectedValue;
                            createrow.Cells[9].Value = cboPerson.Text;
                            createrow.Cells[12].Value = cboType.Text;
                            createrow.Cells[11].Value = salerate;
                            dgvPurchaseItems.Rows.Add(createrow);
                            cboProductName.Focus();
                        }
                    }
                }
            }
            FindTotal();
            ClearForm();
        }


        private void FindTotal()
        {
            int gross = 0;
            if (dgvPurchaseItems.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPurchaseItems.Rows)
                {
                    gross += Convert.ToInt32(row.Cells["TotalGV"].Value.ToString());
                }
                txtGrandTotal.Text = Convert.ToString(gross);
            }
            else
            {
                txtGrandTotal.Text = "0";
            }
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {


            SqlCommand cmd = null;
            object baseqty = null;
            object defaultqty = null;
            object ScrapQty = null;
            object subqty = null;
            object stockqty = null;
            object shopqty = null;
            object baserate = null;
            object defaultrate = null;
            object subrate = null;
            object unittxt = null;
            object baseunit = null;



            if (cboPerson.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Person");
                return;
            }

            if (dgvPurchaseItems.Rows.Count == 0)
            {
                MessageBox.Show("Please Enter Product In Cart");
                return;
            }
            else
            {
                string invoiceno = "RET" + DateTime.Now.ToString("yyddff");
                float grandtotal = float.Parse(txtGrandTotal.Text.ToString());
                MainClass.con.Open();
                try
                {
                    string InsertReturn = "insert into StockReturn (InvoiceNo,PersonID,ReturnDate,ReturnTotal) values (@InvoiceNo,@PersonID,@ReturnDate,@ReturnTotal)";
                    cmd = new SqlCommand(InsertReturn, MainClass.con);
                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                    cmd.Parameters.AddWithValue("@PersonID", cboPerson.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ReturnDate", dtReturn.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@ReturnTotal", txtGrandTotal.Text.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } //Insert Return

                string ReturnID = Convert.ToString(MainClass.Retrieve("select MAX(StockReturnID) from StockReturn").Rows[0][0]);
                if (string.IsNullOrEmpty(ReturnID))
                {
                    MessageBox.Show("Please Check The Error or Try Again");
                    return;
                }

                try
                {
                    foreach (DataGridViewRow products in dgvPurchaseItems.Rows)
                    {
                        try
                        {
                            cmd = new SqlCommand("select UnitID from Units where UnitName = '" + products.Cells[5].Value.ToString() + "'", MainClass.con);
                            unittxt = cmd.ExecuteScalar().ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        }

                        string InsertReturnDetails = "insert into ReturnStocksDetails (StockReturn_ID,Product_ID,Warehouse_ID,ReturnQty,SaleRate,UnitType,Unit,PurchaseRate,TotalofProduct) values (@StockReturn_ID,@Product_ID,@Warehouse_ID,@ReturnQty,@SaleRate,@UnitType,@Unit,@PurchaseRate,@TotalofProduct)";
                        cmd = new SqlCommand(InsertReturnDetails, MainClass.con);
                        cmd.Parameters.AddWithValue("@StockReturn_ID", ReturnID);
                        cmd.Parameters.AddWithValue("@Warehouse_ID", products.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Product_ID", products.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@ReturnQty", products.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@UnitType", products.Cells[12].Value);
                        cmd.Parameters.AddWithValue("@Unit", unittxt);
                        cmd.Parameters.AddWithValue("@PurchaseRate", products.Cells[6].Value);
                        cmd.Parameters.AddWithValue("@TotalofProduct", products.Cells[7].Value);
                        cmd.Parameters.AddWithValue("@SaleRate", products.Cells[11].Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } //Inserting Products
                try
                {
                    foreach (DataGridViewRow item in dgvPurchaseItems.Rows)
                    {
                        try
                        {
                            cmd = new SqlCommand("select BaseQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            baseqty = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Get Base Qty
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
                            cmd = new SqlCommand("select BaseCP from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            baserate = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Get Base rate

                        try
                        {
                            cmd = new SqlCommand("select DefaultCP from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            defaultrate = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Get Default rate
                        try
                        {
                            cmd = new SqlCommand("select DefaultQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            defaultqty = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } // Get Default Qty

                        try
                        {
                            cmd = new SqlCommand("select SubCP from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            subrate = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } // Get Sub Rate
                        try
                        {
                            cmd = new SqlCommand("select SubQty from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            subqty = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } // Get Sub Qty

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
                            cmd = new SqlCommand("select SC_Qty from Scraps  where SC_Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            ScrapQty = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Get Scrap Qty




                        if (item.Cells["WarehouseID"].Value.ToString() == "2")//Shop
                        {


                            if (MessageBox.Show("Add Product " + item.Cells["ProductNameGVC"].Value.ToString() + " IN SCRAP??", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (ScrapQty == null)
                                {

                                    cmd = new SqlCommand("Insert into Scraps (SC_Pcode,SC_Qty,SC_Unit) values(@SC_Pcode,@SC_Qty,@SC_Unit)", MainClass.con);
                                    cmd.Parameters.AddWithValue("@SC_Pcode", item.Cells[0].Value.ToString());
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        cmd.Parameters.AddWithValue("@SC_Qty", int.Parse(item.Cells[4].Value.ToString()) * int.Parse(baseqty.ToString()));
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        cmd.Parameters.AddWithValue("@SC_Qty", int.Parse(item.Cells[4].Value.ToString()) * int.Parse(defaultqty.ToString()));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@SC_Qty", int.Parse(item.Cells[4].Value.ToString()) * int.Parse(subqty.ToString()));

                                    }
                                    cmd.Parameters.AddWithValue("@SC_Unit", baseunit);
                                    cmd.ExecuteNonQuery();
                                }
                                else //Updating Scrap
                                {
                                    int q = Convert.ToInt32(ScrapQty);
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q += int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(baseqty.ToString());
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q += int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q += int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(subqty.ToString());

                                    }
                                    MainClass.UpdateScrap(int.Parse(item.Cells[0].Value.ToString()), q);
                                }
                            }
                            else
                            {
                                int q = Convert.ToInt32(shopqty);
                                if (shopqty == null)
                                {
                                    try
                                    {
                                        cmd = new SqlCommand("Insert into ShopStocks (sh_Pcode,sh_Qty,sh_Unit,BaseRate) values(@sh_Pcode,@sh_Qty,@sh_Unit,@BaseRate)", MainClass.con);
                                        cmd.Parameters.AddWithValue("@sh_Pcode", item.Cells[0].Value.ToString());
                                        if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                        {
                                            cmd.Parameters.AddWithValue("@sh_Qty", int.Parse(item.Cells[4].Value.ToString()) * int.Parse(baseqty.ToString()));
                                        }
                                        else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                        {
                                            cmd.Parameters.AddWithValue("@sh_Qty", int.Parse(item.Cells[4].Value.ToString()) * int.Parse(defaultqty.ToString()));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@sh_Qty", int.Parse(item.Cells[4].Value.ToString()) * int.Parse(subqty.ToString()));

                                        }
                                        cmd.Parameters.AddWithValue("@sh_Unit", baseunit);
                                        cmd.Parameters.AddWithValue("@BaseRate", baserate);
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {


                                        MessageBox.Show(ex.Message);
                                        MainClass.con.Close();
                                    }
                                }
                                else
                                {

                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q += int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(baseqty.ToString());
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q += int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q += int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(subqty.ToString());

                                    }
                                    MainClass.UpdateShop(int.Parse(item.Cells[0].Value.ToString()), q);
                                }
                            }

                        }
                        MessageBox.Show("Stocks Returned Successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }//Updating Stocks


                MainClass.con.Close();
            }

        }
    }
}
