using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static HelloWorldSolutionIMS.MealAction;

namespace HelloWorldSolutionIMS
{
    public partial class DietPlan : Form
    {
        public DietPlan()
        {
            InitializeComponent();
            //calories.TextChanged += UpdateChart;
            fatsm.TextChanged += UpdateChart;
            proteinm.TextChanged += UpdateChart;
            carbsm.TextChanged += UpdateChart;
        }
        static int coderunner = 0;
        public DietPlan(int id)
        {
            InitializeComponent();
            //calories.TextChanged += UpdateChart;
            fatsm.TextChanged += UpdateChart;
            proteinm.TextChanged += UpdateChart;
            carbsm.TextChanged += UpdateChart;
            coderunner = id;
        }
        private void LoadData(int id)
        {
            if (fileno.Text != "")
            {
                string template = null;
                string PreviousPlan = null;
                try
                {

                    dietPlanIDToEdit = fileno.Text.ToString();
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlan WHERE FILENO = @DietPlanID", MainClass.con);
                    cmd.Parameters.AddWithValue("@DietPlanID", dietPlanIDToEdit);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {


                            template = reader["DietPlanTemplateName"].ToString();
                            dietplantemplate.Text = reader["DietPlanTemplate"].ToString();
                            DietPlanDate.Value = Convert.ToDateTime(reader["DIETPLANDATE"]);
                            dietplandays.Text = reader["DietPlanDays"].ToString();
                            instruction.Text = reader["Instructions"].ToString();
                            PreviousPlan = reader["PreviousDiePlan"].ToString();
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
                        dietplantemplatename.Text = template;
                        previousdietplan.Text = PreviousPlan;
                        extrafunc();
                        save.Enabled = false;
                        AddMealrow.Enabled = false;
                        AddLunch.Enabled = false;
                        DinnerAdd.Enabled = false;
                        SnackAdd.Enabled = false;
                        //tabControl1.SelectedIndex = 1;
                    }
                    else
                    {
                        reader.Close();
                        MainClass.con.Close();
                        save.Enabled = true;
                        AddMealrow.Enabled = true;
                        AddLunch.Enabled = true;
                        DinnerAdd.Enabled = true;
                        SnackAdd.Enabled = true;
                        RowsFiller();
                        //MessageBox.Show("No Diet Plan found for file no :" + fileno.Text);
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
                save.Enabled = true;
                AddMealrow.Enabled = true;
                AddLunch.Enabled = true;
                DinnerAdd.Enabled = true;
                SnackAdd.Enabled = true;
                MessageBox.Show("Enter File no!");
            }
            edit = 0;

        }
        private void RowsFiller()
        {
            for (int a = 0; a < 3; a++)
            {
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
            for (int b = 0; b < 3; b++)
            {
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



                for (int i = 1; i < guna2DataGridView4.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView4.Columns[i];

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

                guna2DataGridView4.Rows.Add(row);
            }
            for (int c = 0; c < 3; c++)
            {
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



                for (int i = 1; i < guna2DataGridView5.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView5.Columns[i];

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

                guna2DataGridView5.Rows.Add(row);
            }
            for (int d = 0; d < 3; d++)
            {
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



                for (int i = 1; i < guna2DataGridView6.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView6.Columns[i];

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

                guna2DataGridView6.Rows.Add(row);
            }
        }
        private void RowsChecker()
        {
            int countbf = guna2DataGridView2.RowCount;
            int countl = guna2DataGridView4.RowCount;
            int countd = guna2DataGridView5.RowCount;
            int counts = guna2DataGridView6.RowCount;

            for (int a = countbf; a < 3; a++)
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
            for (int b = countl; b < 3; b++)
            {
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



                for (int i = 1; i < guna2DataGridView4.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView4.Columns[i];

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

                guna2DataGridView4.Rows.Add(row);
            }
            for (int c = countd; c < 3; c++)
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



                for (int i = 1; i < guna2DataGridView5.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView5.Columns[i];

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

                guna2DataGridView5.Rows.Add(row);
            }
            for (int d = counts; d < 3; d++)
            {
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



                for (int i = 1; i < guna2DataGridView6.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView6.Columns[i];

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

                guna2DataGridView6.Rows.Add(row);
            }
        }
        static int removeflag = 0;
        static int edit = 0;
        static int titlecheck = 0;
        static int chartfiller = 0;
        static string dietPlanIDToEdit;
        static int counter = 0;
        static int connectionflag = 0;

        ArtificialMapping EditMap1 = new ArtificialMapping();
        ArtificialMapping EditMap2 = new ArtificialMapping();
        ArtificialMapping EditMap3 = new ArtificialMapping();
        ArtificialMapping EditMap4 = new ArtificialMapping();
        ArtificialMapping EditMap5 = new ArtificialMapping();
        ArtificialMapping EditMap6 = new ArtificialMapping();
        ArtificialMapping EditMap7 = new ArtificialMapping();

        ArtificialMapping EditMap8 = new ArtificialMapping();
        ArtificialMapping EditMap9 = new ArtificialMapping();
        ArtificialMapping EditMap10 = new ArtificialMapping();
        ArtificialMapping EditMap11 = new ArtificialMapping();
        ArtificialMapping EditMap12 = new ArtificialMapping();
        ArtificialMapping EditMap13 = new ArtificialMapping();
        ArtificialMapping EditMap14 = new ArtificialMapping();

        ArtificialMapping EditMap15 = new ArtificialMapping();
        ArtificialMapping EditMap16 = new ArtificialMapping();
        ArtificialMapping EditMap17 = new ArtificialMapping();
        ArtificialMapping EditMap18 = new ArtificialMapping();
        ArtificialMapping EditMap19 = new ArtificialMapping();
        ArtificialMapping EditMap20 = new ArtificialMapping();
        ArtificialMapping EditMap21 = new ArtificialMapping();

        ArtificialMapping EditMap22 = new ArtificialMapping();
        ArtificialMapping EditMap23 = new ArtificialMapping();
        ArtificialMapping EditMap24 = new ArtificialMapping();
        ArtificialMapping EditMap25 = new ArtificialMapping();
        ArtificialMapping EditMap26 = new ArtificialMapping();
        ArtificialMapping EditMap27 = new ArtificialMapping();
        ArtificialMapping EditMap28 = new ArtificialMapping();

        public class Instruction
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }
        public class DietTemplates
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }
        public class MealsDropdown
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        List<MealsDropdown> Mealslist = new List<MealsDropdown>();
        List<int> idlist = new List<int>();
        private void updatepreviousdietplan()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, DIETPLANTEMPLATENAME FROM DIETPLANTEMPLATE", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Clear the dropdown items before adding new ones

                previousdietplan.DataSource = null;
                // Clear the items (if DataSource is not being set)

                previousdietplan.Items.Clear();
                List<DietTemplates> Template = new List<DietTemplates>();

                // Add the default 'Null' option
                Template.Add(new DietTemplates { ID = 0, Name = "Null" });

                foreach (DataRow row in dt.Rows)
                {
                    int promotionId = row.Field<int>("ID");
                    string promotionName = row.Field<string>("DIETPLANTEMPLATENAME");

                    DietTemplates Temp = new DietTemplates { ID = promotionId, Name = promotionName };
                    Template.Add(Temp);
                }


                previousdietplan.DataSource = Template;
                previousdietplan.DisplayMember = "Name"; // Display Member is Name
                previousdietplan.ValueMember = "ID"; // Value Member is ID

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
        private void UpdateDietPlanTemplate()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, DIETPLANTEMPLATENAME FROM DIETPLANTEMPLATE", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Clear the dropdown items before adding new ones
                dietplantemplatename.DataSource = null;
                // Clear the items (if DataSource is not being set)
                dietplantemplatename.Items.Clear();
                List<DietTemplates> Template = new List<DietTemplates>();

                // Add the default 'Null' option
                Template.Add(new DietTemplates { ID = 0, Name = "Null" });

                foreach (DataRow row in dt.Rows)
                {
                    int promotionId = row.Field<int>("ID");
                    string promotionName = row.Field<string>("DIETPLANTEMPLATENAME");

                    DietTemplates Temp = new DietTemplates { ID = promotionId, Name = promotionName };
                    Template.Add(Temp);
                }

                dietplantemplatename.DataSource = Template;
                dietplantemplatename.DisplayMember = "Name"; // Display Member is Name
                dietplantemplatename.ValueMember = "ID"; // Value Member is ID


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
        private void UpdateInstruction()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, InstructionName FROM INSTRUCTION", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Clear the dropdown items before adding new ones
                instruction.DataSource = null;
                // Clear the items (if DataSource is not being set)
                instruction.Items.Clear();
                List<Instruction> Template = new List<Instruction>();

                // Add the default 'Null' option
                Template.Add(new Instruction { ID = 0, Name = "Null" });

                foreach (DataRow row in dt.Rows)
                {
                    int promotionId = row.Field<int>("ID");
                    string promotionName = row.Field<string>("InstructionName");

                    Instruction Temp = new Instruction { ID = promotionId, Name = promotionName };
                    Template.Add(Temp);
                }

                instruction.DataSource = Template;
                instruction.DisplayMember = "Name"; // Display Member is Name
                instruction.ValueMember = "ID"; // Value Member is ID


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
        private void extrafunc()
        {
            List<int> breakfastitemids = GetMealsForDietPlanBreakfast();
            List<int> lunchtitemids = GetMealsForDietPlanLunch();
            List<int> dinnertitemids = GetMealsForDietPlanDinner();
            List<int> snacktitemids = GetMealsForDietPlanSnack();

            guna2DataGridView2.Rows.Clear();
            guna2DataGridView4.Rows.Clear();
            guna2DataGridView5.Rows.Clear();
            guna2DataGridView6.Rows.Clear();

            MainClass.con.Open();
            for (int i = 0; i < breakfastitemids.Count; i++)
            {

                string query = "SELECT category, one, two, three, Four, Five, Six, Seven FROM DietPlanAction WHERE ID = @DietPlanID AND Category = 'Breakfast'";

                SqlCommand cmd2 = new SqlCommand(query, MainClass.con);

                cmd2.Parameters.AddWithValue("@DietPlanID", breakfastitemids[i]);

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
                    if (one != "")
                    {
                        EditMap1.Row = i;

                        EditMap1.ChartName = "guna2DataGridView2";
                        EditMap1.Col = 2;
                        EditMap1.ID = int.Parse(one);

                        Mapping.Add(EditMap1);
                    }

                    if (two != "")
                    {
                        EditMap2.Row = i;

                        EditMap2.ChartName = "guna2DataGridView2";
                        EditMap2.Col = 3;
                        EditMap2.ID = int.Parse(two);
                        Mapping.Add(EditMap2);
                    }

                    if (three != "")
                    {
                        EditMap3.Row = i;

                        EditMap3.ChartName = "guna2DataGridView2";
                        EditMap3.Col = 4;

                        EditMap3.ID = int.Parse(three);
                        Mapping.Add(EditMap3);
                    }

                    if (Four != "")
                    {
                        EditMap4.Row = i;

                        EditMap4.ChartName = "guna2DataGridView2";
                        EditMap4.Col = 5;

                        EditMap4.ID = int.Parse(Four);
                        Mapping.Add(EditMap4);
                    }

                    if (Five != "")
                    {
                        EditMap5.Row = i;

                        EditMap5.ChartName = "guna2DataGridView2";
                        EditMap5.Col = 6;

                        EditMap5.ID = int.Parse(Five);
                        Mapping.Add(EditMap5);

                    }

                    if (Six != "")
                    {
                        EditMap6.Row = i;

                        EditMap6.ChartName = "guna2DataGridView2";
                        EditMap6.Col = 7;

                        EditMap6.ID = int.Parse(Six);
                        Mapping.Add(EditMap6);
                    }

                    if (Seven != "")
                    {
                        EditMap7.Row = i;
                        EditMap7.ChartName = "guna2DataGridView2";
                        EditMap7.Col = 8;

                        EditMap7.ID = int.Parse(Seven);
                        Mapping.Add(EditMap7);
                    }

                    AddDifferentColumnsToRowBreakfast(row, one, two, three, Four, Five, Six, Seven, i);

                }




            }
            for (int i = 0; i < lunchtitemids.Count; i++)
            {

                string query = "SELECT category, one, two, three, Four, Five, Six, Seven FROM DietPlanAction WHERE ID = @DietPlanID AND Category = 'Lunch'";

                SqlCommand cmd2 = new SqlCommand(query, MainClass.con);

                cmd2.Parameters.AddWithValue("@DietPlanID", lunchtitemids[i]);

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
                    guna2DataGridView4.Rows.Add(row);

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
                    guna2DataGridView4.Rows[i].Cells[1] = comboCellCategory;
                    if (one != "")
                    {
                        EditMap8.Row = i;

                        EditMap8.ChartName = "guna2DataGridView4";
                        EditMap8.Col = 2;

                        EditMap8.ID = int.Parse(one);
                        Mapping.Add(EditMap8);
                    }

                    if (two != "")
                    {
                        EditMap9.Row = i;

                        EditMap9.ChartName = "guna2DataGridView4";
                        EditMap9.Col = 3;

                        EditMap9.ID = int.Parse(two);
                        Mapping.Add(EditMap9);
                    }

                    if (three != "")
                    {
                        EditMap10.Row = i;

                        EditMap10.ChartName = "guna2DataGridView4";
                        EditMap10.Col = 4;

                        EditMap10.ID = int.Parse(three);
                        Mapping.Add(EditMap10);
                    }

                    if (Four != "")
                    {
                        EditMap11.Row = i;

                        EditMap11.ChartName = "guna2DataGridView4";
                        EditMap11.Col = 5;

                        EditMap11.ID = int.Parse(Four);
                        Mapping.Add(EditMap11);
                    }

                    if (Five != "")
                    {
                        EditMap12.Row = i;

                        EditMap12.ChartName = "guna2DataGridView4";
                        EditMap12.Col = 6;

                        EditMap12.ID = int.Parse(Five);
                        Mapping.Add(EditMap12);
                    }

                    if (Six != "")
                    {
                        EditMap13.Row = i;

                        EditMap13.ChartName = "guna2DataGridView4";
                        EditMap13.Col = 7;

                        EditMap13.ID = int.Parse(Six);
                        Mapping.Add(EditMap13);
                    }

                    if (Seven != "")
                    {
                        EditMap14.Row = i;
                        EditMap14.ChartName = "guna2DataGridView4";
                        EditMap14.Col = 8;

                        EditMap14.ID = int.Parse(Seven);
                        Mapping.Add(EditMap14);
                    }

                    // Decide and add different columns based on your conditions for each cell
                    AddDifferentColumnsToRowLunch(row, one, two, three, Four, Five, Six, Seven, i);

                }




            }
            for (int i = 0; i < dinnertitemids.Count; i++)
            {


                string query = "SELECT category, one, two, three, Four, Five, Six, Seven FROM DietPlanAction WHERE ID = @DietPlanID AND Category = 'Dinner'";

                SqlCommand cmd2 = new SqlCommand(query, MainClass.con);

                cmd2.Parameters.AddWithValue("@DietPlanID", dinnertitemids[i]);

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
                    guna2DataGridView5.Rows.Add(row);

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
                    guna2DataGridView5.Rows[i].Cells[1] = comboCellCategory;
                    if (one != "")
                    {
                        EditMap15.Row = i;

                        EditMap15.ChartName = "guna2DataGridView5";
                        EditMap15.Col = 2;

                        EditMap15.ID = int.Parse(one);
                        Mapping.Add(EditMap15);
                    }

                    if (two != "")
                    {
                        EditMap16.Row = i;

                        EditMap16.ChartName = "guna2DataGridView5";
                        EditMap16.Col = 3;

                        EditMap16.ID = int.Parse(two);
                        Mapping.Add(EditMap16);
                    }

                    if (three != "")
                    {
                        EditMap17.Row = i;

                        EditMap17.ChartName = "guna2DataGridView5";
                        EditMap17.Col = 4;

                        EditMap17.ID = int.Parse(three);
                        Mapping.Add(EditMap17);
                    }

                    if (Four != "")
                    {
                        EditMap18.Row = i;

                        EditMap18.ChartName = "guna2DataGridView5";
                        EditMap18.Col = 5;

                        EditMap18.ID = int.Parse(Four);
                        Mapping.Add(EditMap18);
                    }

                    if (Five != "")
                    {
                        EditMap19.Row = i;

                        EditMap19.ChartName = "guna2DataGridView5";
                        EditMap19.Col = 6;

                        EditMap19.ID = int.Parse(Five);
                        Mapping.Add(EditMap19);
                    }

                    if (Six != "")
                    {
                        EditMap20.Row = i;

                        EditMap20.ChartName = "guna2DataGridView5";
                        EditMap20.Col = 7;

                        EditMap20.ID = int.Parse(Six);
                        Mapping.Add(EditMap20);
                    }

                    if (Seven != "")
                    {
                        EditMap21.Row = i;
                        EditMap21.ChartName = "guna2DataGridView5";
                        EditMap21.Col = 8;

                        EditMap21.ID = int.Parse(Seven);
                        Mapping.Add(EditMap21);
                    }

                    // Decide and add different columns based on your conditions for each cell
                    AddDifferentColumnsToRowDinner(row, one, two, three, Four, Five, Six, Seven, i);

                }




            }
            for (int i = 0; i < snacktitemids.Count; i++)
            {


                string query = "SELECT category, one, two, three, Four, Five, Six, Seven FROM DietPlanAction WHERE ID = @DietPlanID AND Category = 'Snack'";

                SqlCommand cmd2 = new SqlCommand(query, MainClass.con);

                cmd2.Parameters.AddWithValue("@DietPlanID", snacktitemids[i]);

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
                    guna2DataGridView6.Rows.Add(row);

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
                    guna2DataGridView6.Rows[i].Cells[1] = comboCellCategory;
                    if (one != "")
                    {
                        EditMap22.Row = i;

                        EditMap22.ChartName = "guna2DataGridView6";

                        EditMap22.Col = 2;

                        EditMap22.ID = int.Parse(one);
                        Mapping.Add(EditMap22);
                    }

                    if (two != "")
                    {
                        EditMap23.Row = i;

                        EditMap23.ChartName = "guna2DataGridView6";

                        EditMap23.Col = 3;

                        EditMap23.ID = int.Parse(two);
                        Mapping.Add(EditMap23);
                    }

                    if (three != "")
                    {

                        EditMap24.Row = i;


                        EditMap24.ChartName = "guna2DataGridView6";

                        EditMap24.Col = 4;

                        EditMap24.ID = int.Parse(three);
                        Mapping.Add(EditMap24);
                    }

                    if (Four != "")
                    {
                        EditMap25.Row = i;


                        EditMap25.ChartName = "guna2DataGridView6";

                        EditMap25.Col = 5;

                        EditMap25.ID = int.Parse(Four);
                        Mapping.Add(EditMap25);

                    }

                    if (Five != "")
                    {
                        EditMap26.Row = i;

                        EditMap26.ChartName = "guna2DataGridView6";

                        EditMap26.Col = 6;

                        EditMap26.ID = int.Parse(Five);
                        Mapping.Add(EditMap26);
                    }

                    if (Six != "")
                    {
                        EditMap27.Row = i;

                        EditMap27.ChartName = "guna2DataGridView6";

                        EditMap27.Col = 7;

                        EditMap27.ID = int.Parse(Six);
                        Mapping.Add(EditMap27);
                    }

                    if (Seven != "")
                    {
                        EditMap28.Row = i;
                        EditMap28.ChartName = "guna2DataGridView6";
                        EditMap28.Col = 8;

                        EditMap28.ID = int.Parse(Seven);
                        Mapping.Add(EditMap28);
                    }

                    // Decide and add different columns based on your conditions for each cell
                    AddDifferentColumnsToRowSnack(row, one, two, three, Four, Five, Six, Seven, i);

                }




            }

            MainClass.con.Close();

            RowsChecker();
        }
        private void AddDifferentColumnsToRowBreakfast(DataGridViewRow row, string one, string two, string three, string Four, string Five, string Six, string Seven, int i)
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
        private void AddDifferentColumnsToRowLunch(DataGridViewRow row, string one, string two, string three, string Four, string Five, string Six, string Seven, int i)
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
                guna2DataGridView4.Rows[i].Cells[2] = comboCell;

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
                guna2DataGridView4.Rows[i].Cells[2] = comboCell;
            }

            if (!string.IsNullOrEmpty(two))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(two)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(two))[0].ID;
                guna2DataGridView4.Rows[i].Cells[3] = comboCell;

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
                guna2DataGridView4.Rows[i].Cells[3] = comboCell;
            }

            if (!string.IsNullOrEmpty(three))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(three)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(three))[0].ID;
                guna2DataGridView4.Rows[i].Cells[4] = comboCell;

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
                guna2DataGridView4.Rows[i].Cells[4] = comboCell;
            }

            if (!string.IsNullOrEmpty(Four))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Four)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Four))[0].ID;
                guna2DataGridView4.Rows[i].Cells[5] = comboCell;

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
                guna2DataGridView4.Rows[i].Cells[5] = comboCell;
            }

            if (!string.IsNullOrEmpty(Five))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Five)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Five))[0].ID;
                guna2DataGridView4.Rows[i].Cells[6] = comboCell;

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
                guna2DataGridView4.Rows[i].Cells[6] = comboCell;
            }

            if (!string.IsNullOrEmpty(Six))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Six)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Six))[0].ID;
                guna2DataGridView4.Rows[i].Cells[7] = comboCell;

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
                guna2DataGridView4.Rows[i].Cells[7] = comboCell;
            }

            if (!string.IsNullOrEmpty(Seven))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Seven)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Seven))[0].ID;
                guna2DataGridView4.Rows[i].Cells[8] = comboCell;

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
                guna2DataGridView4.Rows[i].Cells[8] = comboCell;
            }

            //guna2DataGridView4.Rows.Add(row);
            // You can add other cells based on the other parameters (two, three, Four, Five, Six, Seven) in a similar fashion.
        }
        private void AddDifferentColumnsToRowDinner(DataGridViewRow row, string one, string two, string three, string Four, string Five, string Six, string Seven, int i)
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
                guna2DataGridView5.Rows[i].Cells[2] = comboCell;

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
                guna2DataGridView5.Rows[i].Cells[2] = comboCell;
            }

            if (!string.IsNullOrEmpty(two))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(two)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(two))[0].ID;
                guna2DataGridView5.Rows[i].Cells[3] = comboCell;

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
                guna2DataGridView5.Rows[i].Cells[3] = comboCell;
            }

            if (!string.IsNullOrEmpty(three))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(three)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(three))[0].ID;
                guna2DataGridView5.Rows[i].Cells[4] = comboCell;

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
                guna2DataGridView5.Rows[i].Cells[4] = comboCell;
            }

            if (!string.IsNullOrEmpty(Four))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Four)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Four))[0].ID;
                guna2DataGridView5.Rows[i].Cells[5] = comboCell;

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
                guna2DataGridView5.Rows[i].Cells[5] = comboCell;
            }

            if (!string.IsNullOrEmpty(Five))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Five)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Five))[0].ID;
                guna2DataGridView5.Rows[i].Cells[6] = comboCell;

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
                guna2DataGridView5.Rows[i].Cells[6] = comboCell;
            }

            if (!string.IsNullOrEmpty(Six))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Six)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Six))[0].ID;
                guna2DataGridView5.Rows[i].Cells[7] = comboCell;

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
                guna2DataGridView5.Rows[i].Cells[7] = comboCell;
            }

            if (!string.IsNullOrEmpty(Seven))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Seven)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Seven))[0].ID;
                guna2DataGridView5.Rows[i].Cells[8] = comboCell;

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
                guna2DataGridView5.Rows[i].Cells[8] = comboCell;
            }

            //guna2DataGridView5.Rows.Add(row);
            // You can add other cells based on the other parameters (two, three, Four, Five, Six, Seven) in a similar fashion.
        }
        private void AddDifferentColumnsToRowSnack(DataGridViewRow row, string one, string two, string three, string Four, string Five, string Six, string Seven, int i)
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
                guna2DataGridView6.Rows[i].Cells[2] = comboCell;

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
                guna2DataGridView6.Rows[i].Cells[2] = comboCell;
            }

            if (!string.IsNullOrEmpty(two))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(two)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(two))[0].ID;
                guna2DataGridView6.Rows[i].Cells[3] = comboCell;

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
                guna2DataGridView6.Rows[i].Cells[3] = comboCell;
            }

            if (!string.IsNullOrEmpty(three))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(three)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(three))[0].ID;
                guna2DataGridView6.Rows[i].Cells[4] = comboCell;

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
                guna2DataGridView6.Rows[i].Cells[4] = comboCell;
            }

            if (!string.IsNullOrEmpty(Four))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Four)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Four))[0].ID;
                guna2DataGridView6.Rows[i].Cells[5] = comboCell;

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
                guna2DataGridView6.Rows[i].Cells[5] = comboCell;
            }

            if (!string.IsNullOrEmpty(Five))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Five)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Five))[0].ID;
                guna2DataGridView6.Rows[i].Cells[6] = comboCell;

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
                guna2DataGridView6.Rows[i].Cells[6] = comboCell;
            }

            if (!string.IsNullOrEmpty(Six))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Six)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Six))[0].ID;
                guna2DataGridView6.Rows[i].Cells[7] = comboCell;

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
                guna2DataGridView6.Rows[i].Cells[7] = comboCell;
            }

            if (!string.IsNullOrEmpty(Seven))
            {
                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                comboCell.Items.Clear();
                comboCell.DataSource = GetMeals(int.Parse(Seven)); // Replace with your specific field
                comboCell.DisplayMember = "Name";
                comboCell.ValueMember = "ID";
                comboCell.Value = GetMeals(int.Parse(Seven))[0].ID;
                guna2DataGridView6.Rows[i].Cells[8] = comboCell;

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
                guna2DataGridView6.Rows[i].Cells[8] = comboCell;
            }

            //guna2DataGridView6.Rows.Add(row);
            // You can add other cells based on the other parameters (two, three, Four, Five, Six, Seven) in a similar fashion.
        }

        private List<int> GetMealsForDietPlanBreakfast()
        {
            List<int> idlist = new List<int>();

            try
            {

                MainClass.con.Open();
                SqlCommand cmdthree = new SqlCommand("SELECT ID FROM DietPlanAction WHERE DietPlanID = @Mealid AND Category = 'Breakfast'", MainClass.con);
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
        private List<int> GetMealsForDietPlanLunch()
        {
            List<int> idlist = new List<int>();

            try
            {

                MainClass.con.Open();
                SqlCommand cmdthree = new SqlCommand("SELECT ID FROM DietPlanAction WHERE DietPlanID = @Mealid AND Category = 'Lunch'", MainClass.con);
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
        private List<int> GetMealsForDietPlanDinner()
        {
            List<int> idlist = new List<int>();

            try
            {

                MainClass.con.Open();
                SqlCommand cmdthree = new SqlCommand("SELECT ID FROM DietPlanAction WHERE DietPlanID = @Mealid AND Category = 'Dinner'", MainClass.con);
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
        private List<int> GetMealsForDietPlanSnack()
        {
            List<int> idlist = new List<int>();

            try
            {

                MainClass.con.Open();
                SqlCommand cmdthree = new SqlCommand("SELECT ID FROM DietPlanAction WHERE DietPlanID = @Mealid AND Category = 'Snack'", MainClass.con);
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
            if (fatsm.Text != "" && double.TryParse(fatsm.Text, out double fatsValue))
            {
                dt.Rows.Add("Fats", fatsValue * 9);
            }

            if (proteinm.Text != "" && double.TryParse(proteinm.Text, out double proteinValue))
            {
                dt.Rows.Add("Protein", proteinValue * 4);
            }

            if (carbsm.Text != "" && double.TryParse(carbsm.Text, out double carbsValue))
            {
                dt.Rows.Add("Carbohydrates", carbsValue * 4);
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
        //private void ShowDietPlans(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn name, DataGridViewColumn age, DataGridViewColumn dietname)
        //{
        //    SqlCommand cmd;
        //    try
        //    {
        //        MainClass.con.Open();

        //        cmd = new SqlCommand("SELECT FILENO, FIRSTNAME, AGE,DIETPLANTEMPLATENAME  FROM DietPlan", MainClass.con);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        no.DataPropertyName = dt.Columns["FILENO"].ToString();
        //        name.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
        //        age.DataPropertyName = dt.Columns["AGE"].ToString();
        //        dietname.DataPropertyName = dt.Columns["DIETPLANTEMPLATENAME"].ToString();


        //        dgv.DataSource = dt;
        //        MainClass.con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MainClass.con.Close();
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void SearchDietPlans(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn name, DataGridViewColumn age, DataGridViewColumn dietname)
        //{
        //    string firstname = firstnamesearch.Text;
        //    string dietplan = dietplannamesearch.Text;

        //    if (firstname != "" && dietplan != "")
        //    {
        //        try
        //        {
        //            MainClass.con.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT FILENO, FIRSTNAME,AGE, DIETPLANTEMPLATENAME FROM DietPlan " +
        //                " WHERE (FIRSTNAME LIKE @firstname) AND (DIETPLANTEMPLATENAME LIKE @dietplan)", MainClass.con);

        //            cmd.Parameters.AddWithValue("@firstname", "%" + firstname + "%");
        //            cmd.Parameters.AddWithValue("@dietplan", "%" + dietplan + "%");

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            // Modify the column names to match your data grid view
        //            no.DataPropertyName = dt.Columns["FILENO"].ToString();
        //            name.DataPropertyName =  dt.Columns["FIRSTNAME"].ToString();
        //            age.DataPropertyName = dt.Columns["AGE"].ToString();
        //            dietname.DataPropertyName = dt.Columns["DIETPLANTEMPLATENAME"].ToString();


        //            dgv.DataSource = dt;
        //            MainClass.con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MainClass.con.Close();
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else if (firstname == "" && dietplan != "")
        //    {
        //        try
        //        {
        //            MainClass.con.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT FILENO, FIRSTNAME,AGE, DIETPLANTEMPLATENAME FROM DietPlan " +
        //                " WHERE DIETPLANTEMPLATENAME LIKE @dietplan", MainClass.con);

        //            cmd.Parameters.AddWithValue("@dietplan", "%" + dietplan + "%");

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            // Modify the column names to match your data grid view
        //            no.DataPropertyName = dt.Columns["FILENO"].ToString();
        //            name.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
        //            age.DataPropertyName = dt.Columns["AGE"].ToString();
        //            dietname.DataPropertyName = dt.Columns["DIETPLANTEMPLATENAME"].ToString();



        //            dgv.DataSource = dt;
        //            MainClass.con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MainClass.con.Close();
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else if (firstname != "" && dietplan == "")
        //    {
        //        try
        //        {
        //            MainClass.con.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT FILENO, FIRSTNAME,AGE, DIETPLANTEMPLATENAME FROM DietPlan " +
        //                " WHERE FIRSTNAME LIKE @firstname", MainClass.con);

        //            cmd.Parameters.AddWithValue("@firstname", "%" + firstname + "%");

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            // Modify the column names to match your data grid view
        //            no.DataPropertyName = dt.Columns["FILENO"].ToString();
        //            name.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
        //            age.DataPropertyName = dt.Columns["AGE"].ToString();
        //            dietname.DataPropertyName = dt.Columns["DIETPLANTEMPLATENAME"].ToString();


        //            dgv.DataSource = dt;
        //            MainClass.con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MainClass.con.Close();
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Fill First Name or Diet Plan name");
        //        //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);

        //    }
        //}
        private void Backtomeal_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedIndex = 1;
        }
        private void Meals_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedIndex = 0;
        }
        private void Ingredienttab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
        private void Add_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 1;
            firstname.Text = "";
            familyname.Text = "";
            dietplantemplatename.Text = "";
            dietplantemplate.SelectedItem = null;
            dietplandays.Text = "";
            instruction.Text = "";
            gender.Text = "";
            age.Text = "";
            mobileno.Text = "";
            previousdietplan.Text = "";
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
            MedicalHistory.Text = "";
            edit = 0;
            UpdateDietPlanTemplate();
            updatepreviousdietplan();
            UpdateInstruction();
        }
        private void DietPlan_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Red, Green, Blue FROM textcolor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    int red = Convert.ToInt32(reader["Red"]);
                    int green = Convert.ToInt32(reader["Green"]);
                    int blue = Convert.ToInt32(reader["Blue"]);

                    // Create Color object from the read components
                    Color color = Color.FromArgb(red, green, blue);

                    foreach (System.Windows.Forms.Control control in panel2.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel3.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel9.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel10.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                }

                reader.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);

            }

            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Red, Green, Blue FROM buttoncolor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    int red = Convert.ToInt32(reader["Red"]);
                    int green = Convert.ToInt32(reader["Green"]);
                    int blue = Convert.ToInt32(reader["Blue"]);

                    // Create Color object from the read components
                    Color color = Color.FromArgb(red, green, blue);

                    foreach (System.Windows.Forms.Control control in panel3.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel2.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel9.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel10.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }

                }

                reader.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);

            }

            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Text", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    string bold = reader["Bold"].ToString();
                    string italic = reader["italic"].ToString();
                    string underline = reader["underline"].ToString();
                    string size = reader["size"].ToString();
                    FontStyle fontStyle = FontStyle.Regular;

                    if (bold.ToLower() == "on")
                    {
                        fontStyle |= FontStyle.Bold;
                    }

                    if (italic.ToLower() == "on")
                    {
                        fontStyle |= FontStyle.Italic;
                    }

                    if (underline.ToLower() == "on")
                    {
                        fontStyle |= FontStyle.Underline;
                    }

                    int fontSize = int.Parse(size);

                    foreach (System.Windows.Forms.Control control in panel3.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel2.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel9.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel10.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }




                }

                reader.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);

            }
            //chart1.Series.Clear();
            MainClass.HideAllTabsOnTabControl(tabControl1);
            //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
            //guna2DataGridView2.EditingControlShowing += guna2DataGridView2_EditingControlShowing;
            //guna2DataGridView4.EditingControlShowing += guna2DataGridView4_EditingControlShowing;
            //guna2DataGridView5.EditingControlShowing += guna2DataGridView5_EditingControlShowing;
            //guna2DataGridView6.EditingControlShowing += guna2DataGridView6_EditingControlShowing;
            //tabControl1.SelectedIndex = 1;
            //firstname.Text = "";
            //familyname.Text = "";
            //dietplantemplatename.Text = "";
            //dietplantemplate.SelectedItem = null;
            //dietplandays.Text = "";
            //instruction.Text = "";
            //gender.Text = "";
            //age.Text = "";
            //mobileno.Text = "";
            //previousdietplan.Text = "";
            //calories.Text = "";
            //fats.Text = "";
            //fibers.Text = "";
            //potassium.Text = "";
            //water.Text = "";
            //sugar.Text = "";
            //calcium.Text = "";
            //abox.Text = "";
            //protein.Text = "";
            //carbohydrates.Text = "";
            //sodium.Text = "";
            //phosphor.Text = "";
            //magnesium.Text = "";
            //iron.Text = "";
            //iodine.Text = "";
            //bbox.Text = "";
            //MedicalHistory.Text = "";
            //edit = 0;
            //UpdateDietPlanTemplate();
            //updatepreviousdietplan();
            //UpdateInstruction();

            //if (coderunner != 0)
            //{
            //    fileno.Text = coderunner.ToString();
            //    LoadData(coderunner);
            //}

            //if (coderunner == 0)
            //{
            //    RowsFiller();
            //}

            NewTabRowsFill();
            tabControl1.SelectedIndex = 5;
        }

        private void AddIngredient_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2.RowCount < 6)
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
            else
            {
                MessageBox.Show("Cannot add more than 6 meals in Breakfast!");
            }


        }
        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView2.Columns["buttondgv"].Index && e.RowIndex >= 0)
            {
                foreach (var item in Mapping)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView2")
                    {
                        ChartMinus(item.ID);
                    }
                }

                Mapping.RemoveAll(item =>
                item.Row == e.RowIndex &&
                item.ChartName == "guna2DataGridView2");

                List<ArtificialMapping> itemsToAdd = new List<ArtificialMapping>();
                List<ArtificialMapping> itemsToRemove = new List<ArtificialMapping>();

                foreach (var item in Mapping)
                {
                    if (item.ChartName == "guna2DataGridView2")
                    {
                        if (item.Row > e.RowIndex)
                        {
                            ArtificialMapping NewIndex = new ArtificialMapping();
                            NewIndex.ID = item.ID;
                            NewIndex.Row = item.Row - 1;
                            NewIndex.Col = item.Col;
                            NewIndex.ChartName = item.ChartName;

                            itemsToAdd.Add(NewIndex);

                            itemsToRemove.Add(item);
                        }
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    Mapping.Remove(item);
                }

                foreach (var item in itemsToAdd)
                {
                    Mapping.Add(item);
                }
                guna2DataGridView2.Rows.RemoveAt(e.RowIndex);
                RowsChecker();
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {

                        firstname.Text = "";
                        familyname.Text = "";
                        gender.Text = "";
                        age.Text = "";
                        mobileno.Text = "";
                        dietplantemplate.Text = "";
                        dietplantemplatename.Text = "";
                        previousdietplan.Text = "";
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
                        MedicalHistory.Text = "";
                        // Get the Ingredient ID to display in the confirmation message
                        string ingredientIDToDelete = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Diet Plan with file no : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            string id = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM DietPlan WHERE FILENO = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("ID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString()); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                //MainClass.con.Open();
                                //SqlCommand cmdingredients = new SqlCommand("DELETE FROM DietPlan WHERE ID = @MealID", MainClass.con);
                                //cmdingredients.Parameters.AddWithValue("@MealID", id); // Assuming the Ingredient ID is in the first cell of the selected row.
                                //cmdingredients.ExecuteNonQuery();
                                //MessageBox.Show("Meal removed successfully");
                                //MainClass.con.Close();

                                //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
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
        private void Calculate(Guna2DataGridView grid)
        {
            foreach (DataGridViewRow row4 in grid.Rows)
            {
                if (!row4.IsNewRow) // Skip the last empty row4 if present.
                {

                    string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                    //if (row4.Cells[1] == null)
                    //{
                    //    MessageBox.Show("The category is empty!");
                    //}
                    //if (row4.Cells[1].Value != null)
                    //{
                    if (grid.Name == "guna2DataGridView2")
                    {
                        category = "Breakfast";
                    }
                    else if (grid.Name == "guna2DataGridView4")
                    {
                        category = "Lunch";
                    }
                    else if (grid.Name == "guna2DataGridView5")
                    {
                        category = "Dinner";
                    }
                    else if (grid.Name == "guna2DataGridView6")
                    {
                        category = "Snack";
                    }

                    //}

                    if (row4.Cells[2].Value != null)
                    {
                        one = row4.Cells[2].Value.ToString();
                    }

                    if (row4.Cells[3].Value != null)
                    {
                        two = row4.Cells[3].Value.ToString();
                    }

                    if (row4.Cells[4].Value != null)
                    {
                        three = row4.Cells[4].Value.ToString();
                    }

                    if (row4.Cells[5].Value != null)
                    {
                        four = row4.Cells[5].Value.ToString();
                    }

                    if (row4.Cells[6].Value != null)
                    {
                        five = row4.Cells[6].Value.ToString();
                    }

                    if (row4.Cells[7].Value != null)
                    {
                        six = row4.Cells[7].Value.ToString();
                    }

                    if (row4.Cells[8].Value != null)
                    {
                        seven = row4.Cells[8].Value.ToString();
                    }
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                            "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                        // Assuming appropriate variables for the values in the DietPlanAction table
                        cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
        private void CalculateTemplate(Guna2DataGridView grid)
        {
            foreach (DataGridViewRow row4 in grid.Rows)
            {
                if (!row4.IsNewRow) // Skip the last empty row4 if present.
                {

                    string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                    //if (row4.Cells[1] == null)
                    //{
                    //    MessageBox.Show("The category is empty!");
                    //}
                    //if (row4.Cells[1].Value != null)
                    //{
                    if (grid.Name == "guna2DataGridView2")
                    {
                        category = "Breakfast";
                    }
                    else if (grid.Name == "guna2DataGridView4")
                    {
                        category = "Lunch";
                    }
                    else if (grid.Name == "guna2DataGridView5")
                    {
                        category = "Dinner";
                    }
                    else if (grid.Name == "guna2DataGridView6")
                    {
                        category = "Snack";
                    }

                    //}

                    if (row4.Cells[2].Value != null)
                    {
                        one = row4.Cells[2].Value.ToString();
                    }

                    if (row4.Cells[3].Value != null)
                    {
                        two = row4.Cells[3].Value.ToString();
                    }

                    if (row4.Cells[4].Value != null)
                    {
                        three = row4.Cells[4].Value.ToString();
                    }

                    if (row4.Cells[5].Value != null)
                    {
                        four = row4.Cells[5].Value.ToString();
                    }

                    if (row4.Cells[6].Value != null)
                    {
                        five = row4.Cells[6].Value.ToString();
                    }

                    if (row4.Cells[7].Value != null)
                    {
                        six = row4.Cells[7].Value.ToString();
                    }

                    if (row4.Cells[8].Value != null)
                    {
                        seven = row4.Cells[8].Value.ToString();
                    }
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanTemplateAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                            "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                        // Assuming appropriate variables for the values in the DietPlanAction table
                        cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
        private void save_Click(object sender, EventArgs e)
        {
            chartfiller = 0;
            if (edit == 0)
            {
                string query = "SELECT COUNT(*) FROM DietPlan WHERE FILENO = @FileNo";

                using (SqlCommand command = new SqlCommand(query, MainClass.con))
                {
                    command.Parameters.AddWithValue("@FileNo", fileno.Text);

                    // Open connection and execute query
                    MainClass.con.Open();
                    int count = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row

                    MainClass.con.Close();


                    if (count > 0)
                    {
                        DialogResult result = MessageBox.Show("Diet Plan with file no : " + fileno.Text + " already exists! Do you want to update it to this one?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            if (firstname.Text != "")
                            {
                                try
                                {
                                    MainClass.con.Open();
                                    SqlCommand cmd = new SqlCommand("UPDATE DietPlan SET FIRSTNAME = @Firstname, FAMILYNAME = @Familyname, DietPlanDate = @DietPlanDate, DietPlanTemplateName = @DietPlanTemplateName, DietPlanTemplate = @DietPlanTemplate, DietPlanDays = @DietPlanDays, Instructions = @Instructions, Gender = @Gender, Age = @Age, MobileNo = @MobileNo, PreviousDiePlan = @PreviousDietPlan, CALORIES = @Calories, FATS = @Fats, FIBERS = @Fibers, POTASSIUM = @Potassium, WATER = @Water, SUGAR = @Sugar, CALCIUM = @Calcium, A = @A, PROTEIN = @Protein, CARBOHYDRATES = @Carbohydrates, SODIUM = @Sodium, PHOSPHOR = @Phosphor, MAGNESIUM = @Magnesium, IRON = @Iron, IODINE = @Iodine, B = @B WHERE FILENO = @Fileno", MainClass.con);

                                    // Assuming appropriate text boxes for each field in the DietPlan table
                                    cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                                    cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                    cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                    cmd.Parameters.AddWithValue("@DietPlanDate", Convert.ToDateTime(DietPlanDate.Value));
                                    cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatename.Text);
                                    cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplate.Text);
                                    cmd.Parameters.AddWithValue("@DietPlanDays", dietplandays.Text);
                                    cmd.Parameters.AddWithValue("@Instructions", instruction.Text);
                                    cmd.Parameters.AddWithValue("@Gender", gender.Text);
                                    cmd.Parameters.AddWithValue("@Age", int.Parse(age.Text));
                                    cmd.Parameters.AddWithValue("@MobileNo", mobileno.Text);
                                    cmd.Parameters.AddWithValue("@PreviousDietPlan", previousdietplan.Text);
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
                                    MainClass.con.Close();

                                    firstname.Text = "";
                                    familyname.Text = "";
                                    dietplantemplatename.Text = "";
                                    dietplantemplate.SelectedItem = null;
                                    dietplandays.Text = "";
                                    DietPlanDate.Value = DateTime.Now;
                                    instruction.Text = "";
                                    gender.Text = "";
                                    age.Text = "";
                                    mobileno.Text = "";
                                    previousdietplan.Text = "";
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
                                    MedicalHistory.Text = "";

                                    MainClass.con.Close();


                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }

                                try
                                {
                                    MainClass.con.Open();
                                    SqlCommand cmdingredients = new SqlCommand("DELETE FROM DietPlanAction WHERE DietPlanID = @ID", MainClass.con);
                                    cmdingredients.Parameters.AddWithValue("@ID", fileno.Text); // Assuming the Ingredient ID is in the first cell of the selected row.
                                    cmdingredients.ExecuteNonQuery();
                                    //MessageBox.Show("Meal removed successfully");
                                    //MainClass.con.Close();
                                    tabControl1.SelectedIndex = 4;
                                    foreach (DataGridViewRow row2 in guna2DataGridView2.Rows)
                                    {
                                        if (!row2.IsNewRow) // Skip the last empty row2 if present.
                                        {

                                            string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";



                                            category = "Breakfast";


                                            if (row2.Cells[2].Value != null)
                                            {
                                                one = row2.Cells[2].Value.ToString();
                                            }

                                            if (row2.Cells[3].Value != null)
                                            {
                                                two = row2.Cells[3].Value.ToString();
                                            }

                                            if (row2.Cells[4].Value != null)
                                            {
                                                three = row2.Cells[4].Value.ToString();
                                            }

                                            if (row2.Cells[5].Value != null)
                                            {
                                                four = row2.Cells[5].Value.ToString();
                                            }

                                            if (row2.Cells[6].Value != null)
                                            {
                                                five = row2.Cells[6].Value.ToString();
                                            }

                                            if (row2.Cells[7].Value != null)
                                            {
                                                six = row2.Cells[7].Value.ToString();
                                            }

                                            if (row2.Cells[8].Value != null)
                                            {
                                                seven = row2.Cells[8].Value.ToString();
                                            }
                                            try
                                            {
                                                //MainClass.con.Open();
                                                SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                                    "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                                // Assuming appropriate variables for the values in the DietPlanAction table
                                                cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                                    foreach (DataGridViewRow row8 in guna2DataGridView4.Rows)
                                    {
                                        if (!row8.IsNewRow) // Skip the last empty row8 if present.
                                        {

                                            string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                            //if (row8.Cells[1] == null)
                                            //{
                                            //    MessageBox.Show("The category is empty!");
                                            //}
                                            //if (row8.Cells[1].Value != null)
                                            //{
                                            category = "Lunch";
                                            //}

                                            if (row8.Cells[2].Value != null)
                                            {
                                                one = row8.Cells[2].Value.ToString();
                                            }

                                            if (row8.Cells[3].Value != null)
                                            {
                                                two = row8.Cells[3].Value.ToString();
                                            }

                                            if (row8.Cells[4].Value != null)
                                            {
                                                three = row8.Cells[4].Value.ToString();
                                            }

                                            if (row8.Cells[5].Value != null)
                                            {
                                                four = row8.Cells[5].Value.ToString();
                                            }

                                            if (row8.Cells[6].Value != null)
                                            {
                                                five = row8.Cells[6].Value.ToString();
                                            }

                                            if (row8.Cells[7].Value != null)
                                            {
                                                six = row8.Cells[7].Value.ToString();
                                            }

                                            if (row8.Cells[8].Value != null)
                                            {
                                                seven = row8.Cells[8].Value.ToString();
                                            }
                                            try
                                            {
                                                //MainClass.con.Open();
                                                SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                                    "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                                // Assuming appropriate variables for the values in the DietPlanAction table
                                                cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                                                //MainClass.con.Close();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("An error occurred: " + ex.Message);
                                            }

                                        }





                                    }
                                    foreach (DataGridViewRow row9 in guna2DataGridView5.Rows)
                                    {
                                        if (!row9.IsNewRow) // Skip the last empty row9 if present.
                                        {

                                            string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                            //if (row9.Cells[1] == null)
                                            //{
                                            //    MessageBox.Show("The category is empty!");
                                            //}
                                            //if (row9.Cells[1].Value != null)
                                            //{
                                            category = "Dinner";
                                            //}

                                            if (row9.Cells[2].Value != null)
                                            {
                                                one = row9.Cells[2].Value.ToString();
                                            }

                                            if (row9.Cells[3].Value != null)
                                            {
                                                two = row9.Cells[3].Value.ToString();
                                            }

                                            if (row9.Cells[4].Value != null)
                                            {
                                                three = row9.Cells[4].Value.ToString();
                                            }

                                            if (row9.Cells[5].Value != null)
                                            {
                                                four = row9.Cells[5].Value.ToString();
                                            }

                                            if (row9.Cells[6].Value != null)
                                            {
                                                five = row9.Cells[6].Value.ToString();
                                            }

                                            if (row9.Cells[7].Value != null)
                                            {
                                                six = row9.Cells[7].Value.ToString();
                                            }

                                            if (row9.Cells[8].Value != null)
                                            {
                                                seven = row9.Cells[8].Value.ToString();
                                            }
                                            try
                                            {
                                                //MainClass.con.Open();
                                                SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                                    "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                                // Assuming appropriate variables for the values in the DietPlanAction table
                                                cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                                                //MainClass.con.Close();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("An error occurred: " + ex.Message);
                                            }

                                        }





                                    }
                                    foreach (DataGridViewRow row10 in guna2DataGridView6.Rows)
                                    {
                                        if (!row10.IsNewRow) // Skip the last empty row10 if present.
                                        {

                                            string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                            //if (row10.Cells[1] == null)
                                            //{
                                            //    MessageBox.Show("The category is empty!");
                                            //}
                                            //if (row10.Cells[1].Value != null)
                                            //{
                                            category = "Snack";
                                            //}

                                            if (row10.Cells[2].Value != null)
                                            {
                                                one = row10.Cells[2].Value.ToString();
                                            }

                                            if (row10.Cells[3].Value != null)
                                            {
                                                two = row10.Cells[3].Value.ToString();
                                            }

                                            if (row10.Cells[4].Value != null)
                                            {
                                                three = row10.Cells[4].Value.ToString();
                                            }

                                            if (row10.Cells[5].Value != null)
                                            {
                                                four = row10.Cells[5].Value.ToString();
                                            }

                                            if (row10.Cells[6].Value != null)
                                            {
                                                five = row10.Cells[6].Value.ToString();
                                            }

                                            if (row10.Cells[7].Value != null)
                                            {
                                                six = row10.Cells[7].Value.ToString();
                                            }

                                            if (row10.Cells[8].Value != null)
                                            {
                                                seven = row10.Cells[8].Value.ToString();
                                            }
                                            try
                                            {
                                                //MainClass.con.Open();
                                                SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                                    "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                                // Assuming appropriate variables for the values in the DietPlanAction table
                                                cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                                                //MainClass.con.Close();
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
                                MessageBox.Show("Please enter the first name."); // Or any other required field.
                            }
                        }
                    }
                    else
                    {
                        if (firstname.Text != "")
                        {

                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("INSERT INTO DietPlan (FILENO,Firstname, Familyname, DietPlanDate, DietPlanTemplateName, DietPlanTemplate, DietPlanDays, Instructions, Gender, Age, MobileNo, PreviousDiePlan, Calories, Fats, Fibers, Potassium, Water, Sugar, Calcium, A, Protein, Carbohydrates, Sodium, Phosphor, Magnesium, Iron, Iodine, B) " +
                                    "VALUES (@Fileno, @Firstname, @Familyname, @DietPlanDate, @DietPlanTemplateName, @DietPlanTemplate, @DietPlanDays, @Instructions, @Gender, @Age, @MobileNo, @PreviousDietPlan, @Calories, @Fats, @Fibers, @Potassium, @Water, @Sugar, @Calcium, @A, @Protein, @Carbohydrates, @Sodium, @Phosphor, @Magnesium, @Iron, @Iodine, @B)", MainClass.con);

                                // Assuming appropriate text boxes for each field in the DietPlan table
                                cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                                cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                cmd.Parameters.AddWithValue("@DietPlanDate", Convert.ToDateTime(DietPlanDate.Value));
                                cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatename.Text);
                                cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplate.Text);
                                cmd.Parameters.AddWithValue("@DietPlanDays", dietplandays.Text);
                                cmd.Parameters.AddWithValue("@Instructions", instruction.Text);
                                cmd.Parameters.AddWithValue("@Gender", gender.Text);
                                cmd.Parameters.AddWithValue("@Age", int.Parse(age.Text));
                                cmd.Parameters.AddWithValue("@MobileNo", mobileno.Text);
                                cmd.Parameters.AddWithValue("@PreviousDietPlan", previousdietplan.Text);
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
                                MainClass.con.Close();

                                firstname.Text = "";
                                familyname.Text = "";
                                dietplantemplatename.Text = "";
                                dietplantemplate.SelectedItem = null;
                                dietplandays.Text = "";
                                instruction.Text = "";
                                gender.Text = "";
                                age.Text = "";
                                mobileno.Text = "";
                                previousdietplan.Text = "";
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
                                MedicalHistory.Text = "";

                                MainClass.con.Close();

                                // Switch to the first tab of your tab control (assuming it's called tabControl1)
                                //tabControl1.SelectedIndex = 0;

                                // Refresh the DataGridView
                                //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            tabControl1.SelectedIndex = 3;
                            try
                            {
                                Calculate(guna2DataGridView2);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                Calculate(guna2DataGridView4);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                Calculate(guna2DataGridView5);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                Calculate(guna2DataGridView6);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please enter the first name."); // Or any other required field.
                        }
                    }
                }

            }
            else
            {

                if (firstname.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE DietPlan SET FIRSTNAME = @Firstname, FAMILYNAME = @Familyname, DietPlanDate = @DietPlanDate, DietPlanTemplateName = @DietPlanTemplateName, DietPlanTemplate = @DietPlanTemplate, DietPlanDays = @DietPlanDays, Instructions = @Instructions, Gender = @Gender, Age = @Age, MobileNo = @MobileNo, PreviousDiePlan = @PreviousDietPlan, CALORIES = @Calories, FATS = @Fats, FIBERS = @Fibers, POTASSIUM = @Potassium, WATER = @Water, SUGAR = @Sugar, CALCIUM = @Calcium, A = @A, PROTEIN = @Protein, CARBOHYDRATES = @Carbohydrates, SODIUM = @Sodium, PHOSPHOR = @Phosphor, MAGNESIUM = @Magnesium, IRON = @Iron, IODINE = @Iodine, B = @B WHERE FILENO = @Fileno", MainClass.con);

                        // Assuming appropriate text boxes for each field in the DietPlan table
                        cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                        cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                        cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDate", Convert.ToDateTime(DietPlanDate.Value));
                        cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatename.Text);
                        cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplate.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDays", dietplandays.Text);
                        cmd.Parameters.AddWithValue("@Instructions", instruction.Text);
                        cmd.Parameters.AddWithValue("@Gender", gender.Text);
                        cmd.Parameters.AddWithValue("@Age", int.Parse(age.Text));
                        cmd.Parameters.AddWithValue("@MobileNo", mobileno.Text);
                        cmd.Parameters.AddWithValue("@PreviousDietPlan", previousdietplan.Text);
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
                        MainClass.con.Close();

                        firstname.Text = "";
                        familyname.Text = "";
                        dietplantemplatename.Text = "";
                        dietplantemplate.SelectedItem = null;
                        dietplandays.Text = "";
                        instruction.Text = "";
                        gender.Text = "";
                        age.Text = "";
                        mobileno.Text = "";
                        previousdietplan.Text = "";
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
                        MedicalHistory.Text = "";

                        MainClass.con.Close();


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmdingredients = new SqlCommand("DELETE FROM DietPlanAction WHERE DietPlanID = @ID", MainClass.con);
                        cmdingredients.Parameters.AddWithValue("@ID", fileno.Text); // Assuming the Ingredient ID is in the first cell of the selected row.
                        cmdingredients.ExecuteNonQuery();
                        //MessageBox.Show("Meal removed successfully");
                        //MainClass.con.Close();
                        tabControl1.SelectedIndex = 4;
                        foreach (DataGridViewRow row2 in guna2DataGridView2.Rows)
                        {
                            if (!row2.IsNewRow) // Skip the last empty row2 if present.
                            {

                                string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";



                                category = "Breakfast";


                                if (row2.Cells[2].Value != null)
                                {
                                    one = row2.Cells[2].Value.ToString();
                                }

                                if (row2.Cells[3].Value != null)
                                {
                                    two = row2.Cells[3].Value.ToString();
                                }

                                if (row2.Cells[4].Value != null)
                                {
                                    three = row2.Cells[4].Value.ToString();
                                }

                                if (row2.Cells[5].Value != null)
                                {
                                    four = row2.Cells[5].Value.ToString();
                                }

                                if (row2.Cells[6].Value != null)
                                {
                                    five = row2.Cells[6].Value.ToString();
                                }

                                if (row2.Cells[7].Value != null)
                                {
                                    six = row2.Cells[7].Value.ToString();
                                }

                                if (row2.Cells[8].Value != null)
                                {
                                    seven = row2.Cells[8].Value.ToString();
                                }
                                try
                                {
                                    //MainClass.con.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                        "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                    // Assuming appropriate variables for the values in the DietPlanAction table
                                    cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                        foreach (DataGridViewRow row8 in guna2DataGridView4.Rows)
                        {
                            if (!row8.IsNewRow) // Skip the last empty row8 if present.
                            {

                                string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                //if (row8.Cells[1] == null)
                                //{
                                //    MessageBox.Show("The category is empty!");
                                //}
                                //if (row8.Cells[1].Value != null)
                                //{
                                category = "Lunch";
                                //}

                                if (row8.Cells[2].Value != null)
                                {
                                    one = row8.Cells[2].Value.ToString();
                                }

                                if (row8.Cells[3].Value != null)
                                {
                                    two = row8.Cells[3].Value.ToString();
                                }

                                if (row8.Cells[4].Value != null)
                                {
                                    three = row8.Cells[4].Value.ToString();
                                }

                                if (row8.Cells[5].Value != null)
                                {
                                    four = row8.Cells[5].Value.ToString();
                                }

                                if (row8.Cells[6].Value != null)
                                {
                                    five = row8.Cells[6].Value.ToString();
                                }

                                if (row8.Cells[7].Value != null)
                                {
                                    six = row8.Cells[7].Value.ToString();
                                }

                                if (row8.Cells[8].Value != null)
                                {
                                    seven = row8.Cells[8].Value.ToString();
                                }
                                try
                                {
                                    //MainClass.con.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                        "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                    // Assuming appropriate variables for the values in the DietPlanAction table
                                    cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                                    //MainClass.con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("An error occurred: " + ex.Message);
                                }

                            }





                        }
                        foreach (DataGridViewRow row9 in guna2DataGridView5.Rows)
                        {
                            if (!row9.IsNewRow) // Skip the last empty row9 if present.
                            {

                                string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                //if (row9.Cells[1] == null)
                                //{
                                //    MessageBox.Show("The category is empty!");
                                //}
                                //if (row9.Cells[1].Value != null)
                                //{
                                category = "Dinner";
                                //}

                                if (row9.Cells[2].Value != null)
                                {
                                    one = row9.Cells[2].Value.ToString();
                                }

                                if (row9.Cells[3].Value != null)
                                {
                                    two = row9.Cells[3].Value.ToString();
                                }

                                if (row9.Cells[4].Value != null)
                                {
                                    three = row9.Cells[4].Value.ToString();
                                }

                                if (row9.Cells[5].Value != null)
                                {
                                    four = row9.Cells[5].Value.ToString();
                                }

                                if (row9.Cells[6].Value != null)
                                {
                                    five = row9.Cells[6].Value.ToString();
                                }

                                if (row9.Cells[7].Value != null)
                                {
                                    six = row9.Cells[7].Value.ToString();
                                }

                                if (row9.Cells[8].Value != null)
                                {
                                    seven = row9.Cells[8].Value.ToString();
                                }
                                try
                                {
                                    //MainClass.con.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                        "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                    // Assuming appropriate variables for the values in the DietPlanAction table
                                    cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                                    //MainClass.con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("An error occurred: " + ex.Message);
                                }

                            }





                        }
                        foreach (DataGridViewRow row10 in guna2DataGridView6.Rows)
                        {
                            if (!row10.IsNewRow) // Skip the last empty row10 if present.
                            {

                                string category = "", one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                                //if (row10.Cells[1] == null)
                                //{
                                //    MessageBox.Show("The category is empty!");
                                //}
                                //if (row10.Cells[1].Value != null)
                                //{
                                category = "Snack";
                                //}

                                if (row10.Cells[2].Value != null)
                                {
                                    one = row10.Cells[2].Value.ToString();
                                }

                                if (row10.Cells[3].Value != null)
                                {
                                    two = row10.Cells[3].Value.ToString();
                                }

                                if (row10.Cells[4].Value != null)
                                {
                                    three = row10.Cells[4].Value.ToString();
                                }

                                if (row10.Cells[5].Value != null)
                                {
                                    four = row10.Cells[5].Value.ToString();
                                }

                                if (row10.Cells[6].Value != null)
                                {
                                    five = row10.Cells[6].Value.ToString();
                                }

                                if (row10.Cells[7].Value != null)
                                {
                                    six = row10.Cells[7].Value.ToString();
                                }

                                if (row10.Cells[8].Value != null)
                                {
                                    seven = row10.Cells[8].Value.ToString();
                                }
                                try
                                {
                                    //MainClass.con.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, one, two, three, Four, Five, Six, Seven, Category) " +
                                        "VALUES (@DietPlanID, @One, @Two, @Three, @Four, @Five, @Six, @Seven, @Category)", MainClass.con);

                                    // Assuming appropriate variables for the values in the DietPlanAction table
                                    cmd.Parameters.AddWithValue("@DietPlanID", fileno.Text); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
                                    //MainClass.con.Close();
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
                    MessageBox.Show("Please enter the first name."); // Or any other required field.
                }
                edit = 0;
            }


            guna2DataGridView2.Rows.Clear();
            guna2DataGridView4.Rows.Clear();
            guna2DataGridView5.Rows.Clear();
            guna2DataGridView6.Rows.Clear();
            RowsFiller();
            fileno.Text = string.Empty;
            edit = 0;


        }
        private void viewEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileno.Visible = false;
            filenolabel.Visible = false;
            string template = null;
            string PreviousPlan = null;
            edit = 1;
            try
            {
                dietPlanIDToEdit = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlan WHERE FILENO = @DietPlanID", MainClass.con);
                cmd.Parameters.AddWithValue("@DietPlanID", dietPlanIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        firstname.Text = reader["FIRSTNAME"].ToString();
                        familyname.Text = reader["FAMILYNAME"].ToString();
                        template = reader["DietPlanTemplateName"].ToString();
                        dietplantemplate.Text = reader["DietPlanTemplate"].ToString();
                        dietplandays.Text = reader["DietPlanDays"].ToString();
                        instruction.Text = reader["Instructions"].ToString();
                        gender.Text = reader["Gender"].ToString();
                        age.Text = reader["Age"].ToString();
                        mobileno.Text = reader["MobileNo"].ToString();
                        PreviousPlan = reader["PreviousDiePlan"].ToString();
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
                    dietplantemplatename.Text = template;
                    previousdietplan.Text = PreviousPlan;
                    extrafunc();
                    tabControl1.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("Diet Plan not found with ID: " + dietPlanIDToEdit);
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void guna2DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void guna2DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {



                comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted; // Ensure it's detached first
                comboBox.SelectionChangeCommitted += (s, args) => ComboBox_SelectionChangeCommitted(s, args, guna2DataGridView2.Name);
            }
            //CalculateChart(guna2DataGridView2);

        }


        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the SelectedIndexChanged event here
            if (sender is ComboBox comboBox)
            {
                // Get the selected value

                // Do something with the selected value
                ChartNewFunction(comboBox, guna2DataGridView2.Name);
            }
        }

        private void CalculateChart(Guna2DataGridView grid)
        {
            //tabControl1.SelectedIndex = 3;
            List<int> ids = new List<int>();

            foreach (DataGridViewRow row4 in grid.Rows)
            {
                if (!row4.IsNewRow) // Skip the last empty row4 if present.
                {

                    string one = "", two = "", three = "", four = "", five = "", six = "", seven = "";

                    if (row4.Cells[2].Value != null)
                    {
                        one = row4.Cells[2].Value.ToString();
                        ids.Add(int.Parse(one));
                    }

                    if (row4.Cells[3].Value != null)
                    {
                        two = row4.Cells[3].Value.ToString();
                        ids.Add(int.Parse(two));
                    }

                    if (row4.Cells[4].Value != null)
                    {
                        three = row4.Cells[4].Value.ToString();
                        ids.Add(int.Parse(three));
                    }

                    if (row4.Cells[5].Value != null)
                    {
                        four = row4.Cells[5].Value.ToString();
                        ids.Add(int.Parse(four));
                    }

                    if (row4.Cells[6].Value != null)
                    {
                        five = row4.Cells[6].Value.ToString();
                        ids.Add(int.Parse(five));
                    }

                    if (row4.Cells[7].Value != null)
                    {
                        six = row4.Cells[7].Value.ToString();
                        ids.Add(int.Parse(six));
                    }

                    if (row4.Cells[8].Value != null)
                    {
                        seven = row4.Cells[8].Value.ToString();
                        ids.Add(int.Parse(seven));
                    }


                }

            }
            //tabControl1.SelectedIndex = 1;

            float caloriesValue, fatsValue, fibersValue, potassiumValue, waterValue, sugarValue,
                            calciumValue, aboxValue, proteinValue, carbohydratesValue, sodiumValue, phosphorValue,
                            magnesiumValue, ironValue, iodineValue, bboxValue;
            caloriesValue = 0;
            fatsValue = 0;
            fibersValue = 0;
            potassiumValue = 0;
            waterValue = 0;
            sugarValue = 0;
            calciumValue = 0;
            aboxValue = 0;
            proteinValue = 0;
            carbohydratesValue = 0;
            sodiumValue = 0;
            phosphorValue = 0;
            magnesiumValue = 0;
            ironValue = 0;
            iodineValue = 0;
            bboxValue = 0;

            foreach (var id in ids)
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

                            if (calories.Text != "")
                            {
                                // float = calories.Text;
                                //float = fats.Text;
                                // float = fibers.Text;
                                // float = potassium.Text;
                                //float = water.Text;
                                // float = sugar.Text;
                                // float = calcium.Text;
                                // float = abox.Text;
                                // float = protein.Text;
                                // float = carbohydrates.Text;
                                // float = sodium.Text;
                                // float = phosphor.Text;
                                // float = magnesium.Text;
                                // float = iron.Text;
                                // float = iodine.Text;
                                // float = bbox.Text;
                            }
                            else
                            {
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


                        }
                        reader.Close();
                        MainClass.con.Close();

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
        }

        private void ChartNewFunction(object sender, string dgv)
        {
            var comboBox = (ComboBox)sender;
            string name = dgv;
            // Assuming the ComboBox contains items of a custom class "YourCustomClass"
            if (comboBox.SelectedItem is MealsDropdown selectedObject)
            {
                int selectedValue = selectedObject.ID;
                //if(chartfiller == 0)
                //{
                //    calories.Text = "0";
                //    fats.Text = "0";
                //    fibers.Text = "0";
                //    potassium.Text = "0";
                //    water.Text = "0";
                //    sugar.Text = "0";
                //    calcium.Text = "0";
                //    abox.Text = "0";
                //    protein.Text = "0";
                //    carbohydrates.Text = "0";
                //    sodium.Text = "0";
                //    phosphor.Text = "0";
                //    magnesium.Text = "0";
                //    iron.Text = "0";
                //    iodine.Text = "0";
                //    bbox.Text = "0";

                //    chartfiller = 1;
                //}
                //ChartFiller(selectedValue);
                comboBox.BackColor = Color.Orange;
                if (name == "guna2DataGridView2")
                {
                    CalculateChart(guna2DataGridView2);
                }

            }
        }



        List<ArtificialMapping> Mapping = new List<ArtificialMapping>();
        static int chartcounter = 0;
        private void ChartMinus(int id)
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
                        float caloriesValue, fatsValue, fibersValue, potassiumValue, waterValue, sugarValue,
                        calciumValue, aboxValue, proteinValue, carbohydratesValue, sodiumValue, phosphorValue,
                        magnesiumValue, ironValue, iodineValue, bboxValue;

                        if (calories.Text != "")
                        {
                            caloriesValue = float.Parse(calories.Text);
                            fatsValue = float.Parse(fats.Text);
                            fibersValue = float.Parse(fibers.Text);
                            potassiumValue = float.Parse(potassium.Text);
                            waterValue = float.Parse(water.Text);
                            sugarValue = float.Parse(sugar.Text);
                            calciumValue = float.Parse(calcium.Text);
                            aboxValue = float.Parse(abox.Text);
                            proteinValue = float.Parse(protein.Text);
                            carbohydratesValue = float.Parse(carbohydrates.Text);
                            sodiumValue = float.Parse(sodium.Text);
                            phosphorValue = float.Parse(phosphor.Text);
                            magnesiumValue = float.Parse(magnesium.Text);
                            ironValue = float.Parse(iron.Text);
                            iodineValue = float.Parse(iodine.Text);
                            bboxValue = float.Parse(bbox.Text);
                        }
                        else
                        {
                            caloriesValue = 0;
                            fatsValue = 0;
                            fibersValue = 0;
                            potassiumValue = 0;
                            waterValue = 0;
                            sugarValue = 0;
                            calciumValue = 0;
                            aboxValue = 0;
                            proteinValue = 0;
                            carbohydratesValue = 0;
                            sodiumValue = 0;
                            phosphorValue = 0;
                            magnesiumValue = 0;
                            ironValue = 0;
                            iodineValue = 0;
                            bboxValue = 0;
                        }


                        caloriesValue -= float.Parse(reader["CALORIES"].ToString());
                        fatsValue -= float.Parse(reader["FATS"].ToString());
                        fibersValue -= float.Parse(reader["FIBERS"].ToString());
                        potassiumValue -= float.Parse(reader["POTASSIUM"].ToString());
                        waterValue -= float.Parse(reader["WATER"].ToString());
                        sugarValue -= float.Parse(reader["SUGAR"].ToString());
                        calciumValue -= float.Parse(reader["CALCIUM"].ToString());
                        aboxValue -= float.Parse(reader["A"].ToString());
                        proteinValue -= float.Parse(reader["PROTEIN"].ToString());
                        carbohydratesValue -= float.Parse(reader["CARBOHYDRATES"].ToString());
                        sodiumValue -= float.Parse(reader["SODIUM"].ToString());
                        phosphorValue -= float.Parse(reader["PHOSPHOR"].ToString());
                        magnesiumValue -= float.Parse(reader["MAGNESIUM"].ToString());
                        ironValue -= float.Parse(reader["IRON"].ToString());
                        iodineValue -= float.Parse(reader["IODINE"].ToString());
                        bboxValue -= float.Parse(reader["B"].ToString());

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
        private void ChartPlus(int id)
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
                        float caloriesValue, fatsValue, fibersValue, potassiumValue, waterValue, sugarValue,
                        calciumValue, aboxValue, proteinValue, carbohydratesValue, sodiumValue, phosphorValue,
                        magnesiumValue, ironValue, iodineValue, bboxValue;

                        if (calories.Text != "")
                        {
                            caloriesValue = float.Parse(calories.Text);
                            fatsValue = float.Parse(fats.Text);
                            fibersValue = float.Parse(fibers.Text);
                            potassiumValue = float.Parse(potassium.Text);
                            waterValue = float.Parse(water.Text);
                            sugarValue = float.Parse(sugar.Text);
                            calciumValue = float.Parse(calcium.Text);
                            aboxValue = float.Parse(abox.Text);
                            proteinValue = float.Parse(protein.Text);
                            carbohydratesValue = float.Parse(carbohydrates.Text);
                            sodiumValue = float.Parse(sodium.Text);
                            phosphorValue = float.Parse(phosphor.Text);
                            magnesiumValue = float.Parse(magnesium.Text);
                            ironValue = float.Parse(iron.Text);
                            iodineValue = float.Parse(iodine.Text);
                            bboxValue = float.Parse(bbox.Text);
                        }
                        else
                        {
                            caloriesValue = 0;
                            fatsValue = 0;
                            fibersValue = 0;
                            potassiumValue = 0;
                            waterValue = 0;
                            sugarValue = 0;
                            calciumValue = 0;
                            aboxValue = 0;
                            proteinValue = 0;
                            carbohydratesValue = 0;
                            sodiumValue = 0;
                            phosphorValue = 0;
                            magnesiumValue = 0;
                            ironValue = 0;
                            iodineValue = 0;
                            bboxValue = 0;
                        }


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
        private void ChartPlusForFilter(int id)
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
                        float caloriesValue, fatsValue, fibersValue, potassiumValue, waterValue, sugarValue,
                        calciumValue, aboxValue, proteinValue, carbohydratesValue, sodiumValue, phosphorValue,
                        magnesiumValue, ironValue, iodineValue, bboxValue;

                        if (calories.Text != "")
                        {
                            caloriesValue = float.Parse(calories.Text);
                            fatsValue = float.Parse(fats.Text);
                            fibersValue = float.Parse(fibers.Text);
                            potassiumValue = float.Parse(potassium.Text);
                            waterValue = float.Parse(water.Text);
                            sugarValue = float.Parse(sugar.Text);
                            calciumValue = float.Parse(calcium.Text);
                            aboxValue = float.Parse(abox.Text);
                            proteinValue = float.Parse(protein.Text);
                            carbohydratesValue = float.Parse(carbohydrates.Text);
                            sodiumValue = float.Parse(sodium.Text);
                            phosphorValue = float.Parse(phosphor.Text);
                            magnesiumValue = float.Parse(magnesium.Text);
                            ironValue = float.Parse(iron.Text);
                            iodineValue = float.Parse(iodine.Text);
                            bboxValue = float.Parse(bbox.Text);
                        }
                        else
                        {
                            caloriesValue = 0;
                            fatsValue = 0;
                            fibersValue = 0;
                            potassiumValue = 0;
                            waterValue = 0;
                            sugarValue = 0;
                            calciumValue = 0;
                            aboxValue = 0;
                            proteinValue = 0;
                            carbohydratesValue = 0;
                            sodiumValue = 0;
                            phosphorValue = 0;
                            magnesiumValue = 0;
                            ironValue = 0;
                            iodineValue = 0;
                            bboxValue = 0;
                        }


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

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e, string dataGridViewName)
        {
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
            Calculation.SelectedItem = null;
            foreach (var item in Mapping)
            {
                ChartPlusForFilter(item.ID);
            }
            var comboBox = (ComboBox)sender;
            string name = dataGridViewName;
            // Assuming the ComboBox contains items of a custom class "YourCustomClass"
            if (comboBox.SelectedItem is MealsDropdown selectedObject)
            {
                ArtificialMapping data = new ArtificialMapping();
                data.ID = selectedObject.ID;
                int selectedValue = selectedObject.ID;


                if (name == "guna2DataGridView2")
                {
                    data.Row = guna2DataGridView2.CurrentRow.Index;
                    data.Col = guna2DataGridView2.CurrentCell.ColumnIndex;
                    data.ChartName = name;

                    foreach (var item in Mapping)
                    {
                        chartcounter = 1;
                        if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col && item.ID == data.ID)
                        {
                            chartcounter = 0;
                            ChartMinus(data.ID);
                            break;
                        }
                        else if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col)
                        {
                            int previousid = item.ID;
                            ChartMinus(previousid);
                            chartcounter = 0;
                        }
                        else
                        {
                            chartcounter = 0;
                        }


                    }

                    Mapping.RemoveAll(item =>
                    item.Row == data.Row &&
                    item.Col == data.Col &&
                    item.ChartName == name
                    );

                    if (chartcounter == 0)
                    {
                        Mapping.Add(data);
                        ChartPlus(data.ID);
                        chartcounter = 1;
                    }

                }
                else if (name == "guna2DataGridView4")
                {
                    data.Row = guna2DataGridView4.CurrentRow.Index;
                    data.Col = guna2DataGridView4.CurrentCell.ColumnIndex;
                    data.ChartName = name;
                    foreach (var item in Mapping)
                    {
                        chartcounter = 1;
                        if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col && item.ID == data.ID)
                        {
                            chartcounter = 0;
                            ChartMinus(data.ID);
                            break;
                        }
                        else if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col)
                        {
                            int previousid = item.ID;
                            ChartMinus(previousid);
                            chartcounter = 0;
                        }
                        else
                        {
                            chartcounter = 0;
                        }


                    }

                    Mapping.RemoveAll(item =>
                    item.Row == data.Row &&
                    item.Col == data.Col &&
                    item.ChartName == name
                    );

                    if (chartcounter == 0)
                    {
                        Mapping.Add(data);
                        ChartPlus(data.ID);
                        chartcounter = 1;
                    }
                }
                else if (name == "guna2DataGridView5")
                {
                    data.Row = guna2DataGridView5.CurrentRow.Index;
                    data.Col = guna2DataGridView5.CurrentCell.ColumnIndex;
                    data.ChartName = name;
                    foreach (var item in Mapping)
                    {
                        chartcounter = 1;
                        if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col && item.ID == data.ID)
                        {
                            chartcounter = 0;
                            ChartMinus(data.ID);
                            break;
                        }
                        else if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col)
                        {
                            int previousid = item.ID;
                            ChartMinus(previousid);
                            chartcounter = 0;
                        }
                        else
                        {
                            chartcounter = 0;
                        }

                    }

                    Mapping.RemoveAll(item =>
                    item.Row == data.Row &&
                    item.Col == data.Col &&
                    item.ChartName == name
                    );

                    if (chartcounter == 0)
                    {
                        Mapping.Add(data);
                        ChartPlus(data.ID);
                        chartcounter = 1;
                    }
                }
                else if (name == "guna2DataGridView6")
                {
                    data.Row = guna2DataGridView6.CurrentRow.Index;
                    data.Col = guna2DataGridView6.CurrentCell.ColumnIndex;
                    data.ChartName = name;
                    foreach (var item in Mapping)
                    {
                        chartcounter = 1;
                        if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col && item.ID == data.ID)
                        {
                            chartcounter = 0;
                            ChartMinus(data.ID);
                            break;
                        }
                        else if (item.ChartName == name && item.Row == data.Row && item.Col == data.Col)
                        {
                            int previousid = item.ID;
                            ChartMinus(previousid);
                            chartcounter = 0;
                        }
                        else
                        {
                            chartcounter = 0;
                        }

                    }

                    Mapping.RemoveAll(item =>
                    item.Row == data.Row &&
                    item.Col == data.Col &&
                    item.ChartName == name
                    );

                    if (chartcounter == 0)
                    {
                        Mapping.Add(data);
                        ChartPlus(data.ID);
                        chartcounter = 1;
                    }
                }
                //if (name == "guna2DataGridView2")
                //{
                //    CalculateChart(guna2DataGridView2);
                //}

            }
        }
        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            string name = comboBox.Parent.Name;
            // Assuming the ComboBox contains items of a custom class "YourCustomClass"
            if (comboBox.SelectedItem is MealsDropdown selectedObject)
            {
                int selectedValue = selectedObject.ID;
                //if(chartfiller == 0)
                //{
                //    calories.Text = "0";
                //    fats.Text = "0";
                //    fibers.Text = "0";
                //    potassium.Text = "0";
                //    water.Text = "0";
                //    sugar.Text = "0";
                //    calcium.Text = "0";
                //    abox.Text = "0";
                //    protein.Text = "0";
                //    carbohydrates.Text = "0";
                //    sodium.Text = "0";
                //    phosphor.Text = "0";
                //    magnesium.Text = "0";
                //    iron.Text = "0";
                //    iodine.Text = "0";
                //    bbox.Text = "0";

                //    chartfiller = 1;
                //}
                comboBox.BackColor = Color.Orange;
                //CalculateChart(selectedValue);
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
                        float caloriesValue, fatsValue, fibersValue, potassiumValue, waterValue, sugarValue,
                        calciumValue, aboxValue, proteinValue, carbohydratesValue, sodiumValue, phosphorValue,
                        magnesiumValue, ironValue, iodineValue, bboxValue;

                        if (calories.Text != "")
                        {
                            caloriesValue = float.Parse(calories.Text);
                            fatsValue = float.Parse(fats.Text);
                            fibersValue = float.Parse(fibers.Text);
                            potassiumValue = float.Parse(potassium.Text);
                            waterValue = float.Parse(water.Text);
                            sugarValue = float.Parse(sugar.Text);
                            calciumValue = float.Parse(calcium.Text);
                            aboxValue = float.Parse(abox.Text);
                            proteinValue = float.Parse(protein.Text);
                            carbohydratesValue = float.Parse(carbohydrates.Text);
                            sodiumValue = float.Parse(sodium.Text);
                            phosphorValue = float.Parse(phosphor.Text);
                            magnesiumValue = float.Parse(magnesium.Text);
                            ironValue = float.Parse(iron.Text);
                            iodineValue = float.Parse(iodine.Text);
                            bboxValue = float.Parse(bbox.Text);
                        }
                        else
                        {
                            caloriesValue = 0;
                            fatsValue = 0;
                            fibersValue = 0;
                            potassiumValue = 0;
                            waterValue = 0;
                            sugarValue = 0;
                            calciumValue = 0;
                            aboxValue = 0;
                            proteinValue = 0;
                            carbohydratesValue = 0;
                            sodiumValue = 0;
                            phosphorValue = 0;
                            magnesiumValue = 0;
                            ironValue = 0;
                            iodineValue = 0;
                            bboxValue = 0;
                        }


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
            //SearchDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
        }
        private int GetLastMealDietPlanTemplate()
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
        private void dietplantemplatesave_Click(object sender, EventArgs e)
        {
            if (dietplantemplatename.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanTemplate (DietPlanTemplateName, DietPlanTemplate, DietPlanDays, Instructions,  Calories, Fats, Fibers, Potassium, Water, Sugar, Calcium, A, Protein, Carbohydrates, Sodium, Phosphor, Magnesium, Iron, Iodine, B) " +
                        "VALUES (@DietPlanTemplateName, @DietPlanTemplate, @DietPlanDays, @Instructions,  @Calories, @Fats, @Fibers, @Potassium, @Water, @Sugar, @Calcium, @A, @Protein, @Carbohydrates, @Sodium, @Phosphor, @Magnesium, @Iron, @Iodine, @B)", MainClass.con);

                    // Assuming appropriate text boxes for each field in the DietPlan table
                    //cmd.Parameters.AddWithValue("@Fileno", fileno.Text);

                    cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatename.Text);
                    cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplate.Text);
                    cmd.Parameters.AddWithValue("@DietPlanDays", dietplandays.Text);
                    cmd.Parameters.AddWithValue("@Instructions", instruction.Text);
                    //cmd.Parameters.AddWithValue("@medicalhistory", medicalhistory.Text);
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


                    firstname.Text = "";
                    familyname.Text = "";
                    gender.Text = "";
                    age.Text = "";
                    mobileno.Text = "";
                    dietplantemplate.Text = "";
                    dietplantemplatename.Text = "";
                    previousdietplan.Text = "";
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
                    MedicalHistory.Text = "";

                    MainClass.con.Close();

                    // Switch to the first tab of your tab control (assuming it's called tabControl1)
                    tabControl1.SelectedIndex = 0;

                    // Refresh the DataGridView
                    //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
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
                                cmd.Parameters.AddWithValue("@DietPlanID", GetLastMealDietPlanTemplate()); // Replace GetLastMeal() with the appropriate method or value for DietPlanID
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
        private void intlock(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }
        static int conn = 0;
        private void fileno_TextChanged(object sender, EventArgs e)
        {
            Mapping.Clear();
            firstname.Text = string.Empty;
            familyname.Text = string.Empty;
            dietplantemplate.Text = string.Empty;
            dietplandays.Text = string.Empty;
            instruction.Text = string.Empty;
            gender.Text = string.Empty;
            age.Text = string.Empty;
            mobileno.Text = string.Empty;
            calories.Text = string.Empty;
            fats.Text = string.Empty;
            fibers.Text = string.Empty;
            potassium.Text = string.Empty;
            water.Text = string.Empty;
            sugar.Text = string.Empty;
            calcium.Text = string.Empty;
            abox.Text = string.Empty;
            protein.Text = string.Empty;
            carbohydrates.Text = string.Empty;
            sodium.Text = string.Empty;
            phosphor.Text = string.Empty;
            magnesium.Text = string.Empty;
            iron.Text = string.Empty;
            iodine.Text = string.Empty;
            bbox.Text = string.Empty;
            guna2DataGridView2.Rows.Clear();
            guna2DataGridView4.Rows.Clear();
            guna2DataGridView5.Rows.Clear();
            guna2DataGridView6.Rows.Clear();
            RowsFiller();

            if (fileno.Text != "")
            {
                int value = int.Parse(fileno.Text);

                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    SqlCommand cmd2 = new SqlCommand("SELECT  FIRSTNAME, FAMILYNAME, MOBILENO, GENDER, AGE FROM CUSTOMER " +
                        "WHERE FILENO = @fileno", MainClass.con);

                    cmd2.Parameters.AddWithValue("@fileno", value);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        // Assign values from the reader to the respective text boxes
                        firstname.Text = reader2["FIRSTNAME"].ToString();
                        familyname.Text = reader2["FAMILYNAME"].ToString();
                        mobileno.Text = reader2["MOBILENO"].ToString();
                        gender.Text = reader2["GENDER"].ToString();
                        age.Text = reader2["AGE"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No customer with this file no exist!");
                    }
                    reader2.Close();
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
            else
            {
                firstname.Text = "";
                familyname.Text = "";
                mobileno.Text = "";
                gender.SelectedItem = null;
                MedicalHistory.Text = "";
                age.Text = "";

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
        private void dietplantemplatename_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dietplantemplatename.SelectedItem != null)
            {
                DietTemplates selectedTemplate = (DietTemplates)dietplantemplatename.SelectedItem;
                int selectedID = selectedTemplate.ID;

                if (selectedID == 0)
                {
                    dietplandays.Text = "";
                    dietplantemplate.SelectedItem = null;
                    instruction.Text = "";
                }
                else
                {
                    try
                    {
                        if (MainClass.con.State != ConnectionState.Open)
                        {
                            MainClass.con.Open();
                            conn = 1;
                        }

                        SqlCommand cmd = new SqlCommand("SELECT DIETPLANTEMPLATE, DIETPLANDAYS, INSTRUCTIONS FROM DIETPLANTEMPLATE WHERE ID = @SelectedID", MainClass.con);
                        cmd.Parameters.AddWithValue("@SelectedID", selectedID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string dietplanTemplate = reader["DIETPLANTEMPLATE"].ToString();
                            string dietplanDays = reader["DIETPLANDAYS"].ToString();
                            string Instruct = reader["INSTRUCTIONS"].ToString();

                            dietplantemplate.Text = dietplanTemplate;
                            dietplandays.Text = dietplanDays;
                            instruction.Text = Instruct;
                        }
                        reader.Close();
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

            }
        }

        private void mobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true; // Ignore the keypress if it's not a number, a control character, or a plus sign
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void DietPlanDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddLunch_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView4.RowCount < 6)
            {
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



                for (int i = 1; i < guna2DataGridView4.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView4.Columns[i];

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

                guna2DataGridView4.Rows.Add(row);
            }
            else
            {
                MessageBox.Show("Cannot add more than 6 meals in Lunch!");
            }

        }

        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView4.Columns["lunchbuttondgv"].Index && e.RowIndex >= 0)
            {
                foreach (var item in Mapping)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView4")
                    {
                        ChartMinus(item.ID);
                    }
                }

                Mapping.RemoveAll(item =>
                item.Row == e.RowIndex &&
                item.ChartName == "guna2DataGridView4");

                List<ArtificialMapping> itemsToAdd = new List<ArtificialMapping>();
                List<ArtificialMapping> itemsToRemove = new List<ArtificialMapping>();

                foreach (var item in Mapping)
                {
                    if (item.ChartName == "guna2DataGridView4")
                    {
                        if (item.Row > e.RowIndex)
                        {
                            ArtificialMapping NewIndex = new ArtificialMapping();
                            NewIndex.ID = item.ID;
                            NewIndex.Row = item.Row - 1;
                            NewIndex.Col = item.Col;
                            NewIndex.ChartName = item.ChartName;

                            itemsToAdd.Add(NewIndex);

                            itemsToRemove.Add(item);
                        }
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    Mapping.Remove(item);
                }

                foreach (var item in itemsToAdd)
                {
                    Mapping.Add(item);
                }
                // Remove the corresponding row when the remove button is clicked.
                guna2DataGridView4.Rows.RemoveAt(e.RowIndex);
                RowsChecker();

            }
        }

        private void guna2DataGridView4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                // Attach the SelectionChangeCommitted event to the ComboBox
                comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted; // Ensure it's detached first
                comboBox.SelectionChangeCommitted += (s, args) => ComboBox_SelectionChangeCommitted(s, args, guna2DataGridView4.Name);
            }
        }

        private void DinnerAdd_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView5.RowCount < 6)
            {
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



                for (int i = 1; i < guna2DataGridView5.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView5.Columns[i];

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

                guna2DataGridView5.Rows.Add(row);
            }
            else
            {
                MessageBox.Show("Cannot add more than 6 meals in Dinner!");
            }

        }

        private void SnackAdd_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView6.RowCount < 6)
            {
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



                for (int i = 1; i < guna2DataGridView6.ColumnCount; i++)
                {
                    // Create a DataGridViewColumn for the current column.
                    DataGridViewColumn column = guna2DataGridView6.Columns[i];

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

                guna2DataGridView6.Rows.Add(row);
            }
            else
            {
                MessageBox.Show("Cannot add more than 6 meals in Snacks!");
            }

        }

        private void guna2DataGridView5_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                // Attach the SelectionChangeCommitted event to the ComboBox
                comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted; // Ensure it's detached first
                comboBox.SelectionChangeCommitted += (s, args) => ComboBox_SelectionChangeCommitted(s, args, guna2DataGridView5.Name);
            }
        }

        private void guna2DataGridView6_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                // Attach the SelectionChangeCommitted event to the ComboBox
                comboBox.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted; // Ensure it's detached first
                comboBox.SelectionChangeCommitted += (s, args) => ComboBox_SelectionChangeCommitted(s, args, guna2DataGridView6.Name);
            }
        }

        private void guna2DataGridView5_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView5.Columns["dinnerbuttondgv"].Index && e.RowIndex >= 0)
            {
                foreach (var item in Mapping)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView5")
                    {
                        ChartMinus(item.ID);
                    }
                }

                Mapping.RemoveAll(item =>
                item.Row == e.RowIndex &&
                item.ChartName == "guna2DataGridView5");

                List<ArtificialMapping> itemsToAdd = new List<ArtificialMapping>();
                List<ArtificialMapping> itemsToRemove = new List<ArtificialMapping>();

                foreach (var item in Mapping)
                {
                    if (item.ChartName == "guna2DataGridView5")
                    {
                        if (item.Row > e.RowIndex)
                        {
                            ArtificialMapping NewIndex = new ArtificialMapping();
                            NewIndex.ID = item.ID;
                            NewIndex.Row = item.Row - 1;
                            NewIndex.Col = item.Col;
                            NewIndex.ChartName = item.ChartName;

                            itemsToAdd.Add(NewIndex);

                            itemsToRemove.Add(item);
                        }
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    Mapping.Remove(item);
                }

                foreach (var item in itemsToAdd)
                {
                    Mapping.Add(item);
                }

                // Remove the corresponding row when the remove button is clicked.
                guna2DataGridView5.Rows.RemoveAt(e.RowIndex);
                RowsChecker();

            }
        }

        private void guna2DataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView6.Columns["snackbuttondgv"].Index && e.RowIndex >= 0)
            {
                foreach (var item in Mapping)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView6")
                    {
                        ChartMinus(item.ID);
                    }
                }

                Mapping.RemoveAll(item =>
                item.Row == e.RowIndex &&
                item.ChartName == "guna2DataGridView6");

                List<ArtificialMapping> itemsToAdd = new List<ArtificialMapping>();
                List<ArtificialMapping> itemsToRemove = new List<ArtificialMapping>();

                foreach (var item in Mapping)
                {
                    if (item.ChartName == "guna2DataGridView6")
                    {
                        if (item.Row > e.RowIndex)
                        {
                            ArtificialMapping NewIndex = new ArtificialMapping();
                            NewIndex.ID = item.ID;
                            NewIndex.Row = item.Row - 1;
                            NewIndex.Col = item.Col;
                            NewIndex.ChartName = item.ChartName;

                            itemsToAdd.Add(NewIndex);

                            itemsToRemove.Add(item);
                        }
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    Mapping.Remove(item);
                }

                foreach (var item in itemsToAdd)
                {
                    Mapping.Add(item);
                }

                // Remove the corresponding row when the remove button is clicked.
                guna2DataGridView6.Rows.RemoveAt(e.RowIndex);
                RowsChecker();

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            save.Enabled = true;
            AddMealrow.Enabled = true;
            AddLunch.Enabled = true;
            DinnerAdd.Enabled = true;
            SnackAdd.Enabled = true;
            edit = 1;
            save.Text = "Update Plan";

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Mapping.Clear();

            firstname.Text = "";
            familyname.Text = "";
            gender.SelectedItem = null;
            age.Text = "";
            mobileno.Text = "";
            dietplantemplate.Text = "";
            dietplantemplatename.Text = "";
            previousdietplan.Text = "";
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
            MedicalHistory.Text = "";
            guna2DataGridView2.Rows.Clear();
            guna2DataGridView4.Rows.Clear();
            guna2DataGridView5.Rows.Clear();
            guna2DataGridView6.Rows.Clear();
            save.Text = "Save Plan";
            string ingredientIDToDelete = "0";

            if (fileno.Text != "")
            {
                ingredientIDToDelete = fileno.Text.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.
                DialogResult result = MessageBox.Show("Are you sure you want to delete Diet Plan with file no : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM DietPlan WHERE FILENO = @ID", MainClass.con);
                        cmd.Parameters.AddWithValue("ID", ingredientIDToDelete); // Assuming the Ingredient ID is in the first cell of the selected row.
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();

                        //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM DietPlanAction WHERE DietPlanID = @ID", MainClass.con);
                        cmd.Parameters.AddWithValue("ID", ingredientIDToDelete); // Assuming the Ingredient ID is in the first cell of the selected row.
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();

                        //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                fileno.Text = "";
            }
            else
            {
                MessageBox.Show("Insert filen no!");
            }

            save.Enabled = true;
            AddMealrow.Enabled = true;
            AddLunch.Enabled = true;
            DinnerAdd.Enabled = true;
            SnackAdd.Enabled = true;
            edit = 1;
            save.Text = "Save Plan";
            edit = 0;


        }

        private void template_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void savetemplate_Click(object sender, EventArgs e)
        {
            if (dietplantemplateforsave.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanTemplate (DietPlanTemplateName, DietPlanTemplate, DietPlanDays, Instructions,  Calories, Fats, Fibers, Potassium, Water, Sugar, Calcium, A, Protein, Carbohydrates, Sodium, Phosphor, Magnesium, Iron, Iodine, B) " +
                        "VALUES (@DietPlanTemplateName, @DietPlanTemplate, @DietPlanDays, @Instructions,  @Calories, @Fats, @Fibers, @Potassium, @Water, @Sugar, @Calcium, @A, @Protein, @Carbohydrates, @Sodium, @Phosphor, @Magnesium, @Iron, @Iodine, @B)", MainClass.con);

                    // Assuming appropriate text boxes for each field in the DietPlan table
                    //cmd.Parameters.AddWithValue("@Fileno", fileno.Text);

                    cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplateforsave.Text);
                    cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplate.Text);
                    cmd.Parameters.AddWithValue("@DietPlanDays", dietplandays.Text);
                    cmd.Parameters.AddWithValue("@Instructions", instruction.Text);
                    //cmd.Parameters.AddWithValue("@medicalhistory", medicalhistory.Text);
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


                    firstname.Text = "";
                    familyname.Text = "";
                    gender.Text = "";
                    age.Text = "";
                    mobileno.Text = "";
                    dietplantemplate.Text = "";
                    dietplantemplatename.Text = "";
                    previousdietplan.Text = "";
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
                    MedicalHistory.Text = "";

                    MainClass.con.Close();

                    // Switch to the first tab of your tab control (assuming it's called tabControl1)
                    tabControl1.SelectedIndex = 1;

                    // Refresh the DataGridView
                    //ShowDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    CalculateTemplate(guna2DataGridView2);
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    CalculateTemplate(guna2DataGridView4);
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    CalculateTemplate(guna2DataGridView5);
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    CalculateTemplate(guna2DataGridView6);
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
            edit = 0;
        }

        private void searchplan_Click(object sender, EventArgs e)
        {
            if (fileno.Text != "")
            {
                string template = null;
                string PreviousPlan = null;
                StringBuilder stringBuilder = new StringBuilder();
                try
                {

                    dietPlanIDToEdit = fileno.Text.ToString();
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlan WHERE FILENO = @DietPlanID", MainClass.con);
                    cmd.Parameters.AddWithValue("@DietPlanID", dietPlanIDToEdit);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {


                            template = reader["DietPlanTemplateName"].ToString();
                            dietplantemplate.Text = reader["DietPlanTemplate"].ToString();
                            DietPlanDate.Value = Convert.ToDateTime(reader["DIETPLANDATE"]);
                            dietplandays.Text = reader["DietPlanDays"].ToString();
                            instruction.Text = reader["Instructions"].ToString();
                            PreviousPlan = reader["PreviousDiePlan"].ToString();
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
                        dietplantemplatename.Text = template;
                        previousdietplan.Text = PreviousPlan;
                        extrafunc();
                        save.Enabled = false;
                        AddMealrow.Enabled = false;
                        AddLunch.Enabled = false;
                        DinnerAdd.Enabled = false;
                        SnackAdd.Enabled = false;
                        //tabControl1.SelectedIndex = 1;
                        RowsChecker();
                    }
                    else
                    {
                        reader.Close();
                        MainClass.con.Close();
                        save.Enabled = true;
                        AddMealrow.Enabled = true;
                        AddLunch.Enabled = true;
                        DinnerAdd.Enabled = true;
                        SnackAdd.Enabled = true;
                        MessageBox.Show("No Diet Plan found for file no :" + fileno.Text);
                    }


                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    string customerIDToEdit = dietPlanIDToEdit;
                    string customerFilenoToEdit = dietPlanIDToEdit;

                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM MedicalHistory WHERE FILENO = @CustomerID", MainClass.con);
                    cmd.Parameters.AddWithValue("@CustomerID", customerIDToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Set the retrieved data into input boxes

                            string dbstatus = reader["Status"].ToString();
                            string dbSmoking = reader["Smoking"].ToString();
                            string dbblood = reader["BloodType"].ToString();

                            if (dbstatus == "Pregnant" || dbstatus == "Breast Feeding")
                            {
                                stringBuilder.Append(dbstatus);
                                stringBuilder.AppendLine();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Medical History not found for Customer with FILE NO : " + customerFilenoToEdit);
                    }
                    reader.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM DiseaseHistory WHERE FILENO = @CustomerID", MainClass.con);
                    cmd2.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        stringBuilder.Append("Diseases:");
                        stringBuilder.AppendLine();
                        while (reader2.Read())
                        {
                            // Set the retrieved data into input boxes

                            stringBuilder.Append(reader2["Data"].ToString() + ", ");


                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append(".");
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine();
                    }

                    reader2.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd3 = new SqlCommand("SELECT * FROM FoodAllergies WHERE FILENO = @CustomerID", MainClass.con);
                    cmd3.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    if (reader3.HasRows)
                    {
                        stringBuilder.Append("Food Allergies:");
                        stringBuilder.AppendLine();
                        while (reader3.Read())
                        {
                            // Set the retrieved data into input boxes

                            stringBuilder.Append(reader3["Data"].ToString() + ", ");


                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append(".");
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine();
                    }

                    reader3.Close();
                    MainClass.con.Close();



                    MainClass.con.Open();
                    SqlCommand cmd5 = new SqlCommand("SELECT * FROM Medication WHERE FILENO = @CustomerID", MainClass.con);
                    cmd5.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    List<string> medicines = new List<string>();
                    SqlDataReader reader5 = cmd5.ExecuteReader();
                    if (reader5.HasRows)
                    {
                        stringBuilder.Append("Medications:");
                        stringBuilder.AppendLine();
                        while (reader5.Read())
                        {
                            // Set the retrieved data into input boxes

                            stringBuilder.Append(reader5["Data"].ToString() + ", ");


                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append(".");
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine();

                    }

                    reader5.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd6 = new SqlCommand("SELECT * FROM Diet WHERE FILENO = @CustomerID", MainClass.con);
                    cmd6.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    SqlDataReader reader6 = cmd6.ExecuteReader();
                    if (reader6.HasRows)
                    {
                        stringBuilder.Append("Diet Avoidance:");
                        stringBuilder.AppendLine();
                        while (reader6.Read())
                        {
                            // Set the retrieved data into input boxes

                            stringBuilder.Append(reader6["Data"].ToString() + ", ");



                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append(".");
                        //stringBuilder.RemoveLast();
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine();

                    }

                    reader6.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd7 = new SqlCommand("SELECT * FROM Questions WHERE FILENO = @CustomerID", MainClass.con);
                    cmd7.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    SqlDataReader reader7 = cmd7.ExecuteReader();
                    if (reader7.HasRows)
                    {
                        stringBuilder.Append("Other Problems: ");
                        stringBuilder.AppendLine();
                        while (reader7.Read())
                        {
                            // Set the retrieved data into input boxes

                            string hdans = reader7["hormonalDisease"].ToString();
                            string cans = reader7["cancer"].ToString();
                            string hians = reader7["immuneDisease"].ToString();
                            string hedans = reader7["hereditaryDisease"].ToString();
                            string pdans = reader7["pancreaticDisease"].ToString();
                            string odans = reader7["otherDisease"].ToString();

                            if (hdans == "Yes")
                            {

                                stringBuilder.Append("Harmonal Discease, ");


                            }


                            if (cans == "Yes")
                            {
                                stringBuilder.Append("Cancer, ");
                            }


                            if (hians == "Yes")
                            {
                                stringBuilder.Append("Immunity Disease, ");
                            }


                            if (hedans == "Yes")
                            {
                                stringBuilder.Append("Hereditary Disease, ");
                            }


                            if (pdans == "Yes")
                            {
                                stringBuilder.Append("Pancreatic Disease, ");
                            }


                            if (odans == "Yes")
                            {
                                stringBuilder.Append("Other Disease. ");
                            }


                        }

                    }
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    stringBuilder.Append(".");
                    MedicalHistory.Text = stringBuilder.ToString();
                    reader7.Close();
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
                save.Enabled = true;
                AddMealrow.Enabled = true;
                AddLunch.Enabled = true;
                DinnerAdd.Enabled = true;
                SnackAdd.Enabled = true;
                MessageBox.Show("Enter File no!");
            }
            edit = 0;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void updateback_Click(object sender, EventArgs e)
        {
            save.Text = "Save Plan";
            tabControl1.SelectedIndex = 1;
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            Mapping.Clear();
            fileno.Text = "";
            firstname.Text = "";
            familyname.Text = "";
            dietplantemplatename.SelectedItem = null;
            dietplantemplate.SelectedItem = null;
            dietplandays.Text = "";
            instruction.SelectedItem = null;
            gender.Text = "";
            age.Text = "";
            mobileno.Text = "";
            previousdietplan.SelectedItem = null;
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
            MedicalHistory.Text = "";
            save.Enabled = true;
            AddMealrow.Enabled = true;
            AddLunch.Enabled = true;
            DinnerAdd.Enabled = true;
            SnackAdd.Enabled = true;
            edit = 0;
            save.Text = "Save Plan";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Calculation_SelectedValueChanged(object sender, EventArgs e)
        {
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

            string selectedValue = Calculation.Text;
            if (selectedValue == "1st Day")
            {
                foreach (var item in Mapping)
                {
                    if (item.Col == 2)
                    {
                        ChartPlusForFilter(item.ID);
                    }
                }
            }
            else if (selectedValue == "2nd Day")
            {
                foreach (var item in Mapping)
                {
                    if (item.Col == 3)
                    {
                        ChartPlusForFilter(item.ID);
                    }
                }
            }
            else if (selectedValue == "3rd Day")
            {
                foreach (var item in Mapping)
                {
                    if (item.Col == 4)
                    {
                        ChartPlusForFilter(item.ID);
                    }
                }
            }
            else if (selectedValue == "4th Day")
            {
                foreach (var item in Mapping)
                {
                    if (item.Col == 5)
                    {
                        ChartPlusForFilter(item.ID);
                    }
                }
            }
            else if (selectedValue == "5th Day")
            {
                foreach (var item in Mapping)
                {
                    if (item.Col == 6)
                    {
                        ChartPlusForFilter(item.ID);
                    }
                }
            }
            else if (selectedValue == "6th Day")
            {
                foreach (var item in Mapping)
                {
                    if (item.Col == 7)
                    {
                        ChartPlusForFilter(item.ID);
                    }
                }
            }
            else if (selectedValue == "7th Day")
            {
                foreach (var item in Mapping)
                {
                    if (item.Col == 8)
                    {
                        ChartPlusForFilter(item.ID);
                    }
                }
            }
            else if (selectedValue == "All")
            {
                foreach (var item in Mapping)
                {
                    ChartPlusForFilter(item.ID);
                }
            }


        }

        private void guna2DataGridView2_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //New Coding//
        private void NewTabRowsFill()
        {
            guna2DataGridView7.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView7.GridColor = Color.Black;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView7.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView7.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView8.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView8.GridColor = Color.Black;
            guna2DataGridView8.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView8.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView8.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView8.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView9.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView9.GridColor = Color.Black;
            guna2DataGridView9.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView9.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView9.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView9.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView10.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView10.GridColor = Color.Black;
            guna2DataGridView10.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView10.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView10.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView10.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView12.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView12.GridColor = Color.Black;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView12.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView12.RowTemplate.DefaultCellStyle.ForeColor;

            for (int i = 0; i < 3; i++)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView7.Rows.Add(row);
                guna2DataGridView8.Rows.Add(row);
                guna2DataGridView9.Rows.Add(row);
                guna2DataGridView10.Rows.Add(row);
            }
            guna2DataGridView7.ClearSelection();
            guna2DataGridView8.ClearSelection();
            guna2DataGridView9.ClearSelection();
            guna2DataGridView10.ClearSelection();
        }
        public class ArtificialMapping
        {
            public int ID { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }
            public string ChartName { get; set; }
        }

        List<ArtificialMapping> artificialMappings = new List<ArtificialMapping>();
        static int selectedRow;
        static int selectedColumn;
        static string selectedchart;
        static string MealID;
        private void guna2DataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView8.ClearSelection();
            guna2DataGridView9.ClearSelection();
            guna2DataGridView10.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView7";
        }

        private void guna2DataGridView10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView8.ClearSelection();
            guna2DataGridView9.ClearSelection();
            guna2DataGridView7.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView10";
        }

        private void guna2DataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView8.ClearSelection();
            guna2DataGridView10.ClearSelection();
            guna2DataGridView7.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView9";
        }

        private void guna2DataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView10.ClearSelection();
            guna2DataGridView9.ClearSelection();
            guna2DataGridView7.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView8";
        }

        private void guna2DataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView7.Rows.RemoveAt(e.RowIndex);
            CheckRows(guna2DataGridView7);
        }

        private void guna2DataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView10.Rows.RemoveAt(e.RowIndex);
            CheckRows(guna2DataGridView10);
        }

        private void guna2DataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView9.Rows.RemoveAt(e.RowIndex);
            CheckRows(guna2DataGridView9);
        }

        private void guna2DataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView8.Rows.RemoveAt(e.RowIndex);
            CheckRows(guna2DataGridView8);
        }

        private void CheckRows(Guna2DataGridView table)
        {
            while (table.RowCount < 3)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                table.Rows.Add(row);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView7.RowCount == 6)
            {
                MessageBox.Show("Cannot exceed more than 6 meals in breakfast");
            }
            else
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView7.Rows.Add(row);
            }


        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView10.RowCount == 6)
            {
                MessageBox.Show("Cannot exceed more than 6 meals in lunch");
            }
            else
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView10.Rows.Add(row);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView9.RowCount == 6)
            {
                MessageBox.Show("Cannot exceed more than 6 meals in dinner");
            }
            else
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView9.Rows.Add(row);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView8.RowCount == 6)
            {
                MessageBox.Show("Cannot exceed more than 6 meals in snack");
            }
            else
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView8.Rows.Add(row);
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
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView7.SelectedCells.Count == 1)
            {
                guna2DataGridView12.ClearSelection();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView10.SelectedCells.Count == 1)
            {
                guna2DataGridView12.ClearSelection();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView9.SelectedCells.Count == 1)
            {
                guna2DataGridView12.ClearSelection();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView8.SelectedCells.Count == 1)
            {
                guna2DataGridView12.ClearSelection();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
            }
        }

        private void Meals_Click_1(object sender, EventArgs e)
        {
            selectedRow = -1;
            selectedColumn = -1;
            selectedchart = "";

            guna2DataGridView8.ClearSelection();
            guna2DataGridView10.ClearSelection();
            guna2DataGridView7.ClearSelection();
            guna2DataGridView9.ClearSelection();

            tabControl1.SelectedIndex = 5;
        }

        private void guna2DataGridView12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateGroupsC();
            UpdateGroupsN();
            MealID = guna2DataGridView12.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Meal WHERE ID = @MealID", MainClass.con);
                cmd.Parameters.AddWithValue("@MealID", MealID);

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
                        caloriesm.Text = reader["CALORIES"].ToString();
                        fatsm.Text = reader["FATS"].ToString();
                        fibersm.Text = reader["FIBERS"].ToString();
                        potassiumm.Text = reader["POTASSIUM"].ToString();
                        waterm.Text = reader["WATER"].ToString();
                        sugerm.Text = reader["SUGAR"].ToString();
                        calciumm.Text = reader["CALCIUM"].ToString();
                        am.Text = reader["A"].ToString();
                        proteinm.Text = reader["PROTEIN"].ToString();
                        carbsm.Text = reader["CARBOHYDRATES"].ToString();
                        sodiumm.Text = reader["SODIUM"].ToString();
                        phosphorusm.Text = reader["PHOSPHOR"].ToString();
                        magnesiumm.Text = reader["MAGNESIUM"].ToString();
                        ironm.Text = reader["IRON"].ToString();
                        iodinem.Text = reader["IODINE"].ToString();
                        bm.Text = reader["B"].ToString();
                        //category.Text = reader["Category"].ToString();
                        notes.Text = reader["Notes"].ToString();
                        preparation.Text = reader["Preparation"].ToString();
                        classification.Text = reader["CLASSIFICATION"].ToString();
                        //Catgry = reader["Category"].ToString();
                    }
                    reader.Close(); // Close the first DataReader

                    //ShowIngredients(guna2DataGridView1, unitdgv, ingredientardgv, ingredientendgv,quantitydgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv, potassiumdgv, phosphordgv,waterdgv,magnesiumdgv,sugerdgv,irondgv,iodinedgv,adgv,bdgv);
                    MainClass.con.Close();
                    //extrafunc();

                    //tabControl1.SelectedIndex = 2;
                }
                else
                {
                    MessageBox.Show("Meal not found with ID: " + MealID);
                }

                MainClass.con.Close();
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
                    string Namear = row.Field<string>("Namear");
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
        //ArtificialMapping data = new ArtificialMapping();
        //data.ID = int.Parse(MealID);
        //data.Row = selectedRow;
        //    data.Col = selectedColumn;
        //    data.ChartName = selectedchart;

        //}
    }
}

