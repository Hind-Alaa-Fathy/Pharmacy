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
    public partial class Add_product : Form
    {
        public Add_product()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into medicine(name,scientific_name,purchasing_price ,selling_price ,quantity,barcode ) values (@name,@scientific_name, @purchasing_price ,@selling_price ,@quantity,@barcode)";
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@scientific_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@purchasing_price ", textBox3.Text);
            cmd.Parameters.AddWithValue("@selling_price ", textBox4.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox5.Text);
            cmd.Parameters.AddWithValue("@barcode ", textBox6.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Added Successfully");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            PHARMACY_PROJECT. Admin_Home a = new PHARMACY_PROJECT.Admin_Home();
            a.Show();
        }
    }
}
