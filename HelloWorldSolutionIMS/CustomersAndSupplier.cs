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
    public partial class CustomersAndSupplier : Form
    {
        int edit = 0;
        SqlDataReader dr;
        SqlCommand cmd;
        public CustomersAndSupplier()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Persons p = new Persons();
            p.ShowDialog();
        }

        void Clear()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            cboTypes.SelectedIndex = 0;
        }
        private void CustomersAndSupplier_Load(object sender, EventArgs e)
        {
            MainClass.FillPersonTypes(cboTypes);
            ShowPersons(dataGridView1, PersonIDGV, PersonTypeGV, PersonNameGV, PhoneGV, EmailGV);
            cboTypes.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtName.Text != ""  || txtEmail.Text != "" || txtPhone.Text != "" || cboTypes.SelectedIndex != 0)
            {
                Clear();
            }
            else
            {
                Dashboard ds = new Dashboard();
                MainClass.showWindow(ds, this, MDI.ActiveForm);
            }
        }

        private void ShowPersons(DataGridView dgv, DataGridViewColumn IDGV, DataGridViewColumn TypeGV, DataGridViewColumn NameGV, DataGridViewColumn PhoneGV, DataGridViewColumn EmailGV, string data = null )
        {
            SqlCommand cmd = null;
            try
            {
                MainClass.con.Open();
                if (data != null)
                {
                    cmd = new SqlCommand("select p.PersonID,pt.PersonType, p.PersonName,p.PersonPhone,p.PersonAddress from Persons as p inner join PersonTypes pt on pt.PersonTypeID = p.PersonType where p.PersonName like '%" + data + "%'  order by p.PersonName	", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.PersonID,pt.PersonType, p.PersonName,p.PersonPhone,p.PersonAddress from Persons as p inner join PersonTypes pt on pt.PersonTypeID = p.PersonType order by p.PersonName	", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                IDGV.DataPropertyName = dt.Columns["PersonID"].ToString();
                TypeGV.DataPropertyName = dt.Columns["PersonType"].ToString();
                NameGV.DataPropertyName = dt.Columns["PersonName"].ToString();
                PhoneGV.DataPropertyName = dt.Columns["PersonPhone"].ToString();
                EmailGV.DataPropertyName = dt.Columns["PersonAddress"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if(txtName.Text == row.Cells[2].Value.ToString() && cboTypes.SelectedItem.ToString() == row.Cells[1].Value.ToString())
                    {
                        MessageBox.Show("Current Person Name Already Exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (txtName.Text == "" || cboTypes.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Input Details");
                }
               
           
                else
                {
                    try
                    {

                        string ptype = "";
                        MainClass.con.Open();
                        cmd = new SqlCommand("Select PersonTypeID from PersonTypes where PersonType like '" + cboTypes.Text + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            ptype = dr[0].ToString();
                        }
                        dr.Close();
                        MainClass.con.Close();


                        MainClass.con.Open();
                       cmd = new SqlCommand("insert into Persons (PersonType,PersonName,PersonPhone,PersonAddress) values(@PersonType, @PersonName, @PersonPhone, @PersonAddress)", MainClass.con);
                        cmd.Parameters.AddWithValue("@PersonType", ptype);
                        cmd.Parameters.AddWithValue("@PersonName", txtName.Text);
                        cmd.Parameters.AddWithValue("@PersonPhone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@PersonAddress", txtEmail.Text);
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show(txtName.Text + " Added Successfully as " + cboTypes.Text);
                        ShowPersons(dataGridView1, PersonIDGV, PersonTypeGV, PersonNameGV, PhoneGV, EmailGV);

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
                    if(txtName.Text == "")
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd;
                            string ptype = "";
                            MainClass.con.Open();
                            cmd = new SqlCommand("Select PersonTypeID from PersonTypes where PersonType like '" + cboTypes.Text + "'", MainClass.con);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows)
                            {
                                ptype = dr[0].ToString();
                            }
                            dr.Close();
                            MainClass.con.Close();

                            MainClass.con.Open();
                            cmd = new SqlCommand("update  Persons set PersonType = @PersonType,PersonName = @PersonName,PersonPhone = @PersonPhone,PersonAddress = @PersonAddress where PersonID = @PersonID", MainClass.con);
                            cmd.Parameters.AddWithValue("@PersonID", lbID.Text);
                            cmd.Parameters.AddWithValue("@PersonType", ptype);
                            cmd.Parameters.AddWithValue("@PersonName", txtName.Text);
                            cmd.Parameters.AddWithValue("@PersonPhone", txtPhone.Text);
                            cmd.Parameters.AddWithValue("@PersonAddress", txtEmail.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("User Updated Successfully.");
                            Clear();
                            ShowPersons(dataGridView1, PersonIDGV, PersonTypeGV, PersonNameGV, PhoneGV, EmailGV);
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            lbID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cboTypes.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from Persons where PersonID = @PersonID", MainClass.con);
                            cmd.Parameters.AddWithValue("@PersonID", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Deleted Successfully");
                            MainClass.con.Close();
                            ShowPersons(dataGridView1, PersonIDGV, PersonTypeGV, PersonNameGV, PhoneGV, EmailGV);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowPersons(dataGridView1, PersonIDGV, PersonTypeGV, PersonNameGV, PhoneGV, EmailGV, txtSearch.Text);
        }
    }
}
