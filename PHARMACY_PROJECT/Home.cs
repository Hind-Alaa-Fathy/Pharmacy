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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Company a = new Add_Company();
            a.Show();
        }

        private void manageCompanyToolStripMenuItem_Click(object sender, EventArgs e)
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
            this.Hide();
            Add_Customer a = new Add_Customer();
            a.Show();
        }

        private void manageCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Customer m = new Manage_Customer();
            m.Show();
        }
    }
}
