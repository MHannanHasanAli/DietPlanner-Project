using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using EasyTabs;
namespace HelloWorldSolutionIMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginScreen ls = new LoginScreen();
            MainClass.showWindow(ls, this, MDI.ActiveForm);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingScreen s = new SettingScreen();
            MainClass.showWindow(s,this,MDI.ActiveForm);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomersAndSupplier cs = new CustomersAndSupplier();
            MainClass.showWindow(cs, this, MDI.ActiveForm);
        }

        private void btnProductsEntry_Click(object sender, EventArgs e)
        {
            ProductEntry pe = new ProductEntry();
            MainClass.showWindow(pe, this, MDI.ActiveForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Warehouses ws = new Warehouses();
            ws.ShowDialog();
        }
        public static int Tabo=1;
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseInvoice pi = new PurchaseInvoice();
            AppContainer container = new AppContainer(); container.Tabs.Add(
                // Our First Tab created by default in the Application will have as content the Form1
                new TitleBarTab(container)
                {
                    Content = new PurchaseInvoice
                    {
                        Text = "Purchase Invoice" + Tabo
                    }
                }
            );
            container.SelectedTabIndex = 0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(container);
        //    MainClass.showWindow(pi, this, MDI.ActiveForm);
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
          //  Prices p = new Prices();
           // MainClass.showWindow(p, this, MDI.ActiveForm);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ShopInventory inv = new ShopInventory();
            MainClass.showWindow(inv, this, MDI.ActiveForm);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Transfer ts = new Transfer();
            MainClass.showWindow(ts, this, MDI.ActiveForm);

        }
        public static int Ta = 1;
        public static int sale = 0;
        private void btnSale_Click(object sender, EventArgs e)
        {
            Ta = 1;
            SaleInvoice si = new SaleInvoice();
            sale = 1;
            AppContainer container = new AppContainer(); container.Tabs.Add(
               // Our First Tab created by default in the Application will have as content the Form1
               new TitleBarTab(container)
               {
                   Content = new SaleInvoice
                   {
                       Text = "Sale Invoice" + Ta
                   }
               }
           );
            container.SelectedTabIndex = 0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(container);
        //    MainClass.showWindow(si, this, MDI.ActiveForm);
        }



        private void btnLedgers_Click(object sender, EventArgs e)
        {
            Ledgers ld = new Ledgers();
            MainClass.showWindow(ld, this, MDI.ActiveForm);
        }

 

        private void btnReports_Click(object sender, EventArgs e)
        {
            AllReports ar = new AllReports();
            MainClass.showWindow(ar, this, MDI.ActiveForm);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Expenses es = new Expenses();
            es.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpeningBalance ob = new OpeningBalance();
            MainClass.showWindow(ob, this, MDI.ActiveForm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Units u = new Units();
            u.ShowDialog();
        }


     
        private void Dashboard_Load(object sender, EventArgs e)
        {
         
        }

        private void btnReturnStocks_Click(object sender, EventArgs e)
        {
            StocksReturn st = new StocksReturn();
            MainClass.showWindow(st, this, MDI.ActiveForm);

        }
    }
}
