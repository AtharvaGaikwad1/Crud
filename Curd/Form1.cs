using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ATHARVA-PC;Initial Catalog=Crud;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO reallylast values (@id,@Name,@Subject)",con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id",textBox1.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Subject", textBox3.Text);
          
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("New Data is registerred ");
            getAttendanceData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getAttendanceData();
        }

        private void getAttendanceData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ATHARVA-PC;Initial Catalog=Crud;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from reallylast", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
