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
    public partial class Expenses : Form
    {
        int edit = 0;
        int date = 0;
        public Expenses()
        {
            InitializeComponent();
        }

        private void ShowExpense(DataGridView dgv , DataGridViewColumn expid, DataGridViewColumn Expense, DataGridViewColumn expenseprice,DataGridViewColumn dates ,string search = "")
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();
                if(date == 1)
                {
                     cmd = new SqlCommand("select * from Expenses  where ExpenseDate between '"+dateTimePicker1.Value.ToShortDateString()+ "' and '" + dateTimePicker2.Value.ToShortDateString() + "' ", MainClass.con);
                }
                else
                {
                     cmd = new SqlCommand("select * from Expenses order by ExpenseName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                expid.DataPropertyName = dt.Columns["ExpenseID"].ToString();
                Expense.DataPropertyName = dt.Columns["ExpenseName"].ToString();
                expenseprice.DataPropertyName = dt.Columns["ExpensePrice"].ToString();
                dates.DataPropertyName = dt.Columns["ExpenseDate"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            lblID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtExpense.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells[3].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (txtExpense.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Expenses (ExpenseName,ExpensePrice,ExpenseDate) values (@ExpenseName,@ExpensePrice,@ExpenseDate)", MainClass.con);
                        cmd.Parameters.AddWithValue("@ExpenseName", txtExpense.Text);
                        cmd.Parameters.AddWithValue("@ExpensePrice", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@ExpenseDate", dateTimePicker1.Value.ToShortDateString());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Expense Add Successfully");
                        txtExpense.Text = "";
                        txtPrice.Text = "";
                        MainClass.con.Close();
                        ShowExpense(dataGridView2, ExpenseIDGV, ExpenseGV,ExpensePriceGV,DateGV);
                        ShowTotal();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                if (edit == 1)
                {
                    if (txtExpense.Text == "" || txtPrice.Text == "")
                    {
                        MessageBox.Show("Field Required");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("update Expenses set ExpenseName = @ExpenseName,ExpensePrice = @ExpensePrice where ExpenseID = @ExpenseID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ExpenseName", txtExpense.Text);
                            cmd.Parameters.AddWithValue("@ExpensePrice", txtPrice.Text);
                            cmd.Parameters.AddWithValue("@ExpenseID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("Expense Updated Successfully.");
                            txtExpense.Text = "";
                            txtPrice.Text = "";

                            ShowExpense(dataGridView2, ExpenseIDGV, ExpenseGV, ExpensePriceGV, DateGV);
                            ShowTotal();
                            edit = 0;
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

        private void Expenses_Load(object sender, EventArgs e)
        {
            ShowExpense(dataGridView2, ExpenseIDGV, ExpenseGV, ExpensePriceGV, DateGV);
            ShowTotal();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowTotal()
        {
            if (dataGridView2.Rows.Count > 0)
            {
                int total = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    total += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
                }
                txttotal.Text = total.ToString();
            }
            else
            {
                txttotal.Text = "0";
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView2 != null)
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    if (dataGridView2.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from Expenses where ExpenseID = @ExpenseID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ExpenseID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Expense Deleted Successfully");
                            MainClass.con.Close();
                            ShowExpense(dataGridView2, ExpenseIDGV, ExpenseGV, ExpensePriceGV, DateGV);
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            ShowTotal();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = 1;
            ShowExpense(dataGridView2, ExpenseIDGV, ExpenseGV, ExpensePriceGV, DateGV);
            ShowTotal();
        }
    }
}
