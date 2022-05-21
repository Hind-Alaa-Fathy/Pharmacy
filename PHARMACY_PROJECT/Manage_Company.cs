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
    public partial class Manage_Company : Form
    {
        public Manage_Company()
        {
            InitializeComponent();
        }

        private void Manage_Company_Load(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from company where name = @name";
            cmd.CommandText = "delete from supplier where name = @name";
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update company set  /*id =@id,*/ name = @name, phone= @phone ,address= @address where name = @name1 ";
            cmd.Parameters.AddWithValue("@name1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("updated", "information" , MessageBoxButtons.OK , MessageBoxIcon.Information);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Company a = new Add_Company();
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
            cmd.CommandText = "select id , name , phone ,address from company where  name = @name";            
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //id
                textBox2.Text = dr[0].ToString();
                //name
                textBox3.Text = dr[1].ToString();
                //phone
                textBox4.Text = dr[2].ToString();
                //address
                textBox5.Text = dr[3].ToString();
              
            }
            else
            {
                dr.Close();
                MessageBox.Show("No data", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Home a = new Admin_Home();
            a.Show();
        }
    }
}
