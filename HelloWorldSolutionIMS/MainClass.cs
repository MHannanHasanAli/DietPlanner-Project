using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.IO;

namespace HelloWorldSolutionIMS
{
    class MainClass
    {

        public static void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }

        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string s = File.ReadAllText(path + "\\myconnect");
        public static SqlConnection con = new SqlConnection(s);

        public static void showWindow(Form OpenWin, Form clsWin, Form MDIWin)
        {
            clsWin.Close();
            OpenWin.MdiParent = MDIWin;
            OpenWin.WindowState = FormWindowState.Maximized;
            OpenWin.Show();
        }

        public static void ShowReportsOP(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\OpeningBalanceReciept.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowReportsOP(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null,
            string param2 = "", object val2 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                if (param2 != "")
                {
                    cmd.Parameters.AddWithValue(param2, val2);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\OpeningReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void CustomerOpeniningReport(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\CustomerOpeniningReceipt.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowReportsL(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\LedgerReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowInfoReportCust(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null,
            string param2 = "", object val2 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                if (param2 != "")
                {
                    cmd.Parameters.AddWithValue(param2, val2);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\CustomerLedgerReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowInfoReportSup(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null,
            string param2 = "", object val2 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                if (param2 != "")
                {
                    cmd.Parameters.AddWithValue(param2, val2);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\SupplierLedgerReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowReportsLS(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\LedgerReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowStatement(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\CustomerReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowInvoiceVIACustomer(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\InvoicesViaCustomer.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void showWindow(Form OpenWin, Form MDIWin)
        {
            OpenWin.MdiParent = MDIWin;
            OpenWin.WindowState = FormWindowState.Maximized;
            OpenWin.Show();
        }

        public static DataTable Retrieve(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, MainClass.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void FillCategories(ComboBox cmb)
        {

            DataTable dtCategoryName = new DataTable();
            dtCategoryName.Columns.Add("CategoryID");
            dtCategoryName.Columns.Add("Category");
            dtCategoryName.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select CategoryID, Category from Categories");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow category in dt.Rows)
                        {
                            dtCategoryName.Rows.Add(category["CategoryID"], category["Category"]);
                        }
                    }

                }
                cmb.DisplayMember = "Category";
                cmb.ValueMember = "CategoryID";
                cmb.DataSource = dtCategoryName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtCategoryName;
            }

        }



        public static void FillRoles(ComboBox cmb)
        {

            DataTable dtUsers = new DataTable();
            dtUsers.Columns.Add("UserID");
            dtUsers.Columns.Add("Role");
            dtUsers.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select UserID, Role from Users");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow category in dt.Rows)
                        {
                            dtUsers.Rows.Add(category["UserID"], category["Role"]);
                        }
                    }

                }
                cmb.DisplayMember = "Role";
                cmb.ValueMember = "UserID";
                cmb.DataSource = dtUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtUsers;
            }

        }


        public static void FillPersonTypes(ComboBox cmb)
        {
            DataTable dtTypes = new DataTable();
            dtTypes.Columns.Add("PersonTypeID");
            dtTypes.Columns.Add("PersonType");
            dtTypes.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select PersonTypeID, PersonType from PersonTypes");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow types in dt.Rows)
                        {
                            dtTypes.Rows.Add(types["PersonTypeID"], types["PersonType"]);
                        }
                    }

                }
                cmb.DisplayMember = "PersonType";
                cmb.ValueMember = "PersonTypeID";
                cmb.DataSource = dtTypes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtTypes;
            }
        }




        public static void FillUnits(ComboBox cmb)
        {

            DataTable dgUnits = new DataTable();
            dgUnits.Columns.Add("UnitID");
            dgUnits.Columns.Add("UnitName");
            dgUnits.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select UnitID, UnitName from Units");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow units in dt.Rows)
                        {
                            dgUnits.Rows.Add(units["UnitID"], units["UnitName"]);
                        }
                    }

                }
                cmb.DisplayMember = "UnitName";
                cmb.ValueMember = "UnitID";

                cmb.DataSource = dgUnits;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgUnits;
            }

        }



        public static void FillWarehouses(ComboBox cmb)
        {

            DataTable dgUnits = new DataTable();
            dgUnits.Columns.Add("WareID");
            dgUnits.Columns.Add("Warehouse");
            dgUnits.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select WareID, Warehouse from Warehouses");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow units in dt.Rows)
                        {
                            dgUnits.Rows.Add(units["WareID"], units["Warehouse"]);
                        }
                    }

                }
                cmb.DataSource = dgUnits;
                cmb.DisplayMember = "Warehouse";
                cmb.ValueMember = "WareID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgUnits;
            }

        }

        public static void FillProducts2Pur(ComboBox cmb)
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("Pcode");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");

            try
            {
                DataTable dt = Retrieve("select Pcode, ProductName from Products");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["Pcode"], products["ProductName"]);
                        }
                    }

                }
                cmb.DataSource = dgProducts;
                cmb.ValueMember = "Pcode";
                cmb.DisplayMember = "ProductName";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgProducts;
            }

        }





        public static void FillProducts2Sal(ComboBox cmb)
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("Pcode");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");

            try
            {
                DataTable dt = Retrieve("select Pcode, ProductName from Products");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["Pcode"], products["ProductName"]);
                        }
                    }

                }
                cmb.DisplayMember = "ProductName";
                cmb.ValueMember = "Pcode";
                cmb.DataSource = dgProducts;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgProducts;
            }

        }

        public static void ShowProducts(DataGridView dgv, DataGridViewColumn Pcode, DataGridViewColumn ProductName, string searchvalue)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    cmd = new SqlCommand("select Pcode,ProductName from Products order by ProductName", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select Pcode,ProductName from Products where ProductName  like '%" + searchvalue + "%' order by ProductName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Pcode.DataPropertyName = dt.Columns["Pcode"].ToString();
                ProductName.DataPropertyName = dt.Columns["ProductName"].ToString();

                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        public static void FillSupplier(ComboBox cmb)
        {

            DataTable dgPersons = new DataTable();
            dgPersons.Columns.Add("PersonType");
            dgPersons.Columns.Add("PersonID");
            dgPersons.Columns.Add("PersonName");
            dgPersons.Rows.Add("0", "-----Select-----", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select p.PersonID, p.PersonName,pt.PersonType from Persons p inner join PersonTypes pt on pt.PersonTypeID = p.PersonType where pt.PersonTypeID = '1' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow per in dt.Rows)
                        {
                            dgPersons.Rows.Add(per["PersonType"], per["PersonID"], per["PersonName"]);
                        }
                    }

                }
                cmb.DataSource = dgPersons;
                cmb.DisplayMember = "PersonName";
                cmb.ValueMember = "PersonID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgPersons;
            }

        }

        public static void FillCustomer(ComboBox cmb)
        {

            DataTable dgPersons = new DataTable();
            dgPersons.Columns.Add("PersonType");
            dgPersons.Columns.Add("PersonID");
            dgPersons.Columns.Add("PersonName");
            dgPersons.Rows.Add("0", "-----Select-----", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select p.PersonID, p.PersonName,pt.PersonType from Persons p inner join PersonTypes pt on pt.PersonTypeID = p.PersonType where pt.PersonTypeID = '2' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow per in dt.Rows)
                        {
                            dgPersons.Rows.Add(per["PersonType"], per["PersonID"], per["PersonName"]);
                        }
                    }

                }
                cmb.DataSource = dgPersons;
                cmb.DisplayMember = "PersonName";
                cmb.ValueMember = "PersonID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgPersons;
            }

        }


        public static void ShowReports(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\SalesReciept.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowReportsOP(ReportDocument rd, CrystalReportViewer crv, string proc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\OpeningBalanceReciept.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowReportsp(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\PurchaseReciept.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowReportsL(ReportDocument rd, CrystalReportViewer crv, string proc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\LedgerReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowReportsLS(ReportDocument rd, CrystalReportViewer crv, string proc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\SupplierLedgerReport.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private object ProductCount = 0;
        public static void UpdateStock(Int32 Pcode, float qty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Stocks set st_Qty = @qty where st_Pcode = @Pcode", MainClass.con);
                cmd.Parameters.AddWithValue("@Pcode", Pcode);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateShop(Int32 Pcode, float qty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update ShopStocks set sh_Qty = @qty where sh_Pcode = @Pcode", MainClass.con);
                cmd.Parameters.AddWithValue("@Pcode", Pcode);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateScrap(Int32 Pcode, int qty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Scraps set SC_Qty = @qty where SC_Pcode = @Pcode", MainClass.con);
                cmd.Parameters.AddWithValue("@Pcode", Pcode);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }




        public static void ShowStocks(DataGridView dgv, DataGridViewColumn pname, DataGridViewColumn quantity, DataGridViewColumn unit)
        {
            SqlCommand cmd;
            try
            {
                MainClass.con.Open();
                if (AllReports.Other == 1)
                {
                    cmd = new SqlCommand("select  p.ProductName as [Product],s.sh_Qty as [Quantity],u.UnitName as [Unit] from ShopStocks s  inner join Products p on p.Pcode = s.sh_Pcode inner join  Units u on u.UnitName = s.sh_Unit where sh_Qty != '0'   ", MainClass.con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    pname.DataPropertyName = dt.Columns["Product"].ToString();
                    quantity.DataPropertyName = dt.Columns["Quantity"].ToString();
                    unit.DataPropertyName = dt.Columns["Unit"].ToString();
                    dgv.DataSource = dt;
                    AllReports.Other = 0;
                }
                else
                {
                    cmd = new SqlCommand("select  p.ProductName as [Product],s.st_Qty as [Quantity],u.UnitName as [Unit] from Stocks s  inner join Products p on p.Pcode = s.st_Pcode inner join  Units u on u.UnitName = s.st_Unit where st_Qty != '0'  ", MainClass.con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    pname.DataPropertyName = dt.Columns["Product"].ToString();
                    quantity.DataPropertyName = dt.Columns["Quantity"].ToString();
                    unit.DataPropertyName = dt.Columns["Unit"].ToString();
                    dgv.DataSource = dt;
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
}