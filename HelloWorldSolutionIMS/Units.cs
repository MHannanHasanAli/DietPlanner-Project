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
    public partial class Units : Form
    {
        int edit = 0;
        public Units()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (txtUnit.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Units (UnitName) values (@UnitName)", MainClass.con);
                        cmd.Parameters.AddWithValue("@UnitName", txtUnit.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Unit Add Successfully");
                        txtUnit.Text = "";
                        MainClass.con.Close();
                        ShowUnits(dataGridView2, UnitIDGV, UnitGV);
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
                    if (txtUnit.Text == "")
                    {
                        MessageBox.Show("Field Required");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("update Units set UnitName = @UnitName where UnitID = @UnitID", MainClass.con);
                            cmd.Parameters.AddWithValue("@UnitName", txtUnit.Text);
                            cmd.Parameters.AddWithValue("@UnitID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("Unit Updated Successfully.");
                            txtUnit.Text = "";
                            ShowUnits(dataGridView2, UnitIDGV, UnitGV);
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

        void ShowUnits(DataGridView dgv, DataGridViewColumn UnitIDGV, DataGridViewColumn UnitGV)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from Units order by UnitName", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                UnitIDGV.DataPropertyName = dt.Columns["UnitID"].ToString();
                UnitGV.DataPropertyName = dt.Columns["UnitName"].ToString();
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
            txtUnit.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
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
                            SqlCommand cmd = new SqlCommand("delete from Units where UnitID = @UnitID", MainClass.con);
                            cmd.Parameters.AddWithValue("@UnitID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Category Deleted Successfully");
                            MainClass.con.Close();
                            ShowUnits(dataGridView2, UnitIDGV, UnitGV);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Units_Load(object sender, EventArgs e)
        {
            ShowUnits(dataGridView2, UnitIDGV, UnitGV);
        }
    }
}
