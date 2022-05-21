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
namespace PHARMACY_PROJECT
{
    public partial class Add_user : Form
    {
        public Add_user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("Please Complete Information");
            }
            else
            {
                string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into pharmacist(name,password,type_of_permission) values (@name, @password,@type_of_permission)";
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@type_of_permission", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Added Successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Home a = new Admin_Home();
            a.Show();
        }
    }
}
