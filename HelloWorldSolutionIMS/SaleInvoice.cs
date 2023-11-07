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
using System.Drawing.Printing;
using EasyTabs;

namespace HelloWorldSolutionIMS
{
    public partial class SaleInvoice : Form
    {
        bool productcheck = false;
        int scrap = 0;
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }
        public SaleInvoice()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void SaleInvoice_Load(object sender, EventArgs e)
        {
            MainClass.FillCustomer(cboCustomer);
            MainClass.FillProducts2Sal(cboProductName);
            MainClass.FillWarehouses(cboWarehouse);
            cboInvoiceType.SelectedIndex = 0;
        }

       


        private void cboCustomer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex != 0)
            {
                float inopening = 0;
                float insales = 0;
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select PersonPhone from Persons where PersonID = '" + cboCustomer.SelectedValue + "' and PersonType = '2'", MainClass.con);
                    txtContactNo.Text = cmd.ExecuteScalar().ToString();
                    MainClass.con.Close();
                    txtCustomerName.Text = cboCustomer.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } //Person Contact
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select sum(DueAmount) from OpeningAccounts where PesonType_ID = '2' and  PersonName_ID = '" + cboCustomer.SelectedValue.ToString() + "'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if (ob.ToString() != "")
                    {
                        inopening = float.Parse(ob.ToString());
                        txtInOpenbalances.Text = inopening.ToString();
                    }
                    else
                    {
                        txtInOpenbalances.Text = "0";
                    }
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } // In opening
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select sum(RemainingBalance)from CustomerLedgers where Customer_ID = '" + cboCustomer.SelectedValue.ToString() + "'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if (ob != null && ob.ToString() != "")
                    {
                        insales = float.Parse(ob.ToString());
                        txtInSalesLedgers.Text = insales.ToString();
                    }
                    else
                    {
                        txtInSalesLedgers.Text = "0";
                    }
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } // In Sales
                txtTotalBalance.Text = (inopening + insales).ToString();

            }
            else
            {
                txtContactNo.Text = "";
                txtInOpenbalances.Text = "";
                txtInSalesLedgers.Text = "";
                txtTotalBalance.Text = "";
            }
        }

        private void CheckScrap()
        {
            if (cboWarehouse.SelectedValue.ToString() == "3")
            {
                scrap = 1;
            }
        }
        float txtstk = 0;
        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cboProductName.SelectedIndex != 0)
            {
                SqlCommand cmd = null;
                try
                {
                    object stockqty = null;
                    MainClass.con.Open();
                   
                    cmd = new SqlCommand("select sh_Qty  from ShopStocks where sh_Pcode = '" + cboProductName.SelectedValue + "'    ", MainClass.con);
                    stockqty = cmd.ExecuteScalar();

                    if (stockqty == null)
                    {
                        lblInStock.Text = "No";
                    }
                    else
                    {
                        if (stockqty.ToString() == "0")
                        {
                            lblInStock.Text = "No";
                        }
                        else
                        {
                            lblInStock.Text = "Yes";
                        }
                    }
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }


            }

        } 

        private string[] ProductsData = new string[4];
        

        private void CompleteClear()
        {
            ClearForm();
            txtCustomerName.Text = "";
            txtInvoiceType.Text = "";
            txtTotalAmount.Text = "";
            txtPayingAmount.Text = "";
            txtTotalBalance.Text = "";
            txtRemainingAmount.Text = "";
            txtGrandTotal.Text = "";
            dtInvoice.Value = DateTime.Now;
            txtInOpenbalances.Text = "";
            txtInSalesLedgers.Text = "";
            lblInStock.Text = "";
            cboCustomer.SelectedIndex = 0;
            dgvSaleItems.Rows.Clear();
            cboCustomer.Focus();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "" && txtQuantity.Text != "0")
            {
                Int32 rate = Convert.ToInt32(txtSaleRate.Text);
                int qty;
                int.TryParse(txtQuantity.Text.Trim(), out qty);
                txtProductTot.Text = Convert.ToString(qty * rate);
            }
            else
            {
                txtProductTot.Text = "0";
            }
        }

        private void del()
        {
            if (txtDiscountAmount.Text != "" && txtDiscountAmount.Text != "0")
            {
                float gd = 0;
                foreach (DataGridViewRow item in dgvSaleItems.Rows)
                {
                    gd += float.Parse(item.Cells["TotalGV"].Value.ToString());
                }
                float disc;
                float tot;
                disc = float.Parse(txtDiscountAmount.Text.ToString());
                tot = gd - disc;
                txtGrandTotal.Text = tot.ToString();
            }
            else
            {
                float gd = 0;
                foreach (DataGridViewRow item in dgvSaleItems.Rows)
                {
                    gd += float.Parse(item.Cells[8].Value.ToString());
                }
                txtGrandTotal.Text = Convert.ToString(gd);
            }


        }

      

        private void ClearForm()
        {
            cboProductName.SelectedIndex = 0;
            cboWarehouse.SelectedIndex = 0;
           
            if (txtQuantity.Text != "")
            {
                txtQuantity.TextChanged -= txtQuantity_TextChanged;
                txtQuantity.Clear();
                txtQuantity.TextChanged += txtQuantity_TextChanged;

            }

            if (txtSaleRate.Text != "")
            {
                txtSaleRate.TextChanged -= txtSaleRate_TextChanged;
                txtSaleRate.Clear();
                txtSaleRate.TextChanged += txtSaleRate_TextChanged;

            }

            if (txtProductTot.Text != "")
            {
                txtProductTot.TextChanged -= txtProductTot_TextChanged;
                txtProductTot.Clear();
                txtProductTot.TextChanged += txtProductTot_TextChanged;

            }
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtProductTot.Text == "" || txtProductTot.Text == "0")
            {
                MessageBox.Show("Check Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (float.Parse(txtQuantity.Text) > float.Parse(txtStockInfo.Text))
            {
                MessageBox.Show("Not Enough Stock", "Low Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtProductTot.Text == "0")
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txtSaleRate.Text == "")
                {
                    MessageBox.Show("Please Get Rate", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                float quantity;
                int discount, totalofproduct, grandtotal, SaleRate, PurchaseRate;

                float.TryParse(txtQuantity.Text.Trim(), out quantity);
                int.TryParse(txtDiscountAmount.Text.Trim(), out discount);
                int.TryParse(txtSaleRate.Text.Trim(), out SaleRate);
                int.TryParse(txtProductTot.Text.Trim(), out totalofproduct);
                int.TryParse(txtGrandTotal.Text.Trim(), out grandtotal);
                int.TryParse(lblPurchaseRates.Text.Trim(), out PurchaseRate);

                object unitt = null;
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select UnitID from Units where UnitName = '" + txtUnit.Text + "'", MainClass.con);
                    unitt = cmd.ExecuteScalar().ToString();
                    MainClass.con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }


                if (dgvSaleItems.Rows.Count == 0)
                {
                    DataGridViewRow createrow = new DataGridViewRow();
                    createrow.CreateCells(dgvSaleItems);
                    createrow.Cells[0].Value = cboProductName.SelectedValue;
                    createrow.Cells[1].Value = cboProductName.Text;
                    createrow.Cells[2].Value = cboWarehouse.SelectedValue;
                    createrow.Cells[3].Value = cboWarehouse.Text;
                    createrow.Cells[4].Value = quantity;
                    createrow.Cells[5].Value = unitt;
                    createrow.Cells[6].Value = txtUnit.Text;
                    createrow.Cells[7].Value = SaleRate;
                    createrow.Cells[8].Value = totalofproduct;
                    createrow.Cells[9].Value = PurchaseRate;
                    createrow.Cells[10].Value = cboType.Text;



                    dgvSaleItems.Rows.Add(createrow);
                    ClearForm();
                    cboProductName.Focus();
                }
                else
                {
                    foreach (DataGridViewRow check in dgvSaleItems.Rows)
                    {
                        if (Convert.ToString(check.Cells[0].Value) == Convert.ToString(cboProductName.SelectedValue) &&
                            Convert.ToString(check.Cells[5].Value) == Convert.ToString(cboType.SelectedValue))
                        {
                            productcheck = true;
                            break;
                        }
                        else
                        {
                            productcheck = false;
                        }
                    }
                    if (productcheck == true)
                    {
                        foreach (DataGridViewRow row in dgvSaleItems.Rows)
                        {
                            if (Convert.ToString(row.Cells[0].Value) == Convert.ToString(cboProductName.SelectedValue))
                            {
                                row.Cells["QtyGVC"].Value = float.Parse(row.Cells["QtyGVC"].Value.ToString()) + quantity;
                                row.Cells["TotalGV"].Value = float.Parse(row.Cells["QtyGVC"].Value.ToString()) * Convert.ToInt32(row.Cells["SaleRateGVC"].Value.ToString());
                                ClearForm();
                            }
                        }
                    }
                    else
                    {
                        if (productcheck == false)
                        {
                            DataGridViewRow createrow = new DataGridViewRow();
                            createrow.CreateCells(dgvSaleItems);
                            createrow.Cells[0].Value = cboProductName.SelectedValue;
                            createrow.Cells[1].Value = cboProductName.Text;
                            createrow.Cells[2].Value = cboWarehouse.SelectedValue;
                            createrow.Cells[3].Value = cboWarehouse.Text;
                            createrow.Cells[4].Value = quantity;
                            createrow.Cells[5].Value = unitt;
                            createrow.Cells[6].Value = txtUnit.Text;
                            createrow.Cells[7].Value = SaleRate;
                            createrow.Cells[8].Value = totalofproduct;
                            createrow.Cells[9].Value = PurchaseRate;
                            createrow.Cells[10].Value = cboType.Text;

                            dgvSaleItems.Rows.Add(createrow);
                            ClearForm();
                            cboProductName.Focus();
                        }
                    }
                }
            }

            button1.PerformClick();
        }

        private void txtProductTot_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSaleRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float gross = 0;
            if (dgvSaleItems.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSaleItems.Rows)
                {
                    gross += Convert.ToInt32(row.Cells["TotalGV"].Value.ToString());
                }
                txtGrandTotal.Text = Convert.ToString(gross);
                txtTotalAmount.Text = Convert.ToString(gross);
                cboCustomer.Text = txtCustomerName.Text;
                if (cboInvoiceType.Text == "Cash")
                {
                    txtPayingAmount.Text = Convert.ToString(gross);
                }

            }
            if (txtPayingAmount.Text == "0" || txtPayingAmount.Text == "")
            {
                txtRemainingAmount.Text = gross.ToString();
            }
            del();
            del();
            
        }

        private void txtPayingAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPayingAmount.Text != "" || txtPayingAmount.Text == "0")
            {
                float tot = float.Parse(txtTotalAmount.Text);
                float paying = float.Parse(txtPayingAmount.Text);
                txtRemainingAmount.Text = Convert.ToString(tot - paying);
            }
            else
            {
                txtRemainingAmount.Text = txtTotalAmount.Text;
            }
        }

        private void dtInvoice_ValueChanged(object sender, EventArgs e)
        {
       //     txtDated.Text = dtInvoice.Text.ToString();
        }

        private void cboInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInvoiceType.Text = cboInvoiceType.Text;
            if (cboInvoiceType.Text == "Cash")
            {
                guna2GroupBox2.Visible = false;
            }
            else
            {
                guna2GroupBox2.Visible = true;
            }


        }

        private void dgvSaleItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if(e.ColumnIndex == 11)
                {
                    dgvSaleItems.Rows.RemoveAt(dgvSaleItems.CurrentRow.Index);
                }
            }
        }

       
        public static int SaleID = 0;
        public static string SALEINVOICENO;
        private void btnFinalize_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = null;
            object baseqty = null;
            object defaultqty = null;
            object subqty = null;
            object scrapqty = null;
            object stockqty = null;
            int customerinvoiceid;
            object shopqty = null;
            object baserate = null;
            object defaultrate = null;
            object subrate = null;
            object baseunit = null;
            if (cboInvoiceType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Invoice Type");
                return;
            }
            if (cboCustomer.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Customer");
                return;
            }
            if (dgvSaleItems.Rows.Count == 0)
            {
                MessageBox.Show("Please Enter Product In Cart");
                return;
            }
            else
            {

                if (btnFinalize.Text == "&FINALIZE")
                {
                    Random generator = new Random();
                    string invoiceno = "SAL" + generator.Next(0, 1000000).ToString("D6");
                    MainClass.con.Open();
                    cmd = new SqlCommand("select InvoiceNo from Sales where InvoiceNo  = '" + invoiceno + "'", MainClass.con);
                    object notunique = cmd.ExecuteScalar();
                    MainClass.con.Close();

                    if (notunique != null)
                    {
                        generator = new Random();
                        invoiceno = "SAL" + generator.Next(0, 1000000).ToString("D6");
                    }
                    button1.PerformClick();
                    int grandtotal = Convert.ToInt32(txtGrandTotal.Text.ToString());
                    MainClass.con.Open();
                    try
                    {
                        string InsertCustomerInvoice = "insert into CustomerInvoices (Customer_ID,PaymentType,InvoiceDate,Warehouse_ID) values (@Customer_ID,@PaymentType,@InvoiceDate,@Warehouse_ID)";
                        cmd = new SqlCommand(InsertCustomerInvoice, MainClass.con);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboCustomer.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PaymentType", cboInvoiceType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Warehouse_ID", dgvSaleItems.CurrentRow.Cells[2].Value);
                        cmd.ExecuteNonQuery();


                        ////Get Customer InvoiceID
                        string CustomerInvoiceID = Convert.ToString(MainClass.Retrieve("select MAX(CustomerInvoiceID) from CustomerInvoices").Rows[0][0]);
                        if (string.IsNullOrEmpty(CustomerInvoiceID))
                        {
                            MessageBox.Show("Please Check The Error or Try Again");
                            return;
                        }


                        //Inserting Sales
                        string InsertSales = "insert into Sales (InvoiceNo,CustomerInvoice_ID,GrandTotal,Discount) values (@InvoiceNo,@CustomerInvoice_ID,@GrandTotal,@Discount)";
                        SqlCommand cmd1 = new SqlCommand(InsertSales, MainClass.con);
                        cmd1.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd1.Parameters.AddWithValue("@CustomerInvoice_ID", CustomerInvoiceID);
                        cmd1.Parameters.AddWithValue("@GrandTotal", grandtotal);
                        float discount = 0;
                        if (txtDiscountAmount.Text != "")
                        {
                            discount = float.Parse(txtDiscountAmount.Text);
                        }
                        else
                        {
                            discount = 0;
                        }
                        cmd1.Parameters.AddWithValue("@Discount", discount);
                        cmd1.ExecuteNonQuery();


                        ////Get SalesID
                        string SalesID = Convert.ToString(MainClass.Retrieve("select MAX(SalesID) from Sales").Rows[0][0]);
                        if (string.IsNullOrEmpty(SalesID))
                        {
                            MessageBox.Show("Please Check The Error or Try Again");
                            return;
                        }


                        //Inserting Products
                        foreach (DataGridViewRow products in dgvSaleItems.Rows)
                        {
                            object unittxt = null;
                            try
                            {
                                cmd = new SqlCommand("select UnitID from Units where UnitName = '" + products.Cells[6].Value.ToString() + "'", MainClass.con);
                                unittxt = cmd.ExecuteScalar().ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MainClass.con.Close();
                            }


                            string InsertSaleDetails = "insert into SalesDetails (Sales_ID,CustomerInvoice_ID,Product_ID,SalesQty,UnitType,SalesUnit_ID,SalesRate,TotalofProduct,PurchaseRate) values (@Sales_ID,@CustomerInvoice_ID,@Product_ID,@SalesQty,@UnitType,@SalesUnit_ID,@SalesRate,@TotalofProduct,@PurchaseRate)";
                            SqlCommand cmd2 = new SqlCommand(InsertSaleDetails, MainClass.con);
                            cmd2.Parameters.AddWithValue("@Sales_ID", SalesID);
                            cmd2.Parameters.AddWithValue("@CustomerInvoice_ID", CustomerInvoiceID);
                            cmd2.Parameters.AddWithValue("@Product_ID", products.Cells[0].Value);
                            cmd2.Parameters.AddWithValue("@SalesQty", products.Cells[4].Value);
                            cmd2.Parameters.AddWithValue("@UnitType", products.Cells[10].Value);
                            cmd2.Parameters.AddWithValue("@SalesUnit_ID", products.Cells[5].Value);
                            cmd2.Parameters.AddWithValue("@SalesRate", products.Cells[7].Value);
                            if(txtDiscountAmount.Text == "")
                            {
                                txtDiscountAmount.Text = "0";
                            }
                            cmd2.Parameters.AddWithValue("@TotalofProduct", products.Cells[8].Value);
                            cmd2.Parameters.AddWithValue("@PurchaseRate", products.Cells[9].Value);
                            cmd2.ExecuteNonQuery();
                        }

                        foreach (DataGridViewRow item in dgvSaleItems.Rows)
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
                                cmd = new SqlCommand("select BaseSP from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                                baserate = cmd.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            } //Get Base rate

                            try
                            {
                                cmd = new SqlCommand("select DefaultSP from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
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
                                cmd = new SqlCommand("select SubSP from Products where Pcode = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
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
                                cmd = new SqlCommand("select SC_QTY from Scraps where SC_PCODE = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                                scrapqty = cmd.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            } //Get Scrap Qty

                            if (item.Cells["WarehouseID"].Value.ToString() == "2")
                            {
                                if (shopqty == null)
                                {
                                    MessageBox.Show("NO STOCKS");
                                    return;
                                }
                                else
                                {
                                    int q = Convert.ToInt32(shopqty);
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q -= int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(baseqty.ToString());
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q -= int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q -= int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(subqty.ToString());

                                    }
                                    MainClass.UpdateShop(int.Parse(item.Cells[0].Value.ToString()), q);
                                }
                            }//Shop

                            if (item.Cells["WarehouseID"].Value.ToString() == "3")
                            {
                                if (scrapqty == null)
                                {
                                    MessageBox.Show("NO STOCKS IN SCRAP");
                                    return;
                                }
                                else
                                {
                                    int q = Convert.ToInt32(scrapqty);
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q -= int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(baseqty.ToString());
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q -= int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q -= int.Parse(item.Cells["QtyGVC"].Value.ToString()) * int.Parse(subqty.ToString());

                                    }
                                    MainClass.UpdateScrap(int.Parse(item.Cells[0].Value.ToString()), q);
                                }
                            }//SCrap

                        }


                        //Inserting Customer Payments
                        string InsertPayment = "insert into CustomerLedgers (CustomerInvoice_ID,Customer_ID,InvoiceType,InvoiceDate,TotalAmount,PaidAmount,RemainingBalance) values(@CustomerInvoice_ID,@Customer_ID,@InvoiceType,@InvoiceDate,@TotalAmount,@PaidAmount,@RemainingBalance)";
                        SqlCommand cmd3 = new SqlCommand(InsertPayment, MainClass.con);
                        cmd3.Parameters.AddWithValue("@CustomerInvoice_ID", CustomerInvoiceID);
                        cmd3.Parameters.AddWithValue("@Customer_ID", cboCustomer.SelectedValue.ToString());
                        cmd3.Parameters.AddWithValue("@InvoiceType", txtInvoiceType.Text);
                        cmd3.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd3.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                        cmd3.Parameters.AddWithValue("@PaidAmount", txtPayingAmount.Text);
                        cmd3.Parameters.AddWithValue("@RemainingBalance", txtRemainingAmount.Text);
                        cmd3.ExecuteNonQuery();


                        cmd = new SqlCommand("insert into CustomerReport (Customer_ID,SaleInvoiceNo,SaleInvoiceDate,SaleTotalAmount,SaleLastPaid,SaleTodaysPaid,SaleLastPayingDate,SaleBalance) values (@Customer_ID,@SaleInvoiceNo,@SaleInvoiceDate,@SaleTotalAmount,@SaleLastPaid,@SaleTodaysPaid,@SaleLastPayingDate,@SaleBalance)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboCustomer.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SaleInvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@SaleInvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@SaleTotalAmount", float.Parse(txtTotalAmount.Text));
                        cmd.Parameters.AddWithValue("@SaleLastPaid", float.Parse(txtPayingAmount.Text));
                        cmd.Parameters.AddWithValue("@SaleTodaysPaid", float.Parse(txtPayingAmount.Text));
                        cmd.Parameters.AddWithValue("@SaleLastPayingDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@SaleBalance", float.Parse(txtRemainingAmount.Text));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Sale Successful");
                        SaleReportForm srf = new SaleReportForm();
                        srf.Show();
                        CompleteClear();




                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    MainClass.con.Close();
                }
                
                else
                {
                    cmd = null;
                    float discount = 0;
                    if (txtDiscountAmount.Text != "")
                    {
                        discount = float.Parse(txtDiscountAmount.Text);
                    }
                    float grandtotal = float.Parse(txtGrandTotal.Text.ToString());
                    customerinvoiceid = int.Parse(lblCustomerInvoiceID.Text);
                    SaleID = int.Parse(lblSalesID.Text);
                    string invoiceno = lblInvoice.Text.ToString();
                    MainClass.con.Open();

                    try
                    {
                        cmd = new SqlCommand("update CustomerInvoices set Customer_ID = @Customer_ID, PaymentType = @PaymentType, InvoiceDate = @InvoiceDate,Warehouse_ID = @Warehouse_ID where CustomerInvoiceID = '" + customerinvoiceid + "'", MainClass.con);
                        cmd.Parameters.AddWithValue("@CustomerInvoiceID", customerinvoiceid);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboCustomer.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PaymentType", cboInvoiceType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Warehouse_ID", dgvSaleItems.CurrentRow.Cells[2].Value);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }//Update CustomerInvoice
                    try
                    {
                        cmd = new SqlCommand("update Sales set Discount = @Discount, GrandTotal = @GrandTotal where CustomerInvoice_ID = @CustomerInvoice_ID and InvoiceNo = @InvoiceNo and SalesID = @SalesID", MainClass.con);
                        cmd.Parameters.AddWithValue("@SalesID", int.Parse(lblSalesID.Text));
                        cmd.Parameters.AddWithValue("@Discount", discount);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@CustomerInvoice_ID", customerinvoiceid);
                        cmd.Parameters.AddWithValue("@GrandTotal", grandtotal);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }//Update Sales
                    try
                    {

                        SqlDataReader dr;
                        cmd = new SqlCommand("select s.SalesID,p.Pcode,u.UnitName,sd.SalesQty,u.UnitID,s.InvoiceNo,sd.SalesRate,sd.UnitType from Sales s inner join SalesDetails sd on sd.Sales_ID = s.SalesID inner join Products p on p.Pcode = sd.Product_ID inner join Units u on u.UnitID = sd.SalesUnit_ID where s.SalesID = '" + int.Parse(lblSalesID.Text) + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                try
                                {
                                    cmd = new SqlCommand("select BaseQty from Products where Pcode = '" + dr[1].ToString() + "'", MainClass.con);
                                    baseqty = cmd.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                } //Get Base Qty
                                try
                                {
                                    cmd = new SqlCommand("select BaseU from Products where Pcode = '" + dr[1].ToString() + "'", MainClass.con);
                                    baseunit = cmd.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                } // get Base Unit
                                try
                                {
                                    cmd = new SqlCommand("select BaseSP from Products where Pcode = '" + dr[1].ToString() + "'", MainClass.con);
                                    baserate = cmd.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                } //Get Base rate

                                try
                                {
                                    cmd = new SqlCommand("select DefaultSP from Products where Pcode = '" + dr[1].ToString() + "'", MainClass.con);
                                    defaultrate = cmd.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                } //Get Default rate
                                try
                                {
                                    cmd = new SqlCommand("select DefaultQty from Products where Pcode = '" + dr[1].ToString() + "'", MainClass.con);
                                    defaultqty = cmd.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                } // Get Default Qty

                                try
                                {
                                    cmd = new SqlCommand("select SubSP from Products where Pcode = '" + dr[1].ToString() + "'", MainClass.con);
                                    subrate = cmd.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                } // Get Sub Rate
                                try
                                {
                                    cmd = new SqlCommand("select SubQty from Products where Pcode = '" + dr[1].ToString() + "'", MainClass.con);
                                    subqty = cmd.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                } // Get Sub Qty




                                SalesQTY[0] = dr[0].ToString();  //Sale ID
                                SalesQTY[1] = dr[1].ToString(); // Pcode
                                SalesQTY[2] = dr[2].ToString(); // UnitName
                                SalesQTY[3] = dr[3].ToString(); // Qty
                                SalesQTY[4] = dr[4].ToString(); // UntID
                                SalesQTY[5] = dr[5].ToString(); // Invoice
                                SalesQTY[6] = dr[6].ToString(); // SaleRate
                                SalesQTY[7] = dr[7].ToString(); // UnitType


                                
                                if (SalesQTY[7] == "Base")
                                {
                                    SalesQTY[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(baseqty.ToString()));
                                }
                                else if (SalesQTY[7] == "Default")
                                {
                                    SalesQTY[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(defaultqty.ToString()));
                                }
                                else
                                {
                                    SalesQTY[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(subqty.ToString()));
                                }


                                try
                                {


                                    string CheckStock = "select s.sh_Qty as 'Quantity' from ShopStocks s where s.sh_Pcode = '" + SalesQTY[1].ToString() + "' ";
                                    cmd = new SqlCommand(CheckStock, MainClass.con);
                                    object ob = cmd.ExecuteScalar();



                                    if (ob == null)
                                    {
                                        cmd = new SqlCommand("insert into ShopStocks (sh_Pcode,sh_Qty,sh_Unit) values(@sh_Pcode,@sh_Qty,@sh_Unit)", MainClass.con);
                                        cmd.Parameters.AddWithValue("@sh_Pcode", SalesQTY[1].ToString());
                                        cmd.Parameters.AddWithValue("@sh_Qty", SalesQTY[3].ToString());
                                        cmd.Parameters.AddWithValue("@sh_Unit", SalesQTY[4].ToString());
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        float total = float.Parse(SalesQTY[3].ToString());
                                        total += float.Parse(ob.ToString());
                                        MainClass.UpdateShop(int.Parse(SalesQTY[1]), total);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }


                            }



                        }
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //Bring Back Inventory
                    try
                    {
                        cmd = new SqlCommand("delete from SalesDetails where Sales_ID = '" + int.Parse(lblSalesID.Text) + "'", MainClass.con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("select CustomerInvoice_ID from Sales where InvoiceNo = '" + lblInvoice.Text + "'", MainClass.con);
                        object ccid = cmd.ExecuteScalar();

                        foreach (DataGridViewRow products in dgvSaleItems.Rows)
                        {
                            
                            string InsertSaleDetails = "insert into SalesDetails (Sales_ID,CustomerInvoice_ID,Product_ID,SalesQty,SalesUnit_ID,UnitType,PurchaseRate,SalesRate,TotalofProduct) values (@Sales_ID,@CustomerInvoice_ID,@Product_ID,@SalesQty,@SalesUnit_ID,@UnitType,@PurchaseRate,@SalesRate,@TotalofProduct)";
                            SqlCommand cmd2 = new SqlCommand(InsertSaleDetails, MainClass.con);
                            cmd2.Parameters.AddWithValue("@Sales_ID", int.Parse(lblSalesID.Text));
                            cmd2.Parameters.AddWithValue("@CustomerInvoice_ID",  ccid);
                            cmd2.Parameters.AddWithValue("@Product_ID", products.Cells[0].Value);
                            cmd2.Parameters.AddWithValue("@SalesQty", products.Cells[4].Value);
                            cmd2.Parameters.AddWithValue("@SalesUnit_ID", products.Cells[5].Value);     
                            cmd2.Parameters.AddWithValue("@SalesRate", products.Cells[7].Value);
                            cmd2.Parameters.AddWithValue("@TotalofProduct", products.Cells[8].Value);
                            cmd2.Parameters.AddWithValue("@PurchaseRate", products.Cells[9].Value);
                            cmd2.Parameters.AddWithValue("@UnitType", products.Cells[10].Value);
                            cmd2.ExecuteNonQuery();
                        }


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //Update SalesDetials
                    try
                    {
                        foreach (DataGridViewRow sold in dgvSaleItems.Rows)
                        {
                            string CheckStock = "select s.sh_Qty as 'Quantity' from ShopStocks s where s.sh_Pcode = '" + sold.Cells[0].Value.ToString() + "' ";
                            cmd = new SqlCommand(CheckStock, MainClass.con);
                            float q = float.Parse(cmd.ExecuteScalar().ToString());


                            if (sold.Cells[10].Value.ToString() == "Base")
                            {
                                q -= float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(baseqty.ToString());

                            }
                            else if (sold.Cells[10].Value.ToString() == "Default")
                            {
                                q -= float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(defaultqty.ToString());
                            }
                           
                            else
                            {
                                q -= float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(subqty.ToString());

                            }
                            cmd = new SqlCommand("update ShopStocks set sh_Qty = @sh_Qty where sh_Pcode = @sh_Pcode",MainClass.con);
                            cmd.Parameters.AddWithValue("@sh_Qty", q);
                            cmd.Parameters.AddWithValue("@sh_Pcode", sold.Cells[0].Value);
                            cmd.ExecuteNonQuery();


                        }

                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //ReUpdate Inventory
                    try
                    {
                        cmd = new SqlCommand("update CustomerLedgers set InvoiceType = @InvoiceType, InvoiceDate = @InvoiceDate, TotalAmount = @TotalAmount,PaidAmount = @PaidAmount, RemainingBalance = @RemainingBalance where CustomerLedgerID = @CustomerLedgerID ", MainClass.con);
                        cmd.Parameters.AddWithValue("@CustomerLedgerID", int.Parse(lblCustomerLedgerID.Text));
                        cmd.Parameters.AddWithValue("@InvoiceType", txtInvoiceType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@TotalAmount", float.Parse(txtTotalAmount.Text));
                        cmd.Parameters.AddWithValue("@PaidAmount", float.Parse(txtPayingAmount.Text));
                        cmd.Parameters.AddWithValue("@RemainingBalance", float.Parse(txtRemainingAmount.Text));
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //Update CustomerLedgers


                    MainClass.con.Close();
                    SALEINVOICENO = invoiceno;
                    SaleReportForm srf = new SaleReportForm();
                    srf.Show();
                    CompleteClear();
                }
            }
        }

        private string[] SalesQTY = new string[8];


        private void btnReset_Click(object sender, EventArgs e)
        {
            CompleteClear();
        }

       
     

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 520, 820);
            printPreviewDialog1.ShowDialog();

          
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Sale Invoice", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(100, 10));
            e.Graphics.DrawString("Date: " + dtInvoice.Value.ToShortDateString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, 70));
            e.Graphics.DrawString("Customer: " + cboCustomer.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, 90));
            e.Graphics.DrawString("___________________________________________________________ ", new Font("Helvetica", 12, FontStyle.Regular), Brushes.Black, new Point(0, 115));
            e.Graphics.DrawString("Product ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(25, 135));
            e.Graphics.DrawString("QTY ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(190, 135));
            e.Graphics.DrawString("Unit ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(245, 135));
            e.Graphics.DrawString("Rate ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(300, 135));
            e.Graphics.DrawString("Amount ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(400, 135));
            e.Graphics.DrawString("___________________________________________________________ ", new Font("Helvetica", 12, FontStyle.Regular), Brushes.Black, new Point(0, 135));
            int pos = 160;
            foreach (DataGridViewRow item in dgvSaleItems.Rows)
            {
                e.Graphics.DrawString(item.Cells[1].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(25, pos));    //Product
                e.Graphics.DrawString(item.Cells[4].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(190, pos));    // Qty
                e.Graphics.DrawString(item.Cells[5].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(245, pos));    //Unit
                e.Graphics.DrawString(item.Cells[6].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(300, pos));    //Rate
                e.Graphics.DrawString(item.Cells[8].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(400, pos));    //Total
                pos += 20;
            }
            e.Graphics.DrawString("Total Amount: " + txtGrandTotal.Text.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(280, 65));
            e.Graphics.DrawString("Discount: " + txtDiscountAmount.Text.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(280, 80));
            if (cboInvoiceType.Text != "Cash")
            {
                e.Graphics.DrawString("Paying Amount: " + txtPayingAmount.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(280, 93));
                e.Graphics.DrawString("Remaining Balance: " + txtRemainingAmount.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(280, 113));
            }

        }

        private void cboInvoiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {
                cboProductName.Focus();
            }
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            
            txtTotalAmount.Text = txtGrandTotal.Text;
            txtRemainingAmount.Text = txtGrandTotal.Text;
        }

  


        

        private void button2_Click(object sender, EventArgs e)
        {
            ViewSaleInvoices vs = new ViewSaleInvoices(this);
            vs.Show();
        }

        private void lblInvoice_TextChanged(object sender, EventArgs e)
        {
            if(lblInvoice.Text != "lblInvocien")
            {
                btnFinalize.Text = "&UPDATE";
                btnFinalize.BackColor = Color.DarkRed;
            }
        }

        private void dgvSaleItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            button1.PerformClick();
        }

        private void dgvSaleItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            button1.PerformClick();

        }
     

        private void dgvSaleItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
                if (e.ColumnIndex == 4 || e.ColumnIndex == 8 || e.ColumnIndex == 7)
                {
                    e.CellStyle.Format = "N2";
                }
            
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool found = false;
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
                        SqlCommand cmd = new SqlCommand("select BaseSP,BaseU,BaseCP from Products where Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[0] = dr[0].ToString();
                                ProductsData[1] = dr[1].ToString();
                                ProductsData[2] = dr[2].ToString();
                                found = true;
                                txtSaleRate.Text = ProductsData[0].ToString();
                                txtUnit.Text = ProductsData[1].ToString();
                                lblPurchaseRates.Text = ProductsData[2].ToString();
                            }
                        }

                        dr.Close();
                        if (cboType.Text == "Base")
                        {

                            if (cboWarehouse.Text == "Godown")
                            {
                                cmd = new SqlCommand("select i.st_Qty/pm.BaseQty*1.0 as 'Qty' from Products pm inner join Stocks i on i.st_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else if (cboWarehouse.Text == "Shop")
                            {
                                cmd = new SqlCommand("select i.sh_Qty/pm.BaseQty*1.0 as 'Qty' from Products pm inner join ShopStocks i on i.sh_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else
                            {
                                cmd = new SqlCommand("select i.SC_QTY/pm.BaseQty*1.0 as 'Qty' from Products pm inner join Scraps i on i.SC_PCODE = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
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
                        SqlCommand cmd = new SqlCommand("select DefaultSP,DefaultU,DefaultCP,DefaultQty from Products where Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[0] = dr[0].ToString();
                                ProductsData[1] = dr[1].ToString();
                                ProductsData[2] = dr[2].ToString();
                                ProductsData[3] = dr[3].ToString();
                                found = true;
                                txtSaleRate.Text = ProductsData[0].ToString();
                                txtUnit.Text = ProductsData[1].ToString();
                                lblPurchaseRates.Text = ProductsData[2].ToString();
                            }
                        }
                        dr.Close();
                        if (cboType.Text == "Default")
                        {
                            
                            if (cboWarehouse.Text == "Godown")
                            {
                                cmd = new SqlCommand("select i.st_Qty/pm.DefaultQty*1.0 as 'Qty' from Products pm inner join Stocks i on i.st_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else if (cboWarehouse.Text == "Shop")
                            {
                                cmd = new SqlCommand("select i.sh_Qty/pm.DefaultQty*1.0 as 'Qty' from Products pm inner join ShopStocks i on i.sh_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else
                            {
                                cmd = new SqlCommand("select i.SC_QTY/pm.DefaultQty*1.0 as 'Qty' from Products pm inner join Scraps i on i.SC_PCODE = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            if(ProductsData[3] == "0")
                            {
                                stocks = 0;
                            }
                            else
                            {
                                stocks = cmd.ExecuteScalar();
                            }

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
                        SqlCommand cmd = new SqlCommand("select SubSP,SubU,SubCP,SubQty from Products where Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[0] = dr[0].ToString();
                                ProductsData[1] = dr[1].ToString();
                                ProductsData[2] = dr[2].ToString();
                                ProductsData[3] = dr[3].ToString();
                                found = true;
                                txtSaleRate.Text = ProductsData[0].ToString();
                                txtUnit.Text = ProductsData[1].ToString();
                                lblPurchaseRates.Text = float.Parse(ProductsData[2]).ToString();
                            }
                        }
                        dr.Close();
                        if (cboType.Text == "Sub")
                        {

                            if (cboWarehouse.Text == "Godown")
                            {
                                cmd = new SqlCommand("select i.st_Qty/pm.SubQty*1.0 as 'Qty' from Products pm inner join Stocks i on i.st_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else if (cboWarehouse.Text == "Shop")
                            {
                                cmd = new SqlCommand("select i.sh_Qty/pm.SubQty*1.0 as 'Qty' from Products pm inner join ShopStocks i on i.sh_Pcode = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            else
                            {
                                cmd = new SqlCommand("select i.SC_QTY/pm.SubQty*1.0 as 'Qty' from Products pm inner join Scraps i on i.SC_PCODE = pm.Pcode where pm.Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                            }
                            if (ProductsData[3] == "0")
                            {
                                stocks = 0;
                            }
                            else
                            {
                                stocks = cmd.ExecuteScalar();
                            }

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
            if (txtSaleRate.Text == "0")
            {
                txtQuantity.Enabled = false;
            }
            else
            {
                txtQuantity.Enabled = true;
            }
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckScrap();
            if(cboWarehouse.Text != "Scrap")
            {
                scrap = 0;
            }
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            del();
        }
    }
}
