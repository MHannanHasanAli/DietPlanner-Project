using Guna.UI2.HtmlRenderer.Adapters.Entities;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Win32Interop.Enums;
using Color = System.Drawing.Color;

namespace HelloWorldSolutionIMS
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
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
            loadform(new Registration());
        }

        private void guna2TileButton6_Click(object sender, EventArgs e)
        {
            loadform(new Appointment());
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
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
            loadform(new Payment());
        }

        private void guna2TileButton10_Click(object sender, EventArgs e)
        {
            loadform(new SpecialDeal());

        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            loadform(new DietPlan());

        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            loadform(new Diabetes());
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
