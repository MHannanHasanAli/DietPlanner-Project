using Guna.UI2.WinForms;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            fatsm.TextChanged += UpdateChart2;
            proteinm.TextChanged += UpdateChart2;
            carbsm.TextChanged += UpdateChart2;
            fatsd.TextChanged += UpdateChart3;
            proteind.TextChanged += UpdateChart3;
            carbsd.TextChanged += UpdateChart3;
        }
        static int coderunner = 0;
        public DietPlan(int id)
        {
            InitializeComponent();
            //calories.TextChanged += UpdateChart;
            fatsm.TextChanged += UpdateChart2;
            proteinm.TextChanged += UpdateChart2;
            carbsm.TextChanged += UpdateChart2;
            fatsd.TextChanged += UpdateChart3;
            proteind.TextChanged += UpdateChart3;
            carbsd.TextChanged += UpdateChart3;
            coderunner = id;
            filenon.Text = id.ToString();
            LoadData(id);
        }
        private void LoadData(int id)
        {
            string template = null;
            string PreviousPlan = null;
            try
            {

                dietPlanIDToEdit = filenon.Text.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlan WHERE FILENO = @DietPlanID", MainClass.con);
                cmd.Parameters.AddWithValue("@DietPlanID", dietPlanIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dietplanID = int.Parse(reader["ID"].ToString());
                        template = reader["DietPlanTemplateName"].ToString();
                        dietplantemplatenew.Text = reader["DietPlanTemplate"].ToString();
                        dietplandaten.Value = Convert.ToDateTime(reader["DIETPLANDATE"]);
                        dietplandaysnew.Text = reader["DietPlanDays"].ToString();
                        instructionnew.Text = reader["Instructions"].ToString();
                        PreviousPlan = reader["PreviousDiePlan"].ToString();
                        caloried.Text = reader["CALORIES"].ToString();
                        fatsd.Text = reader["FATS"].ToString();
                        fibersd.Text = reader["FIBERS"].ToString();
                        potassiumd.Text = reader["POTASSIUM"].ToString();
                        waterd.Text = reader["WATER"].ToString();
                        sugerd.Text = reader["SUGAR"].ToString();
                        calciumd.Text = reader["CALCIUM"].ToString();
                        ad.Text = reader["A"].ToString();
                        proteind.Text = reader["PROTEIN"].ToString();
                        carbsd.Text = reader["CARBOHYDRATES"].ToString();
                        sodiumd.Text = reader["SODIUM"].ToString();
                        phosphorusd.Text = reader["PHOSPHOR"].ToString();
                        magnesiumd.Text = reader["MAGNESIUM"].ToString();
                        irond.Text = reader["IRON"].ToString();
                        iodined.Text = reader["IODINE"].ToString();
                        bd.Text = reader["B"].ToString();
                    }
                    reader.Close();
                    MainClass.con.Close();
                    dietplantemplatenamenew.Text = template;
                    previousdietplannew.Text = PreviousPlan;
                    MealsFetcher();
                    NewSave.Enabled = true;




                    edit = 1;
                    NewSave.Text = "Update Plan";
                    //tabControl1.SelectedIndex = 1;
                    //RowsChecker();
                }



            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            MainClass.con.Close();
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
                dietplantemplatenamenew.DataSource = null;
                // Clear the items (if DataSource is not being set)
                dietplantemplatenamenew.Items.Clear();
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

                dietplantemplatenamenew.DataSource = Template;
                dietplantemplatenamenew.DisplayMember = "Name"; // Display Member is Name
                dietplantemplatenamenew.ValueMember = "ID"; // Value Member is ID


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
                instructionnew.DataSource = null;
                // Clear the items (if DataSource is not being set)
                instructionnew.Items.Clear();
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

                instructionnew.DataSource = Template;
                instructionnew.DisplayMember = "Name"; // Display Member is Name
                instructionnew.ValueMember = "ID"; // Value Member is ID


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
        static int languagestatus;
        private void LanguageInfo()
        {
            MainClass.con.Open();

            // Create a SqlCommand to fetch the row with ID 1 from the Language table
            SqlCommand fetchCmd = new SqlCommand("SELECT * FROM Language WHERE ID = 1", MainClass.con);

            // Execute the fetch command to get the data
            using (SqlDataReader reader = fetchCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Retrieve values from the reader and store them in variables
                    int id = Convert.ToInt32(reader["ID"]);
                    languagestatus = Convert.ToInt32(reader["Status"]);

                    // Now, you can use the 'id' and 'status' variables as needed
                    // For example, display them in a MessageBox
                }

            }

            MainClass.con.Close();

        }

        private void Start()
        {

            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT COMPANYNAME,BRANCH,EMAIL,LANDLINE,MOBILE,POBOX,TRADENO,WELCOME,LOGO,Room1,Room2,Room3,Room4 FROM SETTINGS", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //companyname.Text = dr["COMPANYNAME"].ToString();
                    //branch.Text = dr["BRANCH"].ToString();
                    //email.Text = dr["EMAIL"].ToString();
                    //landline.Text = dr["LANDLINE"].ToString();
                    //mobile.Text = dr["MOBILE"].ToString();
                    //pobox.Text = dr["POBOX"].ToString();
                    //trade.Text = dr["TRADENO"].ToString();
                    //welcomewords.Text = dr["WELCOME"].ToString();
                    //pictureBox1.ImageLocation = dr["LOGO"].ToString();
                    //logolocation = dr["LOGO"].ToString();
                    //room1.Text = dr["Room1"].ToString();
                    //room2.Text = dr["Room2"].ToString();
                    //room3.Text = dr["Room3"].ToString();
                    //room4.Text = dr["Room4"].ToString();
                }

                dr.Close();
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

                cmd = new SqlCommand("SELECT * FROM Text", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //bold.Text = dr["Bold"].ToString();
                    //itallic.Text = dr["Italic"].ToString();
                    //underline.Text = dr["Underline"].ToString();
                    //textsize.Text = dr["Size"].ToString();
                }

                dr.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void DietPlan_Load(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart4.Series.Clear();
            chart5.Series.Clear();
            chart6.Series.Clear();
            chart7.Series.Clear();
            chart8.Series.Clear();
            chart9.Series.Clear();
            chart10.Series.Clear();

            UpdateInstruction();

            instructionflag = 1;
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

                    foreach (System.Windows.Forms.Control control in panel11.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel17.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel18.Controls)
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

                    foreach (System.Windows.Forms.Control control in panel11.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel17.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel18.Controls)
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

                    foreach (System.Windows.Forms.Control control in panel11.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel17.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel18.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel10.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
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

            LanguageInfo();
            if (languagestatus == 1)
            {
                foreach (Control control in panel11.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel11.Width - currentLoc.X - control.Width, currentLoc.Y);

                    // Set the mirrored location to the control
                    control.Location = mirroredLoc;

                    // Check if the control is a TextBox and set RightToLeft to true
                    if (control is Guna2TextBox textBox)
                    {
                        textBox.RightToLeft = RightToLeft.Yes;
                    }

                    if (control is Guna2DataGridView tabel)
                    {
                        tabel.RightToLeft = RightToLeft.Yes;
                    }
                }

                foreach (Control control in panel17.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel17.Width - currentLoc.X - control.Width, currentLoc.Y);

                    // Set the mirrored location to the control
                    control.Location = mirroredLoc;

                    // Check if the control is a TextBox and set RightToLeft to true
                    if (control is Guna2TextBox textBox)
                    {
                        textBox.RightToLeft = RightToLeft.Yes;
                    }

                    if (control is Guna2DataGridView tabel)
                    {
                        tabel.RightToLeft = RightToLeft.Yes;
                    }
                }

                foreach (Control control in panel18.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel18.Width - currentLoc.X - control.Width, currentLoc.Y);

                    // Set the mirrored location to the control
                    control.Location = mirroredLoc;

                    // Check if the control is a TextBox and set RightToLeft to true
                    if (control is Guna2TextBox textBox)
                    {
                        textBox.RightToLeft = RightToLeft.Yes;
                    }

                    if (control is Guna2DataGridView tabel)
                    {
                        tabel.RightToLeft = RightToLeft.Yes;
                    }
                }
                foreach (Control control in panel19.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel19.Width - currentLoc.X - control.Width, currentLoc.Y);

                    // Set the mirrored location to the control
                    control.Location = mirroredLoc;

                    // Check if the control is a TextBox and set RightToLeft to true
                    if (control is Guna2TextBox textBox)
                    {
                        textBox.RightToLeft = RightToLeft.Yes;
                    }

                    if (control is Guna2DataGridView tabel)
                    {
                        tabel.RightToLeft = RightToLeft.Yes;
                    }
                }
            }
            TableLayoutFill();
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
            Calculation.SelectedIndex = 7;
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
            // SearchDietPlans(guna2DataGridView1, filenodgv, namedgv, agedgv, dietnamedgv);
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
            if (dietplantemplatenamenew.SelectedItem != null)
            {
                DietTemplates selectedTemplate = (DietTemplates)dietplantemplatenamenew.SelectedItem;
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

        private void CheckRows(Guna2DataGridView table)
        {
            while (table.RowCount < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                table.Rows.Add(row);
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
        private void ClearMeals()
        {
            mealar.Text = "";
            mealen.Text = "";
            groupnar.SelectedItem = null;
            groupnen.SelectedItem = null;
            groupcar.SelectedItem = null;
            groupcen.SelectedItem = null;
            caloriesm.Text = "";
            fatsm.Text = "";
            fibersm.Text = "";
            potassiumm.Text = "";
            waterm.Text = "";
            sugerm.Text = "";
            calciumm.Text = "";
            am.Text = "";
            proteinm.Text = "";
            carbsm.Text = "";
            sodiumm.Text = "";
            phosphorusm.Text = "";
            magnesiumm.Text = "";
            ironm.Text = "";
            iodinem.Text = "";
            bm.Text = "";
            notes.Text = "";
            preparation.Text = "";
            classification.SelectedItem = null;

        }




        private void Meals_Click_1(object sender, EventArgs e)
        {
            editmeal = 0;
            selectedRow = -1;
            selectedColumn = -1;
            selectedchart = "";

            ClearSelection();

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

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            if (editmeal == 1)
            {
                if (mealar.Text != "" || mealen.Text != "")
                {
                    ChartSubtract(selectedid.ToString());
                    var itemToUpdate = artificialMappings.Where(item => item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == selectedchart).FirstOrDefault();

                    if (itemToUpdate != null)
                    {
                        itemToUpdate.ID = int.Parse(MealID);
                    }

                    if (languagestatus == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("SELECT MealAr FROM Meal WHERE ID = @MealID", MainClass.con);
                            cmd.Parameters.AddWithValue("@MealID", MealID);

                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (selectedchart == "guna2DataGridView13")
                                    {
                                        guna2DataGridView13.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();
                                    }
                                    else if (selectedchart == "guna2DataGridView15")
                                    {
                                        guna2DataGridView15.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView16")
                                    {
                                        guna2DataGridView16.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView17")
                                    {
                                        guna2DataGridView17.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView18")
                                    {
                                        guna2DataGridView18.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView19")
                                    {
                                        guna2DataGridView19.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView20")
                                    {
                                        guna2DataGridView20.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }



                                }
                                reader.Close();
                                MainClass.con.Close();
                            }


                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                        ChartAdd(MealID);
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("SELECT MealEn FROM Meal WHERE ID = @MealID", MainClass.con);
                            cmd.Parameters.AddWithValue("@MealID", MealID);

                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (selectedchart == "guna2DataGridView13")
                                    {
                                        guna2DataGridView13.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();
                                    }
                                    else if (selectedchart == "guna2DataGridView15")
                                    {
                                        guna2DataGridView15.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView16")
                                    {
                                        guna2DataGridView16.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView17")
                                    {
                                        guna2DataGridView17.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView18")
                                    {
                                        guna2DataGridView18.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView19")
                                    {
                                        guna2DataGridView19.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView20")
                                    {
                                        guna2DataGridView20.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }



                                }
                                reader.Close();
                                MainClass.con.Close();
                            }


                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                        ChartAdd(MealID);
                    }
                }

                tabControl1.SelectedIndex = 8;
                editmeal = 0;
            }
            else
            {
                if (mealar.Text != "" || mealen.Text != "")
                {

                    ArtificialMapping data = new ArtificialMapping();
                    data.ID = int.Parse(MealID);
                    data.Row = selectedRow;
                    data.Col = selectedColumn;
                    data.ChartName = selectedchart;

                    artificialMappings.Add(data);
                    if (languagestatus == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("SELECT MealAr FROM Meal WHERE ID = @MealID", MainClass.con);
                            cmd.Parameters.AddWithValue("@MealID", MealID);

                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (selectedchart == "guna2DataGridView13")
                                    {
                                        guna2DataGridView13.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();
                                    }
                                    else if (selectedchart == "guna2DataGridView15")
                                    {
                                        guna2DataGridView15.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView16")
                                    {
                                        guna2DataGridView16.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView17")
                                    {
                                        guna2DataGridView17.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView18")
                                    {
                                        guna2DataGridView18.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView19")
                                    {
                                        guna2DataGridView19.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView20")
                                    {
                                        guna2DataGridView20.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealAr"].ToString();

                                    }



                                }
                                reader.Close();
                                MainClass.con.Close();
                            }


                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                        ChartAdd(MealID);
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("SELECT MealEn FROM Meal WHERE ID = @MealID", MainClass.con);
                            cmd.Parameters.AddWithValue("@MealID", MealID);

                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (selectedchart == "guna2DataGridView13")
                                    {
                                        guna2DataGridView13.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();
                                    }
                                    else if (selectedchart == "guna2DataGridView15")
                                    {
                                        guna2DataGridView15.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView16")
                                    {
                                        guna2DataGridView16.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView17")
                                    {
                                        guna2DataGridView17.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView18")
                                    {
                                        guna2DataGridView18.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView19")
                                    {
                                        guna2DataGridView19.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }
                                    else if (selectedchart == "guna2DataGridView20")
                                    {
                                        guna2DataGridView20.Rows[selectedRow].Cells[selectedColumn].Value = reader["MealEn"].ToString();

                                    }



                                }
                                reader.Close();
                                MainClass.con.Close();
                            }


                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                        ChartAdd(MealID);
                    }
                }

                tabControl1.SelectedIndex = 8;
            }

        }

        private void ChartAdd(string id)
        {
            double calories = 0;
            double fats = 0;
            double fibers = 0;
            double potassium = 0;
            double water = 0;
            double sugar = 0;
            double calcium = 0;
            double vitaminA = 0;
            double protein = 0;
            double carbohydrates = 0;
            double sodium = 0;
            double phosphorus = 0;
            double magnesium = 0;
            double iron = 0;
            double iodine = 0;
            double vitaminB = 0;
            titlecheck = 0;
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

                        calories = Convert.ToDouble(reader["CALORIES"]);
                        fats = Convert.ToDouble(reader["FATS"]);
                        fibers = Convert.ToDouble(reader["FIBERS"]);
                        potassium = Convert.ToDouble(reader["POTASSIUM"]);
                        water = Convert.ToDouble(reader["WATER"]);
                        sugar = Convert.ToDouble(reader["SUGAR"]);
                        calcium = Convert.ToDouble(reader["CALCIUM"]);
                        vitaminA = Convert.ToDouble(reader["A"]);
                        protein = Convert.ToDouble(reader["PROTEIN"]);
                        carbohydrates = Convert.ToDouble(reader["CARBOHYDRATES"]);
                        sodium = Convert.ToDouble(reader["SODIUM"]);
                        phosphorus = Convert.ToDouble(reader["PHOSPHOR"]);
                        magnesium = Convert.ToDouble(reader["MAGNESIUM"]);
                        iron = Convert.ToDouble(reader["IRON"]);
                        iodine = Convert.ToDouble(reader["IODINE"]);
                        vitaminB = Convert.ToDouble(reader["B"]);

                    }
                    reader.Close();

                    MainClass.con.Close();
                    //extrafunc();

                    //tabControl1.SelectedIndex = 2;
                }


                MainClass.con.Close();


                if (caloried.Text == "" && fatsd.Text == "" && fibersd.Text == "")
                {
                    caloried.Text = calories.ToString();
                    fatsd.Text = fats.ToString();
                    fibersd.Text = fibers.ToString();
                    potassiumd.Text = potassium.ToString();
                    waterd.Text = water.ToString();
                    sugerd.Text = sugar.ToString();
                    calciumd.Text = calcium.ToString();
                    ad.Text = vitaminA.ToString();
                    proteind.Text = protein.ToString();
                    carbsd.Text = carbohydrates.ToString();
                    sodiumd.Text = sodium.ToString();
                    phosphorusd.Text = phosphorus.ToString();
                    magnesiumd.Text = magnesium.ToString();
                    irond.Text = iron.ToString();
                    iodined.Text = iodine.ToString();
                    bd.Text = vitaminB.ToString();
                }
                else
                {
                    double Tcalories = Convert.ToDouble(caloried.Text);
                    double Tfats = Convert.ToDouble(fatsd.Text);
                    double Tfibers = Convert.ToDouble(fibersd.Text);
                    double Tpotassium = Convert.ToDouble(potassiumd.Text);
                    double Twater = Convert.ToDouble(waterd.Text);
                    double Tsugar = Convert.ToDouble(sugerd.Text);
                    double Tcalcium = Convert.ToDouble(calciumd.Text);
                    double TvitaminA = Convert.ToDouble(ad.Text);
                    double Tprotein = Convert.ToDouble(proteind.Text);
                    double Tcarbohydrates = Convert.ToDouble(carbsd.Text);
                    double Tsodium = Convert.ToDouble(sodiumd.Text);
                    double Tphosphorus = Convert.ToDouble(phosphorusd.Text);
                    double Tmagnesium = Convert.ToDouble(magnesiumd.Text);
                    double Tiron = Convert.ToDouble(irond.Text);
                    double Tiodine = Convert.ToDouble(iodined.Text);
                    double TvitaminB = Convert.ToDouble(bd.Text);

                    Tcalories = Tcalories + calories;
                    Tfats = Tfats + fats;
                    Tfibers = Tfibers + fibers;
                    Tpotassium = Tpotassium + potassium;
                    Twater = Twater + water;
                    Tsugar = Tsugar + sugar;
                    Tcalcium = Tcalcium + calcium;
                    TvitaminA = TvitaminA + vitaminA;
                    Tprotein = Tprotein + protein;
                    Tcarbohydrates = Tcarbohydrates + carbohydrates;
                    Tsodium = Tsodium + sodium;
                    Tphosphorus = Tphosphorus + phosphorus;
                    Tmagnesium = Tmagnesium + magnesium;
                    Tiron = Tiron + iron;
                    Tiodine = Tiodine + iodine;
                    TvitaminB = TvitaminB + vitaminB;

                    caloried.Text = Tcalories.ToString();
                    fatsd.Text = Tfats.ToString();
                    fibersd.Text = Tfibers.ToString();
                    potassiumd.Text = Tpotassium.ToString();
                    waterd.Text = Twater.ToString();
                    sugerd.Text = Tsugar.ToString();
                    calciumd.Text = Tcalcium.ToString();
                    ad.Text = TvitaminA.ToString();
                    proteind.Text = Tprotein.ToString();
                    carbsd.Text = Tcarbohydrates.ToString();
                    sodiumd.Text = Tsodium.ToString();
                    phosphorusd.Text = Tphosphorus.ToString();
                    magnesiumd.Text = Tmagnesium.ToString();
                    irond.Text = Tiron.ToString();
                    iodined.Text = Tiodine.ToString();
                    bd.Text = TvitaminB.ToString();


                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void ChartSubtract(string id)
        {
            double calories = 0;
            double fats = 0;
            double fibers = 0;
            double potassium = 0;
            double water = 0;
            double sugar = 0;
            double calcium = 0;
            double vitaminA = 0;
            double protein = 0;
            double carbohydrates = 0;
            double sodium = 0;
            double phosphorus = 0;
            double magnesium = 0;
            double iron = 0;
            double iodine = 0;
            double vitaminB = 0;
            titlecheck = 0;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Meal WHERE ID = @MealID", MainClass.con);
                cmd.Parameters.AddWithValue("@MealID", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls

                        calories = Convert.ToDouble(reader["CALORIES"]);
                        fats = Convert.ToDouble(reader["FATS"]);
                        fibers = Convert.ToDouble(reader["FIBERS"]);
                        potassium = Convert.ToDouble(reader["POTASSIUM"]);
                        water = Convert.ToDouble(reader["WATER"]);
                        sugar = Convert.ToDouble(reader["SUGAR"]);
                        calcium = Convert.ToDouble(reader["CALCIUM"]);
                        vitaminA = Convert.ToDouble(reader["A"]);
                        protein = Convert.ToDouble(reader["PROTEIN"]);
                        carbohydrates = Convert.ToDouble(reader["CARBOHYDRATES"]);
                        sodium = Convert.ToDouble(reader["SODIUM"]);
                        phosphorus = Convert.ToDouble(reader["PHOSPHOR"]);
                        magnesium = Convert.ToDouble(reader["MAGNESIUM"]);
                        iron = Convert.ToDouble(reader["IRON"]);
                        iodine = Convert.ToDouble(reader["IODINE"]);
                        vitaminB = Convert.ToDouble(reader["B"]);

                    }
                    reader.Close();

                    MainClass.con.Close();
                    //extrafunc();

                    //tabControl1.SelectedIndex = 2;
                }


                MainClass.con.Close();

                if (caloried.Text != "" && fatsd.Text != "" && fibersd.Text != "")
                {
                    double Tcalories = Convert.ToDouble(caloried.Text);
                    double Tfats = Convert.ToDouble(fatsd.Text);
                    double Tfibers = Convert.ToDouble(fibersd.Text);
                    double Tpotassium = Convert.ToDouble(potassiumd.Text);
                    double Twater = Convert.ToDouble(waterd.Text);
                    double Tsugar = Convert.ToDouble(sugerd.Text);
                    double Tcalcium = Convert.ToDouble(calciumd.Text);
                    double TvitaminA = Convert.ToDouble(ad.Text);
                    double Tprotein = Convert.ToDouble(proteind.Text);
                    double Tcarbohydrates = Convert.ToDouble(carbsd.Text);
                    double Tsodium = Convert.ToDouble(sodiumd.Text);
                    double Tphosphorus = Convert.ToDouble(phosphorusd.Text);
                    double Tmagnesium = Convert.ToDouble(magnesiumd.Text);
                    double Tiron = Convert.ToDouble(irond.Text);
                    double Tiodine = Convert.ToDouble(iodined.Text);
                    double TvitaminB = Convert.ToDouble(bd.Text);

                    Tcalories = Tcalories - calories;
                    Tfats = Tfats - fats;
                    Tfibers = Tfibers - fibers;
                    Tpotassium = Tpotassium - potassium;
                    Twater = Twater - water;
                    Tsugar = Tsugar - sugar;
                    Tcalcium = Tcalcium - calcium;
                    TvitaminA = TvitaminA - vitaminA;
                    Tprotein = Tprotein - protein;
                    Tcarbohydrates = Tcarbohydrates - carbohydrates;
                    Tsodium = Tsodium - sodium;
                    Tphosphorus = Tphosphorus - phosphorus;
                    Tmagnesium = Tmagnesium - magnesium;
                    Tiron = Tiron - iron;
                    Tiodine = Tiodine - iodine;
                    TvitaminB = TvitaminB - vitaminB;

                    caloried.Text = Tcalories.ToString();
                    fatsd.Text = Tfats.ToString();
                    fibersd.Text = Tfibers.ToString();
                    potassiumd.Text = Tpotassium.ToString();
                    waterd.Text = Twater.ToString();
                    sugerd.Text = Tsugar.ToString();
                    calciumd.Text = Tcalcium.ToString();
                    ad.Text = TvitaminA.ToString();
                    proteind.Text = Tprotein.ToString();
                    carbsd.Text = Tcarbohydrates.ToString();
                    sodiumd.Text = Tsodium.ToString();
                    phosphorusd.Text = Tphosphorus.ToString();
                    magnesiumd.Text = Tmagnesium.ToString();
                    irond.Text = Tiron.ToString();
                    iodined.Text = Tiodine.ToString();
                    bd.Text = TvitaminB.ToString();


                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        static int titlecheck2 = 0;
        static int titlecheck3 = 0;
        private void UpdateChart3(object sender, EventArgs e)
        {
            chart2.Titles.Clear();
            chart3.Titles.Clear();

            // Create a sample DataTable with data (replace this with your data source).
            DataTable dt = new DataTable();
            dt.Columns.Add("Nutrient", typeof(string));
            dt.Columns.Add("Value", typeof(double));

            if (fatsd.Text != "")
            {
                dt.Rows.Add("Fats", double.Parse(fatsd.Text) * 9);
            }

            if (proteind.Text != "")
            {
                dt.Rows.Add("Protein", double.Parse(proteind.Text) * 4);
            }

            if (carbsd.Text != "")
            {
                dt.Rows.Add("Carbohydrates", double.Parse(carbsd.Text) * 4);
            }

            if (chart2.Titles.Count == 0) // Check if there's at least one title
            {
                if (languagestatus == 1)
                {
                    chart2.Titles.Add("القيمة الغذائية");
                }
                else
                {
                    chart2.Titles.Add("Nutrient Chart");
                }
            }

            if (chart2.Legends.Count == 0) // Check if there's at least one legend
            {
                chart2.Legends.Add("Legend");
                chart2.Legends[0].Alignment = StringAlignment.Center;
                chart2.Legends[0].Docking = Docking.Bottom;
            }

            chart2.Titles[0].Alignment = ContentAlignment.TopCenter;

            // Your existing code for chart settings
            chart2.Legends[0].Enabled = true;
            chart2.Legends[0].Alignment = StringAlignment.Center;
            chart2.Legends[0].Docking = Docking.Bottom;

            // Your existing code for chart settings
            chart2.Series.Clear();
            chart2.Palette = ChartColorPalette.Pastel;

            Series series = new Series("Series1");
            series.Points.DataBind(dt.AsEnumerable(), "Nutrient", "Value", "");

            series.ChartType = SeriesChartType.Pie;
            chart2.Series.Add(series);
            chart2.Series[0].Label = "#PERCENT{P0}";
            chart2.Series[0].LegendText = "#VALX";

            // Refresh the chart.
            chart2.Refresh();

            if (chart3.Titles.Count == 0) // Check if there's at least one title
            {
                if (languagestatus == 1)
                {
                    chart3.Titles.Add("القيمة الغذائية");
                }
                else
                {
                    chart3.Titles.Add("Nutrient Chart");
                }
            }

            if (chart3.Legends.Count == 0) // Check if there's at least one legend
            {
                chart3.Legends.Add("Legend");
                chart3.Legends[0].Alignment = StringAlignment.Center;
                chart3.Legends[0].Docking = Docking.Bottom;
            }

            chart3.Titles[0].Alignment = ContentAlignment.TopCenter;

            // Your existing code for chart settings
            chart3.Legends[0].Enabled = true;
            chart3.Legends[0].Alignment = StringAlignment.Center;
            chart3.Legends[0].Docking = Docking.Bottom;

            // Your existing code for chart settings
            chart3.Series.Clear();
            chart3.Palette = ChartColorPalette.Pastel;

            Series series2 = new Series("Series1");
            series2.Points.DataBind(dt.AsEnumerable(), "Nutrient", "Value", "");

            series2.ChartType = SeriesChartType.Pie;
            chart3.Series.Add(series2);
            chart3.Series[0].Label = "#PERCENT{P0}";
            chart3.Series[0].LegendText = "#VALX";

            // Refresh the chart.
            chart3.Refresh();

        }
        private void UpdateChart2(object sender, EventArgs e)
        {
            chart1.Titles.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("Nutrient", typeof(string));
            dt.Columns.Add("Value", typeof(double));

            if (fatsm.Text != "")
            {
                dt.Rows.Add("Fats", double.Parse(fatsm.Text) * 9);
            }

            if (proteinm.Text != "")
            {
                dt.Rows.Add("Protein", double.Parse(proteinm.Text) * 4);
            }

            if (carbsm.Text != "")
            {
                dt.Rows.Add("Carbohydrates", double.Parse(carbsm.Text) * 4);
            }

            if (titlecheck2 == 0)
            {
                titlecheck2 = 1;
            }

            if (titlecheck != 1)
            {
                if (languagestatus == 1)
                {
                    chart1.Titles.Add("القيمة الغذائية");
                }
                else
                {
                    chart1.Titles.Add("Nutrient Chart");
                }
                titlecheck = 1;
            }

            // Ensure there is at least one title before modifying it
            if (chart1.Titles.Count > 0)
            {
                chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
            }

            // Your existing code for chart settings
            chart1.Legends[0].Enabled = true;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Docking = Docking.Bottom;

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



        private void NewSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {

                if (filenon.Text != "")
                {

                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO DietPlan (FILENO,Firstname, Familyname, DietPlanDate, DietPlanTemplateName, DietPlanTemplate, DietPlanDays, Instructions, Gender, Age, MobileNo, PreviousDiePlan, Calories, Fats, Fibers, Potassium, Water, Sugar, Calcium, A, Protein, Carbohydrates, Sodium, Phosphor, Magnesium, Iron, Iodine, B) " +
                            "VALUES (@Fileno, @Firstname, @Familyname, @DietPlanDate, @DietPlanTemplateName, @DietPlanTemplate, @DietPlanDays, @Instructions, @Gender, @Age, @MobileNo, @PreviousDietPlan, @Calories, @Fats, @Fibers, @Potassium, @Water, @Sugar, @Calcium, @A, @Protein, @Carbohydrates, @Sodium, @Phosphor, @Magnesium, @Iron, @Iodine, @B)", MainClass.con);

                        // Assuming appropriate text boxes for each field in the DietPlan table
                        cmd.Parameters.AddWithValue("@Fileno", filenon.Text);
                        cmd.Parameters.AddWithValue("@Firstname", firstnamen.Text);
                        cmd.Parameters.AddWithValue("@Familyname", familynamen.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDate", Convert.ToDateTime(dietplandaten.Value));
                        cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatenamenew.Text);
                        cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplatenew.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDays", dietplandaysnew.Text);
                        cmd.Parameters.AddWithValue("@Instructions", instructionnew.Text);
                        cmd.Parameters.AddWithValue("@Gender", gendern.Text);
                        cmd.Parameters.AddWithValue("@Age", int.Parse(agen.Text));
                        cmd.Parameters.AddWithValue("@MobileNo", mobilenon.Text);
                        cmd.Parameters.AddWithValue("@PreviousDietPlan", previousdietplannew.Text);
                        cmd.Parameters.AddWithValue("@Calories", Convert.ToDouble(caloried.Text));
                        cmd.Parameters.AddWithValue("@Fats", Convert.ToDouble(fatsd.Text));
                        cmd.Parameters.AddWithValue("@Fibers", Convert.ToDouble(fibersd.Text));
                        cmd.Parameters.AddWithValue("@Potassium", Convert.ToDouble(potassiumd.Text));
                        cmd.Parameters.AddWithValue("@Water", Convert.ToDouble(waterd.Text));
                        cmd.Parameters.AddWithValue("@Sugar", Convert.ToDouble(sugerd.Text));
                        cmd.Parameters.AddWithValue("@Calcium", Convert.ToDouble(calciumd.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(ad.Text));
                        cmd.Parameters.AddWithValue("@Protein", Convert.ToDouble(proteind.Text));
                        cmd.Parameters.AddWithValue("@Carbohydrates", Convert.ToDouble(carbsd.Text));
                        cmd.Parameters.AddWithValue("@Sodium", Convert.ToDouble(sodiumd.Text));
                        cmd.Parameters.AddWithValue("@Phosphor", Convert.ToDouble(phosphorusd.Text));
                        cmd.Parameters.AddWithValue("@Magnesium", Convert.ToDouble(magnesiumd.Text));
                        cmd.Parameters.AddWithValue("@Iron", Convert.ToDouble(irond.Text));
                        cmd.Parameters.AddWithValue("@Iodine", Convert.ToDouble(iodined.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bd.Text));

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();


                        firstnamen.Text = "";
                        familynamen.Text = "";
                        dietplantemplatenamenew.Text = "";
                        dietplantemplatenew.SelectedItem = null;
                        dietplandaysnew.SelectedIndex = 6;
                        instructionnew.Text = "";
                        gendern.SelectedItem = null;
                        agen.Text = "";
                        mobilenon.Text = "";
                        previousdietplannew.Text = "";
                        caloried.Text = "";
                        fatsd.Text = "";
                        fibersd.Text = "";
                        potassiumd.Text = "";
                        waterd.Text = "";
                        sugerd.Text = "";
                        calciumd.Text = "";
                        ad.Text = "";
                        proteind.Text = "";
                        carbsd.Text = "";
                        sodiumd.Text = "";
                        phosphorusd.Text = "";
                        magnesiumd.Text = "";
                        irond.Text = "";
                        iodined.Text = "";
                        bd.Text = "";
                        medicalhistoryn.Text = "";

                        MainClass.con.Close();


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }


                    foreach (var item in artificialMappings)
                    {
                        try
                        {
                            MainClass.con.Open();

                            int lastidofDietPlan = GetLastEntryIDForDietPlan();

                            SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, Row, Col, ChartName, MealID) " +
                                "VALUES (@DietPlanID, @Row, @Col, @ChartName, @MealID)", MainClass.con);

                            // Assuming appropriate variables for the values in the DietPlanAction table
                            cmd.Parameters.AddWithValue("@DietPlanID", lastidofDietPlan); // Assuming fileno.Text is convertible to int
                            cmd.Parameters.AddWithValue("@Row", item.Row); // Replace with the actual variable or control for Row
                            cmd.Parameters.AddWithValue("@Col", item.Col); // Replace with the actual variable or control for Col
                            cmd.Parameters.AddWithValue("@ChartName", item.ChartName); // Replace with the actual variable or control for ChartName
                            cmd.Parameters.AddWithValue("@MealID", item.ID); // Replace with the actual variable or control for MealID

                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }

                    filenon.Text = "";
                    MessageBox.Show("Diet Plan added Successfully!");

                    ClearTables();

                    artificialMappings.Clear();

                    TableLayoutFill();

                }
                else
                {
                    MessageBox.Show("Please enter the fileno."); // Or any other required field.
                }

            }
            else
            {

                if (filenon.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE DietPlan SET FIRSTNAME = @Firstname, FAMILYNAME = @Familyname, DietPlanDate = @DietPlanDate, DietPlanTemplateName = @DietPlanTemplateName, DietPlanTemplate = @DietPlanTemplate, DietPlanDays = @DietPlanDays, Instructions = @Instructions, Gender = @Gender, Age = @Age, MobileNo = @MobileNo, PreviousDiePlan = @PreviousDietPlan, CALORIES = @Calories, FATS = @Fats, FIBERS = @Fibers, POTASSIUM = @Potassium, WATER = @Water, SUGAR = @Sugar, CALCIUM = @Calcium, A = @A, PROTEIN = @Protein, CARBOHYDRATES = @Carbohydrates, SODIUM = @Sodium, PHOSPHOR = @Phosphor, MAGNESIUM = @Magnesium, IRON = @Iron, IODINE = @Iodine, B = @B WHERE FILENO = @Fileno", MainClass.con);

                        // Assuming appropriate text boxes for each field in the DietPlan table
                        cmd.Parameters.AddWithValue("@Fileno", filenon.Text);
                        cmd.Parameters.AddWithValue("@Firstname", firstnamen.Text);
                        cmd.Parameters.AddWithValue("@Familyname", familynamen.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDate", Convert.ToDateTime(dietplandaten.Value));
                        cmd.Parameters.AddWithValue("@DietPlanTemplateName", dietplantemplatenamenew.Text);
                        cmd.Parameters.AddWithValue("@DietPlanTemplate", dietplantemplatenew.Text);
                        cmd.Parameters.AddWithValue("@DietPlanDays", dietplandaysnew.Text);
                        cmd.Parameters.AddWithValue("@Instructions", instructionnew.Text);
                        cmd.Parameters.AddWithValue("@Gender", gendern.Text);
                        cmd.Parameters.AddWithValue("@Age", int.Parse(agen.Text));
                        cmd.Parameters.AddWithValue("@MobileNo", mobilenon.Text);
                        cmd.Parameters.AddWithValue("@PreviousDietPlan", previousdietplannew.Text);
                        cmd.Parameters.AddWithValue("@Calories", Convert.ToDouble(caloried.Text));
                        cmd.Parameters.AddWithValue("@Fats", Convert.ToDouble(fatsd.Text));
                        cmd.Parameters.AddWithValue("@Fibers", Convert.ToDouble(fibersd.Text));
                        cmd.Parameters.AddWithValue("@Potassium", Convert.ToDouble(potassiumd.Text));
                        cmd.Parameters.AddWithValue("@Water", Convert.ToDouble(waterd.Text));
                        cmd.Parameters.AddWithValue("@Sugar", Convert.ToDouble(sugerd.Text));
                        cmd.Parameters.AddWithValue("@Calcium", Convert.ToDouble(calciumd.Text));
                        cmd.Parameters.AddWithValue("@A", Convert.ToDouble(ad.Text));
                        cmd.Parameters.AddWithValue("@Protein", Convert.ToDouble(proteind.Text));
                        cmd.Parameters.AddWithValue("@Carbohydrates", Convert.ToDouble(carbsd.Text));
                        cmd.Parameters.AddWithValue("@Sodium", Convert.ToDouble(sodiumd.Text));
                        cmd.Parameters.AddWithValue("@Phosphor", Convert.ToDouble(phosphorusd.Text));
                        cmd.Parameters.AddWithValue("@Magnesium", Convert.ToDouble(magnesiumd.Text));
                        cmd.Parameters.AddWithValue("@Iron", Convert.ToDouble(irond.Text));
                        cmd.Parameters.AddWithValue("@Iodine", Convert.ToDouble(iodined.Text));
                        cmd.Parameters.AddWithValue("@B", Convert.ToDouble(bd.Text));

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();


                        firstnamen.Text = "";
                        familynamen.Text = "";
                        dietplantemplatenamenew.SelectedItem = null;
                        dietplantemplatenew.SelectedItem = null;
                        dietplandaysnew.SelectedIndex = 6;
                        instructionnew.SelectedItem = null;
                        gendern.SelectedItem = null;
                        agen.Text = "";
                        mobilenon.Text = "";
                        previousdietplannew.Text = "";
                        caloried.Text = "";
                        fatsd.Text = "";
                        fibersd.Text = "";
                        potassiumd.Text = "";
                        waterd.Text = "";
                        sugerd.Text = "";
                        calciumd.Text = "";
                        ad.Text = "";
                        proteind.Text = "";
                        carbsd.Text = "";
                        sodiumd.Text = "";
                        phosphorusd.Text = "";
                        magnesiumd.Text = "";
                        irond.Text = "";
                        iodined.Text = "";
                        bd.Text = "";
                        medicalhistoryn.Text = "";

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
                        cmdingredients.Parameters.AddWithValue("@ID", dietplanID); // Assuming the Ingredient ID is in the first cell of the selected row.
                        cmdingredients.ExecuteNonQuery();
                        //MessageBox.Show("Meal removed successfully");                     
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        foreach (var item in artificialMappings)
                        {
                            try
                            {
                                MainClass.con.Open();

                                int lastidofDietPlan = GetLastEntryIDForDietPlan();

                                SqlCommand cmd = new SqlCommand("INSERT INTO DietPlanAction (DietPlanID, Row, Col, ChartName, MealID) " +
                                    "VALUES (@DietPlanID, @Row, @Col, @ChartName, @MealID)", MainClass.con);

                                // Assuming appropriate variables for the values in the DietPlanAction table
                                cmd.Parameters.AddWithValue("@DietPlanID", lastidofDietPlan); // Assuming fileno.Text is convertible to int
                                cmd.Parameters.AddWithValue("@Row", item.Row); // Replace with the actual variable or control for Row
                                cmd.Parameters.AddWithValue("@Col", item.Col); // Replace with the actual variable or control for Col
                                cmd.Parameters.AddWithValue("@ChartName", item.ChartName); // Replace with the actual variable or control for ChartName
                                cmd.Parameters.AddWithValue("@MealID", item.ID); // Replace with the actual variable or control for MealID

                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred: " + ex.Message);
                            }
                        }

                        filenon.Text = "";
                        MessageBox.Show("Diet Plan updated Successfully!");
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    ClearTables();

                    artificialMappings.Clear();

                    TableLayoutFill();

                    NewSave.Text = "Save Plan";
                }
                else
                {
                    MessageBox.Show("Please enter the first name."); // Or any other required field.
                }
                edit = 0;
            }
        }

        public int GetLastEntryIDForDietPlan()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM DietPlan ORDER BY ID DESC", MainClass.con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0); // Get the ID
                    }
                }
            }

            return -1; // Return -1 if no entries found
        }
        private void dietplantemplatenew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dietplantemplatenamenew.SelectedItem != null)
            {
                DietTemplates selectedTemplate = (DietTemplates)dietplantemplatenamenew.SelectedItem;
                int selectedID = selectedTemplate.ID;

                if (selectedID == 0)
                {
                    dietplandaysnew.SelectedIndex = 6;
                    dietplantemplatenew.SelectedItem = null;
                    instructionnew.Text = "";
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

                            dietplantemplatenew.Text = dietplanTemplate;
                            dietplandaysnew.Text = dietplanDays;
                            instructionnew.Text = Instruct;
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
        static int selectedid = 0;
        static int editmeal = 0;
        static string companynamefooter = "";
        static string companynumber = "";
        static string companyemail = "";
        private void SettingCoverInfo()
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT COMPANYNAME,BRANCH,EMAIL,LANDLINE,MOBILE,POBOX,TRADENO,WELCOME,LOGO,Room1,Room2,Room3,Room4 FROM SETTINGS", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    companyname.Text = dr["COMPANYNAME"].ToString();
                    companynamefooter = companyname.Text;
                    welcomewords.Text = dr["WELCOME"].ToString();
                    pictureBox1.ImageLocation = dr["LOGO"].ToString();
                    companynumber = dr["LANDLINE"].ToString();
                    companyemail = dr["EMAIL"].ToString();
                }

                dr.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }


        }


        private void filenon_TextChanged(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int stringappendcheck = 0;
            if (filenon.Text != "")
            {
                int value = int.Parse(filenon.Text);

                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    SqlCommand cmd2 = new SqlCommand("SELECT  FIRSTNAME, FAMILYNAME, MOBILENO, GENDER, AGE, NutritionistName FROM CUSTOMER " +
                        "WHERE FILENO = @fileno", MainClass.con);

                    cmd2.Parameters.AddWithValue("@fileno", value);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        // Assign values from the reader to the respective text boxes
                        firstnamen.Text = reader2["FIRSTNAME"].ToString();
                        familynamen.Text = reader2["FAMILYNAME"].ToString();
                        mobilenon.Text = reader2["MOBILENO"].ToString();
                        gendern.Text = reader2["GENDER"].ToString();
                        agen.Text = reader2["AGE"].ToString();
                        nutritionistcover.Text = reader2["NutritionistName"].ToString();


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

                namecover.Text = firstnamen.Text + " " + familynamen.Text;
                covername.Text = namecover.Text;
                agecover.Text = agen.Text;
                numbercover.Text = mobilenon.Text;
                currentdatecover.Text = DateTime.Now.ToShortDateString();


                try
                {
                    string customerIDToEdit = dietPlanIDToEdit;
                    string customerFilenoToEdit = dietPlanIDToEdit;

                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM MedicalHistory WHERE FILENO = @CustomerID", MainClass.con);
                    cmd.Parameters.AddWithValue("@CustomerID", value); // Replace 'customerIdToFind' with the actual ID you want to find.

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
                                stringappendcheck++;
                                stringBuilder.Append(dbstatus);
                                stringBuilder.AppendLine();
                            }
                        }
                    }

                    reader.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM DiseaseHistory WHERE FILENO = @CustomerID", MainClass.con);
                    cmd2.Parameters.AddWithValue("@CustomerID", value); // Replace 'customerIdToFind' with the actual ID you want to find.
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
                        stringappendcheck++;
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
                    cmd3.Parameters.AddWithValue("@CustomerID", value); // Replace 'customerIdToFind' with the actual ID you want to find.
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
                        stringappendcheck++;
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
                    cmd5.Parameters.AddWithValue("@CustomerID", value); // Replace 'customerIdToFind' with the actual ID you want to find.
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
                        stringappendcheck++;
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
                    cmd6.Parameters.AddWithValue("@CustomerID", value); // Replace 'customerIdToFind' with the actual ID you want to find.
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
                        stringappendcheck++;
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
                    cmd7.Parameters.AddWithValue("@CustomerID", value); // Replace 'customerIdToFind' with the actual ID you want to find.
                    SqlDataReader reader7 = cmd7.ExecuteReader();
                    if (reader7.HasRows)
                    {
                        stringappendcheck++;
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
                    if (stringappendcheck != 0)
                    {
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append(".");
                        medicalhistoryn.Text = stringBuilder.ToString();
                    }

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
                firstnamen.Text = "";
                familynamen.Text = "";
                mobilenon.Text = "";
                gendern.SelectedItem = null;
                medicalhistoryn.Text = "";
                agen.Text = "";

            }
        }
        static int dietplanID = 0;
        List<int> Meadids = new List<int>();

        static string dater;
        static string firstnamer;
        static string lastnamer;
        static string ager;
        static string numberr;

        private void SearchDIetPlan_Click(object sender, EventArgs e)
        {
            string template = null;
            string PreviousPlan = null;
            string instruction = null;
            try
            {

                dietPlanIDToEdit = filenon.Text.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlan WHERE FILENO = @DietPlanID", MainClass.con);
                cmd.Parameters.AddWithValue("@DietPlanID", dietPlanIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dietplanID = int.Parse(reader["ID"].ToString());
                        template = reader["DietPlanTemplateName"].ToString();
                        dietplantemplatenew.Text = reader["DietPlanTemplate"].ToString();
                        dietplandaten.Value = Convert.ToDateTime(reader["DIETPLANDATE"]);
                        dietplandaysnew.Text = reader["DietPlanDays"].ToString();
                        instruction = reader["Instructions"].ToString();
                        PreviousPlan = reader["PreviousDiePlan"].ToString();
                        caloried.Text = reader["CALORIES"].ToString();
                        fatsd.Text = reader["FATS"].ToString();
                        fibersd.Text = reader["FIBERS"].ToString();
                        potassiumd.Text = reader["POTASSIUM"].ToString();
                        waterd.Text = reader["WATER"].ToString();
                        sugerd.Text = reader["SUGAR"].ToString();
                        calciumd.Text = reader["CALCIUM"].ToString();
                        ad.Text = reader["A"].ToString();
                        proteind.Text = reader["PROTEIN"].ToString();
                        carbsd.Text = reader["CARBOHYDRATES"].ToString();
                        sodiumd.Text = reader["SODIUM"].ToString();
                        phosphorusd.Text = reader["PHOSPHOR"].ToString();
                        magnesiumd.Text = reader["MAGNESIUM"].ToString();
                        irond.Text = reader["IRON"].ToString();
                        iodined.Text = reader["IODINE"].ToString();
                        bd.Text = reader["B"].ToString();
                    }
                    reader.Close();
                    MainClass.con.Close();
                    dietplantemplatenamenew.Text = template;
                    previousdietplannew.Text = PreviousPlan;
                    instructionnew.Text = instruction;
                    MealsFetcher();
                    NewSave.Enabled = false;




                    //tabControl1.SelectedIndex = 1;
                    //RowsChecker();
                }
                else
                {
                    reader.Close();
                    MainClass.con.Close();
                    NewSave.Enabled = true;




                    MessageBox.Show("No Diet Plan found");
                }


            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void NutrientsClear()
        {
            caloried.Text = "0";
            fatsd.Text = "0";
            fibersd.Text = "0";
            potassiumd.Text = "0";
            waterd.Text = "0";
            sugerd.Text = "0";
            calciumd.Text = "0";
            ad.Text = "0";
            proteind.Text = "0";
            carbsd.Text = "0";
            sodiumd.Text = "0";
            phosphorusd.Text = "0";
            magnesiumd.Text = "0";
            irond.Text = "0";
            iodined.Text = "0";
            bd.Text = "0";
        }

        private void MealsFetcher()
        {
            artificialMappings.Clear();

            ClearTables();

            TableLayoutFill();

            NutrientsClear();

            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlanAction WHERE DIetPlanID = @DietPlanID", MainClass.con);
            cmd.Parameters.AddWithValue("@DietPlanID", dietplanID);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    ArtificialMapping data = new ArtificialMapping();

                    data.Row = int.Parse(reader["Row"].ToString());
                    data.Col = int.Parse(reader["Col"].ToString());
                    data.ChartName = reader["ChartName"].ToString();
                    data.ID = int.Parse(reader["MealID"].ToString());

                    artificialMappings.Add(data);
                }
                reader.Close();
                MainClass.con.Close();



                foreach (var item in artificialMappings)
                {
                    if (languagestatus == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd2 = new SqlCommand("SELECT MealAr FROM Meal WHERE ID = @MealID", MainClass.con);
                            cmd2.Parameters.AddWithValue("@MealID", item.ID);

                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    if (item.ChartName == "guna2DataGridView13")
                                    {
                                        guna2DataGridView13.Rows[item.Row].Cells[item.Col].Value = reader2["MealAr"].ToString();
                                    }
                                    else if (item.ChartName == "guna2DataGridView15")
                                    {
                                        guna2DataGridView15.Rows[item.Row].Cells[item.Col].Value = reader2["MealAr"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView16")
                                    {
                                        guna2DataGridView16.Rows[item.Row].Cells[item.Col].Value = reader2["MealAr"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView17")
                                    {
                                        guna2DataGridView17.Rows[item.Row].Cells[item.Col].Value = reader2["MealAr"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView18")
                                    {
                                        guna2DataGridView18.Rows[item.Row].Cells[item.Col].Value = reader2["MealAr"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView19")
                                    {
                                        guna2DataGridView19.Rows[item.Row].Cells[item.Col].Value = reader2["MealAr"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView20")
                                    {
                                        guna2DataGridView20.Rows[item.Row].Cells[item.Col].Value = reader2["MealAr"].ToString();

                                    }



                                }
                                reader2.Close();
                                MainClass.con.Close();
                            }


                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                        MealID = item.ID.ToString();
                        ChartAdd(item.ID.ToString());
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd2 = new SqlCommand("SELECT MealEn FROM Meal WHERE ID = @MealID", MainClass.con);
                            cmd2.Parameters.AddWithValue("@MealID", item.ID);

                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    if (item.ChartName == "guna2DataGridView13")
                                    {
                                        guna2DataGridView13.Rows[item.Row].Cells[item.Col].Value = reader2["MealEn"].ToString();
                                    }
                                    else if (item.ChartName == "guna2DataGridView15")
                                    {
                                        guna2DataGridView15.Rows[item.Row].Cells[item.Col].Value = reader2["MealEn"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView16")
                                    {
                                        guna2DataGridView16.Rows[item.Row].Cells[item.Col].Value = reader2["MealEn"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView17")
                                    {
                                        guna2DataGridView17.Rows[item.Row].Cells[item.Col].Value = reader2["MealEn"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView18")
                                    {
                                        guna2DataGridView18.Rows[item.Row].Cells[item.Col].Value = reader2["MealEn"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView19")
                                    {
                                        guna2DataGridView19.Rows[item.Row].Cells[item.Col].Value = reader2["MealEn"].ToString();

                                    }
                                    else if (item.ChartName == "guna2DataGridView20")
                                    {
                                        guna2DataGridView20.Rows[item.Row].Cells[item.Col].Value = reader2["MealEn"].ToString();

                                    }



                                }
                                reader2.Close();
                                MainClass.con.Close();
                            }


                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                        MealID = item.ID.ToString();
                        ChartAdd(item.ID.ToString());
                    }
                }


                NewSave.Enabled = false;



            }
            else
            {
                reader.Close();
                MainClass.con.Close();
                NewSave.Enabled = true;

            }
        }

        private void EditBTnNew_Click(object sender, EventArgs e)
        {
            NewSave.Enabled = true;

            edit = 1;
            NewSave.Text = "Update Plan";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            artificialMappings.Clear();

            firstnamen.Text = "";
            familynamen.Text = "";
            dietplantemplatenamenew.Text = "";
            dietplantemplatenew.SelectedItem = null;
            dietplandaysnew.SelectedIndex = 6;
            instructionnew.SelectedItem = null;
            gendern.SelectedItem = null;
            agen.Text = "";
            mobilenon.Text = "";
            previousdietplannew.Text = "";
            caloried.Text = "";
            fatsd.Text = "";
            fibersd.Text = "";
            potassiumd.Text = "";
            waterd.Text = "";
            sugerd.Text = "";
            calciumd.Text = "";
            ad.Text = "";
            proteind.Text = "";
            carbsd.Text = "";
            sodiumd.Text = "";
            phosphorusd.Text = "";
            magnesiumd.Text = "";
            irond.Text = "";
            iodined.Text = "";
            bd.Text = "";
            medicalhistoryn.Text = "";


            ClearTables();
            NewSave.Text = "Save Plan";
            string ingredientIDToDelete = "0";

            if (filenon.Text != "")
            {
                ingredientIDToDelete = filenon.Text.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.
                DialogResult result = MessageBox.Show("Are you sure you want to delete Diet Plan with file no : " + ingredientIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM DietPlan WHERE ID = @ID", MainClass.con);
                        cmd.Parameters.AddWithValue("ID", dietplanID); // Assuming the Ingredient ID is in the first cell of the selected row.
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
                        cmd.Parameters.AddWithValue("ID", dietplanID); // Assuming the Ingredient ID is in the first cell of the selected row.
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
                filenon.Text = "";
                TableLayoutFill();
            }
            else
            {
                MessageBox.Show("Insert filen no!");
            }

            NewSave.Enabled = true;




            edit = 1;
            NewSave.Text = "Save Plan";
            edit = 0;


        }
        private void ShowDietPlans(DataGridView dgv, DataGridViewColumn iddgv, DataGridViewColumn no, DataGridViewColumn name, DataGridViewColumn age, DataGridViewColumn date, string id)
        {

            try
            {
                MainClass.con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID,FILENO, FIRSTNAME,AGE, DIETPLANDATE FROM DietPlan " +
                    " WHERE FILENO = @dietplan", MainClass.con);

                cmd.Parameters.AddWithValue("@dietplan", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Modify the column names to match your data grid view
                iddgv.DataPropertyName = dt.Columns["ID"].ToString();
                no.DataPropertyName = dt.Columns["FILENO"].ToString();
                name.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                age.DataPropertyName = dt.Columns["AGE"].ToString();
                date.DataPropertyName = dt.Columns["DIETPLANDATE"].ToString();



                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void NewDietPlan_Click(object sender, EventArgs e)
        {
            NewSave.Enabled = true;




            NewSave.Text = "Save Plan";
            edit = 0;
            artificialMappings.Clear();

            filenon.Text = "";
            firstnamen.Text = "";
            familynamen.Text = "";
            dietplantemplatenamenew.Text = "";
            dietplantemplatenew.SelectedItem = null;
            dietplandaysnew.SelectedIndex = 6;
            instructionnew.SelectedItem = null;
            gendern.SelectedItem = null;
            agen.Text = "";
            mobilenon.Text = "";
            previousdietplannew.Text = "";
            caloried.Text = "";
            fatsd.Text = "";
            fibersd.Text = "";
            potassiumd.Text = "";
            waterd.Text = "";
            sugerd.Text = "";
            calciumd.Text = "";
            ad.Text = "";
            proteind.Text = "";
            carbsd.Text = "";
            sodiumd.Text = "";
            phosphorusd.Text = "";
            magnesiumd.Text = "";
            irond.Text = "";
            iodined.Text = "";
            bd.Text = "";
            medicalhistoryn.Text = "";


            ClearTables();

            TableLayoutFill();
        }

        static int filenoforhistory = 0;
        private void History_Click(object sender, EventArgs e)
        {
            if (filenon.Text != "")
            {
                guna2DataGridView1.Visible = true;
                ShowDietPlans(guna2DataGridView1, dpiddgv, filenodgv, namedgv, agedgv, dietnamedgv, filenon.Text);
                filenoforhistory = int.Parse(filenon.Text);
                guna2DataGridView1.ClearSelection();
                tabControl1.SelectedIndex = 7;
            }
            else
            {
                MessageBox.Show("Enter Fileno First!");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void deletehistory_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1) // Changed from SelectedRows to SelectedCells
                    {



                        string appointmentIDToDelete = guna2DataGridView1.CurrentRow.Cells["dpiddgv"].Value.ToString(); // Assuming the Appointment ID is in a column named "Id"

                        DialogResult result = MessageBox.Show("Are you sure you want to delete diet plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM DietPlan WHERE Id = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", appointmentIDToDelete); // Assuming the Appointment ID is in a column named "Id"
                                cmd.ExecuteNonQuery();
                                //MessageBox.Show("Appointment removed successfully");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
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
                                cmd.Parameters.AddWithValue("@ID", appointmentIDToDelete); // Assuming the Appointment ID is in a column named "Id"
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("removed suuccessfully!");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
                                ShowDietPlans(guna2DataGridView1, dpiddgv, filenodgv, namedgv, agedgv, dietnamedgv, filenoforhistory.ToString());
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

        private void VIew_Click(object sender, EventArgs e)
        {
            string template = null;
            string PreviousPlan = null;
            try
            {

                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DietPlan WHERE ID = @DietPlanID", MainClass.con);
                cmd.Parameters.AddWithValue("@DietPlanID", guna2DataGridView1.CurrentRow.Cells["dpiddgv"].Value.ToString());

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dietplanID = int.Parse(reader["ID"].ToString());
                        template = reader["DietPlanTemplateName"].ToString();
                        dietplantemplatenew.Text = reader["DietPlanTemplate"].ToString();
                        dietplandaten.Value = Convert.ToDateTime(reader["DIETPLANDATE"]);
                        dietplandaysnew.Text = reader["DietPlanDays"].ToString();
                        instructionnew.Text = reader["Instructions"].ToString();
                        PreviousPlan = reader["PreviousDiePlan"].ToString();
                        caloried.Text = reader["CALORIES"].ToString();
                        fatsd.Text = reader["FATS"].ToString();
                        fibersd.Text = reader["FIBERS"].ToString();
                        potassiumd.Text = reader["POTASSIUM"].ToString();
                        waterd.Text = reader["WATER"].ToString();
                        sugerd.Text = reader["SUGAR"].ToString();
                        calciumd.Text = reader["CALCIUM"].ToString();
                        ad.Text = reader["A"].ToString();
                        proteind.Text = reader["PROTEIN"].ToString();
                        carbsd.Text = reader["CARBOHYDRATES"].ToString();
                        sodiumd.Text = reader["SODIUM"].ToString();
                        phosphorusd.Text = reader["PHOSPHOR"].ToString();
                        magnesiumd.Text = reader["MAGNESIUM"].ToString();
                        irond.Text = reader["IRON"].ToString();
                        iodined.Text = reader["IODINE"].ToString();
                        bd.Text = reader["B"].ToString();
                    }
                    reader.Close();
                    MainClass.con.Close();
                    dietplantemplatenamenew.Text = template;
                    previousdietplannew.Text = PreviousPlan;
                    MealsFetcher();

                    //tabControl1.SelectedIndex = 1;
                    //RowsChecker();
                }
                else
                {
                    reader.Close();
                    MainClass.con.Close();
                    NewSave.Enabled = true;




                    MessageBox.Show("No Diet Plan found for file no :" + fileno.Text);
                }


            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            NewSave.Visible = false;
            SearchDIetPlan.Visible = false;
            EditBTnNew.Visible = false;
            guna2Button4.Visible = false;
            NewDietPlan.Visible = false;
            History.Visible = false;

            viewclose.Visible = true;
            tabControl1.SelectedIndex = 5;

        }

        private void viewclose_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
            NewSave.Visible = true;
            SearchDIetPlan.Visible = true;
            EditBTnNew.Visible = true;
            guna2Button4.Visible = true;
            NewDietPlan.Visible = true;
            History.Visible = true;

            viewclose.Visible = false;
            NewSave.Enabled = true;


            NutrientsClear();
            ClearTables();
            TableLayoutFill();
        }

        private void SearchMeals(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn mealarfunc, DataGridViewColumn mealenfunc, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {
            string mealName = mealar.Text;
            string groupArName = mealen.Text;

            if (mealName != "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, MealAr,MealEn, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM,PROTEIN FROM Meal " +
                        " WHERE (MealAr LIKE @MealName) AND (MealEn LIKE @GroupArName)", MainClass.con);

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
                        " WHERE MealEn LIKE @GroupArName", MainClass.con);

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
                MessageBox.Show("Fill Meal Ar or Meal En");
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);

            }
        }

        private void MealSearch_Click(object sender, EventArgs e)
        {
            SearchMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
        }

        private void calculationnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            NutrientsClear();
            string selectedValue = calculationnew.Text;
            if (selectedValue == "1st Day" || selectedValue == "اليوم الاول")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView13")
                    {
                        ChartAdd(item.ID.ToString());
                    }
                }
            }
            else if (selectedValue == "2nd Day" || selectedValue == "اليوم الثاني")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView15")
                    {
                        ChartAdd(item.ID.ToString());
                    }
                }
            }
            else if (selectedValue == "3rd Day" || selectedValue == "اليوم الثالث")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView16")
                    {
                        ChartAdd(item.ID.ToString());
                    }
                }
            }
            else if (selectedValue == "4th Day" || selectedValue == "اليوم الرابع ")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView17")
                    {
                        ChartAdd(item.ID.ToString());
                    }
                }
            }
            else if (selectedValue == "5th Day" || selectedValue == "اليوم الخامس")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView18")
                    {
                        ChartAdd(item.ID.ToString());
                    }
                }
            }
            else if (selectedValue == "6th Day" || selectedValue == "اليوم السادس")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView19")
                    {
                        ChartAdd(item.ID.ToString());
                    }
                }
            }
            else if (selectedValue == "7th Day" || selectedValue == "اليوم السابع ")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView20")
                    {
                        ChartAdd(item.ID.ToString());
                    }
                }
            }
            else if (selectedValue == "All")
            {
                foreach (var item in artificialMappings)
                {
                    ChartAdd(item.ID.ToString());
                }
            }
        }

        private void dietplandaysnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = dietplandaysnew.Text;



            List<ArtificialMapping> removelist = new List<ArtificialMapping>();

            int call = -1;

            if (selectedValue == "1")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName != "guna2DataGridView13")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }

                guna2DataGridView15.Visible = false;
                guna2DataGridView16.Visible = false;
                guna2DataGridView17.Visible = false;
                guna2DataGridView18.Visible = false;
                guna2DataGridView19.Visible = false;
                guna2DataGridView20.Visible = false;

                day2.Visible = false;
                day3.Visible = false;
                day4.Visible = false;
                day5.Visible = false;
                day6.Visible = false;
                day7.Visible = false;
            }
            else if (selectedValue == "2")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName != "guna2DataGridView13" &&
                        item.ChartName != "guna2DataGridView15")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }

                guna2DataGridView16.Visible = false;
                guna2DataGridView17.Visible = false;
                guna2DataGridView18.Visible = false;
                guna2DataGridView19.Visible = false;
                guna2DataGridView20.Visible = false;

                day3.Visible = false;
                day4.Visible = false;
                day5.Visible = false;
                day6.Visible = false;
                day7.Visible = false;
            }
            else if (selectedValue == "3")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName != "guna2DataGridView13" &&
                        item.ChartName != "guna2DataGridView15" &&
                        item.ChartName != "guna2DataGridView16")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }

                guna2DataGridView17.Visible = false;
                guna2DataGridView18.Visible = false;
                guna2DataGridView19.Visible = false;
                guna2DataGridView20.Visible = false;

                day4.Visible = false;
                day5.Visible = false;
                day6.Visible = false;
                day7.Visible = false;
            }
            else if (selectedValue == "4")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName != "guna2DataGridView13" &&
                        item.ChartName != "guna2DataGridView15" &&
                        item.ChartName != "guna2DataGridView16" &&
                        item.ChartName != "guna2DataGridView17")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }

                guna2DataGridView18.Visible = false;
                guna2DataGridView19.Visible = false;
                guna2DataGridView20.Visible = false;

                day5.Visible = false;
                day6.Visible = false;
                day7.Visible = false;
            }
            else if (selectedValue == "5")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView19" ||
                        item.ChartName == "guna2DataGridView20")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }

                guna2DataGridView19.Visible = false;
                guna2DataGridView20.Visible = false;

                day6.Visible = false;
                day7.Visible = false;
            }
            else if (selectedValue == "6")
            {
                foreach (var item in artificialMappings)
                {
                    if (item.ChartName == "guna2DataGridView20")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                guna2DataGridView20.Visible = false;

                day7.Visible = false;
            }
            else if (selectedValue == "7")
            {
                guna2DataGridView13.Visible = true;
                guna2DataGridView15.Visible = true;
                guna2DataGridView16.Visible = true;
                guna2DataGridView17.Visible = true;
                guna2DataGridView18.Visible = true;
                guna2DataGridView19.Visible = true;
                guna2DataGridView20.Visible = true;

                day1.Visible = true;
                day2.Visible = true;
                day3.Visible = true;
                day4.Visible = true;
                day5.Visible = true;
                day6.Visible = true;
                day7.Visible = true;
            }


            if (call == 1)
            {

                foreach (var item in removelist)
                {
                    if (item.ChartName == "guna2DataGridView13")
                    {
                        guna2DataGridView13.Rows[item.Row].Cells[item.Col].Value = "";


                    }
                    else if (item.ChartName == "guna2DataGridView15")
                    {
                        guna2DataGridView15.Rows[item.Row].Cells[item.Col].Value = "";

                    }
                    else if (item.ChartName == "guna2DataGridView16")
                    {
                        guna2DataGridView16.Rows[item.Row].Cells[item.Col].Value = "";

                    }
                    else if (item.ChartName == "guna2DataGridView17")
                    {
                        guna2DataGridView17.Rows[item.Row].Cells[item.Col].Value = "";

                    }
                    else if (item.ChartName == "guna2DataGridView18")
                    {
                        guna2DataGridView18.Rows[item.Row].Cells[item.Col].Value = "";

                    }
                    else if (item.ChartName == "guna2DataGridView19")
                    {
                        guna2DataGridView19.Rows[item.Row].Cells[item.Col].Value = "";

                    }
                    else if (item.ChartName == "guna2DataGridView20")
                    {
                        guna2DataGridView20.Rows[item.Row].Cells[item.Col].Value = "";

                    }
                    artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                }
                removelist.Clear();

            }

            //if (selectedValue == "1")
            //{
            //    guna2DataGridView7.Columns[1].Visible = true;
            //    guna2DataGridView8.Columns[1].Visible = true;
            //    guna2DataGridView9.Columns[1].Visible = true;
            //    guna2DataGridView10.Columns[1].Visible = true;
            //    guna2DataGridView11.Columns[1].Visible = true;

            //    guna2DataGridView7.Columns[2].Visible = false;
            //    guna2DataGridView8.Columns[2].Visible = false;
            //    guna2DataGridView9.Columns[2].Visible = false;
            //    guna2DataGridView10.Columns[2].Visible = false;
            //    guna2DataGridView11.Columns[2].Visible = false;

            //    guna2DataGridView7.Columns[3].Visible = false;
            //    guna2DataGridView8.Columns[3].Visible = false;
            //    guna2DataGridView9.Columns[3].Visible = false;
            //    guna2DataGridView10.Columns[3].Visible = false;
            //    guna2DataGridView11.Columns[3].Visible = false;

            //    guna2DataGridView7.Columns[4].Visible = false;
            //    guna2DataGridView8.Columns[4].Visible = false;
            //    guna2DataGridView9.Columns[4].Visible = false;
            //    guna2DataGridView10.Columns[4].Visible = false;
            //    guna2DataGridView11.Columns[4].Visible = false;

            //    guna2DataGridView7.Columns[5].Visible = false;
            //    guna2DataGridView8.Columns[5].Visible = false;
            //    guna2DataGridView9.Columns[5].Visible = false;
            //    guna2DataGridView10.Columns[5].Visible = false;
            //    guna2DataGridView11.Columns[5].Visible = false;

            //    guna2DataGridView7.Columns[6].Visible = false;
            //    guna2DataGridView8.Columns[6].Visible = false;
            //    guna2DataGridView9.Columns[6].Visible = false;
            //    guna2DataGridView10.Columns[6].Visible = false;
            //    guna2DataGridView11.Columns[6].Visible = false;

            //    guna2DataGridView7.Columns[7].Visible = false;
            //    guna2DataGridView8.Columns[7].Visible = false;
            //    guna2DataGridView9.Columns[7].Visible = false;
            //    guna2DataGridView10.Columns[7].Visible = false;
            //    guna2DataGridView11.Columns[7].Visible = false;
            //}
            //else if (selectedValue == "2")
            //{
            //    guna2DataGridView7.Columns[1].Visible = true;
            //    guna2DataGridView8.Columns[1].Visible = true;
            //    guna2DataGridView9.Columns[1].Visible = true;
            //    guna2DataGridView10.Columns[1].Visible = true;
            //    guna2DataGridView11.Columns[1].Visible = true;

            //    guna2DataGridView7.Columns[2].Visible = true;
            //    guna2DataGridView8.Columns[2].Visible = true;
            //    guna2DataGridView9.Columns[2].Visible = true;
            //    guna2DataGridView10.Columns[2].Visible = true;
            //    guna2DataGridView11.Columns[2].Visible = true;

            //    guna2DataGridView7.Columns[3].Visible = false;
            //    guna2DataGridView8.Columns[3].Visible = false;
            //    guna2DataGridView9.Columns[3].Visible = false;
            //    guna2DataGridView10.Columns[3].Visible = false;
            //    guna2DataGridView11.Columns[3].Visible = false;

            //    guna2DataGridView7.Columns[4].Visible = false;
            //    guna2DataGridView8.Columns[4].Visible = false;
            //    guna2DataGridView9.Columns[4].Visible = false;
            //    guna2DataGridView10.Columns[4].Visible = false;
            //    guna2DataGridView11.Columns[4].Visible = false;

            //    guna2DataGridView7.Columns[5].Visible = false;
            //    guna2DataGridView8.Columns[5].Visible = false;
            //    guna2DataGridView9.Columns[5].Visible = false;
            //    guna2DataGridView10.Columns[5].Visible = false;
            //    guna2DataGridView11.Columns[5].Visible = false;

            //    guna2DataGridView7.Columns[6].Visible = false;
            //    guna2DataGridView8.Columns[6].Visible = false;
            //    guna2DataGridView9.Columns[6].Visible = false;
            //    guna2DataGridView10.Columns[6].Visible = false;
            //    guna2DataGridView11.Columns[6].Visible = false;

            //    guna2DataGridView7.Columns[7].Visible = false;
            //    guna2DataGridView8.Columns[7].Visible = false;
            //    guna2DataGridView9.Columns[7].Visible = false;
            //    guna2DataGridView10.Columns[7].Visible = false;
            //    guna2DataGridView11.Columns[7].Visible = false;
            //}
            //else if (selectedValue == "3")
            //{
            //    guna2DataGridView7.Columns[1].Visible = true;
            //    guna2DataGridView8.Columns[1].Visible = true;
            //    guna2DataGridView9.Columns[1].Visible = true;
            //    guna2DataGridView10.Columns[1].Visible = true;
            //    guna2DataGridView11.Columns[1].Visible = true;

            //    guna2DataGridView7.Columns[2].Visible = true;
            //    guna2DataGridView8.Columns[2].Visible = true;
            //    guna2DataGridView9.Columns[2].Visible = true;
            //    guna2DataGridView10.Columns[2].Visible = true;
            //    guna2DataGridView11.Columns[2].Visible = true;

            //    guna2DataGridView7.Columns[3].Visible = true;
            //    guna2DataGridView8.Columns[3].Visible = true;
            //    guna2DataGridView9.Columns[3].Visible = true;
            //    guna2DataGridView10.Columns[3].Visible = true;
            //    guna2DataGridView11.Columns[3].Visible = true;

            //    guna2DataGridView7.Columns[4].Visible = false;
            //    guna2DataGridView8.Columns[4].Visible = false;
            //    guna2DataGridView9.Columns[4].Visible = false;
            //    guna2DataGridView10.Columns[4].Visible = false;
            //    guna2DataGridView11.Columns[4].Visible = false;

            //    guna2DataGridView7.Columns[5].Visible = false;
            //    guna2DataGridView8.Columns[5].Visible = false;
            //    guna2DataGridView9.Columns[5].Visible = false;
            //    guna2DataGridView10.Columns[5].Visible = false;
            //    guna2DataGridView11.Columns[5].Visible = false;

            //    guna2DataGridView7.Columns[6].Visible = false;
            //    guna2DataGridView8.Columns[6].Visible = false;
            //    guna2DataGridView9.Columns[6].Visible = false;
            //    guna2DataGridView10.Columns[6].Visible = false;
            //    guna2DataGridView11.Columns[6].Visible = false;

            //    guna2DataGridView7.Columns[7].Visible = false;
            //    guna2DataGridView8.Columns[7].Visible = false;
            //    guna2DataGridView9.Columns[7].Visible = false;
            //    guna2DataGridView10.Columns[7].Visible = false;
            //    guna2DataGridView11.Columns[7].Visible = false;
            //}
            //else if (selectedValue == "4")
            //{
            //    guna2DataGridView7.Columns[1].Visible = true;
            //    guna2DataGridView8.Columns[1].Visible = true;
            //    guna2DataGridView9.Columns[1].Visible = true;
            //    guna2DataGridView10.Columns[1].Visible = true;
            //    guna2DataGridView11.Columns[1].Visible = true;

            //    guna2DataGridView7.Columns[2].Visible = true;
            //    guna2DataGridView8.Columns[2].Visible = true;
            //    guna2DataGridView9.Columns[2].Visible = true;
            //    guna2DataGridView10.Columns[2].Visible = true;
            //    guna2DataGridView11.Columns[2].Visible = true;

            //    guna2DataGridView7.Columns[3].Visible = true;
            //    guna2DataGridView8.Columns[3].Visible = true;
            //    guna2DataGridView9.Columns[3].Visible = true;
            //    guna2DataGridView10.Columns[3].Visible = true;
            //    guna2DataGridView11.Columns[3].Visible = true;


            //    guna2DataGridView7.Columns[4].Visible = true;
            //    guna2DataGridView8.Columns[4].Visible = true;
            //    guna2DataGridView9.Columns[4].Visible = true;
            //    guna2DataGridView10.Columns[4].Visible = true;
            //    guna2DataGridView11.Columns[4].Visible = true;

            //    guna2DataGridView7.Columns[5].Visible = false;
            //    guna2DataGridView8.Columns[5].Visible = false;
            //    guna2DataGridView9.Columns[5].Visible = false;
            //    guna2DataGridView10.Columns[5].Visible = false;
            //    guna2DataGridView11.Columns[5].Visible = false;

            //    guna2DataGridView7.Columns[6].Visible = false;
            //    guna2DataGridView8.Columns[6].Visible = false;
            //    guna2DataGridView9.Columns[6].Visible = false;
            //    guna2DataGridView10.Columns[6].Visible = false;
            //    guna2DataGridView11.Columns[6].Visible = false;

            //    guna2DataGridView7.Columns[7].Visible = false;
            //    guna2DataGridView8.Columns[7].Visible = false;
            //    guna2DataGridView9.Columns[7].Visible = false;
            //    guna2DataGridView10.Columns[7].Visible = false;
            //    guna2DataGridView11.Columns[7].Visible = false;
            //}
            //else if (selectedValue == "5")
            //{
            //    guna2DataGridView7.Columns[1].Visible = true;
            //    guna2DataGridView8.Columns[1].Visible = true;
            //    guna2DataGridView9.Columns[1].Visible = true;
            //    guna2DataGridView10.Columns[1].Visible = true;
            //    guna2DataGridView11.Columns[1].Visible = true;

            //    guna2DataGridView7.Columns[2].Visible = true;
            //    guna2DataGridView8.Columns[2].Visible = true;
            //    guna2DataGridView9.Columns[2].Visible = true;
            //    guna2DataGridView10.Columns[2].Visible = true;
            //    guna2DataGridView11.Columns[2].Visible = true;

            //    guna2DataGridView7.Columns[3].Visible = true;
            //    guna2DataGridView8.Columns[3].Visible = true;
            //    guna2DataGridView9.Columns[3].Visible = true;
            //    guna2DataGridView10.Columns[3].Visible = true;
            //    guna2DataGridView11.Columns[3].Visible = true;

            //    guna2DataGridView7.Columns[4].Visible = true;
            //    guna2DataGridView8.Columns[4].Visible = true;
            //    guna2DataGridView9.Columns[4].Visible = true;
            //    guna2DataGridView10.Columns[4].Visible = true;
            //    guna2DataGridView11.Columns[4].Visible = true;

            //    guna2DataGridView7.Columns[5].Visible = true;
            //    guna2DataGridView8.Columns[5].Visible = true;
            //    guna2DataGridView9.Columns[5].Visible = true;
            //    guna2DataGridView10.Columns[5].Visible = true;
            //    guna2DataGridView11.Columns[5].Visible = true;

            //    guna2DataGridView7.Columns[6].Visible = false;
            //    guna2DataGridView8.Columns[6].Visible = false;
            //    guna2DataGridView9.Columns[6].Visible = false;
            //    guna2DataGridView10.Columns[6].Visible = false;
            //    guna2DataGridView11.Columns[6].Visible = false;

            //    guna2DataGridView7.Columns[7].Visible = false;
            //    guna2DataGridView8.Columns[7].Visible = false;
            //    guna2DataGridView9.Columns[7].Visible = false;
            //    guna2DataGridView10.Columns[7].Visible = false;
            //    guna2DataGridView11.Columns[7].Visible = false;
            //}
            //else if (selectedValue == "6")
            //{
            //    guna2DataGridView7.Columns[1].Visible = true;
            //    guna2DataGridView8.Columns[1].Visible = true;
            //    guna2DataGridView9.Columns[1].Visible = true;
            //    guna2DataGridView10.Columns[1].Visible = true;
            //    guna2DataGridView11.Columns[1].Visible = true;

            //    guna2DataGridView7.Columns[2].Visible = true;
            //    guna2DataGridView8.Columns[2].Visible = true;
            //    guna2DataGridView9.Columns[2].Visible = true;
            //    guna2DataGridView10.Columns[2].Visible = true;
            //    guna2DataGridView11.Columns[2].Visible = true;

            //    guna2DataGridView7.Columns[3].Visible = true;
            //    guna2DataGridView8.Columns[3].Visible = true;
            //    guna2DataGridView9.Columns[3].Visible = true;
            //    guna2DataGridView10.Columns[3].Visible = true;
            //    guna2DataGridView11.Columns[3].Visible = true;

            //    guna2DataGridView7.Columns[4].Visible = true;
            //    guna2DataGridView8.Columns[4].Visible = true;
            //    guna2DataGridView9.Columns[4].Visible = true;
            //    guna2DataGridView10.Columns[4].Visible = true;
            //    guna2DataGridView11.Columns[4].Visible = true;

            //    guna2DataGridView7.Columns[5].Visible = true;
            //    guna2DataGridView8.Columns[5].Visible = true;
            //    guna2DataGridView9.Columns[5].Visible = true;
            //    guna2DataGridView10.Columns[5].Visible = true;
            //    guna2DataGridView11.Columns[5].Visible = true;

            //    guna2DataGridView7.Columns[6].Visible = true;
            //    guna2DataGridView8.Columns[6].Visible = true;
            //    guna2DataGridView9.Columns[6].Visible = true;
            //    guna2DataGridView10.Columns[6].Visible = true;
            //    guna2DataGridView11.Columns[6].Visible = true;

            //    guna2DataGridView7.Columns[7].Visible = false;
            //    guna2DataGridView8.Columns[7].Visible = false;
            //    guna2DataGridView9.Columns[7].Visible = false;
            //    guna2DataGridView10.Columns[7].Visible = false;
            //    guna2DataGridView11.Columns[7].Visible = false;
            //}
            //else
            //{
            //    for (int i = 1; i < 8; i++)
            //    {
            //        guna2DataGridView7.Columns[i].Visible = true;
            //        guna2DataGridView8.Columns[i].Visible = true;
            //        guna2DataGridView9.Columns[i].Visible = true;
            //        guna2DataGridView10.Columns[i].Visible = true;
            //        guna2DataGridView11.Columns[i].Visible = true;
            //    }
            //}

        }
        //finalcoding

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

        private void TableLayoutFill()
        {
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView1.GridColor = Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView12.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView12.GridColor = Color.Black;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView12.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView12.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView13.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView13.GridColor = Color.Black;
            guna2DataGridView13.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView13.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView13.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView13.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView13.Columns[5].Width = 20;

            guna2DataGridView15.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView15.GridColor = Color.Black;
            guna2DataGridView15.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView15.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView15.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView15.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView15.Columns[5].Width = 20;

            guna2DataGridView16.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView16.GridColor = Color.Black;
            guna2DataGridView16.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView16.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView16.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView16.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView16.Columns[5].Width = 20;

            guna2DataGridView17.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView17.GridColor = Color.Black;
            guna2DataGridView17.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView17.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView17.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView17.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView17.Columns[5].Width = 20;

            guna2DataGridView18.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView18.GridColor = Color.Black;
            guna2DataGridView18.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView18.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView18.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView18.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView18.Columns[5].Width = 20;

            guna2DataGridView19.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView19.GridColor = Color.Black;
            guna2DataGridView19.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView19.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView19.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView19.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView19.Columns[5].Width = 20;

            guna2DataGridView20.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView20.GridColor = Color.Black;
            guna2DataGridView20.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView20.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView20.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView20.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView20.Columns[5].Width = 20;

            while (guna2DataGridView13.Rows.Count < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView13.Rows.Add(row);
            }

            while (guna2DataGridView15.Rows.Count < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView15.Rows.Add(row);
            }

            while (guna2DataGridView16.Rows.Count < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView16.Rows.Add(row);
            }

            while (guna2DataGridView17.Rows.Count < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView17.Rows.Add(row);
            }

            while (guna2DataGridView18.Rows.Count < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView18.Rows.Add(row);
            }

            while (guna2DataGridView19.Rows.Count < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView19.Rows.Add(row);
            }

            while (guna2DataGridView20.Rows.Count < 5)
            {
                Guna2DataGridView row = new Guna2DataGridView();
                guna2DataGridView20.Rows.Add(row);
            }

            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 8;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 8;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void ClearSelection()
        {
            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();
        }

        private void ClearTables()
        {
            guna2DataGridView13.Rows.Clear();
            guna2DataGridView15.Rows.Clear();
            guna2DataGridView16.Rows.Clear();
            guna2DataGridView17.Rows.Clear();
            guna2DataGridView18.Rows.Clear();
            guna2DataGridView19.Rows.Clear();
            guna2DataGridView20.Rows.Clear();
        }

        private void guna2DataGridView13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView13";
        }

        private void guna2DataGridView15_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView13.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView15";
        }

        private void guna2DataGridView16_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView16";
        }

        private void guna2DataGridView17_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView17";
        }

        private void guna2DataGridView18_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView18";
        }

        private void guna2DataGridView19_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView20.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView19";
        }

        private void guna2DataGridView20_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            selectedRow = e.RowIndex;
            selectedColumn = e.ColumnIndex;
            selectedchart = "guna2DataGridView20";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView13.SelectedCells.Count == 1)
            {
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                chart1.Titles.Clear();
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();

            }

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView15.SelectedCells.Count == 1)
            {
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                chart1.Titles.Clear();
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView16.SelectedCells.Count == 1)
            {
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                chart1.Titles.Clear();
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView17.SelectedCells.Count == 1)
            {
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                chart1.Titles.Clear();
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();

            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView18.SelectedCells.Count == 1)
            {
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                chart1.Titles.Clear();
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();

            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView19.SelectedCells.Count == 1)
            {
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                chart1.Titles.Clear();
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();

            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView20.SelectedCells.Count == 1)
            {
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                chart1.Titles.Clear();
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();

            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editmeal = 1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView13")
                {
                    selectedid = item.ID; break;
                }
            }

            if (selectedid != 0)
            {
                UpdateGroupsC();
                UpdateGroupsN();
                MealID = selectedid.ToString();
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
                            notes.Text = reader["Notes"].ToString();
                            preparation.Text = reader["Preparation"].ToString();
                            classification.Text = reader["CLASSIFICATION"].ToString();
                        }
                        reader.Close();

                        MainClass.con.Close();

                    }

                    tabControl1.SelectedIndex = 6;
                    guna2DataGridView12.ClearSelection();
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
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }


        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            editmeal = 1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView15")
                {
                    selectedid = item.ID; break;
                }
            }

            if (selectedid != 0)
            {
                UpdateGroupsC();
                UpdateGroupsN();
                MealID = selectedid.ToString();
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
                            notes.Text = reader["Notes"].ToString();
                            preparation.Text = reader["Preparation"].ToString();
                            classification.Text = reader["CLASSIFICATION"].ToString();
                        }
                        reader.Close();

                        MainClass.con.Close();

                    }

                    tabControl1.SelectedIndex = 6;
                    guna2DataGridView12.ClearSelection();
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
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            editmeal = 1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView16")
                {
                    selectedid = item.ID; break;
                }
            }

            if (selectedid != 0)
            {
                UpdateGroupsC();
                UpdateGroupsN();
                MealID = selectedid.ToString();
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
                            notes.Text = reader["Notes"].ToString();
                            preparation.Text = reader["Preparation"].ToString();
                            classification.Text = reader["CLASSIFICATION"].ToString();
                        }
                        reader.Close();

                        MainClass.con.Close();

                    }

                    tabControl1.SelectedIndex = 6;
                    guna2DataGridView12.ClearSelection();
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
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            editmeal = 1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView17")
                {
                    selectedid = item.ID; break;
                }
            }

            if (selectedid != 0)
            {
                UpdateGroupsC();
                UpdateGroupsN();
                MealID = selectedid.ToString();
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
                            notes.Text = reader["Notes"].ToString();
                            preparation.Text = reader["Preparation"].ToString();
                            classification.Text = reader["CLASSIFICATION"].ToString();
                        }
                        reader.Close();

                        MainClass.con.Close();

                    }

                    tabControl1.SelectedIndex = 6;
                    guna2DataGridView12.ClearSelection();
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
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            editmeal = 1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView18")
                {
                    selectedid = item.ID; break;
                }
            }

            if (selectedid != 0)
            {
                UpdateGroupsC();
                UpdateGroupsN();
                MealID = selectedid.ToString();
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
                            notes.Text = reader["Notes"].ToString();
                            preparation.Text = reader["Preparation"].ToString();
                            classification.Text = reader["CLASSIFICATION"].ToString();
                        }
                        reader.Close();

                        MainClass.con.Close();

                    }

                    tabControl1.SelectedIndex = 6;
                    guna2DataGridView12.ClearSelection();
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
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            editmeal = 1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView19")
                {
                    selectedid = item.ID; break;
                }
            }

            if (selectedid != 0)
            {
                UpdateGroupsC();
                UpdateGroupsN();
                MealID = selectedid.ToString();
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
                            notes.Text = reader["Notes"].ToString();
                            preparation.Text = reader["Preparation"].ToString();
                            classification.Text = reader["CLASSIFICATION"].ToString();
                        }
                        reader.Close();

                        MainClass.con.Close();

                    }

                    tabControl1.SelectedIndex = 6;
                    guna2DataGridView12.ClearSelection();
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
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            editmeal = 1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView20")
                {
                    selectedid = item.ID; break;
                }
            }

            if (selectedid != 0)
            {
                UpdateGroupsC();
                UpdateGroupsN();
                MealID = selectedid.ToString();
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
                            notes.Text = reader["Notes"].ToString();
                            preparation.Text = reader["Preparation"].ToString();
                            classification.Text = reader["CLASSIFICATION"].ToString();
                        }
                        reader.Close();

                        MainClass.con.Close();

                    }

                    tabControl1.SelectedIndex = 6;
                    guna2DataGridView12.ClearSelection();
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
                ClearMeals();
                ShowMeals(guna2DataGridView12, mealiddgv, mealardgv, mealendgv, caloriesdgv, proteinmaindgv, fatsmaindgv, carbohydratesmaindgv, calciummaindgv, fibermaindgv, sodiummaindgv);
                tabControl1.SelectedIndex = 6;
                guna2DataGridView12.ClearSelection();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ArtificialMapping deleteitem = new ArtificialMapping();

            int call = -1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView13")
                {
                    ChartSubtract(item.ID.ToString());
                    deleteitem.Row = item.Row;
                    deleteitem.Col = item.Col;
                    deleteitem.ChartName = item.ChartName;
                    deleteitem.ID = item.ID;
                    call = 1;
                }
            }
            if (call == 1)
            {
                guna2DataGridView13.Rows[deleteitem.Row].Cells[deleteitem.Col].Value = "";
                artificialMappings.RemoveAll(x => (x.Row == deleteitem.Row && x.Col == deleteitem.Col && x.ChartName == deleteitem.ChartName && x.ID == deleteitem.ID));
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ArtificialMapping deleteitem = new ArtificialMapping();

            int call = -1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView15")
                {
                    ChartSubtract(item.ID.ToString());
                    deleteitem.Row = item.Row;
                    deleteitem.Col = item.Col;
                    deleteitem.ChartName = item.ChartName;
                    deleteitem.ID = item.ID;
                    call = 1;
                }
            }
            if (call == 1)
            {
                guna2DataGridView15.Rows[deleteitem.Row].Cells[deleteitem.Col].Value = "";
                artificialMappings.RemoveAll(x => (x.Row == deleteitem.Row && x.Col == deleteitem.Col && x.ChartName == deleteitem.ChartName && x.ID == deleteitem.ID));
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ArtificialMapping deleteitem = new ArtificialMapping();

            int call = -1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView16")
                {
                    ChartSubtract(item.ID.ToString());
                    deleteitem.Row = item.Row;
                    deleteitem.Col = item.Col;
                    deleteitem.ChartName = item.ChartName;
                    deleteitem.ID = item.ID;
                    call = 1;
                }
            }
            if (call == 1)
            {
                guna2DataGridView16.Rows[deleteitem.Row].Cells[deleteitem.Col].Value = "";
                artificialMappings.RemoveAll(x => (x.Row == deleteitem.Row && x.Col == deleteitem.Col && x.ChartName == deleteitem.ChartName && x.ID == deleteitem.ID));
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ArtificialMapping deleteitem = new ArtificialMapping();

            int call = -1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView17")
                {
                    ChartSubtract(item.ID.ToString());
                    deleteitem.Row = item.Row;
                    deleteitem.Col = item.Col;
                    deleteitem.ChartName = item.ChartName;
                    deleteitem.ID = item.ID;
                    call = 1;
                }
            }
            if (call == 1)
            {
                guna2DataGridView17.Rows[deleteitem.Row].Cells[deleteitem.Col].Value = "";
                artificialMappings.RemoveAll(x => (x.Row == deleteitem.Row && x.Col == deleteitem.Col && x.ChartName == deleteitem.ChartName && x.ID == deleteitem.ID));
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ArtificialMapping deleteitem = new ArtificialMapping();

            int call = -1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView18")
                {
                    ChartSubtract(item.ID.ToString());
                    deleteitem.Row = item.Row;
                    deleteitem.Col = item.Col;
                    deleteitem.ChartName = item.ChartName;
                    deleteitem.ID = item.ID;
                    call = 1;
                }
            }
            if (call == 1)
            {
                guna2DataGridView18.Rows[deleteitem.Row].Cells[deleteitem.Col].Value = "";
                artificialMappings.RemoveAll(x => (x.Row == deleteitem.Row && x.Col == deleteitem.Col && x.ChartName == deleteitem.ChartName && x.ID == deleteitem.ID));
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            ArtificialMapping deleteitem = new ArtificialMapping();

            int call = -1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView19")
                {
                    ChartSubtract(item.ID.ToString());
                    deleteitem.Row = item.Row;
                    deleteitem.Col = item.Col;
                    deleteitem.ChartName = item.ChartName;
                    deleteitem.ID = item.ID;
                    call = 1;
                }
            }
            if (call == 1)
            {
                guna2DataGridView19.Rows[deleteitem.Row].Cells[deleteitem.Col].Value = "";
                artificialMappings.RemoveAll(x => (x.Row == deleteitem.Row && x.Col == deleteitem.Col && x.ChartName == deleteitem.ChartName && x.ID == deleteitem.ID));
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            ArtificialMapping deleteitem = new ArtificialMapping();

            int call = -1;
            foreach (var item in artificialMappings)
            {
                if (item.Row == selectedRow && item.Col == selectedColumn && item.ChartName == "guna2DataGridView20")
                {
                    ChartSubtract(item.ID.ToString());
                    deleteitem.Row = item.Row;
                    deleteitem.Col = item.Col;
                    deleteitem.ChartName = item.ChartName;
                    deleteitem.ID = item.ID;
                    call = 1;
                }
            }
            if (call == 1)
            {
                guna2DataGridView20.Rows[deleteitem.Row].Cells[deleteitem.Col].Value = "";
                artificialMappings.RemoveAll(x => (x.Row == deleteitem.Row && x.Col == deleteitem.Col && x.ChartName == deleteitem.ChartName && x.ID == deleteitem.ID));
            }
        }

        private void guna2DataGridView13_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView13.Columns["action1"].Index && e.RowIndex >= 0)
            {
                List<ArtificialMapping> removelist = new List<ArtificialMapping>();

                int call = -1;
                foreach (var item in artificialMappings)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView13")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                if (call == 1)
                {

                    foreach (var item in removelist)
                    {
                        if (item.ChartName == "guna2DataGridView13")
                        {
                            guna2DataGridView13.Rows[item.Row].Cells[item.Col].Value = "";

                        }

                        artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                    }
                    removelist.Clear();

                }
                guna2DataGridView13.Rows.RemoveAt(e.RowIndex);

            }

            CheckRows(guna2DataGridView13);
        }

        private void guna2DataGridView15_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView15.Columns["action2"].Index && e.RowIndex >= 0)
            {
                List<ArtificialMapping> removelist = new List<ArtificialMapping>();

                int call = -1;
                foreach (var item in artificialMappings)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView15")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                if (call == 1)
                {

                    foreach (var item in removelist)
                    {
                        if (item.ChartName == "guna2DataGridView15")
                        {
                            guna2DataGridView15.Rows[item.Row].Cells[item.Col].Value = "";

                        }

                        artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                    }
                    removelist.Clear();

                }
                guna2DataGridView15.Rows.RemoveAt(e.RowIndex);
            }
            CheckRows(guna2DataGridView15);
        }

        private void guna2DataGridView16_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView16.Columns["action3"].Index && e.RowIndex >= 0)
            {
                List<ArtificialMapping> removelist = new List<ArtificialMapping>();

                int call = -1;
                foreach (var item in artificialMappings)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView16")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                if (call == 1)
                {

                    foreach (var item in removelist)
                    {
                        if (item.ChartName == "guna2DataGridView16")
                        {
                            guna2DataGridView16.Rows[item.Row].Cells[item.Col].Value = "";

                        }

                        artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                    }
                    removelist.Clear();

                }
                guna2DataGridView16.Rows.RemoveAt(e.RowIndex);
            }
            CheckRows(guna2DataGridView16);
        }

        private void guna2DataGridView17_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView17.Columns["action4"].Index && e.RowIndex >= 0)
            {
                List<ArtificialMapping> removelist = new List<ArtificialMapping>();

                int call = -1;
                foreach (var item in artificialMappings)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView17")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                if (call == 1)
                {

                    foreach (var item in removelist)
                    {
                        if (item.ChartName == "guna2DataGridView17")
                        {
                            guna2DataGridView17.Rows[item.Row].Cells[item.Col].Value = "";

                        }

                        artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                    }
                    removelist.Clear();

                }
                guna2DataGridView17.Rows.RemoveAt(e.RowIndex);
            }
            CheckRows(guna2DataGridView17);
        }

        private void guna2DataGridView18_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView18.Columns["action5"].Index && e.RowIndex >= 0)
            {
                List<ArtificialMapping> removelist = new List<ArtificialMapping>();

                int call = -1;
                foreach (var item in artificialMappings)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView18")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                if (call == 1)
                {

                    foreach (var item in removelist)
                    {
                        if (item.ChartName == "guna2DataGridView18")
                        {
                            guna2DataGridView18.Rows[item.Row].Cells[item.Col].Value = "";

                        }

                        artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                    }
                    removelist.Clear();

                }
                guna2DataGridView18.Rows.RemoveAt(e.RowIndex);
            }
            CheckRows(guna2DataGridView18);
        }

        private void guna2DataGridView19_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView19.Columns["action6"].Index && e.RowIndex >= 0)
            {
                List<ArtificialMapping> removelist = new List<ArtificialMapping>();

                int call = -1;
                foreach (var item in artificialMappings)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView19")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                if (call == 1)
                {

                    foreach (var item in removelist)
                    {
                        if (item.ChartName == "guna2DataGridView19")
                        {
                            guna2DataGridView19.Rows[item.Row].Cells[item.Col].Value = "";

                        }

                        artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                    }
                    removelist.Clear();

                }
                guna2DataGridView19.Rows.RemoveAt(e.RowIndex);
            }
            CheckRows(guna2DataGridView19);
        }

        private void guna2DataGridView20_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView20.Columns["action7"].Index && e.RowIndex >= 0)
            {
                List<ArtificialMapping> removelist = new List<ArtificialMapping>();

                int call = -1;
                foreach (var item in artificialMappings)
                {
                    if (item.Row == e.RowIndex && item.ChartName == "guna2DataGridView20")
                    {
                        ChartSubtract(item.ID.ToString());
                        ArtificialMapping deleteitem = new ArtificialMapping();
                        deleteitem.Row = item.Row;
                        deleteitem.Col = item.Col;
                        deleteitem.ChartName = item.ChartName;
                        deleteitem.ID = item.ID;
                        removelist.Add(deleteitem);
                        call = 1;
                    }
                }
                if (call == 1)
                {

                    foreach (var item in removelist)
                    {
                        if (item.ChartName == "guna2DataGridView20")
                        {
                            guna2DataGridView20.Rows[item.Row].Cells[item.Col].Value = "";

                        }

                        artificialMappings.RemoveAll(x => (x.Row == item.Row && x.Col == item.Col && x.ChartName == item.ChartName && x.ID == item.ID));


                    }
                    removelist.Clear();

                }
                guna2DataGridView20.Rows.RemoveAt(e.RowIndex);
            }
            CheckRows(guna2DataGridView20);
        }

        static int instructionflag = 0;
        private void instructionnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (instructionflag == 1)
            {


                string selectedValue = instructionnew.SelectedValue.ToString();

                SqlCommand cmd;
                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    // Retrieve the selected ID from the ComboBox
                    int selectedInstructionID = Convert.ToInt32(instructionnew.SelectedValue);

                    // Use the selected ID to fetch the corresponding instruction
                    cmd = new SqlCommand("SELECT InstructionContent FROM INSTRUCTION WHERE ID = @SelectedID", MainClass.con);
                    cmd.Parameters.AddWithValue("@SelectedID", selectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Check if any rows are returned
                    if (dt.Rows.Count > 0)
                    {
                        // Assuming there's only one row, you can use the first row
                        string instructionContent = dt.Rows[0].Field<string>("InstructionContent");

                        // Display the instruction content in the TextBox
                        instructioncontent.Text = instructionContent;
                    }


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

        static double fatsc = 0;
        static double proteinc = 0;
        static double carbohydratesc = 0;

        private void NewChartForDailyDataReport(int id)
        {


            titlecheck = 0;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT FATS,CARBOHYDRATES,PROTEIN FROM Meal WHERE ID = @MealID", MainClass.con);
                cmd.Parameters.AddWithValue("@MealID", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        fatsc = Convert.ToDouble(reader["FATS"]);
                        proteinc = Convert.ToDouble(reader["PROTEIN"]);
                        carbohydratesc = Convert.ToDouble(reader["CARBOHYDRATES"]);

                    }
                    reader.Close();

                    MainClass.con.Close();
                    //extrafunc();

                    //tabControl1.SelectedIndex = 2;
                }


                MainClass.con.Close();


                if (fatsdaily.Text == "")
                {
                    fatsdaily.Text = fatsc.ToString();
                    proteindaily.Text = proteinc.ToString();
                    carbsdaily.Text = carbohydratesc.ToString();
                }
                else
                {

                    double Tfats = Convert.ToDouble(fatsdaily.Text);
                    double Tprotein = Convert.ToDouble(proteindaily.Text);
                    double Tcarbohydrates = Convert.ToDouble(carbsdaily.Text);


                    Tfats = Tfats + fatsc;
                    Tprotein = Tprotein + proteinc;
                    Tcarbohydrates = Tcarbohydrates + carbohydratesc;


                    fatsdaily.Text = Tfats.ToString();
                    proteindaily.Text = Tprotein.ToString();
                    carbsdaily.Text = Tcarbohydrates.ToString();

                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void FillDayByChart()
        {
            foreach (var item in artificialMappings)
            {
                if (item.ChartName == "guna2DataGridView13")
                {
                    NewChartForDailyDataReport(item.ID);
                    DayByChart(chart7);
                }
                else if (item.ChartName == "guna2DataGridView15")
                {
                    NewChartForDailyDataReport(item.ID);
                    DayByChart(chart4);
                }
                else if (item.ChartName == "guna2DataGridView16")
                {
                    NewChartForDailyDataReport(item.ID);
                    DayByChart(chart5);
                }
                else if (item.ChartName == "guna2DataGridView17")
                {
                    NewChartForDailyDataReport(item.ID);
                    DayByChart(chart6);
                }
                else if (item.ChartName == "guna2DataGridView18")
                {
                    NewChartForDailyDataReport(item.ID);
                    DayByChart(chart8);
                }
                else if (item.ChartName == "guna2DataGridView19")
                {
                    NewChartForDailyDataReport(item.ID);
                    DayByChart(chart9);
                }
                else if (item.ChartName == "guna2DataGridView20")
                {
                    NewChartForDailyDataReport(item.ID);
                    DayByChart(chart10);
                }
            }
        }
        private void DayByChart(Chart chart)
        {

            chart.Titles.Clear();


            // Create a sample DataTable with data (replace this with your data source).
            DataTable dt = new DataTable();
            dt.Columns.Add("Nutrient", typeof(string));
            dt.Columns.Add("Value", typeof(double));

            if (fatsdaily.Text != "")
            {
                dt.Rows.Add("Fats", double.Parse(fatsdaily.Text) * 9);
            }

            if (proteindaily.Text != "")
            {
                dt.Rows.Add("Protein", double.Parse(proteindaily.Text) * 4);
            }

            if (carbsdaily.Text != "")
            {
                dt.Rows.Add("Carbohydrates", double.Parse(carbsdaily.Text) * 4);
            }

            if (chart.Titles.Count == 0) // Check if there's at least one title
            {
                if (languagestatus == 1)
                {
                    chart.Titles.Add("القيمة الغذائية");
                }
                else
                {
                    chart.Titles.Add("Nutrient Chart");
                }
            }

            if (chart.Legends.Count == 0) // Check if there's at least one legend
            {
                chart.Legends.Add("Legend");
                chart.Legends[0].Alignment = StringAlignment.Center;
                chart.Legends[0].Docking = Docking.Bottom;
            }

            chart.Titles[0].Alignment = ContentAlignment.TopCenter;

            // Your existing code for chart settings
            chart.Legends[0].Enabled = true;
            chart.Legends[0].Alignment = StringAlignment.Center;
            chart.Legends[0].Docking = Docking.Bottom;

            // Your existing code for chart settings
            chart.Series.Clear();
            chart.Palette = ChartColorPalette.Pastel;

            Series series = new Series("Series1");
            series.Points.DataBind(dt.AsEnumerable(), "Nutrient", "Value", "");

            series.ChartType = SeriesChartType.Pie;
            chart.Series.Add(series);
            chart.Series[0].Label = "#PERCENT{P0}";
            chart.Series[0].LegendText = "#VALX";

            // Refresh the chart.
            chart.Refresh();
            fatsdaily.Text = "";
            proteindaily.Text = "";
            carbsdaily.Text = "";
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 9;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 10;
        }
        private async Task DelayAsync(int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
        }
        private async void PrintBTN_Click(object sender, EventArgs e)
        {
            FillDayByChart();
            SettingCoverInfo();
            //cecover.Text = companyemail;
            //cmcover.Text = companynumber;
            //cncover.Text = companynamefooter;
            tabControl1.SelectedIndex = 11;
            // Delay for 1 second
            await DelayAsync(1000);
            tabControl1.SelectedIndex = 9;
            tabControl1.SelectedIndex = 10;
            tabControl1.SelectedIndex = 8;

            panel19.Dock = DockStyle.None;
            panel19.Size = new Size(1000, 1600);

            guna2DataGridView13.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();
            guna2DataGridView17.ClearSelection();
            guna2DataGridView18.ClearSelection();
            guna2DataGridView19.ClearSelection();
            guna2DataGridView20.ClearSelection();

            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            dietplanreport.Visible = true;
            List<Panel> panelList = new List<Panel> { panel13, panel19, panel22, panel12 };
            SavePanelsAsPdfWithFooter(panelList, 610, 800);

            panel19.Dock = DockStyle.Fill;
            guna2Button5.Visible = true;
            guna2Button6.Visible = true;
            dietplanreport.Visible = false;
            //panel19.Size = new Size(1356, 1020);
            // Create SaveFileDialog object
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            //saveFileDialog.Title = "Save Panels as PDF";

            //// Show the dialog and check if the user selects a file
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = saveFileDialog.FileName;
            //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //    // Create a new PDF document

            //    List<Panel> panelList = new List<Panel> { panel13, panel22 }; // Add more panels as needed

            //    PdfDocument document = new PdfDocument();

            //    // Iterate through each panel and add a page to the document
            //    foreach (Panel currentPanel in panelList)
            //    {
            //        // Add a page to the document with the specified size
            //        PdfPage page = document.AddPage();
            //        page.Width = XUnit.FromPoint(currentPanel.Width);
            //        page.Height = XUnit.FromPoint(currentPanel.Height);

            //        XGraphics gfx = XGraphics.FromPdfPage(page);

            //        // Capture the panel content as an image
            //        Bitmap bmp = new Bitmap(currentPanel.Width, currentPanel.Height);
            //        currentPanel.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

            //        // Convert the GDI image to PDFsharp XImage
            //        XImage panelImage = XImage.FromGdiPlusImage(bmp);

            //        // Draw the image onto the PDF page
            //        gfx.DrawImage(panelImage, 0, 0);

            //        // Dispose of resources for this page
            //        bmp.Dispose();
            //    }

            //    // Add footer on the last page
            //    PdfPage lastPage = document.Pages.Last();
            //    XGraphics lastPageGfx = XGraphics.FromPdfPage(lastPage);
            //    XTextFormatter tf = new XTextFormatter(lastPageGfx);

            //    XRect rect = new XRect(10, lastPage.Height - 20, lastPage.Width - 20, 20);
            //    lastPageGfx.DrawRectangle(XBrushes.White, rect);

            //    // Align the footer text to the left
            //    tf.DrawString($"{companynamefooter} | {companynumber} | {companyemail}", new XFont("Arial", 8), XBrushes.Black, rect, XStringFormats.TopLeft);

            //    // Save the PDF document
            //    document.Save(filePath);

            //    // Dispose of resources
            //    document.Close();

            //    MessageBox.Show($"Panels saved as PDF: {filePath}");
            //}
        }

        private void SavePanelsAsPdfWithFooter(List<Panel> panels, double width, double height)
        {
            // Create SaveFileDialog object
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save Panels as PDF";

            // Show the dialog and check if the user selects a file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // Create a new PDF document
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

                // Iterate through each panel and add a page to the document
                for (int i = 0; i < panels.Count; i++)
                {
                    Panel currentPanel = panels[i];

                    // Add a page to the document with the specified size
                    PdfSharp.Pdf.PdfPage page = document.AddPage();
                    page.Width = width;
                    page.Height = height;

                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Capture the panel content as an image
                    Bitmap bmp = new Bitmap(currentPanel.Width, currentPanel.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    currentPanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                    // Calculate the scaling factor to fit the panel within the page
                    float scaleFactor = Math.Min((float)page.Width / (float)bmp.Width, (float)page.Height / (float)bmp.Height);

                    // Adjust the image width and height based on the scaling factor
                    int scaledWidth = (int)(bmp.Width * scaleFactor);
                    int scaledHeight = (int)(bmp.Height * scaleFactor);

                    // Adjust the X-coordinate to center if the current panel is panel19
                    int xCoordinate = (currentPanel == panel19) ? (int)((page.Width - scaledWidth) / 2) : 0;

                    // Adjust the Y-coordinate for top spacing if the current panel is panel19
                    int topSpacing = (currentPanel == panel19) ? 20 : 0;

                    // Draw the scaled image onto the PDF page with adjusted coordinates
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, ImageFormat.Png);
                    ms.Seek(0, SeekOrigin.Begin);
                    XImage xImage = XImage.FromStream(ms);

                    // Use XImage object for drawing
                    gfx.DrawImage(xImage, xCoordinate, topSpacing, scaledWidth, scaledHeight);

                    // Add footer text
                    DrawFooter(gfx, companynamefooter + " | " + companynumber + " | " + companyemail);

                    // Dispose of resources for this page
                    ms.Dispose();
                    g.Dispose();
                    bmp.Dispose();
                }

                // Save the PDF document
                document.Save(filePath);

                // Dispose of resources
                document.Dispose();

                MessageBox.Show($"Panels saved as PDF with footer: {filePath}");
            }
        }


        private void DrawFooter(XGraphics gfx, string footerText)
        {
            XFont font = new XFont("Arial", 8);

            XRect rect = new XRect(10, gfx.PageSize.Height - 20, gfx.PageSize.Width - 20, 20);
            gfx.DrawRectangle(XBrushes.White, rect);

            // Align the footer text to the left
            gfx.DrawString(footerText, font, XBrushes.Black, rect.Left, rect.Top, XStringFormats.TopLeft);
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void SavePanelsAsPdfWithFooter(List<Panel> panels)
        //{
        //    // Create SaveFileDialog object
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
        //    saveFileDialog.Title = "Save Panels as PDF";

        //    // Show the dialog and check if the user selects a file
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string filePath = saveFileDialog.FileName;
        //        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //        // Create a new PDF document
        //        PdfDocument document = new PdfDocument();

        //        // Iterate through each panel and add a page to the document
        //        for (int i = 0; i < panels.Count; i++)
        //        {
        //            Panel currentPanel = panels[i];

        //            // Add a page to the document with the size of the current panel
        //            PdfPage page = document.AddPage();
        //            XGraphics gfx = XGraphics.FromPdfPage(page);

        //            // Create a bitmap to draw the panel's content
        //            Bitmap bmp = new Bitmap(currentPanel.Width, currentPanel.Height);
        //            currentPanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

        //            // Create an XImage from the bitmap
        //            XImage xImage = XImage.FromGdiPlusImage(bmp);

        //            // Draw the image onto the PDF page
        //            gfx.DrawImage(xImage, 0, 0, currentPanel.Width, currentPanel.Height);

        //            // Add footer text
        //            DrawFooter(gfx, $"Page {i + 1} of {panels.Count}");

        //            // Dispose of resources for this page
        //            xImage.Dispose();
        //            bmp.Dispose();
        //        }

        //        // Save the PDF document
        //        document.Save(filePath);

        //        // Dispose of resources
        //        document.Dispose();

        //        MessageBox.Show($"Panels saved as PDF with footer: {filePath}");
        //    }
        //}

        //private void DrawFooter(XGraphics gfx, string footerText)
        //{
        //    XFont font = new XFont("Arial", 8);

        //    XRect rect = new XRect(10, gfx.PageSize.Height - 20, gfx.PageSize.Width - 20, 20);
        //    gfx.DrawRectangle(XBrushes.White, rect);

        //    // Align the footer text to the left
        //    gfx.DrawString(footerText, font, XBrushes.Black, rect.Left, rect.Top, XStringFormats.TopLeft);
        //}
    }

    public class CustomFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            {
                // You may need to adjust the path to the Arial font file on your system
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                if (File.Exists(fontPath))
                {
                    using (var fs = new FileStream(fontPath, FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        return ms.ToArray();
                    }
                }
                else
                {
                    throw new FileNotFoundException($"Font file not found: {fontPath}");
                }
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // For simplicity, we assume Arial is always available
            return new FontResolverInfo("Arial");
        }
    }

}

