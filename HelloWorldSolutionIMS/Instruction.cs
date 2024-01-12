using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class Instruction : Form
    {
        public Instruction()
        {

            InitializeComponent();

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
        private void ShowInstructions(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn instruction, DataGridViewColumn nutritionist, DataGridViewColumn date)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("select ID,InstructionName,NutritionistName,InstructionDate from Instruction order by InstructionDate", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                no.DataPropertyName = dt.Columns["ID"].ToString();
                instruction.DataPropertyName = dt.Columns["InstructionName"].ToString();
                nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                date.DataPropertyName = dt.Columns["InstructionDate"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        static int conn = 1;
        public class NutritionistInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        private void UpdateNutritionist()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, Name FROM NUTRITIONIST", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                nutritionistname.DataSource = null;
                nutritionistname.Items.Clear();

                List<NutritionistInfo> Nutrition = new List<NutritionistInfo>();


                Nutrition.Add(new NutritionistInfo { ID = 0, Name = "Null" });


                foreach (DataRow row in dt.Rows)
                {
                    int Id = row.Field<int>("ID");
                    string Name = row.Field<string>("Name");


                    NutritionistInfo Temp = new NutritionistInfo { ID = Id, Name = Name };
                    Nutrition.Add(Temp);

                }

                nutritionistname.DataSource = Nutrition;
                nutritionistname.DisplayMember = "Name"; // Display Member is Name
                nutritionistname.ValueMember = "ID"; // Value Member is ID


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
        private void SearchInstructions(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn instruction, DataGridViewColumn nutritionist, DataGridViewColumn date)
        {
            string instructionName = instructionname.Text;

            if (instructionName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, InstructionName, NutritionistName, InstructionDate FROM Instruction WHERE InstructionName LIKE @InstructionName", MainClass.con);

                    cmd.Parameters.AddWithValue("@InstructionName", "%" + instructionName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Modify the column names to match your data grid view
                    no.DataPropertyName = dt.Columns["ID"].ToString();
                    instruction.DataPropertyName = dt.Columns["InstructionName"].ToString();
                    nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                    date.DataPropertyName = dt.Columns["InstructionDate"].ToString();

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
                ShowInstructions(guna2DataGridView1, nodgv, instructionnamedgv, nutritionistnamedgv, datedgv);
                MessageBox.Show("Fill Instruction Name");
            }
        }
        private void Instruction_Load(object sender, EventArgs e)
        {
            UpdateNutritionist();
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
            ShowInstructions(guna2DataGridView1, nodgv, instructionnamedgv, nutritionistnamedgv, datedgv);
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView1.GridColor = Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;

            LanguageInfo();
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

            }
        }

        static string instructionIDToEdit;
        static int edit = 0;
        private void New_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (instructionname.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Instruction (InstructionName, NutritionistName, InstructionDate, InstructionContent) VALUES (@InstructionName, @NutritionistName, @InstructionDate, @InstructionContent)", MainClass.con);

                        cmd.Parameters.AddWithValue("@InstructionName", instructionname.Text); // Replace with the actual input control for InstructionName.
                        cmd.Parameters.AddWithValue("@NutritionistName", nutritionistname.Text); // Replace with the actual input control for NutritionistName.
                        cmd.Parameters.AddWithValue("@InstructionDate", Convert.ToDateTime(date.Value)); // Replace with the actual input control for InstructionDate.
                        cmd.Parameters.AddWithValue("@InstructionContent", instructionbox.Text); // Replace with the actual input control for InstructionContent.

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Instruction added successfully");

                        // Clear the input controls or set them to default values.
                        instructionname.Text = "";
                        nutritionistname.SelectedItem = null;
                        date.Value = DateTime.Now; // Reset to the current date or your default value.
                        instructionbox.Text = "";


                        MainClass.con.Close();

                        ShowInstructions(guna2DataGridView1, nodgv, instructionnamedgv, nutritionistnamedgv, datedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Instruction name cannot be empty.");
                }
            }
            else
            {
                if (instructionname.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Instruction SET InstructionName = @InstructionName, NutritionistName = @NutritionistName, InstructionDate = @InstructionDate, InstructionContent = @InstructionContent WHERE ID = @ID", MainClass.con);

                        cmd.Parameters.AddWithValue("@ID", instructionIDToEdit); // Replace with the actual input control for ID.
                        cmd.Parameters.AddWithValue("@InstructionName", instructionname.Text); // Replace with the actual input control for InstructionName.
                        cmd.Parameters.AddWithValue("@NutritionistName", nutritionistname.Text); // Replace with the actual input control for NutritionistName.
                        cmd.Parameters.AddWithValue("@InstructionDate", Convert.ToDateTime(date.Value)); // Replace with the actual input control for InstructionDate.
                        cmd.Parameters.AddWithValue("@InstructionContent", instructionbox.Text); // Replace with the actual input control for InstructionContent.

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Instruction updated successfully");

                        // Clear the input controls or set them to default values.
                        instructionname.Text = "";
                        nutritionistname.SelectedItem = null;
                        date.Value = DateTime.Now; // Reset to the current date or your default value.
                        instructionbox.Text = "";
                        MainClass.con.Close();

                        ShowInstructions(guna2DataGridView1, nodgv, instructionnamedgv, nutritionistnamedgv, datedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Instruction name cannot be empty.");
                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            try
            {
                instructionIDToEdit = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Instruction WHERE ID = @InstructionID", MainClass.con);
                cmd.Parameters.AddWithValue("@InstructionID", instructionIDToEdit);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input controls
                        instructionname.Text = reader["InstructionName"].ToString();
                        nutritionistname.Text = reader["NutritionistName"].ToString();
                        date.Value = Convert.ToDateTime(reader["InstructionDate"]);
                        instructionbox.Text = reader["InstructionContent"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Instruction not found with ID: " + instructionIDToEdit);
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }


        }

        private void Search_Click(object sender, EventArgs e)
        {
            SearchInstructions(guna2DataGridView1, nodgv, instructionnamedgv, nutritionistnamedgv, datedgv);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 0;
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {
                        // Get the InstructionID to display in the confirmation message
                        string instructionIDToDelete = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString(); // Assuming the InstructionID is in the second cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Instruction with Name: " + instructionIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Instruction WHERE ID = @InstructionID", MainClass.con);
                                cmd.Parameters.AddWithValue("@InstructionID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString()); // Assuming the InstructionID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Instruction removed successfully");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
                                ShowInstructions(guna2DataGridView1, nodgv, instructionnamedgv, nutritionistnamedgv, datedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                        }
                        instructionname.Text = "";
                        nutritionistname.SelectedItem = null;
                        date.Value = DateTime.Now; // Reset to the current date or your default value.
                        instructionbox.Text = "";
                    }
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editToolStripMenuItem.PerformClick();
        }
    }
}
