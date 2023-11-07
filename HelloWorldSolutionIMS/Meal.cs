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

namespace HelloWorldSolutionIMS
{
    public partial class Meal : Form
    {
        public Meal()
        {
            InitializeComponent();
        }

        


        private void Ingredienttab_Click(object sender, EventArgs e)
        {

        }

        private void Meal_Load(object sender, EventArgs e)
        {
            //ShowMeals(guna2DataGridView1, iddgv, mealardgv, mealendgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv);

        }

        //private void Add_Click(object sender, EventArgs e)
        //{
        //    MainPage obj = new MainPage();
        //    obj.formloader(new MealAction());
        //    //loadform(new MealAction());
        //    //MealAction obj = new MealAction();
        //    //obj.Show();
        //}
        //private void SearchMeals(DataGridView dgv, DataGridViewColumn no, DataGridViewColumn mealarfunc, DataGridViewColumn mealenfunc, DataGridViewColumn calories, DataGridViewColumn protein, DataGridViewColumn fats, DataGridViewColumn carbohydrates, DataGridViewColumn fibers, DataGridViewColumn calcium, DataGridViewColumn sodium)
        //{
        //    string mealName = mealar.Text;
        //    string groupArName = groupnar.Text;

        //    if (mealName != "" && groupArName != "")
        //    {
        //        try
        //        {
        //            MainClass.con.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT ID, MealAr,MealEn, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM,PROTEIN FROM Meal " +
        //                "WHERE (MealAr LIKE @MealName) AND (GroupNAr LIKE @GroupArName)", MainClass.con);

        //            cmd.Parameters.AddWithValue("@MealName", "%" + mealName + "%");
        //            cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            // Modify the column names to match your data grid view
        //            no.DataPropertyName = dt.Columns["ID"].ToString();
        //            mealarfunc.DataPropertyName = dt.Columns["MealAr"].ToString();
        //            mealenfunc.DataPropertyName = dt.Columns["MealEn"].ToString();
        //            calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
        //            fats.DataPropertyName = dt.Columns["FATS"].ToString();
        //            carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
        //            fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
        //            calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
        //            sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
        //            protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();



        //            dgv.DataSource = dt;
        //            MainClass.con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MainClass.con.Close();
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else if (mealName == "" && groupArName != "")
        //    {
        //        try
        //        {
        //            MainClass.con.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT ID, MealAr,MealEn, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM,PROTEIN FROM Meal" +
        //                " WHERE GroupNAr LIKE @GroupArName", MainClass.con);

        //            cmd.Parameters.AddWithValue("@GroupArName", "%" + groupArName + "%");

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            // Modify the column names to match your data grid view
        //            no.DataPropertyName = dt.Columns["ID"].ToString();
        //            mealarfunc.DataPropertyName = dt.Columns["MealAr"].ToString();
        //            mealenfunc.DataPropertyName = dt.Columns["MealEn"].ToString();
        //            calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
        //            fats.DataPropertyName = dt.Columns["FATS"].ToString();
        //            carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
        //            fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
        //            calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
        //            sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
        //            protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();



        //            dgv.DataSource = dt;
        //            MainClass.con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MainClass.con.Close();
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else if (mealName != "" && groupArName == "")
        //    {
        //        try
        //        {
        //            MainClass.con.Open();

        //            SqlCommand cmd = new SqlCommand("SELECT ID, MealAr,MealEn, CALORIES, FATS, CARBOHYDRATES, FIBERS, CALCIUM, SODIUM,PROTEIN FROM Meal " +
        //                "WHERE MealAr LIKE @IngredientName", MainClass.con);

        //            cmd.Parameters.AddWithValue("@IngredientName", "%" + mealName + "%");

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            // Modify the column names to match your data grid view
        //            no.DataPropertyName = dt.Columns["ID"].ToString();
        //            mealarfunc.DataPropertyName = dt.Columns["MealAr"].ToString();
        //            mealenfunc.DataPropertyName = dt.Columns["MealEn"].ToString();
        //            calories.DataPropertyName = dt.Columns["CALORIES"].ToString();
        //            fats.DataPropertyName = dt.Columns["FATS"].ToString();
        //            carbohydrates.DataPropertyName = dt.Columns["CARBOHYDRATES"].ToString();
        //            fibers.DataPropertyName = dt.Columns["FIBERS"].ToString();
        //            calcium.DataPropertyName = dt.Columns["CALCIUM"].ToString();
        //            sodium.DataPropertyName = dt.Columns["SODIUM"].ToString();
        //            protein.DataPropertyName = dt.Columns["PROTEIN"].ToString();


        //            dgv.DataSource = dt;
        //            MainClass.con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MainClass.con.Close();
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Fill Meal Ar or Group Ar");
        //        ShowMeals(guna2DataGridView1, iddgv, mealardgv, mealendgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv);

        //    }
        //}

        //private void search_Click(object sender, EventArgs e)
        //{
        //    SearchMeals(guna2DataGridView1, iddgv, mealardgv, mealendgv, caloriedgv, proteindgv, fatsdgv, carbohydratesdgv, calciumdgv, fiberdgv, sodiumdgv);

        //}
    }
}
