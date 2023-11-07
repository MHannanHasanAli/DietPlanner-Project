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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Xml;

namespace HelloWorldSolutionIMS
{
    public partial class OpeningBalance : Form
    {
        int view = 0;
        bool paymentmode = false;
        public OpeningBalance()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }

        private void ClearGB()
        {
            txtBillBookNo.Text = "";
            txtBillNo.Text = "";
            txtDueAmount.Text = "";
            txtPaidAmount.Text = "";
            txtRemarks.Text = "";
            lblHassan.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            cboPersonType.Focus();
        }
        private void ClearGB1()
        {
            view = 10;
            if(txtBillNoFilter.Text != "" || txtBillBookFilter.Text != "")
            {
                txtBillNoFilter.Text = "";
                txtBillBookFilter.Text = "";
            }
            if (cboTypeFilter.SelectedIndex != 0 || cbonameFilter.SelectedIndex != 0)
            {
                cboTypeFilter.SelectedIndex = 0;
              cbonameFilter.SelectedIndex = -1;
            }
        }
        private void FillPersonWRTTYpe(ComboBox cmb)
        {
            DataTable dtPerson = new DataTable();
            dtPerson.Columns.Add("PersonID");
            dtPerson.Columns.Add("PersonName");
            dtPerson.Rows.Add("0", "-----Select-----");

            if (cboPersonType.SelectedIndex != 0)
            {
                try
                {

                    DataTable dt = MainClass.Retrieve("select PersonID,PersonName from Persons where PersonType = '" + cboPersonType.SelectedValue + "'");
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
                    cmb.DisplayMember = "PersonName";
                    cmb.ValueMember = "PersonID";
                    cmb.DataSource = dtPerson;
                    

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                    cmb.DataSource = dtPerson;

                }
            }
        }

        private void FillPersonWRTTYpeFilter(ComboBox cmb)
        {
            DataTable dtPerson = new DataTable();
            dtPerson.Columns.Add("PersonID");
            dtPerson.Columns.Add("PersonName");
            dtPerson.Rows.Add("0", "-----Select-----");
            if (cboTypeFilter.SelectedIndex != 0 && cboTypeFilter.SelectedIndex != -1)
            {
                try
                {
                    DataTable dt = MainClass.Retrieve("select PersonID,PersonName from Persons where PersonType = '" + cboTypeFilter.SelectedValue + "'");
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
                    cmb.DisplayMember = "PersonName";
                    cmb.ValueMember = "PersonID";
                    cmb.DataSource = dtPerson;
                    


                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                    cmb.DataSource = dtPerson;

                }
            }

        }



        private void ShowBills(DataGridView dgv, DataGridViewColumn voucherID, DataGridViewColumn voucherDate, DataGridViewColumn PersonTypeID, DataGridViewColumn PersonType, DataGridViewColumn PersonID, DataGridViewColumn PersonName, DataGridViewColumn Remarks, DataGridViewColumn BillBookNo, DataGridViewColumn BillNo, DataGridViewColumn totalAmount, DataGridViewColumn DueAmount, DataGridViewColumn PaidAmount,DataGridViewColumn Address)
        {
            SqlCommand cmd = null;
            MainClass.con.Open();
            try
            {

                if (view == 1)
                {
                    cmd = new SqlCommand("select op.VoucherID,format(op.VoucherDate,'dd/MM/yyyy') as 'Date',op.PesonType_ID,pt.PersonType,op.PersonName_ID,p.PersonName,op.Remarks,op.BillNo,op.BillBookNo,op.TotalAmount,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where op.PesonType_ID = '" + cboTypeFilter.SelectedValue + "' and op.PersonName_ID = '" + cbonameFilter.SelectedValue + "' order by VoucherID", MainClass.con);
                }
                else if (view == 2)
                {
                    cmd = new SqlCommand("select op.VoucherID,format(op.VoucherDate,'dd/MM/yyyy') as 'Date',op.PesonType_ID,pt.PersonType,op.PersonName_ID,p.PersonName,op.Remarks,op.BillNo,op.BillBookNo,op.TotalAmount,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where DueAmount = '0' order by VoucherID", MainClass.con);
                }
                else if (view == 3)
                {
                    cmd = new SqlCommand("select op.VoucherID,format(op.VoucherDate,'dd/MM/yyyy') as 'Date',op.PesonType_ID,pt.PersonType,op.PersonName_ID,p.PersonName,op.Remarks,op.BillNo,op.BillBookNo,op.TotalAmount,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where DueAmount != '0' order by VoucherID", MainClass.con);
                }

                else if (view == 4)
                {
                    cmd = new SqlCommand("select op.VoucherID,format(op.VoucherDate,'dd/MM/yyyy') as 'Date',op.PesonType_ID,pt.PersonType,op.PersonName_ID,p.PersonName,op.Remarks,op.BillNo,op.BillBookNo,op.TotalAmount,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where op.BillBookNo = '" + txtBillBookFilter.Text+ "' and op.PersonName_ID = '" + cbonameFilter.SelectedValue + "'  order by VoucherID", MainClass.con);
                    view = 0;
                }
                else if (view == 5)
                {
                    cmd = new SqlCommand("select op.VoucherID,format(op.VoucherDate,'dd/MM/yyyy') as 'Date',op.PesonType_ID,pt.PersonType,op.PersonName_ID,p.PersonName,op.Remarks,op.BillNo,op.BillBookNo,op.TotalAmount,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where op.BillBookNo = '" + txtBillBookFilter.Text + "'  and op.BillNo = '" + txtBillNoFilter.Text + "' and op.PersonName_ID = '" + cbonameFilter.SelectedValue + "'  order by VoucherID", MainClass.con);
                    view = 0;
                }
                else if(view ==10)
                {
                   cmd = new SqlCommand("select op.VoucherID,format(op.VoucherDate,'dd/MM/yyyy') as 'Date',op.PesonType_ID,pt.PersonType,op.PersonName_ID,p.PersonName,op.Remarks,op.BillNo,op.BillBookNo,op.TotalAmount,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID order by VoucherID", MainClass.con);
                    view = 0;
                }
                else
                {
                    cmd = new SqlCommand("select op.VoucherID,format(op.VoucherDate,'dd/MM/yyyy') as 'Date',op.PesonType_ID,pt.PersonType,op.PersonName_ID,p.PersonName,op.Remarks,op.BillNo,op.BillBookNo,op.TotalAmount,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID order by VoucherID", MainClass.con);
                }



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                voucherID.DataPropertyName = dt.Columns["VoucherID"].ToString();
                voucherDate.DataPropertyName = dt.Columns["Date"].ToString();
                PersonTypeID.DataPropertyName = dt.Columns["PesonType_ID"].ToString();
                PersonType.DataPropertyName = dt.Columns["PersonType"].ToString();
                PersonID.DataPropertyName = dt.Columns["PersonName_ID"].ToString();
                PersonName.DataPropertyName = dt.Columns["PersonName"].ToString();
                totalAmount.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();
                BillBookNo.DataPropertyName = dt.Columns["BillBookNo"].ToString();
                BillNo.DataPropertyName = dt.Columns["BillNo"].ToString();
                DueAmount.DataPropertyName = dt.Columns["DueAmount"].ToString();
                PaidAmount.DataPropertyName = dt.Columns["PaidAmount"].ToString();
                Address.DataPropertyName = dt.Columns["Address"].ToString();
                dgv.DataSource = dt;
            }

            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            MainClass.con.Close();

        }

        private void OpeningBalance_Load(object sender, EventArgs e)
        {
           MainClass.FillPersonTypes(cboPersonType);
            FillPersonWRTTYpe(cboPersonName);


            MainClass.FillPersonTypes(cboTypeFilter);
            FillPersonWRTTYpeFilter(cbonameFilter);

            txtDueAmount.Enabled = false;
        }

        private void cboPersonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPersonWRTTYpe(cboPersonName);
            view = 11;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }


        public static int VOUCHERID = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;

            if (btnSave.Text == "&SAVE")
            {
                if (txtBillBookNo.Text == "" || txtBillNo.Text == "" || lblHassan.Text == "" || cboPersonType.SelectedIndex == 0 && cboPersonName.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Fill Details Missing");
                    return;
                }
                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("insert into OpeningAccounts (VoucherDate,PesonType_ID,PersonName_ID,Remarks,BillNo,TotalAmount,BillBookNo,DueAmount,PaidAmount,Address) values (@VoucherDate,@PesonType_ID,@PersonName_ID,@Remarks,@BillNo,@TotalAmount,@BillBookNo,@DueAmount,@PaidAmount,@Address)", MainClass.con);
                    cmd.Parameters.AddWithValue("@VoucherDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@PesonType_ID", cboPersonType.SelectedValue);
                    cmd.Parameters.AddWithValue("@PersonName_ID", cboPersonName.SelectedValue);
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                    cmd.Parameters.AddWithValue("@BillNo", txtBillNo.Text);
                    cmd.Parameters.AddWithValue("@BillBookNo", txtBillBookNo.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", lblHassan.Text);
                    cmd.Parameters.AddWithValue("@DueAmount", lblHassan.Text);
                    cmd.Parameters.AddWithValue("@PaidAmount", txtPaidAmount.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();

                    if (cboPersonType.SelectedValue.ToString() == "1")
                    {
                        cmd = new SqlCommand("insert into SupplierReport (Supplier_ID,OVoucherID,OVoucherDate,OBillBookNo,OBillNo,OTotalAmount,OLastPaid,OPayingDate,OBalance,Address)" +
                               "values (@Supplier_ID,@OVoucherID,@OVoucherDate,@OBillBookNo,@OBillNo,@OTotalAmount,@OLastPaid,@OPayingDate,@OBalance,@Address)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Supplier_ID", cboPersonName.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@OVoucherID", lblID.Text);
                        cmd.Parameters.AddWithValue("@OVoucherDate", dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBillBookNo", txtBillBookNo.Text);
                        cmd.Parameters.AddWithValue("@OBillNo", txtBillNo.Text);
                        cmd.Parameters.AddWithValue("@OTotalAmount", lblHassan.Text);
                        cmd.Parameters.AddWithValue("@OLastPaid", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@OPayingDate", dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBalance", lblHassan.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into CustomerReport (Customer_ID,OVoucherDate,OBillBookNo,OBillNo,OTotalAmount,OLastPaid,OPayingDate,OBalance,Address)" +
                            "values (@Customer_ID,@OVoucherDate,@OBillBookNo,@OBillNo,@OTotalAmount,@OLastPaid,@OPayingDate,@OBalance,@Address)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboPersonName.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@OVoucherDate", dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBillBookNo", txtBillBookNo.Text);
                        cmd.Parameters.AddWithValue("@OBillNo", txtBillNo.Text);
                        cmd.Parameters.AddWithValue("@OTotalAmount", lblHassan.Text);
                        cmd.Parameters.AddWithValue("@OLastPaid", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@OPayingDate", dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBalance", lblHassan.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }


                    MainClass.con.Close();
                    MessageBox.Show("Bill Saved");
                    view = 10;
                    ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV,TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);
                    ClearGB();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } //Insert into Openingaccounts
            }
            else if (btnSave.Text == "&PAY")
            {

                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("update OpeningAccounts set DueAmount = @DueAmount , PaidAmount = @PaidAmount where VoucherID = @VoucherID ", MainClass.con);
                    cmd.Parameters.AddWithValue("@DueAmount", txtDueAmount.Text);
                    cmd.Parameters.AddWithValue("@PaidAmount", txtPaidAmount.Text);
                    cmd.Parameters.AddWithValue("@VoucherID", lblID.Text);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    cmd = new SqlCommand("insert into OpeniningAccountsInfo (Voucher_ID,VoucherDate,Customer_ID,BillBookNo,BillNo,LastPaid,TotalAmount,TodayPaying,RemainingBalance,PayingDate,Address )" +
                       "values (@Voucher_ID,@VoucherDate,@Customer_ID,@BillBookNo,@BillNo,@LastPaid,@TotalAmount,@TodayPaying,@RemainingBalance,@PayingDate,@Address)", MainClass.con);
                    cmd.Parameters.AddWithValue("@Voucher_ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@VoucherDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Customer_ID", cboPersonName.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BillBookNo", txtBillBookNo.Text);
                    cmd.Parameters.AddWithValue("@BillNo", txtBillNo.Text);
                    cmd.Parameters.AddWithValue("@LastPaid", txtPaidAmount.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", lbltotal.Text);
                    cmd.Parameters.AddWithValue("@TodayPaying", txtPaidAmount.Text);
                    cmd.Parameters.AddWithValue("@RemainingBalance", txtDueAmount.Text);
                    cmd.Parameters.AddWithValue("@PayingDate", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();


                    if(cboPersonType.SelectedValue.ToString() == "1")
                    {
                        cmd = new SqlCommand("insert into SupplierReport (Supplier_ID,OVoucherID,OVoucherDate,OBillBookNo,OBillNo,OTotalAmount,OLastPaid,OTodaysPaid,OPayingDate,OBalance,Address)" +
                            "values (@Supplier_ID,@OVoucherID,@OVoucherDate,@OBillBookNo,@OBillNo,@OTotalAmount,@OLastPaid,@OTodaysPaid,@OPayingDate,@OBalance,@Address)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Supplier_ID", cboPersonName.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@OVoucherID", lblID.Text);
                        cmd.Parameters.AddWithValue("@OVoucherDate", dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBillBookNo", txtBillBookNo.Text);
                        cmd.Parameters.AddWithValue("@OBillNo", txtBillNo.Text);
                        cmd.Parameters.AddWithValue("@OTotalAmount", lbltotal.Text);
                        cmd.Parameters.AddWithValue("@OLastPaid", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@OTodaysPaid", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@OPayingDate", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBalance", txtDueAmount.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into CustomerReport (Customer_ID,OVoucherID,OVoucherDate,OBillBookNo,OBillNo,OTotalAmount,OLastPaid,OTodaysPaid,OPayingDate,OBalance,Address)" +
                            "values (@Customer_ID,@OVoucherID,@OVoucherDate,@OBillBookNo,@OBillNo,@OTotalAmount,@OLastPaid,@OTodaysPaid,@OPayingDate,@OBalance,@Address)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboPersonName.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@OVoucherID", lblID.Text);
                        cmd.Parameters.AddWithValue("@OVoucherDate", dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBillBookNo", txtBillBookNo.Text);
                        cmd.Parameters.AddWithValue("@OBillNo", txtBillNo.Text);
                        cmd.Parameters.AddWithValue("@OTotalAmount", lbltotal.Text);
                        cmd.Parameters.AddWithValue("@OLastPaid", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@OTodaysPaid", txtPaidAmount.Text);
                        cmd.Parameters.AddWithValue("@OPayingDate", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@OBalance", txtDueAmount.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MainClass.con.Close();
                    MessageBox.Show("Payment Successful");
                    VOUCHERID = int.Parse(lblID.Text);
                    ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV, TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);
                    btnCancel.PerformClick();
                    OpeningBalanceReport op = new OpeningBalanceReport();
                    op.ShowDialog();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } //Paying
                                                                 
                                                                                       

            }
            else
            {
                if (btnSave.Text == "&UPDATE")
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("update OpeningAccounts set VoucherDate= @VoucherDate, PesonType_ID = @PesonType_ID, PersonName_ID = @PersonName_ID,Remarks = @Remarks," +
                       " BillNo = @BillNo,BillBookNo = @BillBookNo,Address = @Address, DueAmount = @DueAmount , PaidAmount = @PaidAmount where VoucherID = @VoucherID ", MainClass.con);
                    cmd.Parameters.AddWithValue("@VoucherDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@PesonType_ID", cboPersonType.SelectedValue);
                    cmd.Parameters.AddWithValue("@PersonName_ID", cboPersonName.SelectedValue);
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                    cmd.Parameters.AddWithValue("@BillNo", txtBillNo.Text);
                    cmd.Parameters.AddWithValue("@BillBookNo", txtBillBookNo.Text);
                    cmd.Parameters.AddWithValue("@DueAmount", lblHassan.Text);
                    cmd.Parameters.AddWithValue("@PaidAmount", txtPaidAmount.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@VoucherID", lblID.Text);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                    MessageBox.Show("Update Successful");
                    view = 10;
                    ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV, TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);
                    btnCancel.PerformClick();
                }
            }
        }

        private void cbonameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            object PersonTotal = null;
            if (cbonameFilter.SelectedIndex != -1 && cbonameFilter.SelectedIndex != 0)
            {
                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("select sum(DueAmount) from OpeningAccounts where PesonType_ID = '" + cboTypeFilter.SelectedValue.ToString() + "' and  PersonName_ID = '" + cbonameFilter.SelectedValue.ToString() + "'", MainClass.con);
                    PersonTotal = cmd.ExecuteScalar();
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
                if (PersonTotal != null)
                {
                    txtPersonTotal.Text = PersonTotal.ToString();
                }
                else
                {
                    txtPersonTotal.Text = "0";
                }
            }
            else
            {
                txtPersonTotal.Text = "";
            }

        }

        private void cboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPersonWRTTYpeFilter(cbonameFilter);
            view = 4;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearGB1();
            ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV, TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);
        }

        private void PaymentMode()
        {
            paymentmode = true;
            BillEntryGB.Text = "BILL PAYMENT";
            DGVBills.Enabled = false;
            BillEntryGB.CustomBorderColor = Color.Teal;
            btnSave.Text = "&PAY";
            btnSave.BackColor = Color.Teal;
            dateTimePicker1.Enabled = false;
            lblHassan.Enabled = false;
            cboPersonType.Enabled = false;
            cboPersonName.Enabled = false;
            txtRemarks.Enabled = false;
            txtBillBookNo.Enabled = false;
            txtBillNo.Enabled = false;
            txtDueAmount.Enabled = false;
            txtPaidAmount.Enabled = true;
            dateTimePicker1.Value = DateTime.ParseExact(DGVBills.CurrentRow.Cells[1].Value.ToString(),"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); 
            cboPersonType.Text = DGVBills.CurrentRow.Cells[3].Value.ToString();
            cboPersonName.Text = DGVBills.CurrentRow.Cells[5].Value.ToString();
            txtRemarks.Text = DGVBills.CurrentRow.Cells[6].Value.ToString();
            txtBillBookNo.Text = DGVBills.CurrentRow.Cells[8].Value.ToString();
            lblID.Text = DGVBills.CurrentRow.Cells[0].Value.ToString();
            txtBillNo.Text = DGVBills.CurrentRow.Cells[7].Value.ToString();
            lblLastPaid.Text = DGVBills.CurrentRow.Cells[11].Value.ToString();


            lbltotal.Text = DGVBills.CurrentRow.Cells[9].Value.ToString();
            lblHassan.Text = DGVBills.CurrentRow.Cells[10].Value.ToString();

            txtPaidAmount.Focus();
        }
        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVBills != null)
            {
                if (DGVBills.Rows.Count > 0)
                {
                    if (DGVBills.SelectedRows.Count == 1)
                    {

                        if (DGVBills.CurrentRow.Cells[9].Value.ToString() == "0")
                        {
                            MessageBox.Show("Payment Paid Already");
                            return;
                        }
                        else
                        {
                            PaymentMode();
                        }
                    }
                }
            }
        }

        private void DGVBills_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (DGVBills.CurrentRow.Cells[9].Value.ToString() == "0")
                {
                    MessageBox.Show("Payment Paid Already");
                    return;
                }
                else
                {
                    PaymentMode();
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbonameFilter.SelectedIndex == -1 && cboTypeFilter.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Person");
            }
            else if (cbonameFilter.SelectedIndex == 0 )
            {
                MessageBox.Show("Please Select Person");
            }
            else if (cboTypeFilter.SelectedIndex != 0 && cbonameFilter.SelectedIndex != 0)
            {
                if (txtBillBookFilter.Text != "")
                {
                    if (txtBillNoFilter.Text != "")
                    {
                        view = 5;
                    }
                    else
                    {
                        view = 4;
                    }
                }
                
                else
                {
                    view = 1;
                }
                ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV, TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DGVBills.Enabled = true;
            BillEntryGB.CustomBorderColor = Color.CornflowerBlue;
            btnSave.Text = "&SAVE";
            btnSave.BackColor = Color.CornflowerBlue;
            dateTimePicker1.Enabled = true;
            cboPersonType.Enabled = true;
            cboPersonName.Enabled = true;
            txtRemarks.Enabled = true;
            lblHassan.Enabled = false;
            txtBillBookNo.Enabled = true;
            txtBillNo.Enabled = true;
            txtPaidAmount.Text = "0";
            lblHassan.Enabled = true;
            lblID.Text = "ID";
            txtPaidAmount.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            ClearGB();
            txtPaidAmount.Focus();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            view = 2;
            ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV, TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view = 3;
            ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV, TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (paymentmode == true)
            {
                Int32 due = 0;
                Int32 tot = 0;
                Int32 pay = 0;
                if(txtPaidAmount.Text != "" || txtPaidAmount.Text == "0")
                {
                    due = int.Parse(lblHassan.Text.ToString());
                    pay = int.Parse(txtPaidAmount.Text.ToString());
                    tot = due - pay;
                    txtDueAmount.Text = tot.ToString();
                }
                else
                {
                    txtDueAmount.Text = lblHassan.Text;
                }
                
               
            }
        
        }

        private void cboPersonName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPersonName.SelectedIndex != 0)
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select PersonAddress from Persons where PersonID = '" + cboPersonName.SelectedValue + "'", MainClass.con);
                    txtAddress.Text = cmd.ExecuteScalar().ToString();
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
            else
            {
                txtAddress.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpeniningExport op = new OpeniningExport();
            op.ShowDialog();
        }

        private void txtBillBookFilter_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.Text = "&UPDATE";
            if(DGVBills.SelectedRows.Count == 1)
            {
                dateTimePicker1.Value = DateTime.ParseExact(DGVBills.CurrentRow.Cells[1].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                cboPersonType.Text = DGVBills.CurrentRow.Cells[3].Value.ToString();
                cboPersonName.Text = DGVBills.CurrentRow.Cells[5].Value.ToString();
                txtRemarks.Text = DGVBills.CurrentRow.Cells[6].Value.ToString();
                txtBillBookNo.Text = DGVBills.CurrentRow.Cells[8].Value.ToString();
                lblID.Text = DGVBills.CurrentRow.Cells[0].Value.ToString();
                txtBillNo.Text = DGVBills.CurrentRow.Cells[7].Value.ToString();
                lblHassan.Text = DGVBills.CurrentRow.Cells[9].Value.ToString();
                txtDueAmount.Text = DGVBills.CurrentRow.Cells[9].Value.ToString();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DGVBills.SelectedRows.Count == 1)
            {
                if(MessageBox.Show("Do you want to delete this records?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("delete from OpeningAccounts where VoucherID = @VoucherID", MainClass.con);
                    cmd.Parameters.AddWithValue("@VoucherID", DGVBills.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully");
                    MainClass.con.Close();
                    view = 10;
                    ShowBills(DGVBills, VoucherIDGV, VoucherDateGV, PersonTypeIDGV, PersonTypeGV, PersonIDGV, PersonNameGV, RemarksGV, BillBookNoGV, BillNoGV, TotalAmountGV, DueAmountGV, PaidAmountGV, AddressGV);

                }
                else
                {
                    return;
                }
            }
        }

        public static int Cust_ID = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            OpeninigReciept o = new OpeninigReciept();
            Cust_ID =int.Parse(cbonameFilter.SelectedIndex.ToString());
            o.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
