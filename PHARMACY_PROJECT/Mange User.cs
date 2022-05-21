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
    public partial class Mange_User : Form
    {
        public Mange_User()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Mange_User_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true");
            string Sql = "Select *from pharmacist";
            SqlDataAdapter da = new SqlDataAdapter(Sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.DisplayMember = "id ";

        }
        private void button4_Click(object sender, EventArgs e)
        {
           
            PHARMACY_PROJECT.Add_user a = new PHARMACY_PROJECT.Add_user();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update pharmacist set  /*name =@name,*/ password = @password where name=@name";
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Updated Successfully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from  pharmacist where name=@name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" deleted  Successfully");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select  name , password, type_of_permission from pharmacist where  name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
            }
            else
            {
                dr.Close();

            } 

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
           PHARMACY_PROJECT. Admin_Home a = new PHARMACY_PROJECT.Admin_Home();
            a.Show();
        }
    }
}
