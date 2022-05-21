using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHARMACY_PROJECT
{
    public partial class Admin_Home : Form
    {
        public Admin_Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
           
            DateTime mytoday = DateTime.Now;
            label1.Text = mytoday.ToLongTimeString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DateTime mydate = DateTime.Now;
            label2.Text = mydate.ToLongDateString();
        }

        private void addCompaniesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Company a = new Add_Company();
            a.Show();
        }

        private void manageCompaniesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Company m = new Manage_Company();
            m.Show();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_supplier a = new add_supplier();
            a.Show();
        }

        private void manageSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            manage_supplier m = new manage_supplier();
            m.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Add_Customer a = new Add_Customer();
            a.Show();
        }

        private void manageCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Customer m = new Manage_Customer();
            m.Show();
        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Mange_User m = new SE_Project.Mange_User();
            m.Show();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Add_Category a = new SE_Project.Add_Category();
            a.Show();
        }

        private void manageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Mange_category m = new SE_Project.Mange_category();
            m.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Add_product a = new SE_Project.Add_product();
            a.Show();
        }

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Mange_Product m = new SE_Project.Mange_Product();
            m.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_user a = new Add_user();
            a.Show();
        }

        private void addSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SE_Project.Add_sales a = new SE_Project.Add_sales();
            a.Show();
        }

        private void manageSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Mange_Sales m = new SE_Project.Mange_Sales();
            m.Show();
        }

        private void addPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Add_purchase a = new SE_Project.Add_purchase();
            a.Show();
        }

        private void managePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE_Project.Mange_Purchase m = new SE_Project.Mange_Purchase();
            m.Show();
        }
    }
}
