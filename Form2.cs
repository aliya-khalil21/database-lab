using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace LAB2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@RegistrationNumber, @Name, @Department, @Session, @Address)", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox2.Text);
            cmd.Parameters.AddWithValue("@Session", textBox4.Text);
            cmd.Parameters.AddWithValue("@Department", textBox3.Text);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Address",textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
                
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RegistrationNumber = @RegistrationNumber AND Session = @Session AND Department = @Department AND Name = @Name AND Address = @Address", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox2.Text);
            cmd.Parameters.AddWithValue("@Session", textBox4.Text);
            cmd.Parameters.AddWithValue("@Department", textBox3.Text);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            string updatedName = textBox1.Text;
            string updatedDepartment = textBox3.Text;
            string updatedSession = textBox4.Text;
            string updatedAddress = textBox5.Text;

            
            UpdateStudentData(textBox2.Text, updatedName, updatedDepartment, updatedSession, updatedAddress);
        }

        
        private void UpdateStudentData(string registrationNumber, string updatedName, string updatedDepartment, string updatedSession, string updatedAddress)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Student SET Name = @Name, Department = @Department, Session = @Session, Address = @Address WHERE RegistrationNumber = @RegistrationNumber", con);
            cmdUpdate.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);
            cmdUpdate.Parameters.AddWithValue("@Name", updatedName);
            cmdUpdate.Parameters.AddWithValue("@Department", updatedDepartment);
            cmdUpdate.Parameters.AddWithValue("@Session", updatedSession);
            cmdUpdate.Parameters.AddWithValue("@Address", updatedAddress);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                int rowsAffected = cmdUpdate.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data updated successfully");

                   
                    MessageBox.Show("Data updated successfully");
                }
                else
                {
                    Console.WriteLine("No rows updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating data: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE RegistrationNumber = @RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox2.Text);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Retrieve data from the database
                            string Name = reader["Name"].ToString();
                            string Department = reader["Department"].ToString();
                            string Session = reader["Session"].ToString();
                            string Address = reader["Address"].ToString();

                            // Populate textboxes with retrieved data
                            textBox4.Text = Session;
                            textBox3.Text = Department;
                            textBox1.Text = Name;
                            textBox5.Text = Address;

                            // Add debugging output to check retrieved values
                            Console.WriteLine($"Name: {Name}, Department: {Department}, Session: {Session}, Address: {Address}");
                        }
                    }
                    else
                    {
                        // No data found for the specified RegistrationNumber
                        MessageBox.Show("No data found for the specified RegistrationNumber");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; ;
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();


            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form2 = new Form3();


            form2.Show();
        }

    }
}
