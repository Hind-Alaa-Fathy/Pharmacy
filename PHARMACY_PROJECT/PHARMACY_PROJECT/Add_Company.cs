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
    public partial class Add_Company : Form
    {
        public Add_Company()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
           
            if (textBox1.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("check your information", "confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string constring = @"server=HATEM_11120\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = " insert into company ( name , phone ,address ) values(@name,@phone ,@address)";

                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@address", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("done", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = " "; textBox3.Text = " "; textBox4.Text = " ";
            

           
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Home a = new Admin_Home();
            a.Show();
        }
    }
}
