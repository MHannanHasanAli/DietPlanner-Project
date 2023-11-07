using Guna.UI2.WinForms;
using Svg;
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
using static HelloWorldSolutionIMS.MealAction;
using Win32Interop.Enums;
using System.Drawing.Printing;
using Fizzler;

namespace HelloWorldSolutionIMS
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        static int edit = 0;
        static string PaymentIDToEdit;
       
        public class Deal
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }
        private void updatepromotions()
        {
            SqlCommand cmd;
            try
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                    conn = 1;
                }

                cmd = new SqlCommand("SELECT ID, PromotionName FROM SPECIALDEALS WHERE GETDATE() BETWEEN Startdate AND Enddate", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Clear the dropdown items before adding new ones
                promotionname.DataSource = null;

                // Clear the items (if DataSource is not being set)
                promotionname.Items.Clear();

                List<Deal> deals = new List<Deal>();

                // Add the default 'Null' option
                deals.Add(new Deal { ID = 0, Name = "Null" });

                foreach (DataRow row in dt.Rows)
                {
                    int promotionId = row.Field<int>("ID");
                    string promotionName = row.Field<string>("PromotionName");

                    Deal deal = new Deal { ID = promotionId, Name = promotionName };
                    deals.Add(deal);
                }

                promotionname.DataSource = deals;
                promotionname.DisplayMember = "Name"; // Display Member is Name
                promotionname.ValueMember = "ID"; // Value Member is ID

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
        private void ShowPayments(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn no, DataGridViewColumn pay, DataGridViewColumn first, DataGridViewColumn family, DataGridViewColumn amount, DataGridViewColumn amountpro, DataGridViewColumn promopercent, DataGridViewColumn date)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT ID,FILENO, FIRSTNAME, FAMILYNAME, PAYMENTNAME, AMOUNT, AMOUNTAFTERPROMOTION, PROMOTIONPERCENTAGE, STARTDATE FROM Payment", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                id.DataPropertyName = dt.Columns["ID"].ToString();
                no.DataPropertyName = dt.Columns["FILENO"].ToString();
                pay.DataPropertyName = dt.Columns["PAYMENTNAME"].ToString();
                first.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                family.DataPropertyName = dt.Columns["FAMILYNAME"].ToString();
                amount.DataPropertyName = dt.Columns["AMOUNT"].ToString();
                amountpro.DataPropertyName = dt.Columns["AMOUNTAFTERPROMOTION"].ToString();
                promopercent.DataPropertyName = dt.Columns["PROMOTIONPERCENTAGE"].ToString();
                date.DataPropertyName = dt.Columns["STARTDATE"].ToString();
               


                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchPayments(DataGridView dgv, DataGridViewColumn id, DataGridViewColumn no, DataGridViewColumn pay, DataGridViewColumn first, DataGridViewColumn family, DataGridViewColumn amount, DataGridViewColumn amountpro, DataGridViewColumn promopercent, DataGridViewColumn date)
        {
            string ingredientName = filenosearch.Text;
            string groupArName = firstnamesearch.Text;

            if (ingredientName != "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID,FILENO, FIRSTNAME, FAMILYNAME, PAYMENTNAME, AMOUNT, AMOUNTAFTERPROMOTION, PROMOTIONPERCENTAGE, STARTDATE FROM Payment " +
                        "WHERE (FILENO LIKE @IngredientName) AND (FIRSTNAME LIKE @GroupArName)", MainClass.con);

                    cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");
                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    id.DataPropertyName = dt.Columns["ID"].ToString();
                    no.DataPropertyName = dt.Columns["FILENO"].ToString();
                    pay.DataPropertyName = dt.Columns["PAYMENTNAME"].ToString();
                    first.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                    family.DataPropertyName = dt.Columns["FAMILYNAME"].ToString();
                    amount.DataPropertyName = dt.Columns["AMOUNT"].ToString();
                    amountpro.DataPropertyName = dt.Columns["AMOUNTAFTERPROMOTION"].ToString();
                    promopercent.DataPropertyName = dt.Columns["PROMOTIONPERCENTAGE"].ToString();
                    date.DataPropertyName = dt.Columns["STARTDATE"].ToString();




                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (ingredientName == "" && groupArName != "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID,FILENO, FIRSTNAME, FAMILYNAME, PAYMENTNAME, AMOUNT, AMOUNTAFTERPROMOTION, PROMOTIONPERCENTAGE, STARTDATE FROM Payment " +
                        "WHERE FIRSTNAME LIKE @GroupArName", MainClass.con);

                    cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    id.DataPropertyName = dt.Columns["ID"].ToString();
                    no.DataPropertyName = dt.Columns["FILENO"].ToString();
                    pay.DataPropertyName = dt.Columns["PAYMENTNAME"].ToString();
                    first.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                    family.DataPropertyName = dt.Columns["FAMILYNAME"].ToString();
                    amount.DataPropertyName = dt.Columns["AMOUNT"].ToString();
                    amountpro.DataPropertyName = dt.Columns["AMOUNTAFTERPROMOTION"].ToString();
                    promopercent.DataPropertyName = dt.Columns["PROMOTIONPERCENTAGE"].ToString();
                    date.DataPropertyName = dt.Columns["STARTDATE"].ToString();
                 



                    dgv.DataSource = dt;
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (ingredientName != "" && groupArName == "")
            {
                try
                {
                    MainClass.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID,FILENO, FIRSTNAME, FAMILYNAME, PAYMENTNAME, AMOUNT, AMOUNTAFTERPROMOTION, PROMOTIONPERCENTAGE, STARTDATE FROM Payment " +
                        "WHERE FILENO LIKE @IngredientName", MainClass.con);

                    cmd.Parameters.AddWithValue("@IngredientName", "%" + ingredientName + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    id.DataPropertyName = dt.Columns["ID"].ToString();
                    no.DataPropertyName = dt.Columns["FILENO"].ToString();
                    pay.DataPropertyName = dt.Columns["PAYMENTNAME"].ToString();
                    first.DataPropertyName = dt.Columns["FIRSTNAME"].ToString();
                    family.DataPropertyName = dt.Columns["FAMILYNAME"].ToString();
                    amount.DataPropertyName = dt.Columns["AMOUNT"].ToString();
                    amountpro.DataPropertyName = dt.Columns["AMOUNTAFTERPROMOTION"].ToString();
                    promopercent.DataPropertyName = dt.Columns["PROMOTIONPERCENTAGE"].ToString();
                    date.DataPropertyName = dt.Columns["STARTDATE"].ToString();




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
                ShowPayments(guna2DataGridView1,iddgv, filenodgv, paymentnamedgv, firstnamedgv, familynamedgv, amountdgv, amountaftrpromotiondgv, promotionpercentagedgv, datedgv);
                MessageBox.Show("Fill File No or First Name");
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (firstname.Text != "")
                {
                    try
                    {
                        if (MainClass.con.State != ConnectionState.Open)
                        {
                            MainClass.con.Open();
                            conn = 1;
                        }
                        SqlCommand cmd = new SqlCommand("INSERT INTO Payment (FileNo, FirstName, FamilyName, Gender, Age, MobileNo, PaymentName, Amount, Startdate, Enddate, AmountAfterPromotion, PromotionPercentage, PromotionCode, PromotionName, PromotionDetails) " +
      "VALUES (@FileNo, @FirstName, @FamilyName, @Gender, @Age, @MobileNo, @PaymentName, @Amount, @Startdate, @Enddate, @AmountAfterPromotion, @PromotionPercentage, @PromotionCode, @PromotionName, @PromotionDetails)", MainClass.con);

                        cmd.Parameters.AddWithValue("@FileNo", Convert.ToInt32(fileno.Text));
                        cmd.Parameters.AddWithValue("@FirstName", firstname.Text);
                        cmd.Parameters.AddWithValue("@FamilyName", familyname.Text);
                        cmd.Parameters.AddWithValue("@Gender", gender.Text);
                        cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(age.Text));
                        cmd.Parameters.AddWithValue("@MobileNo", mobileno.Text);
                        cmd.Parameters.AddWithValue("@PaymentName", paymentname.Text);
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToDouble(amount.Text));
                        cmd.Parameters.AddWithValue("@Startdate", DateTime.Parse(startdate.Text));
                        cmd.Parameters.AddWithValue("@Enddate", DateTime.Parse(enddate.Text));
                        cmd.Parameters.AddWithValue("@AmountAfterPromotion", Convert.ToDouble(amountafterpromotion.Text));
                        cmd.Parameters.AddWithValue("@PromotionPercentage", Convert.ToDouble(promotionpercentage.Text));
                        cmd.Parameters.AddWithValue("@PromotionCode", promotioncode.Text);
                        cmd.Parameters.AddWithValue("@PromotionName", promotionname.SelectedValue);
                        cmd.Parameters.AddWithValue("@PromotionDetails", promotiondetails.Text);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payment added successfully");

                        // Clear the input controls or set them to default values.
                        fileno.Text = "";
                        firstname.Text = "";
                        familyname.Text = "";
                        gender.SelectedItem = null;
                        age.Text = "";
                        mobileno.Text = "";
                        paymentname.Text = "";
                        amount.Text = "";
                        startdate.Text = "";
                        enddate.Text = "";
                        amountafterpromotion.Text = "";
                        promotionpercentage.Text = "";
                        promotioncode.Text = "";
                        promotionname.Text = "";
                        promotiondetails.Text = "";

                        if (conn == 1)
                        {
                            MainClass.con.Close();
                            conn = 0;
                        }

                        // Refresh the DataGridView to display the updated data.
                        // Replace the arguments with your actual DataGridView and column names.
                        ShowPayments(guna2DataGridView1, iddgv, filenodgv, paymentnamedgv, firstnamedgv, familynamedgv, amountdgv, amountaftrpromotiondgv, promotionpercentagedgv, datedgv);
                        tabControl1.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Customer Name cannot be empty.");
                }
            }
            else
            {
                if (firstname.Text != "")
                {
                    try
                    {
                        if (MainClass.con.State != ConnectionState.Open)
                        {
                            MainClass.con.Open();
                            conn = 1;
                        }
                        SqlCommand cmd = new SqlCommand("UPDATE Payment SET FirstName = @FirstName, FamilyName = @FamilyName, Gender = @Gender, Age = @Age, MobileNo = @MobileNo, PaymentName = @PaymentName, Amount = @Amount, Startdate = @StartDate, Enddate = @EndDate, AmountAfterPromotion = @AmountAfterPromotion, PromotionPercentage = @PromotionPercentage, PromotionCode = @PromotionCode, PromotionName = @PromotionName, PromotionDetails = @PromotionDetails WHERE ID = @ID AND FileNo = @FileNo", MainClass.con);

                        cmd.Parameters.AddWithValue("@ID", PaymentIDToEdit);
                        cmd.Parameters.AddWithValue("@FileNo", Convert.ToInt32(fileno.Text));
                        cmd.Parameters.AddWithValue("@FirstName", firstname.Text);
                        cmd.Parameters.AddWithValue("@FamilyName", familyname.Text);
                        cmd.Parameters.AddWithValue("@Gender", gender.Text);
                        cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(age.Text));
                        cmd.Parameters.AddWithValue("@MobileNo", mobileno.Text);
                        cmd.Parameters.AddWithValue("@PaymentName", paymentname.Text);
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToDouble(amount.Text));
                        cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(startdate.Text));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(enddate.Text));
                        cmd.Parameters.AddWithValue("@AmountAfterPromotion", Convert.ToDouble(amountafterpromotion.Text));
                        cmd.Parameters.AddWithValue("@PromotionPercentage", Convert.ToDouble(promotionpercentage.Text));
                        cmd.Parameters.AddWithValue("@PromotionCode", promotioncode.Text);
                        cmd.Parameters.AddWithValue("@PromotionName", promotionname.SelectedValue);
                        cmd.Parameters.AddWithValue("@PromotionDetails", promotiondetails.Text);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payment updated successfully");

                        // Clear the input controls or set them to default values.
                        fileno.Text = "";
                        firstname.Text = "";
                        familyname.Text = "";
                        gender.SelectedItem = null;
                        age.Text = "";
                        mobileno.Text = "";
                        paymentname.Text = "";
                        amount.Text = "";
                        startdate.Text = "";
                        enddate.Text = "";
                        amountafterpromotion.Text = "";
                        promotionpercentage.Text = "";
                        promotioncode.Text = "";
                        promotionname.Text = "";
                        promotiondetails.Text = "";

                        if (conn == 1)
                        {
                            MainClass.con.Close();
                            conn = 0;
                        }

                        // Refresh the DataGridView to display the updated data.
                        // Replace the arguments with your actual DataGridView and column names.
                        ShowPayments(guna2DataGridView1, iddgv, filenodgv, paymentnamedgv, firstnamedgv, familynamedgv, amountdgv, amountaftrpromotiondgv, promotionpercentagedgv, datedgv);
                        tabControl1.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Customer Name cannot be empty.");
                }
            }
            total();
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            MainClass.HideAllTabsOnTabControl(tabControl1);
            ShowPayments(guna2DataGridView1, iddgv, filenodgv, paymentnamedgv, firstnamedgv, familynamedgv, amountdgv, amountaftrpromotiondgv, promotionpercentagedgv, datedgv);
            total();
           
        }
        private void total()
        {
            decimal sum = 0;

            // Replace "guna2DataGridView1" with the actual name of your Guna2 DataGridView control
            Guna.UI2.WinForms.Guna2DataGridView dataGridView = guna2DataGridView1;

            // Replace "columnIndex" with the index of the column you want to sum (0-based index)
            int columnIndex = 5;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[columnIndex].Value != null)
                {
                    decimal cellValue;
                    if (decimal.TryParse(row.Cells[columnIndex].Value.ToString(), out cellValue))
                    {
                        sum += cellValue;
                    }
                }
            }

            // "sum" now contains the sum of values in the specified column

            // Assuming "sumLabel" is the name of your label control
            totalvalues.Text = "Amount Sum: " + sum + "/-";
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1 != null)
            {
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    if (guna2DataGridView1.SelectedRows.Count == 1)
                    {
                        fileno.Text = "";
                        firstname.Text = "";
                        familyname.Text = "";
                        gender.SelectedItem = null;
                        age.Text = "";
                        mobileno.Text = "";
                        paymentname.Text = "";
                        amount.Text = "";
                        startdate.Text = "";
                        enddate.Text = "";
                        amountafterpromotion.Text = "";
                        promotionpercentage.Text = "";
                        promotioncode.Text = "";
                        promotionname.Text = "";
                        promotiondetails.Text = "";

                        // Get the Ingredient ID to display in the confirmation message
                        string paymentIDToDelete = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString(); // Assuming the Ingredient ID is in the first cell of the selected row.

                        // Ask for confirmation
                        DialogResult result = MessageBox.Show("Are you sure you want to delete Payment : " + paymentIDToDelete + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd = new SqlCommand("DELETE FROM Payment WHERE ID = @ID", MainClass.con);
                                cmd.Parameters.AddWithValue("@ID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString()); // Assuming the Ingredient ID is in the first cell of the selected row.
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Payment removed successfully");
                                MainClass.con.Close();
                                // Refresh the data grid view with the updated data
                                ShowPayments(guna2DataGridView1, iddgv, filenodgv, paymentnamedgv, firstnamedgv, familynamedgv, amountdgv, amountaftrpromotiondgv, promotionpercentagedgv, datedgv);
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
        static string promotionName;
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            try
            {
                PaymentIDToEdit = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(); // Assuming the ID is in the first cell

                updatepromotions();
                SqlCommand cmd = new SqlCommand("SELECT FileNo,PaymentName,Amount,Startdate,Enddate,PromotionName FROM Payment WHERE ID = @paymentID", MainClass.con);
                    cmd.Parameters.AddWithValue("@paymentID", PaymentIDToEdit);
                MainClass.con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                         {
                             while (reader.Read())
                             {
                                 fileno.Text = reader["FileNo"].ToString();
                                 paymentname.Text = reader["PaymentName"].ToString();
                                 amount.Text = reader["Amount"].ToString();
                                 startdate.Text = reader["Startdate"].ToString();
                                 enddate.Text = reader["Enddate"].ToString();                       
                                 
                                 promotionName = reader["PromotionName"].ToString();

                        
                                 
                        
                        //promotiondetails.Text = reader["PromotionDetails"].ToString();

                        tabControl1.SelectedIndex = 1;
                             }
                }
                        else
                        {
                            MessageBox.Show("Payment data not found with ID: " + PaymentIDToEdit);
                        }
                reader.Close();
                updatewithfile();
                promotionname.SelectedValue = int.Parse(promotionName);
                MainClass.con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Backtomeal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            fileno.Text = "";
            firstname.Text = "";
            familyname.Text = "";
            gender.SelectedItem = null;
            age.Text = "";
            mobileno.Text = "";
            paymentname.Text = "";
            amount.Text = "";
            startdate.Text = "";
            enddate.Text = "";
            amountafterpromotion.Text = "";
            promotionpercentage.Text = "";
            promotioncode.Text = "";
            promotionname.Text = "";
            promotiondetails.Text = "";
            tabControl1.SelectedIndex = 1;
            check = 1;
            edit = 0;
            updatepromotions();
        }
        private void promotionpercentage_Leave(object sender, EventArgs e)
        {
            float percentage = float.Parse(promotionpercentage.Text);

            if (amount.Text != "")
            {
                int amountvalue = int.Parse(amount.Text);

                var amountupdate = amountvalue + ((percentage / 100.00) * amountvalue);

                amountafterpromotion.Text = amountupdate.ToString();
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            SearchPayments(guna2DataGridView1, iddgv, filenodgv, paymentnamedgv, firstnamedgv, familynamedgv, amountdgv, amountaftrpromotiondgv, promotionpercentagedgv, datedgv);
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void fileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
        }
        static int conn = 0;
        static int check = 0;
        private void updatewithfile()
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
                        gender.Text = reader2["GENDER"].ToString();
                        age.Text = reader2["AGE"].ToString();
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
                    reader2.Close();
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
                gender.SelectedItem = null;
                age.Text = "";

            }
        }
        private void fileno_TextChanged(object sender, EventArgs e)
        {
            if(check == 1)
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
                            gender.Text = reader2["GENDER"].ToString();
                            age.Text = reader2["AGE"].ToString();
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
                    gender.SelectedItem = null;
                    age.Text = "";

                }
                check = 0;
            }
           

        }
        private void promotionname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (promotionname.SelectedItem != null)
            {
                Deal selectedDeal = (Deal)promotionname.SelectedItem;
                int selectedID = selectedDeal.ID;

                if(selectedID == 0)
                {
                    promotioncode.Text = "";
                    promotionpercentage.Text = "";
                    promotiondetails.Text = "";
                }
                else
                {
                    try
                    {
                        if (MainClass.con.State != ConnectionState.Open)
                        {
                            MainClass.con.Open();
                            conn = 1;
                        }

                        SqlCommand cmd = new SqlCommand("SELECT PROMOTIONCODE, PROMOTIONPERCENTAGE, PROMOTIONDETAILS FROM SPECIALDEALS WHERE ID = @SelectedID", MainClass.con);
                        cmd.Parameters.AddWithValue("@SelectedID", selectedID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string promotionCode = reader["PROMOTIONCODE"].ToString();
                            string promotionPercentage = reader["PROMOTIONPERCENTAGE"].ToString();
                            string promotionDetail = reader["PROMOTIONDETAILS"].ToString();

                            promotioncode.Text = promotionCode;
                            promotionpercentage.Text = promotionPercentage;
                            promotiondetails.Text = promotionDetail;
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
                
            }
        }
        private void promotionpercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (promotionpercentage.Text != "")
                {
                    float percentage = float.Parse(promotionpercentage.Text);

                    if (amount.Text != "")
                    {
                        float amountvalue = float.Parse(amount.Text);

                        var amountupdate = amountvalue + ((percentage / 100.00) * amountvalue);

                        amountafterpromotion.Text = amountupdate.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }


        }
        private void promotionpercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
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
        private void intlock(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the keypress if it's not a number or a control character
            }
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
    }
}
