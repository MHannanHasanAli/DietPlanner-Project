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
using HelloWorldSolutionIMS;

namespace HelloWorldSolutionIMS
{
    public partial class PurchaseInvoice : Form
    {
        bool productcheck = false;

        public static int PurUpdateID = 0;

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        public PurchaseInvoice()
        {
            InitializeComponent();
        }

        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            cboInvoiceType.SelectedIndex = 0;
            MainClass.FillProducts2Pur(cboProductName);
            MainClass.FillWarehouses(cboWarehouse);
            // MainClass.FillUnits(cboType);
            MainClass.FillSupplier(cboSupplier);
            txtDated.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private string[] ProductsData = new string[3];


        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "" && txtQuantity.Text != "0")
            {
                float rate = float.Parse(txtPurchaseRate.Text);
                float qty;
                float.TryParse(txtQuantity.Text.Trim(), out qty);
                txtProductTot.Text = Convert.ToString(qty * rate);
            }
            else
            {
                txtProductTot.Text = "0";
            }
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {

            if (txtDiscountAmount.Text != "" && txtDiscountAmount.Text != "0")
            {
                float gd = 0;
                foreach (DataGridViewRow item in dgvPurchaseItems.Rows)
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
                foreach (DataGridViewRow item in dgvPurchaseItems.Rows)
                {
                    gd += float.Parse(item.Cells[7].Value.ToString());
                }
                txtGrandTotal.Text = Convert.ToString(gd);
            }
        }

        private void FindTotal()
        {
            float gross = 0;
            if (dgvPurchaseItems.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPurchaseItems.Rows)
                {
                    gross += float.Parse(row.Cells["TotalGV"].Value.ToString());
                }
                txtGrandTotal.Text = Convert.ToString(gross);
                txtTotalAmount.Text = Convert.ToString(gross);
                cboSupplier.Text = txtSupplierName.Text;
                if (cboInvoiceType.Text == "Cash")
                {
                    txtPayingAmount.Text = Convert.ToString(gross);
                }
            }
            if (txtPayingAmount.Text == "0" || txtPayingAmount.Text == "")
            {
                txtRemainingAmount.Text = gross.ToString();
            }
        }

        private void CompleteClear()
        {
            ClearForm();
            txtSupplierName.Text = "";
            txtInvoiceType.Text = "";
            txtTotalAmount.Text = "";
            txtPayingAmount.Text = "";
            txtRemainingAmount.Text = "";
            dtInvoice.Value = DateTime.Now;
            dgvPurchaseItems.Rows.Clear();
            cboSupplier.Focus();
        }

        private void ClearForm()
        {
            cboProductName.SelectedIndex = 0;
            cboWarehouse.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            if (txtDiscountAmount.Text != "")
            {
                txtDiscountAmount.TextChanged -= txtDiscountAmount_TextChanged;
                txtDiscountAmount.Clear();
                txtDiscountAmount.TextChanged += txtDiscountAmount_TextChanged;

            }
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

        private void btnAddCart_Click(object sender, EventArgs e)
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
                float discount, totalofproduct, grandtotal, puchaserate, salerate;

                float.TryParse(txtQuantity.Text.Trim(), out quantity);
                float.TryParse(txtPurchaseRate.Text.Trim(), out puchaserate);
                float.TryParse(lblSaleRates.Text.Trim(), out salerate);
                float.TryParse(txtProductTot.Text.Trim(), out totalofproduct);
                float.TryParse(txtGrandTotal.Text.Trim(), out grandtotal);

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

                if (dgvPurchaseItems.Rows.Count == 0)
                {
                    DataGridViewRow createrow = new DataGridViewRow();
                    createrow.CreateCells(dgvPurchaseItems);
                    createrow.Cells[0].Value = cboProductName.SelectedValue;
                    createrow.Cells[1].Value = cboProductName.Text;
                    createrow.Cells[2].Value = cboWarehouse.SelectedValue;
                    createrow.Cells[3].Value = cboWarehouse.Text;
                    createrow.Cells[4].Value = quantity;
                    createrow.Cells[5].Value = unitt;
                    createrow.Cells[6].Value = txtUnit.Text;
                    createrow.Cells[7].Value = puchaserate;
                    createrow.Cells[8].Value = totalofproduct;
                    createrow.Cells[9].Value = salerate;
                    createrow.Cells[10].Value = cboType.Text;
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
                        else
                        {
                            productcheck = false;
                        }
                    }
                    if (productcheck == true)
                    {
                        foreach (DataGridViewRow row in dgvPurchaseItems.Rows)
                        {
                            if (Convert.ToString(row.Cells[0].Value) == Convert.ToString(cboProductName.SelectedValue))
                            {
                                row.Cells["QtyGVC"].Value = float.Parse(row.Cells["QtyGVC"].Value.ToString()) + quantity;
                                row.Cells["TotalGV"].Value = float.Parse(row.Cells["QtyGVC"].Value.ToString()) * float.Parse(row.Cells["PurchaseRateGVC"].Value.ToString());
                                ClearForm();
                            }
                        }
                    }
                    else
                    {
                        if (productcheck == false)
                        {
                            DataGridViewRow createrow = new DataGridViewRow();
                            createrow.CreateCells(dgvPurchaseItems);
                            createrow.Cells[0].Value = cboProductName.SelectedValue;
                            createrow.Cells[1].Value = cboProductName.Text;
                            createrow.Cells[2].Value = cboWarehouse.SelectedValue;
                            createrow.Cells[3].Value = cboWarehouse.Text;
                            createrow.Cells[4].Value = quantity;
                            createrow.Cells[5].Value = unitt;
                            createrow.Cells[6].Value = txtUnit.Text;
                            createrow.Cells[7].Value = puchaserate;
                            createrow.Cells[8].Value = totalofproduct;
                            createrow.Cells[9].Value = salerate;
                            createrow.Cells[10].Value = cboType.Text;
                            
                            dgvPurchaseItems.Rows.Add(createrow);
                            cboProductName.Focus();
                        }
                    }
                }
            }
            FindTotal();
            ClearForm();
            button1.PerformClick();

        }



        private void txtPurchaseRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductTot_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPurchaseItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 10)
                {
                    dgvPurchaseItems.Rows.RemoveAt(dgvPurchaseItems.CurrentRow.Index);
                }
            }
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSupplierName.Text = cboSupplier.Text;
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

        private void dtInvoice_ValueChanged(object sender, EventArgs e)
        {
            txtDated.Text = dtInvoice.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float gross = 0;
            if (dgvPurchaseItems.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPurchaseItems.Rows)
                {
                    gross += float.Parse(row.Cells["TotalGV"].Value.ToString());
                }
                txtGrandTotal.Text = Convert.ToString(gross);
                txtTotalAmount.Text = Convert.ToString(gross);
                cboSupplier.Text = txtSupplierName.Text;
                if (cboInvoiceType.Text == "Cash")
                {
                    txtPayingAmount.Text = Convert.ToString(gross);
                }
            }
            if (txtPayingAmount.Text == "0" || txtPayingAmount.Text == "")
            {
                txtRemainingAmount.Text = gross.ToString();
            }

        }

        private string[] PurchaseQty = new string[9];
        private void btnFinalize_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            object baseqty = null;
            object defaultqty = null;
            object subqty = null;
            object stockqty = null;
            object shopqty = null;
            object baserate = null;
            object defaultrate = null;
            object subrate = null;
            object unittxt = null;
            object baseunit = null;
            object supplierinvoiceID = null;
            object purchaseid = null;


            if (cboInvoiceType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Invoice Type");
                return;
            }
            if (cboSupplier.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Supplier");
                return;
            }

            if (dgvPurchaseItems.Rows.Count == 0)
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
                        invoiceno = "PUR" + generator.Next(0, 1000000).ToString("D6");
                    }
                    float grandtotal = float.Parse(txtGrandTotal.Text.ToString());
                    MainClass.con.Open();
                    try
                    {
                        string InsertInvoice = "insert into SupplierInvoices (Supplier_ID,PaymentType,InvoiceDate,Warehouse_ID) values (@Supplier_ID,@PaymentType,@InvoiceDate,@Warehouse_ID)";
                        cmd = new SqlCommand(InsertInvoice, MainClass.con);
                        cmd.Parameters.AddWithValue("@Supplier_ID", cboSupplier.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PaymentType", cboInvoiceType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Warehouse_ID", dgvPurchaseItems.CurrentRow.Cells[2].Value);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Insert Invoice

                    string SupplierInvoiceID = Convert.ToString(MainClass.Retrieve("select MAX(SupplierInvoiceID) from SupplierInvoices").Rows[0][0]);
                    if (string.IsNullOrEmpty(SupplierInvoiceID))
                    {
                        MessageBox.Show("Please Check The Error or Try Again");
                        return;
                    }

                    //Get Supplier InvoiceID

                    try
                    {
                        string InserPurchase = "insert into Purchases (InvoiceNo,SupplierInvoice_ID,GrandTotal,Discount) values (@InvoiceNo,@SupplierInvoice_ID,@GrandTotal,@Discount)";
                        cmd = new SqlCommand(InserPurchase, MainClass.con);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@SupplierInvoice_ID", SupplierInvoiceID);
                        cmd.Parameters.AddWithValue("@GrandTotal", grandtotal);
                        float discount = 0;
                        if (txtDiscountAmount.Text != "")
                        {
                            discount = float.Parse(txtDiscountAmount.Text);
                        }
                        else
                        {
                            discount = 0;
                        }
                        cmd.Parameters.AddWithValue("@Discount", discount);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    }//Inserting Purchase

                    string PurchaseID = Convert.ToString(MainClass.Retrieve("select MAX(PurchaseID) from Purchases").Rows[0][0]);
                    if (string.IsNullOrEmpty(PurchaseID))
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
                                cmd = new SqlCommand("select UnitID from Units where UnitName = '" + products.Cells[6].Value.ToString() + "'", MainClass.con);
                                unittxt = cmd.ExecuteScalar().ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MainClass.con.Close();
                            }

                            string InsertPurchaseDetails = "insert into PurchaseDetails (Purchase_ID,SupplerInvoice_ID,Product_ID,PurchaseQty,SaleRate,UnitType,Unit,PurchaseRate,TotalofProduct) values (@Purchase_ID,@SupplerInvoice_ID,@Product_ID,@PurchaseQty,@SaleRate,@UnitType,@Unit,@PurchaseRate,@TotalofProduct)";
                            cmd = new SqlCommand(InsertPurchaseDetails, MainClass.con);
                            cmd.Parameters.AddWithValue("@Purchase_ID", PurchaseID);
                            cmd.Parameters.AddWithValue("@SupplerInvoice_ID", SupplierInvoiceID);
                            cmd.Parameters.AddWithValue("@Product_ID", products.Cells[0].Value);
                            cmd.Parameters.AddWithValue("@PurchaseQty", products.Cells[4].Value);
                            cmd.Parameters.AddWithValue("@UnitType", products.Cells[10].Value);
                            cmd.Parameters.AddWithValue("@Unit", unittxt);
                            cmd.Parameters.AddWithValue("@PurchaseRate", products.Cells[7].Value);
                            cmd.Parameters.AddWithValue("@TotalofProduct", products.Cells[8].Value);
                            cmd.Parameters.AddWithValue("@SaleRate", products.Cells[9].Value);
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



                            if (item.Cells["WarehouseID"].Value.ToString() == "1") //Godown
                            {
                                if (stockqty == null)
                                {

                                    cmd = new SqlCommand("Insert into Stocks (st_Pcode,BaseRate,st_Qty,st_Unit) values(@st_Pcode,@BaseRate,@st_Qty,@st_Unit)", MainClass.con);
                                    cmd.Parameters.AddWithValue("@st_Pcode", item.Cells[0].Value.ToString());
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        cmd.Parameters.AddWithValue("@st_Qty", float.Parse(item.Cells[4].Value.ToString()) * float.Parse(baseqty.ToString()));
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        cmd.Parameters.AddWithValue("@st_Qty", float.Parse(item.Cells[4].Value.ToString()) * float.Parse(defaultqty.ToString()));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@st_Qty", float.Parse(item.Cells[4].Value.ToString()) * float.Parse(subqty.ToString()));

                                    }
                                    cmd.Parameters.AddWithValue("@BaseRate", baserate);
                                    cmd.Parameters.AddWithValue("@st_Unit", baseunit);
                                    cmd.ExecuteNonQuery();
                                }
                                else //Updating Godown
                                {
                                    float q = float.Parse((string)stockqty);
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q += float.Parse(item.Cells["QtyGVC"].Value.ToString()) * float.Parse(baseqty.ToString());
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q += float.Parse(item.Cells["QtyGVC"].Value.ToString()) * float.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q += float.Parse(item.Cells["QtyGVC"].Value.ToString()) * float.Parse(subqty.ToString());
                                    }
                                    MainClass.UpdateStock(int.Parse(item.Cells[0].Value.ToString()), q);
                                }
                            }
                            else //Shop
                            {
                                if (shopqty == null)
                                {

                                    cmd = new SqlCommand("Insert into ShopStocks (sh_Pcode,BaseRate,sh_Qty,sh_Unit) values(@sh_Pcode,@BaseRate,@sh_Qty,@sh_Unit)", MainClass.con);
                                    cmd.Parameters.AddWithValue("@sh_Pcode", item.Cells[0].Value.ToString());
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        cmd.Parameters.AddWithValue("@sh_Qty", float.Parse(item.Cells[4].Value.ToString()) * float.Parse(baseqty.ToString()));
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        cmd.Parameters.AddWithValue("@sh_Qty", float.Parse(item.Cells[4].Value.ToString()) * float.Parse(defaultqty.ToString()));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@sh_Qty", float.Parse(item.Cells[4].Value.ToString()) * float.Parse(subqty.ToString()));

                                    }
                                    cmd.Parameters.AddWithValue("@BaseRate", baserate);
                                    cmd.Parameters.AddWithValue("@sh_Unit", baseunit);
                                    cmd.ExecuteNonQuery();
                                }
                                else //Updating Shop
                                {
                                    float q = float.Parse((string)shopqty);
                                    if (item.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q += float.Parse(item.Cells["QtyGVC"].Value.ToString()) * float.Parse(baseqty.ToString());
                                    }
                                    else if (item.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q += float.Parse(item.Cells["QtyGVC"].Value.ToString()) * float.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q += float.Parse(item.Cells["QtyGVC"].Value.ToString()) * float.Parse(subqty.ToString());

                                    }
                                    MainClass.UpdateShop(int.Parse(item.Cells[0].Value.ToString()), q);
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    }//Inventory Filling and Updating

                    try
                    {
                        string InsertPayment = "insert into SupplierLedgers (SupplierInvoice_ID,Supplier_ID,InvoiceType,InvoiceDate,TotalAmount,PaidAmount,RemaingBalance) values(@SupplierInvoice_ID,@Supplier_ID,@InvoiceType,@InvoiceDate,@TotalAmount,@PaidAmount,@RemaingBalance)";
                        cmd = new SqlCommand(InsertPayment, MainClass.con);
                        cmd.Parameters.AddWithValue("@SupplierInvoice_ID", SupplierInvoiceID);
                        cmd.Parameters.AddWithValue("@Supplier_ID", cboSupplier.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@InvoiceType", txtInvoiceType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                        cmd.Parameters.AddWithValue("@PaidAmount", txtPayingAmount.Text);
                        cmd.Parameters.AddWithValue("@RemaingBalance", txtRemainingAmount.Text);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //Inserting Supplier Payments
                    try
                    {
                        cmd = new SqlCommand("insert into SupplierReport(Supplierer_ID,SaleInvoiceNo,SaleInvoiceDate,SaleTotalAmount,SaleLastPaid,SaleTodaysPaid,SaleLastPayingDate,SaleBalance) values(@Supplierer_ID,@SaleInvoiceNo,@SaleInvoiceDate,@SaleTotalAmount,@SaleLastPaid,@SaleTodaysPaid,@SaleLastPayingDate,@SaleBalance)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Supplierer_ID", cboSupplier.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SaleInvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@SaleInvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@SaleTotalAmount", float.Parse(txtGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@SaleLastPayingDate", DateTime.Now.ToShortDateString());
                        if (cboInvoiceType.Text == "Cash")
                        {
                            cmd.Parameters.AddWithValue("@SaleLastPaid", 0);
                            cmd.Parameters.AddWithValue("@SaleTodaysPaid", float.Parse(txtGrandTotal.Text));
                            cmd.Parameters.AddWithValue("@SaleBalance", 0);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@SaleLastPaid", 0);
                            cmd.Parameters.AddWithValue("@SaleTodaysPaid", float.Parse(txtPayingAmount.Text));
                            cmd.Parameters.AddWithValue("@SaleBalance", float.Parse(txtRemainingAmount.Text));
                        }
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Inserting In Supplier Report

                    MainClass.con.Close();
                    MessageBox.Show("Purchase Successful");
                    PurchaseReportForm prf = new PurchaseReportForm();
                    prf.Show();
                    CompleteClear();
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
                    supplierinvoiceID = int.Parse(lblSupplierInvoiceID.Text);
                    PurUpdateID = int.Parse(lblPurchaseID.Text);
                    string invoiceno = lblInvoice.Text.ToString();
                    MainClass.con.Open();

                    try
                    {
                        cmd = new SqlCommand("update SupplierInvoices set Supplier_ID = @Supplier_ID, PaymentType = @PaymentType, InvoiceDate = @InvoiceDate,Warehouse_ID = @Warehouse_ID where SupplierInvoiceID = '" + supplierinvoiceID + "'", MainClass.con);
                        cmd.Parameters.AddWithValue("@SupplierInvoiceID", supplierinvoiceID);
                        cmd.Parameters.AddWithValue("@Supplier_ID", cboSupplier.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PaymentType", cboInvoiceType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Warehouse_ID", dgvPurchaseItems.CurrentRow.Cells[2].Value);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }//Update SupplierInvoice
                    try
                    {
                        cmd = new SqlCommand("update Purchases set Discount = @Discount, GrandTotal = @GrandTotal where SupplierInvoice_ID = @SupplierInvoice_ID and InvoiceNo = @InvoiceNo and PurchaseID = @PurchaseID", MainClass.con);
                        cmd.Parameters.AddWithValue("@PurchaseID", int.Parse(lblPurchaseID.Text));
                        cmd.Parameters.AddWithValue("@Discount", discount);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@SupplierInvoice_ID", supplierinvoiceID);
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
                        cmd = new SqlCommand("select s.PurchaseID,p.Pcode,u.UnitName,sd.PurchaseQty,u.UnitID,s.InvoiceNo,sd.PurchaseRate,sd.UnitType,si.Warehouse_ID from Purchases s inner join PurchaseDetails sd on sd.Purchase_ID = s.PurchaseID inner join Products p on p.Pcode = sd.Product_ID inner join Units u on u.UnitID = sd.Unit inner join SupplierInvoices si on si.SupplierInvoiceID = s.SupplierInvoice_ID where s.PurchaseID  = '" + int.Parse(lblPurchaseID.Text) + "'", MainClass.con);
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




                                PurchaseQty[0] = dr[0].ToString();  //Sale ID
                                PurchaseQty[1] = dr[1].ToString(); // Pcode
                                PurchaseQty[2] = dr[2].ToString(); // UnitName
                                PurchaseQty[3] = dr[3].ToString(); // Qty
                                PurchaseQty[4] = dr[4].ToString(); // UntID
                                PurchaseQty[5] = dr[5].ToString(); // Invoice
                                PurchaseQty[6] = dr[6].ToString(); // SaleRate
                                PurchaseQty[7] = dr[7].ToString(); // UnitType
                                PurchaseQty[8] = dr[8].ToString(); // WareID







                                if (PurchaseQty[8] == "2")
                                {
                                    try
                                    {

                                        if (PurchaseQty[7] == "Base")
                                        {
                                            PurchaseQty[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(baseqty.ToString()));
                                        }
                                        else if (PurchaseQty[7] == "Default")
                                        {
                                            PurchaseQty[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(defaultqty.ToString()));
                                        }
                                        else
                                        {
                                            PurchaseQty[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(subqty.ToString()));
                                        }

                                        string CheckStock = "select s.sh_Qty as 'Quantity' from ShopStocks s where s.sh_Pcode = '" + PurchaseQty[1].ToString() + "' ";
                                        cmd = new SqlCommand(CheckStock, MainClass.con);
                                        object ob = cmd.ExecuteScalar();


                                        float total = float.Parse(PurchaseQty[3].ToString());
                                        total -= float.Parse(ob.ToString());
                                        MainClass.UpdateShop(int.Parse(PurchaseQty[1]), total);

                                    }

                                    catch (Exception ex)
                                    {
                                        MainClass.con.Close();
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        if (PurchaseQty[7] == "Base")
                                        {
                                            PurchaseQty[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(baseqty.ToString()));
                                        }
                                        else if (PurchaseQty[7] == "Default")
                                        {
                                            PurchaseQty[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(defaultqty.ToString()));
                                        }
                                        else
                                        {
                                            PurchaseQty[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(subqty.ToString()));
                                        }
                                        try
                                        {
                                            cmd = new SqlCommand("select BaseCP from Products where Pcode = '" + PurchaseQty[1].ToString() + "'", MainClass.con);
                                            baserate = cmd.ExecuteScalar();
                                        }
                                        catch (Exception ex)
                                        {
                                            MainClass.con.Close();
                                            MessageBox.Show(ex.Message);
                                        } //Get Base rate

                                        string CheckStock = "select s.st_Qty as 'Quantity' from Stocks s where s.st_Pcode = '" + PurchaseQty[1].ToString() + "' ";
                                        cmd = new SqlCommand(CheckStock, MainClass.con);
                                        object ob = cmd.ExecuteScalar();
                                        float total = float.Parse(PurchaseQty[3].ToString());
                                        total -= float.Parse(ob.ToString());
                                        MainClass.UpdateStock(int.Parse(PurchaseQty[1]), total);

                                    }

                                    catch (Exception ex)
                                    {
                                        MainClass.con.Close();
                                        MessageBox.Show(ex.Message);
                                    }
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
                        cmd = new SqlCommand("delete from PurchaseDetails where Purchase_ID = '" + int.Parse(lblPurchaseID.Text) + "'", MainClass.con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("select SupplierInvoice_ID from Purchases where InvoiceNo = '" + lblInvoice.Text + "'", MainClass.con);
                        object ccid = cmd.ExecuteScalar();

                        foreach (DataGridViewRow products in dgvPurchaseItems.Rows)
                        {

                            string InsertSaleDetails = "insert into PurchaseDetails(Purchase_ID,SupplerInvoice_ID,Product_ID,PurchaseQty,Unit,UnitType,PurchaseRate,SaleRate,TotalofProduct) values (@Purchase_ID,@SupplerInvoice_ID,@Product_ID,@PurchaseQty,@Unit,@UnitType,@PurchaseRate,@SaleRate,@TotalofProduct)";
                            SqlCommand cmd2 = new SqlCommand(InsertSaleDetails, MainClass.con);
                            cmd2.Parameters.AddWithValue("@Purchase_ID", int.Parse(lblPurchaseID.Text));
                            cmd2.Parameters.AddWithValue("@SupplerInvoice_ID", ccid);
                            cmd2.Parameters.AddWithValue("@Product_ID", products.Cells[0].Value);
                            cmd2.Parameters.AddWithValue("@PurchaseQty", products.Cells[4].Value);
                            cmd2.Parameters.AddWithValue("@Unit", products.Cells[5].Value);
                            cmd2.Parameters.AddWithValue("@SaleRate", products.Cells[9].Value);
                            cmd2.Parameters.AddWithValue("@TotalofProduct", products.Cells[8].Value);
                            cmd2.Parameters.AddWithValue("@PurchaseRate", products.Cells[7].Value);
                            cmd2.Parameters.AddWithValue("@UnitType", products.Cells[10].Value);
                            cmd2.ExecuteNonQuery();
                        }


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //Update PurchaseDetails

                    try
                    {
                        foreach (DataGridViewRow sold in dgvPurchaseItems.Rows)
                        {
                            try
                            {
                                cmd = new SqlCommand("select st_Qty from Stocks where st_Pcode = '" + sold.Cells[0].Value.ToString() + "'", MainClass.con);
                                stockqty = cmd.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            } //Get Stock Qty

                            try
                            {
                                cmd = new SqlCommand("select sh_Qty from ShopStocks where sh_Pcode = '" + sold.Cells[0].Value.ToString() + "'", MainClass.con);
                                shopqty = cmd.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            } //Get Shop Qty



                            if (sold.Cells["WarehouseID"].Value.ToString() == "1") //Godown
                            {
                                if (stockqty == null)
                                {

                                    cmd = new SqlCommand("Insert into Stocks (st_Pcode,BaseRate,st_Qty,st_Unit) values(@st_Pcode,@BaseRate,@st_Qty,@st_Unit)", MainClass.con);
                                    cmd.Parameters.AddWithValue("@st_Pcode", sold.Cells[0].Value.ToString());
                                    if (sold.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        cmd.Parameters.AddWithValue("@st_Qty", float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(baseqty.ToString()));
                                    }
                                    else if (sold.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        cmd.Parameters.AddWithValue("@st_Qty", float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(defaultqty.ToString()));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@st_Qty", float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(subqty.ToString()));

                                    }
                                    cmd.Parameters.AddWithValue("@BaseRate", baserate);
                                    cmd.Parameters.AddWithValue("@st_Unit", baseunit);
                                    cmd.ExecuteNonQuery();
                                }
                                else //Updating Godown
                                {
                                    float q = float.Parse((string)stockqty);
                                    if (sold.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q += float.Parse(sold.Cells["QtyGVC"].Value.ToString()) * float.Parse(baseqty.ToString());
                                    }
                                    else if (sold.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q += float.Parse(sold.Cells["QtyGVC"].Value.ToString()) * float.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q += float.Parse(sold.Cells["QtyGVC"].Value.ToString()) * float.Parse(subqty.ToString());
                                    }
                                    MainClass.UpdateStock(int.Parse(sold.Cells[0].Value.ToString()), q);
                                }
                            }
                            else //Shop
                            {
                                if (shopqty == null)
                                {

                                    cmd = new SqlCommand("Insert into ShopStocks (sh_Pcode,BaseRate,sh_Qty,sh_Unit) values(@sh_Pcode,@BaseRate,@sh_Qty,@sh_Unit)", MainClass.con);
                                    cmd.Parameters.AddWithValue("@sh_Pcode", sold.Cells[0].Value.ToString());
                                    if (sold.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        cmd.Parameters.AddWithValue("@sh_Qty", float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(baseqty.ToString()));
                                    }
                                    else if (sold.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        cmd.Parameters.AddWithValue("@sh_Qty", float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(defaultqty.ToString()));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@sh_Qty", float.Parse(sold.Cells[4].Value.ToString()) * float.Parse(subqty.ToString()));

                                    }
                                    cmd.Parameters.AddWithValue("@BaseRate", baserate);
                                    cmd.Parameters.AddWithValue("@sh_Unit", baseunit);
                                    cmd.ExecuteNonQuery();
                                }
                                else //Updating Shop
                                {
                                    float q = float.Parse((string)shopqty);
                                    if (sold.Cells["TypeGV"].Value.ToString() == "Base")
                                    {
                                        q += float.Parse(sold.Cells["QtyGVC"].Value.ToString()) * float.Parse(baseqty.ToString());
                                    }
                                    else if (sold.Cells["TypeGV"].Value.ToString() == "Default")
                                    {
                                        q += float.Parse(sold.Cells["QtyGVC"].Value.ToString()) * float.Parse(defaultqty.ToString());

                                    }
                                    else
                                    {
                                        q += float.Parse(sold.Cells["QtyGVC"].Value.ToString()) * float.Parse(subqty.ToString());

                                    }
                                    MainClass.UpdateShop(int.Parse(sold.Cells[0].Value.ToString()), q);
                                }
                            }
                        }



                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //ReUpdate Inventory
                    try
                    {
                        cmd = new SqlCommand("update SupplierLedgers set InvoiceType = @InvoiceType, InvoiceDate = @InvoiceDate, TotalAmount = @TotalAmount,PaidAmount = @PaidAmount, RemaingBalance = @RemaingBalance where SupplierLedgerID = @SupplierLedgerID ", MainClass.con);
                        cmd.Parameters.AddWithValue("@SupplierLedgerID", int.Parse(lblSupplierLedgerID.Text));
                        cmd.Parameters.AddWithValue("@InvoiceType", txtInvoiceType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtInvoice.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@TotalAmount", float.Parse(txtTotalAmount.Text));
                        cmd.Parameters.AddWithValue("@PaidAmount", float.Parse(txtPayingAmount.Text));
                        cmd.Parameters.AddWithValue("@RemaingBalance", float.Parse(txtRemainingAmount.Text));
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //Update CustomerLedgers


                    MainClass.con.Close();
                    PurchaseReportForm prf = new PurchaseReportForm();
                    prf.Show();
                    CompleteClear();



                }
            }
        }

        private void txtPayingAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPayingAmount.Text != "" || txtPayingAmount.Text == "0")
            {
                float tot = float.Parse(txtTotalAmount.Text);
                float paying = float.Parse(txtPayingAmount.Text);
                txtRemainingAmount.Text = Convert.ToString(tot - paying);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CompleteClear();
        }

        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            object baseunit = null;
            object stockqty = null;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select BaseU from Products where ProductName = '" + cboProductName.Text.ToString() + "'", MainClass.con);
                baseunit = cmd.ExecuteScalar();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } // get Base Unit
            if (cboWarehouse.SelectedIndex != -1)
            {
                if (cboWarehouse.SelectedIndex == 1)
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("select st_Qty from Stocks where st_Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        stockqty = cmd.ExecuteScalar();
                        if (stockqty != null)
                        {
                            txtStockInfo.Text = stockqty.ToString();
                        }
                        else
                        {
                            txtStockInfo.Text = "0";
                        }
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("select sh_Qty from ShopStocks where sh_Pcode = '" + cboProductName.SelectedValue.ToString() + "'", MainClass.con);
                        stockqty = cmd.ExecuteScalar();
                        if (stockqty != null)
                        {
                            txtStockInfo.Text = stockqty.ToString();
                        }
                        else
                        {
                            txtStockInfo.Text = "0";
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Purchase Invoice", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(100, 10));
            e.Graphics.DrawString("Date: " + dtInvoice.Value.ToShortDateString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, 70));
            e.Graphics.DrawString("Supplier: " + cboSupplier.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, 90));
            e.Graphics.DrawString("___________________________________________________________ ", new Font("Helvetica", 12, FontStyle.Regular), Brushes.Black, new Point(0, 95));
            e.Graphics.DrawString("Product ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(25, 115));
            e.Graphics.DrawString("QTY ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(205, 115));
            e.Graphics.DrawString("Unit ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(255, 115));
            e.Graphics.DrawString("Rate ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(320, 115));
            e.Graphics.DrawString("Amount ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(390, 115));
            e.Graphics.DrawString("___________________________________________________________ ", new Font("Helvetica", 12, FontStyle.Regular), Brushes.Black, new Point(0, 115));
            int pos = 140;
            foreach (DataGridViewRow item in dgvPurchaseItems.Rows)
            {

                e.Graphics.DrawString(item.Cells[1].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(25, pos));    //Product
                e.Graphics.DrawString(item.Cells[4].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(210, pos));    // Qty 
                e.Graphics.DrawString(item.Cells[5].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(255, pos));    //Unit
                e.Graphics.DrawString(item.Cells[6].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(320, pos));    //Rate
                e.Graphics.DrawString(item.Cells[8].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(390, pos));    //Total
                pos += 20;
            }
            e.Graphics.DrawString("Total Amount: " + txtGrandTotal.Text.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(250, 65));
            if (cboInvoiceType.Text != "Cash")
            {
                e.Graphics.DrawString("Paying Amount: " + txtPayingAmount.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(250, 80));
                e.Graphics.DrawString("Remaining Balance: " + txtRemainingAmount.Text.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(250, 93));
            }



        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 520, 820);
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }



        private void cboSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                cboProductName.Focus();
            }
        }

        private void cboUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            object stocks = "";
            bool found = false;
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

     

        private void cboProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProducts sp = new SearchProducts(this);
                sp.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewPurchaseInvoices vs = new ViewPurchaseInvoices(this);
            vs.ShowDialog();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            txtTotalAmount.Text = txtGrandTotal.Text;
            txtRemainingAmount.Text = txtGrandTotal.Text;
        }

        private void lblInvoice_TextChanged(object sender, EventArgs e)
        {
            if (lblInvoice.Text != "lblInvocien")
            {
                btnFinalize.Text = "&UPDATE";
                btnFinalize.BackColor = Color.DarkRed;
            }
        }
    }
}
