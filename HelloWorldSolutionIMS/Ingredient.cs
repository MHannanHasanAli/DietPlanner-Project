using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class Ingredient : Form
    {
        public Ingredient()
        {
            InitializeComponent();
            carbohydrates.TextChanged += UpdateChart;
            fats.TextChanged += UpdateChart;
            protein.TextChanged += UpdateChart;
            //fibers.TextChanged += UpdateChart;
        }
        static int titlecheck = 0;

        private void UpdateChart(object sender, EventArgs e)
        {
            // Create a sample DataTable with data (replace this with your data source).
            DataTable dt = new DataTable();
            dt.Columns.Add("Nutrient", typeof(string));
            dt.Columns.Add("Value", typeof(double));

            //if (calories.Text != "")
            //{
            //    dt.Rows.Add("Calories", double.Parse(calories.Text));

            //}
            if (fats.Text != "")
            {
                dt.Rows.Add("Fats", double.Parse(fats.Text)*9);

            }
            if (protein.Text != "")
            {
                dt.Rows.Add("Protein", double.Parse(protein.Text)*4);

            }
            if (carbohydrates.Text != "")
            {
                dt.Rows.Add("Carbohydrates", double.Parse(carbohydrates.Text)*4);
            }

            if (titlecheck != 1)
            {
                chart1.Titles.Add("Nutrient Chart");
                titlecheck = 1;
            }

            // Ensure the legend is enabled and docked at the left
            chart1.Size = new Size(220, 220);

            //chart1.Legends[0].Enabled = true;
            //chart1.Legends[0].Alignment = StringAlignment.Near;
            //chart1.Legends[0].Docking = Docking.Bottom;
            //chart1.Legends[0].IsTextAutoFit = false;
            //chart1.Legends[0].MaximumAutoSize = 15;
            //chart1.Legends[0].TextWrapThreshold = 2;
            // Your existing code for chart settings
            chart1.Series.Clear();
            chart1.Palette = ChartColorPalette.Pastel;

            Series series = new Series("Series1");
            series.Points.DataBind(dt.AsEnumerable(), "Nutrient", "Value", "");

            series.ChartType = SeriesChartType.Pie;
            chart1.Series.Add(series);
            chart1.Series[0].Label = "#PERCENT{P0}";
            chart1.Series[0].LegendText = "#VALX";

            // Refresh the chart.
            chart1.Refresh();


        }
        static string ingredientIDToEdit;
        static int edit = 0;
        private void ShowIngredients(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn fdc, DataGridViewColumn classification, DataGridViewColumn ingredientAr, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID, fdc_id, CLASSIFICATION, INGREDIENT_AR, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, PROTEIN FROM Ingredient", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_AR"].ToString();
                calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                fats.DataPropertyName = dt.Columns["FATS"].ToString();
                carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();
                fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchIngredients(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn fdc, DataGridViewColumn classification, DataGridViewColumn ingredientAr, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {
            string ingredientName = ingredientar.Text;
            string groupArName = groupar.Text;

            if (ingredientName != "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                        "WHERE (INGREDIENT_AR LIKE @IngredientName) AND (GROUP_AR LIKE @GroupArName)", MainClass.con);

                    cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");
                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_AR"].ToString();
                    calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                    fats.DataPropertyName = dt.Columns["FATS"].ToString();
                    carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                    fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                    calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                    sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                    classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                    fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();



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

                    SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                        "WHERE GROUP_AR LIKE @GroupArName", MainClass.con);

                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_AR"].ToString();
                    calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                    fats.DataPropertyName = dt.Columns["FATS"].ToString();
                    carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                    fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                    calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                    sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                    classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                    fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();



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

                    SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                        "WHERE INGREDIENT_AR LIKE @IngredientName", MainClass.con);

                    cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_AR"].ToString();
                    calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                    fats.DataPropertyName = dt.Columns["FATS"].ToString();
                    carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                    fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                    calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                    sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                    classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                    fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();


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
                ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);
                MessageBox.Show("Fill Ingredient Ar or Group Ar");
            }
        }
        private void Ingredient_Load(object sender, EventArgs e)
        {
            ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);

            chart1.Series.Clear();
        }
        private void New_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (ingredientar.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Ingredient (INGREDIENT_AR, INGREDIENT_EN, GROUP_AR, GROUP_EN, CLASSIFICATION, CALORIES, FATS, FIBERS, POTASSIUM, WATER, SUGAR, CALCIUM, A, PROTEIN, CARBOHYDRATES, SODIUM, PHOSPHOR, MAGNESIUM, IRON, IODINE, B) " +
                            "VALUES (@INGREDIENT_AR, @INGREDIENT_EN, @GROUP_AR, @GROUP_EN, @CLASSIFICATION, @CALORIES, @FATS, @FIBERS, @POTASSIUM, @WATER, @SUGAR, @CALCIUM, @A, @PROTEIN, @CARBOHYDRATES, @SODIUM, @PHOSPHOR, @MAGNESIUM, @IRON, @IODINE, @B)", MainClass.con);

                        cmd.Parameters.AddWithValue("@INGREDIENT_AR", ingredientar.Text); // Replace with the actual input control for INGREDIENT_AR.
                        cmd.Parameters.AddWithValue("@INGREDIENT_EN", ingredienten.Text); // Replace with the actual input control for INGREDIENT_EN.
                        cmd.Parameters.AddWithValue("@GROUP_AR", groupar.Text); // Replace with the actual input control for GROUP_AR.
                        cmd.Parameters.AddWithValue("@GROUP_EN", groupen.Text); // Replace with the actual input control for GROUP_EN.
                        cmd.Parameters.AddWithValue("@CLASSIFICATION", classification.Text); // Replace with the actual input control for CLASSIFICATION.
                        cmd.Parameters.AddWithValue("@CALORIES", Convert.ToDouble(calories.Text)); // Replace with the actual input control for CALORIES.
                        cmd.Parameters.AddWithValue("@FATS", Convert.ToDouble(fats.Text)); // Replace with the actual input control for FATS.
                        cmd.Parameters.AddWithValue("@FIBERS", Convert.ToDouble(fibers.Text)); // Replace with the actual input control for FIBERS.
                        cmd.Parameters.AddWithValue("@POTASSIUM", Convert.ToDouble(potassium.Text)); // Replace with the actual input control for POTASIUM.
                        cmd.Parameters.AddWithValue("@WATER", Convert.ToDouble(water.Text)); // Replace with the actual input control for WATER.
                        cmd.Parameters.AddWithValue("@SUGAR", Convert.ToDouble(sugar.Text)); // Replace with the actual input control for SUGER.
                        cmd.Parameters.AddWithValue("@CALCIUM", Convert.ToDouble(calcium.Text)); // Replace with the actual input control for CALCIUM.
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text)); // Replace with the actual input control for A.
                        cmd.Parameters.AddWithValue("@PROTEIN", Convert.ToDouble(protein.Text)); // Replace with the actual input control for Protein.
                        cmd.Parameters.AddWithValue("@CARBOHYDRATES", Convert.ToDouble(carbohydrates.Text)); // Replace with the actual input control for CARBOHYDRATES.
                        cmd.Parameters.AddWithValue("@SODIUM", Convert.ToDouble(sodium.Text)); // Replace with the actual input control for SODIUM.
                        cmd.Parameters.AddWithValue("@PHOSPHOR", Convert.ToDouble(phosphor.Text)); // Replace with the actual input control for PHOSPHOR.
                        cmd.Parameters.AddWithValue("@MAGNESIUM", Convert.ToDouble(magnesium.Text)); // Replace with the actual input control for MAGNESIUM.
                        cmd.Parameters.AddWithValue("@IRON", Convert.ToDouble(iron.Text)); // Replace with the actual input control for IRON.
                        cmd.Parameters.AddWithValue("@IODINE", Convert.ToDouble(iodine.Text)); // Replace with the actual input control for IODINE.
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text)); // Replace with the actual input control for B.

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ingredient added successfully");

                        // Clear the input controls or set them to default values.
                        ingredientar.Text = "";
                        ingredienten.Text = "";
                        groupar.Text = "";
                        groupen.Text = "";
                        classification.SelectedItem = null;
                        calories.Text = "";
                        fats.Text = "";
                        fibers.Text = "";
                        potassium.Text = "";
                        water.Text = "";
                        sugar.Text = "";
                        calcium.Text = "";
                        abox.Text = "";
                        protein.Text = "";
                        carbohydrates.Text = "";
                        sodium.Text = "";
                        phosphor.Text = "";
                        magnesium.Text = "";
                        iron.Text = "";
                        iodine.Text = "";
                        bbox.Text = "";

                        MainClass.con.Close();

                        ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);

                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ingredient AR name cannot be empty.");
                }
            }
            else
            {
                if (ingredientar.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Ingredient SET INGREDIENT_AR = @INGREDIENT_AR, INGREDIENT_EN = @INGREDIENT_EN, GROUP_AR = @GROUP_AR, GROUP_EN = @GROUP_EN, CLASSIFICATION = @CLASSIFICATION, CALORIES = @CALORIES, FATS = @FATS, FIBERS = @FIBERS, POTASSIUM = @POTASSIUM, WATER = @WATER, SUGAR = @SUGAR, CALCIUM = @CALCIUM, A = @A, PROTEIN = @PROTEIN, CARBOHYDRATES = @CARBOHYDRATES, SODIUM = @SODIUM, PHOSPHOR = @PHOSPHOR, MAGNESIUM = @MAGNESIUM, IRON = @IRON, IODINE = @IODINE, B = @B WHERE ID = @ID", MainClass.con);

                        cmd.Parameters.AddWithValue("@ID", ingredientIDToEdit); // Replace with the actual input control for ID.
                        cmd.Parameters.AddWithValue("@INGREDIENT_AR", ingredientar.Text); // Replace with the actual input control for INGREDIENT_AR.
                        cmd.Parameters.AddWithValue("@INGREDIENT_EN", ingredienten.Text); // Replace with the actual input control for INGREDIENT_EN.
                        cmd.Parameters.AddWithValue("@GROUP_AR", groupar.Text); // Replace with the actual input control for GROUP_AR.
                        cmd.Parameters.AddWithValue("@GROUP_EN", groupen.Text); // Replace with the actual input control for GROUP_EN.
                        cmd.Parameters.AddWithValue("@CLASSIFICATION", classification.Text); // Replace with the actual input control for CLASSIFICATION.
                        cmd.Parameters.AddWithValue("@CALORIES", Convert.ToDouble(calories.Text)); // Replace with the actual input control for CALORIES.
                        cmd.Parameters.AddWithValue("@FATS", Convert.ToDouble(fats.Text)); // Replace with the actual input control for FATS.
                        cmd.Parameters.AddWithValue("@FIBERS", Convert.ToDouble(fibers.Text)); // Replace with the actual input control for FIBERS.
                        cmd.Parameters.AddWithValue("@POTASSIUM", Convert.ToDouble(potassium.Text)); // Replace with the actual input control for POTASIUM.
                        cmd.Parameters.AddWithValue("@WATER", Convert.ToDouble(water.Text)); // Replace with the actual input control for WATER.
                        cmd.Parameters.AddWithValue("@SUGAR", Convert.ToDouble(sugar.Text)); // Replace with the actual input control for SUGER.
                        cmd.Parameters.AddWithValue("@CALCIUM", Convert.ToDouble(calcium.Text)); // Replace with the actual input control for CALCIUM.
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text)); // Replace with the actual input control for A.
                        cmd.Parameters.AddWithValue("@PROTEIN", Convert.ToDouble(protein.Text)); // Replace with the actual input control for Protein.
                        cmd.Parameters.AddWithValue("@CARBOHYDRATES", Convert.ToDouble(carbohydrates.Text)); // Replace with the actual input control for CARBOHYDRATES.
                        cmd.Parameters.AddWithValue("@SODIUM", Convert.ToDouble(sodium.Text)); // Replace with the actual input control for SODIUM.
                        cmd.Parameters.AddWithValue("@PHOSPHOR", Convert.ToDouble(phosphor.Text)); // Replace with the actual input control for PHOSPHOR.
                        cmd.Parameters.AddWithValue("@MAGNESIUM", Convert.ToDouble(magnesium.Text)); // Replace with the actual input control for MAGNESIUM.
                        cmd.Parameters.AddWithValue("@IRON", Convert.ToDouble(iron.Text)); // Replace with the actual input control for IRON.
                        cmd.Parameters.AddWithValue("@IODINE", Convert.ToDouble(iodine.Text)); // Replace with the actual input control for IODINE.
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text)); // Replace with the actual input control for B.

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ingredient updated successfully");

                        // Clear the input controls or set them to default values.
                        ingredientar.Text = "";
                        ingredienten.Text = "";
                        groupar.Text = "";
                        groupen.Text = "";
                        classification.SelectedItem = null;
                        calories.Text = "";
                        fats.Text = "";
                        fibers.Text = "";
                        potassium.Text = "";
                        water.Text = "";
                        sugar.Text = "";
                        calcium.Text = "";
                        abox.Text = "";
                        protein.Text = "";
                        carbohydrates.Text = "";
                        sodium.Text = "";
                        phosphor.Text = "";
                        magnesium.Text = "";
                        iron.Text = "";
                        iodine.Text = "";
                        bbox.Text = "";
                        MainClass.con.Close();

                        ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ingredient AR name cannot be empty.");
                }
            }

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            try
            {
                ingredientIDToEdit = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ingredient WHERE ID = @IngredientID", MainClass.con);
                cmd.Parameters.AddWithValue("@IngredientID", ingredientIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        ingredientar.Text = reader["INGREDIENT_AR"].ToString();
                        ingredienten.Text = reader["INGREDIENT_EN"].ToString();
                        groupar.Text = reader["GROUP_AR"].ToString();
                        groupen.Text = reader["GROUP_EN"].ToString();
                        classification.Text = reader["CLASSIFICATION"].ToString();
                        calories.Text = reader["CALORIES"].ToString();
                        fats.Text = reader["FATS"].ToString();
                        fibers.Text = reader["FIBERS"].ToString();
                        potassium.Text = reader["POTASSIUM"].ToString();
                        water.Text = reader["WATER"].ToString();
                        sugar.Text = reader["SUGAR"].ToString();
                        calcium.Text = reader["CALCIUM"].ToString();
                        abox.Text = reader["A"].ToString();
                        protein.Text = reader["PROTEIN"].ToString();
                        carbohydrates.Text = reader["CARBOHYDRATES"].ToString();
                        sodium.Text = reader["SODIUM"].ToString();
                        phosphor.Text = reader["PHOSPHOR"].ToString();
                        magnesium.Text = reader["MAGNESIUM"].ToString();
                        iron.Text = reader["IRON"].ToString();
                        iodine.Text = reader["IODINE"].ToString();
                        bbox.Text = reader["B"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Ingredient not found with No: " + ingredientIDToEdit);
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
                        ingredientar.Text = "";
                        ingredienten.Text = "";
                        groupar.Text = "";
                        groupen.Text = "";
                        classification.Text = "";
                        calories.Text = "";
                        fats.Text = "";
                        fibers.Text = "";
                        potassium.Text = "";
                        water.Text = "";
                        sugar.Text = "";
                        calcium.Text = "";
                        abox.Text = "";
                        protein.Text = "";
                        carbohydrates.Text = "";
                        sodium.Text = "";
                        phosphor.Text = "";
                        magnesium.Text = "";
                        iron.Text = "";
                        iodine.Text = "";
                        bbox.Text = "";
                        // Get the Ingredient ID to display in the confirmation message
                        string ingredientIDToDelete = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Ingredient : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Ingredient WHERE ID = @IngredientID", MainClass.con);
                                cmd.Parameters.AddWithValue("@IngredientID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString()); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Ingredient removed successfully");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
                                ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);
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
        private void Search_Click(object sender, EventArgs e)
        {
            SearchIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void floatlock(object sender, KeyPressEventArgs e)
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

        private void EditBTN_Click(object sender, EventArgs e)
        {
            edit = 1;
            try
            {
                ingredientIDToEdit = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ingredient WHERE ID = @IngredientID", MainClass.con);
                cmd.Parameters.AddWithValue("@IngredientID", ingredientIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        ingredientar.Text = reader["INGREDIENT_AR"].ToString();
                        ingredienten.Text = reader["INGREDIENT_EN"].ToString();
                        groupar.Text = reader["GROUP_AR"].ToString();
                        groupen.Text = reader["GROUP_EN"].ToString();
                        classification.Text = reader["CLASSIFICATION"].ToString();
                        calories.Text = reader["CALORIES"].ToString();
                        fats.Text = reader["FATS"].ToString();
                        fibers.Text = reader["FIBERS"].ToString();
                        potassium.Text = reader["POTASSIUM"].ToString();
                        water.Text = reader["WATER"].ToString();
                        sugar.Text = reader["SUGAR"].ToString();
                        calcium.Text = reader["CALCIUM"].ToString();
                        abox.Text = reader["A"].ToString();
                        protein.Text = reader["PROTEIN"].ToString();
                        carbohydrates.Text = reader["CARBOHYDRATES"].ToString();
                        sodium.Text = reader["SODIUM"].ToString();
                        phosphor.Text = reader["PHOSPHOR"].ToString();
                        magnesium.Text = reader["MAGNESIUM"].ToString();
                        iron.Text = reader["IRON"].ToString();
                        iodine.Text = reader["IODINE"].ToString();
                        bbox.Text = reader["B"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Ingredient not found with No: " + ingredientIDToEdit);
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {
                        ingredientar.Text = "";
                        ingredienten.Text = "";
                        groupar.Text = "";
                        groupen.Text = "";
                        classification.Text = "";
                        calories.Text = "";
                        fats.Text = "";
                        fibers.Text = "";
                        potassium.Text = "";
                        water.Text = "";
                        sugar.Text = "";
                        calcium.Text = "";
                        abox.Text = "";
                        protein.Text = "";
                        carbohydrates.Text = "";
                        sodium.Text = "";
                        phosphor.Text = "";
                        magnesium.Text = "";
                        iron.Text = "";
                        iodine.Text = "";
                        bbox.Text = "";
                        // Get the Ingredient ID to display in the confirmation message
                        string ingredientIDToDelete = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Ingredient : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Ingredient WHERE ID = @IngredientID", MainClass.con);
                                cmd.Parameters.AddWithValue("@IngredientID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString()); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Ingredient removed successfully");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
                                ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);
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
    }
}
