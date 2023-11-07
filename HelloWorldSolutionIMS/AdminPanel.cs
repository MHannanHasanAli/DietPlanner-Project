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

namespace HelloWorldSolutionIMS
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtKey.Text != "" && cboStatus.SelectedIndex != -1)
            {
                try
                {
                    SqlCommand cmd2 = new SqlCommand("insert into example (Keys,status,today) values('"+firstkeytext.Value.Date.ToString("MM-dd")+txtKey.Text+lastkeytext.Value.Year.ToString() +"',1,'"+DateTime.Now.Date+"')", MainClass.con);
                    cmd2.CommandType = System.Data.CommandType.Text;
                    MainClass.con.Open();
                    cmd2.ExecuteNonQuery();
                    MainClass.con.Close();
                    MessageBox.Show("Your Software has been Activated");
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
