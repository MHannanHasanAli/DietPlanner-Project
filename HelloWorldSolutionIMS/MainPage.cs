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
            LanguageInfo();
            if (languagestatus == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");
            }
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

        public void DisposeAllForms()
        {
            // Iterate through all open forms and dispose them
            foreach (Form form in Application.OpenForms)
            {
                if (form != null && !form.IsDisposed)
                {
                    form.Dispose();
                }
            }
        }

        public void loadLogo()
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT LOGO FROM SETTINGS", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    sidebarlogo.ImageLocation = dr["LOGO"].ToString();
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

            loadLogo();

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
            foreach (System.Windows.Forms.Control control in f.Controls)
            {
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;
                    // Access each button here, for instance, you can print the text of each button
                    button.FillColor = color;
                    // You can access other properties or perform actions with the buttons here
                }
            }
            foreach (System.Windows.Forms.Control control in f.Controls)
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
            foreach (System.Windows.Forms.Control control in obj.tabControl1.Controls)
            {
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;
                    // Access each button here, for instance, you can print the text of each button
                    button.FillColor = color;
                    // You can access other properties or perform actions with the buttons here
                }
            }
            foreach (System.Windows.Forms.Control control in obj.tabControl1.Controls)
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
            LanguageInfo();
            if (languagestatus == 0)
            {
                SqlCommand cmd2;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

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
            LanguageInfo();
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
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
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
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");
            LanguageInfo();
            if (languagestatus == 0)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");

            }
            loadform(new Instruction());

        }

        private void guna2TileButton12_Click(object sender, EventArgs e)
        {
            LanguageInfo();
            if (languagestatus == 0)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");

            }
            loadform(new Ingredient());
        }

        private void guna2TileButton8_Click(object sender, EventArgs e)
        {
            LanguageInfo();
            if (languagestatus == 0)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");
            }
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

        private void guna2TileButton5_Click(object sender, EventArgs e)
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
                loadform(new Evaluation(client_id));

            }
            else
            {
                loadform(new Evaluation());

            }

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User clicked Yes, close the form or perform other closing actions
                Application.Exit();
            }
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (languagestatus == 0)
                {
                    using (var customDialog = new CustomDialogForm())
                    {
                        customDialog.ConfirmationMessage = "Are you sure you want to close the application?";
                        if (customDialog.ShowDialogWithCustomButtons("Yes", "No") == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    using (var customDialog = new CustomDialogForm())
                    {
                        customDialog.ConfirmationMessage = "هل انت متاكد من اغلاق التطبيق؟";
                        if (customDialog.ShowDialogWithCustomButtons("نعم", "لا") == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }


        }

        public void ClosetheApp(int task, FormClosingEventArgs e)
        {
            if (task == 1)
            {

            }
            else
            {

            }
        }
        ToolTip toolTip1 = new ToolTip();
        private void guna2TileButton9_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton9, "Registration");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton9, "التسجيل");
            }


        }

        private void guna2TileButton6_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton6, "Appointment");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton6, "المواعيد");
            }
        }

        private void guna2TileButton12_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton12, "Ingredients");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton12, "المكونات");
            }
        }

        private void guna2TileButton8_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton8, "Meals");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton8, "الوجبات");
            }
        }

        private void guna2TileButton2_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton2, "Instructions");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton2, "الارشادات");
            }
        }

        private void guna2TileButton4_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton13, "Diabetes");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton13, "السكري");
            }
        }

        private void guna2TileButton3_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton14, "Diet Plan");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton14, "تخطيط الحميات");
            }
        }

        private void guna2TileButton7_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton15, "Diet Plan Template");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton15, "نماذج الحميات");
            }
        }

        private void guna2TileButton11_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton16, "Payment");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton16, "الدفعات");
            }
        }

        private void guna2TileButton5_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton17, "Evaluation");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton17, "التقييم");
            }
        }

        private void guna2TileButton10_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton18, "Special Deals");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton18, "عروض خاصة");
            }
        }

        private void guna2TileButton1_MouseHover(object sender, EventArgs e)
        {
            if (languagestatus == 0)
            {
                toolTip1.SetToolTip(guna2TileButton20, "Settings");
            }
            else
            {
                toolTip1.SetToolTip(guna2TileButton20, "الاعدادات");
            }
        }
    }
}
