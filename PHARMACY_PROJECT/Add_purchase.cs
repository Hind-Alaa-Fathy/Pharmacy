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
    public partial class Add_purchase : Form
    {
        public Add_purchase()
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
            cmd.CommandText = "insert into purchase(id,date,company_name,pharmacist_name,product_name,supplier_name,quantity,price,total_price ) values (@id,@date,@company_name,@pharmacist_name,@product_name,@supplier_name,@quantity,@price,@total_price)";
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@date", textBox2.Text);
            cmd.Parameters.AddWithValue("@company_name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@pharmacist_name ", comboBox2.Text);
            cmd.Parameters.AddWithValue("@product_name ", comboBox3.Text);
            cmd.Parameters.AddWithValue("@supplier_name", comboBox4.Text);
            cmd.Parameters.AddWithValue("@quantity ", textBox3.Text);
            cmd.Parameters.AddWithValue("@price ", textBox4.Text);
            cmd.Parameters.AddWithValue("@total_price ", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Added Successfully");
        }

        private void Add_purchase_Load(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataAdapter ad = new SqlDataAdapter("select distinct name from company", con);
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
            SqlDataAdapter ad1 = new SqlDataAdapter("select distinct name from pharmacist", con1);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            foreach (DataRow c in dt1.Rows)
            {
                comboBox2.Items.Add(c["name"]);
            }

            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = constring;
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            SqlDataAdapter ad2 = new SqlDataAdapter("select distinct name from medicine", con2);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            foreach (DataRow c in dt2.Rows)
            {
                comboBox3.Items.Add(c["name"]);
            }
       


            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = constring;
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;
            SqlDataAdapter ad3 = new SqlDataAdapter("select distinct name from supplier", con3);
            DataTable dt3 = new DataTable();
            ad3.Fill(dt3);
            foreach (DataRow c in dt3.Rows)
            {
                comboBox4.Items.Add(c["name"]);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = (int.Parse(textBox4.Text) * int.Parse(textBox3.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PHARMACY_PROJECT.Admin_Home a = new PHARMACY_PROJECT.Admin_Home();
            a.Show();
        }
    }
}
