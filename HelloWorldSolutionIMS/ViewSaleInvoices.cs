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
    public partial class ViewSaleInvoices : Form
    {
        SaleInvoice si;
        public ViewSaleInvoices()
        {
            InitializeComponent();
        }

        public ViewSaleInvoices(SaleInvoice s)
        {
            InitializeComponent();
            this.si = s;
        }


        private void ViewInvoices(DataGridView dgv, DataGridViewColumn SalesID, DataGridViewColumn Person, DataGridViewColumn InvoiceNo,
            DataGridViewColumn Discount, DataGridViewColumn GrandTotal)
        {
            SqlCommand cmd = null;
            cmd = new SqlCommand("select s.SalesID,p.PersonName,s.InvoiceNo,s.Discount,s.GrandTotal  from Sales s inner join CustomerInvoices ci on ci.CustomerInvoiceID = s.CustomerInvoice_ID inner join Persons p on p.PersonID  = ci.Customer_ID", MainClass.con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SalesID.DataPropertyName = dt.Columns["SalesID"].ToString();
            Person.DataPropertyName = dt.Columns["PersonName"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            Discount.DataPropertyName = dt.Columns["Discount"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
        }

        private void ViewSaleInvoices_Load(object sender, EventArgs e)
        {
            ViewInvoices(DGVAllInvoices, IDGV, CustomerGV, InvoiceNoGV, DiscountGV,GrandTotalGV);
        }

        private string[] ProductsData = new string[8];
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = null;
            SqlDataReader dr;
            object invoicetype = null;
            object customerinvoiceID = null;
            object unitype = null;
            object customerledgerid = null;
            DateTime invoicedate = DateTime.Now;
            float total = 0;
            float paid = 0;
            float discount = 0;
            float remain = 0;
            float grandtotal = 0;
            si.lblInvoice.Text = DGVAllInvoices.CurrentRow.Cells[2].Value.ToString();
            si.cboCustomer.Text = DGVAllInvoices.CurrentRow.Cells[1].Value.ToString();
            si.txtCustomerName.Text = DGVAllInvoices.CurrentRow.Cells[1].Value.ToString();
            si.lblSalesID.Text = DGVAllInvoices.CurrentRow.Cells[0].Value.ToString();
            
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select PersonPhone from Persons where PersonID = '" + si.cboCustomer.SelectedValue + "' and PersonType = '2'", MainClass.con);
                si.txtContactNo.Text = cmd.ExecuteScalar().ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //Person Contact
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select CustomerInvoice_ID from Sales where SalesID = '" + DGVAllInvoices.CurrentRow.Cells[0].Value.ToString() + "' ", MainClass.con);
                customerinvoiceID = cmd.ExecuteScalar().ToString();
                si.lblCustomerInvoiceID.Text = customerinvoiceID.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //CustomerInvoiceID

            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select CustomerLedgerID from CustomerLedgers where CustomerInvoice_ID = '"+customerinvoiceID+"' ", MainClass.con);
                customerledgerid = cmd.ExecuteScalar().ToString();
                si.lblCustomerLedgerID.Text = customerledgerid.ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //CustomerLedgerID

            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select PaymentType from CustomerInvoices where CustomerInvoiceID = '" + customerinvoiceID + "'", MainClass.con);
                invoicetype = cmd.ExecuteScalar().ToString();
                si.cboInvoiceType.Text = invoicetype.ToString();
                si.txtInvoiceType.Text = invoicetype.ToString();
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
                cmd = new SqlCommand("select InvoiceDate from CustomerInvoices where CustomerInvoiceID = '" + customerinvoiceID + "'  ",MainClass.con);
                invoicedate = DateTime.Parse(cmd.ExecuteScalar().ToString());
                si.txtDated.Text = invoicedate.ToString();
                si.dtInvoice.Value = invoicedate;
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
                cmd = new SqlCommand("select Product_ID,p.ProductName,ci.Warehouse_ID,wr.Warehouse,sd.SalesQty,sd.SalesUnit_ID,u.UnitName,sd.SalesRate,sd.TotalOfProduct,sd.PurchaseRate,sd.UnitType from SalesDetails sd inner join CustomerInvoices ci on sd.CustomerInvoice_ID = ci.CustomerInvoiceID inner join Products p on p.Pcode = sd.Product_ID inner join Warehouses wr on wr.WareID = ci.Warehouse_ID inner join Units u on u.UnitID = sd.SalesUnit_ID where sd.CustomerInvoice_ID = '" + customerinvoiceID + "'", MainClass.con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    si.dgvSaleItems.Rows.Add(dr["Product_ID"].ToString(), dr["ProductName"].ToString(), dr["Warehouse_ID"].ToString(), dr["Warehouse"].ToString(), float.Parse(dr["SalesQty"].ToString()), dr["SalesUnit_ID"].ToString(), dr["UnitName"].ToString(), float.Parse(dr["SalesRate"].ToString()),  float.Parse(dr["TotalOfProduct"].ToString()), float.Parse(dr["PurchaseRate"].ToString()), dr["UnitType"].ToString());
                }
                MainClass.con.Close();
            
              
            }
            catch (Exception  ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } //Product getting

            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select TotalAmount from CustomerLedgers where CustomerInvoice_ID = '" + customerinvoiceID + "'", MainClass.con);
                object tot = cmd.ExecuteScalar();
                if (tot.ToString() == "")
                {
                    tot = 0;
                }
                else
                {
                    total = float.Parse(tot.ToString());
                }
                si.txtTotalAmount.Text = total.ToString();
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
                cmd = new SqlCommand("select PaidAmount from CustomerLedgers where CustomerInvoice_ID = '" + customerinvoiceID + "'", MainClass.con);
                object pai = cmd.ExecuteScalar();
                if (pai.ToString() == "")
                {
                    paid = 0;
                }
                else
                {
                    paid = float.Parse(pai.ToString());
                }
                si.txtPayingAmount.Text = paid.ToString();
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
                cmd = new SqlCommand("select RemainingBalance from CustomerLedgers where CustomerInvoice_ID = '" + customerinvoiceID + "'", MainClass.con);

                object rem = cmd.ExecuteScalar();
                if (rem.ToString() == "")
                {
                    remain = 0;
                }
                else
                {
                    remain = float.Parse(rem.ToString());
                }
                si.txtTotalAmount.Text = remain.ToString();
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
                cmd = new SqlCommand("select GrandTotal from Sales where CustomerInvoice_ID = '" + customerinvoiceID + "'", MainClass.con);
                grandtotal = int.Parse(cmd.ExecuteScalar().ToString());
                si.txtGrandTotal.Text = grandtotal.ToString();
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
                cmd = new SqlCommand("select Discount from Sales where CustomerInvoice_ID = '" + customerinvoiceID + "'", MainClass.con);
                object disc = cmd.ExecuteScalar();
                if(disc.ToString() == "")
                {
                    discount = 0;
                }
                else
                {
                    discount = float.Parse(disc.ToString());
                }
                si.txtDiscountAmount.Text = discount.ToString();
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
