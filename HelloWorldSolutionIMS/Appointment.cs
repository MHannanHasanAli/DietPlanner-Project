using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HelloWorldSolutionIMS
{
    public partial class Appointment : Form
    {
        static int ClientID;
        static int coderunner = 0;
        public Appointment()
        {
            InitializeComponent();
        }
        public Appointment(int id)
        {
            ClientID = id;
            InitializeComponent();
            LoadData(ClientID);
            coderunner = 1;
        }

        private void LoadData(int file_no)
        {
            Room1.ClearSelection();
            Room1.CurrentCell = null;
            Room2.ClearSelection();
            Room2.CurrentCell = null;
            Room3.ClearSelection();
            Room3.CurrentCell = null;
            Room4.ClearSelection();
            Room4.CurrentCell = null;
            edit = 1;
            stopper = 1;
            check = 1;

            DateTime datefiller = DateTime.Now;
            try
            {

                slot.Visible = true;
                slotlabel.Visible = true;
                AppointmentIDToEdit = file_no;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Appointment WHERE FILENO = @appointmentID", MainClass.con);
                cmd.Parameters.AddWithValue("@appointmentID", AppointmentIDToEdit);
                MainClass.con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fileno.Text = reader["FILENO"].ToString();
                        firstname.Text = reader["FIRSTNAME"].ToString();
                        familyname.Text = reader["FAMILYNAME"].ToString();
                        mobileno.Text = reader["MOBILENO"].ToString();
                        datefiller = Convert.ToDateTime(reader["DATE"]);
                        slot.Text = reader["SLOT"].ToString();

                        tabControl1.SelectedIndex = 1; // Switch to the desired tab
                    }
                }
                else
                {
                    MessageBox.Show("Appointment data not found with FILENO: " + AppointmentIDToEdit);
                }

                reader.Close();
                MainClass.con.Close();
                date.SetDate(datefiller);
                slotupdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static int edit = 0;
        static int conn = 0;
        static int check = 0;
        static int stopper = 0;
        static int AppointmentIDToEdit;
        private void ShowAppointments(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn fileno, DataGridViewColumn firstname, DataGridViewColumn familyname, DataGridViewColumn mobile, DataGridViewColumn room, DataGridViewColumn slot, DataGridViewColumn date)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT Id, Fileno, Firstname, Familyname, Room, Slot, Date, MOBILENO FROM Appointment", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                id.DataPropertyName = dt.Columns["Id"].ColumnName;
                fileno.DataPropertyName = dt.Columns["Fileno"].ColumnName;
                firstname.DataPropertyName = dt.Columns["Firstname"].ColumnName;
                familyname.DataPropertyName = dt.Columns["Familyname"].ColumnName;
                room.DataPropertyName = dt.Columns["Room"].ColumnName;
                slot.DataPropertyName = dt.Columns["Slot"].ColumnName;
                date.DataPropertyName = dt.Columns["Date"].ColumnName;
                mobile.DataPropertyName = dt.Columns["MOBILENO"].ColumnName;
                dgv.DataSource = dt;
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

                cmd = new SqlCommand("SELECT Room1,Room2,Room3,Room4 FROM SETTINGS", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    room1label.Text = dr["Room1"].ToString();
                    room2label.Text = dr["Room2"].ToString();
                    room3label.Text = dr["Room3"].ToString();
                    room4label.Text = dr["Room4"].ToString();
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
        private void SearchAppointments(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn fileno, DataGridViewColumn firstname, DataGridViewColumn familyname, DataGridViewColumn mobile, DataGridViewColumn room, DataGridViewColumn slot, DataGridViewColumn date)
        {
            string file_no = filenosearch.Text;
            string searchname = firstnamesearch.Text;
            if (file_no != "" && searchname != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, FileNo, FirstName, FamilyName, Date, Room, Slot, MOBILENO FROM Appointment WHERE FileNo LIKE @FileNo AND FirstName LIKE @FirstName", MainClass.con);

                    cmd.Parameters.AddWithValue("@FileNo", "%" + file_no + "%");
                    cmd.Parameters.AddWithValue("@FirstName", "%" + searchname + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    id.DataPropertyName = dt.Columns["ID"].ToString();
                    fileno.DataPropertyName = dt.Columns["FileNo"].ToString();
                    firstname.DataPropertyName = dt.Columns["FirstName"].ToString();
                    familyname.DataPropertyName = dt.Columns["FamilyName"].ToString();
                    room.DataPropertyName = dt.Columns["Room"].ToString();
                    slot.DataPropertyName = dt.Columns["Slot"].ToString();
                    date.DataPropertyName = dt.Columns["Date"].ToString();
                    mobile.DataPropertyName = dt.Columns["MOBILENO"].ColumnName;


                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }

                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (file_no == "" && searchname != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, FileNo, FirstName, FamilyName, Date, Room, Slot, MOBILENO FROM Appointment WHERE FirstName LIKE @FirstName", MainClass.con);

                    cmd.Parameters.AddWithValue("@FileNo", "%" + file_no + "%");
                    cmd.Parameters.AddWithValue("@FirstName", "%" + searchname + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    id.DataPropertyName = dt.Columns["ID"].ToString();
                    fileno.DataPropertyName = dt.Columns["FileNo"].ToString();
                    firstname.DataPropertyName = dt.Columns["FirstName"].ToString();
                    familyname.DataPropertyName = dt.Columns["FamilyName"].ToString();
                    room.DataPropertyName = dt.Columns["Room"].ToString();
                    slot.DataPropertyName = dt.Columns["Slot"].ToString();
                    date.DataPropertyName = dt.Columns["Date"].ToString();
                    mobile.DataPropertyName = dt.Columns["MOBILENO"].ColumnName;

                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }

                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (file_no != "" && searchname == "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID, FileNo, FirstName, FamilyName, Date, Room, Slot, MOBILENO FROM Appointment WHERE FileNo LIKE @FileNo", MainClass.con);

                    cmd.Parameters.AddWithValue("@FileNo", "%" + file_no + "%");
                    cmd.Parameters.AddWithValue("@FirstName", "%" + searchname + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    id.DataPropertyName = dt.Columns["ID"].ToString();
                    fileno.DataPropertyName = dt.Columns["FileNo"].ToString();
                    firstname.DataPropertyName = dt.Columns["FirstName"].ToString();
                    familyname.DataPropertyName = dt.Columns["FamilyName"].ToString();
                    room.DataPropertyName = dt.Columns["Room"].ToString();
                    slot.DataPropertyName = dt.Columns["Slot"].ToString();
                    date.DataPropertyName = dt.Columns["Date"].ToString();
                    mobile.DataPropertyName = dt.Columns["MOBILENO"].ColumnName;

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
                ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
                MessageBox.Show("Fill File No or First Name");
            }
        }
        private void InsertColumnsAndRowsToRoom1(Guna2DataGridView Room1)
        {

            // Insert 4 columns without headers
            for (int i = 1; i <= 4; i++)
            {
                Room1.Columns.Add("Column" + i, "");
            }

            // Insert 14 rows
            for (int i = 0; i < 13; i++)
            {
                Room1.Rows.Add();
            }
            Room1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            Room1.GridColor = Color.Black;
            Room1.RowTemplate.DefaultCellStyle.SelectionBackColor = Room1.RowTemplate.DefaultCellStyle.BackColor;
            Room1.RowTemplate.DefaultCellStyle.SelectionForeColor = Room1.RowTemplate.DefaultCellStyle.ForeColor;
            DateTime startTime = DateTime.Today.AddHours(7); // Starting time at 7:00 AM        
            DateTime endTime = DateTime.Today.AddHours(20).AddMinutes(45);
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < 4; i++)
                {

                    if (startTime <= endTime)
                    {
                        Room1.Rows[j].Cells[i].Value = startTime.ToString("HH:mm");
                        startTime = startTime.AddMinutes(15);
                    }

                }
            }

            Room1.ClearSelection();
            Room1.CurrentCell = null;
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
        private void InsertColumnsAndRowsToRoom2(Guna2DataGridView Room2)
        {
            // Insert 4 columns without headers
            for (int i = 1; i <= 4; i++)
            {
                Room2.Columns.Add("Column" + i, "");
            }

            // Insert 14 rows
            for (int i = 0; i < 13; i++)
            {
                Room2.Rows.Add();
            }
            Room2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            Room2.GridColor = Color.Black;
            Room2.RowTemplate.DefaultCellStyle.SelectionBackColor = Room2.RowTemplate.DefaultCellStyle.BackColor;
            Room2.RowTemplate.DefaultCellStyle.SelectionForeColor = Room2.RowTemplate.DefaultCellStyle.ForeColor;
            DateTime startTime = DateTime.Today.AddHours(7); // Starting time at 7:00 AM        
            DateTime endTime = DateTime.Today.AddHours(20).AddMinutes(45);
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < 4; i++)
                {

                    if (startTime <= endTime)
                    {
                        Room2.Rows[j].Cells[i].Value = startTime.ToString("HH:mm");
                        startTime = startTime.AddMinutes(15);
                    }

                }
            }
            Room2.ClearSelection();
            Room2.CurrentCell = null;
        }
        private void InsertColumnsAndRowsToRoom3(Guna2DataGridView Room3)
        {
            // Insert 4 columns without headers
            for (int i = 1; i <= 4; i++)
            {
                Room3.Columns.Add("Column" + i, "");
            }

            // Insert 14 rows
            for (int i = 0; i < 13; i++)
            {
                Room3.Rows.Add();
            }
            Room3.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            Room3.GridColor = Color.Black;
            Room3.RowTemplate.DefaultCellStyle.SelectionBackColor = Room3.RowTemplate.DefaultCellStyle.BackColor;
            Room3.RowTemplate.DefaultCellStyle.SelectionForeColor = Room3.RowTemplate.DefaultCellStyle.ForeColor;
            DateTime startTime = DateTime.Today.AddHours(7); // Starting time at 7:00 AM        
            DateTime endTime = DateTime.Today.AddHours(20).AddMinutes(45);
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < 4; i++)
                {

                    if (startTime <= endTime)
                    {
                        Room3.Rows[j].Cells[i].Value = startTime.ToString("HH:mm");
                        startTime = startTime.AddMinutes(15);
                    }

                }
            }
            Room3.ClearSelection();
            Room3.CurrentCell = null;
        }
        private void InsertColumnsAndRowsToRoom4(Guna2DataGridView Room4)
        {
            // Insert 4 columns without headers
            for (int i = 1; i <= 4; i++)
            {
                Room4.Columns.Add("Column" + i, "");
            }

            // Insert 14 rows
            for (int i = 0; i < 13; i++)
            {
                Room4.Rows.Add();
            }
            Room4.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            Room4.GridColor = Color.Black;
            Room4.RowTemplate.DefaultCellStyle.SelectionBackColor = Room4.RowTemplate.DefaultCellStyle.BackColor;
            Room4.RowTemplate.DefaultCellStyle.SelectionForeColor = Room4.RowTemplate.DefaultCellStyle.ForeColor;
            DateTime startTime = DateTime.Today.AddHours(7); // Starting time at 7:00 AM        
            DateTime endTime = DateTime.Today.AddHours(20).AddMinutes(45);
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < 4; i++)
                {

                    if (startTime <= endTime)
                    {
                        Room4.Rows[j].Cells[i].Value = startTime.ToString("HH:mm");
                        startTime = startTime.AddMinutes(15);
                    }

                }
            }
            Room4.ClearSelection();
            Room4.CurrentCell = null;
        }
        private (int RowIndex, int ColumnIndex, int RoomNo, string time) GetSelectedCellIndexes(Guna2DataGridView Room)
        {
            int rowIndex = -1;
            int columnIndex = -1;
            int roomno = 0;
            string timeselected = "none";
            if (Room.CurrentCell != null)
            {
                rowIndex = Room.CurrentCell.RowIndex;
                columnIndex = Room.CurrentCell.ColumnIndex;
            }

            if (rowIndex != -1 && columnIndex != -1)
            {
                timeselected = Room.Rows[rowIndex].Cells[columnIndex].Value.ToString();

            }


            if (Room.Name == "Room1")
            {
                roomno = 1;
            }
            else if (Room.Name == "Room2")
            {
                roomno = 2;
            }
            else if (Room.Name == "Room3")
            {
                roomno = 3;
            }
            else
            {
                roomno = 4;
            }
            return (rowIndex, columnIndex, roomno, timeselected);
        }
        private void ChangeCellColor(Guna2DataGridView Room, int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && rowIndex < Room.RowCount && columnIndex >= 0 && columnIndex < Room.ColumnCount)
            {
                Room.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Red;
            }
        }
        private void Appointment_Load(object sender, EventArgs e)
        {
            LanguageInfo();
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




                }

                reader.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);

            }
            MainClass.HideAllTabsOnTabControl(tabControl1);
            if (coderunner == 0)
            {
                InsertColumnsAndRowsToRoom1(Room1);
                InsertColumnsAndRowsToRoom2(Room2);
                InsertColumnsAndRowsToRoom3(Room3);
                InsertColumnsAndRowsToRoom4(Room4);
            }
            coderunner = 1;

            ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guna2DataGridView1.GridColor = Color.Black;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.BackColor;
            guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = guna2DataGridView1.RowTemplate.DefaultCellStyle.ForeColor;

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

                    // Create Color object from the read components
                    Color color = Color.FromArgb(red, green, blue);

                    guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = color;

                }

                reader.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);

            }

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
            }

        }
        private void Save_Click(object sender, EventArgs e)
        {
            int intersection = checkselection();
            if (intersection == 0)
            {
                int totalValidSelections = 0;

                var selectedCellIndexesRoom1 = GetSelectedCellIndexes(Room1);
                var selectedCellIndexesRoom2 = GetSelectedCellIndexes(Room2);
                var selectedCellIndexesRoom3 = GetSelectedCellIndexes(Room3);
                var selectedCellIndexesRoom4 = GetSelectedCellIndexes(Room4);

                if (selectedCellIndexesRoom1.RowIndex != -1) totalValidSelections++;
                if (selectedCellIndexesRoom2.RowIndex != -1) totalValidSelections++;
                if (selectedCellIndexesRoom3.RowIndex != -1) totalValidSelections++;
                if (selectedCellIndexesRoom4.RowIndex != -1) totalValidSelections++;

                if (totalValidSelections > 1)
                {
                    MessageBox.Show("More than one table has a selected cell.");
                }
                else
                {
                    if (edit == 0)
                    {
                        if (firstname.Text != "" || familyname.Text != "" || mobileno.Text != "")
                        {
                            if (selectedCellIndexesRoom1.RowIndex != -1)
                            {
                                try
                                {
                                    MainClass.con.Open();
                                    foreach (var item in ForRoom1)
                                    {
                                        SqlCommand cmd = new SqlCommand("INSERT INTO Appointment (Fileno, Firstname, Familyname, Mobileno, Date, Room, RowIndex, ColumnIndex, Slot) " +
                                       "VALUES (@Fileno, @Firstname, @Familyname, @Mobileno, @Date, @Room, @RowIndex, @ColumnIndex, @Slot)", MainClass.con);

                                        string fname = firstname.Text;
                                        string lname = familyname.Text;
                                        cmd.Parameters.AddWithValue("@Fileno", fileno.Text); // Assuming 'fileno' is a control related to 'Fileno' in the database
                                        cmd.Parameters.AddWithValue("@Firstname", fname);
                                        cmd.Parameters.AddWithValue("@Familyname", lname);
                                        cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                        cmd.Parameters.AddWithValue("@Date", date.SelectionStart); // Assuming it's the current date
                                        cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom1.RoomNo); // Assuming 'room' is a control related to 'Room' in the database
                                        cmd.Parameters.AddWithValue("@RowIndex", item.rowindex); // Assuming 'rowIndex' is a control related to 'RowIndex' in the database
                                        cmd.Parameters.AddWithValue("@ColumnIndex", item.colindex); // Assuming 'columnIndex' is a control related to 'ColumnIndex' in the database
                                        cmd.Parameters.AddWithValue("@Slot", item.Time); // Assuming 'slot' is a control related to 'Slot' in the database

                                        cmd.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Appointment added successfully");
                                    MainClass.con.Close();

                                    // Clear the text fields after successful insertion
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                    date.SetDate(DateTime.Today);

                                    // Switch to the first tab of your tab control
                                    tabControl1.SelectedIndex = 0;

                                    // Refresh the DataGridView (if it displays the Appointment data)
                                    ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else if (selectedCellIndexesRoom2.RowIndex != -1)
                            {
                                try
                                {
                                    MainClass.con.Open();
                                    foreach (var item in ForRoom2)
                                    {
                                        SqlCommand cmd = new SqlCommand("INSERT INTO Appointment (Fileno, Firstname, Familyname, Mobileno, Date, Room, RowIndex, ColumnIndex, Slot) " +
                                        "VALUES (@Fileno, @Firstname, @Familyname, @Mobileno, @Date, @Room, @RowIndex, @ColumnIndex, @Slot)", MainClass.con);

                                        cmd.Parameters.AddWithValue("@Fileno", fileno.Text); // Assuming 'fileno' is a control related to 'Fileno' in the database
                                        cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                        cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                        cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                        cmd.Parameters.AddWithValue("@Date", date.SelectionStart); // Assuming it's the current date
                                        cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom2.RoomNo); // Assuming 'room' is a control related to 'Room' in the database
                                        cmd.Parameters.AddWithValue("@RowIndex", item.rowindex); // Assuming 'rowIndex' is a control related to 'RowIndex' in the database
                                        cmd.Parameters.AddWithValue("@ColumnIndex", item.colindex); // Assuming 'columnIndex' is a control related to 'ColumnIndex' in the database
                                        cmd.Parameters.AddWithValue("@Slot", item.Time); // Assuming 'slot' is a control related to 'Slot' in the database

                                        cmd.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Appointment added successfully");
                                    MainClass.con.Close();

                                    // Clear the text fields after successful insertion
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                    date.SetDate(DateTime.Today);

                                    // Switch to the first tab of your tab control
                                    tabControl1.SelectedIndex = 0;

                                    // Refresh the DataGridView (if it displays the Appointment data)
                                    ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else if (selectedCellIndexesRoom3.RowIndex != -1)
                            {
                                try
                                {
                                    MainClass.con.Open();
                                    foreach (var item in ForRoom3)
                                    {
                                        SqlCommand cmd = new SqlCommand("INSERT INTO Appointment (Fileno, Firstname, Familyname, Mobileno, Date, Room, RowIndex, ColumnIndex, Slot) " +
                                        "VALUES (@Fileno, @Firstname, @Familyname, @Mobileno, @Date, @Room, @RowIndex, @ColumnIndex, @Slot)", MainClass.con);

                                        cmd.Parameters.AddWithValue("@Fileno", fileno.Text); // Assuming 'fileno' is a control related to 'Fileno' in the database
                                        cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                        cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                        cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                        cmd.Parameters.AddWithValue("@Date", date.SelectionStart); // Assuming it's the current date
                                        cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom3.RoomNo); // Assuming 'room' is a control related to 'Room' in the database
                                        cmd.Parameters.AddWithValue("@RowIndex", item.rowindex); // Assuming 'rowIndex' is a control related to 'RowIndex' in the database
                                        cmd.Parameters.AddWithValue("@ColumnIndex", item.colindex); // Assuming 'columnIndex' is a control related to 'ColumnIndex' in the database
                                        cmd.Parameters.AddWithValue("@Slot", item.Time); // Assuming 'slot' is a control related to 'Slot' in the database

                                        cmd.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Appointment added successfully");
                                    MainClass.con.Close();

                                    // Clear the text fields after successful insertion
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                    date.SetDate(DateTime.Today);

                                    // Switch to the first tab of your tab control
                                    tabControl1.SelectedIndex = 0;

                                    // Refresh the DataGridView (if it displays the Appointment data)
                                    ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    MainClass.con.Open();
                                    foreach (var item in ForRoom4)
                                    {
                                        SqlCommand cmd = new SqlCommand("INSERT INTO Appointment (Fileno, Firstname, Familyname, Mobileno, Date, Room, RowIndex, ColumnIndex, Slot) " +
                                        "VALUES (@Fileno, @Firstname, @Familyname, @Mobileno, @Date, @Room, @RowIndex, @ColumnIndex, @Slot)", MainClass.con);

                                        cmd.Parameters.AddWithValue("@Fileno", fileno.Text); // Assuming 'fileno' is a control related to 'Fileno' in the database
                                        cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                        cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                        cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                        cmd.Parameters.AddWithValue("@Date", date.SelectionStart); // Assuming it's the current date
                                        cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom4.RoomNo); // Assuming 'room' is a control related to 'Room' in the database
                                        cmd.Parameters.AddWithValue("@RowIndex", item.rowindex); // Assuming 'rowIndex' is a control related to 'RowIndex' in the database
                                        cmd.Parameters.AddWithValue("@ColumnIndex", item.colindex); // Assuming 'columnIndex' is a control related to 'ColumnIndex' in the database
                                        cmd.Parameters.AddWithValue("@Slot", item.Time); // Assuming 'slot' is a control related to 'Slot' in the database

                                        cmd.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Appointment added successfully");
                                    MainClass.con.Close();

                                    // Clear the text fields after successful insertion
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                    date.SetDate(DateTime.Today);

                                    // Switch to the first tab of your tab control
                                    tabControl1.SelectedIndex = 0;

                                    // Refresh the DataGridView (if it displays the Appointment data)
                                    ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please fill First name, Family name and Mobile No.");
                        }
                    }
                    else
                    {

                        if (firstname.Text != "" || familyname.Text != "" || mobileno.Text != "")
                        {
                            if (selectedCellIndexesRoom1.RowIndex != -1)
                            {
                                try
                                {
                                    MainClass.con.Open();

                                    SqlCommand cmd = new SqlCommand("UPDATE Appointment SET Fileno = @Fileno, Firstname = @Firstname, Familyname = @Familyname, Mobileno = @Mobileno, Date = @Date, Room = @Room, RowIndex = @RowIndex, ColumnIndex = @ColumnIndex, Slot = @Slot WHERE ID = @AppointmentID", MainClass.con);

                                    cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                                    cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                    cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                    cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                    cmd.Parameters.AddWithValue("@Date", date.SelectionStart);
                                    cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom1.RoomNo);
                                    cmd.Parameters.AddWithValue("@RowIndex", selectedCellIndexesRoom1.RowIndex);
                                    cmd.Parameters.AddWithValue("@ColumnIndex", selectedCellIndexesRoom1.ColumnIndex);
                                    cmd.Parameters.AddWithValue("@Slot", selectedCellIndexesRoom1.time);
                                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentIDToEdit);

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Appointment updated successfully");
                                    MainClass.con.Close();
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                                ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);

                            }
                            else if (selectedCellIndexesRoom2.RowIndex != -1)
                            {
                                try
                                {
                                    MainClass.con.Open();

                                    SqlCommand cmd = new SqlCommand("UPDATE Appointment SET Fileno = @Fileno, Firstname = @Firstname, Familyname = @Familyname, Mobileno = @Mobileno, Date = @Date, Room = @Room, RowIndex = @RowIndex, ColumnIndex = @ColumnIndex, Slot = @Slot WHERE ID = @AppointmentID", MainClass.con);

                                    cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                                    cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                    cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                    cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                    cmd.Parameters.AddWithValue("@Date", date.SelectionStart);
                                    cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom2.RoomNo);
                                    cmd.Parameters.AddWithValue("@RowIndex", selectedCellIndexesRoom2.RowIndex);
                                    cmd.Parameters.AddWithValue("@ColumnIndex", selectedCellIndexesRoom2.ColumnIndex);
                                    cmd.Parameters.AddWithValue("@Slot", selectedCellIndexesRoom2.time);
                                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentIDToEdit);

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Appointment updated successfully");
                                    MainClass.con.Close();
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                                ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);

                            }
                            else if (selectedCellIndexesRoom3.RowIndex != -1)
                            {
                                try
                                {
                                    MainClass.con.Open();

                                    SqlCommand cmd = new SqlCommand("UPDATE Appointment SET Fileno = @Fileno, Firstname = @Firstname, Familyname = @Familyname, Mobileno = @Mobileno, Date = @Date, Room = @Room, RowIndex = @RowIndex, ColumnIndex = @ColumnIndex, Slot = @Slot WHERE ID = @AppointmentID", MainClass.con);

                                    cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                                    cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                    cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                    cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                    cmd.Parameters.AddWithValue("@Date", date.SelectionStart);
                                    cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom3.RoomNo);
                                    cmd.Parameters.AddWithValue("@RowIndex", selectedCellIndexesRoom3.RowIndex);
                                    cmd.Parameters.AddWithValue("@ColumnIndex", selectedCellIndexesRoom3.ColumnIndex);
                                    cmd.Parameters.AddWithValue("@Slot", selectedCellIndexesRoom3.time);
                                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentIDToEdit);

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Appointment updated successfully");
                                    MainClass.con.Close();
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                                ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);

                            }
                            else
                            {
                                try
                                {
                                    MainClass.con.Open();

                                    SqlCommand cmd = new SqlCommand("UPDATE Appointment SET Fileno = @Fileno, Firstname = @Firstname, Familyname = @Familyname, Mobileno = @Mobileno, Date = @Date, Room = @Room, RowIndex = @RowIndex, ColumnIndex = @ColumnIndex, Slot = @Slot WHERE ID = @AppointmentID", MainClass.con);

                                    cmd.Parameters.AddWithValue("@Fileno", fileno.Text);
                                    cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                                    cmd.Parameters.AddWithValue("@Familyname", familyname.Text);
                                    cmd.Parameters.AddWithValue("@Mobileno", mobileno.Text);
                                    cmd.Parameters.AddWithValue("@Date", date.SelectionStart);
                                    cmd.Parameters.AddWithValue("@Room", selectedCellIndexesRoom4.RoomNo);
                                    cmd.Parameters.AddWithValue("@RowIndex", selectedCellIndexesRoom4.RowIndex);
                                    cmd.Parameters.AddWithValue("@ColumnIndex", selectedCellIndexesRoom4.ColumnIndex);
                                    cmd.Parameters.AddWithValue("@Slot", selectedCellIndexesRoom4.time);
                                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentIDToEdit);

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Appointment updated successfully");
                                    MainClass.con.Close();
                                    fileno.Text = "";
                                    firstname.Text = "";
                                    familyname.Text = "";
                                    mobileno.Text = "";
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }
                                ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Please fill First name, Family name and Mobile No.");
                        }

                    }
                    tabControl1.SelectedIndex = 0;
                    slot.Visible = false;
                    slotlabel.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Appointment for this day and time is already booked!");
            }

            ForRoom1.Clear();
            ForRoom2.Clear();
            ForRoom3.Clear();
            ForRoom4.Clear();
            for (int i = 0; i < Room1.Rows.Count; i++)
            {
                for (int j = 0; j < Room1.Columns.Count; j++)
                {
                    Room1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < Room2.Rows.Count; i++)
            {
                for (int j = 0; j < Room2.Columns.Count; j++)
                {
                    Room2.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < Room3.Rows.Count; i++)
            {
                for (int j = 0; j < Room3.Columns.Count; j++)
                {
                    Room3.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room3.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < Room4.Rows.Count; i++)
            {
                for (int j = 0; j < Room4.Columns.Count; j++)
                {
                    Room4.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room4.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            Room1.ClearSelection();
            Room1.CurrentCell = null;
            Room2.ClearSelection();
            Room2.CurrentCell = null;
            Room3.ClearSelection();
            Room3.CurrentCell = null;
            Room4.ClearSelection();
            Room4.CurrentCell = null;
            ForRoom1.Clear();
            ForRoom2.Clear();
            ForRoom3.Clear();
            ForRoom4.Clear();
            for (int i = 0; i < Room1.Rows.Count; i++)
            {
                for (int j = 0; j < Room1.Columns.Count; j++)
                {
                    if (Room1.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room2.Rows.Count; i++)
            {
                for (int j = 0; j < Room2.Columns.Count; j++)
                {
                    if (Room2.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room2.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room3.Rows.Count; i++)
            {
                for (int j = 0; j < Room3.Columns.Count; j++)
                {
                    if (Room3.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room3.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room3.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room4.Rows.Count; i++)
            {
                for (int j = 0; j < Room4.Columns.Count; j++)
                {
                    if (Room4.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room4.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room4.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
        }
        private void mobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true; // Ignore the keypress if it's not a number, a control character, or a plus sign
            }
        }
        private void fileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }
        private void fileno_TextChanged(object sender, EventArgs e)
        {
            if (stopper == 0)
            {
                if (fileno.Text != "")
                {
                    int value = int.Parse(fileno.Text);

                    try
                    {
                        if (MainClass.con.State != ConnectionState.Open)
                        {
                            MainClass.con.Open();
                            conn = 1;
                        }

                        SqlCommand cmd2 = new SqlCommand("SELECT  FIRSTNAME, FAMILYNAME, MOBILENO, GENDER, AGE FROM CUSTOMER " +
                            "WHERE FILENO = @fileno", MainClass.con);

                        cmd2.Parameters.AddWithValue("@fileno", value);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            // Assign values from the reader to the respective text boxes
                            firstname.Text = reader2["FIRSTNAME"].ToString();
                            familyname.Text = reader2["FAMILYNAME"].ToString();
                            mobileno.Text = reader2["MOBILENO"].ToString();
                            date.SetDate(DateTime.Today);
                        }
                        else
                        {
                            MessageBox.Show("No customer with this file no exist!");
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
                else
                {
                    firstname.Text = "";
                    familyname.Text = "";
                    mobileno.Text = "";
                    date.SetDate(DateTime.Today);
                }
            }

            stopper = 0;
        }
        private int checkselection()
        {
            var selectedCellIndexesRoom1 = GetSelectedCellIndexes(Room1);
            var selectedCellIndexesRoom2 = GetSelectedCellIndexes(Room2);
            var selectedCellIndexesRoom3 = GetSelectedCellIndexes(Room3);
            var selectedCellIndexesRoom4 = GetSelectedCellIndexes(Room4);

            int modifier = 0;

            if (selectedCellIndexesRoom1.RowIndex != -1)
            {

                SqlCommand cmdforRoom1;

                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    DateTime selectedDate = date.SelectionStart;

                    cmdforRoom1 = new SqlCommand("SELECT Room, RowIndex, ColumnIndex FROM Appointment WHERE CONVERT(date, Date) = @SelectedDate", MainClass.con);
                    cmdforRoom1.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    SqlDataReader reader = cmdforRoom1.ExecuteReader();

                    while (reader.Read())
                    {

                        int roomNo = int.Parse(reader["Room"].ToString());
                        int row = int.Parse(reader["RowIndex"].ToString());
                        int column = int.Parse(reader["ColumnIndex"].ToString());

                        if (selectedCellIndexesRoom1.RoomNo == roomNo && selectedCellIndexesRoom1.RowIndex == row && selectedCellIndexesRoom1.ColumnIndex == column)
                        {
                            modifier++;
                        }

                    }

                    reader.Close();
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
            if (selectedCellIndexesRoom2.RowIndex != -1)
            {
                SqlCommand cmdforRoom2;

                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    DateTime selectedDate = date.SelectionStart;

                    cmdforRoom2 = new SqlCommand("SELECT Room, RowIndex, ColumnIndex FROM Appointment WHERE CONVERT(date, Date) = @SelectedDate", MainClass.con);
                    cmdforRoom2.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    SqlDataReader reader = cmdforRoom2.ExecuteReader();

                    while (reader.Read())
                    {

                        int roomNo = int.Parse(reader["Room"].ToString());
                        int row = int.Parse(reader["RowIndex"].ToString());
                        int column = int.Parse(reader["ColumnIndex"].ToString());

                        if (selectedCellIndexesRoom2.RoomNo == roomNo && selectedCellIndexesRoom2.RowIndex == row && selectedCellIndexesRoom2.ColumnIndex == column)
                        {
                            modifier++;
                        }

                    }

                    reader.Close();
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
            if (selectedCellIndexesRoom3.RowIndex != -1)
            {
                SqlCommand cmdforRoom3;

                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    DateTime selectedDate = date.SelectionStart;

                    cmdforRoom3 = new SqlCommand("SELECT Room, RowIndex, ColumnIndex FROM Appointment WHERE CONVERT(date, Date) = @SelectedDate", MainClass.con);
                    cmdforRoom3.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    SqlDataReader reader = cmdforRoom3.ExecuteReader();

                    while (reader.Read())
                    {

                        int roomNo = int.Parse(reader["Room"].ToString());
                        int row = int.Parse(reader["RowIndex"].ToString());
                        int column = int.Parse(reader["ColumnIndex"].ToString());

                        if (selectedCellIndexesRoom3.RoomNo == roomNo && selectedCellIndexesRoom3.RowIndex == row && selectedCellIndexesRoom3.ColumnIndex == column)
                        {
                            modifier++;
                        }

                    }

                    reader.Close();
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
            if (selectedCellIndexesRoom4.RowIndex != -1)
            {
                SqlCommand cmdforRoom4;

                try
                {
                    if (MainClass.con.State != ConnectionState.Open)
                    {
                        MainClass.con.Open();
                        conn = 1;
                    }

                    DateTime selectedDate = date.SelectionStart;

                    cmdforRoom4 = new SqlCommand("SELECT Room, RowIndex, ColumnIndex FROM Appointment WHERE CONVERT(date, Date) = @SelectedDate", MainClass.con);
                    cmdforRoom4.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    SqlDataReader reader = cmdforRoom4.ExecuteReader();

                    while (reader.Read())
                    {

                        int roomNo = int.Parse(reader["Room"].ToString());
                        int row = int.Parse(reader["RowIndex"].ToString());
                        int column = int.Parse(reader["ColumnIndex"].ToString());

                        if (selectedCellIndexesRoom4.RoomNo == roomNo && selectedCellIndexesRoom4.RowIndex == row && selectedCellIndexesRoom4.ColumnIndex == column)
                        {
                            modifier++;
                        }

                    }

                    reader.Close();
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

            return modifier;
        }
        private void slotupdate()
        {
            int empty = 0;
            SqlCommand cmd;
            Room1.Rows.Clear();
            Room1.Columns.Clear();
            Room2.Rows.Clear();
            Room2.Columns.Clear();
            Room3.Rows.Clear();
            Room3.Columns.Clear();
            Room4.Rows.Clear();
            Room4.Columns.Clear();
            InsertColumnsAndRowsToRoom1(Room1);
            InsertColumnsAndRowsToRoom2(Room2);
            InsertColumnsAndRowsToRoom3(Room3);
            InsertColumnsAndRowsToRoom4(Room4);
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                DateTime selectedDate = date.SelectionStart;

                cmd = new SqlCommand("SELECT Room, RowIndex, ColumnIndex FROM Appointment WHERE CONVERT(date, Date) = @SelectedDate", MainClass.con);
                cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int roomNo = int.Parse(reader["Room"].ToString());
                    int row = int.Parse(reader["RowIndex"].ToString());
                    int column = int.Parse(reader["ColumnIndex"].ToString());

                    if (roomNo == 1)
                    {
                        ChangeCellColor(Room1, row, column);
                        empty++;
                    }
                    else if (roomNo == 2)
                    {
                        ChangeCellColor(Room2, row, column);
                        empty++;
                    }
                    else if (roomNo == 3)
                    {
                        ChangeCellColor(Room3, row, column);
                        empty++;
                    }
                    else if (roomNo == 4)
                    {
                        ChangeCellColor(Room4, row, column);
                        empty++;
                    }

                }


                if (conn == 1)
                {
                    MainClass.con.Close();
                    conn = 0;
                }
                if (empty == 0)
                {
                    Room1.Rows.Clear();
                    Room1.Columns.Clear();
                    Room2.Rows.Clear();
                    Room2.Columns.Clear();
                    Room3.Rows.Clear();
                    Room3.Columns.Clear();
                    Room4.Rows.Clear();
                    Room4.Columns.Clear();
                    InsertColumnsAndRowsToRoom1(Room1);
                    InsertColumnsAndRowsToRoom2(Room2);
                    InsertColumnsAndRowsToRoom3(Room3);
                    InsertColumnsAndRowsToRoom4(Room4);
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void date_DateChanged(object sender, DateRangeEventArgs e)
        {
            slotupdate();
        }
        private void New_Click(object sender, EventArgs e)
        {
            fileno.Text = "";
            firstname.Text = "";
            familyname.Text = "";
            mobileno.Text = "";
            edit = 0;
            tabControl1.SelectedIndex = 1;
            slotupdate();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1) // Changed from SelectedRows to SelectedCells
                    {
                        // Clear the text boxes
                        fileno.Text = "";
                        firstname.Text = "";
                        familyname.Text = "";
                        mobileno.Text = "";


                        string appointmentIDToDelete = guna2DataGridView1.CurrentRow.Cells["iddgv"].Value.ToString(); // Assuming the Appointment ID is in a column named "Id"

                        DialogResult result = MessageBox.Show("Are you sure you want to delete Appointment: " + appointmentIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Appointment WHERE Id = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", guna2DataGridView1.CurrentRow.Cells["iddgv"].Value.ToString()); // Assuming the Appointment ID is in a column named "Id"
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Appointment removed successfully");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
                                ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
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
        private void viewEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Room1.ClearSelection();
            Room1.CurrentCell = null;
            Room2.ClearSelection();
            Room2.CurrentCell = null;
            Room3.ClearSelection();
            Room3.CurrentCell = null;
            Room4.ClearSelection();
            Room4.CurrentCell = null;
            edit = 1;
            stopper = 1;
            check = 1;

            DateTime datefiller = DateTime.Now;
            try
            {

                slot.Visible = true;
                slotlabel.Visible = true;
                AppointmentIDToEdit = int.Parse(guna2DataGridView1.CurrentRow.Cells["Iddgv"].Value.ToString()); // Assuming the ID is in a column named "Id"

                SqlCommand cmd = new SqlCommand("SELECT * FROM Appointment WHERE Id = @appointmentID", MainClass.con);
                cmd.Parameters.AddWithValue("@appointmentID", AppointmentIDToEdit);
                MainClass.con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fileno.Text = reader["FILENO"].ToString();
                        firstname.Text = reader["FIRSTNAME"].ToString();
                        familyname.Text = reader["FAMILYNAME"].ToString();
                        mobileno.Text = reader["MOBILENO"].ToString();
                        datefiller = Convert.ToDateTime(reader["DATE"]);
                        slot.Text = reader["SLOT"].ToString();

                        tabControl1.SelectedIndex = 1; // Switch to the desired tab
                    }
                }
                else
                {
                    MessageBox.Show("Appointment data not found with ID: " + AppointmentIDToEdit);
                }

                reader.Close();
                MainClass.con.Close();
                date.SetDate(datefiller);
                slotupdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            slot.Visible = false;
            slotlabel.Visible = false;
            ForRoom1.Clear();
            ForRoom2.Clear();
            ForRoom3.Clear();
            ForRoom4.Clear();
            for (int i = 0; i < Room1.Rows.Count; i++)
            {
                for (int j = 0; j < Room1.Columns.Count; j++)
                {
                    Room1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < Room2.Rows.Count; i++)
            {
                for (int j = 0; j < Room2.Columns.Count; j++)
                {
                    Room2.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < Room3.Rows.Count; i++)
            {
                for (int j = 0; j < Room3.Columns.Count; j++)
                {
                    Room3.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room3.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < Room4.Rows.Count; i++)
            {
                for (int j = 0; j < Room4.Columns.Count; j++)
                {
                    Room4.Rows[i].Cells[j].Style.BackColor = Color.White;
                    Room4.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            SearchAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            Room1.ClearSelection();
            Room1.CurrentCell = null;
            Room2.ClearSelection();
            Room2.CurrentCell = null;
            Room3.ClearSelection();
            Room3.CurrentCell = null;
            Room4.ClearSelection();
            Room4.CurrentCell = null;
            edit = 1;
            stopper = 1;
            check = 1;

            DateTime datefiller = DateTime.Now;
            try
            {

                slot.Visible = true;
                slotlabel.Visible = true;
                AppointmentIDToEdit = int.Parse(guna2DataGridView1.SelectedRows[0].Cells["Iddgv"].Value.ToString()); // Assuming the ID is in a column named "Id"

                SqlCommand cmd = new SqlCommand("SELECT * FROM Appointment WHERE Id = @appointmentID", MainClass.con);
                cmd.Parameters.AddWithValue("@appointmentID", AppointmentIDToEdit);
                MainClass.con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fileno.Text = reader["FILENO"].ToString();
                        firstname.Text = reader["FIRSTNAME"].ToString();
                        familyname.Text = reader["FAMILYNAME"].ToString();
                        mobileno.Text = reader["MOBILENO"].ToString();
                        datefiller = Convert.ToDateTime(reader["DATE"]);
                        slot.Text = reader["SLOT"].ToString();

                        tabControl1.SelectedIndex = 1; // Switch to the desired tab
                    }
                }
                else
                {
                    MessageBox.Show("Appointment data not found with ID: " + AppointmentIDToEdit);
                }

                reader.Close();
                MainClass.con.Close();
                date.SetDate(datefiller);
                slotupdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1) // Changed from SelectedRows to SelectedCells
                    {
                        // Clear the text boxes
                        fileno.Text = "";
                        firstname.Text = "";
                        familyname.Text = "";
                        mobileno.Text = "";


                        string appointmentIDToDelete = guna2DataGridView1.SelectedRows[0].Cells["iddgv"].Value.ToString(); // Assuming the Appointment ID is in a column named "Id"

                        DialogResult result = MessageBox.Show("Are you sure you want to delete Appointment: " + appointmentIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Appointment WHERE Id = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", guna2DataGridView1.CurrentRow.Cells["iddgv"].Value.ToString()); // Assuming the Appointment ID is in a column named "Id"
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Appointment removed successfully");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
                                ShowAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public class Index
        {
            public string Time { get; set; }
            public int rowindex { get; set; }
            public int colindex { get; set; }
        }
        List<Index> ForRoom1 = new List<Index>();
        List<Index> ForRoom2 = new List<Index>();
        List<Index> ForRoom3 = new List<Index>();
        List<Index> ForRoom4 = new List<Index>();
        private void Room1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Room2.ClearSelection();
            Room2.CurrentCell = null;
            Room3.ClearSelection();
            Room3.CurrentCell = null;
            Room4.ClearSelection();
            Room4.CurrentCell = null;
            ForRoom2.Clear();
            ForRoom3.Clear();
            ForRoom4.Clear();
            for (int i = 0; i < Room2.Rows.Count; i++)
            {
                for (int j = 0; j < Room2.Columns.Count; j++)
                {
                    if (Room2.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room2.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room3.Rows.Count; i++)
            {
                for (int j = 0; j < Room3.Columns.Count; j++)
                {
                    if (Room3.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room3.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room3.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room4.Rows.Count; i++)
            {
                for (int j = 0; j < Room4.Columns.Count; j++)
                {
                    if (Room4.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room4.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room4.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            Index timeselected = new Index();
            timeselected.colindex = e.ColumnIndex;
            timeselected.rowindex = e.RowIndex;
            timeselected.Time = Room1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in ForRoom1)
            {
                if (item.rowindex == timeselected.rowindex && item.colindex == timeselected.colindex)
                {
                    ForRoom1.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                ForRoom1.Add(timeselected);
            }
            Room1.ClearSelection();
            for (int i = 0; i < Room1.Rows.Count; i++)
            {
                for (int j = 0; j < Room1.Columns.Count; j++)
                {
                    if (Room1.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }

            foreach (var item in ForRoom1)
            {
                Room1.Rows[item.rowindex].Cells[item.colindex].Style.BackColor = Color.FromArgb(128, 255, 128);
                Room1.Rows[item.rowindex].Cells[item.colindex].Style.ForeColor = Color.Black;

            }
        }

        private void Room2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Room1.ClearSelection();
            Room1.CurrentCell = null;
            Room3.ClearSelection();
            Room3.CurrentCell = null;
            Room4.ClearSelection();
            Room4.CurrentCell = null;
            ForRoom1.Clear();
            ForRoom3.Clear();
            ForRoom4.Clear();
            for (int i = 0; i < Room1.Rows.Count; i++)
            {
                for (int j = 0; j < Room1.Columns.Count; j++)
                {
                    if (Room1.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room3.Rows.Count; i++)
            {
                for (int j = 0; j < Room3.Columns.Count; j++)
                {
                    if (Room3.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room3.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room3.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room4.Rows.Count; i++)
            {
                for (int j = 0; j < Room4.Columns.Count; j++)
                {
                    if (Room4.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room4.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room4.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            Index timeselected = new Index();
            timeselected.colindex = e.ColumnIndex;
            timeselected.rowindex = e.RowIndex;
            timeselected.Time = Room2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in ForRoom2)
            {
                if (item.rowindex == timeselected.rowindex && item.colindex == timeselected.colindex)
                {
                    ForRoom2.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                ForRoom2.Add(timeselected);
            }
            Room2.ClearSelection();
            for (int i = 0; i < Room2.Rows.Count; i++)
            {
                for (int j = 0; j < Room2.Columns.Count; j++)
                {
                    if (Room2.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room2.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }

            foreach (var item in ForRoom2)
            {
                Room2.Rows[item.rowindex].Cells[item.colindex].Style.BackColor = Color.FromArgb(128, 255, 128);
                Room2.Rows[item.rowindex].Cells[item.colindex].Style.ForeColor = Color.Black;

            }
        }

        private void Room3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Room1.ClearSelection();
            Room1.CurrentCell = null;
            Room2.ClearSelection();
            Room2.CurrentCell = null;
            Room4.ClearSelection();
            Room4.CurrentCell = null;
            ForRoom2.Clear();
            ForRoom1.Clear();
            ForRoom4.Clear();
            for (int i = 0; i < Room1.Rows.Count; i++)
            {

                for (int j = 0; j < Room1.Columns.Count; j++)
                {
                    if (Room1.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room2.Rows.Count; i++)
            {
                for (int j = 0; j < Room2.Columns.Count; j++)
                {
                    if (Room2.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room2.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room4.Rows.Count; i++)
            {
                for (int j = 0; j < Room4.Columns.Count; j++)
                {
                    if (Room4.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room4.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room4.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            Index timeselected = new Index();
            timeselected.colindex = e.ColumnIndex;
            timeselected.rowindex = e.RowIndex;
            timeselected.Time = Room3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in ForRoom3)
            {
                if (item.rowindex == timeselected.rowindex && item.colindex == timeselected.colindex)
                {
                    ForRoom3.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                ForRoom3.Add(timeselected);
            }
            Room3.ClearSelection();
            for (int i = 0; i < Room3.Rows.Count; i++)
            {
                for (int j = 0; j < Room3.Columns.Count; j++)
                {
                    if (Room3.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room3.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room3.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }

            foreach (var item in ForRoom3)
            {
                Room3.Rows[item.rowindex].Cells[item.colindex].Style.BackColor = Color.FromArgb(128, 255, 128);
                Room3.Rows[item.rowindex].Cells[item.colindex].Style.ForeColor = Color.Black;

            }
        }

        private void Room4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Room1.ClearSelection();
            Room1.CurrentCell = null;
            Room2.ClearSelection();
            Room2.CurrentCell = null;
            Room3.ClearSelection();
            Room3.CurrentCell = null;
            ForRoom2.Clear();
            ForRoom3.Clear();
            ForRoom1.Clear();
            for (int i = 0; i < Room1.Rows.Count; i++)
            {
                for (int j = 0; j < Room1.Columns.Count; j++)
                {
                    if (Room1.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room2.Rows.Count; i++)
            {
                for (int j = 0; j < Room2.Columns.Count; j++)
                {
                    if (Room2.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room2.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            for (int i = 0; i < Room3.Rows.Count; i++)
            {
                for (int j = 0; j < Room3.Columns.Count; j++)
                {
                    if (Room3.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room3.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room3.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }

            Index timeselected = new Index();
            timeselected.colindex = e.ColumnIndex;
            timeselected.rowindex = e.RowIndex;
            timeselected.Time = Room4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int checker = 0;
            foreach (var item in ForRoom4)
            {
                if (item.rowindex == timeselected.rowindex && item.colindex == timeselected.colindex)
                {
                    ForRoom4.Remove(item);
                    checker = 1;
                    break;
                }
            }

            if (checker == 0)
            {
                ForRoom4.Add(timeselected);
            }
            Room4.ClearSelection();
            for (int i = 0; i < Room4.Rows.Count; i++)
            {
                for (int j = 0; j < Room4.Columns.Count; j++)
                {
                    if (Room4.Rows[i].Cells[j].Style.BackColor != Color.Red)
                    {
                        Room4.Rows[i].Cells[j].Style.BackColor = Color.White;
                        Room4.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }

            foreach (var item in ForRoom4)
            {
                Room4.Rows[item.rowindex].Cells[item.colindex].Style.BackColor = Color.FromArgb(128, 255, 128);
                Room4.Rows[item.rowindex].Cells[item.colindex].Style.ForeColor = Color.Black;

            }
        }
        private void SearchAppointmentsWithDate(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn fileno, DataGridViewColumn firstname, DataGridViewColumn familyname, DataGridViewColumn mobile, DataGridViewColumn room, DataGridViewColumn slot, DataGridViewColumn date)
        {
            var SelectedDate = CalendarFilter.SelectionStart;

            try
            {
                MainClass.con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID, FileNo, FirstName, FamilyName, Date, Room, Slot, MOBILENO FROM Appointment WHERE CONVERT(date, Date) = @SelectedDate", MainClass.con);

                cmd.Parameters.AddWithValue("@SelectedDate", SelectedDate);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                id.DataPropertyName = dt.Columns["ID"].ToString();
                fileno.DataPropertyName = dt.Columns["FileNo"].ToString();
                firstname.DataPropertyName = dt.Columns["FirstName"].ToString();
                familyname.DataPropertyName = dt.Columns["FamilyName"].ToString();
                room.DataPropertyName = dt.Columns["Room"].ToString();
                slot.DataPropertyName = dt.Columns["Slot"].ToString();
                date.DataPropertyName = dt.Columns["Date"].ToString();
                mobile.DataPropertyName = dt.Columns["MOBILENO"].ColumnName;


                dgv.DataSource = dt;
                MainClass.con.Close();
            }

            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }
        private void CalendarFilter_DateChanged(object sender, DateRangeEventArgs e)
        {

            SearchAppointmentsWithDate(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditBTN.PerformClick();
        }

        private void filenosearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchAppointments(guna2DataGridView1, iddgv, filenodgv, firstnamedgv, familynamedgv, mobilenodgv, roomdgv, slotdgv, datedgv);
            }
        }
    }
}

