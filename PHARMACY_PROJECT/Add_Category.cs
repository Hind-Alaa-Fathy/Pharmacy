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

namespace SE_Project
{
    public partial class Add_Category : Form
    {
        public Add_Category()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into category(name) values (@name)";
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PHARMACY_PROJECT.Admin_Home a = new PHARMACY_PROJECT.Admin_Home();
            a.Show();
        }
    }
}
