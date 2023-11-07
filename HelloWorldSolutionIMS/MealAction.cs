using Guna.UI2.WinForms;
using iTextSharp.text.pdf.codec.wmf;
using RestSharp.Extensions;
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
using static HelloWorldSolutionIMS.MealAction;

namespace HelloWorldSolutionIMS
{
    public partial class MealAction : Form
    {
        public MealAction()
        {
            InitializeComponent();
            //tabControl1.SelectedIndex = 2;
            carbohydrates.TextChanged += UpdateChart;
            fats.TextChanged += UpdateChart;
            protein.TextChanged += UpdateChart;
            //fibers.TextChanged += UpdateChart;

           

        }

        public void extrafunc()
        {
            List<int> itemids = GetIngredientsForMeal();
            guna2DataGridView1.Rows.Clear();
            for (int i = 0; i < itemids.Count; i++)
            {
                MainClass.con.Open();
                //int selectedIngredientID = Convert.ToInt32(guna2DataGridView1.Rows[i].Cells[1].Value);

                //// Get the new quantity value from the "Quantity" cell.
                //int newQuantity = Convert.ToInt32(guna2DataGridView1.Rows[i].Cells[3].Value);

                // Fetch additional data based on the selected Ingredient ID and new quantity from your database.
                // You can use a SQL query to retrieve data for other cells.
                string query = "SELECT Quantity,CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, PROTEIN, SODIUM, UNIT, POTASSIUM, PHOSPHOR, WATER, MAGNESIUM, SUGER, IRON, IODINE, A, B, IngredientEn, IngredientAr FROM MealIngredients WHERE ID = @MealID";

                using (SqlCommand cmdtwo = new SqlCommand(query, MainClass.con))
                {
                    cmdtwo.Parameters.AddWithValue("@MealID", itemids[i]);
                    
                    SqlDataReader reader5 = cmdtwo.ExecuteReader();

                    if (reader5.Read())
                    {
                        // Calculate the values for other cells in the row based on the fetched data and the new quantity.
                        double caloriesd = Convert.ToDouble(reader5["CALORIES"]);
                        double fatsd = Convert.ToDouble(reader5["FATS"]);
                        double carbohydratesd = Convert.ToDouble(reader5["CARBOHYDRATES"]);
                        double fibersd = Convert.ToDouble(reader5["FIBERS"]);
                        double Proteind = Convert.ToDouble(reader5["PROTEIN"]);
                        double calciumd = Convert.ToDouble(reader5["CALCIUM"]);
                        double sodiumd = Convert.ToDouble(reader5["SODIUM"]);
                        double potassiumd = Convert.ToDouble(reader5["POTASSIUM"]);
                        double iodined = Convert.ToDouble(reader5["IODINE"]);
                        double ad = Convert.ToDouble(reader5["A"]);
                        double bd = Convert.ToDouble(reader5["B"]);
                        double irond = Convert.ToDouble(reader5["IRON"]);
                        double waterd = Convert.ToDouble(reader5["WATER"]);
                        double sugerd = Convert.ToDouble(reader5["SUGER"]);
                        double magnesiumd = Convert.ToDouble(reader5["MAGNESIUM"]);
                        double phosphord = Convert.ToDouble(reader5["PHOSPHOR"]);
                        int ingredientend = int.Parse(reader5["IngredientEn"].ToString());
                        int ingredientard = int.Parse(reader5["IngredientAr"].ToString());
                        int Quantityd = int.Parse(reader5["Quantity"].ToString());
                        string unitd = (reader5["UNIT"]).ToString();


                        MainClass.con.Close();
                        if (removeflag != 1)
                        {
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.Name = "RemoveColumn";
                            buttonColumn.HeaderText = "Action";
                            buttonColumn.Text = "Remove";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            guna2DataGridView1.Columns.Add(buttonColumn);
                            removeflag = 1;

                            // Set the custom cell style for the button cells
                            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                            cellStyle.BackColor = Color.Red; // Set the background color to red
                            buttonColumn.DefaultCellStyle = cellStyle;

                            // Handle the click event for the "Remove" button
                            guna2DataGridView1.CellContentClick += (s, args) =>
                            {
                                if (args.RowIndex >= 0 && args.ColumnIndex == guna2DataGridView1.Columns["RemoveColumn"].Index)
                                {
                                    if (guna2DataGridView1.Rows[args.RowIndex].Cells[4].Value == "" || guna2DataGridView1.Rows[args.RowIndex].Cells[4].Value == null)
                                    {
                                        guna2DataGridView1.Rows.RemoveAt(args.RowIndex);

                                    }
                                    else
                                    {
                                        var caloriesu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[4].Value.ToString());
                                        var proteinu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[5].Value.ToString());
                                        var fatsu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[6].Value.ToString());
                                        var carbsu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[7].Value.ToString());
                                        var calciumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[8].Value.ToString());
                                        var fiberu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[9].Value.ToString());
                                        var sodiumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[10].Value.ToString());
                                        var potassiumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[11].Value.ToString());
                                        var phosphoru = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[12].Value.ToString());
                                        var wateru = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[13].Value.ToString());
                                        var magnesiumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[14].Value.ToString());
                                        var sugaru = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[15].Value.ToString());
                                        var ironu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[16].Value.ToString());
                                        var iodineu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[17].Value.ToString());
                                        var au = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[18].Value.ToString());
                                        var bu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[19].Value.ToString());

                                        double currentCalories = double.Parse(calories.Text);
                                        double currentProteins = double.Parse(protein.Text);
                                        double currentFats = double.Parse(fats.Text);
                                        double currentCarbohydrates = double.Parse(carbohydrates.Text);
                                        double currentCalcium = double.Parse(calcium.Text);
                                        double currentFibers = double.Parse(fibers.Text);
                                        double currentSodium = double.Parse(sodium.Text);
                                        double currentPotassium = double.Parse(potassium.Text);
                                        double currentPhosphor = double.Parse(phosphor.Text);
                                        double currentWater = double.Parse(water.Text);
                                        double currentMagnesium = double.Parse(magnesium.Text);
                                        double currentSuger = double.Parse(sugar.Text);
                                        double currentIron = double.Parse(iron.Text);
                                        double currentIodine = double.Parse(iodine.Text);
                                        double currenta = double.Parse(abox.Text);
                                        double currentb = double.Parse(bbox.Text);

                                        double updatedCalories = currentCalories - caloriesu;
                                        double updatedProteins = currentProteins - proteinu;
                                        double updatedFats = currentFats - fatsu;
                                        double updatedCarbohydrates = currentCarbohydrates - carbsu;
                                        double updatedCalcium = currentCalcium - calciumu;
                                        double updatedFibers = currentFibers - fiberu;
                                        double updatedSodium = currentSodium - sodiumu;
                                        double updatedPotassium = currentPotassium - potassiumu;
                                        double updatedPhosphor = currentPhosphor - phosphoru;
                                        double updatedWater = currentWater - wateru;
                                        double updatedMagnesium = currentMagnesium - magnesiumu;
                                        double updatedSuger = currentSuger - sugaru;
                                        double updatedIron = currentIron - ironu;
                                        double updatedIodine = currentIodine - iodineu;
                                        double updateda = currenta - au;
                                        double updatedb = currentb - bu;

                                        // Update the textboxes with the new values
                                        calories.Text = updatedCalories.ToString();
                                        protein.Text = updatedProteins.ToString();
                                        fats.Text = updatedFats.ToString();
                                        carbohydrates.Text = updatedCarbohydrates.ToString();
                                        calcium.Text = updatedCalcium.ToString();
                                        fibers.Text = updatedFibers.ToString();
                                        sodium.Text = updatedSodium.ToString();
                                        potassium.Text = updatedPotassium.ToString();
                                        phosphor.Text = updatedPhosphor.ToString();
                                        water.Text = updatedWater.ToString();
                                        magnesium.Text = updatedMagnesium.ToString();
                                        sugar.Text = updatedSuger.ToString();
                                        iron.Text = updatedIron.ToString();
                                        iodine.Text = updatedIodine.ToString();
                                        abox.Text = updateda.ToString();
                                        bbox.Text = updatedb.ToString();

                                        guna2DataGridView1.Rows.RemoveAt(args.RowIndex);
                                        if (guna2DataGridView1.Rows.Count == 0)
                                        {
                                            save.Visible = false;
                                        }
                                        else
                                        {
                                            save.Visible = true;
                                        }
                                    }

                                }
                            };
                        }
                        DataGridViewRow row = new DataGridViewRow();

                        // Create a DataGridViewComboBoxCell for the second cell.
                        DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();

                        // Clear the items in the combo cell to avoid duplicates
                        comboCell.Items.Clear();

                        comboCell.DataSource = GetIngredients(ingredientard);
                        comboCell.DisplayMember = "Name";
                        comboCell.ValueMember = "ID";

                        // Set the default selected value for the combo box.
                        comboCell.Value = GetIngredients(ingredientard)[0].ID; // Replace with the desired default value.

                        // Create a DataGridViewTextBoxCell for the first cell.
                        DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();

                        row.Cells.Add(cell1);
                        row.Cells.Add(comboCell);

                        DataGridViewComboBoxCell comboCell2 = new DataGridViewComboBoxCell();
                        comboCell2.DataSource = GetIngredientsEN(ingredientend); // Use different items for the second combo box
                        comboCell2.DisplayMember = "Name";
                        comboCell2.ValueMember = "ID";
                        comboCell2.Value = GetIngredientsEN(ingredientend)[0].ID;

                        // Create a DataGridViewTextBoxCell for the first cell (just an assumption for the text cell).


                        // Add cells to the row

                        row.Cells.Add(comboCell2);

                        // Add the row to the DataGridView.
                        guna2DataGridView1.Rows.Add(row);
                        // Set the calculated values for other cells in the row.
                        //guna2DataGridView1.Rows[i].Cells[2].Value = ingredientend;
                        guna2DataGridView1.Rows[i].Cells[3].Value = Quantityd;
                        guna2DataGridView1.Rows[i].Cells[4].Value = caloriesd;
                        guna2DataGridView1.Rows[i].Cells[5].Value = Proteind;
                        guna2DataGridView1.Rows[i].Cells[6].Value = fatsd;
                        guna2DataGridView1.Rows[i].Cells[7].Value = carbohydratesd;
                        guna2DataGridView1.Rows[i].Cells[8].Value = calciumd;
                        guna2DataGridView1.Rows[i].Cells[9].Value = fibersd;
                        guna2DataGridView1.Rows[i].Cells[10].Value = sodiumd;
                        guna2DataGridView1.Rows[i].Cells[11].Value = potassiumd;
                        guna2DataGridView1.Rows[i].Cells[12].Value = phosphord;
                        guna2DataGridView1.Rows[i].Cells[13].Value = waterd;
                        guna2DataGridView1.Rows[i].Cells[14].Value = magnesiumd;
                        guna2DataGridView1.Rows[i].Cells[15].Value = sugerd;
                        guna2DataGridView1.Rows[i].Cells[16].Value = irond;
                        guna2DataGridView1.Rows[i].Cells[17].Value = iodined;
                        guna2DataGridView1.Rows[i].Cells[18].Value = ad;
                        guna2DataGridView1.Rows[i].Cells[19].Value = bd;
                        guna2DataGridView1.Rows[i].Cells[0].Value = unitd;
                    }

                    reader5.Close();
                    double totalCalories = 0;
                    double totalProteins = 0;
                    double totalFats = 0;
                    double totalCarbohydrates = 0;
                    double totalCalcium = 0;
                    double totalFibers = 0;
                    double totalSodium = 0;
                    double totalPotassium = 0;
                    double totalPhosphor = 0;
                    double totalWater = 0;
                    double totalMagnesium = 0;
                    double totalSuger = 0;
                    double totalIron = 0;
                    double totalIodine = 0;
                    double totala = 0;
                    double totalb = 0;

                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (row.Cells[4].Value != null)
                        {
                            totalCalories += Convert.ToDouble(row.Cells[4].Value);
                            totalProteins += Convert.ToDouble(row.Cells[5].Value);
                            totalFats += Convert.ToDouble(row.Cells[6].Value);
                            totalCarbohydrates += Convert.ToDouble(row.Cells[7].Value);
                            totalCalcium += Convert.ToDouble(row.Cells[8].Value);
                            totalFibers += Convert.ToDouble(row.Cells[9].Value);
                            totalSodium += Convert.ToDouble(row.Cells[10].Value);
                            totalPotassium += Convert.ToDouble(row.Cells[11].Value);
                            totalPhosphor += Convert.ToDouble(row.Cells[12].Value);
                            totalWater += Convert.ToDouble(row.Cells[13].Value);
                            totalMagnesium += Convert.ToDouble(row.Cells[14].Value);
                            totalSuger += Convert.ToDouble(row.Cells[15].Value);
                            totalIron += Convert.ToDouble(row.Cells[16].Value);
                            totalIodine += Convert.ToDouble(row.Cells[17].Value);
                            totala += Convert.ToDouble(row.Cells[18].Value);
                            totalb += Convert.ToDouble(row.Cells[19].Value);
                        }
                    }

                    calories.Text = totalCalories.ToString();
                    protein.Text = totalProteins.ToString();
                    fats.Text = totalFats.ToString();
                    carbohydrates.Text = totalCarbohydrates.ToString();
                    calcium.Text = totalCalcium.ToString();
                    fibers.Text = totalFibers.ToString();
                    sodium.Text = totalSodium.ToString();
                    potassium.Text = totalPotassium.ToString();
                    phosphor.Text = totalPhosphor.ToString();
                    water.Text = totalWater.ToString();
                    magnesium.Text = totalMagnesium.ToString();
                    sugar.Text = totalSuger.ToString();
                    iron.Text = totalIron.ToString();
                    iodine.Text = totalIodine.ToString();
                    abox.Text = totala.ToString();
                    bbox.Text = totalb.ToString();

                    
                }

            }
            save.Visible = true;

        }
        public class Ingredients
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        List<Ingredients> ingredientsList = new List<Ingredients>();
        List<Ingredients> ingredientsListen = new List<Ingredients>();

        static int titlecheck = 0;
        static int edit = 0;
        static int removeflag = 0;
        static int dropdown = 0;
        static string mealIDToEdit;
        static int counter = 0;
        static int conn = 0;

        public class GroupnarContent
        {
            public int ID { get; set; }
            public string NameAR { get; set; }
            public string NameEN { get; set; }
        }
        private void UpdateGroupsN()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, Namear, Nameen FROM GROUPN", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Clear the dropdown items before adding new ones
                groupnar.DataSource = null;
                groupnen.DataSource = null;

                // Clear the items (if DataSource is not being set)
                groupnar.Items.Clear();
                groupnen.Items.Clear();
                List<GroupnarContent> GroupNAR = new List<GroupnarContent>();

                // Add the default 'Null' option
                GroupNAR.Add(new GroupnarContent { ID = 0, NameAR = "Null", NameEN = "Null" });

                foreach (DataRow row in dt.Rows)
                {
                    int Id = row.Field<int>("ID");
                    string Namear = row.Field<string>("Namear");
                    string Nameen = row.Field<string>("Nameen");

                    GroupnarContent Temp = new GroupnarContent { ID = Id, NameAR = Namear, NameEN = Nameen };
                    GroupNAR.Add(Temp);
                }

                groupnar.DataSource = GroupNAR;
                groupnar.DisplayMember = "NameAR"; // Display Member is Name
                groupnar.ValueMember = "ID"; // Value Member is ID

                groupnen.DataSource = GroupNAR;
                groupnen.DisplayMember = "NameEN"; // Display Member is Name
                groupnen.ValueMember = "ID"; // Value Member is ID


                if (conn == 1)
                {
                    MainClass.con.Close();
                    conn = 0;
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateGroupsC()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, Namear, Nameen FROM GROUPC", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Clear the dropdown items before adding new ones
                groupcar.DataSource = null;
                groupcen.DataSource = null;
                // Clear the items (if DataSource is not being set)
                groupcar.Items.Clear();
                groupcen.Items.Clear();
                List<GroupnarContent> GroupCAR = new List<GroupnarContent>();

                // Add the default 'Null' option
                GroupCAR.Add(new GroupnarContent { ID = 0, NameAR = "Null", NameEN = "Null" });

                foreach (DataRow row in dt.Rows)
                {
                    int Id = row.Field<int>("ID");
                    string Namear= row.Field<string>("Namear");
                    string Nameen = row.Field<string>("Nameen");

                    GroupnarContent Temp = new GroupnarContent { ID = Id, NameAR = Namear, NameEN = Nameen };
                    GroupCAR.Add(Temp);
                }

                groupcar.DataSource = GroupCAR;
                groupcar.DisplayMember = "NameAR"; // Display Member is Name
                groupcar.ValueMember = "ID"; // Value Member is ID

                groupcen.DataSource = GroupCAR;
                groupcen.DisplayMember = "NameEN"; // Display Member is Name
                groupcen.ValueMember = "ID"; // Value Member is ID

                if (conn == 1)
                {
                    MainClass.con.Close();
                    conn = 0;
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowGroupN(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn namear, DataGridViewColumn nameen)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID, Namear, Nameen FROM GROUPN", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                namear.DataPropertyName = dt.Columns["Namear"].ToString();
                nameen.DataPropertyName = dt.Columns["Nameen"].ToString();
               

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowGroupC(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn namear, DataGridViewColumn nameen)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID, Namear, Nameen FROM GROUPC", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                namear.DataPropertyName = dt.Columns["Namear"].ToString();
                nameen.DataPropertyName = dt.Columns["Nameen"].ToString();


                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowMeals(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn mealar, DataGridViewColumn mealen, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID, MealAr, MealEn,PROTEIN, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM FROM Meal", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                mealar.DataPropertyName = dt.Columns["MealAr"].ToString();
                mealen.DataPropertyName = dt.Columns["MealEn"].ToString();
                calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                fats.DataPropertyName = dt.Columns["FATS"].ToString();
                carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchMeals(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn mealarfunc, DataGridViewColumn mealenfunc, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {
            string mealName = mealarsearch.Text;
            string groupArName = groupnarsearch.Text;

            if (mealName != "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, MealAr,MealEn, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM,PROTEIN FROM Meal " +
                        " WHERE (MealAr LIKE @MealName) AND (GroupNAr LIKE @GroupArName)", MainClass.con);

                    cmd.Parameters.AddWithValue("@MealName", "%" + mealName + "%");
                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    mealarfunc.DataPropertyName = dt.Columns["MealAr"].ToString();
                    mealenfunc.DataPropertyName = dt.Columns["MealEn"].ToString();
                    calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                    fats.DataPropertyName = dt.Columns["FATS"].ToString();
                    carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                    fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                    calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                    sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                    protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();



                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (mealName == "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, MealAr,MealEn, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM,PROTEIN FROM Meal" +
                        " WHERE GroupNAr LIKE @GroupArName", MainClass.con);

                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    mealarfunc.DataPropertyName = dt.Columns["MealAr"].ToString();
                    mealenfunc.DataPropertyName = dt.Columns["MealEn"].ToString();
                    calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                    fats.DataPropertyName = dt.Columns["FATS"].ToString();
                    carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                    fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                    calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                    sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                    protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();



                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (mealName != "" && groupArName == "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, MealAr,MealEn, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM,PROTEIN FROM Meal " +
                        " WHERE MealAr LIKE @IngredientName", MainClass.con);

                    cmd.Parameters.AddWithValue("@IngredientName", "%" + mealName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    mealarfunc.DataPropertyName = dt.Columns["MealAr"].ToString();
                    mealenfunc.DataPropertyName = dt.Columns["MealEn"].ToString();
                    calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                    fats.DataPropertyName = dt.Columns["FATS"].ToString();
                    carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                    fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                    calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                    sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                    protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();


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
                MessageBox.Show("Fill Meal Ar or Group Ar");
                ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv);

            }
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
        private void MealAction_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            MainClass.HideAllTabsOnTabControl(tabControl1);
            save.Visible = false;
            
            ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
            guna2DataGridView1.EditingControlShowing += guna2DataGridView1_EditingControlShowing;
        }
        List<int> idlist = new List<int>();
        private List<int> GetIngredientsForMeal()
        {
            try
            {
                MainClass.con.Open();
                ingredientsList.Clear();
                SqlCommand cmdthree = new SqlCommand("SELECT ID FROM MealIngredients WHERE MealID = @Mealid", MainClass.con);
                cmdthree.Parameters.AddWithValue("@Mealid", mealIDToEdit);
                SqlDataReader reader6 = cmdthree.ExecuteReader();
                idlist.Clear();
                while (reader6.Read())
                {
                    int id = Convert.ToInt32(reader6["ID"]);
                    idlist.Add(id);
                    counter++;
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return idlist;
        }
        private List<Ingredients> GetIngredientsEN(int id_ar)
        {
            try
            {
                MainClass.con.Open();
                ingredientsListen.Clear();
                SqlCommand cmdfour = new SqlCommand("SELECT ID, INGREDIENT_EN FROM Ingredient WHERE ID = @id", MainClass.con);
                cmdfour.Parameters.AddWithValue("@id", id_ar);
                SqlDataReader reader3 = cmdfour.ExecuteReader();
                ingredientsListen.Clear();

                while (reader3.Read())
                {
                    int id = Convert.ToInt32(reader3["ID"]);
                    string ingredientAr = reader3["INGREDIENT_EN"].ToString();
                    ingredientsListen.Add(new Ingredients { ID = id, Name = ingredientAr });
                }
                reader3.Close();
                MainClass.con.Close();

                MainClass.con.Open();
                SqlCommand cmdfive = new SqlCommand("SELECT ID, INGREDIENT_EN FROM Ingredient", MainClass.con);
                SqlDataReader reader2 = cmdfive.ExecuteReader();

                while (reader2.Read())
                {
                    int id = Convert.ToInt32(reader2["ID"]);
                    if (id == id_ar)
                    {
                        continue;
                    }
                    string ingredientAr = reader2["INGREDIENT_EN"].ToString();
                    ingredientsListen.Add(new Ingredients { ID = id, Name = ingredientAr });
                }
                reader2.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return ingredientsListen;
        }
        private List<Ingredients> GetIngredients(int id_ar)
        {
            try
            {
                MainClass.con.Open();
                ingredientsList.Clear();
                SqlCommand cmdfour = new SqlCommand("SELECT ID, INGREDIENT_AR FROM Ingredient WHERE ID = @id", MainClass.con);
                cmdfour.Parameters.AddWithValue("@id", id_ar);
                SqlDataReader reader3 = cmdfour.ExecuteReader();
                ingredientsList.Clear();
              
                while (reader3.Read())
                {
                    int id = Convert.ToInt32(reader3["ID"]);
                    string ingredientAr = reader3["INGREDIENT_AR"].ToString();
                    ingredientsList.Add(new Ingredients { ID = id, Name = ingredientAr });
                }
                reader3.Close();
                MainClass.con.Close();

                MainClass.con.Open();
                SqlCommand cmdfive = new SqlCommand("SELECT ID, INGREDIENT_AR FROM Ingredient", MainClass.con);
                SqlDataReader reader2 = cmdfive.ExecuteReader();

                while (reader2.Read())
                {
                    int id = Convert.ToInt32(reader2["ID"]);
                    if(id == id_ar)
                    {
                        continue;
                    }
                    string ingredientAr = reader2["INGREDIENT_AR"].ToString();
                    ingredientsList.Add(new Ingredients { ID = id, Name = ingredientAr });
                }
                reader2.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return ingredientsList;
        }
        private List<Ingredients> GetIngredientsEn()
        {
            try
            {
                MainClass.con.Open();
                ingredientsListen.Clear();
                SqlCommand cmd = new SqlCommand("SELECT ID, INGREDIENT_EN FROM Ingredient", MainClass.con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string ingredientAr = reader["INGREDIENT_EN"].ToString();
                    ingredientsListen.Add(new Ingredients { ID = id, Name = ingredientAr });
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return ingredientsListen;
        }
        private List<Ingredients> GetIngredients()
        {
            try
            {
                MainClass.con.Open();
                ingredientsList.Clear();
                SqlCommand cmd = new SqlCommand("SELECT ID, INGREDIENT_AR FROM Ingredient", MainClass.con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string ingredientAr = reader["INGREDIENT_AR"].ToString();
                    ingredientsList.Add(new Ingredients { ID = id, Name = ingredientAr });
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return ingredientsList;
         }
        private void AddIngredient_Click(object sender, EventArgs e)
        {
            save.Visible = true;

            if (removeflag != 1)
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "RemoveColumn";
                buttonColumn.HeaderText = "Action";
                buttonColumn.Text = "Remove";
                buttonColumn.UseColumnTextForButtonValue = true;
                guna2DataGridView1.Columns.Add(buttonColumn);
                removeflag = 1;

                // Set the custom cell style for the button cells
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.BackColor = Color.Red; // Set the background color to red
                buttonColumn.DefaultCellStyle = cellStyle;

                // Handle the click event for the "Remove" button
                guna2DataGridView1.CellContentClick += (s, args) =>
                {
                    if (args.RowIndex >= 0 && args.ColumnIndex == guna2DataGridView1.Columns["RemoveColumn"].Index)
                    {
                        if(guna2DataGridView1.Rows[args.RowIndex].Cells[4].Value == "" || guna2DataGridView1.Rows[args.RowIndex].Cells[4].Value == null)
                        {
                            guna2DataGridView1.Rows.RemoveAt(args.RowIndex);

                        }
                        else
                        {
                            var caloriesu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[4].Value.ToString());
                            var proteinu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[5].Value.ToString());
                            var fatsu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[6].Value.ToString());
                            var carbsu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[7].Value.ToString());
                            var calciumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[8].Value.ToString());
                            var fiberu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[9].Value.ToString());
                            var sodiumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[10].Value.ToString());
                            var potassiumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[11].Value.ToString());
                            var phosphoru = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[12].Value.ToString());
                            var wateru = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[13].Value.ToString());
                            var magnesiumu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[14].Value.ToString());
                            var sugaru = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[15].Value.ToString());
                            var ironu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[16].Value.ToString());
                            var iodineu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[17].Value.ToString());
                            var au = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[18].Value.ToString());
                            var bu = float.Parse(guna2DataGridView1.Rows[args.RowIndex].Cells[19].Value.ToString());

                            double currentCalories = double.Parse(calories.Text);
                            double currentProteins = double.Parse(protein.Text);
                            double currentFats = double.Parse(fats.Text);
                            double currentCarbohydrates = double.Parse(carbohydrates.Text);
                            double currentCalcium = double.Parse(calcium.Text);
                            double currentFibers = double.Parse(fibers.Text);
                            double currentSodium = double.Parse(sodium.Text);
                            double currentPotassium = double.Parse(potassium.Text);
                            double currentPhosphor = double.Parse(phosphor.Text);
                            double currentWater = double.Parse(water.Text);
                            double currentMagnesium = double.Parse(magnesium.Text);
                            double currentSuger = double.Parse(sugar.Text);
                            double currentIron = double.Parse(iron.Text);
                            double currentIodine = double.Parse(iodine.Text);
                            double currenta = double.Parse(abox.Text);
                            double currentb = double.Parse(bbox.Text);

                            double updatedCalories = currentCalories - caloriesu;
                            double updatedProteins = currentProteins - proteinu;
                            double updatedFats = currentFats - fatsu;
                            double updatedCarbohydrates = currentCarbohydrates - carbsu;
                            double updatedCalcium = currentCalcium - calciumu;
                            double updatedFibers = currentFibers - fiberu;
                            double updatedSodium = currentSodium - sodiumu;
                            double updatedPotassium = currentPotassium - potassiumu;
                            double updatedPhosphor = currentPhosphor - phosphoru;
                            double updatedWater = currentWater - wateru;
                            double updatedMagnesium = currentMagnesium - magnesiumu;
                            double updatedSuger = currentSuger - sugaru;
                            double updatedIron = currentIron - ironu;
                            double updatedIodine = currentIodine - iodineu;
                            double updateda = currenta - au;
                            double updatedb = currentb - bu;

                            // Update the textboxes with the new values
                            calories.Text = updatedCalories.ToString();
                            protein.Text = updatedProteins.ToString();
                            fats.Text = updatedFats.ToString();
                            carbohydrates.Text = updatedCarbohydrates.ToString();
                            calcium.Text = updatedCalcium.ToString();
                            fibers.Text = updatedFibers.ToString();
                            sodium.Text = updatedSodium.ToString();
                            potassium.Text = updatedPotassium.ToString();
                            phosphor.Text = updatedPhosphor.ToString();
                            water.Text = updatedWater.ToString();
                            magnesium.Text = updatedMagnesium.ToString();
                            sugar.Text = updatedSuger.ToString();
                            iron.Text = updatedIron.ToString();
                            iodine.Text = updatedIodine.ToString();
                            abox.Text = updateda.ToString();
                            bbox.Text = updatedb.ToString();

                            guna2DataGridView1.Rows.RemoveAt(args.RowIndex);
                            if (guna2DataGridView1.Rows.Count == 0)
                            {
                                save.Visible = false;
                            }
                            else
                            {
                                save.Visible = true;
                            }
                        }
                        
                    }
                };
            }

            DataGridViewRow row = new DataGridViewRow();

            // Create the first DataGridViewComboBoxCell for the first column.
            DataGridViewComboBoxCell comboCell1 = new DataGridViewComboBoxCell();
            comboCell1.DataSource = GetIngredients();
            comboCell1.DisplayMember = "Name";
            comboCell1.ValueMember = "ID";
            comboCell1.Value = GetIngredients()[0].ID;
            DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
            row.Cells.Add(cell1);
            row.Cells.Add(comboCell1);
            // Create the second DataGridViewComboBoxCell for the second column.
            DataGridViewComboBoxCell comboCell2 = new DataGridViewComboBoxCell();
            comboCell2.DataSource = GetIngredientsEn(); // Use different items for the second combo box
            comboCell2.DisplayMember = "Name";
            comboCell2.ValueMember = "ID";
            comboCell2.Value = GetIngredientsEn()[0].ID;

            // Create a DataGridViewTextBoxCell for the first cell (just an assumption for the text cell).


            // Add cells to the row

            row.Cells.Add(comboCell2);

            // Add the row to the DataGridView.
            guna2DataGridView1.Rows.Add(row);
        }
        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3) // Check if the "Quantity" cell value changed.
            {
                // Get the selected Ingredient ID from the ComboBox cell.
                int selectedIngredientID = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value);

                // Get the new quantity value from the "Quantity" cell.
                int newQuantity = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value);

                // Fetch additional data based on the selected Ingredient ID and new quantity from your database.
                // You can use a SQL query to retrieve data for other cells.
                string query = "SELECT CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, PROTEIN, SODIUM, CLASSIFICATION, POTASSIUM, PHOSPHOR, WATER, MAGNESIUM, SUGAR, IRON, IODINE, A, B, INGREDIENT_EN FROM Ingredient WHERE ID = @IngredientID";

                using (SqlCommand cmd = new SqlCommand(query, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@IngredientID", selectedIngredientID);
                    MainClass.con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Calculate the values for other cells in the row based on the fetched data and the new quantity.
                        double calories = (Convert.ToDouble(reader["CALORIES"]) * newQuantity)/ 100;
                        double fats = (Convert.ToDouble(reader["FATS"]) * newQuantity)/100;
                        double carbohydrates = (Convert.ToDouble(reader["CARBOHYDRATES"]) * newQuantity)/ 100;
                        double fibers = (Convert.ToDouble(reader["FIBERS"]) * newQuantity)/ 100;
                        double Protein = (Convert.ToDouble(reader["PROTEIN"]) * newQuantity) / 100;
                        double calcium = (Convert.ToDouble(reader["CALCIUM"]) * newQuantity) / 100;
                        double sodium = (Convert.ToDouble(reader["SODIUM"]) * newQuantity) / 100;
                        double potassium = (Convert.ToDouble(reader["POTASSIUM"]) * newQuantity) / 100;
                        double iodine = (Convert.ToDouble(reader["IODINE"]) * newQuantity) / 100;
                        double a = (Convert.ToDouble(reader["A"]) * newQuantity) / 100;
                        double b = (Convert.ToDouble(reader["B"]) * newQuantity) / 100;
                        double iron = (Convert.ToDouble(reader["IRON"]) * newQuantity) / 100;
                        double water = (Convert.ToDouble(reader["WATER"]) * newQuantity) / 100;
                        double suger = (Convert.ToDouble(reader["SUGAR"]) * newQuantity) / 100;
                        double magnesium = (Convert.ToDouble(reader["MAGNESIUM"]) * newQuantity) / 100;
                        double phosphor = (Convert.ToDouble(reader["PHOSPHOR"]) * newQuantity) / 100;
                        string ingredienten = reader["INGREDIENT_EN"].ToString();




                        string unit = (reader["CLASSIFICATION"]).ToString();

                        // Set the calculated values for other cells in the row.
                        //guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value = ingredienten;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value = calories;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value = Protein;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value = fats;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value = carbohydrates;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value = calcium;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value = fibers;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[10].Value = sodium;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[11].Value = potassium;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[12].Value = phosphor;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[13].Value = water;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[14].Value = magnesium;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[15].Value = suger;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[16].Value = iron;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[17].Value = iodine;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[18].Value = a;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[19].Value = b;
                        guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value = unit;
                    }

                    double totalCalories = 0;
                    double totalProteins = 0;
                    double totalFats = 0;
                    double totalCarbohydrates = 0;
                    double totalCalcium = 0;
                    double totalFibers = 0;
                    double totalSodium = 0;
                    double totalPotassium = 0;
                    double totalPhosphor = 0;
                    double totalWater = 0;
                    double totalMagnesium = 0;
                    double totalSuger = 0;
                    double totalIron = 0;
                    double totalIodine = 0;
                    double totala = 0;
                    double totalb = 0;

                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (row.Cells[4].Value != null)
                        {
                            totalCalories += Convert.ToDouble(row.Cells[4].Value);
                            totalProteins += Convert.ToDouble(row.Cells[5].Value);
                            totalFats += Convert.ToDouble(row.Cells[6].Value);
                            totalCarbohydrates += Convert.ToDouble(row.Cells[7].Value);
                            totalCalcium += Convert.ToDouble(row.Cells[8].Value);
                            totalFibers += Convert.ToDouble(row.Cells[9].Value);
                            totalSodium += Convert.ToDouble(row.Cells[10].Value);
                            totalPotassium += Convert.ToDouble(row.Cells[11].Value);
                            totalPhosphor += Convert.ToDouble(row.Cells[12].Value);
                            totalWater += Convert.ToDouble(row.Cells[13].Value);
                            totalMagnesium += Convert.ToDouble(row.Cells[14].Value);
                            totalSuger += Convert.ToDouble(row.Cells[15].Value);
                            totalIron += Convert.ToDouble(row.Cells[16].Value);
                            totalIodine += Convert.ToDouble(row.Cells[17].Value);
                            totala += Convert.ToDouble(row.Cells[18].Value);
                            totalb += Convert.ToDouble(row.Cells[19].Value);
                        }
                    }

                    calories.Text = totalCalories.ToString();
                    protein.Text = totalProteins.ToString();
                    fats.Text = totalFats.ToString();
                    carbohydrates.Text = totalCarbohydrates.ToString();
                    calcium.Text = totalCalcium.ToString();
                    fibers.Text = totalFibers.ToString();
                    sodium.Text = totalSodium.ToString();
                    potassium.Text = totalPotassium.ToString(); 
                    phosphor.Text = totalPhosphor.ToString();
                    water.Text = totalWater.ToString();
                    magnesium.Text = totalMagnesium.ToString();
                    sugar.Text = totalSuger.ToString();
                    iron.Text = totalIron.ToString();
                    iodine.Text = totalIodine.ToString();
                    abox.Text = totala.ToString();
                    bbox.Text = totalb.ToString();

                    MainClass.con.Close();
                }
            }

        }
        private int GetLastMeal()
        {

            int ID = 0;
            // Create a connection a

            // Create a SQL command to retrieve the last meal
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Meal ORDER BY ID DESC", MainClass.con))
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
            if (edit == 0)
            {
                if (mealar.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Meal (MealAr, MealEn, GroupNAr, GroupNEn, GroupCAr, GroupCEn, CLASSIFICATION, CALORIES, FATS, FIBERS, POTASSIUM, WATER, SUGAR, CALCIUM, A, PROTEIN, CARBOHYDRATES, SODIUM, PHOSPHOR, MAGNESIUM, IRON, IODINE, B, Notes, Preparation) " +
                            "VALUES (@MealAr, @MealEn, @GroupNAr, @GroupNEn, @GroupCAr, @GroupCEn, @CLASSIFICATION, @CALORIES, @FATS, @FIBERS, @POTASSIUM, @WATER, @SUGAR, @CALCIUM, @A, @PROTEIN, @CARBOHYDRATES, @SODIUM, @PHOSPHOR, @MAGNESIUM, @IRON, @IODINE, @B, @Notes, @Preparation)", MainClass.con);

                        cmd.Parameters.AddWithValue("@MealAr", mealar.Text);
                        cmd.Parameters.AddWithValue("@MealEn", mealen.Text);
                        cmd.Parameters.AddWithValue("@GroupNAr", groupnar.Text);
                        cmd.Parameters.AddWithValue("@GroupNEn", groupnen.Text);
                        cmd.Parameters.AddWithValue("@GroupCAr", groupcar.Text);
                        cmd.Parameters.AddWithValue("@GroupCEn", groupcen.Text);
                        //cmd.Parameters.AddWithValue("@Category", category.Text);
                        cmd.Parameters.AddWithValue("@CLASSIFICATION", classification.Text);
                        cmd.Parameters.AddWithValue("@CALORIES", Convert.ToDouble(calories.Text));
                        cmd.Parameters.AddWithValue("@FATS", Convert.ToDouble(fats.Text));
                        cmd.Parameters.AddWithValue("@FIBERS", Convert.ToDouble(fibers.Text));
                        cmd.Parameters.AddWithValue("@POTASSIUM", Convert.ToDouble(potassium.Text));
                        cmd.Parameters.AddWithValue("@WATER", Convert.ToDouble(water.Text));
                        cmd.Parameters.AddWithValue("@SUGAR", Convert.ToDouble(sugar.Text));
                        cmd.Parameters.AddWithValue("@CALCIUM", Convert.ToDouble(calcium.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text));
                        cmd.Parameters.AddWithValue("@PROTEIN", Convert.ToDouble(protein.Text));
                        cmd.Parameters.AddWithValue("@CARBOHYDRATES", Convert.ToDouble(carbohydrates.Text));
                        cmd.Parameters.AddWithValue("@SODIUM", Convert.ToDouble(sodium.Text));
                        cmd.Parameters.AddWithValue("@PHOSPHOR", Convert.ToDouble(phosphor.Text));
                        cmd.Parameters.AddWithValue("@MAGNESIUM", Convert.ToDouble(magnesium.Text));
                        cmd.Parameters.AddWithValue("@IRON", Convert.ToDouble(iron.Text));
                        cmd.Parameters.AddWithValue("@IODINE", Convert.ToDouble(iodine.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text));
                        cmd.Parameters.AddWithValue("@Notes", notes.Text);
                        cmd.Parameters.AddWithValue("@Preparation", preparation.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Meal added successfully");
                        MainClass.con.Close();

                        mealar.Text = "";
                        mealen.Text = "";
                        groupnar.Text = "";
                        groupnen.Text = "";
                        groupcar.Text = "";
                        groupcen.Text = "";
                        classification.SelectedItem = null;
                        //category.SelectedItem = null;
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
                        notes.Text = "";
                        preparation.Text = "";




                        tabControl1.SelectedIndex = 0;
                        ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            if (!row.IsNewRow) // Skip the last empty row if present.
                            {
                                int ingredientAr = int.Parse(row.Cells["ingredientardgv"].Value.ToString());



                                string ingredientEn = row.Cells["ingredientendgv"].Value.ToString();
                                string unit = row.Cells["unitdgv"].Value.ToString();
                                double calories = Convert.ToDouble(row.Cells["caloriedgv"].Value);
                                double fats = Convert.ToDouble(row.Cells["fatsdgv"].Value);
                                double carbohydrates = Convert.ToDouble(row.Cells["carbohydratesdgv"].Value);
                                double fibers = Convert.ToDouble(row.Cells["fiberdgv"].Value);
                                double protein = Convert.ToDouble(row.Cells["proteindgv"].Value);
                                double calcium = Convert.ToDouble(row.Cells["calciumdgv"].Value);
                                double sodium = Convert.ToDouble(row.Cells["sodiumdgv"].Value);
                                double potassium = Convert.ToDouble(row.Cells["potassiumdgv"].Value);
                                double iodine = Convert.ToDouble(row.Cells["iodinedgv"].Value);
                                double a = Convert.ToDouble(row.Cells["adgv"].Value);
                                double b = Convert.ToDouble(row.Cells["bdgv"].Value);
                                double iron = Convert.ToDouble(row.Cells["irondgv"].Value);
                                double water = Convert.ToDouble(row.Cells["waterdgv"].Value);
                                double suger = Convert.ToDouble(row.Cells["sugerdgv"].Value);
                                double magnesium = Convert.ToDouble(row.Cells["magnesiumdgv"].Value);
                                double phosphor = Convert.ToDouble(row.Cells["phosphordgv"].Value);
                                int quantity = int.Parse(row.Cells["quantitydgv"].Value.ToString());

                                MainClass.con.Open();
                                using (SqlCommand command = new SqlCommand(
                                    "INSERT INTO MealIngredients (MealID, IngredientAr, IngredientEn, Unit, Calories, Fats, Carbohydrates, Fibers, Protein, Calcium, Sodium, Potassium, Iodine, A, B, Iron, Water, Suger, Magnesium, Phosphor, Quantity) " +
                                    "VALUES (@MealID, @IngredientAr, @IngredientEn, @Unit, @Calories, @Fats, @Carbohydrates, @Fibers, @Protein, @Calcium, @Sodium, @Potassium, @Iodine, @A, @B, @Iron, @Water, @Suger, @Magnesium, @Phosphor, @Quantity)", MainClass.con))
                                {
                                    // Add parameters to the SQL command
                                    command.Parameters.AddWithValue("@MealID", GetLastMeal());
                                    command.Parameters.AddWithValue("@IngredientAr", ingredientAr);
                                    command.Parameters.AddWithValue("@IngredientEn", ingredientEn);
                                    command.Parameters.AddWithValue("@Unit", unit);
                                    command.Parameters.AddWithValue("@Calories", calories);
                                    command.Parameters.AddWithValue("@Fats", fats);
                                    command.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
                                    command.Parameters.AddWithValue("@Fibers", fibers);
                                    command.Parameters.AddWithValue("@Protein", protein);
                                    command.Parameters.AddWithValue("@Calcium", calcium);
                                    command.Parameters.AddWithValue("@Sodium", sodium);
                                    command.Parameters.AddWithValue("@Potassium", potassium);
                                    command.Parameters.AddWithValue("@Iodine", iodine);
                                    command.Parameters.AddWithValue("@A", a);
                                    command.Parameters.AddWithValue("@B", b);
                                    command.Parameters.AddWithValue("@Iron", iron);
                                    command.Parameters.AddWithValue("@Water", water);
                                    command.Parameters.AddWithValue("@Suger", suger);
                                    command.Parameters.AddWithValue("@Magnesium", magnesium);
                                    command.Parameters.AddWithValue("@Phosphor", phosphor);
                                    command.Parameters.AddWithValue("@Quantity", quantity);
                                    // Execute the SQL command
                                    command.ExecuteNonQuery();
                                }
                                MainClass.con.Close();
                            }
                        }
                        guna2DataGridView1.Rows.Clear();
                        tabControl1.SelectedIndex = 0;
                        ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);

                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Meal AR name cannot be empty.");
                }
            }
            else
            {
                if (mealar.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Meal SET MealAr = @MealAr, MealEn = @MealEn, GroupNAr = @GroupNAr, GroupNEn = @GroupNEn, GroupCAr = @GroupCAr, GroupCEn = @GroupCEn, CLASSIFICATION = @CLASSIFICATION, FATS = @FATS, FIBERS = @FIBERS, POTASSIUM = @POTASSIUM, WATER = @WATER, SUGAR = @SUGAR, CALCIUM = @CALCIUM, A = @A, PROTEIN = @PROTEIN, CARBOHYDRATES = @CARBOHYDRATES, SODIUM = @SODIUM, PHOSPHOR = @PHOSPHOR, MAGNESIUM = @MAGNESIUM, IRON = @IRON, IODINE = @IODINE, B = @B, Category = @Category, Notes = @Notes, Preparation = @Preparation WHERE ID = @ID", MainClass.con);

                        cmd.Parameters.AddWithValue("@ID", mealIDToEdit);
                        cmd.Parameters.AddWithValue("@MealAr", mealar.Text);
                        cmd.Parameters.AddWithValue("@MealEn", mealen.Text);
                        cmd.Parameters.AddWithValue("@GroupNAr", groupnar.Text);
                        cmd.Parameters.AddWithValue("@GroupNEn", groupnen.Text);
                        cmd.Parameters.AddWithValue("@GroupCAr", groupcar.Text);
                        cmd.Parameters.AddWithValue("@GroupCEn", groupcen.Text);
                        //cmd.Parameters.AddWithValue("@Category", category.Text);
                        cmd.Parameters.AddWithValue("@CLASSIFICATION", classification.Text);
                        cmd.Parameters.AddWithValue("@CALORIES", Convert.ToDouble(calories.Text));
                        cmd.Parameters.AddWithValue("@FATS", Convert.ToDouble(fats.Text));
                        cmd.Parameters.AddWithValue("@FIBERS", Convert.ToDouble(fibers.Text));
                        cmd.Parameters.AddWithValue("@POTASSIUM", Convert.ToDouble(potassium.Text));
                        cmd.Parameters.AddWithValue("@WATER", Convert.ToDouble(water.Text));
                        cmd.Parameters.AddWithValue("@SUGAR", Convert.ToDouble(sugar.Text));
                        cmd.Parameters.AddWithValue("@CALCIUM", Convert.ToDouble(calcium.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text));
                        cmd.Parameters.AddWithValue("@PROTEIN", Convert.ToDouble(protein.Text));
                        cmd.Parameters.AddWithValue("@CARBOHYDRATES", Convert.ToDouble(carbohydrates.Text));
                        cmd.Parameters.AddWithValue("@SODIUM", Convert.ToDouble(sodium.Text));
                        cmd.Parameters.AddWithValue("@PHOSPHOR", Convert.ToDouble(phosphor.Text));
                        cmd.Parameters.AddWithValue("@MAGNESIUM", Convert.ToDouble(magnesium.Text));
                        cmd.Parameters.AddWithValue("@IRON", Convert.ToDouble(iron.Text));
                        cmd.Parameters.AddWithValue("@IODINE", Convert.ToDouble(iodine.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text));
                        cmd.Parameters.AddWithValue("@Notes", notes.Text);
                        cmd.Parameters.AddWithValue("@Preparation", preparation.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Meal updated successfully");
                        MainClass.con.Close();
                        ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);

                        // Clear the input controls or set them to default values.
                        mealar.Text = "";
                        mealen.Text = "";
                        groupnar.Text = "";
                        groupnen.Text = "";
                        groupcar.Text = "";
                        groupcen.Text = "";
                        classification.SelectedItem = null;
                        //category.SelectedItem = null;
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
                        notes.Text = "";
                        preparation.Text = "";



                    }
                     
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmdingredients = new SqlCommand("DELETE FROM MealIngredients WHERE MealID = @MealID", MainClass.con);
                        cmdingredients.Parameters.AddWithValue("@MealID", mealIDToEdit); // Assuming the Ingredient ID is in the first cell of the selected row.
                        cmdingredients.ExecuteNonQuery();
                        //MessageBox.Show("Meal removed successfully");
                        MainClass.con.Close();
                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            if (!row.IsNewRow) // Skip the last empty row if present.
                            {
                                string ingredientAr = row.Cells["ingredientardgv"].Value.ToString();
                                string ingredientEn = row.Cells["ingredientendgv"].Value.ToString();
                                string unit = row.Cells["unitdgv"].Value.ToString();
                                double calories = Convert.ToDouble(row.Cells["caloriedgv"].Value);
                                double fats = Convert.ToDouble(row.Cells["fatsdgv"].Value);
                                double carbohydrates = Convert.ToDouble(row.Cells["carbohydratesdgv"].Value);
                                double fibers = Convert.ToDouble(row.Cells["fiberdgv"].Value);
                                double protein = Convert.ToDouble(row.Cells["proteindgv"].Value);
                                double calcium = Convert.ToDouble(row.Cells["calciumdgv"].Value);
                                double sodium = Convert.ToDouble(row.Cells["sodiumdgv"].Value);
                                double potassium = Convert.ToDouble(row.Cells["potassiumdgv"].Value);
                                double iodine = Convert.ToDouble(row.Cells["iodinedgv"].Value);
                                double a = Convert.ToDouble(row.Cells["adgv"].Value);
                                double b = Convert.ToDouble(row.Cells["bdgv"].Value);
                                double iron = Convert.ToDouble(row.Cells["irondgv"].Value);
                                double water = Convert.ToDouble(row.Cells["waterdgv"].Value);
                                double suger = Convert.ToDouble(row.Cells["sugerdgv"].Value);
                                double magnesium = Convert.ToDouble(row.Cells["magnesiumdgv"].Value);
                                double phosphor = Convert.ToDouble(row.Cells["phosphordgv"].Value);
                                int quantity = int.Parse(row.Cells["quantitydgv"].Value.ToString());

                                MainClass.con.Open();
                                using (SqlCommand command = new SqlCommand(
                                    "INSERT INTO MealIngredients (MealID, IngredientAr, IngredientEn, Unit, Calories, Fats, Carbohydrates, Fibers, Protein, Calcium, Sodium, Potassium, Iodine, A, B, Iron, Water, Suger, Magnesium, Phosphor, Quantity) " +
                                    "VALUES (@MealID, @IngredientAr, @IngredientEn, @Unit, @Calories, @Fats, @Carbohydrates, @Fibers, @Protein, @Calcium, @Sodium, @Potassium, @Iodine, @A, @B, @Iron, @Water, @Suger, @Magnesium, @Phosphor, @Quantity)", MainClass.con))
                                {
                                    // Add parameters to the SQL command
                                    command.Parameters.AddWithValue("@MealID", mealIDToEdit);
                                    command.Parameters.AddWithValue("@IngredientAr", ingredientAr);
                                    command.Parameters.AddWithValue("@IngredientEn", ingredientEn);
                                    command.Parameters.AddWithValue("@Unit", unit);
                                    command.Parameters.AddWithValue("@Calories", calories);
                                    command.Parameters.AddWithValue("@Fats", fats);
                                    command.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
                                    command.Parameters.AddWithValue("@Fibers", fibers);
                                    command.Parameters.AddWithValue("@Protein", protein);
                                    command.Parameters.AddWithValue("@Calcium", calcium);
                                    command.Parameters.AddWithValue("@Sodium", sodium);
                                    command.Parameters.AddWithValue("@Potassium", potassium);
                                    command.Parameters.AddWithValue("@Iodine", iodine);
                                    command.Parameters.AddWithValue("@A", a);
                                    command.Parameters.AddWithValue("@B", b);
                                    command.Parameters.AddWithValue("@Iron", iron);
                                    command.Parameters.AddWithValue("@Water", water);
                                    command.Parameters.AddWithValue("@Suger", suger);
                                    command.Parameters.AddWithValue("@Magnesium", magnesium);
                                    command.Parameters.AddWithValue("@Phosphor", phosphor);
                                    command.Parameters.AddWithValue("@Quantity", quantity);
                                    // Execute the SQL command
                                    command.ExecuteNonQuery();
                                }
                                MainClass.con.Close();
                            }
                        }
                        guna2DataGridView1.Rows.Clear();

                        guna2DataGridView1.Rows.Clear();
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
                    MessageBox.Show("Meal AR name cannot be empty.");
                }
            }

        }
        private void Ingredienttab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void Backtomeal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
        private void AddIngredient_Click_1(object sender, EventArgs e)
        {

        }
        private void Add_Click(object sender, EventArgs e)
        {
            mealar.Text = "";
            mealen.Text = "";
            groupnar.SelectedItem = null;
            groupnen.SelectedItem = null;
            groupcar.SelectedItem = null;
            groupcen.SelectedItem = null;
            classification.SelectedItem = null;
            //category.SelectedItem = null;
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
            notes.Text = "";
            preparation.Text = "";
            edit = 0;
            guna2DataGridView1.Rows.Clear();
            UpdateGroupsN();
            UpdateGroupsC();
            tabControl1.SelectedIndex = 2;
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2 != null)
            {
                if (guna2DataGridView2.Rows.Count > 0)
                {
                    if (guna2DataGridView2.SelectedRows.Count == 1)
                    {
                        mealar.Text = "";
                        mealen.Text = "";
                        groupnar.Text = "";
                        groupnen.Text = "";
                        groupcar.Text = "";
                        groupcen.Text = "";
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
                        string ingredientIDToDelete = guna2DataGridView2.CurrentRow.Cells[1].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Meal : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            string id = guna2DataGridView2.CurrentRow.Cells[0].Value.ToString();
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Meal WHERE ID = @MealID", MainClass.con);
                                cmd.Parameters.AddWithValue("@MealID", guna2DataGridView2.CurrentRow.Cells[0].Value.ToString()); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                MainClass.con.Open();
                                SqlCommand cmdingredients = new SqlCommand("DELETE FROM MealIngredients WHERE MealID = @MealID", MainClass.con);
                                cmdingredients.Parameters.AddWithValue("@MealID", id); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmdingredients.ExecuteNonQuery();
                                MessageBox.Show("Meal removed successfully");
                                MainClass.con.Close();

                                ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv);
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            try
            {
                mealIDToEdit = guna2DataGridView2.CurrentRow.Cells[0].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Meal WHERE ID = @MealID", MainClass.con);
                cmd.Parameters.AddWithValue("@MealID", mealIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        mealar.Text = reader["MealAr"].ToString();
                        mealen.Text = reader["MealEn"].ToString();
                        groupnar.Text = reader["GroupNAr"].ToString();
                        groupnen.Text = reader["GroupNEn"].ToString();
                        groupcar.Text = reader["GroupCAr"].ToString();
                        groupcen.Text = reader["GroupCEn"].ToString();
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
                        //category.Text = reader["Category"].ToString();
                        notes.Text = reader["Notes"].ToString();
                        preparation.Text = reader["Preparation"].ToString();
                        classification.Text = reader["CLASSIFICATION"].ToString();
                    }
                    reader.Close(); // Close the first DataReader

                    //ShowIngredients(guna2DataGridView1, unitdgv, ingredientardgv, ingredientendgv,quantitydgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv, potassiumdgv, phosphordgv,waterdgv,magnesiumdgv,sugerdgv,irondgv,iodinedgv,adgv,bdgv);
                    MainClass.con.Close();
                    extrafunc();
                    
                    tabControl1.SelectedIndex = 2;
                }
                else
                {
                    MessageBox.Show("Meal not found with ID: " + mealIDToEdit);
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }


        }
        private void Meals_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void search_Click(object sender, EventArgs e)
        {
            SearchMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv);

        }
        private bool simulateDoubleClick = false;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a single click should be treated as a double click
            if (simulateDoubleClick)
            {
                
                simulateDoubleClick = false;
            }
            else
            {
                simulateDoubleClick = true;

                Timer timer = new Timer();
                timer.Interval = SystemInformation.DoubleClickTime; // Use system-defined double-click time
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    simulateDoubleClick = false;
                };
                timer.Start();
            }
        }
        private void guna2DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;

                // Unsubscribe previously subscribed event to avoid adding the handler multiple times
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

                // Subscribe to the SelectedIndexChanged event to detect changes in the ComboBox
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                // Get the row and column index of the changed cell
                int rowIndex = guna2DataGridView1.CurrentCell.RowIndex;
                int columnIndex = guna2DataGridView1.CurrentCell.ColumnIndex;
                if (comboBox.SelectedValue != null)
                {
                    if (comboBox.SelectedValue != null && int.TryParse(comboBox.SelectedValue.ToString(), out int selectedValue))
                    {
                        selectedValue = (int)comboBox.SelectedValue; // Change this to the appropriate data type if needed
                        guna2DataGridView1.Rows.RemoveAt(rowIndex);
                        DataGridViewRow row = new DataGridViewRow();

                        // Create the first DataGridViewComboBoxCell for the first column.
                        DataGridViewComboBoxCell comboCell1 = new DataGridViewComboBoxCell();
                        comboCell1.DataSource = GetIngredients(selectedValue);
                        comboCell1.DisplayMember = "Name";
                        comboCell1.ValueMember = "ID";
                        comboCell1.Value = GetIngredients(selectedValue)[0].ID;

                        DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                        row.Cells.Add(cell1);
                        row.Cells.Add(comboCell1);
                        // Create the second DataGridViewComboBoxCell for the second column.

                        DataGridViewComboBoxCell comboCell2 = new DataGridViewComboBoxCell();
                        comboCell2.DataSource = GetIngredientsEN(selectedValue); // Use different items for the second combo box
                        comboCell2.DisplayMember = "Name";
                        comboCell2.ValueMember = "ID";
                        comboCell2.Value = GetIngredientsEN(selectedValue)[0].ID;

                        // Create a DataGridViewTextBoxCell for the first cell (just an assumption for the text cell).


                        // Add cells to the row

                        row.Cells.Add(comboCell2);

                        // Add the row to the DataGridView.
                        guna2DataGridView1.Rows.Add(row);
                    }
                    else
                    {
                        MessageBox.Show("You are selecting same option again!");
                    }
                }
                // Access the selected value in the ComboBox

                // Do something with the selected value or perform additional actions
                // For instance, you can update other cells in the same row or process the selected value
            }
        }
        private void EditBTN_Click(object sender, EventArgs e)
        {
            UpdateGroupsC();
            UpdateGroupsN();
            edit = 1;
            try
            {
                mealIDToEdit = guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Meal WHERE ID = @MealID", MainClass.con);
                cmd.Parameters.AddWithValue("@MealID", mealIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        mealar.Text = reader["MealAr"].ToString();
                        mealen.Text = reader["MealEn"].ToString();
                        groupnar.Text = reader["GroupNAr"].ToString();
                        groupnen.Text = reader["GroupNEn"].ToString();
                        groupcar.Text = reader["GroupCAr"].ToString();
                        groupcen.Text = reader["GroupCEn"].ToString();
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
                        //category.Text = reader["Category"].ToString();
                        notes.Text = reader["Notes"].ToString();
                        preparation.Text = reader["Preparation"].ToString();
                        classification.Text = reader["CLASSIFICATION"].ToString();
                    }
                    reader.Close(); // Close the first DataReader

                    //ShowIngredients(guna2DataGridView1, unitdgv, ingredientardgv, ingredientendgv,quantitydgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv, potassiumdgv, phosphordgv,waterdgv,magnesiumdgv,sugerdgv,irondgv,iodinedgv,adgv,bdgv);
                    MainClass.con.Close();
                    extrafunc();

                    tabControl1.SelectedIndex = 2;
                }
                else
                {
                    MessageBox.Show("Meal not found with ID: " + mealIDToEdit);
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2 != null)
            {
                if (guna2DataGridView2.Rows.Count > 0)
                {
                    if (guna2DataGridView2.SelectedRows.Count == 1)
                    {
                        mealar.Text = "";
                        mealen.Text = "";
                        groupnar.Text = "";
                        groupnen.Text = "";
                        groupcar.Text = "";
                        groupcen.Text = "";
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
                        string ingredientIDToDelete = guna2DataGridView2.CurrentRow.Cells[1].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Meal : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            string id = guna2DataGridView2.CurrentRow.Cells[0].Value.ToString();
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Meal WHERE ID = @MealID", MainClass.con);
                                cmd.Parameters.AddWithValue("@MealID", guna2DataGridView2.CurrentRow.Cells[0].Value.ToString()); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                MainClass.con.Open();
                                SqlCommand cmdingredients = new SqlCommand("DELETE FROM MealIngredients WHERE MealID = @MealID", MainClass.con);
                                cmdingredients.Parameters.AddWithValue("@MealID", id); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmdingredients.ExecuteNonQuery();
                                MessageBox.Show("Meal removed successfully");
                                MainClass.con.Close();

                                ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv);
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
        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (mealar.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Meal (MealAr, MealEn, GroupNAr, GroupNEn, GroupCAr, GroupCEn, CLASSIFICATION, CALORIES, FATS, FIBERS, POTASSIUM, WATER, SUGAR, CALCIUM, A, PROTEIN, CARBOHYDRATES, SODIUM, PHOSPHOR, MAGNESIUM, IRON, IODINE, B, Notes, Preparation) " +
                            "VALUES (@MealAr, @MealEn, @GroupNAr, @GroupNEn, @GroupCAr, @GroupCEn, @CLASSIFICATION, @CALORIES, @FATS, @FIBERS, @POTASSIUM, @WATER, @SUGAR, @CALCIUM, @A, @PROTEIN, @CARBOHYDRATES, @SODIUM, @PHOSPHOR, @MAGNESIUM, @IRON, @IODINE, @B, @Notes, @Preparation)", MainClass.con);

                        cmd.Parameters.AddWithValue("@MealAr", mealar.Text);
                        cmd.Parameters.AddWithValue("@MealEn", mealen.Text);
                        cmd.Parameters.AddWithValue("@GroupNAr", groupnar.Text);
                        cmd.Parameters.AddWithValue("@GroupNEn", groupnen.Text);
                        cmd.Parameters.AddWithValue("@GroupCAr", groupcar.Text);
                        cmd.Parameters.AddWithValue("@GroupCEn", groupcen.Text);
                        //cmd.Parameters.AddWithValue("@Category", category.Text);
                        cmd.Parameters.AddWithValue("@CLASSIFICATION", classification.Text);
                        cmd.Parameters.AddWithValue("@CALORIES", Convert.ToDouble(calories.Text));
                        cmd.Parameters.AddWithValue("@FATS", Convert.ToDouble(fats.Text));
                        cmd.Parameters.AddWithValue("@FIBERS", Convert.ToDouble(fibers.Text));
                        cmd.Parameters.AddWithValue("@POTASSIUM", Convert.ToDouble(potassium.Text));
                        cmd.Parameters.AddWithValue("@WATER", Convert.ToDouble(water.Text));
                        cmd.Parameters.AddWithValue("@SUGAR", Convert.ToDouble(sugar.Text));
                        cmd.Parameters.AddWithValue("@CALCIUM", Convert.ToDouble(calcium.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text));
                        cmd.Parameters.AddWithValue("@PROTEIN", Convert.ToDouble(protein.Text));
                        cmd.Parameters.AddWithValue("@CARBOHYDRATES", Convert.ToDouble(carbohydrates.Text));
                        cmd.Parameters.AddWithValue("@SODIUM", Convert.ToDouble(sodium.Text));
                        cmd.Parameters.AddWithValue("@PHOSPHOR", Convert.ToDouble(phosphor.Text));
                        cmd.Parameters.AddWithValue("@MAGNESIUM", Convert.ToDouble(magnesium.Text));
                        cmd.Parameters.AddWithValue("@IRON", Convert.ToDouble(iron.Text));
                        cmd.Parameters.AddWithValue("@IODINE", Convert.ToDouble(iodine.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text));
                        cmd.Parameters.AddWithValue("@Notes", notes.Text);
                        cmd.Parameters.AddWithValue("@Preparation", preparation.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Meal added successfully");
                        MainClass.con.Close();

                        mealar.Text = "";
                        mealen.Text = "";
                        groupnar.Text = "";
                        groupnen.Text = "";
                        groupcar.Text = "";
                        groupcen.Text = "";
                        classification.SelectedItem = null;
                        //category.SelectedItem = null;
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
                        notes.Text = "";
                        preparation.Text = "";




                        tabControl1.SelectedIndex = 0;
                        ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            if (!row.IsNewRow) // Skip the last empty row if present.
                            {
                                int ingredientAr = int.Parse(row.Cells["ingredientardgv"].Value.ToString());



                                string ingredientEn = row.Cells["ingredientendgv"].Value.ToString();
                                string unit = row.Cells["unitdgv"].Value.ToString();
                                double calories = Convert.ToDouble(row.Cells["caloriedgv"].Value);
                                double fats = Convert.ToDouble(row.Cells["fatsdgv"].Value);
                                double carbohydrates = Convert.ToDouble(row.Cells["carbohydratesdgv"].Value);
                                double fibers = Convert.ToDouble(row.Cells["fiberdgv"].Value);
                                double protein = Convert.ToDouble(row.Cells["proteindgv"].Value);
                                double calcium = Convert.ToDouble(row.Cells["calciumdgv"].Value);
                                double sodium = Convert.ToDouble(row.Cells["sodiumdgv"].Value);
                                double potassium = Convert.ToDouble(row.Cells["potassiumdgv"].Value);
                                double iodine = Convert.ToDouble(row.Cells["iodinedgv"].Value);
                                double a = Convert.ToDouble(row.Cells["adgv"].Value);
                                double b = Convert.ToDouble(row.Cells["bdgv"].Value);
                                double iron = Convert.ToDouble(row.Cells["irondgv"].Value);
                                double water = Convert.ToDouble(row.Cells["waterdgv"].Value);
                                double suger = Convert.ToDouble(row.Cells["sugerdgv"].Value);
                                double magnesium = Convert.ToDouble(row.Cells["magnesiumdgv"].Value);
                                double phosphor = Convert.ToDouble(row.Cells["phosphordgv"].Value);
                                int quantity = int.Parse(row.Cells["quantitydgv"].Value.ToString());

                                MainClass.con.Open();
                                using (SqlCommand command = new SqlCommand(
                                    "INSERT INTO MealIngredients (MealID, IngredientAr, IngredientEn, Unit, Calories, Fats, Carbohydrates, Fibers, Protein, Calcium, Sodium, Potassium, Iodine, A, B, Iron, Water, Suger, Magnesium, Phosphor, Quantity) " +
                                    "VALUES (@MealID, @IngredientAr, @IngredientEn, @Unit, @Calories, @Fats, @Carbohydrates, @Fibers, @Protein, @Calcium, @Sodium, @Potassium, @Iodine, @A, @B, @Iron, @Water, @Suger, @Magnesium, @Phosphor, @Quantity)", MainClass.con))
                                {
                                    // Add parameters to the SQL command
                                    command.Parameters.AddWithValue("@MealID", GetLastMeal());
                                    command.Parameters.AddWithValue("@IngredientAr", ingredientAr);
                                    command.Parameters.AddWithValue("@IngredientEn", ingredientEn);
                                    command.Parameters.AddWithValue("@Unit", unit);
                                    command.Parameters.AddWithValue("@Calories", calories);
                                    command.Parameters.AddWithValue("@Fats", fats);
                                    command.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
                                    command.Parameters.AddWithValue("@Fibers", fibers);
                                    command.Parameters.AddWithValue("@Protein", protein);
                                    command.Parameters.AddWithValue("@Calcium", calcium);
                                    command.Parameters.AddWithValue("@Sodium", sodium);
                                    command.Parameters.AddWithValue("@Potassium", potassium);
                                    command.Parameters.AddWithValue("@Iodine", iodine);
                                    command.Parameters.AddWithValue("@A", a);
                                    command.Parameters.AddWithValue("@B", b);
                                    command.Parameters.AddWithValue("@Iron", iron);
                                    command.Parameters.AddWithValue("@Water", water);
                                    command.Parameters.AddWithValue("@Suger", suger);
                                    command.Parameters.AddWithValue("@Magnesium", magnesium);
                                    command.Parameters.AddWithValue("@Phosphor", phosphor);
                                    command.Parameters.AddWithValue("@Quantity", quantity);
                                    // Execute the SQL command
                                    command.ExecuteNonQuery();
                                }
                                MainClass.con.Close();
                            }
                        }
                        guna2DataGridView1.Rows.Clear();
                        tabControl1.SelectedIndex = 0;
                        ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);

                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Meal AR name cannot be empty.");
                }
            }
            else
            {
                if (mealar.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Meal SET MealAr = @MealAr, MealEn = @MealEn, GroupNAr = @GroupNAr, GroupNEn = @GroupNEn, GroupCAr = @GroupCAr, GroupCEn = @GroupCEn, CLASSIFICATION = @CLASSIFICATION, CALORIES = @CALORIES, FATS = @FATS, FIBERS = @FIBERS, POTASSIUM = @POTASSIUM, WATER = @WATER, SUGAR = @SUGAR, CALCIUM = @CALCIUM, A = @A, PROTEIN = @PROTEIN, CARBOHYDRATES = @CARBOHYDRATES, SODIUM = @SODIUM, PHOSPHOR = @PHOSPHOR, MAGNESIUM = @MAGNESIUM, IRON = @IRON, IODINE = @IODINE, B = @B, Notes = @Notes, Preparation = @Preparation WHERE ID = @ID", MainClass.con);

                        cmd.Parameters.AddWithValue("@ID", mealIDToEdit);
                        cmd.Parameters.AddWithValue("@MealAr", mealar.Text);
                        cmd.Parameters.AddWithValue("@MealEn", mealen.Text);
                        cmd.Parameters.AddWithValue("@GroupNAr", groupnar.Text);
                        cmd.Parameters.AddWithValue("@GroupNEn", groupnen.Text);
                        cmd.Parameters.AddWithValue("@GroupCAr", groupcar.Text);
                        cmd.Parameters.AddWithValue("@GroupCEn", groupcen.Text);
                        //cmd.Parameters.AddWithValue("@Category", category.Text);
                        cmd.Parameters.AddWithValue("@CLASSIFICATION", classification.Text);
                        cmd.Parameters.AddWithValue("@CALORIES", Convert.ToDouble(calories.Text));
                        cmd.Parameters.AddWithValue("@FATS", Convert.ToDouble(fats.Text));
                        cmd.Parameters.AddWithValue("@FIBERS", Convert.ToDouble(fibers.Text));
                        cmd.Parameters.AddWithValue("@POTASSIUM", Convert.ToDouble(potassium.Text));
                        cmd.Parameters.AddWithValue("@WATER", Convert.ToDouble(water.Text));
                        cmd.Parameters.AddWithValue("@SUGAR", Convert.ToDouble(sugar.Text));
                        cmd.Parameters.AddWithValue("@CALCIUM", Convert.ToDouble(calcium.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(abox.Text));
                        cmd.Parameters.AddWithValue("@PROTEIN", Convert.ToDouble(protein.Text));
                        cmd.Parameters.AddWithValue("@CARBOHYDRATES", Convert.ToDouble(carbohydrates.Text));
                        cmd.Parameters.AddWithValue("@SODIUM", Convert.ToDouble(sodium.Text));
                        cmd.Parameters.AddWithValue("@PHOSPHOR", Convert.ToDouble(phosphor.Text));
                        cmd.Parameters.AddWithValue("@MAGNESIUM", Convert.ToDouble(magnesium.Text));
                        cmd.Parameters.AddWithValue("@IRON", Convert.ToDouble(iron.Text));
                        cmd.Parameters.AddWithValue("@IODINE", Convert.ToDouble(iodine.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bbox.Text));
                        cmd.Parameters.AddWithValue("@Notes", notes.Text);
                        cmd.Parameters.AddWithValue("@Preparation", preparation.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Meal updated successfully");
                        MainClass.con.Close();
                        ShowMeals(guna2DataGridView2, iddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);

                        // Clear the input controls or set them to default values.
                        mealar.Text = "";
                        mealen.Text = "";
                        groupnar.Text = "";
                        groupnen.Text = "";
                        groupcar.Text = "";
                        groupcen.Text = "";
                        classification.SelectedItem = null;
                        //category.SelectedItem = null;
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
                        notes.Text = "";
                        preparation.Text = "";



                    }

                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmdingredients = new SqlCommand("DELETE FROM MealIngredients WHERE MealID = @MealID", MainClass.con);
                        cmdingredients.Parameters.AddWithValue("@MealID", mealIDToEdit); // Assuming the Ingredient ID is in the first cell of the selected row.
                        cmdingredients.ExecuteNonQuery();
                        //MessageBox.Show("Meal removed successfully");
                        MainClass.con.Close();
                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            if (!row.IsNewRow) // Skip the last empty row if present.
                            {
                                string ingredientAr = row.Cells["ingredientardgv"].Value.ToString();
                                string ingredientEn = row.Cells["ingredientendgv"].Value.ToString();
                                string unit = row.Cells["unitdgv"].Value.ToString();
                                double calories = Convert.ToDouble(row.Cells["caloriedgv"].Value);
                                double fats = Convert.ToDouble(row.Cells["fatsdgv"].Value);
                                double carbohydrates = Convert.ToDouble(row.Cells["carbohydratesdgv"].Value);
                                double fibers = Convert.ToDouble(row.Cells["fiberdgv"].Value);
                                double protein = Convert.ToDouble(row.Cells["proteindgv"].Value);
                                double calcium = Convert.ToDouble(row.Cells["calciumdgv"].Value);
                                double sodium = Convert.ToDouble(row.Cells["sodiumdgv"].Value);
                                double potassium = Convert.ToDouble(row.Cells["potassiumdgv"].Value);
                                double iodine = Convert.ToDouble(row.Cells["iodinedgv"].Value);
                                double a = Convert.ToDouble(row.Cells["adgv"].Value);
                                double b = Convert.ToDouble(row.Cells["bdgv"].Value);
                                double iron = Convert.ToDouble(row.Cells["irondgv"].Value);
                                double water = Convert.ToDouble(row.Cells["waterdgv"].Value);
                                double suger = Convert.ToDouble(row.Cells["sugerdgv"].Value);
                                double magnesium = Convert.ToDouble(row.Cells["magnesiumdgv"].Value);
                                double phosphor = Convert.ToDouble(row.Cells["phosphordgv"].Value);
                                int quantity = int.Parse(row.Cells["quantitydgv"].Value.ToString());

                                MainClass.con.Open();
                                using (SqlCommand command = new SqlCommand(
                                    "INSERT INTO MealIngredients (MealID, IngredientAr, IngredientEn, Unit, Calories, Fats, Carbohydrates, Fibers, Protein, Calcium, Sodium, Potassium, Iodine, A, B, Iron, Water, Suger, Magnesium, Phosphor, Quantity) " +
                                    "VALUES (@MealID, @IngredientAr, @IngredientEn, @Unit, @Calories, @Fats, @Carbohydrates, @Fibers, @Protein, @Calcium, @Sodium, @Potassium, @Iodine, @A, @B, @Iron, @Water, @Suger, @Magnesium, @Phosphor, @Quantity)", MainClass.con))
                                {
                                    // Add parameters to the SQL command
                                    command.Parameters.AddWithValue("@MealID", mealIDToEdit);
                                    command.Parameters.AddWithValue("@IngredientAr", ingredientAr);
                                    command.Parameters.AddWithValue("@IngredientEn", ingredientEn);
                                    command.Parameters.AddWithValue("@Unit", unit);
                                    command.Parameters.AddWithValue("@Calories", calories);
                                    command.Parameters.AddWithValue("@Fats", fats);
                                    command.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
                                    command.Parameters.AddWithValue("@Fibers", fibers);
                                    command.Parameters.AddWithValue("@Protein", protein);
                                    command.Parameters.AddWithValue("@Calcium", calcium);
                                    command.Parameters.AddWithValue("@Sodium", sodium);
                                    command.Parameters.AddWithValue("@Potassium", potassium);
                                    command.Parameters.AddWithValue("@Iodine", iodine);
                                    command.Parameters.AddWithValue("@A", a);
                                    command.Parameters.AddWithValue("@B", b);
                                    command.Parameters.AddWithValue("@Iron", iron);
                                    command.Parameters.AddWithValue("@Water", water);
                                    command.Parameters.AddWithValue("@Suger", suger);
                                    command.Parameters.AddWithValue("@Magnesium", magnesium);
                                    command.Parameters.AddWithValue("@Phosphor", phosphor);
                                    command.Parameters.AddWithValue("@Quantity", quantity);
                                    // Execute the SQL command
                                    command.ExecuteNonQuery();
                                }
                                MainClass.con.Close();
                            }
                        }
                        guna2DataGridView1.Rows.Clear();

                        guna2DataGridView1.Rows.Clear();
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
                    MessageBox.Show("Meal AR name cannot be empty.");
                }
            }
        }
        private void SaveGroupn_Click(object sender, EventArgs e)
        {
            if (agnar.Text != "" && agnen.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO GROUPN (Namear, Nameen) " +
                        "VALUES (@Namear, @Nameen)", MainClass.con);

                    cmd.Parameters.AddWithValue("@Namear", agnar.Text);
                    cmd.Parameters.AddWithValue("@Nameen", agnen.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully");
                    MainClass.con.Close();

                    agnar.Text = "";
                    agnen.Text = "";

                    tabControl1.SelectedIndex = 2;
                    UpdateGroupsN();

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill both names!.");
            }
        }
        private void Closebtn_Click(object sender, EventArgs e)
        {
            agnar.Text = "";
            agnen.Text = "";
            tabControl1.SelectedIndex = 2;

        }
        private void agn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }
        private void CLoseDGN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

        }
        private void Deletegn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView3 != null)
            {
                if (guna2DataGridView3.Rows.Count > 0)
                {
                    if (guna2DataGridView3.SelectedRows.Count == 1)
                    {
                       
                        // Get the Ingredient ID to display in the confirmation message
                        string groupid = guna2DataGridView3.SelectedRows[0].Cells[0].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Group N : " + groupid + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM GROUPN WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", groupid); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                //tabControl1.SelectedIndex = 2;
                                ShowGroupN(guna2DataGridView3, idgn, gnnar, gnnen);
                                UpdateGroupsN();

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
        private void dgn_Click(object sender, EventArgs e)
        {
            ShowGroupN(guna2DataGridView3, idgn, gnnar, gnnen);
            tabControl1.SelectedIndex = 3;

        }
        private void agc_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }
        private void savegc_Click(object sender, EventArgs e)
        {
            if (gcnamear.Text != "" && gcnameen.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO GROUPC (Namear, Nameen) " +
                        "VALUES (@Namear, @Nameen)", MainClass.con);

                    cmd.Parameters.AddWithValue("@Namear", gcnamear.Text);
                    cmd.Parameters.AddWithValue("@Nameen", gcnameen.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully");
                    MainClass.con.Close();

                    gcnamear.Text = "";
                    gcnameen.Text = "";

                    tabControl1.SelectedIndex = 2;
                    UpdateGroupsC();

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill both names!");
            }
        }
        private void dgc_Click(object sender, EventArgs e)
        {
            ShowGroupC(guna2DataGridView4, gcid, gcnar, gcnen);
            tabControl1.SelectedIndex = 5;
        }
        private void Deletegc_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView4 != null)
            {
                if (guna2DataGridView4.Rows.Count > 0)
                {
                    if (guna2DataGridView4.SelectedRows.Count == 1)
                    {

                        // Get the Ingredient ID to display in the confirmation message
                        string groupid = guna2DataGridView4.SelectedRows[0].Cells[0].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Group C : " + groupid + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM GROUPC WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", groupid); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                //tabControl1.SelectedIndex = 2;
                                ShowGroupC(guna2DataGridView4, gcid, gcnar, gcnen);
                                UpdateGroupsC();
                                
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
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
      
}
