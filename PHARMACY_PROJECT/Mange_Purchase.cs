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
    public partial class Mange_Purchase : Form
    {
        public Mange_Purchase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_purchase a = new Add_purchase();
            a.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select id,date,company_name,pharmacist_name,product_name,supplier_name,quantity,price,total_price from purchase where  date = @date";
            cmd.Parameters.AddWithValue("@date", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox8.Text = dr[0].ToString();
                textBox7.Text = dr[1].ToString();
                comboBox5.Text = dr[2].ToString();
                comboBox2.Text = dr[3].ToString();
                comboBox3.Text = dr[4].ToString();
                comboBox4.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
                textBox4.Text = dr[7].ToString();
                textBox5.Text = dr[8].ToString();
            }
            else
            {
                dr.Close();

            }
        }

        private void Mange_Purchase_Load(object sender, EventArgs e)
        {

            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataAdapter ad = new SqlDataAdapter("select distinct date from purchase", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow c in dt.Rows)
            {
                comboBox1.Items.Add(c["date"]);
            }
           
            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = constring;
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con4;
            SqlDataAdapter ad4 = new SqlDataAdapter("select distinct name from company", con4);
            DataTable dt4 = new DataTable();
            ad4.Fill(dt4);
            foreach (DataRow c in dt4.Rows)
            {
                comboBox5.Items.Add(c["name"]);
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

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from purchase where date = @date";
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
            cmd.CommandText = "update purchase set date=@date,company_name=@company_name ,pharmacist_name=@pharmacist_name ,product_name=@product_name ,supplier_name=@supplier_name ,quantity=@quantity ,price=@price ,total_price=@total_price where date = @date ";
            cmd.Parameters.AddWithValue("@date", textBox7.Text);
            cmd.Parameters.AddWithValue("@company_name", comboBox5.Text);
            cmd.Parameters.AddWithValue("@pharmacist_name", comboBox2.Text);
            cmd.Parameters.AddWithValue("@product_name", comboBox3.Text);
            cmd.Parameters.AddWithValue("@supplier_name", comboBox4.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox6.Text);
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            cmd.Parameters.AddWithValue("@total_price", textBox5.Text);
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
