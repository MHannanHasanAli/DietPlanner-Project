using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class Diabetes : Form
    {
        static int coderunner = 0;
        public Diabetes()
        {
            InitializeComponent();
            weight.KeyPress += weight_KeyPress;
            weight.TextChanged += weight_TextChanged;

        }
        static int valueid = 0;
        public Diabetes(int id)
        {
            InitializeComponent();
            weight.KeyPress += weight_KeyPress;
            weight.TextChanged += weight_TextChanged;
            coderunner = id;
            LoadData(id);


        }
        static int total;
        static double insulincharbcalc;
        static int rowflag = 0;

        public double RoundNumber(double number, int decimalPlaces)
        {
            return Math.Round(number, decimalPlaces);
        }
        private void updatetotal()
        {
            if (guna2DataGridView1.Rows[4].Cells[1].Value != "")
            {
                int totalval = int.Parse(guna2DataGridView1.Rows[4].Cells[1].Value.ToString());
                totalval = total;
                guna2DataGridView1.Rows[4].Cells[1].Value = totalval;
            }

        }

        private void LoadData(int id)
        {
            try
            {
                string filenoTOedit = "";
                string savedweight = "";
                idToEdit = id;

                MainClass.con.Open();

                // Fetch the row based on ID
                SqlCommand selectCmd = new SqlCommand("SELECT * FROM Diabetes WHERE ID = @ID", MainClass.con);
                selectCmd.Parameters.AddWithValue("@ID", idToEdit);

                SqlDataReader reader = selectCmd.ExecuteReader();

                if (reader.Read())
                {
                    filenoTOedit = reader["FileNo"].ToString();
                    savedweight = reader["Weight"].ToString();
                    weight.Text = reader["Weight"].ToString();
                    guna2DataGridView1.Rows[0].Cells[1].Value = reader["BFInsulin"];
                    guna2DataGridView1.Rows[1].Cells[1].Value = reader["LInsulin"];
                    guna2DataGridView1.Rows[2].Cells[1].Value = reader["DInsulin"];
                    guna2DataGridView1.Rows[3].Cells[1].Value = reader["SInsulin"];
                    guna2DataGridView2.Rows[0].Cells[1].Value = reader["BFCarbs"];
                    guna2DataGridView2.Rows[1].Cells[1].Value = reader["LCarbs"];
                    guna2DataGridView2.Rows[2].Cells[1].Value = reader["DCarbs"];
                    guna2DataGridView2.Rows[3].Cells[1].Value = reader["SCarbs"];
                    guna2DataGridView4.Rows[0].Cells[2].Value = reader["FastingGlucose"];
                    guna2DataGridView4.Rows[1].Cells[2].Value = reader["BeforeLunch"];
                    guna2DataGridView4.Rows[2].Cells[2].Value = reader["BeforeDinner"];
                    guna2DataGridView4.Rows[3].Cells[2].Value = reader["BedTime"];

                }
                else
                {
                    MessageBox.Show("No data found for the specified ID");
                }

                reader.Close();
                MainClass.con.Close();
                fileno.Text = filenoTOedit;
                weight.Text = savedweight;
                FillData();
                tabControl1.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainClass.con.Close();
            }
        }

        private void AddFiveRowsToTablecarbs()
        {

            if (languagestatus == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    // Add a new row to the DataGridView
                    int rowIndex = guna2DataGridView2.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "الافطار"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "الغداء"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "العشاء"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "الوجبات الخفيفة"; // Add text to cell 2 (index 1)
                    }
                    else
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "المجموع";
                        //guna2DataGridView2.Rows[rowIndex].Cells[1].Value = total* insulincharbcalc;
                        //guna2DataGridView2.Rows[rowIndex].Cells[2].Value = total;// Add text to cell 2 (index 1)
                    }
                    // Add specific text to the second and third cells of each row
                }

            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    // Add a new row to the DataGridView
                    int rowIndex = guna2DataGridView2.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "BREAKFAST"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "LUNCH"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "DINNER"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "SNACKS"; // Add text to cell 2 (index 1)
                    }
                    else
                    {
                        guna2DataGridView2.Rows[rowIndex].Cells[0].Value = "TOTAL";
                        //guna2DataGridView2.Rows[rowIndex].Cells[1].Value = total* insulincharbcalc;
                        //guna2DataGridView2.Rows[rowIndex].Cells[2].Value = total;// Add text to cell 2 (index 1)
                    }
                    // Add specific text to the second and third cells of each row
                }
            }

        }
        private void AddFiveRowsToTable()
        {

            if (languagestatus == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    // Add a new row to the DataGridView
                    int rowIndex = guna2DataGridView1.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "الافطار "; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "الغداء"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "العشاء "; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "الوجبات الخفيفة "; // Add text to cell 2 (index 1)
                    }
                    else
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "المجموع ";
                        guna2DataGridView1.Rows[rowIndex].Cells[1].Value = total;// Add text to cell 2 (index 1)
                    }
                    // Add specific text to the second and third cells of each row
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    // Add a new row to the DataGridView
                    int rowIndex = guna2DataGridView1.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "BREAKFAST"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "LUNCH"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "DINNER"; // Add text to cell 2 (index 1)
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "SNACKS"; // Add text to cell 2 (index 1)
                    }
                    else
                    {
                        guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "TOTAL";
                        guna2DataGridView1.Rows[rowIndex].Cells[1].Value = total;// Add text to cell 2 (index 1)
                    }
                    // Add specific text to the second and third cells of each row
                }
            }


        }
        private void AddRowsToBloodSuger()
        {
            if (languagestatus == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    // Add a new row to the DataGridView
                    int rowIndex = guna2DataGridView4.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "سكر الدم الصيامي"; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "130";
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "سكر الدم قبل الغداء "; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "180";
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "سكر الدم قبل العشاء "; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "180";
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "سكر الدم قبل النوم "; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "150";
                    }

                    // Add specific text to the second and third cells of each row
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    // Add a new row to the DataGridView
                    int rowIndex = guna2DataGridView4.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "FASTING GLUCOSE"; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "130";
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "BEFORE LUNCH"; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "180";
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "BEFORE DINNER"; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "180";
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView4.Rows[rowIndex].Cells[0].Value = "BED TIME"; // Add text to cell 2 (index 1)
                        guna2DataGridView4.Rows[rowIndex].Cells[1].Value = "150";
                    }

                    // Add specific text to the second and third cells of each row
                }
            }

            guna2DataGridView4.ClearSelection();
        }
        private void AddRowsToCorrectionFactor()
        {

            if (languagestatus == 1)
            {
                for (int i = 0; i < 5; i++)
                {

                    int rowIndex = guna2DataGridView5.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "عامل التصحيح "; // Add text to cell 2 (index 1)                   
                        cofactor = 1800 / totalinsulinperday;
                        cofactor = Math.Round(cofactor, 2);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = cofactor;
                    }
                    else if (rowIndex == 1)
                    {
                        var value = fastingglucose / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "وحدات الانسولين قبل الافطار"; // Add text to cell 2 (index 1)
                        cfb = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    else if (rowIndex == 2)
                    {
                        var value = beforelunch / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "وحدات الانسولين قبل الغداء"; // Add text to cell 2 (index 1)
                        cfl = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    else if (rowIndex == 3)
                    {
                        var value = beforedinner / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "وحدات الانسولين قبل العشاء"; // Add text to cell 2 (index 1)
                        cfd = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    else if (rowIndex == 4)
                    {
                        var value = bedtime / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "وحدات الانسولين قبل النوم "; // Add text to cell 2 (index 1)
                        cfs = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    // Add specific text to the second and third cells of each row
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {

                    int rowIndex = guna2DataGridView5.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "Correction Factor"; // Add text to cell 2 (index 1)                   
                        cofactor = 1800 / totalinsulinperday;
                        cofactor = Math.Round(cofactor, 2);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = cofactor;
                    }
                    else if (rowIndex == 1)
                    {
                        var value = fastingglucose / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "Insulin units required before breakfast"; // Add text to cell 2 (index 1)
                        cfb = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    else if (rowIndex == 2)
                    {
                        var value = beforelunch / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "Insulin units required before lunch"; // Add text to cell 2 (index 1)
                        cfl = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    else if (rowIndex == 3)
                    {
                        var value = beforedinner / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "Insulin units required before dinner"; // Add text to cell 2 (index 1)
                        cfd = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    else if (rowIndex == 4)
                    {
                        var value = bedtime / cofactor;
                        guna2DataGridView5.Rows[rowIndex].Cells[0].Value = "Insulin units required before bed"; // Add text to cell 2 (index 1)
                        cfs = RoundNumber(value, 0);
                        guna2DataGridView5.Rows[rowIndex].Cells[1].Value = RoundNumber(value, 0);
                    }
                    // Add specific text to the second and third cells of each row
                }
            }

            guna2DataGridView4.ClearSelection();
        }
        static double cfb;
        static double cfl;
        static double cfd;
        static double cfs;
        private void AddRowsToCorrection()
        {

            int one = 0;
            int two = 0;
            int three = 0;
            int four = 0;
            for (int i = 0; i < 5; i++)
            {
                if (languagestatus == 1)
                {
                    int rowIndex = guna2DataGridView6.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "الافطار "; // Add text to cell 2 (index 1)                   
                        one = (int)(cfb + ib);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(one, 0);
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "الغداء"; // Add text to cell 2 (index 1)
                        two = (int)(cfl + il);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(two, 0);
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "العشاء "; // Add text to cell 2 (index 1)
                        three = (int)(cfd + id);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(three, 0);
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "الوجبات الخفيفة "; // Add text to cell 2 (index 1)
                        four = (int)(cfs + iss);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(four, 0);
                    }
                    else if (rowIndex == 4)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "المجموع "; // Add text to cell 2 (index 1)
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = one + two + three + four;
                    }
                }
                else
                {
                    int rowIndex = guna2DataGridView6.Rows.Add();
                    if (rowIndex == 0)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "BREAKFAST"; // Add text to cell 2 (index 1)                   
                        one = (int)(cfb + ib);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(one, 0);
                    }
                    else if (rowIndex == 1)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "LUNCH"; // Add text to cell 2 (index 1)
                        two = (int)(cfl + il);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(two, 0);
                    }
                    else if (rowIndex == 2)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "DINNER"; // Add text to cell 2 (index 1)
                        three = (int)(cfd + id);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(three, 0);
                    }
                    else if (rowIndex == 3)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "SNACKS"; // Add text to cell 2 (index 1)
                        four = (int)(cfs + iss);
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = RoundNumber(four, 0);
                    }
                    else if (rowIndex == 4)
                    {
                        guna2DataGridView6.Rows[rowIndex].Cells[0].Value = "TOTAL"; // Add text to cell 2 (index 1)
                        guna2DataGridView6.Rows[rowIndex].Cells[1].Value = one + two + three + four;
                    }
                }

                // Add specific text to the second and third cells of each row
            }
            guna2DataGridView6.ClearSelection();
        }

        static float bv;
        static float lv;
        static float dv;
        static float sv;
        static float tv;

        static double totalinsulinperday;
        private void weight_TextChanged(object sender, EventArgs e)
        {
            if (weight.Text != "")
            {
                float w = float.Parse(weight.Text);

                var totalinsulinvar = w * 0.55;
                double rounded = RoundNumber(totalinsulinvar, 0);
                totalinsulinvar = RoundNumber(totalinsulinvar, 2);
                totalinsulinperday = totalinsulinvar;
                int baseline = (int)(rounded / 2);
                int bolus = baseline;
                total = baseline;
                double insulin_charb = 500 / totalinsulinvar;
                string formattedInsulinCharb = insulin_charb.ToString("0.00");
                insulincharbcalc = double.Parse(formattedInsulinCharb);

                totalinsulin.Text = totalinsulinvar.ToString();
                baselineinsulin.Text = baseline.ToString();
                bolusinsulin.Text = bolus.ToString();
                insulincharb.Text = formattedInsulinCharb;
                //guna2DataGridView2.Rows[4].Cells[1].Value = total * insulincharbcalc;
                //guna2DataGridView2.Rows[4].Cells[2].Value = total;
                updatetotal();
            }


        }
        private void weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.') && (e.KeyChar != '-'))
                {
                    e.Handled = true; // Ignore the keypress if it's not a number, a decimal point, or a minus sign
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && textBox.Text.Contains("."))
                {
                    e.Handled = true;
                }

                // Allow a minus sign only at the beginning
                if (e.KeyChar == '-' && textBox.Text.Length > 0)
                {
                    e.Handled = true;
                }

                // Allow a minus sign after a decimal point
                if (e.KeyChar == '-' && textBox.Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }

        static double table_total;
        static double table_total2;

        static int languagestatus;

        private void ClearForm()
        {
            fastingglucose = 0;
            beforelunch = 0;
            beforedinner = 0;
            bedtime = 0;
            cofactor = 0;

            ib = 0;
            il = 0;
            id = 0;
            iss = 0;

            cfb = 0;
            cfl = 0;
            cfd = 0;
            cfs = 0;

            table_total = 0;

            fileno.Text = "";
            weight.Text = "";
            totalinsulin.Text = "";
            baselineinsulin.Text = "";
            bolusinsulin.Text = "";
            insulincharb.Text = "";

            guna2DataGridView1.Rows[4].Cells[1].Value = "0";
            guna2DataGridView1.Rows[0].Cells[1].Value = "0";
            guna2DataGridView1.Rows[1].Cells[1].Value = "0";
            guna2DataGridView1.Rows[2].Cells[1].Value = "0";
            guna2DataGridView1.Rows[3].Cells[1].Value = "0";

            guna2DataGridView2.Rows[4].Cells[1].Value = "0";
            guna2DataGridView2.Rows[0].Cells[1].Value = "0";
            guna2DataGridView2.Rows[1].Cells[1].Value = "0";
            guna2DataGridView2.Rows[2].Cells[1].Value = "0";
            guna2DataGridView2.Rows[3].Cells[1].Value = "0";

            guna2DataGridView2.Rows[4].Cells[2].Value = "0";
            guna2DataGridView2.Rows[0].Cells[2].Value = "0";
            guna2DataGridView2.Rows[1].Cells[2].Value = "0";
            guna2DataGridView2.Rows[2].Cells[2].Value = "0";
            guna2DataGridView2.Rows[3].Cells[2].Value = "0";

            guna2DataGridView4.Rows[0].Cells[2].Value = "0";
            guna2DataGridView4.Rows[1].Cells[2].Value = "0";
            guna2DataGridView4.Rows[2].Cells[2].Value = "0";
            guna2DataGridView4.Rows[3].Cells[2].Value = "0";

            if (guna2DataGridView6.Rows.Count > 0)
            {
                guna2DataGridView6.Rows[4].Cells[1].Value = "0";
                guna2DataGridView6.Rows[0].Cells[1].Value = "0";
                guna2DataGridView6.Rows[1].Cells[1].Value = "0";
                guna2DataGridView6.Rows[2].Cells[1].Value = "0";
                guna2DataGridView6.Rows[3].Cells[1].Value = "0";
            }


        }
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
        static int edit = 0;
        private void Diabetes_Load(object sender, EventArgs e)
        {
            MainClass.HideAllTabsOnTabControl(tabControl1);
            fastingglucose = 0;
            beforelunch = 0;
            beforedinner = 0;
            bedtime = 0;
            cofactor = 0;

            ib = 0;
            il = 0;
            id = 0;
            iss = 0;

            cfb = 0;
            cfl = 0;
            cfd = 0;
            cfs = 0;

            table_total = 0;



            guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;
            guna2DataGridView2.CellValueChanged += guna2DataGridView2_CellValueChanged;

            guna2DataGridView1.Visible = false;
            guna2DataGridView2.Visible = false;

            if (coderunner != 0)
            {
                fileno.Text = coderunner.ToString();
                coderunner = 0;
            }
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
                    System.Drawing.Color color = System.Drawing.Color.FromArgb(red, green, blue);

                    foreach (System.Windows.Forms.Control control in panel1.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }

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
                    System.Drawing.Color color = System.Drawing.Color.FromArgb(red, green, blue);

                    foreach (System.Windows.Forms.Control control in panel1.Controls)
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

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }

                    foreach (System.Windows.Forms.Control control in panel2.Controls)
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

            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView1.GridColor = System.Drawing.Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView2.GridColor = System.Drawing.Color.Black;
            guna2DataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView2.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView2.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView4.GridColor = System.Drawing.Color.Black;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView4.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView4.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView5.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView5.GridColor = System.Drawing.Color.Black;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView5.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView5.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView7.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView7.GridColor = System.Drawing.Color.Black;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView7.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView7.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView7.Visible = false;

            guna2DataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView6.GridColor = System.Drawing.Color.Black;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView6.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView6.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView6.Rows.Clear();

            guna2DataGridView8.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView8.GridColor = System.Drawing.Color.Black;
            guna2DataGridView8.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView8.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView8.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView8.RowTemplate.DefaultCellStyle.ForeColor;

            LanguageInfo();
            if (languagestatus == 1)
            {

                foreach (System.Windows.Forms.Control control in panel1.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new System.Drawing.Point(panel1.Width - currentLoc.X - control.Width, currentLoc.Y);

                    // Set the mirrored location to the control
                    control.Location = mirroredLoc;

                    // Check if the control is a TextBox and set RightToLeft to true
                    if (control is Guna2TextBox textBox)
                    {
                        textBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    }

                    if (control is Guna2DataGridView tabel)
                    {
                        tabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    }
                }

                foreach (System.Windows.Forms.Control control in panel2.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new System.Drawing.Point(panel2.Width - currentLoc.X - control.Width, currentLoc.Y);

                    // Set the mirrored location to the control
                    control.Location = mirroredLoc;

                    // Check if the control is a TextBox and set RightToLeft to true
                    if (control is Guna2TextBox textBox)
                    {
                        textBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    }

                    if (control is Guna2DataGridView tabel)
                    {
                        tabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    }
                }

            }

            AddFiveRowsToTable();
            AddFiveRowsToTablecarbs();
            AddRowsToBloodSuger();
            ShowDiabetes(guna2DataGridView8, iddgv, filenodgv, firstnamedgv, familynamedgv, weightdgv);
            edit = 0;

        }

        static int counter = 0;
        static double ib;
        static double il;
        static double id;
        static double iss;
        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1 && e.RowIndex != 4 && e.RowIndex >= 0)// Change this to the index of the column to monitor          
            {
                if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    table_total = 0;
                    string changedValue = guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    guna2DataGridView7.Visible = true;
                    for (int i = 0; i < 4; i++)
                    {
                        if (guna2DataGridView1.Rows[0 + i].Cells[e.ColumnIndex].Value != null)
                        {
                            table_total += double.Parse(guna2DataGridView1.Rows[0 + i].Cells[e.ColumnIndex].Value.ToString());
                        }
                    }
                    //table_total += double.Parse(changedValue);
                    if (table_total <= total)
                    {
                        double cellvalue = double.Parse(changedValue) * insulincharbcalc;

                        guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = cellvalue;
                        string val = guna2DataGridView1.Rows[4].Cells[e.ColumnIndex + 1].Value?.ToString();
                        double new_value = 0;

                        if (val == null)
                        {
                            guna2DataGridView1.Rows[4].Cells[e.ColumnIndex + 1].Value = cellvalue;
                            rowflag = 0;
                        }
                        else
                        {

                            if (rowflag == 0)
                            {

                                rowflag = 1;
                            }
                            else
                            {
                                float finalval = 0;
                                new_value = double.Parse(val) + cellvalue / 2;
                                for (int i = 0; i < 4; i++)
                                {
                                    if (guna2DataGridView1.Rows[i].Cells[e.ColumnIndex + 1].Value != null)
                                    {
                                        finalval += float.Parse(guna2DataGridView1.Rows[i].Cells[e.ColumnIndex + 1].Value.ToString());

                                    }
                                }
                                guna2DataGridView1.Rows[4].Cells[e.ColumnIndex + 1].Value = finalval;
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Total number of insulin exceeded!");
                    }

                    if (totalinsulin.Text != "")
                    {
                        if (guna2DataGridView1.Rows[0].Selected)
                        {
                            ib = double.Parse(guna2DataGridView1.Rows[0].Cells[1].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();


                        }
                        else if (guna2DataGridView1.Rows[1].Selected)
                        {
                            il = double.Parse(guna2DataGridView1.Rows[1].Cells[1].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();
                        }
                        else if (guna2DataGridView1.Rows[2].Selected)
                        {
                            id = double.Parse(guna2DataGridView1.Rows[2].Cells[1].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();
                        }
                        else if (guna2DataGridView1.Rows[3].Selected)
                        {
                            iss = double.Parse(guna2DataGridView1.Rows[3].Cells[1].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();
                        }
                    }
                }
            }

        }

        static int full = 0;
        static int shots = 0;
        private void guna2DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1 && e.RowIndex != 4 && e.RowIndex >= 0)// Change this to the index of the column to monitor
            {
                if (guna2DataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    table_total2 = 0;
                    shots = 0;
                    string changedValue = guna2DataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (changedValue == "0")
                    {
                        return;
                    }
                    guna2DataGridView7.Visible = true;
                    for (int i = 0; i < 4; i++)
                    {
                        if (guna2DataGridView2.Rows[0 + i].Cells[e.ColumnIndex].Value != null)
                        {
                            table_total2 += double.Parse(guna2DataGridView2.Rows[0 + i].Cells[e.ColumnIndex].Value.ToString());
                        }
                    }


                    //table_total2 += double.Parse(changedValue);

                    double cellvalue = double.Parse(changedValue) / insulincharbcalc;
                    double round = RoundNumber(cellvalue, 0);

                    guna2DataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = int.Parse(round.ToString());
                    for (int i = 0; i < 4; i++)
                    {
                        if (guna2DataGridView2.Rows[0 + i].Cells[e.ColumnIndex + 1].Value != null)
                        {
                            shots += int.Parse(guna2DataGridView2.Rows[0 + i].Cells[e.ColumnIndex + 1].Value.ToString());
                        }
                    }
                    //shots = shots + int.Parse(round.ToString());
                    string val = guna2DataGridView2.Rows[4].Cells[e.ColumnIndex + 1].Value?.ToString();

                    guna2DataGridView2.Rows[4].Cells[2].Value = shots;
                    guna2DataGridView2.Rows[4].Cells[1].Value = table_total2;

                    if (val == null)
                    {
                        guna2DataGridView2.Rows[4].Cells[e.ColumnIndex + 1].Value = cellvalue;
                    }

                    if (totalinsulin.Text != "")
                    {
                        if (guna2DataGridView2.Rows[0].Selected)
                        {
                            ib = double.Parse(guna2DataGridView2.Rows[0].Cells[2].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();


                        }
                        else if (guna2DataGridView2.Rows[1].Selected)
                        {
                            il = double.Parse(guna2DataGridView2.Rows[1].Cells[2].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();
                        }
                        else if (guna2DataGridView2.Rows[2].Selected)
                        {
                            id = double.Parse(guna2DataGridView2.Rows[2].Cells[2].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();
                        }
                        else if (guna2DataGridView2.Rows[3].Selected)
                        {
                            iss = double.Parse(guna2DataGridView2.Rows[3].Cells[2].Value.ToString());

                            guna2DataGridView5.Rows.Clear();
                            AddRowsToCorrectionFactor();
                            guna2DataGridView6.Rows.Clear();
                            AddRowsToCorrection();
                        }
                    }
                }

            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = true;
            guna2DataGridView2.Visible = false;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = false;
            guna2DataGridView2.Visible = true;
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

                    SqlCommand cmd2 = new SqlCommand("SELECT FIRSTNAME,FAMILYNAME,DOB FROM CUSTOMER " +
                        "WHERE FILENO = @fileno", MainClass.con);

                    cmd2.Parameters.AddWithValue("@fileno", value);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        // Assign values from the reader to the respective text boxes
                        dob.Value = Convert.ToDateTime(reader2["DOB"]);
                        firstname.Text = reader2["FirstName"].ToString();
                        familyname.Text = reader2["FamilyName"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No customer with this file no exist!");
                    }
                    if (conn == 1)
                    {
                        MainClass.con.Close();
                        conn = 0;
                    }
                    reader2.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
                //if(coderunner!=0)
                //{
                //    int idtemp=0;
                //    try
                //    {
                //        if (MainClass.con.State != ConnectionState.Open)
                //        {
                //            MainClass.con.Open();
                //            conn = 1;
                //        }

                //        SqlCommand cmd2 = new SqlCommand("SELECT ID FROM Customer " +
                //            "WHERE FILENO = @fileno", MainClass.con);

                //        cmd2.Parameters.AddWithValue("@fileno", value);
                //        SqlDataReader reader2 = cmd2.ExecuteReader();
                //        if (reader2.Read())
                //        {
                //            // Assign values from the reader to the respective text boxes
                //            idtemp = int.Parse(reader2["ID"].ToString());
                //        }
                //        else
                //        {
                //            MessageBox.Show("No customer with this file no exist!");
                //        }
                //        if (conn == 1)
                //        {
                //            MainClass.con.Close();
                //            conn = 0;
                //        }
                //        reader2.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        MainClass.con.Close();
                //        MessageBox.Show(ex.Message);
                //    }

                //    try
                //    {
                //        if (MainClass.con.State != ConnectionState.Open)
                //        {
                //            MainClass.con.Open();
                //            conn = 1;
                //        }

                //        SqlCommand cmd2 = new SqlCommand("SELECT WEIGHT FROM BODYCOMPOSITION " +
                //            "WHERE CustomerID = @fileno", MainClass.con);

                //        cmd2.Parameters.AddWithValue("@fileno", idtemp);
                //        SqlDataReader reader2 = cmd2.ExecuteReader();
                //        if (reader2.Read())
                //        {
                //            // Assign values from the reader to the respective text boxes
                //            weight.Text = reader2["WEIGHT"].ToString();
                //        }
                //        else
                //        {
                //            MessageBox.Show("No customer with this file no exist!");
                //        }
                //        if (conn == 1)
                //        {
                //            MainClass.con.Close();
                //            conn = 0;
                //        }
                //        reader2.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        MainClass.con.Close();
                //        MessageBox.Show(ex.Message);
                //    }

                //    coderunner = 0;
                //}
                //else
                //{
                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    SqlCommand cmd2 = new SqlCommand("SELECT WEIGHT FROM BODYCOMPOSITION " +
                        "WHERE CustomerID = @fileno", MainClass.con);

                    cmd2.Parameters.AddWithValue("@fileno", value.ToString());
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        // Assign values from the reader to the respective text boxes
                        weight.Text = reader2["WEIGHT"].ToString();
                    }
                    else
                    {

                    }
                    if (conn == 1)
                    {
                        MainClass.con.Close();
                        conn = 0;
                    }
                    reader2.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
                //}

            }
            else
            {
                firstname.Text = "";
                familyname.Text = "";
                dob.Value = DateTime.Now;
                weight.Text = "";
                totalinsulin.Text = "";
                baselineinsulin.Text = "";
                insulincharb.Text = "";
                bolusinsulin.Text = "";

            }
        }

        private void totalinsulin_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView5.Rows.Clear();
            AddRowsToCorrectionFactor();
        }

        static double fastingglucose;
        static double beforelunch;
        static double beforedinner;
        static double bedtime;
        static double cofactor;
        int counterfor4 = 11;
        private void guna2DataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (totalinsulin.Text != "")
            {
                if (guna2DataGridView4.Rows[0].Selected)
                {
                    fastingglucose = double.Parse(guna2DataGridView4.Rows[0].Cells[2].Value.ToString());
                    fastingglucose = fastingglucose - 130;
                    guna2DataGridView5.Rows.Clear();
                    AddRowsToCorrectionFactor();
                    guna2DataGridView6.Rows.Clear();
                    AddRowsToCorrection();
                }
                else if (guna2DataGridView4.Rows[1].Selected)
                {
                    beforelunch = double.Parse(guna2DataGridView4.Rows[1].Cells[2].Value.ToString());
                    beforelunch = beforelunch - 180;
                    guna2DataGridView5.Rows.Clear();
                    AddRowsToCorrectionFactor();
                    guna2DataGridView6.Rows.Clear();
                    AddRowsToCorrection();
                }
                else if (guna2DataGridView4.Rows[2].Selected)
                {
                    beforedinner = double.Parse(guna2DataGridView4.Rows[2].Cells[2].Value.ToString());
                    beforedinner = beforedinner - 180;
                    guna2DataGridView5.Rows.Clear();
                    AddRowsToCorrectionFactor();
                    guna2DataGridView6.Rows.Clear();
                    AddRowsToCorrection();
                }
                else if (guna2DataGridView4.Rows[3].Selected)
                {
                    bedtime = double.Parse(guna2DataGridView4.Rows[3].Cells[2].Value.ToString());
                    bedtime = bedtime - 150;
                    guna2DataGridView5.Rows.Clear();
                    AddRowsToCorrectionFactor();
                    guna2DataGridView6.Rows.Clear();
                    AddRowsToCorrection();
                }
            }
            counterfor4--;
        }

        private void AddDiabetesCalculation()
        {

            try
            {
                if (string.IsNullOrEmpty(fileno.Text))
                {

                }
                else
                {
                    if (edit == 0)
                    {

                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Diabetes (FileNo, Weight, BFInsulin, LInsulin, DInsulin, SInsulin, BFCarbs, LCarbs, DCarbs, SCarbs, FastingGlucose, BeforeLunch, BeforeDinner, BedTime) VALUES (@FileNo, @Weight, @BFInsulin, @LInsulin, @DInsulin, @SInsulin, @BFCarbs, @LCarbs, @DCarbs, @SCarbs, @FastingGlucose, @BeforeLunch, @BeforeDinner, @BedTime)", MainClass.con);

                        cmd.Parameters.AddWithValue("@FileNo", fileno.Text);
                        cmd.Parameters.AddWithValue("@Weight", float.TryParse(weight.Text, out float weightVal) ? weightVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BFInsulin", float.TryParse(guna2DataGridView1.Rows[0].Cells[1].Value?.ToString(), out float bfInsulinVal) ? bfInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@LInsulin", float.TryParse(guna2DataGridView1.Rows[1].Cells[1].Value?.ToString(), out float lInsulinVal) ? lInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@DInsulin", float.TryParse(guna2DataGridView1.Rows[2].Cells[1].Value?.ToString(), out float dInsulinVal) ? dInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@SInsulin", float.TryParse(guna2DataGridView1.Rows[3].Cells[1].Value?.ToString(), out float sInsulinVal) ? sInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BFCarbs", float.TryParse(guna2DataGridView2.Rows[0].Cells[1].Value?.ToString(), out float bfCarbsVal) ? bfCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@LCarbs", float.TryParse(guna2DataGridView2.Rows[1].Cells[1].Value?.ToString(), out float lCarbsVal) ? lCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@DCarbs", float.TryParse(guna2DataGridView2.Rows[2].Cells[1].Value?.ToString(), out float dCarbsVal) ? dCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@SCarbs", float.TryParse(guna2DataGridView2.Rows[3].Cells[1].Value?.ToString(), out float sCarbsVal) ? sCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@FastingGlucose", float.TryParse(guna2DataGridView4.Rows[0].Cells[2].Value?.ToString(), out float fastingGlucoseVal) ? fastingGlucoseVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BeforeLunch", float.TryParse(guna2DataGridView4.Rows[1].Cells[2].Value?.ToString(), out float beforeLunchVal) ? beforeLunchVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BeforeDinner", float.TryParse(guna2DataGridView4.Rows[2].Cells[2].Value?.ToString(), out float beforeDinnerVal) ? beforeDinnerVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BedTime", float.TryParse(guna2DataGridView4.Rows[3].Cells[2].Value?.ToString(), out float bedTimeVal) ? bedTimeVal : 0.00f);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data added successfully");

                        MainClass.con.Close();

                    }
                    else
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Diabetes SET FileNo = @FileNo, Weight = @Weight, BFInsulin = @BFInsulin, LInsulin = @LInsulin, DInsulin = @DInsulin, SInsulin = @SInsulin, BFCarbs = @BFCarbs, LCarbs = @LCarbs, DCarbs = @DCarbs, SCarbs = @SCarbs, FastingGlucose = @FastingGlucose, BeforeLunch = @BeforeLunch, BeforeDinner = @BeforeDinner, BedTime = @BedTime WHERE ID = @ID", MainClass.con);

                        cmd.Parameters.AddWithValue("@ID", idToEdit); // Replace yourSelectedId with the actual ID of the row you want to update.
                        cmd.Parameters.AddWithValue("@FileNo", fileno.Text);
                        cmd.Parameters.AddWithValue("@Weight", float.TryParse(weight.Text, out float weightVal) ? weightVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BFInsulin", float.TryParse(guna2DataGridView1.Rows[0].Cells[1].Value?.ToString(), out float bfInsulinVal) ? bfInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@LInsulin", float.TryParse(guna2DataGridView1.Rows[1].Cells[1].Value?.ToString(), out float lInsulinVal) ? lInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@DInsulin", float.TryParse(guna2DataGridView1.Rows[2].Cells[1].Value?.ToString(), out float dInsulinVal) ? dInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@SInsulin", float.TryParse(guna2DataGridView1.Rows[3].Cells[1].Value?.ToString(), out float sInsulinVal) ? sInsulinVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BFCarbs", float.TryParse(guna2DataGridView2.Rows[0].Cells[1].Value?.ToString(), out float bfCarbsVal) ? bfCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@LCarbs", float.TryParse(guna2DataGridView2.Rows[1].Cells[1].Value?.ToString(), out float lCarbsVal) ? lCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@DCarbs", float.TryParse(guna2DataGridView2.Rows[2].Cells[1].Value?.ToString(), out float dCarbsVal) ? dCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@SCarbs", float.TryParse(guna2DataGridView2.Rows[3].Cells[1].Value?.ToString(), out float sCarbsVal) ? sCarbsVal : 0.00f);
                        cmd.Parameters.AddWithValue("@FastingGlucose", float.TryParse(guna2DataGridView4.Rows[0].Cells[2].Value?.ToString(), out float fastingGlucoseVal) ? fastingGlucoseVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BeforeLunch", float.TryParse(guna2DataGridView4.Rows[1].Cells[2].Value?.ToString(), out float beforeLunchVal) ? beforeLunchVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BeforeDinner", float.TryParse(guna2DataGridView4.Rows[2].Cells[2].Value?.ToString(), out float beforeDinnerVal) ? beforeDinnerVal : 0.00f);
                        cmd.Parameters.AddWithValue("@BedTime", float.TryParse(guna2DataGridView4.Rows[3].Cells[2].Value?.ToString(), out float bedTimeVal) ? bedTimeVal : 0.00f);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data updated successfully");

                        MainClass.con.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainClass.con.Close();
            }
        }
        static int idToEdit;
        private void EditDiabetesCalculation()
        {
            try
            {
                if (guna2DataGridView8.SelectedRows.Count > 0)
                {
                    string filenoTOedit = "";
                    string savedweight = "";
                    idToEdit = Convert.ToInt32(guna2DataGridView8.SelectedRows[0].Cells["iddgv"].Value);

                    MainClass.con.Open();

                    // Fetch the row based on ID
                    SqlCommand selectCmd = new SqlCommand("SELECT * FROM Diabetes WHERE ID = @ID", MainClass.con);
                    selectCmd.Parameters.AddWithValue("@ID", idToEdit);

                    SqlDataReader reader = selectCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        filenoTOedit = reader["FileNo"].ToString();
                        savedweight = reader["Weight"].ToString();
                        weight.Text = reader["Weight"].ToString();
                        guna2DataGridView1.Rows[0].Cells[1].Value = reader["BFInsulin"];
                        guna2DataGridView1.Rows[1].Cells[1].Value = reader["LInsulin"];
                        guna2DataGridView1.Rows[2].Cells[1].Value = reader["DInsulin"];
                        guna2DataGridView1.Rows[3].Cells[1].Value = reader["SInsulin"];
                        guna2DataGridView2.Rows[0].Cells[1].Value = reader["BFCarbs"];
                        guna2DataGridView2.Rows[1].Cells[1].Value = reader["LCarbs"];
                        guna2DataGridView2.Rows[2].Cells[1].Value = reader["DCarbs"];
                        guna2DataGridView2.Rows[3].Cells[1].Value = reader["SCarbs"];
                        guna2DataGridView4.Rows[0].Cells[2].Value = reader["FastingGlucose"];
                        guna2DataGridView4.Rows[1].Cells[2].Value = reader["BeforeLunch"];
                        guna2DataGridView4.Rows[2].Cells[2].Value = reader["BeforeDinner"];
                        guna2DataGridView4.Rows[3].Cells[2].Value = reader["BedTime"];

                    }
                    else
                    {
                        MessageBox.Show("No data found for the specified ID");
                    }

                    reader.Close();
                    MainClass.con.Close();
                    fileno.Text = filenoTOedit;
                    weight.Text = savedweight;
                    FillData();

                }
                else
                {
                    MessageBox.Show("Please select a row in the DataGridView.");
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainClass.con.Close();
            }
        }

        private void ShowDiabetes(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn file, DataGridViewColumn weight, DataGridViewColumn firstname, DataGridViewColumn lastname)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT D.ID, D.FileNo, D.Weight, R.FirstName, R.familyName FROM Diabetes D INNER JOIN Customer R ON D.FileNo = R.FileNo", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                id.DataPropertyName = dt.Columns["ID"].ToString();
                file.DataPropertyName = dt.Columns["FileNo"].ToString();
                weight.DataPropertyName = dt.Columns["Weight"].ToString();
                firstname.DataPropertyName = dt.Columns["FirstName"].ToString();
                lastname.DataPropertyName = dt.Columns["familyName"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainClass.con.Close();
            }
        }

        private void FillData()
        {
            if (guna2DataGridView4.Rows[0].Cells[2].Value != "")
            {
                fastingglucose = double.Parse(guna2DataGridView4.Rows[0].Cells[2].Value.ToString());
                fastingglucose = fastingglucose - 130;
                guna2DataGridView5.Rows.Clear();
                AddRowsToCorrectionFactor();
                guna2DataGridView6.Rows.Clear();
                AddRowsToCorrection();
            }

            if (guna2DataGridView4.Rows[1].Cells[2].Value != "")
            {
                beforelunch = double.Parse(guna2DataGridView4.Rows[1].Cells[2].Value.ToString());
                beforelunch = beforelunch - 180;
                guna2DataGridView5.Rows.Clear();
                AddRowsToCorrectionFactor();
                guna2DataGridView6.Rows.Clear();
                AddRowsToCorrection();
            }

            if (guna2DataGridView4.Rows[2].Cells[2].Value != "")
            {
                beforedinner = double.Parse(guna2DataGridView4.Rows[2].Cells[2].Value.ToString());
                beforedinner = beforedinner - 180;
                guna2DataGridView5.Rows.Clear();
                AddRowsToCorrectionFactor();
                guna2DataGridView6.Rows.Clear();
                AddRowsToCorrection();
            }

            if (guna2DataGridView4.Rows[3].Cells[2].Value != "")
            {
                bedtime = double.Parse(guna2DataGridView4.Rows[3].Cells[2].Value.ToString());
                bedtime = bedtime - 150;
                guna2DataGridView5.Rows.Clear();
                AddRowsToCorrectionFactor();
                guna2DataGridView6.Rows.Clear();
                AddRowsToCorrection();
            }
        }

        private void DeleteDiabetesCalculation()
        {
            try
            {
                if (guna2DataGridView8.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this diabetes calculation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int idToDelete = Convert.ToInt32(guna2DataGridView8.SelectedRows[0].Cells[0].Value);

                        MainClass.con.Open();

                        // Delete row based on ID
                        SqlCommand deleteCmd = new SqlCommand("DELETE FROM Diabetes WHERE ID = @ID", MainClass.con);
                        deleteCmd.Parameters.AddWithValue("@ID", idToDelete);

                        // Execute the DELETE command
                        deleteCmd.ExecuteNonQuery();

                        MainClass.con.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Please select a diabetes calculation to delete.");
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainClass.con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddDiabetes_Click(object sender, EventArgs e)
        {
            ClearForm();

            edit = 0;
            tabControl1.SelectedIndex = 1;

        }

        private void EditDiabetes_Click(object sender, EventArgs e)
        {
            ClearForm();
            EditDiabetesCalculation();

            edit = 1;
            tabControl1.SelectedIndex = 1;

        }

        private void Back_Click(object sender, EventArgs e)
        {
            edit = 0;
            tabControl1.SelectedIndex = 0;
            ClearForm();
        }

        private void SaveDiabetes_Click(object sender, EventArgs e)
        {
            AddDiabetesCalculation();
            edit = 0;
            ShowDiabetes(guna2DataGridView8, iddgv, filenodgv, firstnamedgv, familynamedgv, weightdgv);
            tabControl1.SelectedIndex = 0;
        }

        private void DeleteDiabetes_Click(object sender, EventArgs e)
        {
            DeleteDiabetesCalculation();
            ShowDiabetes(guna2DataGridView8, iddgv, filenodgv, firstnamedgv, familynamedgv, weightdgv);
        }

        private void SearchDiabetes(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn file, DataGridViewColumn weight, DataGridViewColumn firstname, DataGridViewColumn lastname)
        {
            SqlCommand cmd;
            try
            {


                string fileNo = searchbox.Text;
                if (fileNo == "")
                {
                    ShowDiabetes(guna2DataGridView8, iddgv, filenodgv, firstnamedgv, familynamedgv, weightdgv);
                }
                else
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("SELECT D.ID, D.FileNo, D.Weight, R.FirstName, R.familyName FROM Diabetes D INNER JOIN Customer R ON D.FileNo = R.FileNo WHERE D.FileNo = @FileNo", MainClass.con);
                    cmd.Parameters.AddWithValue("@FileNo", fileNo);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    id.DataPropertyName = dt.Columns["ID"].ToString();
                    file.DataPropertyName = dt.Columns["FileNo"].ToString();
                    weight.DataPropertyName = dt.Columns["Weight"].ToString();
                    firstname.DataPropertyName = dt.Columns["FirstName"].ToString();
                    lastname.DataPropertyName = dt.Columns["familyName"].ToString();

                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }


            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainClass.con.Close();
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchDiabetes(guna2DataGridView8, iddgv, filenodgv, firstnamedgv, familynamedgv, weightdgv);
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SearchDiabetes(guna2DataGridView8, iddgv, filenodgv, firstnamedgv, familynamedgv, weightdgv);

        }
    }
}
