using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HelloWorldSolutionIMS
{
    public partial class Diabetes : Form
    {
        public Diabetes()
        {
            InitializeComponent();
            weight.KeyPress += weight_KeyPress;
            weight.TextChanged += weight_TextChanged;

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
            if(guna2DataGridView1.Rows[4].Cells[1].Value != "")
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
                if(rowIndex == 0) {
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
        private void weight_TextChanged(object sender, EventArgs e)
        {
            if(weight.Text != "")
            {
                float w = float.Parse(weight.Text);

                var totalinsulinvar = w * 0.55;
                double rounded = RoundNumber(totalinsulinvar, 0);
                totalinsulinvar = RoundNumber(totalinsulinvar, 2);
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
            
            table_total = 0;
            AddFiveRowsToTable();
            AddFiveRowsToTablecarbs();
            guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;
            guna2DataGridView2.CellValueChanged += guna2DataGridView2_CellValueChanged;

            guna2DataGridView1.Visible = false;
            guna2DataGridView2.Visible = false;

        }
        
        static int counter = 0;
        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 1 && e.RowIndex != 4 && e.RowIndex >= 0)// Change this to the index of the column to monitor
            {
                
                    string changedValue = guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    table_total += double.Parse(changedValue);
                    if (table_total <= total*2)
                    {
                        double cellvalue = double.Parse(changedValue) * insulincharbcalc;

                        guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = cellvalue;
                        string val = guna2DataGridView1.Rows[4].Cells[e.ColumnIndex+1].Value?.ToString();
                        double new_value = 0;
                       
                        if (val == null)
                        {                       
                            guna2DataGridView1.Rows[4].Cells[e.ColumnIndex + 1].Value = cellvalue;
                        }
                        else
                        {

                            if(rowflag == 0)
                            {
                                
                                rowflag = 1;
                            }
                            else
                            {
                                new_value = double.Parse(val) + cellvalue / 2;
                                guna2DataGridView1.Rows[4].Cells[e.ColumnIndex + 1].Value = new_value;
                            }
                               
                        }
                    
                    }
                    else
                    {
                        MessageBox.Show("Total number of insulin exceeded!");
                    }

            }
            
        }
        
        static int full = 0;
        static int shots = 0;
        private void guna2DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != 4 && e.RowIndex >= 0)// Change this to the index of the column to monitor
            {

                    string changedValue = guna2DataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    table_total2 += double.Parse(changedValue);
                
                    double cellvalue = double.Parse(changedValue) / insulincharbcalc;
                    double round = RoundNumber(cellvalue,0);

                    guna2DataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = int.Parse(round.ToString());
                    shots = shots + int.Parse(round.ToString());
                    string val = guna2DataGridView2.Rows[4].Cells[e.ColumnIndex + 1].Value?.ToString();

                    guna2DataGridView2.Rows[4].Cells[2].Value = shots/2;
                    guna2DataGridView2.Rows[4].Cells[1].Value = table_total2 / 2;

                    if (val == null)
                    {
                        guna2DataGridView2.Rows[4].Cells[e.ColumnIndex + 1].Value = cellvalue;
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
    }
}
