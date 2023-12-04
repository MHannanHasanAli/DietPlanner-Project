using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class Evaluation : Form
    {
        public Evaluation()
        {
            InitializeComponent();
        }

        static int conn = 0;
        private void Evaluation_Load(object sender, EventArgs e)
        {
            MainClass.HideAllTabsOnTabControl(tabControl1);
            TableStyle();
            PrepareMCQsEnglish();
            ClearForm();
        }

        private void ClearForm()
        {
            fileno.Text = "";
            firstname.Text = "";
            label55.Text = "";

            guna2DataGridView5.ClearSelection();
            guna2DataGridView6.ClearSelection();
            guna2DataGridView7.ClearSelection();
            guna2DataGridView8.ClearSelection();
            guna2DataGridView9.ClearSelection();
            guna2DataGridView10.ClearSelection();
            guna2DataGridView11.ClearSelection();
            guna2DataGridView12.ClearSelection();
            guna2DataGridView13.ClearSelection();

            question10.Text = "";
        }

        private void TableStyle()
        {
            guna2DataGridView5.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView5.GridColor = Color.Black;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView5.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView5.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView6.GridColor = Color.Black;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView6.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView6.RowTemplate.DefaultCellStyle.ForeColor;

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

            guna2DataGridView11.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView11.GridColor = Color.Black;
            guna2DataGridView11.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView11.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView11.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView11.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView12.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView12.GridColor = Color.Black;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView12.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView12.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView13.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView13.GridColor = Color.Black;
            guna2DataGridView13.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView13.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView13.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView13.RowTemplate.DefaultCellStyle.ForeColor;

        }
        private void PrepareMCQsEnglish()
        {

            guna2DataGridView5.Rows.Add();
            guna2DataGridView6.Rows.Add();
            guna2DataGridView7.Rows.Add();
            guna2DataGridView8.Rows.Add();
            guna2DataGridView9.Rows.Add();
            guna2DataGridView10.Rows.Add();
            guna2DataGridView11.Rows.Add();
            guna2DataGridView12.Rows.Add();
            guna2DataGridView13.Rows.Add();

            guna2DataGridView8.Rows[0].Cells[0].Value = "Very Good";
            guna2DataGridView8.Rows[0].Cells[1].Value = "Good";
            guna2DataGridView8.Rows[0].Cells[2].Value = "Not that much";
            guna2DataGridView8.Rows[0].Cells[3].Value = "Not at all";

            guna2DataGridView7.Rows[0].Cells[0].Value = "Fast And Gentle";
            guna2DataGridView7.Rows[0].Cells[1].Value = "Average speed but not gentle";
            guna2DataGridView7.Rows[0].Cells[2].Value = "Average speed and gentle";
            guna2DataGridView7.Rows[0].Cells[3].Value = "Very slow but not gentle";

            guna2DataGridView6.Rows[0].Cells[0].Value = "Yes";
            guna2DataGridView6.Rows[0].Cells[1].Value = "No";

            guna2DataGridView5.Rows[0].Cells[0].Value = "Yes";
            guna2DataGridView5.Rows[0].Cells[1].Value = "No";

            guna2DataGridView9.Rows[0].Cells[0].Value = "Yes";
            guna2DataGridView9.Rows[0].Cells[1].Value = "No";

            guna2DataGridView10.Rows[0].Cells[0].Value = "Yes";
            guna2DataGridView10.Rows[0].Cells[1].Value = "No";

            guna2DataGridView11.Rows[0].Cells[0].Value = "Yes";
            guna2DataGridView11.Rows[0].Cells[1].Value = "No";

            guna2DataGridView12.Rows[0].Cells[0].Value = "Very Good";
            guna2DataGridView12.Rows[0].Cells[1].Value = "Good";
            guna2DataGridView12.Rows[0].Cells[2].Value = "Not Good";

            guna2DataGridView13.Rows[0].Cells[0].Value = "From a friend";
            guna2DataGridView13.Rows[0].Cells[1].Value = "From Google Website";
            guna2DataGridView13.Rows[0].Cells[2].Value = "Tik Tok Program";
            guna2DataGridView13.Rows[0].Cells[3].Value = "Others";
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (fileno.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Evaluation WHERE FILENO = @FILENO", MainClass.con);

                    cmd.Parameters.AddWithValue("@FILENO", Convert.ToInt32(fileno.Text)); // Replace with the actual input control for ID.

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting data: {ex.Message}");
                }
                finally
                {
                    MainClass.con.Close();
                }

                SaveAnswers(guna2DataGridView5);
                SaveAnswers(guna2DataGridView6);
                SaveAnswers(guna2DataGridView7);
                SaveAnswers(guna2DataGridView8);
                SaveAnswers(guna2DataGridView9);
                SaveAnswers(guna2DataGridView10);
                SaveAnswers(guna2DataGridView11);
                SaveAnswers(guna2DataGridView12);
                SaveAnswers(guna2DataGridView13);

                ClearForm();
                MessageBox.Show("Evaluation added successfully!");
            }
        }

        private void SaveAnswers(Guna2DataGridView table)
        {
            try
            {
                MainClass.con.Open();
                int selectedColumnIndex = -1; // Default value if none of the cells is selected

                if (table.SelectedCells.Count > 0)
                {
                    selectedColumnIndex = table.SelectedCells[0].ColumnIndex;
                }
                else
                {
                    MessageBox.Show("Please answer all the questions.");
                    return; // Exit the method if no cell is selected
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Evaluation (Fileno, Firstname, Lastname,Tablename, Col, Others, Question10) " +
                    "VALUES (@Fileno, @Firstname, @Lastname, @Tablename, @Col, @Others, @Question10)", MainClass.con);

                cmd.Parameters.AddWithValue("@Fileno", Convert.ToInt32(fileno.Text)); // Replace with the actual input control for Fileno.
                cmd.Parameters.AddWithValue("@Firstname", firstname.Text); // Replace with the actual input control for Firstname.
                cmd.Parameters.AddWithValue("@Lastname", label55.Text); // Replace with the actual input control for Lastname.
                cmd.Parameters.AddWithValue("@Tablename", table.Name);
                cmd.Parameters.AddWithValue("@Col", table.SelectedCells[0].ColumnIndex); // Replace with the actual input control for Col.
                cmd.Parameters.AddWithValue("@Others", others.Text); // Replace with the actual input control for Others.
                cmd.Parameters.AddWithValue("@Question10", question10.Text); // Replace with the actual input control for Question10.

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding data: {ex.Message}");
            }
            finally
            {
                MainClass.con.Close();
            }
        }
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

                    SqlCommand cmd2 = new SqlCommand("SELECT  FIRSTNAME, FAMILYNAME FROM CUSTOMER " +
                        "WHERE FILENO = @fileno", MainClass.con);

                    cmd2.Parameters.AddWithValue("@fileno", value);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        // Assign values from the reader to the respective text boxes
                        firstname.Text = reader2["FIRSTNAME"].ToString();
                        label55.Text = reader2["FAMILYNAME"].ToString();

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
                label55.Text = "";
            }



        }

        private void fileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }

        private void guna2DataGridView13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView13.SelectedCells[0].ColumnIndex == 3)
            {
                others.Text = "Mention here";
                others.Visible = true;
            }
            else
            {
                others.Visible = false;
                others.Text = "";
            }
        }


        private void others_MouseClick(object sender, MouseEventArgs e)
        {
            if (others.Text == "Mention here")
            {
                others.Text = "";
            }
        }
    }
}
