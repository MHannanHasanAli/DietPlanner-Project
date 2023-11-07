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
    public partial class SearchProducts : Form
    {
        PurchaseInvoice purchase;
        SaleInvoice sale;
        public SearchProducts(PurchaseInvoice Invoice)
        {
            InitializeComponent();
            this.purchase = Invoice;
            MainClass.ShowProducts(dataGridView1, PcodeGV, ProductNameGV, txtSearch.Text);
        }

        public SearchProducts(SaleInvoice inv)
        {
            InitializeComponent();
            this.sale = inv;
            MainClass.ShowProducts(dataGridView1, PcodeGV, ProductNameGV, txtSearch.Text);
        }


        private void SearchSupplier_Load(object sender, EventArgs e)
        {
            MainClass.ShowProducts(dataGridView1, PcodeGV, ProductNameGV, txtSearch.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1 != null)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        if (purchase != null)
                        {
                            purchase.cboProductName.SelectedValue = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                            purchase.cboProductName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                            this.Close();
                        }
                        else
                        {
                        //    sale.cboProductName.SelectedValue = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                         //   sale.cboProductName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Atleast One Record");
                    }
                }
                else
                {
                    MessageBox.Show("List is Empty");
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1 != null)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        if (dataGridView1.SelectedRows.Count == 1)
                        {
                            if (purchase != null)
                            {
                                purchase.cboProductName.SelectedValue = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                                purchase.cboProductName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                                this.Close();
                            }
                            else
                            {
                        //        sale.cboProductName.SelectedValue = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                          //      sale.cboProductName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Atleast One Record");
                        }
                    }
                    else
                    {
                        MessageBox.Show("List is Empty");
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MainClass.ShowProducts(dataGridView1, PcodeGV, ProductNameGV, txtSearch.Text);
        }
    }
}
