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
    public partial class Mange_Sales : Form
    {
        public Mange_Sales()
        {
            InitializeComponent();
        }

        private void Mange_Sales_Load(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataAdapter ad = new SqlDataAdapter("select distinct date from Sales", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow c in dt.Rows)
            {
                comboBox1.Items.Add(c["date"]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select id,product_name,date,Pharmacist_name,customer_name,quantity,price,Total_Price from Sales where  date = @date";
            cmd.Parameters.AddWithValue("@date", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox4.Text = dr[0].ToString();
                comboBox4.Text = dr[1].ToString();
                textBox8.Text = dr[2].ToString();
                comboBox3.Text = dr[3].ToString();
                comboBox2.Text = dr[4].ToString();
                textBox7.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
                textBox5.Text = dr[7].ToString();
            }
            else
            {
                dr.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_sales a = new Add_sales();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from Sales where date = @date";
            cmd.Parameters.AddWithValue("@date", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update Sales set  product_name=@product_name, date=@date ,Pharmacist_name=@Pharmacist_name ,customer_name=@customer_name ,quantity=@quantity ,price=@price,Total_Price=@Total_Price where date = @date ";
            cmd.Parameters.AddWithValue("@product_name", comboBox4.Text);
            cmd.Parameters.AddWithValue("@date", textBox8.Text);
            cmd.Parameters.AddWithValue("@Pharmacist_name", comboBox3.Text);
            cmd.Parameters.AddWithValue("@customer_name", comboBox2.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox7.Text);
            cmd.Parameters.AddWithValue("@price", textBox6.Text);
            cmd.Parameters.AddWithValue("@Total_Price", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("updated", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PHARMACY_PROJECT.Admin_Home a = new PHARMACY_PROJECT.Admin_Home();
            a.Show();
        }
    }
}
