using Guna.UI2.WinForms;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace HelloWorldSolutionIMS
{
    public partial class MainPage : Form
    {
        static int client_id = 0;
        public MainPage()
        {
            InitializeComponent();
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LoadData SET ClientID = @FileNoE WHERE ID = @id", MainClass.con);

                cmd.Parameters.AddWithValue("@id", 1); // Replace fileNoValue with the actual file number.
                cmd.Parameters.AddWithValue("@FileNoE", 0);
                cmd.ExecuteNonQuery();
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
        static System.Drawing.Color selectedColor = System.Drawing.Color.White;
        private void MainPage_Load(object sender, EventArgs e)
        {
            LanguageInfo();
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

                    // Create Color object from the read components
                    Color color = Color.FromArgb(red, green, blue);

                    // Set the `loginpanel` background color
                    sidebar.BackColor = color;
                }
                else
                {
                    // Set the `loginpanel` background color to default white
                    sidebar.BackColor = Color.White;
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



            int w = 1200;
            int h = 737;
            //this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            loadform(new Registration());
        }
        public void formloader(object Form)
        {
            loadform(Form);
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            System.Drawing.Color color = Color.Orange;
            System.Drawing.Color textcolor = Color.White;
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
                    Color btncolor = Color.FromArgb(red, green, blue);
                    color = btncolor;

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
                SqlCommand cmd = new SqlCommand("SELECT Red, Green, Blue FROM textcolor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    int red = Convert.ToInt32(reader["Red"]);
                    int green = Convert.ToInt32(reader["Green"]);
                    int blue = Convert.ToInt32(reader["Blue"]);

                    // Create Color object from the read components
                    Color txtcolor = Color.FromArgb(red, green, blue);
                    textcolor = txtcolor;

                }

                reader.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);

            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            foreach (Control control in f.Controls)
            {
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;
                    // Access each button here, for instance, you can print the text of each button
                    button.FillColor = color;
                    // You can access other properties or perform actions with the buttons here
                }
            }
            foreach (Control control in f.Controls)
            {
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;
                    // Access each button here, for instance, you can print the text of each button
                    button.ForeColor = textcolor;
                    // You can access other properties or perform actions with the buttons here
                }
            }
            MealAction obj = new MealAction();
            foreach (Control control in obj.tabControl1.Controls)
            {
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;
                    // Access each button here, for instance, you can print the text of each button
                    button.FillColor = color;
                    // You can access other properties or perform actions with the buttons here
                }
            }
            foreach (Control control in obj.tabControl1.Controls)
            {
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;
                    // Access each button here, for instance, you can print the text of each button
                    button.ForeColor = textcolor;
                    // You can access other properties or perform actions with the buttons here
                }
            }
            this.mainpanel.Tag = f;
            f.Show();
        }
        private void guna2TileButton9_Click(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                SqlCommand cmd2;
                try
                {
                    MainClass.con.Open();

                    cmd2 = new SqlCommand("SELECT ClientID FROM LoadData", MainClass.con);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {

                        client_id = int.Parse(reader2["ClientID"].ToString());

                    }



                    MainClass.con.Close();

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }

                if (client_id != 0)
                {
                    loadform(new Registration(client_id));
                }
                else
                {
                    loadform(new Registration());
                }
            }
            else
            {
                SqlCommand cmd2;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");
                try
                {
                    MainClass.con.Open();

                    cmd2 = new SqlCommand("SELECT ClientID FROM LoadData", MainClass.con);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {

                        client_id = int.Parse(reader2["ClientID"].ToString());

                    }



                    MainClass.con.Close();

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }

                if (client_id != 0)
                {
                    loadform(new Registration(client_id));
                }
                else
                {
                    loadform(new Registration());
                }
            }

            client_id = 0;
        }

        private void guna2TileButton6_Click(object sender, EventArgs e)
        {
            if (languagestatus == 1)
            {
                SqlCommand cmd2;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");

                try
                {
                    MainClass.con.Open();

                    cmd2 = new SqlCommand("SELECT ClientID FROM LoadData", MainClass.con);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {

                        client_id = int.Parse(reader2["ClientID"].ToString());

                    }



                    MainClass.con.Close();

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }


                if (client_id != 0)
                {
                    loadform(new Appointment(client_id));
                }
                else
                {
                    loadform(new Appointment());
                }
            }
            else
            {
                SqlCommand cmd2;
                try
                {
                    MainClass.con.Open();

                    cmd2 = new SqlCommand("SELECT ClientID FROM LoadData", MainClass.con);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {

                        client_id = int.Parse(reader2["ClientID"].ToString());

                    }



                    MainClass.con.Close();

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }


                if (client_id != 0)
                {
                    loadform(new Appointment(client_id));
                }
                else
                {
                    loadform(new Appointment());
                }
            }

            client_id = 0;
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");

            loadform(new Instruction());

        }

        private void guna2TileButton12_Click(object sender, EventArgs e)
        {
            loadform(new Ingredient());
        }

        private void guna2TileButton8_Click(object sender, EventArgs e)
        {
            loadform(new MealAction());
        }

        private void guna2TileButton11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2;
            try
            {
                MainClass.con.Open();

                cmd2 = new SqlCommand("SELECT ClientID FROM LoadData", MainClass.con);

                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {

                    client_id = int.Parse(reader2["ClientID"].ToString());

                }



                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }


            if (client_id != 0)
            {
                loadform(new Payment(client_id));
            }
            else
            {
                loadform(new Payment());
            }
            client_id = 0;
        }

        private void guna2TileButton10_Click(object sender, EventArgs e)
        {
            loadform(new SpecialDeal());

        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2;
            try
            {
                MainClass.con.Open();

                cmd2 = new SqlCommand("SELECT ClientID FROM LoadData", MainClass.con);

                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {

                    client_id = int.Parse(reader2["ClientID"].ToString());

                }



                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            if (client_id != 0)
            {
                loadform(new DietPlan(client_id));
            }
            else
            {
                loadform(new DietPlan());
            }

            client_id = 0;

        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2;
            try
            {
                MainClass.con.Open();

                cmd2 = new SqlCommand("SELECT ClientID FROM LoadData", MainClass.con);

                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {

                    client_id = int.Parse(reader2["ClientID"].ToString());

                }



                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            if (client_id != 0)
            {
                loadform(new Diabetes(client_id));

            }
            else
            {
                loadform(new Diabetes());

            }
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            loadform(new SettingScreen());

        }

        private void guna2TileButton7_Click(object sender, EventArgs e)
        {
            loadform(new DietPlanTemplate());
        }
    }
}
