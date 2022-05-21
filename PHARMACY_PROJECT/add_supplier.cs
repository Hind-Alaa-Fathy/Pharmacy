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
    public partial class add_supplier : Form
    {
        public add_supplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ( textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("check your information", "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {

                string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = " insert into supplier ( name , phone ,company_id ) values(@name,@phone ,@company_id)";

                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@company_id", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("done", "information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                textBox2.Text = " "; textBox3.Text = " "; textBox4.Text = " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Home a = new Admin_Home();
            a.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select id from company where  name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
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

        private void add_supplier_Load(object sender, EventArgs e)
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
        }
    }
}
