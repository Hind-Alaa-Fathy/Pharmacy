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
    public partial class Add_sales : Form
    {
        public Add_sales()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_sales_Load(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataAdapter ad = new SqlDataAdapter("select distinct name from medicine", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow c in dt.Rows)
            {
                comboBox1.Items.Add(c["name"]);
            }

         
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = constring;
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            SqlDataAdapter ad1 = new SqlDataAdapter("select distinct name from customer", con);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            foreach (DataRow c in dt1.Rows)
            {
                comboBox2.Items.Add(c["name"]);
            }

            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = constring;
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;
            SqlDataAdapter ad3 = new SqlDataAdapter("select distinct name from pharmacist", con);
            DataTable dt3 = new DataTable();
            ad3.Fill(dt3);
            foreach (DataRow c in dt3.Rows)
            {
                comboBox2.Items.Add(c["name"]);
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = ((int.Parse(textBox3.Text)) * (int.Parse(textBox6.Text))).ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
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
            cmd.CommandText = "insert into Sales(id,product_name,date,Pharmacist_name,customer_name,quantity,price,Total_Price ) values (@id,@product_name,@date,@Pharmacist_name,@customer_name,@quantity,@price,@Total_Price)";
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.Parameters.AddWithValue("@product_name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", textBox1.Text);
            cmd.Parameters.AddWithValue("@Pharmacist_name ", comboBox3.Text);
            cmd.Parameters.AddWithValue("@customer_name ", comboBox2.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@price ", textBox6.Text);
            cmd.Parameters.AddWithValue("@Total_Price ", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Added Successfully");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
