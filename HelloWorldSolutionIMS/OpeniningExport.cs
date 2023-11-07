using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class OpeniningExport : Form
    {
        int view = 0;
        public OpeniningExport()
        {
            InitializeComponent();
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
        private void ShowBills(DataGridView dgv,DataGridViewColumn voucherDate, DataGridViewColumn PersonName, DataGridViewColumn BillBookNo, DataGridViewColumn BillNo, DataGridViewColumn DueAmount, DataGridViewColumn PaidAmount, DataGridViewColumn Address)
        {
            SqlCommand cmd = null;
            MainClass.con.Open();
            try
            {

                if (view == 1)
                {
                    cmd = new SqlCommand("select format(op.VoucherDate,'dd/MM/yyyy') as 'Date',p.PersonName,op.BillNo,op.BillBookNo,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where op.PesonType_ID = '" + cboTypeFilter.SelectedValue + "' and op.PersonName_ID = '" + cbonameFilter.SelectedValue + "' order by VoucherID", MainClass.con);
                }                                                                                          
                else if (view == 2)                                                                       
                {                                                                                         
                    cmd = new SqlCommand("select format(op.VoucherDate,'dd/MM/yyyy') as 'Date',p.PersonName,op.BillNo,op.BillBookNo,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where DueAmount = '0' order by VoucherID", MainClass.con);
                }                                                                                         
                else if (view == 3)                                                                       
                {                                                                                        
                    cmd = new SqlCommand("select format(op.VoucherDate,'dd/MM/yyyy') as 'Date',p.PersonName,op.BillNo,op.BillBookNo,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where DueAmount != '0' order by VoucherID", MainClass.con);
                }                                                                                          
                                                                                                           
                else if (view == 4)                                                                        
                {                                                                                          
                    cmd = new SqlCommand("select format(op.VoucherDate,'dd/MM/yyyy') as 'Date',p.PersonName,op.BillNo,op.BillBookNo,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where op.BillBookNo = '" + txtBillBookFilter.Text + "' and op.PersonName_ID = '" + cbonameFilter.SelectedValue + "'  order by VoucherID", MainClass.con);
                    view = 0;                                                                              
                }                                                                                          
                else if (view == 5)                                                                        
                {                                                                                          
                    cmd = new SqlCommand("select format(op.VoucherDate,'dd/MM/yyyy') as 'Date',p.PersonName,op.BillNo,op.BillBookNo,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID where op.BillBookNo = '" + txtBillBookFilter.Text + "'  and op.BillNo = '" + txtBillNoFilter.Text + "' and op.PersonName_ID = '" + cbonameFilter.SelectedValue + "'  order by VoucherID", MainClass.con);
                    view = 0;                                                                              
                }                                                                                          
                else if (view == 10)                                                                       
                {                                                                                          
                    cmd = new SqlCommand("select format(op.VoucherDate,'dd/MM/yyyy') as 'Date',p.PersonName,op.BillNo,op.BillBookNo,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID order by VoucherID", MainClass.con);
                    view = 0;                                                                              
                }                                                                                          
                else                                                                                       
                {                                                                                          
                    cmd = new SqlCommand("select format(op.VoucherDate,'dd/MM/yyyy') as 'Date',p.PersonName,op.BillNo,op.BillBookNo,op.DueAmount,op.PaidAmount,op.Address from OpeningAccounts op inner join PersonTypes pt on pt.PersonTypeID = op.PesonType_ID inner join Persons p on p.PersonID = op.PersonName_ID order by VoucherID", MainClass.con);
                }



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                voucherDate.DataPropertyName = dt.Columns["Date"].ToString();
                PersonName.DataPropertyName = dt.Columns["PersonName"].ToString();
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
        private void ClearGB1()
        {
            view = 10;
            if (txtBillNoFilter.Text != "" || txtBillBookFilter.Text != "")
            {
                txtBillNoFilter.Text = "";
                txtBillBookFilter.Text = "";
            }
            if (cboTypeFilter.SelectedIndex != 0 || cbonameFilter.SelectedIndex != 0)
            {
                cboTypeFilter.SelectedIndex = 0;
                //    cbonameFilter.SelectedIndex = 0;
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbonameFilter.SelectedIndex == -1 && cboTypeFilter.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Person");
            }
            else if (cbonameFilter.SelectedIndex == 0)
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
                ShowBills(DGVBills, VoucherDateGV, PersonNameGV, BillBookNoGV, BillNoGV, DueAmountGV, PaidAmountGV, AddressGV);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearGB1();
            ShowBills(DGVBills, VoucherDateGV, PersonNameGV, BillBookNoGV, BillNoGV, DueAmountGV, PaidAmountGV, AddressGV);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            view = 2;
            ShowBills(DGVBills, VoucherDateGV, PersonNameGV, BillBookNoGV, BillNoGV, DueAmountGV, PaidAmountGV, AddressGV);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view = 3;
            ShowBills(DGVBills, VoucherDateGV, PersonNameGV, BillBookNoGV, BillNoGV, DueAmountGV, PaidAmountGV, AddressGV);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "Output.pdf";
            bool fileError = false;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                if (!fileError)
                {
                    try
                    {
                        PdfPTable pdfTable = new PdfPTable(DGVBills.Columns.Count);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;


                        foreach (DataGridViewColumn column in DGVBills.Columns)
                        {
                            if (column.Visible != false)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }
                        }

                        foreach (DataGridViewRow row in DGVBills.Rows)
                        {

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(cell.Value.ToString());
                            }

                        }

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("Data Exported Successfully !!!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }

        private void OpeniningExport_Load(object sender, EventArgs e)
        {
            MainClass.FillPersonTypes(cboTypeFilter);
        }

        private void cboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPersonWRTTYpeFilter(cbonameFilter);

        }
    }
}
