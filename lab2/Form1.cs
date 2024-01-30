using CRUD_Operations;
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

namespace LAB2
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Enrollments values (@Student_Name,@Course_Name)", con);
            cmd.Parameters.AddWithValue("@Student_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Course_Name", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Enrollments", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Enrollments", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Enrollments WHERE Student_Name = @Student_Name AND Course_Name = @Course_Name", con);
            cmd.Parameters.AddWithValue("@Student_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Course_Name", textBox2.Text);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted");
                }
                else
                {
                    MessageBox.Show("No rows deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting data: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form2 = new Form3();


            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();


            form2.Show();
        }
    }
}
