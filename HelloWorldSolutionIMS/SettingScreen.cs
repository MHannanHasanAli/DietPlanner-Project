using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static HelloWorldSolutionIMS.MealAction;
using Svg;
using Win32Interop.Enums;
using System.Runtime.ConstrainedExecution;
using Win32Interop.Structs;

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


                    NutritionistInfo Temp = new NutritionistInfo { ID = Id, Name = Name};
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
        }
        private void SettingScreen_Load(object sender, EventArgs e)
        {
            //ShowUsers(Datagridview1, NameGV, UsernameGV, PasswordGV, RoleGV);
            //cboRole.SelectedIndex = 0;
            Start();
            MainClass.HideAllTabsOnTabControl(tabControl1);
            tabControl1.SelectedIndex = 2;
            
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
                if(edit == 1)
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
                            SqlCommand cmd = new SqlCommand("update Users set Name = @Name, @Password = @Password, Role = @Role where Username = @Username" ,MainClass.con);
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
            if(Datagridview1 != null)
            {
                if(Datagridview1.Rows.Count > 0)
                {
                    if(Datagridview1.SelectedRows.Count == 1)
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
                        MessageBox.Show("Please Locate The Backup File", "Error",MessageBoxButtons.OK);
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

                if(dialog.ShowDialog() == DialogResult.OK) 
                {
                    logolocation = dialog.FileName;
                     pictureBox1.ImageLocation = logolocation;
                }
            }
            catch(Exception ex)
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

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap)pictureBox2.Image;
            Color clr = pixelData.GetPixel(e.X, e.Y);
            showpanel.BackColor = clr;
        }

        static Color color;
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap)pictureBox2.Image;
            Color clr = pixelData.GetPixel(e.X, e.Y);
            selectedpanel.BackColor = clr;
            color = clr;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            showpanel.BackColor = Color.White;
        }

        private void Apply_Click(object sender, EventArgs e)
        {
           

           

            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE SideBarColor SET Color = @color WHERE Id = @colorId", MainClass.con);

                cmd.Parameters.AddWithValue("@colorId", 1);
                cmd.Parameters.AddWithValue("@color", ColorTranslator.ToHtml(color));

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
    }
}
