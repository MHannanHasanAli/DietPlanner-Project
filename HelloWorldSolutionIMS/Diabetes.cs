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
        private void AddFiveRowsToTablecarbs()
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
        private void AddFiveRowsToTable()
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
        private void AddRowsToBloodSuger()
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
            guna2DataGridView4.ClearSelection();
        }
        private void AddRowsToCorrectionFactor()
        {
            for (int i = 0; i < 5; i++)
            {
                // Add a new row to the DataGridView
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
                // Add a new row to the DataGridView
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
        private void Diabetes_Load(object sender, EventArgs e)
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

            AddFiveRowsToTable();
            AddFiveRowsToTablecarbs();
            AddRowsToBloodSuger();

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
            guna2DataGridView1.GridColor = Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView2.GridColor = Color.Black;
            guna2DataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView2.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView2.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView4.GridColor = Color.Black;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView4.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView4.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView5.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView5.GridColor = Color.Black;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView5.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView5.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView7.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView7.GridColor = Color.Black;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView7.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView7.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView7.Visible = false;

            guna2DataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView6.GridColor = Color.Black;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView6.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView6.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView6.Rows.Clear();
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
    }
}
