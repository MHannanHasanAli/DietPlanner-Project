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
    public partial class Warehouses : Form
    {
        int edit = 0;
        public Warehouses()
        {
            InitializeComponent();
        }

        void ShowWarehouse(DataGridView dgv, DataGridViewColumn WareIDGV, DataGridViewColumn WareGV)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from Warehouses order by Warehouse", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                WareIDGV.DataPropertyName = dt.Columns["WareID"].ToString();
                WareGV.DataPropertyName = dt.Columns["Warehouse"].ToString();
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
            txtWarehouse.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
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
                            SqlCommand cmd = new SqlCommand("delete from Warehouses where WareID = @WareID", MainClass.con);
                            cmd.Parameters.AddWithValue("@WareID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Warehouse Deleted Successfully");
                            MainClass.con.Close();
                            ShowWarehouse(dataGridView2, WareIDGV, WareGV);
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
                if (txtWarehouse.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Warehouses (Warehouse) values (@Warehouse)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Warehouse Add Successfully");
                        txtWarehouse.Text = "";
                        MainClass.con.Close();
                        ShowWarehouse(dataGridView2, WareIDGV, WareGV);
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
                    if (txtWarehouse.Text == "")
                    {
                        MessageBox.Show("Field Required");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("update Warehouses set Warehouse = @Warehouse where WareID = @WareID", MainClass.con);
                            cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text);
                            cmd.Parameters.AddWithValue("@WareID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("Warehouse Updated Successfully.");
                            txtWarehouse.Text = "";
                            ShowWarehouse(dataGridView2, WareIDGV, WareGV);
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

        private void Warehouses_Load(object sender, EventArgs e)
        {
            ShowWarehouse(dataGridView2, WareIDGV, WareGV);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
