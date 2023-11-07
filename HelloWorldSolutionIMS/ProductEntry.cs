using System;
using System.Collections;
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
    public partial class ProductEntry : Form
    {
        int edit = 0;
        SqlDataReader dr;
        public ProductEntry()
        {
            InitializeComponent();
        }

        private void CheckNils()
        {
            foreach (DataGridViewRow item in datagridview2.Rows)
            {
                if (item.Cells[6].Value.ToString() == "-----Select-----" || item.Cells["ODefaultUnitGV"].Value.ToString() == "")
                {
                    item.Cells[6].Value = DBNull.Value;
                    item.Cells[7].Value = DBNull.Value;
                    item.Cells[8].Value = DBNull.Value;
                    item.Cells["ODefaultSaleGV"].Value = DBNull.Value;

                }
                if (item.Cells[10].Value.ToString() == "-----Select-----" || item.Cells["OSubUnitGV"].Value.ToString() == "")
                {
                    item.Cells[10].Value = DBNull.Value;
                    item.Cells[11].Value = DBNull.Value;
                    item.Cells[12].Value = DBNull.Value;
                    item.Cells[13].Value = DBNull.Value;
                    item.Cells["OSubCostGV"].Value = DBNull.Value;
                }
            }
        }

        private void ShowWithoutOtherData(DataGridView dgv, DataGridViewColumn PCODEGV, DataGridViewColumn ProductNameGV, DataGridViewColumn CategoryGV, DataGridViewColumn UnitGV, DataGridViewColumn BaseCPGV, DataGridViewColumn BaseSPGV)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select p.Pcode,c.Category,p.ProductName,p.BaseU,p.BaseCP,p.BaseSP from Products as p inner join Categories c on c.CategoryID = p.CatID 	", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                PCODEGV.DataPropertyName = dt.Columns["Pcode"].ToString();
                ProductNameGV.DataPropertyName = dt.Columns["ProductName"].ToString();
                CategoryGV.DataPropertyName = dt.Columns["Category"].ToString();
                UnitGV.DataPropertyName = dt.Columns["BaseU"].ToString();
                BaseCPGV.DataPropertyName = dt.Columns["BaseCP"].ToString();
                BaseSPGV.DataPropertyName = dt.Columns["BaseSP"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void ProductEntry_Load(object sender, EventArgs e)
        {
            ShowWithoutOtherData(dataGridView1, PcodeGV, ProductNameGV, CategoryGV, UnitGV, CostPriceGV, SalePriceGV);
            NotTextChanged();
            MainClass.FillCategories(cboCategory);
            MainClass.FillUnits(cboBaseUnit);
            MainClass.FillUnits(cboDefaultUnit);
            MainClass.FillUnits(cboSubUnit);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            MainClass.FillCategories(cboCategory);
        }

        private void btnaddcat_Click(object sender, EventArgs e)
        {
            Categories cs = new Categories();
            cs.ShowDialog();
        }


        private void Clear()
        {
            txtProductName.Text = "";
            cboCategory.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            if (edit == 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (txtProductName.Text == row.Cells[1].Value.ToString())
                    {
                        MessageBox.Show("Current Product Already Exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (txtProductName.Text == "" || cboCategory.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Input Details");
                }

                else
                {
                    string catId = "";
                    MainClass.con.Open();
                    cmd = new SqlCommand("select CategoryID from Categories where Category like '" + cboCategory.Text + "'", MainClass.con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            catId = dr[0].ToString();
                        }
                    }
                    dr.Close();
                    MainClass.con.Close();


                    MainClass.con.Open();
                    cmd = new SqlCommand("insert into Products (ProductName,CatID,BaseUnit,BaseU,BaseCP,BaseQty,BaseSP,DefaultUnit,DefaultU,DefaultCP,DefaultSP,DefaultQty,SubUnit,SubU,SubCP,SubSP,SubQty) values (@ProductName,@CatID,@BaseUnit,@BaseU,@BaseCP,@BaseQty,@BaseSP,@DefaultUnit,@DefaultU,@DefaultCP,@DefaultSP,@DefaultQty,@SubUnit,@SubU,@SubCP,@SubSP,@SubQty)", MainClass.con);
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@CatID", catId);
                    cmd.Parameters.AddWithValue("@BaseUnit", cboBaseUnit.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BaseU", cboBaseUnit.Text);
                    cmd.Parameters.AddWithValue("@BaseCP", txtbaseCost.Text);
                    cmd.Parameters.AddWithValue("@BaseSP", txtBaseSale.Text);
                    cmd.Parameters.AddWithValue("@BaseQty", txtBaseQty.Text);
                    cmd.Parameters.AddWithValue("@DefaultUnit", cboDefaultUnit.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DefaultU", cboDefaultUnit.Text);
                    cmd.Parameters.AddWithValue("@DefaultCP", txtDefaultCost.Text);
                    cmd.Parameters.AddWithValue("@DefaultSP", txtDefaultSale.Text);
                    cmd.Parameters.AddWithValue("@DefaultQty", txtDefaultQty.Text);
                    cmd.Parameters.AddWithValue("@SubUnit", cboSubUnit.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SubU", cboSubUnit.Text);
                    cmd.Parameters.AddWithValue("@SubCP", txtSubCost.Text);
                    cmd.Parameters.AddWithValue("@SubSP", txtSubSale.Text);
                    cmd.Parameters.AddWithValue("@SubQty", txtSubQty.Text);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                    MessageBox.Show("Product Added Successfully");
                    Clear();
                    cbOtherData.Checked = false;
                    ShowWithoutOtherData(dataGridView1, PcodeGV, ProductNameGV, CategoryGV, UnitGV, CostPriceGV, SalePriceGV);
                }
            }
            else
            {
                if (edit == 1)
                {
                    if (txtProductName.Text == "" || cboCategory.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                        try
                        {
                            string catId = "";
                            MainClass.con.Open();
                            cmd = new SqlCommand("select CategoryID from Categories where Category like '" + cboCategory.Text + "'", MainClass.con);
                            dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    catId = dr[0].ToString();
                                }
                            }
                            dr.Close();
                            MainClass.con.Close();



                            MainClass.con.Open();
                            cmd = new SqlCommand("update Products set ProductName = @ProductName,CatID = @CatID,BaseUnit = @BaseUnit,BaseU = @BaseU,BaseCP = @BaseCP,BaseQty= @BaseQty,BaseSP=@BaseSP,DefaultUnit=@DefaultUnit,DefaultU = @DefaultU," +
                                "DefaultCP=@DefaultCP,DefaultSP = @DefaultSP,DefaultQty=@DefaultQty,SubUnit=@SubUnit,SubU=@SubU,SubCP=@SubCP,SubSP=@SubSP, SubQty = @SubQty  where Pcode = @Pcode ", MainClass.con);
                            cmd.Parameters.AddWithValue("@Pcode", lblID.Text);
                            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                            cmd.Parameters.AddWithValue("@CatID", catId);
                            cmd.Parameters.AddWithValue("@BaseUnit", cboBaseUnit.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@BaseU", cboBaseUnit.Text);
                            cmd.Parameters.AddWithValue("@BaseCP", txtbaseCost.Text);
                            cmd.Parameters.AddWithValue("@BaseSP", txtBaseSale.Text);
                            cmd.Parameters.AddWithValue("@BaseQty", txtBaseQty.Text);
                            cmd.Parameters.AddWithValue("@DefaultUnit", cboDefaultUnit.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@DefaultU", cboDefaultUnit.Text);
                            cmd.Parameters.AddWithValue("@DefaultCP", txtDefaultCost.Text);
                            cmd.Parameters.AddWithValue("@DefaultSP", txtDefaultSale.Text);
                            cmd.Parameters.AddWithValue("@DefaultQty", txtDefaultQty.Text);
                            cmd.Parameters.AddWithValue("@SubUnit", cboSubUnit.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@SubU", cboSubUnit.Text);
                            cmd.Parameters.AddWithValue("@SubCP", txtSubCost.Text);
                            cmd.Parameters.AddWithValue("@SubSP", txtSubSale.Text);
                            cmd.Parameters.AddWithValue("@SubQty", txtSubQty.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Item Updated");
                            MainClass.con.Close();
                            if (cbOtherData.Checked == true)
                            {
                                ShowProducts(datagridview2, OPcodeGV, OProductNameGV, OCatGV, OBaseUnitGV, OBaseCostGV, OBaseSaleGV, ODefaultUnitGV, ODefaultCostGV, ODefaultSaleGV, OSubCostGV, ODefaultQtyGV, OSubSaleGV, OSubUnitGV, OSubQtyDGV);
                            }
                            else
                            {
                                ShowWithoutOtherData(dataGridView1, PcodeGV, ProductNameGV, CategoryGV, UnitGV, CostPriceGV, SalePriceGV);
                            }
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


        void ShowProducts(DataGridView dgv, DataGridViewColumn Pcode, DataGridViewColumn ProductName, DataGridViewColumn CategoryGv,
           DataGridViewColumn BaseU, DataGridViewColumn BaseCost,
           DataGridViewColumn BaseSale, DataGridViewColumn DefaultU,
           DataGridViewColumn DefaultCost, DataGridViewColumn DefaultSale, DataGridViewColumn SubCost, DataGridViewColumn DefaultQty,
           DataGridViewColumn SubSale, DataGridViewColumn SubU, DataGridViewColumn SubQty)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select Pcode,ProductName,c.Category,BaseU,BaseCP,BaseSP,DefaultU,DefaultCP,DefaultQty,DefaultSP,SubU,SubCP,SubSP,SubQty from Products p inner join Categories c on c.CategoryID = p.CatID ", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Pcode.DataPropertyName = dt.Columns["Pcode"].ToString();
                ProductName.DataPropertyName = dt.Columns["ProductName"].ToString();
                CategoryGv.DataPropertyName = dt.Columns["Category"].ToString();
                BaseU.DataPropertyName = dt.Columns["BaseU"].ToString();
                BaseCost.DataPropertyName = dt.Columns["BaseCP"].ToString();
                BaseSale.DataPropertyName = dt.Columns["BaseSP"].ToString();
                DefaultU.DataPropertyName = dt.Columns["DefaultU"].ToString();
                DefaultQty.DataPropertyName = dt.Columns["DefaultQty"].ToString();
                DefaultCost.DataPropertyName = dt.Columns["DefaultCP"].ToString();
                DefaultSale.DataPropertyName = dt.Columns["DefaultSP"].ToString();
                SubU.DataPropertyName = dt.Columns["SubU"].ToString();
                SubCost.DataPropertyName = dt.Columns["SubCP"].ToString();
                SubSale.DataPropertyName = dt.Columns["SubSP"].ToString();
                SubQty.DataPropertyName = dt.Columns["SubQty"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
                CheckNils();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
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
                            SqlCommand cmd = new SqlCommand("delete from Products where Pcode = @Pcode", MainClass.con);
                            cmd.Parameters.AddWithValue("@Pcode", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Products Deleted Successfully");
                            MainClass.con.Close();
                            ShowWithoutOtherData(dataGridView1, PcodeGV, ProductNameGV, CategoryGV, UnitGV, CostPriceGV, SalePriceGV);
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
            if (cbOtherData.Checked == true)
            {
                lblID.Text = datagridview2.CurrentRow.Cells[0].Value.ToString();
                txtProductName.Text = datagridview2.CurrentRow.Cells[1].Value.ToString();
                cboCategory.Text = datagridview2.CurrentRow.Cells[2].Value.ToString();
                cboBaseUnit.Text = datagridview2.CurrentRow.Cells[3].Value.ToString();
                txtbaseCost.Text = datagridview2.CurrentRow.Cells[4].Value.ToString();
                txtBaseSale.Text = datagridview2.CurrentRow.Cells[5].Value.ToString();
                cboDefaultUnit.Text = datagridview2.CurrentRow.Cells[6].Value.ToString();
                txtDefaultCost.Text = datagridview2.CurrentRow.Cells[7].Value.ToString();
                txtDefaultQty.Text = datagridview2.CurrentRow.Cells[8].Value.ToString();
                txtDefaultSale.Text = datagridview2.CurrentRow.Cells[9].Value.ToString();
                cboSubUnit.Text = datagridview2.CurrentRow.Cells[10].Value.ToString();
                txtSubCost.Text = datagridview2.CurrentRow.Cells[11].Value.ToString();
                txtSubSale.Text = datagridview2.CurrentRow.Cells[12].Value.ToString();
                txtSubQty.Text = datagridview2.CurrentRow.Cells[13].Value.ToString();
            }
            else
            {
                lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cboCategory.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtProductName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cboBaseUnit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtbaseCost.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtBaseSale.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text != "" || cboCategory.SelectedIndex != 0)
            {
                Clear();
            }
            else
            {
                Dashboard ds = new Dashboard();
                MainClass.showWindow(ds, this, MDI.ActiveForm);
            }
        }


        private void dataGridView1_DataError_2(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void dTextChanged()
        {

            lblBaseUnit.Text = "Base Unit";
            lblbaseqty.Visible = true;
            txtBaseQty.Visible = true;
            lblBaseSale.Text = "Base Sale";
            lblBaseCost.Text = "Base Cost";
            GBDATA.Visible = true;
        }

        private void NotTextChanged()
        {
            lblBaseUnit.Text = "Unit";
            lblbaseqty.Visible = false;
            txtBaseQty.Visible = false;
            lblBaseCost.Text = "Cost Price";
            lblBaseSale.Text = "Sale Price";
            GBDATA.Visible = false;
        }
        private void cbOtherData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOtherData.Checked == true)
            {
                dTextChanged();
                datagridview2.Visible = true;
                dataGridView1.Visible = false;
                ShowProducts(datagridview2, OPcodeGV, OProductNameGV, OCatGV, OBaseUnitGV, OBaseCostGV, OBaseSaleGV, ODefaultUnitGV, ODefaultCostGV, ODefaultSaleGV, OSubCostGV, ODefaultQtyGV, OSubSaleGV, OSubUnitGV, OSubQtyDGV);

            }
            else
            {
                NotTextChanged();
                dataGridView1.Visible = true;
                datagridview2.Visible = false;
                ShowWithoutOtherData(dataGridView1, PcodeGV, ProductNameGV, CategoryGV, UnitGV, CostPriceGV, SalePriceGV);
            }

        }
    }
}
