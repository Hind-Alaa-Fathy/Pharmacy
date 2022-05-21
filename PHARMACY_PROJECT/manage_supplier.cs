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
    public partial class manage_supplier : Form
    {
        public manage_supplier()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_supplier a = new add_supplier();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from supplier where name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manage_supplier_Load(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataAdapter ad = new SqlDataAdapter("select distinct name from supplier", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow c in dt.Rows)
            {
                comboBox1.Items.Add(c["name"]);
            }
            
            ////////////////////////////////////////////////
            //string Constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = constring;
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            SqlDataAdapter ad1 = new SqlDataAdapter("select distinct name from company", con1);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            foreach (DataRow c in dt1.Rows)
            {
                comboBox2.Items.Add(c["name"]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select id , name , phone ,company_id from supplier where  name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //id
                textBox1.Text = dr[0].ToString();
                //name
                textBox2.Text = dr[1].ToString();
                //phone
                textBox3.Text = dr[2].ToString();
                //company_id
                textBox4.Text = dr[3].ToString();

            }
            else
            {
                dr.Close();
                MessageBox.Show("No data", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update supplier set  name = @name, phone= @phone ,company_id= @company_id where name = @name1 ";
            cmd.Parameters.AddWithValue("@name1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@company_id", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("updated", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Home a = new Admin_Home();
            a.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select id from company where  name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //id
                textBox4.Text = dr[0].ToString();

            }
            else
            {
                dr.Close();
                MessageBox.Show("No data", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select name from company where  id = @id";
            cmd.Parameters.AddWithValue("@id", textBox4.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //name
                comboBox2.Text = dr[0].ToString();

            }
            else
            {
                dr.Close();
                MessageBox.Show("No data", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
