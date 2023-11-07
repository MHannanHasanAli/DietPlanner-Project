using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
namespace HelloWorldSolutionIMS
{
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {

            Dashboard.Tabo++;
            Dashboard.Ta++;
            if (Dashboard.sale == 1)
            {
                return new TitleBarTab(this)
                {
                    Content = new SaleInvoice
                    {

                        Text = "Sale Invoice" + Dashboard.Ta
                    }
                };
            }
            else
            {


                return new TitleBarTab(this)
                {

                    Content = new PurchaseInvoice
                    {

                        Text = "Purchase Invoice" + Dashboard.Tabo
                    }
                };
            }
        }





    }
}
