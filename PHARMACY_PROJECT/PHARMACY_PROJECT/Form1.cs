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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text !="")
            {
               
                if (textBox1.Text == "Ali12" && textBox2.Text == "123")
                {
                    this.Hide();
                    Admin_Home a = new Admin_Home();
                    a.Show();
                   
                }
                else if (textBox1.Text == "Mona12" && textBox2.Text == "456")
                {
                    this.Hide();
                    Pharmacist_Home a = new Pharmacist_Home();
                    a.Show();
                }
                else if (textBox1.Text == "Hind12" && textBox2.Text == "12345678")
                {
                    this.Hide();
                    Admin_Home a = new Admin_Home();
                    a.Show();
                }
                else if (textBox1.Text == "Heba12" && textBox2.Text == "987654321")
                {
                    this.Hide();
                    Admin_Home a = new Admin_Home();
                    a.Show();
                }
                else if (textBox1.Text == "Hadeer12" && textBox2.Text == "0987654321")
                {
                    this.Hide();
                    Admin_Home a = new Admin_Home();
                    a.Show();
                }
                else if (textBox1.Text == "mohamed12" && textBox2.Text == "123456")
                {
                    this.Hide();
                    Pharmacist_Home a = new Pharmacist_Home();
                    a.Show();
                }
               

            }
            else
            {
                MessageBox.Show(" fill all items", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
