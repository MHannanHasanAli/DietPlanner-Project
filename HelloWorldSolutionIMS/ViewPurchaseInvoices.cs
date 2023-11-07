using HelloWorldSolutionIMS;
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
    public partial class ViewPurchaseInvoices : Form
    {
        PurchaseInvoice pr;
        public ViewPurchaseInvoices()
        {
            InitializeComponent();
        }

        public ViewPurchaseInvoices(PurchaseInvoice p)
        {
            InitializeComponent();
            this.pr = p;
        }

        private void ViewInvoices(DataGridView dgv, DataGridViewColumn SalesID, DataGridViewColumn Person, DataGridViewColumn InvoiceNo,
         DataGridViewColumn Discount, DataGridViewColumn GrandTotal)
        {
            SqlCommand cmd = null;
            cmd = new SqlCommand("select s.PurchaseID,p.PersonName,s.InvoiceNo,s.Discount,s.GrandTotal  from Purchases s inner join SupplierInvoices ci on ci.SupplierInvoiceID = s.SupplierInvoice_ID inner join Persons p on p.PersonID  = ci.Supplier_ID", MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SalesID.DataPropertyName = dt.Columns["PurchaseID"].ToString();
            Person.DataPropertyName = dt.Columns["PersonName"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            Discount.DataPropertyName = dt.Columns["Discount"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
        }

        private void ViewPurchaseInvoices_Load(object sender, EventArgs e)
        {
            ViewInvoices(DGVAllInvoices, IDGV, SupplierGV, InvoiceNoGV, DiscountGV, GrandTotalGV);
        }

        private string[] ProductsData = new string[8];

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataReader dr;
            object invoicetype = null;
            object supplierinvoiceID = null;
            object unitype = null;
            object supplierLedgerID = null;
            DateTime invoicedate = DateTime.Now;
            float total = 0;
            float paid = 0;
            float discount = 0;
            float remain = 0;
            float grandtotal = 0;
            pr.lblInvoice.Text = DGVAllInvoices.CurrentRow.Cells[2].Value.ToString();
            pr.cboSupplier.Text = DGVAllInvoices.CurrentRow.Cells[1].Value.ToString();
            pr.txtSupplierName.Text = DGVAllInvoices.CurrentRow.Cells[1].Value.ToString();
            pr.lblPurchaseID.Text = DGVAllInvoices.CurrentRow.Cells[0].Value.ToString();


            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select SupplierInvoice_ID from Purchases where PurchaseID = '" + DGVAllInvoices.CurrentRow.Cells[0].Value.ToString() + "' ", MainClass.con);
                supplierinvoiceID = cmd.ExecuteScalar().ToString();
                pr.lblSupplierInvoiceID.Text = supplierinvoiceID.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //SupplierInvoiceID
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select SupplierLedgerID from SupplierLedgers where SupplierInvoice_ID = '" + supplierinvoiceID + "' ", MainClass.con);
                supplierLedgerID = cmd.ExecuteScalar().ToString();
                pr.lblSupplierLedgerID.Text = supplierLedgerID.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //SupplierLedgerID
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select PaymentType from SupplierInvoices where SupplierInvoiceID = '" + supplierinvoiceID + "'", MainClass.con);
                invoicetype = cmd.ExecuteScalar().ToString();
                pr.cboInvoiceType.Text = invoicetype.ToString();
                pr.txtInvoiceType.Text = invoicetype.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }//InvoiceType
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select InvoiceDate from SupplierInvoices where SupplierInvoiceID = '" + supplierinvoiceID + "'  ", MainClass.con);
                invoicedate = DateTime.Parse(cmd.ExecuteScalar().ToString());
                pr.txtDated.Text = invoicedate.ToString();
                pr.dtInvoice.Value = invoicedate;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } // InvoiceDate
            try
            {
                int i = 0;
                MainClass.con.Open();
                cmd = new SqlCommand("select Product_ID,p.ProductName,ci.Warehouse_ID,wr.Warehouse,sd.PurchaseQty,sd.Unit,u.UnitName,sd.SaleRate,sd.TotalOfProduct,sd.PurchaseRate,sd.UnitType from PurchaseDetails sd inner join SupplierInvoices ci on sd.SupplerInvoice_ID = ci.SupplierInvoiceID inner join Products p on p.Pcode = sd.Product_ID inner join Warehouses wr on wr.WareID = ci.Warehouse_ID inner join Units u on u.UnitID = sd.Unit where sd.SupplerInvoice_ID = '" + supplierinvoiceID + "'", MainClass.con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    pr.dgvPurchaseItems.Rows.Add(dr["Product_ID"].ToString(), dr["ProductName"].ToString(), dr["Warehouse_ID"].ToString(), dr["Warehouse"].ToString(), float.Parse(dr["PurchaseQty"].ToString()), dr["Unit"].ToString(), dr["UnitName"].ToString(), float.Parse(dr["PurchaseRate"].ToString()), float.Parse(dr["TotalOfProduct"].ToString()), float.Parse(dr["SaleRate"].ToString()), dr["UnitType"].ToString());
                }
                MainClass.con.Close();


            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } //Product getting
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select TotalAmount from SupplierLedgers where SupplierInvoice_ID = '" + supplierinvoiceID + "'", MainClass.con);
                object tot = cmd.ExecuteScalar();
                if (tot.ToString() == "")
                {
                    tot = 0;
                }
                else
                {
                    total = float.Parse(tot.ToString());
                }
                pr.txtTotalAmount.Text = total.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } // totalAmount
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select PaidAmount from SupplierLedgers where SupplierInvoice_ID = '" + supplierinvoiceID + "'", MainClass.con);
                object pai = cmd.ExecuteScalar();
                if (pai.ToString() == "")
                {
                    paid = 0;
                }
                else
                {
                    paid = float.Parse(pai.ToString());
                }
                pr.txtPayingAmount.Text = paid.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //Paid Amount
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select RemaingBalance from SupplierLedgers where SupplierInvoice_ID = '" + supplierinvoiceID + "'", MainClass.con);

                object rem = cmd.ExecuteScalar();
                if (rem.ToString() == "")
                {
                    remain = 0;
                }
                else
                {
                    remain = float.Parse(rem.ToString());
                }
                pr.txtTotalAmount.Text = remain.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //Balance
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select GrandTotal from Purchases where SupplierInvoice_ID = '" + supplierinvoiceID + "'", MainClass.con);
                grandtotal = int.Parse(cmd.ExecuteScalar().ToString());
                pr.txtGrandTotal.Text = grandtotal.ToString();
                MainClass.con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }//GrandTotal
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select Discount from Purchases where SupplierInvoice_ID = '" + supplierinvoiceID + "'", MainClass.con);
                object disc = cmd.ExecuteScalar();
                if (disc.ToString() == "")
                {
                    discount = 0;
                }
                else
                {
                    discount = float.Parse(disc.ToString());
                }
                pr.txtDiscountAmount.Text = discount.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //Discount
            this.Close();
        }
    }
}
