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
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
        }

        private void Store_Load(object sender, EventArgs e)
        {
      
            string constring = "server=HATEM_11120\\SQLEXPRESS; database=last_pharmacy; trusted_connection=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from medicine ", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
