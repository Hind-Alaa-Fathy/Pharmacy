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
    public partial class Add_Customer : Form
    {
        public Add_Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text == "" && textBox3.Text == "" )
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
                cmd.CommandText = " insert into customer ( name ,phone ) values(@name ,@phone)";

                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
          
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("done", "information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                textBox2.Text = " "; textBox3.Text = " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
