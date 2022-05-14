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
    public partial class Pharmacist_Home : Form
    {
        public Pharmacist_Home()
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

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Add_Customer a = new Add_Customer();
            a.Show();
        }

        private void viewStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Store s = new Store();
            s.Show();
        }
    }
}
