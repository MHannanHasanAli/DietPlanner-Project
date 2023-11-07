using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32Interop.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace HelloWorldSolutionIMS
{
    public partial class SpecialDeal : Form
    {
        public SpecialDeal()
        {
            InitializeComponent();
        }

        static int edit = 0;
        static string SpecialDealIDToEdit;
        private void ShowSpecialDeals(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn name, DataGridViewColumn code, DataGridViewColumn percentage, DataGridViewColumn start, DataGridViewColumn end, DataGridViewColumn nutritionist, DataGridViewColumn branch)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID, PromotionName, PromotionCode, PromotionPercentage, StartDate, EndDate, NutritionistName, Branch FROM SpecialDeals", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                name.DataPropertyName = dt.Columns["PromotionName"].ToString();
                code.DataPropertyName = dt.Columns["PromotionCode"].ToString();
                percentage.DataPropertyName = dt.Columns["PromotionPercentage"].ToString();
                start.DataPropertyName = dt.Columns["StartDate"].ToString();
                end.DataPropertyName = dt.Columns["EndDate"].ToString();
                nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                branch.DataPropertyName = dt.Columns["Branch"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchSpecialDeals(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn name, DataGridViewColumn code, DataGridViewColumn percentage, DataGridViewColumn start, DataGridViewColumn end, DataGridViewColumn nutritionist, DataGridViewColumn branch)
        {
            string ingredientName = promotionnamesearch.Text;
            string groupArName = promotioncodesearch.Text;

            if (ingredientName != "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, PromotionName, PromotionCode, PromotionPercentage, StartDate, EndDate, NutritionistName, Branch FROM SpecialDeals " +
               "WHERE (PromotionName LIKE @IngredientName) AND (PromotionCode LIKE @GroupArName)", MainClass.con);


                    cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");
                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    name.DataPropertyName = dt.Columns["PromotionName"].ToString();
                    code.DataPropertyName = dt.Columns["PromotionCode"].ToString();
                    percentage.DataPropertyName = dt.Columns["PromotionPercentage"].ToString();
                    start.DataPropertyName = dt.Columns["StartDate"].ToString();
                    end.DataPropertyName = dt.Columns["EndDate"].ToString();
                    nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                    branch.DataPropertyName = dt.Columns["Branch"].ToString();



                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (ingredientName == "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, PromotionName, PromotionCode, PromotionPercentage, StartDate, EndDate, NutritionistName, Branch FROM SpecialDeals " +
                        "WHERE PromotionCode LIKE @GroupArName", MainClass.con);

                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    name.DataPropertyName = dt.Columns["PromotionName"].ToString();
                    code.DataPropertyName = dt.Columns["PromotionCode"].ToString();
                    percentage.DataPropertyName = dt.Columns["PromotionPercentage"].ToString();
                    start.DataPropertyName = dt.Columns["StartDate"].ToString();
                    end.DataPropertyName = dt.Columns["EndDate"].ToString();
                    nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                    branch.DataPropertyName = dt.Columns["Branch"].ToString();




                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (ingredientName != "" && groupArName == "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, PromotionName, PromotionCode, PromotionPercentage, StartDate, EndDate, NutritionistName, Branch FROM SpecialDeals " +
                        "WHERE PromotionName LIKE @IngredientName", MainClass.con);

                    cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    name.DataPropertyName = dt.Columns["PromotionName"].ToString();
                    code.DataPropertyName = dt.Columns["PromotionCode"].ToString();
                    percentage.DataPropertyName = dt.Columns["PromotionPercentage"].ToString();
                    start.DataPropertyName = dt.Columns["StartDate"].ToString();
                    end.DataPropertyName = dt.Columns["EndDate"].ToString();
                    nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                    branch.DataPropertyName = dt.Columns["Branch"].ToString();



                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                ShowSpecialDeals(guna2DataGridView1, iddgv, promotionnamedgv, promotioncodedgv, promotionpercentagedgv, startdatedgv, enddatedgv, nutritionistdgv, branchdgv);
                MessageBox.Show("Fill Promotion Name or Code");
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            promotionname.Text = "";
            promotioncode.Text = "";
            promotionpercentage.Text = "";
            startdate.Text = "";
            enddate.Text = "";
            nutritionist.Text = "";
            branch.Text = "";
            promotiondetails.Text = "";
            edit = 0;
            tabControl1.SelectedIndex = 1;
        }
        private void Backtodeal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (promotionname.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO SpecialDeals (PromotionName, PromotionCode, PromotionPercentage, StartDate, EndDate, NutritionistName, Branch, PromotionDetails) " +
                            "VALUES (@PromotionName, @PromotionCode, @PromotionPercentage, @StartDate, @EndDate, @NutritionistName, @Branch, @PromotionDetails)", MainClass.con);

                        cmd.Parameters.AddWithValue("@PromotionName", promotionname.Text);
                        cmd.Parameters.AddWithValue("@PromotionCode", promotioncode.Text);
                        cmd.Parameters.AddWithValue("@PromotionPercentage", Convert.ToDecimal(promotionpercentage.Text));
                        cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(startdate.Text));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(enddate.Text));
                        cmd.Parameters.AddWithValue("@NutritionistName", nutritionist.Text);
                        cmd.Parameters.AddWithValue("@Branch", branch.Text);
                        cmd.Parameters.AddWithValue("@PromotionDetails", promotiondetails.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Special Deal added successfully");

                        // Clear the input controls or set them to default values.
                        promotionname.Text = "";
                        promotioncode.Text = "";
                        promotionpercentage.Text = "";
                        startdate.Text = "";
                        enddate.Text = "";
                        nutritionist.Text = "";
                        branch.Text = "";
                        promotiondetails.Text = "";

                        MainClass.con.Close();

                        // Refresh the DataGridView to display the updated data.
                        // Replace the arguments with your actual DataGridView and column names.
                        ShowSpecialDeals(guna2DataGridView1, iddgv, promotionnamedgv, promotioncodedgv, promotionpercentagedgv, startdatedgv, enddatedgv, nutritionistdgv, branchdgv);
                        tabControl1.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Promotion Name cannot be empty.");
                }
            }
            else
            {
                if (promotionname.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE SpecialDeals SET PromotionName = @PromotionName, PromotionCode = @PromotionCode, PromotionPercentage = @PromotionPercentage, StartDate = @StartDate, EndDate = @EndDate, NutritionistName = @NutritionistName, Branch = @Branch, PromotionDetails = @PromotionDetails WHERE ID = @ID", MainClass.con);

                        cmd.Parameters.AddWithValue("@ID", SpecialDealIDToEdit);
                        cmd.Parameters.AddWithValue("@PromotionName", promotionname.Text);
                        cmd.Parameters.AddWithValue("@PromotionCode", promotioncode.Text);
                        cmd.Parameters.AddWithValue("@PromotionPercentage", Convert.ToDecimal(promotionpercentage.Text));
                        cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(startdate.Text));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(enddate.Text));
                        cmd.Parameters.AddWithValue("@NutritionistName", nutritionist.Text);
                        cmd.Parameters.AddWithValue("@Branch", branch.Text);
                        cmd.Parameters.AddWithValue("@PromotionDetails", promotiondetails.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Special Deal updated successfully");

                        // Clear the input controls or set them to default values.
                        promotionname.Text = "";
                        promotioncode.Text = "";
                        promotionpercentage.Text = "";
                        startdate.Text = "";
                        enddate.Text = "";
                        nutritionist.Text = "";
                        branch.Text = "";
                        promotiondetails.Text = "";

                        MainClass.con.Close();

                        // Refresh the DataGridView to display the updated data.
                        // Replace the arguments with your actual DataGridView and column names.
                        ShowSpecialDeals(guna2DataGridView1, iddgv, promotionnamedgv, promotioncodedgv, promotionpercentagedgv, startdatedgv, enddatedgv, nutritionistdgv, branchdgv);
                        tabControl1.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Promotion Name cannot be empty.");
                }
            }

        }
        private void SpecialDeal_Load(object sender, EventArgs e)
        {
            MainClass.HideAllTabsOnTabControl(tabControl1);
            ShowSpecialDeals(guna2DataGridView1, iddgv, promotionnamedgv, promotioncodedgv, promotionpercentagedgv, startdatedgv, enddatedgv, nutritionistdgv, branchdgv);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1; // Assuming you want to perform an edit operation
            try
            {
                SpecialDealIDToEdit = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(); // Assuming the ID is in the first cell
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SpecialDeals WHERE ID = @specialDealID", MainClass.con);
                cmd.Parameters.AddWithValue("@specialDealID", SpecialDealIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        promotionname.Text = reader["PromotionName"].ToString();
                        promotioncode.Text = reader["PromotionCode"].ToString();
                        promotionpercentage.Text = reader["PromotionPercentage"].ToString();
                        startdate.Text = reader["StartDate"].ToString();
                        enddate.Text = reader["EndDate"].ToString();
                        nutritionist.Text = reader["NutritionistName"].ToString();
                        branch.Text = reader["Branch"].ToString();
                        promotiondetails.Text = reader["PromotionDetails"].ToString();
                    }
                    tabControl1.SelectedIndex = 1; // Assuming your tab control index for editing is 1
                }
                else
                {
                    MessageBox.Show("Special Deal data not found with ID: " + SpecialDealIDToEdit);
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {
                        // Clear the input controls
                        promotionname.Text = "";
                        promotioncode.Text = "";
                        promotionpercentage.Text = "";
                        startdate.Text = "";
                        enddate.Text = "";
                        nutritionist.Text = "";
                        branch.Text = "";
                        promotiondetails.Text = "";

                        // Get the SpecialDeal ID to display in the confirmation message
                        string specialDealIDToDelete = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(); // Assuming the ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Special Deal with ID: " + specialDealIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM SpecialDeals WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", specialDealIDToDelete); // Assuming the ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Special Deal removed successfully");
                                MainClass.con.Close();

                                // Refresh the DataGridView with the updated data
                                ShowSpecialDeals(guna2DataGridView1, iddgv, promotionnamedgv, promotioncodedgv, promotionpercentagedgv, startdatedgv, enddatedgv, nutritionistdgv, branchdgv);
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

        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void search_Click(object sender, EventArgs e)
        {
            SearchSpecialDeals(guna2DataGridView1, iddgv, promotionnamedgv, promotioncodedgv, promotionpercentagedgv, startdatedgv, enddatedgv, nutritionistdgv, branchdgv);
        }

        private void promotionpercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the keypress if it's not a number, a control character, or a decimal point
            }

            // Allow only one decimal point
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
