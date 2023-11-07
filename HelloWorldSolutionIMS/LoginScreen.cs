using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using static HelloWorldSolutionIMS.MealAction;
using Win32Interop.Enums;

namespace HelloWorldSolutionIMS
{
    public partial class LoginScreen : Form
    {
        SqlDataReader dr;
        public static string User_NAME = "";
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            //try
            //{
            //    bool found = false;
            //    MainClass.con.Open();
            //    SqlCommand cmd = new SqlCommand("select * from Users where Username = @Username and Password = @Password ", MainClass.con);
            //    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            //    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            //    dr = cmd.ExecuteReader();
            //    dr.Read();
            //    if (dr.HasRows)
            //    {
            //        found = true;
            //        User_NAME = dr["Name"].ToString();
            //    }
            //    else
            //    {
            //        found = false;
            //        MessageBox.Show("Invalid Details", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        Clear();
            //        txtUsername.Focus();
            //    }
            //    dr.Close();
            //    MainClass.con.Close();
            //    if (found == true)
            //    {
            //        MessageBox.Show("Welcome " + User_NAME);
            //        Dashboard das = new Dashboard();
            //        MainClass.showWindow(das, this, MDI.ActiveForm);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MainClass.con.Close();
            //    MessageBox.Show(ex.Message);
            //}
        }

        //private void cbPass_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(cbPass.Checked == true)
        //    {
        //        txtPassword.UseSystemPasswordChar = false;
        //    }
        //    else
        //    {
        //        txtPassword.UseSystemPasswordChar = true;
        //    }
        //}
        private void Start()
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("SELECT COMPANYNAME,BRANCH,EMAIL,LANDLINE,MOBILE,POBOX,TRADENO,WELCOME,LOGO FROM SETTINGS", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    companyname.Text = dr["COMPANYNAME"].ToString();
                    branch.Text = dr["BRANCH"].ToString();
                    email.Text = dr["EMAIL"].ToString();
                    landline.Text = dr["LANDLINE"].ToString();
                    trade.Text = dr["TRADENO"].ToString();
                    //labelPOBox.Text = dr["POBOX"].ToString();
                    trade.Text = dr["TRADENO"].ToString();
                    liscense.Text = dr["TRADENO"].ToString();
                    welcome.Text = dr["WELCOME"].ToString();
                    pictureBox1.ImageLocation = dr["LOGO"].ToString();
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
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Color FROM SideBarColor", MainClass.con);

                SqlDataReader reader = cmd.ExecuteReader();
                // Read color value from the database
                if (reader.Read())
                {
                    string colorString = reader["Color"].ToString();
                    Color color = ColorTranslator.FromHtml(colorString);
                    loginpanel.BackColor = color;

                }
                else
                {
                    loginpanel.BackColor = Color.White;

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

            Start();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!File.Exists(path + "\\myconnect"))
            {
                DatabaseSettings sl = new DatabaseSettings();
                sl.ShowDialog();
            }
            long fileLen = new FileInfo(path + "\\myconnect").Length;
            if (File.Exists(path + "\\myconnect") && fileLen != 0)
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select * from example where status = 1 ", MainClass.con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[2].ToString() == "1")
                        {
                            dr.Close();
                            SqlCommand cmd1 = new SqlCommand("select left(e.Keys,5)+'-' +RIGHT(e.Keys,4) as 'Date' from example e where e.status = 1", MainClass.con);
                            cmd1.CommandType = CommandType.Text;
                            SqlDataReader dr1 = cmd1.ExecuteReader();
                            if (dr1.Read())
                            {
                                if (DateTime.Parse(dr1["Date"].ToString()) <= DateTime.Now.Date)
                                {
                                    dr1.Close();
                                    SqlCommand cmd2 = new SqlCommand("update  example set status = 0", MainClass.con);
                                    cmd2.CommandType = CommandType.Text;
                                    cmd2.ExecuteNonQuery();
                                    MessageBox.Show("Your Software has been expired");

                                    AdminLogin amd = new AdminLogin();
                                    amd.ShowDialog();
                                }
                                else
                                {
                                    try
                                    {
                                        dr1.Close();
                                        SqlCommand cmd2 = new SqlCommand("select today from example e where e.status = 1", MainClass.con);
                                        cmd2.CommandType = CommandType.Text;
                                        SqlDataReader dr2 = cmd2.ExecuteReader();
                                        if (dr2.Read())
                                        {
                                            if (DateTime.Parse(dr2["today"].ToString()) > DateTime.Now.Date)
                                            {
                                                SqlCommand cmd3 = new SqlCommand("update  example set status = 0", MainClass.con);
                                                cmd3.CommandType = CommandType.Text;
                                                cmd3.ExecuteNonQuery();
                                                MessageBox.Show("Your Software has been expired");
                                                AdminLogin amd = new AdminLogin();
                                                amd.ShowDialog();
                                            }
                                            else
                                            {
                                                MainClass.con.Close();
                                                try
                                                {
                                                    SqlCommand cmd4 = new SqlCommand("update example set today = '" + DateTime.Now.Date + "' where status = 1", MainClass.con);
                                                    cmd4.CommandType = CommandType.Text;
                                                    MainClass.con.Open();
                                                    cmd4.ExecuteNonQuery();
                                                    MainClass.con.Close();
                                                }
                                                catch (Exception ex)
                                                {
                                                    MainClass.con.Close();
                                                    MessageBox.Show(ex.Message);
                                                }

                                                //LoginScreen hs = new LoginScreen();
                                                //MainClass.showWindow(hs, this);
                                            }
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
                        else
                        {
                            AdminLogin amd = new AdminLogin();
                            amd.ShowDialog();
                        }

                        MainClass.con.Close();

                    }
                    else
                    {
                        AdminLogin amd = new AdminLogin();
                        amd.ShowDialog();
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
                DatabaseSettings sl = new DatabaseSettings();
                sl.ShowDialog();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            MainPage obj = new MainPage();
            this.Hide();
            obj.Show();
        }
    }
}
