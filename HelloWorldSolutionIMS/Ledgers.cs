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
    public partial class Ledgers : Form
    {
        SqlCommand cmd;
        int changed = 0;
        public Ledgers()
        {
            InitializeComponent();
        }
        
        private void ShowLedgerC(DataGridView dgv, DataGridViewTextBoxColumn InvoiceGV, DataGridViewTextBoxColumn NameGv, DataGridViewTextBoxColumn PhoneGV, DataGridViewTextBoxColumn TypeGV, DataGridViewTextBoxColumn DateGV, DataGridViewTextBoxColumn TotalGV, DataGridViewTextBoxColumn PaidGV, DataGridViewTextBoxColumn BalanceGV)
        {
            try
            {
                MainClass.con.Open();
                if(changed == 1)
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemainingBalance from CustomerLedgers cl inner join Persons p on p.PersonID = cl.Customer_ID inner join Sales s on s.CustomerInvoice_ID = cl.CustomerInvoice_ID where cl.InvoiceType = 'Credit' and  p.PersonName = '" + cboCustomer.Text+ "' and RemainingBalance != '0'", MainClass.con);
                    changed = 0;
                }
                else if(changed == 2)
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemainingBalance from CustomerLedgers cl inner join Persons p on p.PersonID = cl.Customer_ID inner join Sales s on s.CustomerInvoice_ID = cl.CustomerInvoice_ID where cl.InvoiceType = 'Credit' and  p.PersonName = '" + cboCustomer.Text + "'  and cl.InvoiceDate  between '"+dtFrom.Value.ToShortDateString()+"' and '"+dtTo.Value.ToShortDateString() + "'  and RemainingBalance != '0'", MainClass.con);
                    changed = 0;
                }
                else if(changed == 3)
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemainingBalance from CustomerLedgers cl inner join Persons p on p.PersonID = cl.Customer_ID inner join Sales s on s.CustomerInvoice_ID = cl.CustomerInvoice_ID where cl.InvoiceType = 'Credit'  and cl.InvoiceDate  between '" + dtFrom.Value.ToShortDateString() + "' and '"+dtTo.Value.ToShortDateString() + "'  and RemainingBalance != '0'", MainClass.con);
                    changed = 0;
                }
                else
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemainingBalance from CustomerLedgers cl inner join Persons p on p.PersonID = cl.Customer_ID inner join Sales s on s.CustomerInvoice_ID = cl.CustomerInvoice_ID where cl.InvoiceType = 'Credit'  and RemainingBalance != '0'", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                InvoiceGV.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                NameGv.DataPropertyName = dt.Columns["PersonName"].ToString();
                PhoneGV.DataPropertyName = dt.Columns["PersonPhone"].ToString();
                TypeGV.DataPropertyName = dt.Columns["InvoiceType"].ToString();
                DateGV.DataPropertyName = dt.Columns["Date"].ToString();
                TotalGV.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                PaidGV.DataPropertyName = dt.Columns["PaidAmount"].ToString();
                BalanceGV.DataPropertyName = dt.Columns["RemainingBalance"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowLedgerS(DataGridView dgv, DataGridViewTextBoxColumn InvoiceGV, DataGridViewTextBoxColumn NameGv, DataGridViewTextBoxColumn PhoneGV, DataGridViewTextBoxColumn TypeGV, DataGridViewTextBoxColumn DateGV, DataGridViewTextBoxColumn TotalGV, DataGridViewTextBoxColumn PaidGV, DataGridViewTextBoxColumn BalanceGV)
        {
            try
            {
                MainClass.con.Open();
                if (changed == 1)
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemaingBalance from SupplierLedgers cl inner join Persons p on p.PersonID = cl.Supplier_ID inner join Purchases s on s.SupplierInvoice_ID = cl.SupplierInvoice_ID where cl.InvoiceType = 'Credit' and  p.PersonName = '" + cboSupplier.Text + "' and RemaingBalance != '0' ", MainClass.con);
                    changed = 0;
                }
                else if (changed == 2)
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemaingBalance from SupplierLedgers cl inner join Persons p on p.PersonID = cl.Supplier_ID inner join Purchases s on s.SupplierInvoice_ID = cl.SupplierInvoice_ID where cl.InvoiceType = 'Credit' where cl.InvoiceType = 'Credit' and  p.PersonName  = '" + cboSupplier.Text + "'  and cl.InvoiceDate  between '" + dtFromS.Value.ToShortDateString() + "' and '" + dtToS.Value.ToShortDateString() + "' and RemaingBalance != '0' ", MainClass.con);
                    changed = 0;
                }
                else if (changed == 3)
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemaingBalance from SupplierLedgers cl inner join Persons p on p.PersonID = cl.Supplier_ID inner join Purchases s on s.SupplierInvoice_ID = cl.SupplierInvoice_ID where cl.InvoiceType = 'Credit'  and cl.InvoiceDate  between '" + dtFromS.Value.ToShortDateString() + "' and '" + dtToS.Value.ToShortDateString() + "' and RemaingBalance != '0'  ", MainClass.con);
                    changed = 0;
                }
                else
                {
                    cmd = new SqlCommand("select s.InvoiceNo, p.PersonName, p.PersonPhone, cl.InvoiceType, format(cl.InvoiceDate,'dd/MM/yyyy') as 'Date', cl.TotalAmount, cl.PaidAmount, cl.RemaingBalance from SupplierLedgers cl inner join Persons p on p.PersonID = cl.Supplier_ID inner join Purchases s on s.SupplierInvoice_ID = cl.SupplierInvoice_ID where cl.InvoiceType = 'Credit' and RemaingBalance != '0'  ", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                InvoiceGV.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                NameGv.DataPropertyName = dt.Columns["PersonName"].ToString();
                PhoneGV.DataPropertyName = dt.Columns["PersonPhone"].ToString();
                TypeGV.DataPropertyName = dt.Columns["InvoiceType"].ToString();
                DateGV.DataPropertyName = dt.Columns["Date"].ToString();
                TotalGV.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                PaidGV.DataPropertyName = dt.Columns["PaidAmount"].ToString();
                BalanceGV.DataPropertyName = dt.Columns["RemaingBalance"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowTotalC()
        {
            MainClass.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select sum(RemainingBalance) from CustomerLedgers cl inner join Persons p on p.PersonID = cl.Customer_ID where p.PersonName = '" + cboCustomer.Text + "'",MainClass.con);
                TotalBalanceC.Text = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            MainClass.con.Close();
        }

        private void ShowTotalS()
        {
            MainClass.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select sum(RemaingBalance) from SupplierLedgers cl inner join Persons p on p.PersonID = cl.Supplier_ID where p.PersonName = '" + cboSupplier.Text + "'",MainClass.con);
                TotalS.Text = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            MainClass.con.Close();
        }

        private void btnCustomerLedger_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnSupplierLedger_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }
        private void Ledgers_Load(object sender, EventArgs e)
        {
            MainClass.HideAllTabsOnTabControl(tabControl1);
            MainClass.FillCustomer(cboCustomer);
            MainClass.FillSupplier(cboSupplier);
            ShowLedgerC(dgvCustomerLedgers, InvoiceDGV, CustomerNameDGV, PhoneNoDGV, InvoiceTypeDGV, InvoiceDateDGV, TotalAmountDGV, PaidAmountDGV, RemainingBalanceDGV);
            ShowLedgerS(dgvSupplierLedger, InvoiceSGV, SupplierSGV, PhoneSGV, TypeSGV, DateSGV, TotalAmountSGV, PaidSGV, BalanceSGV);
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCustomer.SelectedIndex != 0)
            {
                changed = 1;
                ShowLedgerC(dgvCustomerLedgers, InvoiceDGV, CustomerNameDGV, PhoneNoDGV, InvoiceTypeDGV, InvoiceDateDGV, TotalAmountDGV, PaidAmountDGV, RemainingBalanceDGV);
                ShowTotalC();
            }
            else
            {
                changed = 0;
                ShowLedgerC(dgvCustomerLedgers, InvoiceDGV, CustomerNameDGV, PhoneNoDGV, InvoiceTypeDGV, InvoiceDateDGV, TotalAmountDGV, PaidAmountDGV, RemainingBalanceDGV);
            }
        }

        private void Dtchanged(object sender, EventArgs e)
        {
            if(cboCustomer.SelectedIndex != 0)
            {
                changed = 2;
                ShowLedgerC(dgvCustomerLedgers, InvoiceDGV, CustomerNameDGV, PhoneNoDGV, InvoiceTypeDGV, InvoiceDateDGV, TotalAmountDGV, PaidAmountDGV, RemainingBalanceDGV);
            }
            else
            {
                changed = 3;
                ShowLedgerC(dgvCustomerLedgers, InvoiceDGV, CustomerNameDGV, PhoneNoDGV, InvoiceTypeDGV, InvoiceDateDGV, TotalAmountDGV, PaidAmountDGV, RemainingBalanceDGV);
            }
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSupplier.SelectedIndex != 0)
            {
                changed = 1;
                ShowLedgerS(dgvSupplierLedger, InvoiceSGV, SupplierSGV, PhoneSGV, TypeSGV, DateSGV, TotalAmountSGV, PaidSGV, BalanceSGV);
                ShowTotalS();
            }
            else
            {
                changed = 0;
                ShowLedgerS(dgvSupplierLedger, InvoiceSGV, SupplierSGV, PhoneSGV, TypeSGV, DateSGV, TotalAmountSGV, PaidSGV, BalanceSGV);
            }
        }

        private void DTchanged2(object sender, EventArgs e)
        {
            if (cboSupplier.SelectedIndex != 0)
            {
                changed = 2;
                ShowLedgerS(dgvSupplierLedger, InvoiceSGV, SupplierSGV, PhoneSGV, TypeSGV, DateSGV, TotalAmountSGV, PaidSGV, BalanceSGV);
            }
            else
            {
                changed = 3;
                ShowLedgerS(dgvSupplierLedger, InvoiceSGV, SupplierSGV, PhoneSGV, TypeSGV, DateSGV, TotalAmountSGV, PaidSGV, BalanceSGV);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvCustomerLedgers != null)
            {
                if(dgvCustomerLedgers.Rows.Count > 0)
                {
                    if(dgvCustomerLedgers.SelectedRows.Count == 1)
                    {
                        dgvCustomerLedgers.Enabled = false;
                        lblp.Text = "Customer";
                        float payment = 0;
                        float remain = 0;
                        string name = "";
                        string inv = "";
                        float lastpaid = 0;
                        string invno = "";
                        string contact = "";
                        DateTime invdate = DateTime.Now;
                        GPPAyment.Visible = true;
                        foreach (DataGridViewRow item in dgvCustomerLedgers.Rows)
                        {
                            if(item.Selected == true)
                            {
                                name = item.Cells[1].Value.ToString();
                                contact = item.Cells[2].Value.ToString();
                                payment = float.Parse(item.Cells[5].Value.ToString());
                                remain = float.Parse(item.Cells[7].Value.ToString());
                                inv = item.Cells[0].Value.ToString();
                                invdate = DateTime.ParseExact(item.Cells[4].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                lastpaid = float.Parse(item.Cells[6].Value.ToString());
                                invno = item.Cells[0].Value.ToString();

                             

                            }
                        }
                        txtTotal.Text = payment.ToString();
                        lblCustomer.Text = name.ToString();
                        lblPhone.Text = contact.ToString();
                        txtPrev.Text = remain.ToString();
                        lblInvoice.Text = inv.ToString();
                        dateTimePicker1.Value = DateTime.Parse(invdate.ToString());
                        lblLastPaid.Text = lastpaid.ToString();
                        lblInvoiceNo.Text = invno;
                    }
                }
            }

        }

        

        private void txtPaying_TextChanged(object sender, EventArgs e)
        {
            float tot = 0;
            float pay = 0;
            if (txtPaying.Text != "" || txtPaying.Text == "0")
            {
                 tot = float.Parse(txtPrev.Text.ToString());
                 pay = float.Parse(txtPaying.Text.ToString());
                txtRemaining.Text = Convert.ToString(tot - pay);
            }
            else
            {
                txtRemaining.Text = tot.ToString();
            }
        }

     
        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSupplierLedger != null)
            {
                if (dgvSupplierLedger.Rows.Count > 0)
                {
                    if (dgvSupplierLedger.SelectedRows.Count == 1)
                    {
                        dgvSupplierLedger.Enabled = false;
                        lblp.Text = "Supplier";
                        float payment = 0;
                        float remain = 0;
                        string inv = "";
                        string name = "";
                        string contact = "";
                        float lastpaid = 0;
                        string invno = "";
                        DateTime invdate = DateTime.Now;
                        GPPAyment.Visible = true;
                        foreach (DataGridViewRow item in dgvSupplierLedger.Rows)
                        {
                            if (item.Selected == true)
                            {
                                name = item.Cells[1].Value.ToString();
                                contact = item.Cells[2].Value.ToString();
                                payment = int.Parse(item.Cells[5].Value.ToString());
                                remain = int.Parse(item.Cells[7].Value.ToString());
                                inv = item.Cells[0].Value.ToString();
                                invdate = DateTime.ParseExact(item.Cells[4].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                lastpaid = float.Parse(item.Cells[6].Value.ToString());
                                invno = item.Cells[0].Value.ToString();

                            }
                        }
                        txtTotal.Text = payment.ToString();
                        lblCustomer.Text = name.ToString();
                        lblPhone.Text = contact.ToString();
                        txtPrev.Text = remain.ToString();
                        lblInvoice.Text = inv.ToString();
                        dateTimePicker1.Value = DateTime.Parse(invdate.ToString());
                        lblLastPaid.Text = lastpaid.ToString();
                        lblInvoiceNo.Text = invno;
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }

        public static int changedtype = 0;
        public static int SUPLEDGERID = 0;
        public static int CUSTLEDGERID = 0;


        private void btnPay_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                MainClass.con.Open();
                //get LedgerID
                if (lblp.Text == "Supplier")
                {
                    cmd = new SqlCommand("select sl.SupplierLedgerID from SupplierLedgers sl inner join Purchases p on p.SupplierInvoice_ID = sl.SupplierInvoice_ID where p.InvoiceNo = '" + lblInvoice.Text + "' ", MainClass.con);
                    SUPLEDGERID = int.Parse(cmd.ExecuteScalar().ToString());

                    cmd = new SqlCommand("select PersonID from Persons where PersonName = '"+lblCustomer.Text+"' ", MainClass.con);
                    object supID = cmd.ExecuteScalar();

                    cmd = new SqlCommand("insert into SupplierLedgersInfo (SupplierLedger_ID, Supplier_ID,InvoiceDate,InvoiceNo,TotalAmount,LastPaid,TodaysPaid,PayingDate,RemaininigBalance) values (@SupplierLedger_ID,@Supplier_ID,@InvoiceDate,@InvoiceNo,@TotalAmount,@LastPaid,@TodaysPaid,@PayingDate,@RemaininigBalance)", MainClass.con);
                    cmd.Parameters.AddWithValue("@SupplierLedger_ID", SUPLEDGERID);
                    cmd.Parameters.AddWithValue("@Supplier_ID", supID);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@InvoiceNo", lblInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@LastPaid", lblLastPaid.Text);
                    cmd.Parameters.AddWithValue("@TodaysPaid", txtPaying.Text);
                    cmd.Parameters.AddWithValue("@PayingDate", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@RemaininigBalance", txtRemaining.Text);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("insert into SupplierReport (Supplierer_ID,SaleInvoiceNo,SaleInvoiceDate,SaleTotalAmount,SaleLastPaid,SaleTodaysPaid,SaleLastPayingDate,SaleBalance) values (@Supplierer_ID,@SaleInvoiceNo,@SaleInvoiceDate,@SaleTotalAmount,@SaleLastPaid,@SaleTodaysPaid,@SaleLastPayingDate,@SaleBalance)", MainClass.con);
                    cmd.Parameters.AddWithValue("@Supplierer_ID", supID);
                    cmd.Parameters.AddWithValue("@SaleInvoiceDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@SaleInvoiceNo", lblInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@SaleTotalAmount", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@SaleLastPaid", lblLastPaid.Text);
                    cmd.Parameters.AddWithValue("@SaleTodaysPaid", txtPaying.Text);
                    cmd.Parameters.AddWithValue("@SaleLastPayingDate", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@SaleBalance", txtRemaining.Text);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("update SupplierLedgers set InvoiceDate = @InvoiceDate,PaidAmount = @PaidAmount, RemaingBalance = @RemaingBalance where SupplierLedgerID = @SupplierLedgerID ", MainClass.con);
                    cmd.Parameters.AddWithValue("@SupplierLedgerID", SUPLEDGERID);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@PaidAmount", float.Parse(txtPaying.Text));
                    cmd.Parameters.AddWithValue("@RemaingBalance", float.Parse(txtRemaining.Text));
                    cmd.ExecuteNonQuery();
                    
                }
                else
                {
                    cmd = new SqlCommand("select sl.CustomerLedgerID from CustomerLedgers sl inner join Sales p on p.CustomerInvoice_ID = sl.CustomerInvoice_ID where p.InvoiceNo = '" + lblInvoice.Text + "' ", MainClass.con);
                    CUSTLEDGERID = int.Parse(cmd.ExecuteScalar().ToString());

                    cmd = new SqlCommand("select PersonID from Persons where PersonName = '" + lblCustomer.Text + "' ", MainClass.con);
                    object cuID = cmd.ExecuteScalar();


                    cmd = new SqlCommand("insert into CustomerLedgersInfo (CustomerLedger_ID, Customer_ID,InvoiceDate,InvoiceNo,TotalAmount,LastPaid,TodaysPaid,PayingDate,RemaininigBalance) values (@CustomerLedger_ID,@Customer_ID,@InvoiceDate,@InvoiceNo,@TotalAmount,@LastPaid,@TodaysPaid,@PayingDate,@RemaininigBalance)", MainClass.con);
                    cmd.Parameters.AddWithValue("@CustomerLedger_ID", CUSTLEDGERID);
                    cmd.Parameters.AddWithValue("@Customer_ID", cuID);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@InvoiceNo", lblInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@LastPaid", lblLastPaid.Text);
                    cmd.Parameters.AddWithValue("@TodaysPaid", txtPaying.Text);
                    cmd.Parameters.AddWithValue("@PayingDate", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@RemaininigBalance", txtRemaining.Text);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("insert into CustomerReport (Customer_ID,SaleInvoiceNo,SaleInvoiceDate,SaleTotalAmount,SaleLastPaid,SaleTodaysPaid,SaleLastPayingDate,SaleBalance) values (@Customer_ID,@SaleInvoiceNo,@SaleInvoiceDate,@SaleTotalAmount,@SaleLastPaid,@SaleTodaysPaid,@SaleLastPayingDate,@SaleBalance)", MainClass.con);
                    cmd.Parameters.AddWithValue("@Customer_ID", cuID);
                    cmd.Parameters.AddWithValue("@SaleInvoiceDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@SaleInvoiceNo", lblInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@SaleTotalAmount", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@SaleLastPaid", lblLastPaid.Text);
                    cmd.Parameters.AddWithValue("@SaleTodaysPaid", txtPaying.Text);
                    cmd.Parameters.AddWithValue("@SaleLastPayingDate", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@SaleBalance", txtRemaining.Text);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("update CustomerLedgers set InvoiceDate = @InvoiceDate,PaidAmount = @PaidAmount, RemainingBalance = @RemainingBalance where CustomerLedgerID = @CustomerLedgerID ", MainClass.con);
                    cmd.Parameters.AddWithValue("@CustomerLedgerID", CUSTLEDGERID);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@PaidAmount", float.Parse(txtPaying.Text));
                    cmd.Parameters.AddWithValue("@RemainingBalance", float.Parse(txtRemaining.Text));
                    cmd.ExecuteNonQuery();

                }
                MessageBox.Show("Payment Done");
                MainClass.con.Close();
                ShowLedgerC(dgvCustomerLedgers, InvoiceDGV, CustomerNameDGV, PhoneNoDGV, InvoiceTypeDGV, InvoiceDateDGV, TotalAmountDGV, PaidAmountDGV, RemainingBalanceDGV);
                ShowLedgerS(dgvSupplierLedger, InvoiceSGV, SupplierSGV, PhoneSGV, TypeSGV, DateSGV, TotalAmountSGV, PaidSGV, BalanceSGV);

                if (lblp.Text == "Supplier")
                {
                    changedtype = 1;
                    LedgerReportForm lf = new LedgerReportForm();
                    lf.Show();
                }
                else
                {
                    changedtype = 0;
                    LedgerReportForm lf = new LedgerReportForm();
                    lf.Show();
                }
                GPPAyment.Visible = false;
                txtPaying.Text = "";
                dgvCustomerLedgers.Enabled = true;
                dgvSupplierLedger.Enabled = true;
                




            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GPPAyment.Visible = false;
            dgvCustomerLedgers.Enabled = true;
            txtPaying.Clear();
        }

        private void txtRemaining_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvCustomerLedgers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
