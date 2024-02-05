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

        private void ShowEvaluations(DataGridView dgv, DataGridViewColumn fileno, DataGridViewColumn name, DataGridViewColumn fname)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT DISTINCT FILENO, FIRSTNAME, LASTNAME FROM Evaluation ORDER BY FILENO", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                fileno.DataPropertyName = dt.Columns["FILENO"].ToString();
                name.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                fname.DataPropertyName = dt.Columns["LASTNAME"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void Evaluation_Load(object sender, EventArgs e)
        {
            MainClass.HideAllTabsOnTabControl(tabControl1);
            TableStyle();
            ClearForm();
            ShowEvaluations(guna2DataGridView17, filenodgv, firstnamedgv, familynamedgv);
            guna2DataGridView17.ClearSelection();

            guna2DataGridView17.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView17.GridColor = Color.Black;
            guna2DataGridView17.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView17.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView17.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView17.RowTemplate.DefaultCellStyle.ForeColor;

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

                    foreach (Control control in panel3.Controls)
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

                    foreach (Control control in panel3.Controls)
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

                    foreach (System.Windows.Forms.Control control in panel2.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }

                    foreach (System.Windows.Forms.Control control in panel3.Controls)
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
            LanguageInfo();
            if (languagestatus == 1)
            {
                PrepareMCQsArabic();

                foreach (Control control in panel2.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel2.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel3.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel3.Width - currentLoc.X - control.Width, currentLoc.Y);

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
            else
            {
                PrepareMCQsEnglish();
            }
            ClearForm();

            tabControl1.SelectedIndex = 1;
        }

        private void ClearForm()
        {
            fileno.Text = "";
            firstname.Text = "";
            familyname.Text = "";
            nutritionist.Text = "";
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

            others.Visible = false;
        }
        private void ClearFormWihtoutFIleNo()
        {

            firstname.Text = "";
            familyname.Text = "";
            nutritionist.Text = "";
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

            others.Visible = false;
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
        private void PrepareMCQsArabic()
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

            guna2DataGridView8.Rows[0].Cells[0].Value = "على دراية كاملة بالمعلومات والاساليب";
            guna2DataGridView8.Rows[0].Cells[1].Value = "على دراية متوسطة بالمعلومات والاساليب";
            guna2DataGridView8.Rows[0].Cells[2].Value = "على دراية بالمعلومات الاساسية فقط";
            guna2DataGridView8.Rows[0].Cells[3].Value = "لا تمتلك معلومات ولا اساليب كافية لعمل برنامج غذائي";

            guna2DataGridView7.Rows[0].Cells[0].Value = "سريع ولبق في التعامل";
            guna2DataGridView7.Rows[0].Cells[1].Value = "سرعة متوسطة وغير لبق في التعامل";
            guna2DataGridView7.Rows[0].Cells[2].Value = "سرعة متوسطة ولبق في التعامل";
            guna2DataGridView7.Rows[0].Cells[3].Value = "بطيء جدا وغير لبق في التعامل";

            guna2DataGridView6.Rows[0].Cells[0].Value = "نعم ";
            guna2DataGridView6.Rows[0].Cells[1].Value = "لا";

            guna2DataGridView5.Rows[0].Cells[0].Value = "نعم ";
            guna2DataGridView5.Rows[0].Cells[1].Value = "لا";

            guna2DataGridView9.Rows[0].Cells[0].Value = "نعم ";
            guna2DataGridView9.Rows[0].Cells[1].Value = "لا";

            guna2DataGridView10.Rows[0].Cells[0].Value = "نعم ";
            guna2DataGridView10.Rows[0].Cells[1].Value = "لا";

            guna2DataGridView11.Rows[0].Cells[0].Value = "نعم ";
            guna2DataGridView11.Rows[0].Cells[1].Value = "لا";

            guna2DataGridView12.Rows[0].Cells[0].Value = "ممتاز ";
            guna2DataGridView12.Rows[0].Cells[1].Value = "جيد جدا ";
            guna2DataGridView12.Rows[0].Cells[2].Value = "Not Good";

            guna2DataGridView13.Rows[0].Cells[0].Value = "من صديق";
            guna2DataGridView13.Rows[0].Cells[1].Value = "من موقع الجوجل";
            guna2DataGridView13.Rows[0].Cells[2].Value = "برنامج التيك توك ";
            guna2DataGridView13.Rows[0].Cells[3].Value = "غيرها ";
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

            ShowEvaluations(guna2DataGridView17, filenodgv, firstnamedgv, familynamedgv);
            guna2DataGridView17.ClearSelection();
            tabControl1.SelectedIndex = 1;
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
                cmd.Parameters.AddWithValue("@Lastname", familyname.Text); // Replace with the actual input control for Lastname.
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
            ClearFormWihtoutFIleNo();
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

                    SqlCommand cmd2 = new SqlCommand("SELECT  FIRSTNAME, FAMILYNAME, NutritionistName FROM CUSTOMER " +
                        "WHERE FILENO = @fileno", MainClass.con);

                    cmd2.Parameters.AddWithValue("@fileno", value);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        // Assign values from the reader to the respective text boxes
                        firstname.Text = reader2["FIRSTNAME"].ToString();
                        familyname.Text = reader2["FAMILYNAME"].ToString();
                        nutritionist.Text = reader2["NutritionistName"].ToString();

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

                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Evaluation WHERE FILENO = @FILENO", MainClass.con);

                    cmd.Parameters.AddWithValue("@FILENO", Convert.ToInt32(fileno.Text)); // Replace with the actual input control for FILENO.

                    // Assuming you have a SqlDataReader to read the data, replace "reader" with your SqlDataReader variable
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            firstname.Text = reader["Firstname"].ToString();
                            familyname.Text = reader["Lastname"].ToString();
                            string tablename = reader["Tablename"].ToString();
                            string col = reader["Col"].ToString();
                            string other = reader["Others"].ToString();
                            question10.Text = reader["Question10"].ToString();
                            if (other == "" || other == "Mention here")
                            {
                                others.Visible = false;
                                others.Text = "Mention here";
                            }
                            else
                            {
                                others.Visible = true;
                                others.Text = other;
                            }

                            if (col != "")
                            {


                                if (tablename == "guna2DataGridView5")
                                {
                                    guna2DataGridView5.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView6")
                                {
                                    guna2DataGridView6.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView7")
                                {
                                    guna2DataGridView7.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView8")
                                {
                                    guna2DataGridView8.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView9")
                                {
                                    guna2DataGridView9.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView10")
                                {
                                    guna2DataGridView10.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView11")
                                {
                                    guna2DataGridView11.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView12")
                                {
                                    guna2DataGridView12.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                                else if (tablename == "guna2DataGridView13")
                                {
                                    guna2DataGridView13.Rows[0].Cells[int.Parse(col)].Selected = true;
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving data: {ex.Message}");
                }
                finally
                {
                    MainClass.con.Close();
                }

            }
            else
            {
                firstname.Text = "";
                familyname.Text = "";
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView17.SelectedRows.Count > 0)
            {
                string selectedfileno = guna2DataGridView17.SelectedRows[0].Cells[0].Value.ToString();
                fileno.Text = selectedfileno;
            }
            tabControl1.SelectedIndex = 0;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView17 != null)
            {
                if (guna2DataGridView17.Rows.Count > 0)
                {
                    if (guna2DataGridView17.SelectedRows.Count == 1)
                    {
                        string filenoToDelete = guna2DataGridView17.SelectedRows[0].Cells[0].Value.ToString();

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete evaluation of Customer with FILE NO: " + filenoToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from Evaluation where FileNo = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", filenoToDelete);
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                                ShowEvaluations(guna2DataGridView17, filenodgv, firstnamedgv, familynamedgv);
                                guna2DataGridView17.ClearSelection();
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

        private void Add_Click(object sender, EventArgs e)
        {
            ClearForm();
            tabControl1.SelectedIndex = 0;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView17_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit.PerformClick();
        }
    }
}
