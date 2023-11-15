using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using OfficeOpenXml.LoadFunctions.Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32Interop.Enums;
using static HelloWorldSolutionIMS.Payment;
using static HelloWorldSolutionIMS.SettingScreen;

namespace HelloWorldSolutionIMS
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        public Registration(int id)
        {
            
            InitializeComponent();
            loaddata(id);
        }
       public void loaddata(int id)
        {
            edit = 1;
            try
            {
               
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", id); // Replace 'customerIdToFind' with the actual ID you want to find.

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input boxes
                        filenoTobeedited = int.Parse(reader["FileNo"].ToString());

                        firstname.Text = reader["FirstName"].ToString();
                        familyname.Text = reader["FamilyName"].ToString();
                        gender.Text = reader["Gender"].ToString();
                        dob.Value = Convert.ToDateTime(reader["DOB"]);
                        age.Text = reader["Age"].ToString();
                        mobileno.Text = reader["MobileNo"].ToString();
                        landline.Text = reader["Landline"].ToString();
                        email.Text = reader["Email"].ToString();
                        //subscriptionstatus.Text = reader["SubscriptionStatus"].ToString();
                        startdate.Value = Convert.ToDateTime(reader["SubscriptionStartDate"]);
                        enddate.Value = Convert.ToDateTime(reader["SubscriptionEndDate"]);
                        branch.Text = reader["Branch"].ToString();
                        lastvisitdate.Value = Convert.ToDateTime(reader["LastVisitDate"]);
                        nutritionistname.Text = reader["NutritionistName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Customer not found with FILE NO : " + filenoTobeedited);
                }
                reader.Close();
                MainClass.con.Close();
                bool anyRowsFound = false;
                SqlCommand cmd2;
                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    cmd2 = new SqlCommand("SELECT STARTDATE, ENDDATE FROM PAYMENT WHERE FILENO = @FILENO", MainClass.con);
                    cmd2.Parameters.AddWithValue("@FILENO", filenoTobeedited);
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        anyRowsFound = true;
                        DateTime startDate = (DateTime)reader2["STARTDATE"];
                        DateTime endDate = (DateTime)reader2["ENDDATE"];
                        DateTime currentDate = DateTime.Now;

                        if (currentDate >= startDate && currentDate <= endDate)
                        {
                            subscriptionstatus.Text = "Yes";
                        }
                        else
                        {
                            subscriptionstatus.Text = "Freezed";
                        }
                    }

                    reader2.Close();
                    if (!anyRowsFound)
                    {
                        // Execute other code when no rows are found
                        // For example:
                        subscriptionstatus.Text = "No";
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
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        static int edit = 0;
        public class NutritionistInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        private void UpdateBranch()
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT BRANCH FROM SETTINGS", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    
                    branch.Text = dr["BRANCH"].ToString();
                    
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
        private int GetLastFileno()
        {

            int fileno = 0;
            // Create a connection a
            MainClass.con.Open();

            // Create a SQL command to retrieve the last meal
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Customer ORDER BY ID DESC", MainClass.con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create a Meal object and populate it with data from the database

                        fileno = reader.GetInt32(reader.GetOrdinal("FILENO"));
                        // Retrieve other columns as needed

                    }
                }
            }
            MainClass.con.Close();


            return fileno;
        }
        private void ShowCustomer(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn file, DataGridViewColumn name, DataGridViewColumn familyname, DataGridViewColumn start, DataGridViewColumn end, DataGridViewColumn nutritionist)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();
               
              cmd = new SqlCommand("select ID,FileNo,FirstName,FamilyName,SubscriptionStartDate,SubscriptionEndDate,NutritionistName from Customer order by FileNo", MainClass.con);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                id.DataPropertyName = dt.Columns["ID"].ToString();
                file.DataPropertyName = dt.Columns["FileNo"].ToString();
                name.DataPropertyName = dt.Columns["FirstName"].ToString();
                familyname.DataPropertyName = dt.Columns["FamilyName"].ToString();
                start.DataPropertyName = dt.Columns["SubscriptionStartDate"].ToString();
                end.DataPropertyName = dt.Columns["SubscriptionEndDate"].ToString();
                nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchCustomer(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn file, DataGridViewColumn name, DataGridViewColumn fname, DataGridViewColumn start, DataGridViewColumn end, DataGridViewColumn nutritionist)
        {
            string file_no = fileno.Text;
            string searchname = firstname.Text;
            string searchfamily = familyname.Text;
            string searchgender = gender.Text;
            string searchmobileno = mobileno.Text;
            string searchlandline = landline.Text;
            string searchage = age.Text;
            string searchemail = email.Text;

          

            string whereClause = "1 = 1"; // Initialize an empty where clause

            if (file_no != "")
            {
                whereClause += " AND (FileNo = @FileNo)";
            }
            if (searchname != "")
            {
                whereClause += " AND (ISNULL(FirstName, '') LIKE @FirstName)";
            }

            if (searchfamily != "")
            {
                whereClause += " AND (ISNULL(FamilyName, '') LIKE @FamilyName)";
            }

            if (searchgender != "")
            {
                whereClause += " AND (Gender = @Gender)";
            }

            if (searchmobileno != "")
            {
                whereClause += " AND (MobileNo LIKE @MobileNo)";
            }

            if (searchlandline != "")
            {
                whereClause += " AND (Landline LIKE @Landline)";
            }

            if (searchage != "")
            {
                whereClause += " AND (Age = @Age)";
            }

            if (searchemail != "")
            {
                whereClause += " AND (Email LIKE @Email)";
            }

            try
            {
                MainClass.con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID, FileNo, FirstName, FamilyName, SubscriptionStartDate, SubscriptionEndDate, NutritionistName FROM Customer WHERE " + whereClause, MainClass.con);

                if (file_no != "")
                {
                    cmd.Parameters.AddWithValue("@FileNo", int.Parse(file_no));
                }

                if (searchname != "")
                {
                    cmd.Parameters.AddWithValue("@FirstName", "%" + searchname + "%");
                }

                if (searchfamily != "")
                {
                    cmd.Parameters.AddWithValue("@FamilyName", "%" + searchfamily + "%");
                }

                if (searchgender != "")
                {
                    cmd.Parameters.AddWithValue("@Gender", searchgender);
                }

                if (searchmobileno != "")
                {
                    cmd.Parameters.AddWithValue("@MobileNo", "%" + searchmobileno + "%");
                }

                if (searchlandline != "")
                {
                    cmd.Parameters.AddWithValue("@Landline", "%" + searchlandline + "%");
                }

                if (searchage != "")
                {
                    cmd.Parameters.AddWithValue("@Age", int.Parse(searchage));
                }

                if (searchemail != "")
                {
                    cmd.Parameters.AddWithValue("@Email", "%" + searchemail + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                id.DataPropertyName = dt.Columns["ID"].ToString();
                file.DataPropertyName = dt.Columns["FileNo"].ToString();
                name.DataPropertyName = dt.Columns["FirstName"].ToString();
                fname.DataPropertyName = dt.Columns["FamilyName"].ToString();
                start.DataPropertyName = dt.Columns["SubscriptionStartDate"].ToString();
                end.DataPropertyName = dt.Columns["SubscriptionEndDate"].ToString();
                nutritionist.DataPropertyName = dt.Columns["NutritionistName"].ToString();
                dgv.DataSource = dt;

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }





        }
        private void New_Click(object sender, EventArgs e)
        {
            int fileno_new = GetLastFileno();
            fileno_new = fileno_new + 1;
            if (edit == 0)
            {
                if (firstname.Text != "" && familyname.Text != "" && gender.Text != "" && mobileno.Text != "" && dob.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Customer (FileNo, FirstName, FamilyName, Gender, DOB, Age, MobileNo, Landline, Email, SubscriptionStatus, SubscriptionStartDate, SubscriptionEndDate, Branch, LastVisitDate, NutritionistName) VALUES (@FileNo, @FirstName, @FamilyName, @Gender, @DOB, @Age, @MobileNo, @Landline, @Email, @SubscriptionStatus, @SubscriptionStartDate, @SubscriptionEndDate, @Branch, @LastVisitDate, @NutritionistName)", MainClass.con);

                        cmd.Parameters.AddWithValue("@FileNo", fileno_new); // Replace fileNoValue with the actual file number.
                        cmd.Parameters.AddWithValue("@FirstName", firstname.Text);
                        cmd.Parameters.AddWithValue("@FamilyName", familyname.Text);
                        cmd.Parameters.AddWithValue("@Gender", gender.Text);
                        cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dob.Value)); // Assuming dateTimePickerDOB is used to select the date of birth.
                        cmd.Parameters.AddWithValue("@Age", age.Text); // Replace ageValue with the actual age.
                        cmd.Parameters.AddWithValue("@MobileNo", mobileno.Text);
                        cmd.Parameters.AddWithValue("@Landline", landline.Text);
                        cmd.Parameters.AddWithValue("@Email", email.Text);
                        cmd.Parameters.AddWithValue("@SubscriptionStatus", subscriptionstatus.Text);
                        cmd.Parameters.AddWithValue("@SubscriptionStartDate", Convert.ToDateTime(startdate.Value)); // Assuming dateTimePickerSubscriptionStart is used to select the subscription start date.
                        cmd.Parameters.AddWithValue("@SubscriptionEndDate", Convert.ToDateTime(enddate.Value)); // Assuming dateTimePickerSubscriptionEnd is used to select the subscription end date.
                        cmd.Parameters.AddWithValue("@Branch", branch.Text);
                        cmd.Parameters.AddWithValue("@LastVisitDate", Convert.ToDateTime(lastvisitdate.Value)); // Assuming dateTimePickerLastVisit is used to select the last visit date.
                        cmd.Parameters.AddWithValue("@NutritionistName", nutritionistname.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer added successfully");
                        
                        firstname.Text = "";
                        familyname.Text = "";
                        gender.SelectedItem = null;
                        dob.Value = DateTime.Now; // Reset the date of birth to the current date or your default value.
                        age.Text = "";
                        mobileno.Text = "";
                        landline.Text = "";
                        email.Text = "";
                        subscriptionstatus.Text = "";
                        startdate.Value = DateTime.Now; // Reset the subscription start date to the current date or your default value.
                        enddate.Value = DateTime.Now; // Reset the subscription end date to the current date or your default value.
                        branch.Text = "";
                        lastvisitdate.Value = DateTime.Now; // Reset the last visit date to the current date or your default value.
                        nutritionistname.SelectedItem = null;
                        MainClass.con.Close();

                        int filenonew = GetLastFileno();
                        filenonew = filenonew + 1;

                        fileno.Text = filenonew.ToString();

                        ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("First name, Family name, gender, mobile no, Date of birth are mandatory!.");
                }
            }
            else
            {
                if (firstname.Text != "" && familyname.Text != "" && gender.Text != "" && mobileno.Text != "" && dob.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Customer SET FileNo = @FileNo, FirstName = @FirstName, FamilyName = @FamilyName, Gender = @Gender, DOB = @DOB, Age = @Age, MobileNo = @MobileNo, Landline = @Landline, Email = @Email, SubscriptionStatus = @SubscriptionStatus, SubscriptionStartDate = @SubscriptionStartDate, SubscriptionEndDate = @SubscriptionEndDate, Branch = @Branch, LastVisitDate = @LastVisitDate, NutritionistName = @NutritionistName WHERE FileNo = @FileNo", MainClass.con);

                        cmd.Parameters.AddWithValue("@FileNo", filenoTobeedited); // Replace fileNoValue with the actual file number.
                        cmd.Parameters.AddWithValue("@FirstName", firstname.Text);
                        cmd.Parameters.AddWithValue("@FamilyName", familyname.Text);
                        cmd.Parameters.AddWithValue("@Gender", gender.Text);
                        cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dob.Value)); // Assuming dateTimePickerDOB is used to select the date of birth.
                        cmd.Parameters.AddWithValue("@Age", age.Text); // Replace ageValue with the actual age.
                        cmd.Parameters.AddWithValue("@MobileNo", mobileno.Text);
                        cmd.Parameters.AddWithValue("@Landline", landline.Text);
                        cmd.Parameters.AddWithValue("@Email", email.Text);
                        cmd.Parameters.AddWithValue("@SubscriptionStatus", subscriptionstatus.Text);
                        cmd.Parameters.AddWithValue("@SubscriptionStartDate", Convert.ToDateTime(startdate.Value)); // Assuming dateTimePickerSubscriptionStart is used to select the subscription start date.
                        cmd.Parameters.AddWithValue("@SubscriptionEndDate", Convert.ToDateTime(enddate.Value)); // Assuming dateTimePickerSubscriptionEnd is used to select the subscription end date.
                        cmd.Parameters.AddWithValue("@Branch", branch.Text);
                        cmd.Parameters.AddWithValue("@LastVisitDate", Convert.ToDateTime(lastvisitdate.Value)); // Assuming dateTimePickerLastVisit is used to select the last visit date.
                        cmd.Parameters.AddWithValue("@NutritionistName", nutritionistname.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer updated successfully");
                        fileno.Text = "";
                        firstname.Text = "";
                        familyname.Text = "";
                        gender.SelectedItem = null;
                        dob.Value = DateTime.Now; // Reset the date of birth to the current date or your default value.
                        age.Text = "";
                        mobileno.Text = "";
                        landline.Text = "";
                        email.Text = "";
                        subscriptionstatus.Text = "";
                        startdate.Value = DateTime.Now; // Reset the subscription start date to the current date or your default value.
                        enddate.Value = DateTime.Now; // Reset the subscription end date to the current date or your default value.
                        branch.Text = "";
                        lastvisitdate.Value = DateTime.Now; // Reset the last visit date to the current date or your default value.
                        nutritionistname.Text = "";
                        MainClass.con.Close();

                        int filenonew = GetLastFileno();
                        filenonew = filenonew + 1;

                        fileno.Text = filenonew.ToString();

                        ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("First name, Family name, gender, mobile no, Date of birth are mandatory!.");
                }
            }
           
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Color FROM textcolor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    string colorString = reader["Color"].ToString();
                    System.Drawing.Color color = ColorTranslator.FromHtml(colorString);

                    foreach (Control control in panel1.Controls)
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
                else
                {
                    foreach (Control control in panel1.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.ForeColor = System.Drawing.Color.Green;
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
                SqlCommand cmd = new SqlCommand("SELECT Color FROM buttoncolor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    string colorString = reader["Color"].ToString();
                    System.Drawing.Color color = ColorTranslator.FromHtml(colorString);

                    foreach (Control control in panel1.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = color;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
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
                else
                {
                    foreach (Control control in panel1.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = System.Drawing.Color.Green;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel2.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = System.Drawing.Color.Green;
                            // You can access other properties or perform actions with the buttons here
                        }
                    }
                    foreach (Control control in panel3.Controls)
                    {
                        if (control is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)control;
                            // Access each button here, for instance, you can print the text of each button
                            button.FillColor = System.Drawing.Color.Green;
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
            UpdateBranch();
            UpdateNutritionist();
            MainClass.HideAllTabsOnTabControl(tabControl1);
           
            ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);

        }
        static int conn = 0;
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
             try
                {
                    string customerIDToEdit = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string customerFilenoToEdit = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE ID = @CustomerID", MainClass.con);
                    cmd.Parameters.AddWithValue("@CustomerID", customerIDToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Set the retrieved data into input boxes
                            fileno.Text = reader["FileNo"].ToString();

                            firstname.Text = reader["FirstName"].ToString();
                            familyname.Text = reader["FamilyName"].ToString();
                            gender.Text = reader["Gender"].ToString();
                            dob.Value = Convert.ToDateTime(reader["DOB"]);
                            age.Text = reader["Age"].ToString();
                            mobileno.Text = reader["MobileNo"].ToString();
                            landline.Text = reader["Landline"].ToString();
                            email.Text = reader["Email"].ToString();
                            //subscriptionstatus.Text = reader["SubscriptionStatus"].ToString();
                            startdate.Value = Convert.ToDateTime(reader["SubscriptionStartDate"]);
                            enddate.Value = Convert.ToDateTime(reader["SubscriptionEndDate"]);
                            branch.Text = reader["Branch"].ToString();
                            lastvisitdate.Value = Convert.ToDateTime(reader["LastVisitDate"]);
                            nutritionistname.Text = reader["NutritionistName"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer not found with FILE NO : " + customerFilenoToEdit);
                    }
                    reader.Close();
                    MainClass.con.Close();
                bool anyRowsFound = false;
                SqlCommand cmd2;
                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    cmd2 = new SqlCommand("SELECT STARTDATE, ENDDATE FROM PAYMENT WHERE FILENO = @FILENO", MainClass.con);
                    cmd2.Parameters.AddWithValue("@FILENO", fileno.Text);
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        anyRowsFound = true;
                        DateTime startDate = (DateTime)reader2["STARTDATE"];
                        DateTime endDate = (DateTime)reader2["ENDDATE"];
                        DateTime currentDate = DateTime.Now;

                        if (currentDate >= startDate && currentDate <= endDate)
                        {
                            subscriptionstatus.Text = "Yes";
                        }
                        else
                        {
                            subscriptionstatus.Text = "Freezed";
                        }
                    }

                    reader2.Close();
                    if (!anyRowsFound)
                    {
                        // Execute other code when no rows are found
                        // For example:
                        subscriptionstatus.Text = "No";
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
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {
                        // Get the CustomerID to display in the confirmation message
                        string customerIDToDelete = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Customer with FILE NO: " + customerIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from Customer where ID = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Customer removed successfully");
                                MainClass.con.Close();
                                ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
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
        private void Update_Click(object sender, EventArgs e)
        {
           
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
        private void Search_Click(object sender, EventArgs e)
        {

            SearchCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);

        }
        private void mobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }

            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                string text = mobileno.Text + e.KeyChar;
                if (!int.TryParse(text, out int number) || text.Length > 10 || (text.Length == 1 && e.KeyChar != '0'))
                {
                    e.Handled = true; // Ensure the text remains an integer, doesn't exceed 10 digits, and starts with 0
                }
            }

        }
        private void landline_TextChanged(object sender, EventArgs e)
        {

        }
        private void landline_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }
        private void dob_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dob.Value;
            DateTime currentDate = DateTime.Today;

            int years = currentDate.Year - selectedDate.Year;
            if (selectedDate.Date > currentDate.AddYears(-years)) years--;

            // Use the 'years' variable as needed, for instance, displaying it in a label
            age.Text = years.ToString();
        }
        private void age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }

        private void fileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }

        private void bodycomp_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
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
        private void AddBMI_Click(object sender, EventArgs e)
        {
            bca.Text = "";
            height.Text = "";
            weight.Text = "";
            protein.Text = "";
            water.Text = "";
            minerals.Text = "";
            abdominalfats.Text = "";
            visceralfats.Text = "";
            fats.Text = "";
            tabControl1.SelectedIndex = 2;
        }

        private void SaveBMI_Click(object sender, EventArgs e)
        {
            
            if (edit == 0)
            {
                if (firstnamebmi.Text != "" && familynamebmi.Text != "" && genderbmi.Text != "" && mobilenobmi.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO BodyComposition (DATE, BCA, LENGTH, WEIGHT, AGE, FATS, PROTEIN, WATER, MINERALS, VISCERAL_FATS, ABDOMINAL_FAT, BMI, BMR, CustomerID) " +
                                                        "VALUES (@DATE, @BCA, @LENGTH, @WEIGHT, @AGE, @FATS, @PROTEIN, @WATER, @MINERALS, @VISCERAL_FATS, @ABDOMINAL_FAT, @BMI, @BMR, @CustomerID)", MainClass.con);

                        // Assuming you have a customer ID, replace customerIDValue with the actual ID.
                        int customerIDValue = int.Parse(filenobmi.Text); // Get the actual customer ID from your application logic.

                        cmd.Parameters.AddWithValue("@DATE", DateTime.Now); // Assuming the current date is used.
                        cmd.Parameters.AddWithValue("@BCA", bca.Text); // Replace bcaValue with the actual value.
                        cmd.Parameters.AddWithValue("@LENGTH", height.Text); // Replace lengthValue with the actual value.
                        cmd.Parameters.AddWithValue("@WEIGHT", weight.Text); // Replace weightValue with the actual value.
                        cmd.Parameters.AddWithValue("@AGE", agebmi.Text); // Replace ageValue with the actual value.
                        cmd.Parameters.AddWithValue("@FATS", fats.Text); // Replace fatsValue with the actual value.
                        cmd.Parameters.AddWithValue("@PROTEIN", protein.Text); // Replace proteinValue with the actual value.
                        cmd.Parameters.AddWithValue("@WATER", water.Text); // Replace waterValue with the actual value.
                        cmd.Parameters.AddWithValue("@MINERALS", minerals.Text); // Replace mineralsValue with the actual value.
                        cmd.Parameters.AddWithValue("@VISCERAL_FATS", visceralfats.Text); // Replace visceralFatsValue with the actual value.
                        cmd.Parameters.AddWithValue("@ABDOMINAL_FAT", abdominalfats.Text); // Replace abdominalFatValue with the actual value.

                        var genderval = genderbmi.Text;
                        var heightval = double.Parse(height.Text);
                        var heightforBMR = heightval;
                        heightval = heightval / 100;
                        heightval = heightval * heightval;

                        var weightval = double.Parse(weight.Text);
                        var bmi = weightval / heightval;

                        weightval = weightval * 10;
                        heightforBMR = heightforBMR * 6.25;

                        int ageval = int.Parse(agebmi.Text);

                        ageval = ageval * 5;
                        double bmr = 0;
                        
                        if (genderval == "Female")
                        {
                            bmr = weightval + heightforBMR - ageval - 161;
                        }
                        else
                        {
                            bmr = weightval + heightforBMR - ageval + 5;
                        }

                        cmd.Parameters.AddWithValue("@BMI", bmi); // Replace bmiValue with the actual value.
                        cmd.Parameters.AddWithValue("@BMR", bmr); // Replace bmrValue with the actual value.
                        cmd.Parameters.AddWithValue("@CustomerID", customerIDValue);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Body composition data added successfully");
                        MainClass.con.Close();
                        ShowBodyComposition(guna2DataGridView2, idbc, datebc, bcabc, heightbc, weightbc, agebc, fatsbc, proteinbc, waterbc, mineralsbc, visceralfatsbc, abdominalfatsbc, bmibc, bmrbc);
                        tabControl1.SelectedIndex = 1;
                      
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("First name, Family name, gender, mobile no, Date of birth are mandory!.");
                }
            }
            else
            {
                if (filenobmi.Text != "" )
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE BodyComposition SET DATE = @DATE, BCA = @BCA, LENGTH = @LENGTH, WEIGHT = @WEIGHT, AGE = @AGE, FATS = @FATS, PROTEIN = @PROTEIN, WATER = @WATER, MINERALS = @MINERALS, VISCERAL_FATS = @VISCERAL_FATS, ABDOMINAL_FAT = @ABDOMINAL_FAT, BMI = @BMI, BMR = @BMR WHERE ID = @CustomerID", MainClass.con);

                        // Assuming you have a customer ID, replace customerIDValue with the actual ID.
                        int customerIDValue = int.Parse(filenobmi.Text); // Get the actual customer ID from your application logic.

                        // Set parameters for the BodyComposition update
                        cmd.Parameters.AddWithValue("@DATE", DateTime.Now); // Assuming the current date is used.
                        cmd.Parameters.AddWithValue("@BCA", bca.Text); // Replace bcaValue with the actual value.
                        cmd.Parameters.AddWithValue("@LENGTH", height.Text); // Replace lengthValue with the actual value.
                        cmd.Parameters.AddWithValue("@WEIGHT", weight.Text); // Replace weightValue with the actual value.
                        cmd.Parameters.AddWithValue("@AGE", agebmi.Text); // Replace ageValue with the actual value.
                        cmd.Parameters.AddWithValue("@FATS", fats.Text); // Replace fatsValue with the actual value.
                        cmd.Parameters.AddWithValue("@PROTEIN", protein.Text); // Replace proteinValue with the actual value.
                        cmd.Parameters.AddWithValue("@WATER", water.Text); // Replace waterValue with the actual value.
                        cmd.Parameters.AddWithValue("@MINERALS", minerals.Text); // Replace mineralsValue with the actual value.
                        cmd.Parameters.AddWithValue("@VISCERAL_FATS", visceralfats.Text); // Replace visceralFatsValue with the actual value.
                        cmd.Parameters.AddWithValue("@ABDOMINAL_FAT", abdominalfats.Text); // Replace abdominalFatValue with the actual value.

                        var genderval = genderbmi.Text;
                        var heightval = double.Parse(height.Text);
                        var heightforBMR = heightval;
                        heightval = heightval / 100;
                        heightval = heightval * heightval;

                        var weightval = double.Parse(weight.Text);
                        var bmi = weightval / heightval;

                        weightval = weightval * 10;
                        heightforBMR = heightforBMR * 6.25;

                        int ageval = int.Parse(agebmi.Text);

                        ageval = ageval * 5;
                        double bmr = 0;

                        if (genderval == "Female")
                        {
                            bmr = weightval + heightforBMR - ageval - 161;
                        }
                        else
                        {
                            bmr = weightval + heightforBMR - ageval + 5;
                        }

                        cmd.Parameters.AddWithValue("@BMI", bmi); // Replace bmiValue with the actual value.
                        cmd.Parameters.AddWithValue("@BMR", bmr); // Replace bmrValue with the actual value.
                        cmd.Parameters.AddWithValue("@CustomerID", BMIID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Body composition data updated successfully");
                        MainClass.con.Close();
                        bca.Text = "";
                        height.Text = "";
                        weight.Text = "";
                        protein.Text = "";
                        water.Text = "";
                        minerals.Text = "";
                        abdominalfats.Text = "";
                        visceralfats.Text = "";
                        fats.Text = "";
                        ShowBodyComposition(guna2DataGridView2, idbc, datebc, bcabc, heightbc, weightbc, agebc, fatsbc, proteinbc, waterbc, mineralsbc, visceralfatsbc, abdominalfatsbc, bmibc, bmrbc);
                        tabControl1.SelectedIndex = 1;
                        edit = 1;
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("First name, Family name, gender, mobile no, Date of birth are mandory!.");
                }
            }
        }
        static string filenoforbmi;
        private void back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void ShowBodyComposition(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn date, DataGridViewColumn bca, DataGridViewColumn height, DataGridViewColumn weight, DataGridViewColumn age, DataGridViewColumn fats, DataGridViewColumn protein, DataGridViewColumn water, DataGridViewColumn mineral, DataGridViewColumn fat1, DataGridViewColumn fat2, DataGridViewColumn bmi, DataGridViewColumn bmr)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID,BCA,WATER,MINERALS,DATE,AGE,LENGTH,WEIGHT,FATS,PROTEIN,ABDOMINAL_FAT,VISCERAL_FATS,BMI,BMR FROM BodyComposition WHERE CustomerID = @CUSTOMERID ORDER BY ID", MainClass.con);
                cmd.Parameters.AddWithValue("@CUSTOMERID", filenobmi.Text); // Replace 'customerIdToFind' with the actual ID you want to find.
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                id.DataPropertyName = dt.Columns["ID"].ToString();
                date.DataPropertyName = dt.Columns["DATE"].ToString();
                bca.DataPropertyName = dt.Columns["BCA"].ToString();
                height.DataPropertyName = dt.Columns["LENGTH"].ToString();
                weight.DataPropertyName = dt.Columns["WEIGHT"].ToString();
                age.DataPropertyName = dt.Columns["AGE"].ToString();
                fats.DataPropertyName = dt.Columns["FATS"].ToString();
                protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();
                water.DataPropertyName = dt.Columns["WATER"].ToString();
                mineral.DataPropertyName = dt.Columns["MINERALS"].ToString();
                fat1.DataPropertyName = dt.Columns["VISCERAL_FATS"].ToString();
                fat2.DataPropertyName = dt.Columns["ABDOMINAL_FAT"].ToString();
                bmi.DataPropertyName = dt.Columns["BMI"].ToString();
                bmr.DataPropertyName = dt.Columns["BMR"].ToString();
               

                dgv.DataSource = dt;
                MainClass.con.Close();
                
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        static string BMIID;
        private void EditBMI_Click(object sender, EventArgs e)
        {
            edit = 1;
            try
            {
                int selectedIndex = guna2DataGridView2.SelectedRows[0].Index;
                BMIID = guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                filenoforbmi = BMIID;
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BodyComposition WHERE ID = @ID", MainClass.con);
                cmd.Parameters.AddWithValue("@ID", BMIID); // Replace 'customerIdToFind' with the actual ID you want to find.

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input boxes
                        bca.Text = reader["BCA"].ToString();
                        height.Text = reader["Length"].ToString();
                        weight.Text = reader["Weight"].ToString();
                        minerals.Text = reader["Minerals"].ToString();
                        visceralfats.Text = reader["VISCERAL_FATS"].ToString();
                        fats.Text = reader["Fats"].ToString();
                        protein.Text = reader["Protein"].ToString();
                        water.Text = reader["Water"].ToString();
                        abdominalfats.Text = reader["ABDOMINAL_FAT"].ToString();
                    }
                    tabControl1.SelectedIndex = 2;
                }
                else
                {
                    MessageBox.Show("Body Composition not found with ID : " + BMIID);
                }
                reader.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void Close_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            filenobmi.Text = "";
            firstnamebmi.Text = "";
            familynamebmi.Text = "";
            mobilenobmi.Text = "";
            genderbmi.SelectedItem = null;
            agebmi.Text = "";
            nutritionistbmi.Text = "";
            while (guna2DataGridView2.Rows.Count > 0)
            {
                guna2DataGridView2.Rows.RemoveAt(0);
            }
        }

        private void filenobmi_TextChanged(object sender, EventArgs e)
        {
            if(filenobmi.Text != "")
            {
                int value = int.Parse(filenobmi.Text);

                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    SqlCommand cmd2 = new SqlCommand("SELECT  FIRSTNAME, FAMILYNAME, MOBILENO, GENDER, AGE, NutritionistName FROM CUSTOMER " +
                        "WHERE FILENO = @fileno", MainClass.con);

                    cmd2.Parameters.AddWithValue("@fileno", value);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {


                        firstnamebmi.Text = reader2["FIRSTNAME"].ToString();
                        familynamebmi.Text = reader2["FAMILYNAME"].ToString();
                        mobilenobmi.Text = reader2["MOBILENO"].ToString();
                        genderbmi.Text = reader2["GENDER"].ToString();
                        agebmi.Text = reader2["AGE"].ToString();
                        nutritionistbmi.Text = reader2["NutritionistName"].ToString();
                        tabControl1.SelectedIndex = 1;
                        //filenobmi.ReadOnly = false;
                        firstnamebmi.ReadOnly = true;
                        familynamebmi.ReadOnly = true;
                        mobilenobmi.ReadOnly = true;
                        genderbmi.DropDownStyle = ComboBoxStyle.DropDownList;
                        agebmi.ReadOnly = true;
                        nutritionistbmi.ReadOnly = true;
                    }
                    else
                    {

                        MessageBox.Show("No customer with this file no exist!");
                    }

                    reader2.Close();
                    if (conn == 1)
                    {
                        MainClass.con.Close();
                        conn = 0;
                    }
                    ShowBodyComposition(guna2DataGridView2, idbc, datebc, bcabc, heightbc, weightbc, agebc, fatsbc, proteinbc, waterbc, mineralsbc, visceralfatsbc, abdominalfatsbc, bmibc, bmrbc);

                }
                catch (Exception ex)
                {

                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);

                }
            }
           
        }

        static int filenoTobeedited;
        private void EditBTN_Click(object sender, EventArgs e)
        {
            edit = 1;
            int id = int.Parse(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                string customerIDToEdit = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string customerFilenoToEdit = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE ID = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", customerIDToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Set the retrieved data into input boxes
                        filenoTobeedited = int.Parse(reader["FileNo"].ToString());
                        fileno.Text = reader["FileNo"].ToString();
                        firstname.Text = reader["FirstName"].ToString();
                        familyname.Text = reader["FamilyName"].ToString();
                        gender.Text = reader["Gender"].ToString();
                        dob.Value = Convert.ToDateTime(reader["DOB"]);
                        age.Text = reader["Age"].ToString();
                        mobileno.Text = reader["MobileNo"].ToString();
                        landline.Text = reader["Landline"].ToString();
                        email.Text = reader["Email"].ToString();
                        //subscriptionstatus.Text = reader["SubscriptionStatus"].ToString();
                        startdate.Value = Convert.ToDateTime(reader["SubscriptionStartDate"]);
                        enddate.Value = Convert.ToDateTime(reader["SubscriptionEndDate"]);
                        branch.Text = reader["Branch"].ToString();
                        lastvisitdate.Value = Convert.ToDateTime(reader["LastVisitDate"]);
                        nutritionistname.Text = reader["NutritionistName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Customer not found with FILE NO : " + customerFilenoToEdit);
                }
                reader.Close();
                MainClass.con.Close();
                bool anyRowsFound = false;
                SqlCommand cmd2;
                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    cmd2 = new SqlCommand("SELECT STARTDATE, ENDDATE FROM PAYMENT WHERE FILENO = @FILENO", MainClass.con);
                    cmd2.Parameters.AddWithValue("@FILENO", filenoTobeedited);
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        anyRowsFound = true;
                        DateTime startDate = (DateTime)reader2["STARTDATE"];
                        DateTime endDate = (DateTime)reader2["ENDDATE"];
                        DateTime currentDate = DateTime.Now;

                        if (currentDate >= startDate && currentDate <= endDate)
                        {
                            subscriptionstatus.Text = "Yes";
                        }
                        else
                        {
                            subscriptionstatus.Text = "Freezed";
                        }
                    }

                    reader2.Close();
                    if (!anyRowsFound)
                    {
                        // Execute other code when no rows are found
                        // For example:
                        subscriptionstatus.Text = "No";
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
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LoadData SET ClientID = @FileNoE WHERE ID = @id", MainClass.con);

                cmd.Parameters.AddWithValue("@id", 1); // Replace fileNoValue with the actual file number.
                cmd.Parameters.AddWithValue("@FileNoE", filenoTobeedited);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            //MainPage page = new MainPage(id);
            //page.Show();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {
                        // Get the CustomerID to display in the confirmation message
                        string customerIDToDelete = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Customer with FILE NO: " + customerIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from Customer where ID = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Customer removed successfully");
                                MainClass.con.Close();
                                ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
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

        private void AddClient_Click(object sender, EventArgs e)
        {
            int fileno_new = GetLastFileno();
            fileno_new = fileno_new + 1;

            fileno.Text = fileno_new.ToString();

            subscriptionstatus.Text = "No";

            //fileno.ReadOnly = true;
        }
    }
}
