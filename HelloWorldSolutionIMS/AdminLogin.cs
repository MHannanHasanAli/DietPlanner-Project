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
namespace HelloWorldSolutionIMS
{
    public partial class AdminLogin : Form
    {
        SqlDataReader dr;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                bool found = false;
                SqlCommand cmd = new SqlCommand("select * from example2 where username = @username and password = @password ", MainClass.con);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                }
                else
                {
                    found = false;
                    MessageBox.Show("Invalid Details", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                }
                MainClass.con.Close();
                dr.Close();
                if (found == true)
                {
                    AdminPanel das = new AdminPanel();
                    this.Dispose();
                    das.ShowDialog();
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }
    }
}
