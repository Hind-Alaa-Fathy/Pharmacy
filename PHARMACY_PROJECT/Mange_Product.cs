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
    public partial class Mange_Product : Form
    {
        public Mange_Product()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             Add_product AD= new Add_product();
            AD.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from  medicine where name=@name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" deleted  Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
             string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update medicine set  name =@name, scientific_name = @scientific_name,  purchasing_price = @purchasing_price , selling_price = @selling_price,  quantity = @quantity, barcode = @barcode where name=@name";
            cmd.Parameters.AddWithValue("@name", textBox7.Text);
            cmd.Parameters.AddWithValue("@scientific_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@purchasing_price ", textBox3.Text);
            cmd.Parameters.AddWithValue("@selling_price ", textBox4.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox5.Text);
            cmd.Parameters.AddWithValue("@barcode ", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Updated Successfully");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select* from medicine where  name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox7.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
               
            }
            else
           
                dr.Close();

        }

        private void Mange_Product_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true");
            string Sql = "Select *from medicine";
            SqlDataAdapter da = new SqlDataAdapter(Sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow c in dt.Rows)
            {
                comboBox1.Items.Add(c["name"]);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
           PHARMACY_PROJECT. Admin_Home a = new PHARMACY_PROJECT.Admin_Home();
            a.Show();
        }
    }
}
