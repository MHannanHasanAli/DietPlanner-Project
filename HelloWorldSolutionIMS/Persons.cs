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
    public partial class Persons : Form
    {
        int edit = 0;
        public Persons()
        {
            InitializeComponent();
        }

        private void Persons_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        void ShowTypes(DataGridView dgv, DataGridViewColumn IDGV, DataGridViewColumn TypeGV)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from PersonTypes order by PersonType", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                PersonIDGV.DataPropertyName = dt.Columns["PersonTypeID"].ToString();
                PersonTypeGV.DataPropertyName = dt.Columns["PersonType"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (txtType.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into PersonTypes (PersonType) values (@PersonType)", MainClass.con);
                        cmd.Parameters.AddWithValue("@PersonType", txtType.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Person Type Add Successfully");
                        txtType.Text = "";
                        MainClass.con.Close();
                        ShowTypes(dataGridView2, PersonIDGV, PersonTypeGV);
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
                if(edit == 1)
                {
                    if (txtType.Text == "")
                    {
                        MessageBox.Show("Field Required");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("update PersonTypes set PersonType = @PersonType where PersonTypeID = @PersonTypeID", MainClass.con);
                            cmd.Parameters.AddWithValue("@PersonType", txtType.Text);
                            cmd.Parameters.AddWithValue("@PersonTypeID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("User Updated Successfully.");
                            txtType.Text = "";
                            ShowTypes(dataGridView2, PersonIDGV, PersonTypeGV);
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

        private void Persons_Load(object sender, EventArgs e)
        {
            ShowTypes(dataGridView2, PersonIDGV, PersonTypeGV);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            lblID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtType.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
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
                            SqlCommand cmd = new SqlCommand("delete from PersonTypes where PersonTypeID = @PersonTypeID", MainClass.con);
                            cmd.Parameters.AddWithValue("@PersonTypeID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Type Deleted Successfully");
                            MainClass.con.Close();
                            ShowTypes(dataGridView2, PersonIDGV, PersonTypeGV);
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

    }
}
