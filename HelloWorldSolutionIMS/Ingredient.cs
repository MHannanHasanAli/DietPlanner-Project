using ClosedXML.Excel;
using Guna.UI2.WinForms;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static HelloWorldSolutionIMS.MealAction;

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

        private void DecimalLock(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            string text = textBox.Text;

            // Remove leading zeros
            if (text.StartsWith("0") && text.Length > 1 && text[1] != '.')
            {
                textBox.Text = text.TrimStart('0');
                textBox.SelectionStart = textBox.Text.Length;
            }

            // Remove leading decimal point
            if (text.Length > 1 && text.StartsWith("."))
            {
                textBox.Text = "0" + text;
                textBox.SelectionStart = textBox.Text.Length;
            }

            // Remove multiple consecutive decimal points
            if (text.Contains(".."))
            {
                textBox.Text = text.Replace("..", ".");
                textBox.SelectionStart = textBox.Text.Length;
            }

            // Ensure only digits, one decimal point, and up to two decimal places are allowed
            if (!IsValidInput(text))
            {
                // If the input is not valid, remove the last character
                textBox.Text = text.Substring(0, text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
        private bool IsValidInput(string input)
        {
            // Implement your validation logic here
            // Return true if the input is valid, false otherwise
            // For example, allow only digits, one decimal point, and up to two decimal places
            Regex regex = new Regex(@"^\d*\.?\d{0,2}$");
            return regex.IsMatch(input);
        }
        private void ShowIngredients(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn fdc, DataGridViewColumn classification, DataGridViewColumn ingredientAr, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {
            if (languagestatus == 1)
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

                    // Set formatting for columns
                    fats.DefaultCellStyle.Format = "N2";
                    carbohydrates.DefaultCellStyle.Format = "N2";
                    protein.DefaultCellStyle.Format = "N2";
                    calories.DefaultCellStyle.Format = "N0";

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
                SqlCommand cmd;
                try
                {
                    MainClass.con.Open();

                    cmd = new SqlCommand("SELECT ID, fdc_id, CLASSIFICATION, INGREDIENT_EN, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, PROTEIN FROM Ingredient", MainClass.con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                    ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_EN"].ToString();
                    calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                    fats.DataPropertyName = dt.Columns["FATS"].ToString();
                    carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                    fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                    calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                    sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                    protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();
                    fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();

                    // Set formatting for columns
                    fats.DefaultCellStyle.Format = "N2";
                    carbohydrates.DefaultCellStyle.Format = "N2";
                    protein.DefaultCellStyle.Format = "N2";
                    calories.DefaultCellStyle.Format = "N0";

                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void SearchIngredients(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn fdc, DataGridViewColumn classification, DataGridViewColumn ingredientAr, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {

            string ingredientName = ingredientar.Text;
            string groupArName = ingredienten.Text;

            if (languagestatus == 1)
            {
                if (ingredientName != "" && groupArName != "")
                {
                    try
                    {
                        MainClass.con.Open();

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                            "WHERE (INGREDIENT_AR LIKE @IngredientName) AND (INGREDIENT_EN LIKE @GroupArName)", MainClass.con);

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
                        protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();

                        fats.DefaultCellStyle.Format = "N2";
                        carbohydrates.DefaultCellStyle.Format = "N2";
                        protein.DefaultCellStyle.Format = "N2";
                        calories.DefaultCellStyle.Format = "N0";

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

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                            "WHERE INGREDIENT_EN LIKE @GroupArName", MainClass.con);

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
                        protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();

                        fats.DefaultCellStyle.Format = "N2";
                        carbohydrates.DefaultCellStyle.Format = "N2";
                        protein.DefaultCellStyle.Format = "N2";
                        calories.DefaultCellStyle.Format = "N0";

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

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
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
                        protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();

                        fats.DefaultCellStyle.Format = "N2";
                        carbohydrates.DefaultCellStyle.Format = "N2";
                        protein.DefaultCellStyle.Format = "N2";
                        calories.DefaultCellStyle.Format = "N0";
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
                    MessageBox.Show("Fill Ingredient Ar or Ingredient En");
                }
            }
            else
            {
                if (ingredientName != "" && groupArName != "")
                {
                    try
                    {
                        MainClass.con.Open();

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_EN, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                            "WHERE (INGREDIENT_AR LIKE @IngredientName) AND (INGREDIENT_EN LIKE @GroupArName)", MainClass.con);

                        cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");
                        cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Modify the column names to match your data grid view
                        no.DataPropertyName = dt.Columns["ID"].ToString();
                        ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_EN"].ToString();
                        calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                        fats.DataPropertyName = dt.Columns["FATS"].ToString();
                        carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                        fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                        calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                        sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                        classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                        fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();
                        protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();

                        fats.DefaultCellStyle.Format = "N2";
                        carbohydrates.DefaultCellStyle.Format = "N2";
                        protein.DefaultCellStyle.Format = "N2";
                        calories.DefaultCellStyle.Format = "N0";

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

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_EN, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                            "WHERE INGREDIENT_EN LIKE @GroupArName", MainClass.con);

                        cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Modify the column names to match your data grid view
                        no.DataPropertyName = dt.Columns["ID"].ToString();
                        ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_EN"].ToString();
                        calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                        fats.DataPropertyName = dt.Columns["FATS"].ToString();
                        carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                        fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                        calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                        sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                        classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                        fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();
                        protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();

                        fats.DefaultCellStyle.Format = "N2";
                        carbohydrates.DefaultCellStyle.Format = "N2";
                        protein.DefaultCellStyle.Format = "N2";
                        calories.DefaultCellStyle.Format = "N0";

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

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_EN, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                            "WHERE INGREDIENT_AR LIKE @IngredientName", MainClass.con);

                        cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Modify the column names to match your data grid view
                        no.DataPropertyName = dt.Columns["ID"].ToString();
                        ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_EN"].ToString();
                        calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                        fats.DataPropertyName = dt.Columns["FATS"].ToString();
                        carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                        fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                        calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                        sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                        classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                        fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();
                        protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();

                        // Set formatting for columns
                        fats.DefaultCellStyle.Format = "N2";
                        carbohydrates.DefaultCellStyle.Format = "N2";
                        protein.DefaultCellStyle.Format = "N2";
                        calories.DefaultCellStyle.Format = "N0";


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
                    MessageBox.Show("Fill Ingredient Ar or Ingredient En");
                }
            }

        }

        private void ShowIngredientsWithFilter(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn fdc, DataGridViewColumn classification, DataGridViewColumn ingredientAr, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium, string category)
        {
            try
            {
                MainClass.con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                    "WHERE CATEGORY LIKE @Category", MainClass.con);

                cmd.Parameters.AddWithValue("@Category", "%" + category + "%");


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

                fats.DefaultCellStyle.Format = "N2";
                carbohydrates.DefaultCellStyle.Format = "N2";
                protein.DefaultCellStyle.Format = "N2";
                calories.DefaultCellStyle.Format = "N2";

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
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
        private void Ingredient_Load(object sender, EventArgs e)
        {
            LanguageInfo();

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

                    foreach (Control control in panel1.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel2.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel5.Controls)
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

                    foreach (Control control in panel1.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel2.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel5.Controls)
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

                    foreach (System.Windows.Forms.Control control in panel1.Controls)
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
                    foreach (System.Windows.Forms.Control control in panel5.Controls)
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
            MainClass.HideAllTabsOnTabControl(tabControl1);
            tabControl1.SelectedIndex = 0;
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView1.GridColor = Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;
            chart1.Series.Clear();
            UpdateGroups();
            loadcheck = 1;
            if (languagestatus == 1)
            {
                foreach (Control control in panel1.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel1.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel2.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel1.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel5.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel1.Width - currentLoc.X - control.Width, currentLoc.Y);

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

            guna2DataGridView1.Columns["fatsdgv"].DefaultCellStyle.Format = "N2";
            guna2DataGridView1.Columns["carbohydratedgv"].DefaultCellStyle.Format = "N2";
            guna2DataGridView1.Columns["proteindgv"].DefaultCellStyle.Format = "N2";
            guna2DataGridView1.Columns["calloriesdgv"].DefaultCellStyle.Format = "N0";

            ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);

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
                        //categorybox.SelectedItem = null;

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
                        //cmd.Parameters.AddWithValue("@Category", categorybox.Text);
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
                        //categorybox.SelectedItem = null;
                        MainClass.con.Close();
                        importall.Visible = true;
                        importbranded.Visible = true;
                        importff.Visible = true;
                        importfndds.Visible = true;
                        importlocal.Visible = true;
                        importsr.Visible = true;
                        //categorylabel.Visible = false;
                        //categorybox.Visible = false;
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
                        //categorybox.SelectedItem = null;
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
            importall.Visible = false;
            importbranded.Visible = false;
            importff.Visible = false;
            importfndds.Visible = false;
            importlocal.Visible = false;
            importsr.Visible = false;
            //categorylabel.Visible = true;
            //categorybox.Visible = true;
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
                        //categorybox.Text = reader["Category"].ToString();
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
        static int conn = 0;
        public void ImportExcelToDatabase(string excelFilePath)
        {
            if (MainClass.con.State != ConnectionState.Open)
            {
                MainClass.con.Open();
                conn = 1;
            }
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string ingredientAR = worksheet.Cells[row, 4].Value?.ToString();
                        string ingredientEN = worksheet.Cells[row, 3].Value?.ToString();
                        string groupAR = worksheet.Cells[row, 6].Value?.ToString();
                        string groupEN = worksheet.Cells[row, 5].Value?.ToString();
                        if (string.IsNullOrEmpty(ingredientAR) && !string.IsNullOrEmpty(ingredientEN))
                        {
                            ingredientAR = "";
                        }
                        else if (string.IsNullOrEmpty(ingredientAR) && string.IsNullOrEmpty(ingredientEN))
                        {
                            ingredientAR = "";
                            ingredientEN = "";
                        }

                        if (string.IsNullOrEmpty(ingredientEN) && !string.IsNullOrEmpty(ingredientAR))
                        {
                            ingredientEN = "";
                        }

                        if (string.IsNullOrEmpty(groupAR) && !string.IsNullOrEmpty(groupEN))
                        {
                            groupAR = "Null";
                        }
                        else if (string.IsNullOrEmpty(groupAR) && string.IsNullOrEmpty(groupEN))
                        {
                            groupAR = "Null";
                            groupEN = "Null";
                        }

                        if (string.IsNullOrEmpty(groupEN) && !string.IsNullOrEmpty(groupAR))
                        {
                            groupEN = "Null";
                        }

                        float calories, fats, fibers, potassium, water, sugar, calcium, a, protein, carbohydrates, sodium, phosphor, magnesium, iron, iodine, b;
                        int fdc_id;
                        string datatype = null;

                        float.TryParse(worksheet.Cells[row, 7].Value?.ToString(), out calories);
                        float.TryParse(worksheet.Cells[row, 9].Value?.ToString(), out fats);
                        float.TryParse(worksheet.Cells[row, 13].Value?.ToString(), out fibers);
                        float.TryParse(worksheet.Cells[row, 18].Value?.ToString(), out potassium);
                        float.TryParse(worksheet.Cells[row, 11].Value?.ToString(), out water);
                        float.TryParse(worksheet.Cells[row, 12].Value?.ToString(), out sugar);
                        float.TryParse(worksheet.Cells[row, 14].Value?.ToString(), out calcium);
                        float.TryParse(worksheet.Cells[row, 21].Value?.ToString(), out a);
                        float.TryParse(worksheet.Cells[row, 8].Value?.ToString(), out protein);
                        float.TryParse(worksheet.Cells[row, 10].Value?.ToString(), out carbohydrates);
                        float.TryParse(worksheet.Cells[row, 19].Value?.ToString(), out sodium);
                        float.TryParse(worksheet.Cells[row, 17].Value?.ToString(), out phosphor);
                        float.TryParse(worksheet.Cells[row, 16].Value?.ToString(), out magnesium);
                        float.TryParse(worksheet.Cells[row, 15].Value?.ToString(), out iron);
                        float.TryParse(worksheet.Cells[row, 20].Value?.ToString(), out iodine);
                        float.TryParse(worksheet.Cells[row, 22].Value?.ToString(), out b);
                        int.TryParse(worksheet.Cells[row, 1].Value?.ToString(), out fdc_id);

                        // Extracting datatype and category
                        string datatypeString = worksheet.Cells[row, 2].Value?.ToString();
                        if (!string.IsNullOrEmpty(datatypeString))
                        {
                            datatype = datatypeString;
                        }
                        else
                        {
                            datatype = "";
                        }

                        // The columns from the Excel file are not null or empty, proceed to insert the record
                        string query = "INSERT INTO Ingredient (INGREDIENT_AR, INGREDIENT_EN, GROUP_AR, GROUP_EN, " +
                                       "CLASSIFICATION, CALORIES, FATS, FIBERS, POTASSIUM, WATER, SUGAR, CALCIUM, A, " +
                                       "PROTEIN, CARBOHYDRATES, SODIUM, PHOSPHOR, MAGNESIUM, IRON, IODINE, B, fdc_id, " +
                                       "datatype, Category) VALUES (@IngredientAR, @IngredientEN, @GroupAR, @GroupEN, " +
                                       "@Classification, @Calories, @Fats, @Fibers, @Potassium, @Water, @Sugar, @Calcium, " +
                                       "@A, @Protein, @Carbohydrates, @Sodium, @Phosphor, @Magnesium, @Iron, @Iodine, @B, " +
                                       "@fdc_id, @datatype, @Category)";

                        using (SqlCommand command = new SqlCommand(query, MainClass.con))
                        {
                            command.Parameters.AddWithValue("@IngredientAR", ingredientAR);
                            command.Parameters.AddWithValue("@IngredientEN", ingredientEN);
                            command.Parameters.AddWithValue("@GroupAR", groupAR);
                            command.Parameters.AddWithValue("@GroupEN", groupEN);
                            command.Parameters.AddWithValue("@Classification", "Per 100 gram");
                            command.Parameters.AddWithValue("@Calories", calories);
                            command.Parameters.AddWithValue("@Fats", fats);
                            command.Parameters.AddWithValue("@Fibers", fibers);
                            command.Parameters.AddWithValue("@Potassium", potassium);
                            command.Parameters.AddWithValue("@Water", water);
                            command.Parameters.AddWithValue("@Sugar", sugar);
                            command.Parameters.AddWithValue("@Calcium", calcium);
                            command.Parameters.AddWithValue("@A", a);
                            command.Parameters.AddWithValue("@Protein", protein);
                            command.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
                            command.Parameters.AddWithValue("@Sodium", sodium);
                            command.Parameters.AddWithValue("@Phosphor", phosphor);
                            command.Parameters.AddWithValue("@Magnesium", magnesium);
                            command.Parameters.AddWithValue("@Iron", iron);
                            command.Parameters.AddWithValue("@Iodine", iodine);
                            command.Parameters.AddWithValue("@B", b);
                            command.Parameters.AddWithValue("@fdc_id", fdc_id);
                            command.Parameters.AddWithValue("@datatype", datatype);
                            command.Parameters.AddWithValue("@Category", datatype);

                            command.ExecuteNonQuery();

                        }

                    }
                    if (conn == 1)
                    {
                        MainClass.con.Close();
                        conn = 0;
                    }
                    ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);
                    MessageBox.Show("Ingredients imported successfully!");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }


        }
        private void importall_Click(object sender, EventArgs e)
        {

            ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);

        }
        private void importff_Click(object sender, EventArgs e)
        {

            ShowIngredientsWithFilter(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv, "Foundation Foods");

        }
        private void importsr_Click(object sender, EventArgs e)
        {

            ShowIngredientsWithFilter(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv, "SR Legacy");

        }
        private void importfndds_Click(object sender, EventArgs e)
        {

            ShowIngredientsWithFilter(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv, "FNDDS");

        }

        private void importbranded_Click(object sender, EventArgs e)
        {

            ShowIngredientsWithFilter(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv, "Branded");

        }

        private void importlocal_Click(object sender, EventArgs e)
        {

            ShowIngredientsWithFilter(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv, "Local");

        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    ImportExcelToDatabase(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveGroupn_Click(object sender, EventArgs e)
        {
            if (agnar.Text != "" && agnen.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO GroupIngredients (Namear, Nameen) " +
                        "VALUES (@Namear, @Nameen)", MainClass.con);

                    cmd.Parameters.AddWithValue("@Namear", agnar.Text);
                    cmd.Parameters.AddWithValue("@Nameen", agnen.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully");
                    MainClass.con.Close();

                    agnar.Text = "";
                    agnen.Text = "";

                    ShowGroupIngredients(guna2DataGridView3, idgn, gnnar, gnnen);
                    tabControl1.SelectedIndex = 2;

                    UpdateGroups();

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
            tabControl1.SelectedIndex = 0;
        }

        private void agn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void CLoseDGN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void ShowGroupIngredients(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn namear, DataGridViewColumn nameen)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID, Namear, Nameen FROM GroupIngredients", MainClass.con);

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

        private void UpdateGroups()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, Namear, Nameen FROM GroupIngredients", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Clear the dropdown items before adding new ones
                groupar.DataSource = null;
                groupen.DataSource = null;

                // Clear the items (if DataSource is not being set)
                groupar.Items.Clear();
                groupen.Items.Clear();
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

                if (conn == 1)
                {
                    MainClass.con.Close();
                    conn = 0;
                }

                groupar.DataSource = GroupNAR;
                groupar.DisplayMember = "NameAR"; // Display Member is Name
                groupar.ValueMember = "ID"; // Value Member is ID

                groupen.DataSource = GroupNAR;
                groupen.DisplayMember = "NameEN"; // Display Member is Name
                groupen.ValueMember = "ID"; // Value Member is ID



            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
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
                                SqlCommand cmd = new SqlCommand("DELETE FROM GroupIngredients WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", groupid); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                //tabControl1.SelectedIndex = 2;
                                ShowGroupIngredients(guna2DataGridView3, idgn, gnnar, gnnen);
                                UpdateGroups();

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
            ShowGroupIngredients(guna2DataGridView3, idgn, gnnar, gnnen);
            tabControl1.SelectedIndex = 2;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void export_Click(object sender, EventArgs e)
        {

            ExportIngredientsToExcel();
        }
        private void ExportIngredientsToExcel()
        {
            try
            {
                MainClass.con.Open();

                // SQL query to select all rows from the Ingredient table
                string query = "SELECT fdc_id, INGREDIENT_AR, INGREDIENT_EN, GROUP_AR, GROUP_EN, CLASSIFICATION, CALORIES, FATS, FIBERS, POTASSIUM, WATER, SUGAR, CALCIUM, A, PROTEIN, CARBOHYDRATES, SODIUM, PHOSPHOR, MAGNESIUM, IRON, IODINE, B FROM Ingredient;";

                using (SqlCommand command = new SqlCommand(query, MainClass.con))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        // Create a DataTable to hold the data
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Call the ExportToExcel function to save the data to Excel
                        ExportToExcel(dataTable);
                    }
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(DataTable dataTable)
        {
            try
            {
                // Create SaveFileDialog object
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Save As Excel File";
                saveFileDialog.DefaultExt = "xlsx";

                // Show the Save As dialog and check if the user selects a file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Creating Excel Workbook
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    // Writing Header
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i).Value = dataTable.Columns[i - 1].ColumnName;
                    }

                    // Writing Rows
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataTable.Rows[i][j].ToString();
                        }
                    }

                    // Save the workbook to the user-selected file path
                    string filePath = saveFileDialog.FileName;
                    workbook.SaveAs(filePath);

                    MessageBox.Show($"Data exported to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GroupFilterIngredients(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn fdc, DataGridViewColumn classification, DataGridViewColumn ingredientAr, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        {

            string groupartext = groupar.Text;


            if (languagestatus == 1)
            {
                if (groupartext != "" && groupartext != "Null")
                {
                    try
                    {
                        MainClass.con.Open();

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_AR, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                            "WHERE (Group_AR LIKE @GroupArName)", MainClass.con);


                        cmd.Parameters.AddWithValue("@GroupArName", "%" + groupartext + "%");

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
                    ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);
                }
            }
            else
            {
                if (groupartext != "" && groupartext != "Null")
                {
                    try
                    {
                        MainClass.con.Open();

                        SqlCommand cmd = new SqlCommand("SELECT ID, fdc_id, INGREDIENT_EN, CALORIES, FATS, PROTEIN, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM, CLASSIFICATION FROM Ingredient " +
                            "WHERE (Group_AR LIKE @GroupArName)", MainClass.con);


                        cmd.Parameters.AddWithValue("@GroupArName", "%" + groupartext + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Modify the column names to match your data grid view
                        no.DataPropertyName = dt.Columns["ID"].ToString();
                        ingredientAr.DataPropertyName = dt.Columns["INGREDIENT_EN"].ToString();
                        calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
                        fats.DataPropertyName = dt.Columns["FATS"].ToString();
                        carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
                        fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
                        calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
                        sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
                        classification.DataPropertyName = dt.Columns["CLASSIFICATION"].ToString();
                        fdc.DataPropertyName = dt.Columns["fdc_id"].ToString();
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
                    ShowIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);

                }
            }

        }

        static int loadcheck = 0;
        private void groupar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (loadcheck == 1)
            {
                GroupFilterIngredients(guna2DataGridView1, nodgv, fdciddgv, classificationdgv, ingredientardgv, calloriesdgv, proteindgv, fatsdgv, carbohydratedgv, calciumdgv, fibersdgv, sodiumdgv);

            }

        }

        private void calories_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            string newText = GetFormattedText(text: textBox.Text);

            // If the new text is different from the current text, update the TextBox
            if (newText != textBox.Text)
            {
                textBox.Text = newText;
                textBox.SelectionStart = newText.Length;
            }
        }
        private string GetFormattedText(string text)
        {
            // Remove anything after the decimal point and any non-digit characters
            string cleanText = Regex.Replace(text, @"[^\d.]", "");

            // If a decimal point is present, keep the digits before it
            int decimalIndex = cleanText.IndexOf('.');
            if (decimalIndex != -1)
            {
                cleanText = cleanText.Substring(0, decimalIndex);
            }

            return cleanText;
        }
        private void TwoDecimalLock(object sender, KeyPressEventArgs e)
        {

            Guna2TextBox textBox = (Guna2TextBox)sender;

            // Allow only digits, one decimal point, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.' || textBox.Text.Contains(".")))
            {
                e.Handled = true;
            }

            // Allow only up to two decimal places
            if (textBox.Text.Contains("."))
            {
                string[] parts = textBox.Text.Split('.');
                if (parts.Length > 1 && parts[1].Length >= 2)
                {
                    e.Handled = true;
                }
            }

            // Allow backspace after two digits
            if (e.KeyChar == '\b' && textBox.Text.Length > 2)
            {
                e.Handled = false;
            }


        }
        private void calories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }
    }

}
