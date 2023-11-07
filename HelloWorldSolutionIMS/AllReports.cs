using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
namespace HelloWorldSolutionIMS
{
    public partial class AllReports : Form
    {
        int date = 0;
        int saledate = 0;
        int purchasedate = 0;
        public AllReports()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }
        private void ShowInvoices(DataGridView dgv, DataGridViewColumn InvID, DataGridViewColumn Name, DataGridViewColumn InvNO, DataGridViewColumn InvDAte, DataGridViewColumn Type, DataGridViewColumn Total)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if(purchasedate == 1)
                {
                    cmd = new SqlCommand("select si.SupplierInvoiceID,pr.PersonName,p.InvoiceNo,format(si.InvoiceDate,'dd/MM/yyyy') as 'Date',si.PaymentType,p.GrandTotal from SupplierInvoices si inner join Purchases p on p.SupplierInvoice_ID = si.SupplierInvoiceID inner join Persons pr on pr.PersonID = si.Supplier_ID where si.InvoiceDate between '"+dtPurchase1.Value.ToShortDateString()+ "' and '" + dtPurchase2.Value.ToShortDateString() + "' ", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select si.SupplierInvoiceID,pr.PersonName,p.InvoiceNo,format(si.InvoiceDate,'dd/MM/yyyy') as 'Date',si.PaymentType,p.GrandTotal from SupplierInvoices si inner join Purchases p on p.SupplierInvoice_ID = si.SupplierInvoiceID inner join Persons pr on pr.PersonID = si.Supplier_ID", MainClass.con);

                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                InvID.DataPropertyName = dt.Columns["SupplierInvoiceID"].ToString();
                Name.DataPropertyName = dt.Columns["PersonName"].ToString();
                InvNO.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                InvDAte.DataPropertyName = dt.Columns["Date"].ToString();
                Type.DataPropertyName = dt.Columns["PaymentType"].ToString();
                Total.DataPropertyName = dt.Columns["GrandTotal"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void ShowInvoicesCustomer(DataGridView dgv, DataGridViewColumn InvID, DataGridViewColumn Name, DataGridViewColumn InvNO, DataGridViewColumn InvDAte, DataGridViewColumn Type, DataGridViewColumn Total)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if(saledate == 1)
                {
                    cmd = new SqlCommand("select ci.CustomerInvoiceID,pr.PersonName,s.InvoiceNo,format(ci.InvoiceDate,'dd/MM/yyyy') as 'Date',ci.PaymentType,s.GrandTotal from CustomerInvoices ci inner join Sales s on s.CustomerInvoice_ID = ci.CustomerInvoiceID inner join Persons pr on pr.PersonID = ci.Customer_ID where ci.InvoiceDate between '" + dtSale1.Value.ToShortDateString() + "' and '" + dtSale2.Value.ToShortDateString() + "'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select ci.CustomerInvoiceID,pr.PersonName,s.InvoiceNo,format(ci.InvoiceDate,'dd/MM/yyyy') as 'Date',ci.PaymentType,s.GrandTotal from CustomerInvoices ci inner join Sales s on s.CustomerInvoice_ID = ci.CustomerInvoiceID inner join Persons pr on pr.PersonID = ci.Customer_ID", MainClass.con);
                }
                 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                InvID.DataPropertyName = dt.Columns["CustomerInvoiceID"].ToString();
                Name.DataPropertyName = dt.Columns["PersonName"].ToString();
                InvNO.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                InvDAte.DataPropertyName = dt.Columns["Date"].ToString();
                Type.DataPropertyName = dt.Columns["PaymentType"].ToString();
                Total.DataPropertyName = dt.Columns["GrandTotal"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowTransferReports(DataGridView dgv, DataGridViewColumn TID, DataGridViewColumn TProduct, DataGridViewColumn TQty, DataGridViewColumn TUnit, DataGridViewColumn TDate, DataGridViewColumn TTotal)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if(date == 1)
                {
                    cmd = new SqlCommand("select t.TransferID,p.ProductName,t.TransferQty,u.UnitName,t.Date,t.TransferTotal from Transfers t inner join Products p on p.Pcode = t.Pcode inner join Units u on u.UnitID = t.TransferUnit where t.Date between '"+dtTransfer1.Value.ToShortDateString()+"' and '"+dtTransfer2.Value.ToShortDateString()+"'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select t.TransferID,p.ProductName,t.TransferQty,u.UnitName,t.Date,t.TransferTotal from Transfers t inner join Products p on p.Pcode = t.Pcode inner join Units u on u.UnitID = t.TransferUnit", MainClass.con);
                }

                 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TID.DataPropertyName = dt.Columns["TransferID"].ToString();
                TProduct.DataPropertyName = dt.Columns["ProductName"].ToString();
                TQty.DataPropertyName = dt.Columns["TransferQty"].ToString();
                TUnit.DataPropertyName = dt.Columns["UnitName"].ToString();
                TDate.DataPropertyName = dt.Columns["Date"].ToString();
                TTotal.DataPropertyName = dt.Columns["TransferTotal"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void FillPersonWRTTYpe(ComboBox cmb)
        {
            DataTable dtPerson = new DataTable();
            dtPerson.Columns.Add("PersonID");
            dtPerson.Columns.Add("PersonName");
            dtPerson.Rows.Add("0", "-----Select-----");
            if (cboPersonTypes.SelectedIndex != 0)
            {
                try
                {

                    DataTable dt = MainClass.Retrieve("select PersonID,PersonName from Persons where PersonType = '" + cboPersonTypes.SelectedValue + "'");
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow person in dt.Rows)
                            {
                                dtPerson.Rows.Add(person["PersonID"], person["PersonName"]);
                            }
                        }
                    }
                    cmb.DataSource = dtPerson;
                    cmb.DisplayMember = "PersonName";
                    cmb.ValueMember = "PersonID";

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                    cmb.DataSource = dtPerson;

                }
            }
        }



        private void SupplierLedgersInfo(DataGridView dgv, DataGridViewColumn InfoID, DataGridViewColumn LedgerID,
            DataGridViewColumn InvoiceNo, DataGridViewColumn SupplierID, DataGridViewColumn InvoiceDate,
            DataGridViewColumn TotalAmount, DataGridViewColumn LastPaid, DataGridViewColumn TodaysPaid, DataGridViewColumn PayingDate, DataGridViewColumn RemainingBalance,
            DataGridViewColumn PersonAddress)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select si.SupplierLedgersInfoID,si.SupplierLedger_ID,si.InvoiceNo,p.PersonName,si.InvoiceDate,si.TotalAmount,si.LastPaid,si.TodaysPaid,si.PayingDate,si.RemaininigBalance,p.PersonAddress from SupplierLedgersInfo si inner join SupplierLedgers sl on sl.SupplierLedgerID = si.SupplierLedger_ID inner join Persons p on p.PersonID = sl.Supplier_ID where p.PersonID = '" + CboCustomerLedger.SelectedValue.ToString() + "'", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                InfoID.DataPropertyName = dt.Columns["SupplierLedgersInfoID"].ToString();
                LedgerID.DataPropertyName = dt.Columns["SupplierLedger_ID"].ToString();
                InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                SupplierID.DataPropertyName = dt.Columns["PersonName"].ToString();
                InvoiceDate.DataPropertyName = dt.Columns["InvoiceDate"].ToString();
                TotalAmount.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                LastPaid.DataPropertyName = dt.Columns["LastPaid"].ToString();
                TodaysPaid.DataPropertyName = dt.Columns["TodaysPaid"].ToString();
                PayingDate.DataPropertyName = dt.Columns["PayingDate"].ToString();
                RemainingBalance.DataPropertyName = dt.Columns["RemaininigBalance"].ToString();
                PersonAddress.DataPropertyName = dt.Columns["PersonAddress"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void CustomerLedgersInfo(DataGridView dgv, DataGridViewColumn InfoID, DataGridViewColumn LedgerID,
            DataGridViewColumn InvoiceNo, DataGridViewColumn CustomerID, DataGridViewColumn InvoiceDate,
            DataGridViewColumn TotalAmount, DataGridViewColumn LastPaid, DataGridViewColumn TodaysPaid, DataGridViewColumn PayingDate, DataGridViewColumn RemainingBalance,
            DataGridViewColumn PersonAddress)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select si.CustomerLedgersInfoID,si.CustomerLedger_ID,si.InvoiceNo,p.PersonName,si.InvoiceDate,si.TotalAmount,si.LastPaid,si.TodaysPaid,si.PayingDate,si.RemaininigBalance,p.PersonAddress from CustomerLedgersInfo si inner join CustomerLedgers sl on sl.CustomerLedgerID = si.CustomerLedger_ID inner join Persons p on p.PersonID = sl.Customer_ID where p.PersonID = '" + CboCustomerLedger.SelectedValue.ToString() + "'", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                InfoID.DataPropertyName = dt.Columns["CustomerLedgersInfoID"].ToString();
                LedgerID.DataPropertyName = dt.Columns["CustomerLedger_ID"].ToString();
                InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                CustomerID.DataPropertyName = dt.Columns["PersonName"].ToString();
                InvoiceDate.DataPropertyName = dt.Columns["InvoiceDate"].ToString();
                TotalAmount.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                LastPaid.DataPropertyName = dt.Columns["LastPaid"].ToString();
                TodaysPaid.DataPropertyName = dt.Columns["TodaysPaid"].ToString();
                PayingDate.DataPropertyName = dt.Columns["PayingDate"].ToString();
                RemainingBalance.DataPropertyName = dt.Columns["RemaininigBalance"].ToString();
                PersonAddress.DataPropertyName = dt.Columns["PersonAddress"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }



        private void AllReports_Load(object sender, EventArgs e)
        {
            ShowInvoices(dgvPurchaseInvoices, InvoiceIDGVC, SupplierNameGVC, InvoiceNoGVC, DateGVC, TypeGVC, GrandTotalGVC);
            ShowOpeningInfo(DGVOpeniningInfo, IDGV, VoucherIDGV, VoucherDateGV, CustomerGV, BillBookGV, BillNoGV, LastPaidGV, TotalAmountGV, TodayPayingGV, RemainingBalanceGV, PayingDateGV, AddressGV);
            ShowInvoicesCustomer(dgvSaleInvoices, InvoiceIDCGVC, CustomerCGVC, InvoiceNoCGVC, InvoiceDateCGVC, TypeCGVC, TotalCGVC);
            ShowTransferReports(dgvTransfers, TransferIDGVC, ProductNameGVC, QtyGVC, UnitGVC, DateGVCT, totalGVC);
            MainClass.HideAllTabsOnTabControl(tabControl1);
            MainClass.FillWarehouses(cboWarehouses);
            MainClass.FillCustomer(cboCustomer);
            MainClass.FillSupplier(cboSupplierReport);
            MainClass.FillCustomer(cboCustomerReport);
            MainClass.FillPersonTypes(cboPersonTypes);
            PType = 0;
            FillPersonWRTTYpe(CboCustomerLedger);
            GetDailySales();
            GetProductsInGodwn();
            ExpensesShow();
            GetProductsInShop();
            GetLedgerAmounts();
        }

        public static int Invoice_ID = 0;
        private void dgvPurchaseInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dgvPurchaseInvoices.Rows[e.RowIndex];
                Invoice_ID = Convert.ToInt32(row.Cells["InvoiceIDGVC"].Value.ToString());
                PurchaseReportForm prf = new PurchaseReportForm();
                prf.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        public object DailySale;

        private void GetDailySales()
        {
            string sdate = DateTime.Now.ToShortDateString();
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select sum(s.GrandTotal) from Sales s inner join CustomerInvoices ci on ci.CustomerInvoiceID = s.CustomerInvoice_ID where Ci.InvoiceDate between '" + sdate + "' and  '" + sdate + "'", MainClass.con);
                DailySale = cmd.ExecuteScalar();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            lblDailySales.Text = DailySale.ToString();
        }

        public int Proshop = 0;
        public object prosh;

        private void GetProductsInShop()
        {
            try
            {

                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from ShopStocks where sh_Qty > 0 ", MainClass.con);
                prosh = cmd.ExecuteScalar();
                MainClass.con.Close();
                if (prosh != null)
                {

                    MainClass.con.Open();
                    cmd = new SqlCommand("select count(*)  from ShopStocks where sh_Qty < 500 and sh_Unit = '3'", MainClass.con);
                    Proshop += int.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();

                    MainClass.con.Open();
                    cmd = new SqlCommand("select count(*)  from ShopStocks where sh_Qty < 24 and sh_Unit != '3'", MainClass.con);
                    Proshop += int.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();
                    lblInShop.Text = Proshop.ToString();
                }
                else
                {
                    lblInShop.Text = txtnone.Text;
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public int ProGodown = 0;
        public object prodown;

        private void GetProductsInGodwn()
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from Stocks where st_Qty > 0 ", MainClass.con);
                prodown = cmd.ExecuteScalar();
                MainClass.con.Close();
                if (prodown != null)
                {

                    MainClass.con.Open();
                    cmd = new SqlCommand("select count(*)  from Stocks where st_Qty < 500 and st_Unit = '3'", MainClass.con);
                    Proshop += int.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();

                    MainClass.con.Open();
                    cmd = new SqlCommand("select count(*)  from Stocks where st_Qty < 24 and st_Unit != '3'", MainClass.con);
                    Proshop += int.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();
                    lblInHand.Text = Proshop.ToString();
                }
                else
                {
                    lblInHand.Text = txtnone.Text;
                }



            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public object totalLedgers;
        private void GetLedgerAmounts()
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select sum(RemainingBalance) from CustomerLedgers", MainClass.con);
                totalLedgers = cmd.ExecuteScalar();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            lblTotalLedgerCustomer.Text = totalLedgers.ToString();
        }


        public object Expense;

        private void ExpensesShow()
        {
            string sdate = DateTime.Now.ToShortDateString();

            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select sum(ExpensePrice) from Expenses  where ExpenseDate between '" + sdate + "' and '" + sdate + "'", MainClass.con);
                Expense = cmd.ExecuteScalar();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            lblExpense.Text = Expense.ToString();
        }



        private void dgvSaleInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dgvSaleInvoices.Rows[e.RowIndex];
                Invoice_ID = Convert.ToInt32(row.Cells["InvoiceIDCGVC"].Value.ToString());
                SaleReportForm srf = new SaleReportForm();
                srf.Show();

            }
        }
        public static int Other = 0;
        private void cboWarehouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWarehouses.SelectedIndex != 0)
            {
                if (cboWarehouses.Text == "Godown")
                {
                    MainClass.ShowStocks(DGVStocks, stockp, stockq, stocku);
                }
                else
                {
                    Other = 1;
                    MainClass.ShowStocks(DGVStocks, stockp, stockq, stocku);
                }
            }
            else
            {
                DGVStocks.DataSource = null;
            }
        }

        private void btnLedgerReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void btnOpeningReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowOpeningInfo(DGVOpeniningInfo, IDGV, VoucherIDGV, VoucherDateGV, CustomerGV, BillBookGV, BillNoGV, LastPaidGV, TotalAmountGV, TodayPayingGV, RemainingBalanceGV, PayingDateGV, AddressGV, cboCustomer.SelectedValue.ToString());
        }

        private void ShowOpeningInfo(DataGridView dgv, DataGridViewColumn OID, DataGridViewColumn VID, DataGridViewColumn VDate, DataGridViewColumn PersonName, DataGridViewColumn BillBookNo, DataGridViewColumn BillNo, DataGridViewColumn LastPaid,
            DataGridViewColumn TotalAmount, DataGridViewColumn TodayPaying, DataGridViewColumn RemainingBalance, DataGridViewColumn PayingDate, DataGridViewColumn Address, string CID = null)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = null;
                if (CID != null && CID != "System.Data.DataRowView" && CID != "-----Select-----")
                {
                    cmd = new SqlCommand("select oi.OpeningAccountsInfoID,oi.Voucher_ID,oi.VoucherDate,p.PersonName,oi.BillBookNo,oi.BillNo,oi.TotalAmount,oi.LastPaid,oi.TodayPaying,oi.RemainingBalance,oi.PayingDate,oi.Address   from OpeniningAccountsInfo oi inner join Persons p on p.PersonID = oi.Customer_ID where oi.Customer_ID = '" + cboCustomer.SelectedValue.ToString() + "'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select oi.OpeningAccountsInfoID,oi.Voucher_ID,oi.VoucherDate,p.PersonName,oi.BillBookNo,oi.BillNo,oi.TotalAmount,oi.LastPaid,oi.TodayPaying,oi.RemainingBalance,oi.PayingDate,oi.Address   from OpeniningAccountsInfo oi inner join Persons p on p.PersonID = oi.Customer_ID", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                OID.DataPropertyName = dt.Columns["OpeningAccountsInfoID"].ToString();
                VID.DataPropertyName = dt.Columns["Voucher_ID"].ToString();
                VDate.DataPropertyName = dt.Columns["VoucherDate"].ToString();
                PersonName.DataPropertyName = dt.Columns["PersonName"].ToString();
                BillBookNo.DataPropertyName = dt.Columns["BillBookNo"].ToString();
                TotalAmount.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                BillNo.DataPropertyName = dt.Columns["BillNo"].ToString();
                LastPaid.DataPropertyName = dt.Columns["LastPaid"].ToString();
                TodayPaying.DataPropertyName = dt.Columns["TodayPaying"].ToString();
                RemainingBalance.DataPropertyName = dt.Columns["RemainingBalance"].ToString();
                PayingDate.DataPropertyName = dt.Columns["PayingDate"].ToString();
                Address.DataPropertyName = dt.Columns["Address"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static int Customer_ID = 0;
        public static int InfoID = 0;
        private void DGVOpeniningInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select PersonID from Persons where PersonName = '" + DGVOpeniningInfo.CurrentRow.Cells[4].Value.ToString() + "'", MainClass.con);
                    Customer_ID = int.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();

                }
                DataGridViewRow row = DGVOpeniningInfo.Rows[e.RowIndex];
                InfoID = Convert.ToInt32(row.Cells["IDGV"].Value.ToString());
                OpeningBalanceReport orf = new OpeningBalanceReport();
                orf.Show();

            }
        }

        private void cboPersonTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPersonWRTTYpe(CboCustomerLedger);
        }

        private void CboCustomerLedger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPersonTypes.SelectedValue.ToString() == "1")
            {
                guna2DataGridView1.Visible = false;
                DGVLedgerInfo.Visible = true;
                if (CboCustomerLedger.Text != "-----Select-----" && CboCustomerLedger.Text != "System.Data.DataRowView")
                {
                    SupplierLedgersInfo(DGVLedgerInfo, InfoIDGV, LedgerIDGV, InvoiceNoGV, PersonGV, InvoiceDateGV, TotalAmountGGV, LastPaidGGV, TodaysPaidGGV,
                        PayingDateGGV, RemainingBalanceGGV, AddressGGV);
                }
                else
                {
                    if (DGVLedgerInfo.Rows.Count > 0)
                    {

                    }
                }
            }
            else
            {
                guna2DataGridView1.Visible = true;
                DGVLedgerInfo.Visible = false;
                if (CboCustomerLedger.Text != "-----Select-----" && CboCustomerLedger.Text != "System.Data.DataRowView")
                {
                    CustomerLedgersInfo(guna2DataGridView1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11);
                }
                else
                {
                    if (guna2DataGridView1.Rows.Count > 0)
                    {

                    }
                }
            }
        }
        public static int SupInfoID = 0;
        public static int CusInfoID = 0;
        public static int CustID = 0;
        public static int SupID = 0;
        public static int PType = 0;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select PersonID from Persons where PersonName = '" + CboCustomerLedger.Text + "'", MainClass.con);
                CustID = int.Parse(cmd.ExecuteScalar().ToString());
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();

            }


            if (e.ColumnIndex == 0)
            {
                PType = 2;
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                CusInfoID = Convert.ToInt32(row.Cells["C1"].Value.ToString());
                LedgerInfoReportForm lrf = new LedgerInfoReportForm();
                lrf.Show();
            }

        }


        private void DGVLedgerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select PersonID from Persons where PersonName = '" + CboCustomerLedger.Text + "'", MainClass.con);
                SupID = int.Parse(cmd.ExecuteScalar().ToString());
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();

            }

            if (e.ColumnIndex == 0)
            {
                PType = 1;
                DataGridViewRow row = DGVLedgerInfo.Rows[e.RowIndex];
                SupInfoID = Convert.ToInt32(row.Cells["InfoIDGV"].Value.ToString());
                LedgerInfoReportForm lrf = new LedgerInfoReportForm();
                lrf.Show();
            }
        }

        private void btnCustomerStatement_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
        }

        public static int CustomerIDStatement = 0;
        public static int SupllierIDStatement = 0;
        public static int VIEWINVOICEVIACUSTOMER = 0;
        private void btnCustomerLoad_Click(object sender, EventArgs e)
        {
            VIEWINVOICEVIACUSTOMER = 0;
            CustomerIDStatement = int.Parse(cboCustomerReport.SelectedValue.ToString());
            CustomerStatement cs = new CustomerStatement();
            cs.Show();
        }

        private void btnSupplierLoad_Click(object sender, EventArgs e)
        {
            try
            {
                
                MainClass.con.Open();
                int CheckSuporCust = 0;
                SqlCommand cmd = new SqlCommand("select PersonType from Persons where PersonID = '" + cboSupplierReport.SelectedValue.ToString() + "'", MainClass.con);
                int ob = int.Parse(cmd.ExecuteScalar().ToString());
                MainClass.con.Close();
                if (ob == 2)
                {
                    CheckSuporCust = 1;
                }
                else
                {
                    CheckSuporCust = 0;
                }

            }

            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            SupllierIDStatement = int.Parse(cboSupplierReport.SelectedValue.ToString());

            CustomerStatement cs = new CustomerStatement();
            cs.Show();
        }

        private void btnSupplierStatement_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 8;

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] SalesQTY = new string[6];

            SqlCommand cmd = null;
            object salesid = null;
            object customerinvoiceid = null;
            SqlDataReader dr;
            //if (dgvSaleInvoices.SelectedRows.Count == 1)
            {
                try
                {
                    MainClass.con.Open();
                  
                    cmd = new SqlCommand("select SalesID from Sales where InvoiceNo = '" + dgvSaleInvoices.CurrentRow.Cells["InvoiceNoCGVC"].Value.ToString() + "'", MainClass.con);
                    salesid = cmd.ExecuteScalar();
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
                    object BaseQty = null;
                    object DefaultQty = null;
                    object SubQty = null;
                    cmd = new SqlCommand("select s.SalesID,p.Pcode,sd.UnitType,sd.SalesQty,u.UnitID,s.InvoiceNo from Sales s inner join SalesDetails sd on sd.Sales_ID = s.SalesID inner join Products p on p.Pcode = sd.Product_ID inner join Units u on u.UnitID = sd.SalesUnit_ID where s.SalesID = '" + salesid + "'", MainClass.con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SalesQTY[0] = dr[0].ToString();  //Sale ID
                            SalesQTY[1] = dr[1].ToString(); // Pcode
                            SalesQTY[2] = dr[2].ToString(); // UnitType
                            SalesQTY[3] = dr[3].ToString(); // Qty
                            SalesQTY[4] = dr[4].ToString(); // UntID
                            SalesQTY[5] = dr[5].ToString(); // Invoice

                            cmd = new SqlCommand("select BaseQty from Products where Pcode = '" + SalesQTY[1] + "'", MainClass.con);
                            BaseQty =cmd.ExecuteScalar();

                            cmd = new SqlCommand("select DefaultQty from Products where Pcode = '" + SalesQTY[1] + "'", MainClass.con);
                            DefaultQty = cmd.ExecuteScalar();

                            cmd = new SqlCommand("select SubQty from Products where Pcode = '" + SalesQTY[1] + "'", MainClass.con);
                            SubQty = cmd.ExecuteScalar();



                            if (SalesQTY[2] == "Base")
                            {
                                SalesQTY[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(BaseQty.ToString()));
                            }
                            else if (SalesQTY[2] == "Default")
                            {
                                SalesQTY[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(DefaultQty.ToString()));
                            }
                            else 
                            {
                                SalesQTY[3] = Convert.ToString(float.Parse(dr[3].ToString()) * float.Parse(SubQty.ToString()));
                            }
                           

                            try
                            {
                                string CheckStock = "select s.sh_Qty as 'Quantity' from ShopStocks s where s.sh_Pcode = '" + SalesQTY[1].ToString() + "' ";
                                cmd = new SqlCommand(CheckStock, MainClass.con);
                                object ob = cmd.ExecuteScalar();

                                cmd = new SqlCommand("select CustomerInvoice_ID from Sales where InvoiceNo = '" + SalesQTY[5].ToString() + "'", MainClass.con);
                                customerinvoiceid = cmd.ExecuteScalar();

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
                        


                    } // Reverting back to inventory

                    //Deleting iNvoices LEdgers and Infos and Reports
                    cmd = new SqlCommand("update CustomerReport set SaleInvoiceNo = @SaleInvoiceNo,SaleInvoiceDate = @SaleInvoiceDate,SaleTotalAmount = @SaleTotalAmount,SaleLastPaid = @SaleLastPaid,SaleTodaysPaid = @SaleTodaysPaid,SaleLastPayingDate = @SaleLastPayingDate,SaleBalance = @SaleBalance where SaleInvoiceNo = '" + SalesQTY[5].ToString() + "'", MainClass.con);
                    cmd.Parameters.AddWithValue("@SaleInvoiceDate",   DBNull.Value);
                    cmd.Parameters.AddWithValue("@SaleInvoiceNo",     DBNull.Value);
                    cmd.Parameters.AddWithValue("@SaleTotalAmount",   DBNull.Value);
                    cmd.Parameters.AddWithValue("@SaleLastPaid",      DBNull.Value);
                    cmd.Parameters.AddWithValue("@SaleTodaysPaid",    DBNull.Value);
                    cmd.Parameters.AddWithValue("@SaleLastPayingDate",DBNull.Value);
                    cmd.Parameters.AddWithValue("@SaleBalance", DBNull.Value);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("delete from CustomerLedgersInfo where InvoiceNo = '" + SalesQTY[5].ToString() + "'", MainClass.con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from CustomerLedgers  where CustomerInvoice_ID = '"+ customerinvoiceid + "'", MainClass.con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from CustomerInvoices  where CustomerInvoiceID = '" + customerinvoiceid + "'", MainClass.con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from SalesDetails  where CustomerInvoice_ID = '" + customerinvoiceid + "'", MainClass.con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from SalesDetails  where CustomerInvoice_ID = '" + customerinvoiceid + "'", MainClass.con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from Sales where InvoiceNo =  '" + SalesQTY[5].ToString() + "'", MainClass.con);
                    cmd.ExecuteNonQuery();


                    MainClass.con.Close();

                }
                
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Sales Deleted Successfully The Deleted Sale Items are Gone Back to Inventory ");
                
            }
            ShowInvoicesCustomer(dgvSaleInvoices, InvoiceIDCGVC, CustomerCGVC, InvoiceNoCGVC, InvoiceDateCGVC, TypeCGVC, TotalCGVC);

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ShowTransferReports(dgvTransfers, TransferIDGVC, ProductNameGVC, QtyGVC, UnitGVC, DateGVCT, totalGVC);
        }

        private void dtTrasnfer(object sender, EventArgs e)
        {
            if (dtTransfer1.Value == DateTime.Now && dtTransfer1.Value == DateTime.Now)
            {
                date = 0;

            }
            else
            {
                date = 1;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            date = 0;
            dtTransfer1.Value = DateTime.Now;
            dtTransfer2.Value = DateTime.Now;
            ShowTransferReports(dgvTransfers, TransferIDGVC, ProductNameGVC, QtyGVC, UnitGVC, DateGVCT, totalGVC);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowInvoicesCustomer(dgvSaleInvoices, InvoiceIDCGVC, CustomerCGVC, InvoiceNoCGVC, InvoiceDateCGVC, TypeCGVC, TotalCGVC);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saledate = 0;
            dtSale1.Value = DateTime.Now;
            dtSale2.Value = DateTime.Now;
            ShowInvoicesCustomer(dgvSaleInvoices, InvoiceIDCGVC, CustomerCGVC, InvoiceNoCGVC, InvoiceDateCGVC, TypeCGVC, TotalCGVC);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            ShowInvoices(dgvPurchaseInvoices, InvoiceIDGVC, SupplierNameGVC, InvoiceNoGVC, DateGVC, TypeGVC, GrandTotalGVC);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            purchasedate = 0;
            dtPurchase1.Value = DateTime.Now;
            dtPurchase2.Value = DateTime.Now;
            ShowInvoices(dgvPurchaseInvoices, InvoiceIDGVC, SupplierNameGVC, InvoiceNoGVC, DateGVC, TypeGVC, GrandTotalGVC);
        }

        private void PurchaseDAte(object sender, EventArgs e)
        {
            if (dtPurchase1.Value == DateTime.Now && dtPurchase2.Value == DateTime.Now)
            {
                purchasedate = 0;

            }
            else
            {
                purchasedate = 1;

            }
        }

        private void SaleValue(object sender, EventArgs e)
        {
            if (dtSale2.Value == DateTime.Now && dtSale1.Value == DateTime.Now)
            {
                saledate = 0;

            }
            else
            {
                saledate = 1;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CustomerIDStatement = 0;
            VIEWINVOICEVIACUSTOMER = int.Parse(cboCustomerReport.SelectedValue.ToString());
            CustomerIDStatement = int.Parse(cboCustomerReport.SelectedValue.ToString());
            CustomerStatement cs = new CustomerStatement();
            cs.Show();
        }
    }
    
}
