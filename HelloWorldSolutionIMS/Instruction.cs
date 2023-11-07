using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using Win32Interop.Structs;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Asn1.Crmf;
using System.Web.UI;
using Win32Interop.Enums;

namespace HelloWorldSolutionIMS
{
    public partial class Instruction : Form
    {
        public Instruction()
        {
            InitializeComponent();
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
        private void SearchInstructions(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn instruction, DataGridViewColumn nutritionist, DataGridViewColumn date)
        {
            string instructionName = instructionname.Text;
            string nutritionistName = nutritionistname.Text;
            if (instructionName != "" && nutritionistName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, InstructionName, NutritionistName, InstructionDate FROM Instruction WHERE (@InstructionName = '' OR InstructionName LIKE @InstructionName) AND (@NutritionistName = '' OR NutritionistName LIKE @NutritionistName)", MainClass.con);

                    cmd.Parameters.AddWithValue("@InstructionName", "%" + instructionName + "%");
                    cmd.Parameters.AddWithValue("@NutritionistName", "%" + nutritionistName + "%");

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
            else if (instructionName == "" && nutritionistName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, InstructionName, NutritionistName, InstructionDate FROM Instruction WHERE NutritionistName LIKE @NutritionistName", MainClass.con);

                    cmd.Parameters.AddWithValue("@NutritionistName", "%" + nutritionistName + "%");

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
            else if (instructionName != "" && nutritionistName == "")
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
                MessageBox.Show("Fill Instruction Name or Nutritionist Name");
            }
        }
        private void Instruction_Load(object sender, EventArgs e)
        {
            ShowInstructions(guna2DataGridView1, nodgv, instructionnamedgv, nutritionistnamedgv, datedgv);
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
                        nutritionistname.Text = "";
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
                        nutritionistname.Text = "";
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
                    }
                }
            }

        }
    }
}
