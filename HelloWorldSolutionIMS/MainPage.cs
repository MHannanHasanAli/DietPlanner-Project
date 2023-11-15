using Guna.UI2.HtmlRenderer.Adapters.Entities;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Win32Interop.Enums;
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
       

        static System.Drawing.Color selectedColor = System.Drawing.Color.White;
        private void MainPage_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Color FROM SideBarColor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
               if(reader.Read())
                {
                    string colorString = reader["Color"].ToString();
                    System.Drawing.Color color = ColorTranslator.FromHtml(colorString);
                    sidebar.BackColor = color;

                }
                else
                {
                    sidebar.BackColor = System.Drawing.Color.White;
                  
                }
                
                // Convert color from string to Color
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
             if(this.mainpanel.Controls.Count > 0 )
                this.mainpanel.Controls.RemoveAt(0);
            System.Drawing.Color color = Color.Orange;
            System.Drawing.Color textcolor = Color.White;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Color FROM buttoncolor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    string colorString = reader["Color"].ToString();
                   color = ColorTranslator.FromHtml(colorString);

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
                SqlCommand cmd = new SqlCommand("SELECT Color FROM textcolor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    string colorString = reader["Color"].ToString();
                    textcolor = ColorTranslator.FromHtml(colorString);

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

            if (client_id!=0)
            {
                loadform(new Registration(client_id));
            }
            else
            {
                loadform(new Registration());
            }

            client_id = 0;
        }
        
        private void guna2TileButton6_Click(object sender, EventArgs e)
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
            
            
            if(client_id != 0)
            {
                loadform(new Appointment(client_id));
            }
            else
            {
                loadform(new Appointment());
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
            if(client_id!=0)
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
