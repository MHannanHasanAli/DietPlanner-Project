﻿using Guna.UI2.WinForms;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class SettingScreen : Form
    {
        int edit = 0;
        ProductEntry frm = new ProductEntry();
        public SettingScreen()
        {
            InitializeComponent();
        }
        public class NutritionistInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        static int conn = 0;
        private void SaveFileAsExcel(string filename)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files|*.xlsx;*.xls";
            saveFileDialog1.Title = "Save an Excel File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Replace this path with the path of your Excel file
                var pth = AppDomain.CurrentDomain.BaseDirectory;
                string sourceFilePath = pth + filename;
                string destinationFilePath = saveFileDialog1.FileName;

                try
                {
                    File.Copy(sourceFilePath, destinationFilePath);
                    MessageBox.Show("File saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
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

                room1.DataSource = null;
                room1.Items.Clear();

                List<NutritionistInfo> Room1 = new List<NutritionistInfo>();
                List<NutritionistInfo> Room2 = new List<NutritionistInfo>();
                List<NutritionistInfo> Room3 = new List<NutritionistInfo>();
                List<NutritionistInfo> Room4 = new List<NutritionistInfo>();

                Room1.Add(new NutritionistInfo { ID = 0, Name = "Null" });
                Room2.Add(new NutritionistInfo { ID = 0, Name = "Null" });
                Room3.Add(new NutritionistInfo { ID = 0, Name = "Null" });
                Room4.Add(new NutritionistInfo { ID = 0, Name = "Null" });

                foreach (DataRow row in dt.Rows)
                {
                    int Id = row.Field<int>("ID");
                    string Name = row.Field<string>("Name");


                    NutritionistInfo Temp = new NutritionistInfo { ID = Id, Name = Name };
                    Room1.Add(Temp);
                    Room2.Add(Temp);
                    Room3.Add(Temp);
                    Room4.Add(Temp);
                }

                room1.DataSource = Room1;
                room1.DisplayMember = "Name"; // Display Member is Name
                room1.ValueMember = "ID"; // Value Member is ID

                room2.DataSource = Room2;
                room2.DisplayMember = "Name"; // Display Member is Name
                room2.ValueMember = "ID"; // Value Member is ID

                room3.DataSource = Room3;
                room3.DisplayMember = "Name"; // Display Member is Name
                room3.ValueMember = "ID"; // Value Member is ID

                room4.DataSource = Room4;
                room4.DisplayMember = "Name"; // Display Member is Name
                room4.ValueMember = "ID"; // Value Member is ID

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
        void ShowUsers(DataGridView dgv, DataGridViewColumn NameGV, DataGridViewColumn UsernameGV, DataGridViewColumn PasswordGV, DataGridViewColumn RoleGv)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from Users order by Name", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                NameGV.DataPropertyName = dt.Columns["Name"].ToString();
                UsernameGV.DataPropertyName = dt.Columns["Username"].ToString();
                PasswordGV.DataPropertyName = dt.Columns["Password"].ToString();
                RoleGv.DataPropertyName = dt.Columns["Role"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        void Clear()
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cboRole.SelectedIndex = 0;
        }

        static int languagestatus;
        private void Start()
        {
            UpdateNutritionist();
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT COMPANYNAME,BRANCH,EMAIL,LANDLINE,MOBILE,POBOX,TRADENO,WELCOME,LOGO,Room1,Room2,Room3,Room4 FROM SETTINGS", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    companyname.Text = dr["COMPANYNAME"].ToString();
                    branch.Text = dr["BRANCH"].ToString();
                    email.Text = dr["EMAIL"].ToString();
                    landline.Text = dr["LANDLINE"].ToString();
                    mobile.Text = dr["MOBILE"].ToString();
                    pobox.Text = dr["POBOX"].ToString();
                    trade.Text = dr["TRADENO"].ToString();
                    welcomewords.Text = dr["WELCOME"].ToString();
                    pictureBox1.ImageLocation = dr["LOGO"].ToString();
                    logolocation = dr["LOGO"].ToString();
                    room1.Text = dr["Room1"].ToString();
                    room2.Text = dr["Room2"].ToString();
                    room3.Text = dr["Room3"].ToString();
                    room4.Text = dr["Room4"].ToString();
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
                    bold.Text = dr["Bold"].ToString();
                    itallic.Text = dr["Italic"].ToString();
                    underline.Text = dr["Underline"].ToString();
                    textsize.Text = dr["Size"].ToString();
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
        private void SettingScreen_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView1.GridColor = Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView4.GridColor = Color.Black;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView4.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView4.RowTemplate.DefaultCellStyle.ForeColor;

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
                    guna2TextBox9.Text = red.ToString();
                    guna2TextBox8.Text = green.ToString();
                    guna2TextBox7.Text = blue.ToString();
                    Color color = Color.FromArgb(red, green, blue);
                    panel13.BackColor = color;

                    foreach (Control control in panel9.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel8.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel7.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel4.Controls)
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
                    foreach (Control control in panel6.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel10.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel11.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in DatabaseSettingPanel.Controls)
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
                    guna2TextBox6.Text = red.ToString();
                    guna2TextBox5.Text = green.ToString();
                    guna2TextBox4.Text = blue.ToString();
                    Color color = Color.FromArgb(red, green, blue);
                    panel12.BackColor = color;

                    foreach (Control control in panel9.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }

                    foreach (Control control in panel8.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel7.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }

                    foreach (Control control in panel4.Controls)
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
                    foreach (Control control in panel6.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel10.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel11.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in DatabaseSettingPanel.Controls)
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

                    foreach (System.Windows.Forms.Control control in panel8.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel7.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel6.Controls)
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
                    foreach (System.Windows.Forms.Control control in panel4.Controls)
                    {
                        if (control is Label)
                        {
                            Label label = (Label)control;

                            Font font = new Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel11.Controls)
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
                    foreach (System.Windows.Forms.Control control in DatabaseSettingPanel.Controls)
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
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Red, Green, Blue FROM LoginPageColor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    int red = Convert.ToInt32(reader["Red"]);
                    int green = Convert.ToInt32(reader["Green"]);
                    int blue = Convert.ToInt32(reader["Blue"]);
                    guna2TextBox12.Text = red.ToString();
                    guna2TextBox11.Text = green.ToString();
                    guna2TextBox10.Text = blue.ToString();
                    Color color = Color.FromArgb(red, green, blue);
                    panel14.BackColor = color;

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
                SqlCommand cmd = new SqlCommand("SELECT Red, Green, Blue FROM RowSelection", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    int red = Convert.ToInt32(reader["Red"]);
                    int green = Convert.ToInt32(reader["Green"]);
                    int blue = Convert.ToInt32(reader["Blue"]);
                    guna2TextBox15.Text = red.ToString();
                    guna2TextBox14.Text = green.ToString();
                    guna2TextBox13.Text = blue.ToString();
                    Color color = Color.FromArgb(red, green, blue);
                    panel15.BackColor = color;

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
                SqlCommand cmd = new SqlCommand("SELECT Red, Green, Blue FROM SideBarColor", MainClass.con);

                // Execute the select query
                SqlDataReader reader = cmd.ExecuteReader();

                // Check if there is a color record in the table
                if (reader.Read())
                {
                    // Read color components from the database
                    int red = Convert.ToInt32(reader["Red"]);
                    int green = Convert.ToInt32(reader["Green"]);
                    int blue = Convert.ToInt32(reader["Blue"]);
                    guna2TextBox1.Text = red.ToString();
                    guna2TextBox2.Text = green.ToString();
                    guna2TextBox3.Text = blue.ToString();
                    selectedpanel.BackColor = Color.FromArgb(red, green, blue);

                    // Create Color object from the read components


                    // Set the `loginpanel` background color

                }


                // Close the data reader and database connection
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
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);

            }

            Start();

            MainClass.HideAllTabsOnTabControl(tabControl1);
            tabControl1.SelectedIndex = 2;

            if (languagestatus == 1)
            {
                //    language.SelectedIndex = 1;
            }
            else
            {
                //language.SelectedIndex = 0;
            }

            if (languagestatus == 1)
            {
                foreach (Control control in panel4.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel4.Width - currentLoc.X - control.Width, currentLoc.Y);

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
                    var mirroredLoc = new Point(panel5.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel6.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel6.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel7.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel7.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel8.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel8.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel9.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel9.Width - currentLoc.X - control.Width, currentLoc.Y);

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

                foreach (Control control in panel10.Controls)
                {
                    // Get the current location of the control
                    var currentLoc = control.Location;

                    // Calculate the mirrored location
                    var mirroredLoc = new Point(panel10.Width - currentLoc.X - control.Width, currentLoc.Y);

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
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (txtName.Text == "" && txtUsername.Text == "" && txtPassword.Text == "" && cboRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Password Mismatched");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("insert into Users (Name,Username,Password,Role) values(@Name,@Username,@Password,@Role)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text);
                            cmd.Parameters.AddWithValue("@Role", cboRole.SelectedItem);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("User Inserted Successfully.");
                            Clear();
                            ShowUsers(Datagridview1, NameGV, UsernameGV, PasswordGV, RoleGV);
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                if (edit == 1)
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Password Mismatched");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("update Users set Name = @Name, @Password = @Password, Role = @Role where Username = @Username", MainClass.con);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text);
                            cmd.Parameters.AddWithValue("@Role", cboRole.SelectedItem);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("User Updated Successfully.");
                            Clear();
                            ShowUsers(Datagridview1, NameGV, UsernameGV, PasswordGV, RoleGV);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" || txtUsername.Text != "" || txtPassword.Text != "" || cboRole.SelectedIndex != 0 || txtConfirmPassword.Text != "")
            {
                Clear();
            }
            else
            {
                Dashboard ds = new Dashboard();
                MainClass.showWindow(ds, this, MDI.ActiveForm);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            MainClass.showWindow(ds, this, MDI.ActiveForm);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Datagridview1 != null)
            {
                if (Datagridview1.Rows.Count > 0)
                {
                    if (Datagridview1.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from Users where Username = @Username", MainClass.con);
                            cmd.Parameters.AddWithValue("@Username", Datagridview1.CurrentRow.Cells[1].Value.ToString());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Deleted Successfully");
                            MainClass.con.Close();
                            ShowUsers(Datagridview1, NameGV, UsernameGV, PasswordGV, RoleGV);
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            txtName.Text = Datagridview1.CurrentRow.Cells[0].Value.ToString();
            txtUsername.Text = Datagridview1.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = Datagridview1.CurrentRow.Cells[2].Value.ToString();
            txtConfirmPassword.Text = Datagridview1.CurrentRow.Cells[2].Value.ToString();
            cboRole.SelectedItem = Datagridview1.CurrentRow.Cells[3].Value.ToString();
        }



        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnDatabaseSettings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }


        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return csvData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnBackupBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = fbd.SelectedPath;
                btnBackupBrowse.Enabled = true;
            }
        }

        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQL SERVER database backup files|*.bak";
            ofd.Title = "Database Restore";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = ofd.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

            {

                String Database = MainClass.con.Database.ToString();
                try
                {
                    MainClass.con.Open();
                    if (txtBackup.Text == "")
                    {
                        MessageBox.Show("Please Locate The Backup File", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        string q = "BACKUP DATABASE[" + Database + "] TO DISK = '" + txtBackup.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                        SqlCommand cmd = new SqlCommand(q, MainClass.con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Backup Success", "Success", MessageBoxButtons.OK);
                    }
                    MainClass.con.Close();
                }

                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

            {
                MainClass.con.Open();
                String Database = MainClass.con.Database.ToString();
                try
                {
                    string sql1 = string.Format("ALTER DATABASE [" + Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand cmd = new SqlCommand(sql1, MainClass.con);
                    cmd.ExecuteNonQuery();

                    string sql2 = string.Format("USE MASTER RESTORE DATABASE [" + Database + "] FROM DISK='" + txtRestore.Text + "' WITH REPLACE;");
                    SqlCommand cmd2 = new SqlCommand(sql2, MainClass.con);
                    cmd2.ExecuteNonQuery();

                    string sql3 = string.Format("ALTER DATABASE [" + Database + "] SET MULTI_USER");
                    SqlCommand cmd3 = new SqlCommand(sql3, MainClass.con);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Database Restored successfully", "Restore Database successs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { MainClass.con.Close(); }
            }
        }

        private void Dbsetting_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        static string logolocation;
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Settings SET CompanyName = @CompanyName, Branch = @Branch, Landline = @Landline, Mobile = @Mobile, Email = @Email, POBox = @POBox, TradeNo = @TradeNo, Welcome = @Welcome, Logo = @logo, Room1 = @Room1, Room2 = @Room2, Room3 = @Room3, Room4 = @Room4 WHERE ID = @ID", MainClass.con);

                cmd.Parameters.AddWithValue("@ID", 1); // Replace with the actual input control for ID.
                cmd.Parameters.AddWithValue("@CompanyName", companyname.Text); // Replace with the actual input control for INGREDIENT_AR.
                cmd.Parameters.AddWithValue("@Branch", branch.Text); // Replace with the actual input control for INGREDIENT_EN.
                cmd.Parameters.AddWithValue("@Landline", landline.Text); // Replace with the actual input control for GROUP_AR.
                cmd.Parameters.AddWithValue("@Mobile", mobile.Text); // Replace with the actual input control for GROUP_EN.
                cmd.Parameters.AddWithValue("@Email", email.Text); // Replace with the actual input control for CLASSIFICATION.
                cmd.Parameters.AddWithValue("@POBox", pobox.Text); // Replace with the actual input control for CALORIES.
                cmd.Parameters.AddWithValue("@TradeNo", trade.Text); // Replace with the actual input control for FATS.
                cmd.Parameters.AddWithValue("@Welcome", welcomewords.Text); // Replace with the actual input control for FIBERS.
                cmd.Parameters.AddWithValue("@Logo", logolocation.ToString());
                cmd.Parameters.AddWithValue("@Room1", room1.Text);
                cmd.Parameters.AddWithValue("@Room2", room2.Text);
                cmd.Parameters.AddWithValue("@Room3", room3.Text);
                cmd.Parameters.AddWithValue("@Room4", room4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Info updated successfully");

                // Clear the input controls or set them to default values.
                //companyname.Text = "";
                //branch.Text = "";
                //landline.Text = "";
                //mobile.Text = "";
                //email.Text = "";
                //pobox.Text = "";
                //trade.Text = "";
                //welcomewords.Text = "";

                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Attach_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    logolocation = dialog.FileName;
                    pictureBox1.ImageLocation = logolocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void AddNutri_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ShowNutritionist(guna2DataGridView4, iddgv, namedgv);
            tabControl1.SelectedIndex = 4;
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            if (nutriname.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Nutritionist (Name) " +
                        "VALUES (@Name)", MainClass.con);

                    cmd.Parameters.AddWithValue("@Name", nutriname.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully");
                    MainClass.con.Close();

                    nutriname.Text = "";


                    tabControl1.SelectedIndex = 2;
                    UpdateNutritionist();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill name!");
            }
        }

        private void ShowNutritionist(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn name)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID, Name FROM NUTRITIONIST", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                name.DataPropertyName = dt.Columns["Name"].ToString();


                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Deletegc_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView4 != null)
            {
                if (guna2DataGridView4.Rows.Count > 0)
                {
                    if (guna2DataGridView4.SelectedRows.Count == 1)
                    {

                        // Get the Ingredient ID to display in the confirmation message
                        string groupid = guna2DataGridView4.SelectedRows[0].Cells[0].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Nutritionist : " + groupid + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM NUTRITIONIST WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", groupid); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                //tabControl1.SelectedIndex = 2;
                                ShowNutritionist(guna2DataGridView4, iddgv, namedgv);
                                UpdateNutritionist();
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void Adduser_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Passkey) " +
                        "VALUES (@username,@passkey)", MainClass.con);

                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@passkey", password.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully");
                    MainClass.con.Close();

                    username.Text = "";
                    password.Text = "";

                    tabControl1.SelectedIndex = 2;
                    UpdateNutritionist();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill both Username and Password!");
            }
        }

        void ShowUser(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn Username)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from Users order by Username", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                no.DataPropertyName = dt.Columns["ID"].ToString();
                Username.DataPropertyName = dt.Columns["Username"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void usermanagement_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void modifyuser_Click(object sender, EventArgs e)
        {
            ShowUser(guna2DataGridView1, useriddgv, usernamedgv);
            tabControl1.SelectedIndex = 6;
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {

                        // Get the Ingredient ID to display in the confirmation message
                        string groupid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete User : " + groupid + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", groupid); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();

                                //tabControl1.SelectedIndex = 2;
                                ShowUser(guna2DataGridView1, useriddgv, usernamedgv);
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

        static string userid = "";
        private void edituser_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {
                        try
                        {

                            // Get the Ingredient ID to display in the confirmation message
                            string groupid = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                            // Ask for confirmation

                            SqlCommand cmd;
                            MainClass.con.Open();

                            cmd = new SqlCommand("SELECT ID,Username,Passkey FROM Users WHERE ID = @ID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ID", groupid);
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                userid = dr["ID"].ToString();
                                usernameedit.Text = dr["Username"].ToString();
                                passwordedit.Text = dr["Passkey"].ToString();
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
                }
            }
        }

        private void saveuser_Click(object sender, EventArgs e)
        {
            if (usernameedit.Text != "" && passwordedit.Text != "")
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET Username = @username, Passkey = @passkey WHERE ID = @userId", MainClass.con);

                    cmd.Parameters.AddWithValue("@userId", userid);
                    cmd.Parameters.AddWithValue("@username", usernameedit.Text);
                    cmd.Parameters.AddWithValue("@passkey", passwordedit.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User information updated successfully");
                    MainClass.con.Close();

                    usernameedit.Text = "";
                    passwordedit.Text = "";

                    tabControl1.SelectedIndex = 2;
                    //UpdateNutritionist();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Provide a valid  Username and Password!");
            }

        }




        private void Apply_Click(object sender, EventArgs e)
        {

            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE SideBarColor SET Color = @color WHERE Id = @colorId", MainClass.con);

                cmd.Parameters.AddWithValue("@colorId", 1);
                //cmd.Parameters.AddWithValue("@color", ColorTranslator.ToHtml(color));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Color theme updated successfully");
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            Application.Restart();
        }

        private void mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }

            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                string text = mobile.Text + e.KeyChar;
                if (!int.TryParse(text, out int number) || text.Length > 10 || (text.Length == 1 && e.KeyChar != '0'))
                {
                    e.Handled = true; // Ensure the text remains an integer, doesn't exceed 10 digits, and starts with 0
                }
            }
        }

        private void intlock(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 8;
        }

        private void downloadingredient_Click(object sender, EventArgs e)
        {
            SaveFileAsExcel("\\DemoIngredientsImport.xlsx");
        }

        private void importmeals_Click(object sender, EventArgs e)
        {
            SaveFileAsExcel("\\DemoMealsImport.xlsx");
        }


        private void gapplybutton_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE buttoncolor  SET Color = @color WHERE Id = @colorId", MainClass.con);

                cmd.Parameters.AddWithValue("@colorId", 1);
                //cmd.Parameters.AddWithValue("@color", ColorTranslator.ToHtml(color));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Button color updated successfully");
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            Application.Restart();
        }

        private void Colorsetting_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 9;
        }


        private void ApplyText_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE textcolor SET Color = @color WHERE Id = @colorId", MainClass.con);

                cmd.Parameters.AddWithValue("@colorId", 1);
                //cmd.Parameters.AddWithValue("@color", ColorTranslator.ToHtml(color));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Button text theme updated successfully");
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            Application.Restart();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ImportExcelToDatabase(string excelFilePath)
        {
            MainClass.con.Open();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string CompanyName = worksheet.Cells[row, 1].Value?.ToString();
                        string Branch = worksheet.Cells[row, 2].Value?.ToString();



                        string landline = worksheet.Cells[row, 3].Value?.ToString();
                        string mobile = worksheet.Cells[row, 4].Value?.ToString();


                        string email = worksheet.Cells[row, 5].Value?.ToString();
                        string pobox = worksheet.Cells[row, 6].Value?.ToString();
                        string tradeliscense = worksheet.Cells[row, 7].Value?.ToString();
                        string welcome = worksheet.Cells[row, 8].Value?.ToString();


                        string query = "UPDATE Settings " +
                        "SET CompanyName = @CompanyName, Branch = @Branch, Landline = @Landline, Mobile = @Mobile, " +
                        "Email = @Email, POBox = @POBox, TradeNo = @TradeNo, Welcome = @Welcome, " +
                        "Room1 = COALESCE(Room1, @Room1), Room2 = COALESCE(Room2, @Room2), " +
                        "Room3 = COALESCE(Room3, @Room3), Room4 = COALESCE(Room4, @Room4), Logo = COALESCE(Logo, @Logo)";

                        using (SqlCommand command = new SqlCommand(query, MainClass.con))
                        {
                            command.Parameters.AddWithValue("@CompanyName", CompanyName);
                            command.Parameters.AddWithValue("@Branch", Branch);
                            command.Parameters.AddWithValue("@Landline", landline);
                            command.Parameters.AddWithValue("@Mobile", mobile);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@POBox", pobox);
                            command.Parameters.AddWithValue("@TradeNo", tradeliscense);
                            command.Parameters.AddWithValue("@Welcome", welcome);
                            command.Parameters.AddWithValue("@Room1", "tradeliscense");
                            command.Parameters.AddWithValue("@Room2", "tradeliscense");
                            command.Parameters.AddWithValue("@Room3", "tradeliscense");
                            command.Parameters.AddWithValue("@Room4", "tradeliscense");
                            command.Parameters.AddWithValue("@Logo", "tradeliscense");

                            command.ExecuteNonQuery();
                        }

                        //}
                        //else
                        //{
                        //    MessageBox.Show("Some of the crucial columns are empty or null");
                        //}
                    }

                    MainClass.con.Close();

                    Start();
                    MessageBox.Show("Data imported successfully!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
            }
        }

        private void ColorClose_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void importsettings_Click(object sender, EventArgs e)
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

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            SaveFileAsExcel("\\DemoSettingImport.xlsx");
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE text SET bold = @bold, italic = @itallic, underline = @underline, Size = @size WHERE Id = @Id", MainClass.con);

                cmd.Parameters.AddWithValue("@Id", 1);
                cmd.Parameters.AddWithValue("@bold", bold.Text);
                cmd.Parameters.AddWithValue("@itallic", itallic.Text);
                cmd.Parameters.AddWithValue("@underline", underline.Text);
                cmd.Parameters.AddWithValue("@size", textsize.Text);

                cmd.ExecuteNonQuery();

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
                SqlCommand cmd = new SqlCommand("UPDATE SideBarColor SET Red = @red, Green = @green, Blue = @blue WHERE Id = @id", MainClass.con);

                // Set the command parameters
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@red", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@green", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@blue", guna2TextBox3.Text);

                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("UPDATE buttoncolor SET Red = @red, Green = @green, Blue = @blue WHERE Id = @id", MainClass.con);

                // Set the command parameters
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@red", guna2TextBox6.Text);
                cmd.Parameters.AddWithValue("@green", guna2TextBox5.Text);
                cmd.Parameters.AddWithValue("@blue", guna2TextBox4.Text);

                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("UPDATE textcolor SET Red = @red, Green = @green, Blue = @blue WHERE Id = @id", MainClass.con);

                // Set the command parameters
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@red", guna2TextBox9.Text);
                cmd.Parameters.AddWithValue("@green", guna2TextBox8.Text);
                cmd.Parameters.AddWithValue("@blue", guna2TextBox7.Text);

                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("UPDATE LoginPageColor SET Red = @red, Green = @green, Blue = @blue WHERE Id = @id", MainClass.con);

                // Set the command parameters
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@red", guna2TextBox12.Text);
                cmd.Parameters.AddWithValue("@green", guna2TextBox11.Text);
                cmd.Parameters.AddWithValue("@blue", guna2TextBox10.Text);

                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("UPDATE RowSelection SET Red = @red, Green = @green, Blue = @blue WHERE Id = @id", MainClass.con);

                // Set the command parameters
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@red", guna2TextBox15.Text);
                cmd.Parameters.AddWithValue("@green", guna2TextBox14.Text);
                cmd.Parameters.AddWithValue("@blue", guna2TextBox13.Text);

                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("UPDATE Settings SET CompanyName = @CompanyName, Branch = @Branch, Landline = @Landline, Mobile = @Mobile, Email = @Email, POBox = @POBox, TradeNo = @TradeNo, Welcome = @Welcome, Logo = @logo, Room1 = @Room1, Room2 = @Room2, Room3 = @Room3, Room4 = @Room4 WHERE ID = @ID", MainClass.con);

                cmd.Parameters.AddWithValue("@ID", 1); // Replace with the actual input control for ID.
                cmd.Parameters.AddWithValue("@CompanyName", companyname.Text); // Replace with the actual input control for INGREDIENT_AR.
                cmd.Parameters.AddWithValue("@Branch", branch.Text); // Replace with the actual input control for INGREDIENT_EN.
                cmd.Parameters.AddWithValue("@Landline", landline.Text); // Replace with the actual input control for GROUP_AR.
                cmd.Parameters.AddWithValue("@Mobile", mobile.Text); // Replace with the actual input control for GROUP_EN.
                cmd.Parameters.AddWithValue("@Email", email.Text); // Replace with the actual input control for CLASSIFICATION.
                cmd.Parameters.AddWithValue("@POBox", pobox.Text); // Replace with the actual input control for CALORIES.
                cmd.Parameters.AddWithValue("@TradeNo", trade.Text); // Replace with the actual input control for FATS.
                cmd.Parameters.AddWithValue("@Welcome", welcomewords.Text); // Replace with the actual input control for FIBERS.
                cmd.Parameters.AddWithValue("@Logo", logolocation.ToString());
                cmd.Parameters.AddWithValue("@Room1", room1.Text);
                cmd.Parameters.AddWithValue("@Room2", room2.Text);
                cmd.Parameters.AddWithValue("@Room3", room3.Text);
                cmd.Parameters.AddWithValue("@Room4", room4.Text);
                cmd.ExecuteNonQuery();

                // Clear the input controls or set them to default values.
                //companyname.Text = "";
                //branch.Text = "";
                //landline.Text = "";
                //mobile.Text = "";
                //email.Text = "";
                //pobox.Text = "";
                //trade.Text = "";
                //welcomewords.Text = "";

                MainClass.con.Close();
                MessageBox.Show("Setting updated successfully");
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            Application.Restart();
            //MainPage obj = new MainPage();
            //FormClosingEventArgs alpha = null;
            //obj.ClosetheApp(1, alpha);
        }

        private void RestartApp()
        {
            Application.Restart();
        }
        private void IntLock(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }
        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            selectedpanel.BackColor = Color.FromArgb(guna2TrackBar1.Value, guna2TrackBar2.Value, guna2TrackBar3.Value);
            guna2TextBox1.Text = guna2TrackBar1.Value.ToString();
            guna2TextBox2.Text = guna2TrackBar2.Value.ToString();
            guna2TextBox3.Text = guna2TrackBar3.Value.ToString();
        }

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            selectedpanel.BackColor = Color.FromArgb(guna2TrackBar1.Value, guna2TrackBar2.Value, guna2TrackBar3.Value);
            guna2TextBox1.Text = guna2TrackBar1.Value.ToString();
            guna2TextBox2.Text = guna2TrackBar2.Value.ToString();
            guna2TextBox3.Text = guna2TrackBar3.Value.ToString();
        }

        private void guna2TrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            selectedpanel.BackColor = Color.FromArgb(guna2TrackBar1.Value, guna2TrackBar2.Value, guna2TrackBar3.Value);
            guna2TextBox1.Text = guna2TrackBar1.Value.ToString();
            guna2TextBox2.Text = guna2TrackBar2.Value.ToString();
            guna2TextBox3.Text = guna2TrackBar3.Value.ToString();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {
                int value = int.Parse(guna2TextBox1.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar1.Value = value;
                    selectedpanel.BackColor = Color.FromArgb(guna2TrackBar1.Value, guna2TrackBar2.Value, guna2TrackBar3.Value);

                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text != "")
            {
                int value = int.Parse(guna2TextBox2.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar2.Value = value;
                    selectedpanel.BackColor = Color.FromArgb(guna2TrackBar1.Value, guna2TrackBar2.Value, guna2TrackBar3.Value);

                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text != "")
            {
                int value = int.Parse(guna2TextBox3.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar3.Value = value;
                    selectedpanel.BackColor = Color.FromArgb(guna2TrackBar1.Value, guna2TrackBar2.Value, guna2TrackBar3.Value);

                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TrackBar6_Scroll(object sender, ScrollEventArgs e)
        {
            panel12.BackColor = Color.FromArgb(guna2TrackBar6.Value, guna2TrackBar5.Value, guna2TrackBar4.Value);
            guna2TextBox6.Text = guna2TrackBar6.Value.ToString();
            guna2TextBox5.Text = guna2TrackBar5.Value.ToString();
            guna2TextBox4.Text = guna2TrackBar4.Value.ToString();
        }

        private void guna2TrackBar5_Scroll(object sender, ScrollEventArgs e)
        {
            panel12.BackColor = Color.FromArgb(guna2TrackBar6.Value, guna2TrackBar5.Value, guna2TrackBar4.Value);
            guna2TextBox6.Text = guna2TrackBar6.Value.ToString();
            guna2TextBox5.Text = guna2TrackBar5.Value.ToString();
            guna2TextBox4.Text = guna2TrackBar4.Value.ToString();
        }

        private void guna2TrackBar4_Scroll(object sender, ScrollEventArgs e)
        {
            panel12.BackColor = Color.FromArgb(guna2TrackBar6.Value, guna2TrackBar5.Value, guna2TrackBar4.Value);
            guna2TextBox6.Text = guna2TrackBar6.Value.ToString();
            guna2TextBox5.Text = guna2TrackBar5.Value.ToString();
            guna2TextBox4.Text = guna2TrackBar4.Value.ToString();
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "")
            {
                int value = int.Parse(guna2TextBox6.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar6.Value = value;
                    panel12.BackColor = Color.FromArgb(guna2TrackBar6.Value, guna2TrackBar5.Value, guna2TrackBar4.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text != "")
            {
                int value = int.Parse(guna2TextBox5.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar5.Value = value;
                    panel12.BackColor = Color.FromArgb(guna2TrackBar6.Value, guna2TrackBar5.Value, guna2TrackBar4.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text != "")
            {
                int value = int.Parse(guna2TextBox4.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar4.Value = value;
                    panel12.BackColor = Color.FromArgb(guna2TrackBar6.Value, guna2TrackBar5.Value, guna2TrackBar4.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TrackBar9_Scroll(object sender, ScrollEventArgs e)
        {
            panel13.BackColor = Color.FromArgb(guna2TrackBar9.Value, guna2TrackBar8.Value, guna2TrackBar7.Value);
            guna2TextBox9.Text = guna2TrackBar9.Value.ToString();
            guna2TextBox8.Text = guna2TrackBar8.Value.ToString();
            guna2TextBox7.Text = guna2TrackBar7.Value.ToString();
        }

        private void guna2TrackBar8_Scroll(object sender, ScrollEventArgs e)
        {
            panel13.BackColor = Color.FromArgb(guna2TrackBar9.Value, guna2TrackBar8.Value, guna2TrackBar7.Value);
            guna2TextBox9.Text = guna2TrackBar9.Value.ToString();
            guna2TextBox8.Text = guna2TrackBar8.Value.ToString();
            guna2TextBox7.Text = guna2TrackBar7.Value.ToString();
        }

        private void guna2TrackBar7_Scroll(object sender, ScrollEventArgs e)
        {
            panel13.BackColor = Color.FromArgb(guna2TrackBar9.Value, guna2TrackBar8.Value, guna2TrackBar7.Value);
            guna2TextBox9.Text = guna2TrackBar9.Value.ToString();
            guna2TextBox8.Text = guna2TrackBar8.Value.ToString();
            guna2TextBox7.Text = guna2TrackBar7.Value.ToString();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox9.Text != "")
            {
                int value = int.Parse(guna2TextBox9.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar9.Value = value;
                    panel13.BackColor = Color.FromArgb(guna2TrackBar9.Value, guna2TrackBar8.Value, guna2TrackBar7.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox8.Text != "")
            {
                int value = int.Parse(guna2TextBox8.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar8.Value = value;
                    panel13.BackColor = Color.FromArgb(guna2TrackBar9.Value, guna2TrackBar8.Value, guna2TrackBar7.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox7.Text != "")
            {
                int value = int.Parse(guna2TextBox7.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar7.Value = value;
                    panel13.BackColor = Color.FromArgb(guna2TrackBar9.Value, guna2TrackBar8.Value, guna2TrackBar7.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void language_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (language.Text == "Arabic")
            //{
            //    MainClass.con.Open();

            //    SqlCommand cmd = new SqlCommand("UPDATE Language SET Status = @Status WHERE ID = @ID", MainClass.con);

            //    cmd.Parameters.AddWithValue("@Status", 1); // Replace updatedLanguageStatusValue with the new status value.
            //    cmd.Parameters.AddWithValue("@ID", 1); // Replace languageIDValue with the ID of the language you want to update.

            //    cmd.ExecuteNonQuery();

            //    MainClass.con.Close();

            //}
            //else
            //{
            //    MainClass.con.Open();

            //    SqlCommand cmd = new SqlCommand("UPDATE Language SET Status = @Status WHERE ID = @ID", MainClass.con);

            //    cmd.Parameters.AddWithValue("@Status", 0); // Replace updatedLanguageStatusValue with the new status value.
            //    cmd.Parameters.AddWithValue("@ID", 1); // Replace languageIDValue with the ID of the language you want to update.

            //    cmd.ExecuteNonQuery();

            //    MainClass.con.Close();
            //}
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox12.Text != "")
            {
                int value = int.Parse(guna2TextBox12.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar12.Value = value;
                    panel14.BackColor = Color.FromArgb(guna2TrackBar12.Value, guna2TrackBar11.Value, guna2TrackBar10.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox11.Text != "")
            {
                int value = int.Parse(guna2TextBox11.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar11.Value = value;
                    panel14.BackColor = Color.FromArgb(guna2TrackBar12.Value, guna2TrackBar11.Value, guna2TrackBar10.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox10.Text != "")
            {
                int value = int.Parse(guna2TextBox10.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar10.Value = value;
                    panel14.BackColor = Color.FromArgb(guna2TrackBar12.Value, guna2TrackBar11.Value, guna2TrackBar10.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TrackBar12_Scroll(object sender, ScrollEventArgs e)
        {
            panel14.BackColor = Color.FromArgb(guna2TrackBar12.Value, guna2TrackBar11.Value, guna2TrackBar10.Value);
            guna2TextBox12.Text = guna2TrackBar12.Value.ToString();
            guna2TextBox11.Text = guna2TrackBar11.Value.ToString();
            guna2TextBox10.Text = guna2TrackBar10.Value.ToString();
        }

        private void guna2TrackBar11_Scroll(object sender, ScrollEventArgs e)
        {
            panel14.BackColor = Color.FromArgb(guna2TrackBar12.Value, guna2TrackBar11.Value, guna2TrackBar10.Value);
            guna2TextBox12.Text = guna2TrackBar12.Value.ToString();
            guna2TextBox11.Text = guna2TrackBar11.Value.ToString();
            guna2TextBox10.Text = guna2TrackBar10.Value.ToString();
        }

        private void guna2TrackBar10_Scroll(object sender, ScrollEventArgs e)
        {
            panel14.BackColor = Color.FromArgb(guna2TrackBar12.Value, guna2TrackBar11.Value, guna2TrackBar10.Value);
            guna2TextBox12.Text = guna2TrackBar12.Value.ToString();
            guna2TextBox11.Text = guna2TrackBar11.Value.ToString();
            guna2TextBox10.Text = guna2TrackBar10.Value.ToString();
        }

        private void guna2TrackBar15_Scroll(object sender, ScrollEventArgs e)
        {
            panel15.BackColor = Color.FromArgb(guna2TrackBar15.Value, guna2TrackBar14.Value, guna2TrackBar13.Value);
            guna2TextBox15.Text = guna2TrackBar15.Value.ToString();
            guna2TextBox14.Text = guna2TrackBar14.Value.ToString();
            guna2TextBox13.Text = guna2TrackBar13.Value.ToString();
        }

        private void guna2TrackBar14_Scroll(object sender, ScrollEventArgs e)
        {
            panel15.BackColor = Color.FromArgb(guna2TrackBar15.Value, guna2TrackBar14.Value, guna2TrackBar13.Value);
            guna2TextBox15.Text = guna2TrackBar15.Value.ToString();
            guna2TextBox14.Text = guna2TrackBar14.Value.ToString();
            guna2TextBox13.Text = guna2TrackBar13.Value.ToString();
        }

        private void guna2TrackBar13_Scroll(object sender, ScrollEventArgs e)
        {
            panel15.BackColor = Color.FromArgb(guna2TrackBar15.Value, guna2TrackBar14.Value, guna2TrackBar13.Value);
            guna2TextBox15.Text = guna2TrackBar15.Value.ToString();
            guna2TextBox14.Text = guna2TrackBar14.Value.ToString();
            guna2TextBox13.Text = guna2TrackBar13.Value.ToString();
        }

        private void guna2TextBox15_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox15.Text != "")
            {
                int value = int.Parse(guna2TextBox15.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar15.Value = value;
                    panel15.BackColor = Color.FromArgb(guna2TrackBar15.Value, guna2TrackBar14.Value, guna2TrackBar13.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox14.Text != "")
            {
                int value = int.Parse(guna2TextBox14.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar14.Value = value;
                    panel15.BackColor = Color.FromArgb(guna2TrackBar15.Value, guna2TrackBar14.Value, guna2TrackBar13.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox13.Text != "")
            {
                int value = int.Parse(guna2TextBox13.Text);
                if (value >= 0 && value <= 255)
                {
                    guna2TrackBar13.Value = value;
                    panel15.BackColor = Color.FromArgb(guna2TrackBar15.Value, guna2TrackBar14.Value, guna2TrackBar13.Value);
                }
                else
                {
                    MessageBox.Show("Vaue should be between 0 to 255");
                }
            }
        }
    }
}
