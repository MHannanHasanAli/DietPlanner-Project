using ClosedXML.Excel;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class Registration : Form
    {
        public Registration()
        {
            LanguageInfo();
            if (languagestatus == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-AE");
            }
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

        List<string> history = new List<string>
{
    "Dysphagia",
    "Celiac disease",
    "Hepatitis",
    "Total cholesterol",
    "Esophageal reflux",
    "Gluten sensitivity",
    "Fatty liver",
    "LDL",
    "Indigestion (dyspepsia)",
    "Inflammatory bowel disease",
    "Diabetes type 1",
    "Nephrotic syndrome",
    "Vomiting",
    "Crohn's disease",
    "Diabetes type 2",
    "Acute kidney failure",
    "Peptic ulcer",
    "Short-bowel syndrome",
    "Atherosclerosis",
    "Chronic kidney failure",
    "H. pylori",
    "Diverticulitis",
    "Coronary heart disease",
    "Kidney stone",
    "Constipation",
    "Lactose intolerance",
    "Stroke",
    "Hypothyroidism",
    "Bloating",
    "Gallstone",
    "Hypertension",
    "Hyperthyroidism",
    "Irritable bowel syndrome",
    "Liver transplant",
    "Heart failure",
    "Irregular menstruation",
    "Steatorrhea",
    "Cirrhosis",
    "Triglycerides",
    "Gout"
};
        List<string> allegies = new List<string>
{
    "No",
    "Milk",
    "wheat",
    "Beans",
    "Strawberry",
    "Honey",
    "Peanut",
    "Nuts",
    "Fish",
    "Soy",
    "Sesame",
    "eggs"
};
        List<string> Deficiency = new List<string>
{
    "Iron",
    "vitamin D",
    "B12",
    "Folate",
    "calcium",
    "N/A"
};
        List<string> foodGroups = new List<string>
{
    "Milk group",
    "Dried fruits",
    "Avocado",
    "Eggs",
    "Red meat",
    "Eggplant",
    "White meat",
    "Wheat products",
    "Fish",
    "Nuts",
    "Legumes",
    "Seafood"
};

        private void PrepareMCQS()
        {
            DataGridViewCell cell1 = guna2DataGridView3.Rows[0].Cells[0];
            DataGridViewCell cell2 = guna2DataGridView3.Rows[0].Cells[1];
            DataGridViewCell cell3 = guna2DataGridView3.Rows[0].Cells[2];
            DataGridViewCell cell4 = guna2DataGridView3.Rows[0].Cells[3];

            DataGridViewCell cell5 = guna2DataGridView4.Rows[0].Cells[0];
            DataGridViewCell cell6 = guna2DataGridView4.Rows[0].Cells[1];
            DataGridViewCell cell7 = guna2DataGridView4.Rows[0].Cells[2];
            DataGridViewCell cell8 = guna2DataGridView4.Rows[0].Cells[3];

            DataGridViewCell cell9 = guna2DataGridView5.Rows[0].Cells[0];
            DataGridViewCell cell10 = guna2DataGridView5.Rows[0].Cells[1];
            DataGridViewCell cell11 = guna2DataGridView5.Rows[0].Cells[2];
            DataGridViewCell cell12 = guna2DataGridView5.Rows[0].Cells[3];
            DataGridViewCell cell13 = guna2DataGridView5.Rows[0].Cells[4];
            DataGridViewCell cell14 = guna2DataGridView5.Rows[0].Cells[5];
            DataGridViewCell cell15 = guna2DataGridView5.Rows[0].Cells[6];
            DataGridViewCell cell16 = guna2DataGridView5.Rows[0].Cells[7];
            guna2DataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView3.GridColor = Color.Black;
            guna2DataGridView3.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView3.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView4.GridColor = Color.Black;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView4.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView5.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView5.GridColor = Color.Black;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView5.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView6.GridColor = Color.Black;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView6.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView7.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView7.GridColor = Color.Black;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView7.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView8.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView8.GridColor = Color.Black;
            guna2DataGridView8.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView8.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView9.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView9.GridColor = Color.Black;
            guna2DataGridView9.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView9.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView10.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView10.GridColor = Color.Black;
            guna2DataGridView10.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView10.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView11.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView11.GridColor = Color.Black;
            guna2DataGridView11.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView11.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;
            guna2DataGridView12.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView12.GridColor = Color.Black;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView12.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView13.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView13.GridColor = Color.Black;
            guna2DataGridView13.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView13.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView14.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView14.GridColor = Color.Black;
            guna2DataGridView14.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView14.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView15.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView15.GridColor = Color.Black;
            guna2DataGridView15.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView15.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView16.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView16.GridColor = Color.Black;
            guna2DataGridView16.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView16.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView3.RowTemplate.DefaultCellStyle.ForeColor;

            cell1.Value = "Single";
            cell2.Value = "Pregnant";
            cell3.Value = "Breast Feeding";
            cell4.Value = "N/A";

            cell5.Value = "Smoker (Cigarettes)";
            cell6.Value = "Smoker (Hookah)";
            cell7.Value = "Smoker (Cigarettes & Hookah)";
            cell8.Value = "Non-Smoker";

            cell9.Value = "A+";
            cell10.Value = "A-";
            cell11.Value = "B+";
            cell12.Value = "B-";
            cell13.Value = "O+";
            cell14.Value = "O-";
            cell15.Value = "AB+";
            cell16.Value = "AB-";

            for (int i = 0; i < 10; i++)
            {
                guna2DataGridView6.Rows.Add();
            }

            int index = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    guna2DataGridView6.Rows[i].Cells[j].Value = history[index];
                    index++;
                }
            }



            guna2DataGridView7.Rows[0].Cells[0].Value = "No";
            guna2DataGridView7.Rows[0].Cells[1].Value = "Yes";
            guna2DataGridView8.Rows[0].Cells[0].Value = "No";
            guna2DataGridView8.Rows[0].Cells[1].Value = "Yes";
            guna2DataGridView9.Rows[0].Cells[0].Value = "No";
            guna2DataGridView9.Rows[0].Cells[1].Value = "Yes";
            guna2DataGridView10.Rows[0].Cells[0].Value = "No";
            guna2DataGridView10.Rows[0].Cells[1].Value = "Yes";
            guna2DataGridView11.Rows[0].Cells[0].Value = "No";
            guna2DataGridView11.Rows[0].Cells[1].Value = "Yes";
            guna2DataGridView12.Rows[0].Cells[0].Value = "No";
            guna2DataGridView12.Rows[0].Cells[1].Value = "Yes";

            for (int i = 0; i < 4; i++)
            {
                guna2DataGridView13.Rows.Add();
            }

            int index2 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    guna2DataGridView13.Rows[i].Cells[j].Value = allegies[index2];
                    index2++;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                guna2DataGridView14.Rows.Add();
            }

            int index3 = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    guna2DataGridView14.Rows[i].Cells[j].Value = Deficiency[index3];
                    index3++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                guna2DataGridView16.Rows.Add();
            }

            int index4 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    guna2DataGridView16.Rows[i].Cells[j].Value = foodGroups[index4];
                    index4++;
                }
            }

            guna2DataGridView15.Rows[0].Cells[0].Value = "Cortisone";
            guna2DataGridView15.Rows[0].Cells[1].Value = "Warfarin";
            guna2DataGridView15.Rows[0].Cells[2].Value = "Coumadin";
            guna2DataGridView15.Rows[0].Cells[3].Value = "N/A";


            guna2DataGridView3.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView4.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView5.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView6.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView7.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView8.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView9.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView10.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView11.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView12.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView13.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView14.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView15.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
            guna2DataGridView16.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);

            guna2DataGridView3.Rows[0].Height = 15;
            guna2DataGridView4.Rows[0].Height = 15;
            guna2DataGridView5.Rows[0].Height = 15;
            for (int i = 0; i < 10; i++)
            {
                guna2DataGridView6.Rows[i].Height = 15;

            }
            guna2DataGridView7.Rows[0].Height = 15;
            guna2DataGridView8.Rows[0].Height = 15;
            guna2DataGridView9.Rows[0].Height = 15;
            guna2DataGridView10.Rows[0].Height = 15;
            guna2DataGridView11.Rows[0].Height = 15;
            guna2DataGridView12.Rows[0].Height = 15;
            for (int i = 0; i < 4; i++)
            {
                guna2DataGridView13.Rows[i].Height = 15;
                if (i == 3)
                {
                    guna2DataGridView13.Rows[i].Height = 18;
                }
            }
            guna2DataGridView14.Rows[0].Height = 15;
            guna2DataGridView14.Rows[1].Height = 15;
            guna2DataGridView15.Rows[0].Height = 15;
            for (int i = 0; i < 3; i++)
            {
                guna2DataGridView16.Rows[i].Height = 18;

            }

            guna2DataGridView6.ClearSelection();
            guna2DataGridView13.ClearSelection();
            guna2DataGridView14.ClearSelection();
            guna2DataGridView16.ClearSelection();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            editstatus = 0;
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
                        if (control is System.Windows.Forms.Label)
                        {
                            System.Windows.Forms.Label label = (System.Windows.Forms.Label)control;

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel2.Controls)
                    {
                        if (control is System.Windows.Forms.Label)
                        {
                            System.Windows.Forms.Label label = (System.Windows.Forms.Label)control;

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
                            label.Font = font;
                        }
                    }
                    foreach (System.Windows.Forms.Control control in panel3.Controls)
                    {
                        if (control is System.Windows.Forms.Label)
                        {
                            System.Windows.Forms.Label label = (System.Windows.Forms.Label)control;

                            System.Drawing.Font font = new System.Drawing.Font(label.Font.FontFamily, fontSize, fontStyle);
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

            PrepareMCQS();
            MainClass.HideAllTabsOnTabControl(tabControl1);

            ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView1.GridColor = Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView2.GridColor = Color.Black;
            guna2DataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView2.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView2.RowTemplate.DefaultCellStyle.ForeColor;

            guna2DataGridView17.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView17.GridColor = Color.Black;
            guna2DataGridView17.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView17.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView17.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView17.RowTemplate.DefaultCellStyle.ForeColor;


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

                foreach (Control control in panel2.Controls)
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

                foreach (Control control in panel5.Controls)
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
            filenobmi.Text = "";
            firstnamebmi.Text = "";
            familynamebmi.Text = "";
            mobilenobmi.Text = "";
            genderbmi.SelectedItem = null;
            agebmi.Text = "";
            nutritionistbmi.Text = "";
            ShowBodyCompositionAll(guna2DataGridView2, idbc, datebc, bcabc, heightbc, weightbc, agebc, fatsbc, proteinbc, waterbc, mineralsbc, visceralfatsbc, abdominalfatsbc, bmibc, bmrbc);
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

                        cmd.Parameters.AddWithValue("@CustomerID", customerIDValue);
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
                if (filenobmi.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE BodyComposition SET DATE = @DATE, BCA = @BCA, LENGTH = @LENGTH, WEIGHT = @WEIGHT, AGE = @AGE, FATS = @FATS, PROTEIN = @PROTEIN, WATER = @WATER, MINERALS = @MINERALS, VISCERAL_FATS = @VISCERAL_FATS, ABDOMINAL_FAT = @ABDOMINAL_FAT, BMI = @BMI, BMR = @BMR WHERE ID = @CustomerID", MainClass.con);

                        // Assuming you have a customer ID, replace customerIDValue with the actual ID.
                        int customerIDValue = int.Parse(filenobmi.Text); // Get the actual customer ID from your application logic.

                        // Set parameters for the BodyComposition update
                        cmd.Parameters.AddWithValue("@CustomerID", BMIID);
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
        private void ShowMedicalHistoryAll(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn fileno, DataGridViewColumn name, DataGridViewColumn fname)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID,FILENO,FIRSTNAME,FAMILYNAME FROM MedicalHistory ORDER BY ID", MainClass.con);
                //cmd.Parameters.AddWithValue("@FILENO", filenomh.Text); // Replace 'customerIdToFind' with the actual ID you want to find.

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                id.DataPropertyName = dt.Columns["ID"].ToString();
                fileno.DataPropertyName = dt.Columns["FILENO"].ToString();
                name.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                fname.DataPropertyName = dt.Columns["FAMILYNAME"].ToString();



                dgv.DataSource = dt;
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMedicalHistory(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn fileno, DataGridViewColumn name, DataGridViewColumn fname)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID,FILENO,FIRSTNAME,FAMILYNAME FROM MedicalHistory WHERE FILENO = @fileno", MainClass.con);
                cmd.Parameters.AddWithValue("@fileno", filenomh.Text); // Replace 'customerIdToFind' with the actual ID you want to find.

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                id.DataPropertyName = dt.Columns["ID"].ToString();
                fileno.DataPropertyName = dt.Columns["FILENO"].ToString();
                name.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                fname.DataPropertyName = dt.Columns["FAMILYNAME"].ToString();



                dgv.DataSource = dt;
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
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
        private void ExportBCToExcel()
        {
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                // SQL query to select all rows from the Ingredient table
                string query = @"
            SELECT 
                    C.Fileno,
                    C.Firstname,
                    C.Familyname,
                	BC.DATE,
                    BC.BCA,
                    BC.WATER,
                    BC.MINERALS,
                    BC.AGE,
                    BC.LENGTH,
                    BC.WEIGHT,
                    BC.FATS,
                    BC.PROTEIN,
                    BC.ABDOMINAL_FAT,
                    BC.VISCERAL_FATS,
                    BC.BMI,
                    BC.BMR
                FROM 
                    BodyComposition BC
                JOIN 
                    customer C ON BC.CustomerID = C.FileNo;";

                using (SqlCommand command = new SqlCommand(query, MainClass.con))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        // Create a DataTable to hold the data
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Call the ExportToExcel function to save the data to Excel
                        ExportToExcel(dataTable);
                    }
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportMHToExcel()
        {
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                // SQL query to select all rows from the Ingredient table
                string query = @"
           SELECT
                MH.FileNo,
                C.Firstname,
                C.Familyname,
                MH.Status,
                MH.Smoking,
                MH.BloodType,
                Q.HormonalDisease,
                Q.Cancer,
                Q.ImmuneDisease,
                Q.HereditaryDisease,
                Q.PancreaticDisease,
                Q.OtherDisease,
                DH.Disease_History,
                FA.Food_Allergies,
                M.Medication,
                D.Deficiency,
                Diet.Diet  -- Assuming Diet is the column from the Diet table
            FROM
                MedicalHistory MH
            LEFT JOIN
                customer C ON MH.FileNo = C.FileNo
            LEFT JOIN
                Questions Q ON MH.FileNo = Q.FileNo
            LEFT JOIN
                (
                    SELECT
                        FileNo,
                        STRING_AGG(data, ', ') AS Disease_History
                    FROM
                        DiseaseHistory
                    GROUP BY
                        FileNo
                ) DH ON MH.FileNo = DH.FileNo
            LEFT JOIN
                (
                    SELECT
                        FileNo,
                        STRING_AGG(data, ', ') AS Food_Allergies
                    FROM
                        FoodAllergies
                    GROUP BY
                        FileNo
                ) FA ON MH.FileNo = FA.FileNo
            LEFT JOIN
                (
                    SELECT
                        FileNo,
                        STRING_AGG(data, ', ') AS Medication
                    FROM
                        Medication
                    GROUP BY
                        FileNo
                ) M ON MH.FileNo = M.FileNo
            LEFT JOIN
                (
                    SELECT
                        FileNo,
                        STRING_AGG(data, ', ') AS Deficiency
                    FROM
                        Deficiency
                    GROUP BY
                        FileNo
                ) D ON MH.FileNo = D.FileNo
            LEFT JOIN
                (
                    SELECT
                        FileNo,
                        STRING_AGG(data, ', ') AS Diet
                    FROM
                        Diet
                    GROUP BY
                        FileNo
                ) Diet ON MH.FileNo = Diet.FileNo;";

                using (SqlCommand command = new SqlCommand(query, MainClass.con))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        // Create a DataTable to hold the data
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Call the ExportToExcel function to save the data to Excel
                        ExportToExcel(dataTable);
                    }
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(DataTable dataTable)
        {
            try
            {
                // Create SaveFileDialog object
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Save As Excel File";
                saveFileDialog.DefaultExt = "xlsx";

                // Show the Save As dialog and check if the user selects a file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Creating Excel Workbook
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    // Writing Header with modification
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        string columnName = dataTable.Columns[i - 1].ColumnName;
                        // Change "Category" to "Data Source"

                        worksheet.Cell(1, i).Value = columnName;
                    }

                    // Writing Rows
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataTable.Rows[i][j].ToString();
                        }
                    }

                    // Save the workbook to the user-selected file path
                    string filePath = saveFileDialog.FileName;
                    workbook.SaveAs(filePath);

                    MessageBox.Show($"Data exported to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowBodyCompositionAll(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn date, DataGridViewColumn bca, DataGridViewColumn height, DataGridViewColumn weight, DataGridViewColumn age, DataGridViewColumn fats, DataGridViewColumn protein, DataGridViewColumn water, DataGridViewColumn mineral, DataGridViewColumn fat1, DataGridViewColumn fat2, DataGridViewColumn bmi, DataGridViewColumn bmr)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID,BCA,WATER,MINERALS,DATE,AGE,LENGTH,WEIGHT,FATS,PROTEIN,ABDOMINAL_FAT,VISCERAL_FATS,BMI,BMR FROM BodyComposition ORDER BY ID", MainClass.con);
                /* cmd.Parameters.AddWithValue("@CUSTOMERID", filenobmi.Text);*/ // Replace 'customerIdToFind' with the actual ID you want to find.

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
                string mhfileno = "0";
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
                        mhfileno = reader["CustomerID"].ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Body Composition not found with ID : " + BMIID);
                }
                reader.Close();
                MainClass.con.Close();
                filenobmi.Text = mhfileno;
                tabControl1.SelectedIndex = 2;
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
            if (filenobmi.Text != "")
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
                    if (editstatus == 1)
                    {
                        tabControl1.SelectedIndex = 0;
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
                firstnamebmi.Text = "";
                familynamebmi.Text = "";
                mobilenobmi.Text = "";
                genderbmi.SelectedItem = null;
                agebmi.Text = "";
                nutritionistbmi.Text = "";
                ShowBodyCompositionAll(guna2DataGridView2, idbc, datebc, bcabc, heightbc, weightbc, agebc, fatsbc, proteinbc, waterbc, mineralsbc, visceralfatsbc, abdominalfatsbc, bmibc, bmrbc);

            }

        }

        static int filenoTobeedited;
        static int editstatus = 0;
        private void EditBTN_Click(object sender, EventArgs e)
        {
            editstatus = 1;
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
                filenobmi.Text = filenoTobeedited.ToString();
                filenomh.Text = filenoTobeedited.ToString();
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
            editstatus = 0;
            //fileno.ReadOnly = true;
        }

        private void label32_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            filenomh.Text = "";
            firstnamemh.Text = "";
            familynamemh.Text = "";
            agemh.Text = "";
            mobilenomh.Text = "";
            nutritionistmh.Text = "";
            gendermh.SelectedItem = null;

            ShowMedicalHistoryAll(guna2DataGridView17, idmhdgv, filenomhdgv, firstnamemhdgv, familynamemhdgv);
            guna2DataGridView17.ClearSelection();
        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            guna2DataGridView3.Rows[rowIndex].Cells[columnIndex].Selected = true;
        }


        private void guna2DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the row index of the clicked cell

        }
        public class Indexing
        {
            public int row { get; set; }
            public int col { get; set; }

            public string value { get; set; }
        }
        public class IndexingQuestions
        {
            public int row { get; set; }
            public int col { get; set; }
            public string TableName { get; set; }
            public string value { get; set; }
            public string explanantion { get; set; }
        }
        private void ClearOldMedicalHistory()
        {
            string CurrentFileNo = filenomh.Text;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("delete from MedicalHistory where FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("delete from Diet where FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("delete from Questions where FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("delete from Medication where FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("delete from Deficiency where FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("delete from DiseaseHistory where FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("delete from FoodAllergies where FILENO = @CustomerID", MainClass.con);
                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                cmd.ExecuteNonQuery();

                MainClass.con.Close();
                //MessageBox.Show("Medical history removed successfully");

                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        List<Indexing> coordinates = new List<Indexing>();
        List<Indexing> Allegiescoordinates = new List<Indexing>();
        List<Indexing> Deficiencycoordinates = new List<Indexing>();
        List<Indexing> Medicationcoordinates = new List<Indexing>();
        List<Indexing> Dietcoordinates = new List<Indexing>();
        List<IndexingQuestions> Questions = new List<IndexingQuestions>();
        private void guna2DataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Indexing index = new Indexing();
            index.row = e.RowIndex;
            index.col = e.ColumnIndex;
            index.value = guna2DataGridView6.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in coordinates)
            {
                if (item.row == index.row && item.col == index.col)
                {
                    coordinates.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                coordinates.Add(index);
            }
            guna2DataGridView6.ClearSelection();
            for (int i = 0; i < guna2DataGridView6.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView6.Columns.Count; j++)
                {
                    guna2DataGridView6.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView6.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            foreach (var item in coordinates)
            {
                guna2DataGridView6.Rows[item.row].Cells[item.col].Style.BackColor = Color.FromArgb(128, 255, 128);
                guna2DataGridView6.Rows[item.row].Cells[item.col].Style.ForeColor = Color.Black;

            }
        }

        private void guna2DataGridView13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Indexing index = new Indexing();
            index.row = e.RowIndex;
            index.col = e.ColumnIndex;
            index.value = guna2DataGridView13.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in Allegiescoordinates)
            {
                if (item.row == index.row && item.col == index.col)
                {
                    Allegiescoordinates.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                Allegiescoordinates.Add(index);
            }
            guna2DataGridView13.ClearSelection();
            for (int i = 0; i < guna2DataGridView13.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView13.Columns.Count; j++)
                {
                    guna2DataGridView13.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView13.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            foreach (var item in Allegiescoordinates)
            {
                guna2DataGridView13.Rows[item.row].Cells[item.col].Style.BackColor = Color.FromArgb(128, 255, 128);
                guna2DataGridView13.Rows[item.row].Cells[item.col].Style.ForeColor = Color.Black;

            }
        }

        private void guna2DataGridView14_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Indexing index = new Indexing();
            index.row = e.RowIndex;
            index.col = e.ColumnIndex;
            index.value = guna2DataGridView14.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in Deficiencycoordinates)
            {
                if (item.row == index.row && item.col == index.col)
                {
                    Deficiencycoordinates.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                Deficiencycoordinates.Add(index);
            }
            guna2DataGridView14.ClearSelection();
            for (int i = 0; i < guna2DataGridView14.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView14.Columns.Count; j++)
                {
                    guna2DataGridView14.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView14.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            foreach (var item in Deficiencycoordinates)
            {
                guna2DataGridView14.Rows[item.row].Cells[item.col].Style.BackColor = Color.FromArgb(128, 255, 128);
                guna2DataGridView14.Rows[item.row].Cells[item.col].Style.ForeColor = Color.Black;

            }
        }

        private void guna2DataGridView15_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Indexing index = new Indexing();
            index.row = e.RowIndex;
            index.col = e.ColumnIndex;
            index.value = guna2DataGridView15.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in Medicationcoordinates)
            {
                if (item.row == index.row && item.col == index.col)
                {
                    Medicationcoordinates.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                Medicationcoordinates.Add(index);
            }
            guna2DataGridView15.ClearSelection();
            for (int i = 0; i < guna2DataGridView15.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView15.Columns.Count; j++)
                {
                    guna2DataGridView15.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView15.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            foreach (var item in Medicationcoordinates)
            {
                guna2DataGridView15.Rows[item.row].Cells[item.col].Style.BackColor = Color.FromArgb(128, 255, 128);
                guna2DataGridView15.Rows[item.row].Cells[item.col].Style.ForeColor = Color.Black;

            }
        }

        private void guna2DataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                hd.Visible = true;
            }
            else
            {
                hd.Visible = false;
            }
            IndexingQuestions index = new IndexingQuestions();
            index.row = 0;
            index.col = e.ColumnIndex;
            index.TableName = "guna2DataGridView7";
            index.value = guna2DataGridView7.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            index.explanantion = hd.Text;


            foreach (var item in Questions)
            {
                if (item.TableName == index.TableName)
                {
                    Questions.Remove(item);
                    break;
                }
            }

            Questions.Add(index);

        }

        private void guna2DataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                c.Visible = true;
            }
            else
            {
                c.Visible = false;
            }
            IndexingQuestions index = new IndexingQuestions();
            index.row = 0;
            index.col = e.ColumnIndex;
            index.TableName = "guna2DataGridView8";
            index.value = guna2DataGridView8.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            index.explanantion = c.Text;

            foreach (var item in Questions)
            {
                if (item.TableName == index.TableName)
                {
                    Questions.Remove(item);
                    break;
                }
            }

            Questions.Add(index);
        }

        private void guna2DataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                idbox.Visible = true;
            }
            else
            {
                idbox.Visible = false;
            }
            IndexingQuestions index = new IndexingQuestions();
            index.row = 0;
            index.col = e.ColumnIndex;
            index.TableName = "guna2DataGridView9";
            index.value = guna2DataGridView9.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            index.explanantion = idbox.Text;

            foreach (var item in Questions)
            {
                if (item.TableName == index.TableName)
                {
                    Questions.Remove(item);
                    break;
                }
            }

            Questions.Add(index);
        }

        private void guna2DataGridView10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                hed.Visible = true;
            }
            else
            {
                hed.Visible = false;
            }
            IndexingQuestions index = new IndexingQuestions();
            index.row = 0;
            index.col = e.ColumnIndex;
            index.TableName = "guna2DataGridView10";
            index.value = guna2DataGridView10.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            index.explanantion = hed.Text;

            foreach (var item in Questions)
            {
                if (item.TableName == index.TableName)
                {
                    Questions.Remove(item);
                    break;
                }
            }

            Questions.Add(index);
        }

        private void guna2DataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                pd.Visible = true;
            }
            else
            {
                pd.Visible = false;
            }
            IndexingQuestions index = new IndexingQuestions();
            index.row = 0;
            index.col = e.ColumnIndex;
            index.TableName = "guna2DataGridView11";
            index.value = guna2DataGridView11.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            index.explanantion = pd.Text;


            foreach (var item in Questions)
            {
                if (item.TableName == index.TableName)
                {
                    Questions.Remove(item);
                    break;
                }
            }

            Questions.Add(index);
        }

        private void guna2DataGridView12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                od.Visible = true;
            }
            else
            {
                od.Visible = false;
            }
            IndexingQuestions index = new IndexingQuestions();
            index.row = 0;
            index.col = e.ColumnIndex;
            index.TableName = "guna2DataGridView12";
            index.value = guna2DataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            index.explanantion = od.Text;


            foreach (var item in Questions)
            {
                if (item.TableName == index.TableName)
                {
                    Questions.Remove(item);
                    break;
                }
            }

            Questions.Add(index);
        }

        private void guna2DataGridView16_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Indexing index = new Indexing();
            index.row = e.RowIndex;
            index.col = e.ColumnIndex;
            index.value = guna2DataGridView16.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in Dietcoordinates)
            {
                if (item.row == index.row && item.col == index.col)
                {
                    Dietcoordinates.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                Dietcoordinates.Add(index);
            }
            guna2DataGridView16.ClearSelection();
            for (int i = 0; i < guna2DataGridView16.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView15.Columns.Count; j++)
                {
                    guna2DataGridView16.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView16.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            foreach (var item in Dietcoordinates)
            {
                guna2DataGridView16.Rows[item.row].Cells[item.col].Style.BackColor = Color.FromArgb(128, 255, 128);
                guna2DataGridView16.Rows[item.row].Cells[item.col].Style.ForeColor = Color.Black;

            }
        }

        private void filenomh_TextChanged(object sender, EventArgs e)
        {
            if (filenomh.Text != "")
            {
                int value = int.Parse(filenomh.Text);

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


                        firstnamemh.Text = reader2["FIRSTNAME"].ToString();
                        familynamemh.Text = reader2["FAMILYNAME"].ToString();
                        mobilenomh.Text = reader2["MOBILENO"].ToString();
                        gendermh.Text = reader2["GENDER"].ToString();
                        agemh.Text = reader2["AGE"].ToString();
                        nutritionistmh.Text = reader2["NutritionistName"].ToString();
                        //tabControl1.SelectedIndex = 1;
                        //filenomh.ReadOnly = false;
                        firstnamemh.ReadOnly = true;
                        familynamemh.ReadOnly = true;
                        mobilenomh.ReadOnly = true;
                        gendermh.DropDownStyle = ComboBoxStyle.DropDownList;
                        agemh.ReadOnly = true;
                        nutritionistmh.ReadOnly = true;
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
                }
                catch (Exception ex)
                {

                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);

                }
                ShowMedicalHistory(guna2DataGridView17, idmhdgv, filenomhdgv, firstnamemhdgv, familynamemhdgv);
                if (editstatus == 1)
                {
                    tabControl1.SelectedIndex = 0;
                }
            }
            else
            {
                firstnamemh.Text = "";
                familynamemh.Text = "";
                agemh.Text = "";
                mobilenomh.Text = "";
                nutritionistmh.Text = "";
                gendermh.SelectedItem = null;
                ShowMedicalHistoryAll(guna2DataGridView17, idmhdgv, filenomhdgv, firstnamemhdgv, familynamemhdgv);

            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (filenomh.Text != "")
            {
                tabControl1.SelectedIndex = 3;
            }
            else
            {
                MessageBox.Show("Please Fill file no first!");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            Clean();
            edit = 0;
            ShowMedicalHistory(guna2DataGridView17, idmhdgv, filenomhdgv, firstnamemhdgv, familynamemhdgv);

        }
        private void Clean()
        {
            coordinates.Clear();
            Allegiescoordinates.Clear();
            Deficiencycoordinates.Clear();
            Medicationcoordinates.Clear();
            Dietcoordinates.Clear();
            Questions.Clear();

            guna2DataGridView3.ClearSelection();
            guna2DataGridView4.ClearSelection();
            guna2DataGridView5.ClearSelection();
            guna2DataGridView6.ClearSelection();
            guna2DataGridView7.ClearSelection();
            guna2DataGridView8.ClearSelection();
            guna2DataGridView9.ClearSelection();
            guna2DataGridView10.ClearSelection();
            guna2DataGridView11.ClearSelection();
            guna2DataGridView12.ClearSelection();
            guna2DataGridView13.ClearSelection();
            guna2DataGridView14.ClearSelection();
            guna2DataGridView15.ClearSelection();
            guna2DataGridView16.ClearSelection();

            for (int i = 0; i < guna2DataGridView6.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView6.Columns.Count; j++)
                {
                    guna2DataGridView6.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView6.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            for (int i = 0; i < guna2DataGridView13.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView13.Columns.Count; j++)
                {
                    guna2DataGridView13.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView13.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            for (int i = 0; i < guna2DataGridView14.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView14.Columns.Count; j++)
                {
                    guna2DataGridView14.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView14.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            for (int i = 0; i < guna2DataGridView15.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView15.Columns.Count; j++)
                {
                    guna2DataGridView15.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView15.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            for (int i = 0; i < guna2DataGridView16.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView15.Columns.Count; j++)
                {
                    guna2DataGridView16.Rows[i].Cells[j].Style.BackColor = Color.White;
                    guna2DataGridView16.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            hd.Text = "";
            c.Text = "";
            hed.Text = "";
            pd.Text = "";
            idbox.Text = "";
            od.Text = "";
        }
        private void SaveMedicalHistory_Click(object sender, EventArgs e)
        {
            ClearOldMedicalHistory();
            int fileNoValue = int.Parse(filenomh.Text);
            if (edit == 0)
            {
                if (firstnamemh.Text != "" && familynamemh.Text != "" && gendermh.Text != "" && mobilenomh.Text != "")
                {
                    try
                    {
                        MainClass.con.Open(); // Open the connection to the database

                        // Prepare an SQL query to insert a new record into the MedicalHistory table
                        SqlCommand cmd = new SqlCommand("INSERT INTO MedicalHistory (FileNo, Status, Smoking, BloodType, Firstname, Familyname) " +
                                                        "VALUES (@FileNo, @Status, @Smoking, @BloodType, @Firstname, @Familyname)", MainClass.con);

                        cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Smoking", smoking); // Replace smokingValue with the actual value
                        cmd.Parameters.AddWithValue("@BloodType", bloodtype); // Replace bloodTypeValue with the actual value
                        cmd.Parameters.AddWithValue("@Firstname", firstnamemh.Text); // Replace firstnameValue with the actual value
                        cmd.Parameters.AddWithValue("@Familyname", familynamemh.Text); // Replace familynameValue with the actual value

                        cmd.ExecuteNonQuery();

                        // Close the connection to the database
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (coordinates.Count != 0)
                        {
                            MainClass.con.Open();
                            foreach (var item in coordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO DiseaseHistory (FileNo, rowindex, colindex, data) " +
                                                             "VALUES (@FileNo, @rowindex, @colindex, @data)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue); // Replace fileNoValue with the actual value.
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@data", item.value); // Replace data with the actual value.

                                cmd.ExecuteNonQuery();
                            }



                            //MessageBox.Show("Disease history data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Allegiescoordinates.Count != 0)
                        {
                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.

                            foreach (var item in Allegiescoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO FoodAllergies (FileNo, rowindex, colindex, data) " +
                                                             "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            //MessageBox.Show("Food allergy data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Deficiencycoordinates.Count != 0)
                        {
                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.

                            foreach (var item in Deficiencycoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Deficiency (FileNo, rowindex, colindex, data) " +
                                                            "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            //MessageBox.Show("Food allergy data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Medicationcoordinates.Count != 0)
                        {
                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.

                            foreach (var item in Medicationcoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Medication (FileNo, rowindex, colindex, data) " +
                                                            "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            //MessageBox.Show("Food allergy data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Dietcoordinates.Count != 0)
                        {


                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.


                            foreach (var item in Dietcoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Diet (FileNo, rowindex, colindex, data) " +
                                                            "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            MainClass.con.Close();

                            // Update the UI with the new data
                        }
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }


                    try
                    {
                        int check1 = 0;
                        int check2 = 0;
                        int check3 = 0;
                        int check4 = 0;
                        int check5 = 0;
                        int check6 = 0;
                        MainClass.con.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO Questions (FileNo, hormonalDisease, cancer, immuneDisease, hereditaryDisease, pancreaticDisease, otherDisease, hormonalDiseaseText, cancerText, immuneDiseaseText, hereditaryDiseaseText, pancreaticDiseaseText, otherDiseaseText) " +
                                                        "VALUES (@FileNo, @hormonalDisease, @cancer, @immuneDisease, @hereditaryDisease, @pancreaticDisease, @otherDisease, @hormonalDiseaseText, @cancerText, @immuneDiseaseText, @hereditaryDiseaseText, @pancreaticDiseaseText, @otherDiseaseText)", MainClass.con);

                        // Get the actual file number from your application logic and assign it to the @FileNo parameter
                        cmd.Parameters.AddWithValue("@FileNo", fileNoValue); // Replace fileNoValue with the actual value

                        foreach (var item in Questions)
                        {
                            if (item.TableName == "guna2DataGridView7")
                            {
                                check1 = 1;
                                cmd.Parameters.AddWithValue("@hormonalDisease", item.value);
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@hormonalDiseaseText", hd.Text); // Replace hormonalDiseaseTextValue with the actual value

                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@hormonalDiseaseText", "Nothing"); // Replace hormonalDiseaseTextValue with the actual value

                                }

                            }

                            if (item.TableName == "guna2DataGridView8")
                            {
                                check2 = 1;
                                cmd.Parameters.AddWithValue("@cancer", item.value);
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@cancerText", c.Text); // Replace cancerTextValue with the actual value

                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cancerText", "Nothing"); // Replace cancerTextValue with the actual value

                                }

                            }

                            if (item.TableName == "guna2DataGridView9")
                            {
                                check3 = 1;
                                cmd.Parameters.AddWithValue("@immuneDisease", item.value); // Replace immuneDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@immuneDiseaseText", idbox.Text); // Replace immuneDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@immuneDiseaseText", "Nothing"); // Replace immuneDiseaseTextValue with the actual value

                                }
                            }

                            if (item.TableName == "guna2DataGridView10")
                            {
                                check4 = 1;
                                cmd.Parameters.AddWithValue("@hereditaryDisease", item.value); // Replace hereditaryDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@hereditaryDiseaseText", hed.Text); // Replace hereditaryDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@hereditaryDiseaseText", "Nothing"); // Replace hereditaryDiseaseTextValue with the actual value

                                }
                            }

                            if (item.TableName == "guna2DataGridView11")
                            {
                                check5 = 1;
                                cmd.Parameters.AddWithValue("@pancreaticDisease", item.value); // Replace pancreaticDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@pancreaticDiseaseText", pd.Text); // Replace pancreaticDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@pancreaticDiseaseText", "Nothing"); // Replace pancreaticDiseaseTextValue with the actual value

                                }
                            }

                            if (item.TableName == "guna2DataGridView12")
                            {
                                check6 = 1;
                                cmd.Parameters.AddWithValue("@otherDisease", item.value); // Replace otherDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@otherDiseaseText", od.Text); // Replace otherDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@otherDiseaseText", "Nothing"); // Replace otherDiseaseTextValue with the actual value

                                }
                            }


                        }
                        if (check1 == 0)
                        {
                            cmd.Parameters.AddWithValue("@hormonalDisease", "No");
                            cmd.Parameters.AddWithValue("@hormonalDiseaseText", "Nothing");
                        }
                        if (check2 == 0)
                        {
                            cmd.Parameters.AddWithValue("@cancer", "No");
                            cmd.Parameters.AddWithValue("@cancerText", "Nothing");
                        }
                        if (check3 == 0)
                        {
                            cmd.Parameters.AddWithValue("@immuneDisease", "No");
                            cmd.Parameters.AddWithValue("@immuneDiseaseText", "Nothing");
                        }
                        if (check4 == 0)
                        {
                            cmd.Parameters.AddWithValue("@hereditaryDisease", "No");
                            cmd.Parameters.AddWithValue("@hereditaryDiseaseText", "Nothing");
                        }
                        if (check5 == 0)
                        {
                            cmd.Parameters.AddWithValue("@pancreaticDisease", "No");
                            cmd.Parameters.AddWithValue("@pancreaticDiseaseText", "Nothing");
                        }
                        if (check6 == 0)
                        {
                            cmd.Parameters.AddWithValue("@otherDisease", "No");
                            cmd.Parameters.AddWithValue("@otherDiseaseText", "Nothing");
                        }

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Task completed successfully");
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    tabControl1.SelectedIndex = 0;
                    Clean();

                }

                else
                {
                    MessageBox.Show("First name, Family name, gender, mobile no, Date of birth are mandory!.");
                }
            }
            else
            {
                if (firstnamemh.Text != "" && familynamemh.Text != "" && gendermh.Text != "" && mobilenomh.Text != "")
                {
                    try
                    {
                        MainClass.con.Open(); // Open the connection to the database

                        // Prepare an SQL query to insert a new record into the MedicalHistory table
                        SqlCommand cmd = new SqlCommand("INSERT INTO MedicalHistory (FileNo, Status, Smoking, BloodType, Firstname, Familyname) " +
                                                        "VALUES (@FileNo, @Status, @Smoking, @BloodType, @Firstname, @Familyname)", MainClass.con);

                        cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Smoking", smoking); // Replace smokingValue with the actual value
                        cmd.Parameters.AddWithValue("@BloodType", bloodtype); // Replace bloodTypeValue with the actual value
                        cmd.Parameters.AddWithValue("@Firstname", firstnamemh.Text); // Replace firstnameValue with the actual value
                        cmd.Parameters.AddWithValue("@Familyname", familynamemh.Text); // Replace familynameValue with the actual value

                        cmd.ExecuteNonQuery();

                        // Close the connection to the database
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (coordinates.Count != 0)
                        {
                            MainClass.con.Open();
                            foreach (var item in coordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO DiseaseHistory (FileNo, rowindex, colindex, data) " +
                                                             "VALUES (@FileNo, @rowindex, @colindex, @data)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue); // Replace fileNoValue with the actual value.
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@data", item.value); // Replace data with the actual value.

                                cmd.ExecuteNonQuery();
                            }



                            //MessageBox.Show("Disease history data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Allegiescoordinates.Count != 0)
                        {
                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.

                            foreach (var item in Allegiescoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO FoodAllergies (FileNo, rowindex, colindex, data) " +
                                                             "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            //MessageBox.Show("Food allergy data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Deficiencycoordinates.Count != 0)
                        {
                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.

                            foreach (var item in Deficiencycoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Deficiency (FileNo, rowindex, colindex, data) " +
                                                            "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            //MessageBox.Show("Food allergy data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Medicationcoordinates.Count != 0)
                        {
                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.

                            foreach (var item in Medicationcoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Medication (FileNo, rowindex, colindex, data) " +
                                                            "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            //MessageBox.Show("Food allergy data added successfully");
                            MainClass.con.Close();
                        }
                        // Update the UI with the new data
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        if (Dietcoordinates.Count != 0)
                        {


                            MainClass.con.Open();

                            // Replace fileNoValue with the actual value.


                            foreach (var item in Dietcoordinates)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Diet (FileNo, rowindex, colindex, data) " +
                                                            "VALUES (@FileNo, @rowindex, @colindex, @allergen)", MainClass.con);

                                // Get the actual file number from your application logic.
                                cmd.Parameters.AddWithValue("@FileNo", fileNoValue);
                                cmd.Parameters.AddWithValue("@rowindex", item.row); // Replace rowIndex with the actual value.
                                cmd.Parameters.AddWithValue("@colindex", item.col); // Replace colIndex with the actual value.
                                cmd.Parameters.AddWithValue("@allergen", item.value); // Replace allergen with the actual value.

                                cmd.ExecuteNonQuery();
                            }

                            MainClass.con.Close();

                            // Update the UI with the new data
                        }
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }


                    try
                    {
                        int check1 = 0;
                        int check2 = 0;
                        int check3 = 0;
                        int check4 = 0;
                        int check5 = 0;
                        int check6 = 0;
                        MainClass.con.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO Questions (FileNo, hormonalDisease, cancer, immuneDisease, hereditaryDisease, pancreaticDisease, otherDisease, hormonalDiseaseText, cancerText, immuneDiseaseText, hereditaryDiseaseText, pancreaticDiseaseText, otherDiseaseText) " +
                                                        "VALUES (@FileNo, @hormonalDisease, @cancer, @immuneDisease, @hereditaryDisease, @pancreaticDisease, @otherDisease, @hormonalDiseaseText, @cancerText, @immuneDiseaseText, @hereditaryDiseaseText, @pancreaticDiseaseText, @otherDiseaseText)", MainClass.con);

                        // Get the actual file number from your application logic and assign it to the @FileNo parameter
                        cmd.Parameters.AddWithValue("@FileNo", fileNoValue); // Replace fileNoValue with the actual value

                        foreach (var item in Questions)
                        {
                            if (item.TableName == "guna2DataGridView7")
                            {
                                check1 = 1;
                                cmd.Parameters.AddWithValue("@hormonalDisease", item.value);
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@hormonalDiseaseText", hd.Text); // Replace hormonalDiseaseTextValue with the actual value

                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@hormonalDiseaseText", "Nothing"); // Replace hormonalDiseaseTextValue with the actual value

                                }

                            }

                            if (item.TableName == "guna2DataGridView8")
                            {
                                check2 = 1;
                                cmd.Parameters.AddWithValue("@cancer", item.value);
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@cancerText", c.Text); // Replace cancerTextValue with the actual value

                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@cancerText", "Nothing"); // Replace cancerTextValue with the actual value

                                }

                            }

                            if (item.TableName == "guna2DataGridView9")
                            {
                                check3 = 1;
                                cmd.Parameters.AddWithValue("@immuneDisease", item.value); // Replace immuneDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@immuneDiseaseText", idbox.Text); // Replace immuneDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@immuneDiseaseText", "Nothing"); // Replace immuneDiseaseTextValue with the actual value

                                }
                            }

                            if (item.TableName == "guna2DataGridView10")
                            {
                                check4 = 1;
                                cmd.Parameters.AddWithValue("@hereditaryDisease", item.value); // Replace hereditaryDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@hereditaryDiseaseText", hed.Text); // Replace hereditaryDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@hereditaryDiseaseText", "Nothing"); // Replace hereditaryDiseaseTextValue with the actual value

                                }
                            }

                            if (item.TableName == "guna2DataGridView11")
                            {
                                check5 = 1;
                                cmd.Parameters.AddWithValue("@pancreaticDisease", item.value); // Replace pancreaticDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@pancreaticDiseaseText", pd.Text); // Replace pancreaticDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@pancreaticDiseaseText", "Nothing"); // Replace pancreaticDiseaseTextValue with the actual value

                                }
                            }

                            if (item.TableName == "guna2DataGridView12")
                            {
                                check6 = 1;
                                cmd.Parameters.AddWithValue("@otherDisease", item.value); // Replace otherDiseaseValue with the actual value
                                if (item.value == "Yes")
                                {
                                    cmd.Parameters.AddWithValue("@otherDiseaseText", od.Text); // Replace otherDiseaseTextValue with the actual value
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@otherDiseaseText", "Nothing"); // Replace otherDiseaseTextValue with the actual value

                                }
                            }


                        }
                        if (check1 == 0)
                        {
                            cmd.Parameters.AddWithValue("@hormonalDisease", "No");
                            cmd.Parameters.AddWithValue("@hormonalDiseaseText", "Nothing");
                        }
                        if (check2 == 0)
                        {
                            cmd.Parameters.AddWithValue("@cancer", "No");
                            cmd.Parameters.AddWithValue("@cancerText", "Nothing");
                        }
                        if (check3 == 0)
                        {
                            cmd.Parameters.AddWithValue("@immuneDisease", "No");
                            cmd.Parameters.AddWithValue("@immuneDiseaseText", "Nothing");
                        }
                        if (check4 == 0)
                        {
                            cmd.Parameters.AddWithValue("@hereditaryDisease", "No");
                            cmd.Parameters.AddWithValue("@hereditaryDiseaseText", "Nothing");
                        }
                        if (check5 == 0)
                        {
                            cmd.Parameters.AddWithValue("@pancreaticDisease", "No");
                            cmd.Parameters.AddWithValue("@pancreaticDiseaseText", "Nothing");
                        }
                        if (check6 == 0)
                        {
                            cmd.Parameters.AddWithValue("@otherDisease", "No");
                            cmd.Parameters.AddWithValue("@otherDiseaseText", "Nothing");
                        }

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Task completed successfully");
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    tabControl1.SelectedIndex = 0;
                    Clean();

                }

                else
                {
                    MessageBox.Show("First name, Family name, gender, mobile no, Date of birth are mandory!.");
                }
            }
        }

        static string status = "Nothing";
        static string smoking = "Nothing";
        static string bloodtype = "Nothing";
        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            status = guna2DataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        }

        private void guna2DataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            smoking = guna2DataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        }

        private void guna2DataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bloodtype = guna2DataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        }

        private void MedicalHistoryDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView17 != null)
            {
                if (guna2DataGridView17.Rows.Count > 0)
                {
                    if (guna2DataGridView17.SelectedRows.Count == 1)
                    {
                        // Get the CustomerID to display in the confirmation message
                        string customerIDToDelete = guna2DataGridView17.SelectedRows[0].Cells[0].Value.ToString();
                        string CurrentFileNo = guna2DataGridView17.SelectedRows[0].Cells[1].Value.ToString();
                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Medical History of Customer with FILE NO: " + CurrentFileNo + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from MedicalHistory where ID = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", guna2DataGridView17.CurrentRow.Cells[0].Value.ToString());
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from Diet where FILENO = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from Questions where FILENO = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from Medication where FILENO = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from Deficiency where FILENO = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from DiseaseHistory where FILENO = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("delete from FoodAllergies where FILENO = @CustomerID", MainClass.con);
                                cmd.Parameters.AddWithValue("@CustomerID", CurrentFileNo);
                                cmd.ExecuteNonQuery();

                                MainClass.con.Close();
                                MessageBox.Show("Medical history removed successfully");

                                //ShowCustomer(guna2DataGridView1, IDDGV, FILENODGV, firstnamedgv, familynamedgv, subscriptionstartdatedgv, subscriptionenddatedgv, nutritionistnamedgv);
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                            ShowMedicalHistory(guna2DataGridView17, idmhdgv, filenomhdgv, firstnamemhdgv, familynamemhdgv);

                        }
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void EditMedicalHistory_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView17.SelectedRows.Count > 0)
            {
                edit = 0;
                coordinates.Clear();
                Medicationcoordinates.Clear();
                Allegiescoordinates.Clear();
                Dietcoordinates.Clear();
                Deficiencycoordinates.Clear();
                Questions.Clear();
                //int id = int.Parse(guna2DataGridView17.SelectedRows[0].Cells[0].Value.ToString());
                try
                {
                    string customerIDToEdit = guna2DataGridView17.SelectedRows[0].Cells[0].Value.ToString();
                    string customerFilenoToEdit = guna2DataGridView17.SelectedRows[0].Cells[1].Value.ToString();
                    filenomh.Text = customerFilenoToEdit;
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM MedicalHistory WHERE ID = @CustomerID", MainClass.con);
                    cmd.Parameters.AddWithValue("@CustomerID", customerIDToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Set the retrieved data into input boxes

                            string dbstatus = reader["Status"].ToString();
                            string dbSmoking = reader["Smoking"].ToString();
                            string dbblood = reader["BloodType"].ToString();
                            status = dbstatus;
                            smoking = dbSmoking;
                            bloodtype = dbblood;
                            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(dbstatus))
                                    {
                                        cell.Selected = true;
                                        break; // Stop iterating through the cells once the matching cell is found
                                    }
                                }
                            }
                            foreach (DataGridViewRow row in guna2DataGridView4.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(dbSmoking))
                                    {
                                        cell.Selected = true;
                                        break; // Stop iterating through the cells once the matching cell is found
                                    }
                                }
                            }
                            foreach (DataGridViewRow row in guna2DataGridView5.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(dbblood))
                                    {
                                        cell.Selected = true;
                                        break; // Stop iterating through the cells once the matching cell is found
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Medical History not found for Customer with FILE NO : " + customerFilenoToEdit);
                    }
                    reader.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM DiseaseHistory WHERE FILENO = @CustomerID", MainClass.con);
                    cmd2.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    List<string> datas = new List<string>();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            // Set the retrieved data into input boxes

                            datas.Add(reader2["Data"].ToString());
                            Indexing SavedDisease = new Indexing();
                            SavedDisease.row = int.Parse(reader2["rowindex"].ToString());
                            SavedDisease.col = int.Parse(reader2["colindex"].ToString());
                            SavedDisease.value = reader2["Data"].ToString();
                            coordinates.Add(SavedDisease);

                        }
                        foreach (var item in datas)
                        {
                            foreach (DataGridViewRow row in guna2DataGridView6.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(item))
                                    {
                                        cell.Style.BackColor = Color.FromArgb(128, 255, 128);
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }

                    reader2.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd3 = new SqlCommand("SELECT * FROM FoodAllergies WHERE FILENO = @CustomerID", MainClass.con);
                    cmd3.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    List<string> Alergies = new List<string>();
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    if (reader3.HasRows)
                    {
                        while (reader3.Read())
                        {
                            // Set the retrieved data into input boxes

                            Alergies.Add(reader3["Data"].ToString());
                            Indexing SavedDisease = new Indexing();
                            SavedDisease.row = int.Parse(reader3["rowindex"].ToString());
                            SavedDisease.col = int.Parse(reader3["colindex"].ToString());
                            SavedDisease.value = reader3["Data"].ToString();
                            Allegiescoordinates.Add(SavedDisease);

                        }
                        foreach (var item in Alergies)
                        {
                            foreach (DataGridViewRow row in guna2DataGridView13.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(item))
                                    {
                                        cell.Style.BackColor = Color.FromArgb(128, 255, 128);
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }

                    reader3.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd4 = new SqlCommand("SELECT * FROM Deficiency WHERE FILENO = @CustomerID", MainClass.con);
                    cmd4.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    List<string> nutrients = new List<string>();
                    SqlDataReader reader4 = cmd4.ExecuteReader();
                    if (reader4.HasRows)
                    {
                        while (reader4.Read())
                        {
                            // Set the retrieved data into input boxes

                            nutrients.Add(reader4["Data"].ToString());
                            Indexing SavedDisease = new Indexing();
                            SavedDisease.row = int.Parse(reader4["rowindex"].ToString());
                            SavedDisease.col = int.Parse(reader4["colindex"].ToString());
                            SavedDisease.value = reader4["Data"].ToString();
                            Deficiencycoordinates.Add(SavedDisease);


                        }
                        foreach (var item in nutrients)
                        {
                            foreach (DataGridViewRow row in guna2DataGridView14.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(item))
                                    {
                                        cell.Style.BackColor = Color.FromArgb(128, 255, 128);
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }

                    reader4.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd5 = new SqlCommand("SELECT * FROM Medication WHERE FILENO = @CustomerID", MainClass.con);
                    cmd5.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    List<string> medicines = new List<string>();
                    SqlDataReader reader5 = cmd5.ExecuteReader();
                    if (reader5.HasRows)
                    {
                        while (reader5.Read())
                        {
                            // Set the retrieved data into input boxes

                            medicines.Add(reader5["Data"].ToString());
                            Indexing SavedDisease = new Indexing();
                            SavedDisease.row = int.Parse(reader5["rowindex"].ToString());
                            SavedDisease.col = int.Parse(reader5["colindex"].ToString());
                            SavedDisease.value = reader5["Data"].ToString();
                            Medicationcoordinates.Add(SavedDisease);


                        }
                        foreach (var item in medicines)
                        {
                            foreach (DataGridViewRow row in guna2DataGridView15.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(item))
                                    {
                                        cell.Style.BackColor = Color.FromArgb(128, 255, 128);
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }

                    reader5.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd6 = new SqlCommand("SELECT * FROM Diet WHERE FILENO = @CustomerID", MainClass.con);
                    cmd6.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    List<string> dietavoid = new List<string>();
                    SqlDataReader reader6 = cmd6.ExecuteReader();
                    if (reader6.HasRows)
                    {
                        while (reader6.Read())
                        {
                            // Set the retrieved data into input boxes

                            dietavoid.Add(reader6["Data"].ToString());
                            Indexing SavedDisease = new Indexing();
                            SavedDisease.row = int.Parse(reader6["rowindex"].ToString());
                            SavedDisease.col = int.Parse(reader6["colindex"].ToString());
                            SavedDisease.value = reader6["Data"].ToString();
                            Dietcoordinates.Add(SavedDisease);


                        }
                        foreach (var item in dietavoid)
                        {
                            foreach (DataGridViewRow row in guna2DataGridView16.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value.ToString().Equals(item))
                                    {
                                        cell.Style.BackColor = Color.FromArgb(128, 255, 128);
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }

                    reader6.Close();
                    MainClass.con.Close();

                    MainClass.con.Open();
                    SqlCommand cmd7 = new SqlCommand("SELECT * FROM Questions WHERE FILENO = @CustomerID", MainClass.con);
                    cmd7.Parameters.AddWithValue("@CustomerID", customerFilenoToEdit); // Replace 'customerIdToFind' with the actual ID you want to find.
                    SqlDataReader reader7 = cmd7.ExecuteReader();
                    if (reader7.HasRows)
                    {
                        while (reader7.Read())
                        {
                            // Set the retrieved data into input boxes

                            string hdans = reader7["hormonalDisease"].ToString();
                            string cans = reader7["cancer"].ToString();
                            string hians = reader7["immuneDisease"].ToString();
                            string hedans = reader7["hereditaryDisease"].ToString();
                            string pdans = reader7["pancreaticDisease"].ToString();
                            string odans = reader7["otherDisease"].ToString();

                            if (hdans == "Yes")
                            {
                                hd.Visible = true;
                                hd.Text = reader7["hormonalDiseaseText"].ToString();
                                guna2DataGridView7.Rows[0].Cells[1].Selected = true;

                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView7";
                                newitem.value = "Yes";
                                Questions.Add(newitem);

                            }
                            else if (hdans == "No")
                            {
                                hd.Visible = false;

                                guna2DataGridView7.Rows[0].Cells[0].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView7";
                                newitem.value = "No";
                                Questions.Add(newitem);

                            }

                            if (cans == "Yes")
                            {
                                c.Visible = true;
                                c.Text = reader7["cancerText"].ToString();
                                guna2DataGridView8.Rows[0].Cells[1].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView8";
                                newitem.value = "Yes";
                                Questions.Add(newitem);
                            }
                            else if (cans == "No")
                            {
                                c.Visible = false;

                                guna2DataGridView8.Rows[0].Cells[0].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView8";
                                newitem.value = "No";
                                Questions.Add(newitem);
                            }

                            if (hians == "Yes")
                            {
                                idbox.Visible = true;
                                idbox.Text = reader7["immuneDiseaseText"].ToString();
                                guna2DataGridView9.Rows[0].Cells[1].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView9";
                                newitem.value = "Yes";
                                Questions.Add(newitem);
                            }
                            else if (hians == "No")
                            {
                                idbox.Visible = false;

                                guna2DataGridView9.Rows[0].Cells[0].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView9";
                                newitem.value = "No";
                                Questions.Add(newitem);
                            }

                            if (hedans == "Yes")
                            {
                                hed.Visible = true;
                                hed.Text = reader7["hereditaryDiseaseText"].ToString();
                                guna2DataGridView10.Rows[0].Cells[1].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView10";
                                newitem.value = "Yes";
                                Questions.Add(newitem);
                            }
                            else if (hedans == "No")
                            {
                                hed.Visible = false;

                                guna2DataGridView10.Rows[0].Cells[0].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView10";
                                newitem.value = "No";
                                Questions.Add(newitem);
                            }

                            if (pdans == "Yes")
                            {
                                pd.Visible = true;
                                pd.Text = reader7["pancreaticDiseaseText"].ToString();
                                guna2DataGridView11.Rows[0].Cells[1].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView11";
                                newitem.value = "Yes";
                                Questions.Add(newitem);
                            }
                            else if (pdans == "No")
                            {
                                pd.Visible = false;

                                guna2DataGridView11.Rows[0].Cells[0].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView11";
                                newitem.value = "No";
                                Questions.Add(newitem);
                            }

                            if (odans == "Yes")
                            {
                                od.Visible = true;
                                od.Text = reader7["otherDiseaseText"].ToString();
                                guna2DataGridView12.Rows[0].Cells[1].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView12";
                                newitem.value = "Yes";
                                Questions.Add(newitem);
                            }
                            else if (odans == "No")
                            {
                                od.Visible = false;

                                guna2DataGridView12.Rows[0].Cells[0].Selected = true;
                                IndexingQuestions newitem = new IndexingQuestions();
                                newitem.TableName = "guna2DataGridView12";
                                newitem.value = "No";
                                Questions.Add(newitem);
                            }

                        }

                    }

                    reader7.Close();
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }

                tabControl1.SelectedIndex = 3;
            }
            else
            {
                MessageBox.Show("Please select a row in the table.");
            }

        }

        private void Reset_Click(object sender, EventArgs e)
        {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bodycompositionbtn_Click(object sender, EventArgs e)
        {
            if (fileno.Text == "")
            {
                filenobmi.Text = "";
                firstnamebmi.Text = "";
                familynamebmi.Text = "";
                mobilenobmi.Text = "";
                genderbmi.SelectedItem = null;
                agebmi.Text = "";
                nutritionistbmi.Text = "";
            }

            ShowBodyCompositionAll(guna2DataGridView2, idbc, datebc, bcabc, heightbc, weightbc, agebc, fatsbc, proteinbc, waterbc, mineralsbc, visceralfatsbc, abdominalfatsbc, bmibc, bmrbc);
            tabControl1.SelectedIndex = 1;
            edit = 0;
        }

        private void medicalhistoryBTN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            if (fileno.Text == "")
            {
                filenomh.Text = "";
                firstnamemh.Text = "";
                familynamemh.Text = "";
                agemh.Text = "";
                mobilenomh.Text = "";
                nutritionistmh.Text = "";
                gendermh.SelectedItem = null;
            }
            ShowMedicalHistoryAll(guna2DataGridView17, idmhdgv, filenomhdgv, firstnamemhdgv, familynamemhdgv);
            guna2DataGridView17.ClearSelection();
            edit = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exportbc_Click(object sender, EventArgs e)
        {
            ExportBCToExcel();
        }

        private void ExportMH_Click(object sender, EventArgs e)
        {
            ExportMHToExcel();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditBTN.PerformClick();
        }
    }
}
