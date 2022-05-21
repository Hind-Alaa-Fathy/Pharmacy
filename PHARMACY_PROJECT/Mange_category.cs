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
    public partial class Mange_category : Form
    {
        public Mange_category()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select name from category where  name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox1.Text = dr[0].ToString();

            }
            else
            {
                dr.Close();

            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from category where name=@name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" deleted  Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Category a = new Add_Category();
            a.Show();
        }

        private void Mange_category_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true");
            string Sql = "Select name from category";
            SqlDataAdapter da = new SqlDataAdapter(Sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow c in  dt.Rows)
            {
                comboBox1.Items.Add(c["name"]);
                
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           PHARMACY_PROJECT. Admin_Home a = new  PHARMACY_PROJECT.Admin_Home();
            a.Show();
        }
    }
}
