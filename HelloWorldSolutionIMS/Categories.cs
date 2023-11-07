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
    public partial class Categories : Form
    {
        int edit = 0;
        ProductEntry ps = new ProductEntry();
        public Categories()
        {
            InitializeComponent();
        }

        void ShowCategories(DataGridView dgv, DataGridViewColumn CatIDGV, DataGridViewColumn CatGV)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from Categories order by Category", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CatIDGV.DataPropertyName = dt.Columns["CategoryID"].ToString();
                CatGV.DataPropertyName = dt.Columns["Category"].ToString();
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
            txtCategory.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
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
                            SqlCommand cmd = new SqlCommand("delete from Categories where CategoryID = @CategoryID", MainClass.con);
                            cmd.Parameters.AddWithValue("@CategoryID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Category Deleted Successfully");
                            MainClass.con.Close();
                            ShowCategories(dataGridView2, CategoryIDGV, CategoryGV);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (txtCategory.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Categories (Category) values (@Category)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Category Add Successfully");
                        txtCategory.Text = "";
                        MainClass.con.Close();
                        ShowCategories(dataGridView2, CategoryIDGV, CategoryGV);
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
                    if (txtCategory.Text == "")
                    {
                        MessageBox.Show("Field Required");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("update Categories set Category = @Category where CategoryID = @CategoryID", MainClass.con);
                            cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                            cmd.Parameters.AddWithValue("@CategoryID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("Category Updated Successfully.");
                            txtCategory.Text = "";
                            ShowCategories(dataGridView2, CategoryIDGV, CategoryGV);
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

        private void Categories_Load(object sender, EventArgs e)
        {
            ShowCategories(dataGridView2, CategoryIDGV, CategoryGV);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
