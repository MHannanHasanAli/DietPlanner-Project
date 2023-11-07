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
using System.Windows.Forms.DataVisualization.Charting;
using static HelloWorldSolutionIMS.DietPlan;

namespace HelloWorldSolutionIMS
{
    public partial class DietPlanTemplate : Form
    {
        public DietPlanTemplate()
        {
            InitializeComponent();
            carbohydrates.TextChanged += UpdateChart;
            fats.TextChanged += UpdateChart;
            protein.TextChanged += UpdateChart;
            //fibers.TextChanged += UpdateChart;
        }

        static int edit = 0;
        static int titlecheck = 0;
        static int chartfiller = 0;
        static string dietPlanIDToEdit;

        public class MealsDropdown
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        List<MealsDropdown> Mealslist = new List<MealsDropdown>();
        private void intlock(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
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
        private void DietPlanTemplate_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            MainClass.HideAllTabsOnTabControl(tabControl1);
            ShowDietPlanTemplates(guna2DataGridView1, filenodgv, dietnamedgv);
            guna2DataGridView2.EditingControlShowing += guna2DataGridView2_EditingControlShowing;

        }
        private void ShowDietPlanTemplates(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn dietname)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID,DIETPLANTEMPLATENAME  FROM DietPlanTemplate", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                dietname.DataPropertyName = dt.Columns["DIETPLANTEMPLATENAME"].ToString();


                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchDietPlanTemplates(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn dietname)
        {
       
            string dietplan = dietplannamesearch.Text;

            
            if (dietplan != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, DIETPLANTEMPLATENAME FROM DietPlanTemplate " +
                        " WHERE DIETPLANTEMPLATENAME LIKE @dietplan", MainClass.con);

                    cmd.Parameters.AddWithValue("@dietplan", "%" + dietplan + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    dietname.DataPropertyName = dt.Columns["DIETPLANTEMPLATENAME"].ToString();



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
                MessageBox.Show("Fill Diet Plan Template name");
                ShowDietPlanTemplates(guna2DataGridView1, filenodgv, dietnamedgv);

            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            dietplantemplatename.Text = "";
            dietplantemplatebox.Text = "";
            dietplandays.Text = "";
            instruction.Text = "";
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
            edit = 0;
            tabControl1.SelectedIndex = 1;
        }
        private void Meals_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void Ingredienttab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
        private void Backtomeal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private List<string> GetCategory()
        {
            return new List<string>
    {
        "Breakfast",
        "Lunch",
        "Dinner",
        "Snack",
        "Functional Food"
    };
        }
        private List<MealsDropdown> GetMeals()
        {
            try
            {
                if (MainClass.con.State == ConnectionState.Open)
                {
                    Mealslist.Clear();
                    SqlCommand cmd = new SqlCommand("SELECT ID, MealAr FROM Meal", MainClass.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string mealname = reader["MealAr"].ToString();
                        Mealslist.Add(new MealsDropdown { ID = id, Name = mealname });
                    }
                    reader.Close();
                }
                else
                {
                    MainClass.con.Open();
                    Mealslist.Clear();
                    SqlCommand cmd = new SqlCommand("SELECT ID, MealAr FROM Meal", MainClass.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string mealname = reader["MealAr"].ToString();
                        Mealslist.Add(new MealsDropdown { ID = id, Name = mealname });
                    }
                    reader.Close();
                    MainClass.con.Close();
                }


            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return Mealslist;
        }
        private void AddMealrow_Click(object sender, EventArgs e)
        {

            // Create a single row for your DataGridView.
            DataGridViewRow row = new DataGridViewRow();

            // Create a DataGridViewComboBoxCell for the combo box.
            DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell comboCellcategory = new DataGridViewComboBoxCell();

            // Clear the items in the combo cell to avoid duplicates.
            comboCell.Items.Clear();

            // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
            comboCell.DataSource = GetMeals();
            comboCell.DisplayMember = "Name";
            comboCell.ValueMember = "ID";

            // Set the default selected value for the combo box.
            comboCell.Value = GetMeals()[0].ID; // Replace with the desired default value.

            comboCellcategory.Items.Clear();

            comboCellcategory.DataSource = GetCategory();



            for (int i = 1; i < guna2DataGridView2.ColumnCount; i++)
            {
                // Create a DataGridViewColumn for the current column.
                DataGridViewColumn column = guna2DataGridView2.Columns[i];

                if (i == 1)
                {
                    column.CellTemplate = comboCellcategory;
                }
                //else if(i == 9)
                //{
                //    DataGridViewButtonCell removeButtonCell = new DataGridViewButtonCell();
                //    removeButtonCell.Value = "Remove";
                //    row.Cells.Add(removeButtonCell);
                //}
                else
                {
                    if (i == 9)
                    {
                        continue;
                    }
                    else
                    {
                        column.CellTemplate = comboCell;

                    }
                }
            }
            //DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
            //buttonCell.Value = "Remove"; // Set the button text to "Remove"
            //row.Cells.Add(buttonCell);

            guna2DataGridView2.Rows.Add(row);
        }
        private int GetLastMeal()
        {

            int ID = 0;
            // Create a connection a

            // Create a SQL command to retrieve the last meal
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM DietPlanTemplate ORDER BY ID DESC", MainClass.con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create a Meal object and populate it with data from the database

                        ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        // Retrieve other columns as needed

                    }
                }
            }


            return ID;
        }
        private void save_Click(object sender, EventArgs e)
        {
            chartfiller = 0;
            if (edit == 0)
            {
                if (dietplantemplatename.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanTemplate (DietPlanTemplateName, DietPlanTemplate, DietPlanDays, Instructions, MEDICALHISTORY,  Calories, Fats, Fibers, Potassium, Water, Sugar, Calcium, A, Protein, Carbohydrates, Sodium, Phosphor, Magnesium, Iron, Iodine, B) " +
                            "VALUES (@DietPlanTemplateName, @DietPlanTemplate, @DietPlanDays, @Instructions, @medicalhistory,  @Calories, @Fats, @Fibers, @Potassium, @Water, @Sugar, @Calcium, @A, @Protein, @Carbohydrates, @Sodium, @Phosphor, @Magnesium, @Iron, @Iodine, @B)", MainClass.con);

                        // Assuming appropriate text boxes for each field in the DietPlan table
                        //cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                       
                        cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatename.Text);
                        cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplatebox.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDays", dietplandays.Text);
                        cmd.Parameters.AddWithValue("@Instructions", instruction.Text);
                        cmd.Parameters.AddWithValue("@medicalhistory", medicalhistory.Text);
                        cmd.Parameters.AddWithValue("@Calories", Convert.ToDouble(calories.Text));
                        cmd.Parameters.AddWithValue("@Fats", Convert.ToDouble(fats.Text));
                        cmd.Parameters.AddWithValue("@Fibers", Convert.ToDouble(fibers.Text));
                        cmd.Parameters.AddWithValue("@Potassium", Convert.ToDouble(potassium.Text));
                        cmd.Parameters.AddWithValue("@Water", Convert.ToDouble(water.Text));
                        cmd.Parameters.AddWithValue("@Sugar", Convert.ToDouble(sugar.Text));
                        cmd.Parameters.AddWithValue("@Calcium", Convert.ToDouble(calcium.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text));
                        cmd.Parameters.AddWithValue("@Protein", Convert.ToDouble(protein.Text));
                        cmd.Parameters.AddWithValue("@Carbohydrates", Convert.ToDouble(carbohydrates.Text));
                        cmd.Parameters.AddWithValue("@Sodium", Convert.ToDouble(sodium.Text));
                        cmd.Parameters.AddWithValue("@Phosphor", Convert.ToDouble(phosphor.Text));
                        cmd.Parameters.AddWithValue("@Magnesium", Convert.ToDouble(magnesium.Text));
                        cmd.Parameters.AddWithValue("@Iron", Convert.ToDouble(iron.Text));
                        cmd.Parameters.AddWithValue("@Iodine", Convert.ToDouble(iodine.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Diet Plan Template added successfully");
                        MainClass.con.Close();

                
                        dietplantemplatename.Text = "";
                        dietplantemplatebox.Text = "";
                        dietplandays.Text = "";
                        instruction.Text = "";                       
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

                        // Switch to the first tab of your tab control (assuming it's called tabControl1)
                        tabControl1.SelectedIndex = 0;

                        // Refresh the DataGridView
                        ShowDietPlanTemplates(guna2DataGridView1, filenodgv, dietnamedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                        {
                            if (!row.IsNewRow) // Skip the last empty row if present.
                            {

                                string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                if (row.Cells[1] == null)
                                {
                                    MessageBox.Show("The category is empty!");
                                }
                                if (row.Cells[1].Value != null)
                                {
                                    category = row.Cells[1].Value.ToString();
                                }

                                if (row.Cells["onedgv"].Value != null)
                                {
                                    one = row.Cells["onedgv"].Value.ToString();
                                }

                                if (row.Cells["twodgv"].Value != null)
                                {
                                    two = row.Cells["twodgv"].Value.ToString();
                                }

                                if (row.Cells["threedgv"].Value != null)
                                {
                                    three = row.Cells["threedgv"].Value.ToString();
                                }

                                if (row.Cells["fourdgv"].Value != null)
                                {
                                    four = row.Cells["fourdgv"].Value.ToString();
                                }

                                if (row.Cells["fivedgv"].Value != null)
                                {
                                    five = row.Cells["fivedgv"].Value.ToString();
                                }

                                if (row.Cells["sixdgv"].Value != null)
                                {
                                    six = row.Cells["sixdgv"].Value.ToString();
                                }

                                if (row.Cells["sevendgv"].Value != null)
                                {
                                    seven = row.Cells["sevendgv"].Value.ToString();
                                }
                                try
                                {
                                    MainClass.con.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanTemplateAction (DietPlanTemplateID, one, two, three, Four, Five, Six, Seven, Category) " +
                                        "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                    // Assuming appropriate variables for the values in the DietPlanAction table
                                    cmd.Parameters.AddWithValue("@DietPlanID", GetLastMeal()); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
                                    cmd.Parameters.AddWithValue("@One", one);
                                    cmd.Parameters.AddWithValue("@Two", two);
                                    cmd.Parameters.AddWithValue("@Three", three);
                                    cmd.Parameters.AddWithValue("@Four", four);
                                    cmd.Parameters.AddWithValue("@Five", five);
                                    cmd.Parameters.AddWithValue("@Six", six);
                                    cmd.Parameters.AddWithValue("@Seven", seven);
                                    cmd.Parameters.AddWithValue("@Category", category); // Change 'categoryTextBox' to the actual textbox capturing the category value

                                    cmd.ExecuteNonQuery();
                                    //MessageBox.Show("Diet Plan added Successfully!");
                                    MainClass.con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("An error occurred: " + ex.Message);
                                }

                            }





                        }

                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the Diet Plan Template name."); // Or any other required field.
                }
            }
            else
            {

                if (dietplantemplatename.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE DietPlanTemplate SET DietPlanTemplateName = @DietPlanTemplateName, DietPlanTemplate = @DietPlanTemplate, DietPlanDays = @DietPlanDays, Instructions = @Instructions, MEDICALHISTORY = @medicalhistory, CALORIES = @Calories, FATS = @Fats, FIBERS = @Fibers, POTASSIUM = @Potassium, WATER = @Water, SUGAR = @Sugar, CALCIUM = @Calcium, A = @A, PROTEIN = @Protein, CARBOHYDRATES = @Carbohydrates, SODIUM = @Sodium, PHOSPHOR = @Phosphor, MAGNESIUM = @Magnesium, IRON = @Iron, IODINE = @Iodine, B = @B WHERE ID = @Fileno", MainClass.con);

                        // Assuming appropriate text boxes for each field in the DietPlan table
                        cmd.Parameters.AddWithValue("@Fileno", dietPlanIDToEdit);
                        cmd.Parameters.AddWithValue("@DietPlanDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatename.Text);
                        cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplatebox.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDays", dietplandays.Text);
                        cmd.Parameters.AddWithValue("@Instructions", instruction.Text);
                        cmd.Parameters.AddWithValue("@medicalhistory", medicalhistory.Text);                 
                        cmd.Parameters.AddWithValue("@Calories", Convert.ToDouble(calories.Text));
                        cmd.Parameters.AddWithValue("@Fats", Convert.ToDouble(fats.Text));
                        cmd.Parameters.AddWithValue("@Fibers", Convert.ToDouble(fibers.Text));
                        cmd.Parameters.AddWithValue("@Potassium", Convert.ToDouble(potassium.Text));
                        cmd.Parameters.AddWithValue("@Water", Convert.ToDouble(water.Text));
                        cmd.Parameters.AddWithValue("@Sugar", Convert.ToDouble(sugar.Text));
                        cmd.Parameters.AddWithValue("@Calcium", Convert.ToDouble(calcium.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text));
                        cmd.Parameters.AddWithValue("@Protein", Convert.ToDouble(protein.Text));
                        cmd.Parameters.AddWithValue("@Carbohydrates", Convert.ToDouble(carbohydrates.Text));
                        cmd.Parameters.AddWithValue("@Sodium", Convert.ToDouble(sodium.Text));
                        cmd.Parameters.AddWithValue("@Phosphor", Convert.ToDouble(phosphor.Text));
                        cmd.Parameters.AddWithValue("@Magnesium", Convert.ToDouble(magnesium.Text));
                        cmd.Parameters.AddWithValue("@Iron", Convert.ToDouble(iron.Text));
                        cmd.Parameters.AddWithValue("@Iodine", Convert.ToDouble(iodine.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Diet Plan Template updated successfully");
                        MainClass.con.Close();

         
                        dietplantemplatename.Text = "";
                        dietplantemplatebox.Text = "";
                        dietplandays.Text = "";
                        instruction.Text = "";                       
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

                        // Switch to the first tab of your tab control (assuming it's called tabControl1)
                        tabControl1.SelectedIndex = 0;

                        // Refresh the DataGridView
                        ShowDietPlanTemplates(guna2DataGridView1, filenodgv, dietnamedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmdingredients = new SqlCommand("DELETE FROM DietPlanTemplateAction WHERE DietPlanTemplateID = @ID", MainClass.con);
                        cmdingredients.Parameters.AddWithValue("@ID", dietPlanIDToEdit); // Assuming the Ingredient ID is in the first cell of the selected row.
                        cmdingredients.ExecuteNonQuery();
                        //MessageBox.Show("Meal removed successfully");
                        //MainClass.con.Close();

                        foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                        {
                            if (!row.IsNewRow) // Skip the last empty row if present.
                            {

                                string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                if (row.Cells[1] == null)
                                {
                                    MessageBox.Show("The category is empty!");
                                }
                                if (row.Cells[1].Value != null)
                                {
                                    category = row.Cells[1].Value.ToString();
                                }

                                if (row.Cells[2].Value != null)
                                {
                                    one = row.Cells[2].Value.ToString();
                                }

                                if (row.Cells[3].Value != null)
                                {
                                    two = row.Cells[3].Value.ToString();
                                }

                                if (row.Cells[4].Value != null)
                                {
                                    three = row.Cells[4].Value.ToString();
                                }

                                if (row.Cells[5].Value != null)
                                {
                                    four = row.Cells[5].Value.ToString();
                                }

                                if (row.Cells[6].Value != null)
                                {
                                    five = row.Cells[6].Value.ToString();
                                }

                                if (row.Cells[7].Value != null)
                                {
                                    six = row.Cells[7].Value.ToString();
                                }

                                if (row.Cells[8].Value != null)
                                {
                                    seven = row.Cells[8].Value.ToString();
                                }
                                try
                                {
                                    //MainClass.con.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanTemplateAction (DietPlanTemplateID, one, two, three, Four, Five, Six, Seven, Category) " +
                                        "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                    // Assuming appropriate variables for the values in the DietPlanAction table
                                    cmd.Parameters.AddWithValue("@DietPlanID", dietPlanIDToEdit); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
                                    cmd.Parameters.AddWithValue("@One", one);
                                    cmd.Parameters.AddWithValue("@Two", two);
                                    cmd.Parameters.AddWithValue("@Three", three);
                                    cmd.Parameters.AddWithValue("@Four", four);
                                    cmd.Parameters.AddWithValue("@Five", five);
                                    cmd.Parameters.AddWithValue("@Six", six);
                                    cmd.Parameters.AddWithValue("@Seven", seven);
                                    cmd.Parameters.AddWithValue("@Category", category); // Change 'categoryTextBox' to the actual textbox capturing the category value

                                    cmd.ExecuteNonQuery();
                                    //MessageBox.Show("Diet Plan updated Successfully!");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("An error occurred: " + ex.Message);
                                }

                            }

                        }
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
                    MessageBox.Show("Please enter the diet plan template name."); // Or any other required field.
                }
            }

        }
        private List<int> GetMealsForDietPlan()
        {
            List<int> idlist = new List<int>();

            try
            {

                MainClass.con.Open();
                SqlCommand cmdthree = new SqlCommand("SELECT ID FROM DietPlanTemplateAction WHERE DietPlanTemplateID = @Mealid", MainClass.con);
                cmdthree.Parameters.AddWithValue("@Mealid", dietPlanIDToEdit);

                using (SqlDataReader reader = cmdthree.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        idlist.Add(id);
                    }
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return idlist;
        }
        private List<MealsDropdown> GetMeals(int id_ar)
        {
            List<MealsDropdown> Mealslist = new List<MealsDropdown>();


            try
            {
                Mealslist.Clear();
                SqlCommand cmdfour = new SqlCommand("SELECT ID, MealAr FROM Meal WHERE ID = @id", MainClass.con);
                cmdfour.Parameters.AddWithValue("@id", id_ar);

                SqlDataReader reader65 = cmdfour.ExecuteReader();

                while (reader65.Read())
                {
                    int id = Convert.ToInt32(reader65["ID"]);
                    string ingredientAr = reader65["MealAr"].ToString();
                    Mealslist.Add(new MealsDropdown { ID = id, Name = ingredientAr });
                }
                reader65.Close();


                SqlCommand cmdfours = new SqlCommand("SELECT ID, MealAr FROM Meal", MainClass.con);

                SqlDataReader reader85 = cmdfours.ExecuteReader();

                while (reader85.Read())
                {
                    int id = Convert.ToInt32(reader85["ID"]);
                    if (id == id_ar)
                    {
                        continue;
                    }
                    string ingredientAr = reader85["MealAr"].ToString();
                    Mealslist.Add(new MealsDropdown { ID = id, Name = ingredientAr });
                }
                reader85.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Mealslist;
        }
        private void AddDifferentColumnsToRow(DataGridViewRow row, string one, string two, string three, string Four, string Five, string Six, string Seven, int i)
        {
            // Example condition to add different columns to cells in the row
            if (!string.IsNullOrEmpty(one))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(one)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(one))[0].ID;
                guna2DataGridView2.Rows[i].Cells[2] = comboCell;
            }
            else
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                // Clear the items in the combo cell to avoid duplicates.
                comboCell.Items.Clear();

                // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
                comboCell.DataSource = GetMeals();
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";

                // Set the default selected value for the combo box.
                guna2DataGridView2.Rows[i].Cells[2] = comboCell;
            }

            if (!string.IsNullOrEmpty(two))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(two)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(two))[0].ID;
                guna2DataGridView2.Rows[i].Cells[3] = comboCell;
            }
            else
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                // Clear the items in the combo cell to avoid duplicates.
                comboCell.Items.Clear();

                // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
                comboCell.DataSource = GetMeals();
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";

                // Set the default selected value for the combo box.
                guna2DataGridView2.Rows[i].Cells[3] = comboCell;
            }

            if (!string.IsNullOrEmpty(three))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(three)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(three))[0].ID;
                guna2DataGridView2.Rows[i].Cells[4] = comboCell;
            }
            else
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                // Clear the items in the combo cell to avoid duplicates.
                comboCell.Items.Clear();

                // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
                comboCell.DataSource = GetMeals();
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";

                // Set the default selected value for the combo box.
                guna2DataGridView2.Rows[i].Cells[4] = comboCell;
            }

            if (!string.IsNullOrEmpty(Four))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Four)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Four))[0].ID;
                guna2DataGridView2.Rows[i].Cells[5] = comboCell;
            }
            else
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                // Clear the items in the combo cell to avoid duplicates.
                comboCell.Items.Clear();

                // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
                comboCell.DataSource = GetMeals();
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";

                // Set the default selected value for the combo box.
                guna2DataGridView2.Rows[i].Cells[5] = comboCell;
            }

            if (!string.IsNullOrEmpty(Five))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Five)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Five))[0].ID;
                guna2DataGridView2.Rows[i].Cells[6] = comboCell;
            }
            else
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                // Clear the items in the combo cell to avoid duplicates.
                comboCell.Items.Clear();

                // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
                comboCell.DataSource = GetMeals();
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";

                // Set the default selected value for the combo box.
                guna2DataGridView2.Rows[i].Cells[6] = comboCell;
            }

            if (!string.IsNullOrEmpty(Six))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Six)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Six))[0].ID;
                guna2DataGridView2.Rows[i].Cells[7] = comboCell;
            }
            else
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                // Clear the items in the combo cell to avoid duplicates.
                comboCell.Items.Clear();

                // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
                comboCell.DataSource = GetMeals();
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";

                // Set the default selected value for the combo box.
                guna2DataGridView2.Rows[i].Cells[7] = comboCell;
            }

            if (!string.IsNullOrEmpty(Seven))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Seven)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Seven))[0].ID;
                guna2DataGridView2.Rows[i].Cells[8] = comboCell;
            }
            else
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                // Clear the items in the combo cell to avoid duplicates.
                comboCell.Items.Clear();

                // Set the DataSource, DisplayMember, and ValueMember for the combo cell.
                comboCell.DataSource = GetMeals();
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";

                // Set the default selected value for the combo box.
                guna2DataGridView2.Rows[i].Cells[8] = comboCell;
            }

            //guna2DataGridView2.Rows.Add(row);
            // You can add other cells based on the other parameters (two, three, Four, Five, Six, Seven) in a similar fashion.
        }
        private void extrafunc()
        {
            List<int> itemids = GetMealsForDietPlan();
            guna2DataGridView2.Rows.Clear();

            MainClass.con.Open();
            for (int i = 0; i < itemids.Count; i++)
            {

                string query = "SELECT category, one, two, three, Four, Five, Six, Seven FROM DietPlanTemplateAction WHERE ID = @DietPlanID";

                SqlCommand cmd2 = new SqlCommand(query, MainClass.con);

                cmd2.Parameters.AddWithValue("@DietPlanID", itemids[i]);

                SqlDataReader reader75 = cmd2.ExecuteReader();

                if (reader75.Read())
                {
                    string category = reader75["category"].ToString();
                    string one = reader75["one"].ToString();
                    string two = reader75["two"].ToString();
                    string three = reader75["three"].ToString();
                    string Four = reader75["Four"].ToString();
                    string Five = reader75["Five"].ToString();
                    string Six = reader75["Six"].ToString();
                    string Seven = reader75["Seven"].ToString();
                    reader75.Close();

                    DataGridViewRow row = new DataGridViewRow();
                    guna2DataGridView2.Rows.Add(row);

                    // Add the category column to the row
                    DataGridViewComboBoxCell comboCellCategory = new DataGridViewComboBoxCell();
                    comboCellCategory.Items.Clear();
                    comboCellCategory.DataSource = GetCategory();
                    if (category == "Breakfast")
                    {
                        comboCellCategory.Value = GetCategory()[0];
                    }
                    else if (category == "Functional Food")
                    {
                        comboCellCategory.Value = GetCategory()[4];
                    }
                    else if (category == "Dinner")
                    {
                        comboCellCategory.Value = GetCategory()[2];
                    }
                    else if (category == "Lunch")
                    {
                        comboCellCategory.Value = GetCategory()[1];
                    }
                    else
                    {
                        comboCellCategory.Value = GetCategory()[3];

                    }
                    //comboCellCategory.Value = GetCategory();
                    // Replace with your specific field
                    guna2DataGridView2.Rows[i].Cells[1] = comboCellCategory;

                    // Decide and add different columns based on your conditions for each cell
                    AddDifferentColumnsToRow(row, one, two, three, Four, Five, Six, Seven, i);

                }

            }
            MainClass.con.Close();
        }
        private void viewEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            try
            {
                dietPlanIDToEdit = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlanTemplate WHERE ID = @DietPlanID", MainClass.con);
                cmd.Parameters.AddWithValue("@DietPlanID", dietPlanIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        dietplantemplatename.Text = reader["DietPlanTemplateName"].ToString();
                        dietplantemplatebox.Text = reader["DietPlanTemplate"].ToString();
                        dietplandays.Text = reader["DietPlanDays"].ToString();
                        instruction.Text = reader["Instructions"].ToString();
                        medicalhistory.Text = reader["MEDICALHISTORY"].ToString();
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
                    reader.Close();
                    MainClass.con.Close();
                    extrafunc();
                    tabControl1.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("Diet Plan Template not found with ID: " + dietPlanIDToEdit);
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView2.Columns["buttondgv"].Index && e.RowIndex >= 0)
            {
                // Remove the corresponding row when the remove button is clicked.
                guna2DataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void guna2DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                // Attach the SelectionChangeCommitted event to the ComboBox
                comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted; // Ensure it's detached first
                comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
            }
        }
        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;

            // Assuming the ComboBox contains items of a custom class "YourCustomClass"
            if (comboBox.SelectedItem is MealsDropdown selectedObject)
            {
                int selectedValue = selectedObject.ID;
                if (chartfiller == 0)
                {
                    calories.Text = "0";
                    fats.Text = "0";
                    fibers.Text = "0";
                    potassium.Text = "0";
                    water.Text = "0";
                    sugar.Text = "0";
                    calcium.Text = "0";
                    abox.Text = "0";
                    protein.Text = "0";
                    carbohydrates.Text = "0";
                    sodium.Text = "0";
                    phosphor.Text = "0";
                    magnesium.Text = "0";
                    iron.Text = "0";
                    iodine.Text = "0";
                    bbox.Text = "0";

                    chartfiller = 1;
                }
                ChartFiller(selectedValue);
                // Use the value as needed in your application
            }
        }
        private void ChartFiller(int id)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, PROTEIN, SODIUM, POTASSIUM, PHOSPHOR, WATER, MAGNESIUM, SUGAR, IRON, IODINE, A, B FROM Meal WHERE ID = @ID", MainClass.con);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        float caloriesValue = float.Parse(calories.Text);
                        float fatsValue = float.Parse(fats.Text);
                        float fibersValue = float.Parse(fibers.Text);
                        float potassiumValue = float.Parse(potassium.Text);
                        float waterValue = float.Parse(water.Text);
                        float sugarValue = float.Parse(sugar.Text);
                        float calciumValue = float.Parse(calcium.Text);
                        float aboxValue = float.Parse(abox.Text);
                        float proteinValue = float.Parse(protein.Text);
                        float carbohydratesValue = float.Parse(carbohydrates.Text);
                        float sodiumValue = float.Parse(sodium.Text);
                        float phosphorValue = float.Parse(phosphor.Text);
                        float magnesiumValue = float.Parse(magnesium.Text);
                        float ironValue = float.Parse(iron.Text);
                        float iodineValue = float.Parse(iodine.Text);
                        float bboxValue = float.Parse(bbox.Text);

                        // Assuming the reader is a DataReader
                        // Add the existing values from text boxes with the new values obtained from the reader
                        caloriesValue += float.Parse(reader["CALORIES"].ToString());
                        fatsValue += float.Parse(reader["FATS"].ToString());
                        fibersValue += float.Parse(reader["FIBERS"].ToString());
                        potassiumValue += float.Parse(reader["POTASSIUM"].ToString());
                        waterValue += float.Parse(reader["WATER"].ToString());
                        sugarValue += float.Parse(reader["SUGAR"].ToString());
                        calciumValue += float.Parse(reader["CALCIUM"].ToString());
                        aboxValue += float.Parse(reader["A"].ToString());
                        proteinValue += float.Parse(reader["PROTEIN"].ToString());
                        carbohydratesValue += float.Parse(reader["CARBOHYDRATES"].ToString());
                        sodiumValue += float.Parse(reader["SODIUM"].ToString());
                        phosphorValue += float.Parse(reader["PHOSPHOR"].ToString());
                        magnesiumValue += float.Parse(reader["MAGNESIUM"].ToString());
                        ironValue += float.Parse(reader["IRON"].ToString());
                        iodineValue += float.Parse(reader["IODINE"].ToString());
                        bboxValue += float.Parse(reader["B"].ToString());

                        // Assign the summed values back to the respective text boxes
                        calories.Text = caloriesValue.ToString();
                        fats.Text = fatsValue.ToString();
                        fibers.Text = fibersValue.ToString();
                        potassium.Text = potassiumValue.ToString();
                        water.Text = waterValue.ToString();
                        sugar.Text = sugarValue.ToString();
                        calcium.Text = calciumValue.ToString();
                        abox.Text = aboxValue.ToString();
                        protein.Text = proteinValue.ToString();
                        carbohydrates.Text = carbohydratesValue.ToString();
                        sodium.Text = sodiumValue.ToString();
                        phosphor.Text = phosphorValue.ToString();
                        magnesium.Text = magnesiumValue.ToString();
                        iron.Text = ironValue.ToString();
                        iodine.Text = iodineValue.ToString();
                        bbox.Text = bboxValue.ToString();

                    }
                    reader.Close();
                    MainClass.con.Close();
                    //extrafunc();
                    //tabControl1.SelectedIndex = ;
                }
                else
                {
                    MessageBox.Show("Meal Not Found!");
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            SearchDietPlanTemplates(guna2DataGridView1, filenodgv, dietnamedgv);

        }
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
                dt.Rows.Add("Fats", double.Parse(fats.Text) * 9);

            }
            if (protein.Text != "")
            {
                dt.Rows.Add("Protein", double.Parse(protein.Text) * 4);

            }
            if (carbohydrates.Text != "")
            {
                dt.Rows.Add("Carbohydrates", double.Parse(carbohydrates.Text) * 4);
            }

            if (titlecheck != 1)
            {
                chart1.Titles.Add("Nutrient Chart");
                titlecheck = 1;
            }
            chart1.Titles[0].Alignment = ContentAlignment.TopCenter; // Align the title to the top center

            // Your existing code for chart settings
            chart1.Legends[0].Enabled = true; // Enable the legend.
            chart1.Legends[0].Alignment = StringAlignment.Center; // Align the legend to the center.
            chart1.Legends[0].Docking = Docking.Bottom; // Dock the legend at the bottom.

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
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (guna2DataGridView2 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {

                        dietplantemplatebox.Text = "";
                        dietplantemplatename.Text = "";
                        dietplandays.Text = "";
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
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Diet Plan template with ID : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            string id = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM DietPlanTemplate WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("ID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString()); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                //MainClass.con.Open();
                                //SqlCommand cmdingredients = new SqlCommand("DELETE FROM DietPlan WHERE ID = @MealID", MainClass.con);
                                //cmdingredients.Parameters.AddWithValue("@MealID", id); // Assuming the Ingredient ID is in the first cell of the selected row.
                                //cmdingredients.ExecuteNonQuery();
                                //MessageBox.Show("Meal removed successfully");
                                //MainClass.con.Close();

                                ShowDietPlanTemplates(guna2DataGridView1, filenodgv, dietnamedgv);
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
        private void emptyplan_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.Rows.Clear();

            calories.Text = "0";
            fats.Text = "0";
            fibers.Text = "0";
            potassium.Text = "0";
            water.Text = "0";
            sugar.Text = "0";
            calcium.Text = "0";
            abox.Text = "0";
            protein.Text = "0";
            carbohydrates.Text = "0";
            sodium.Text = "0";
            phosphor.Text = "0";
            magnesium.Text = "0";
            iron.Text = "0";
            iodine.Text = "0";
            bbox.Text = "0";

        }
    }
}
