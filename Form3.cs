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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Course", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Course values (@Course_ID, @Course_Name, @Student_Name, @Teacher_Name, @Semester)", con);
            cmd.Parameters.AddWithValue("@Course_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Teacher_Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Student_Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Course_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Semester", textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Course WHERE Course_ID = @Course_ID AND Teacher_Name = @Teacher_Name AND Student_Name=@Student_Name AND Course_Name=@Course_Name AND Semester=@Semester", con);
            cmd.Parameters.AddWithValue("@Course_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Teacher_Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Student_Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Course_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Semester", textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE Course_ID =@Course_ID", con);
            cmd.Parameters.AddWithValue("@Course_ID", textBox1.Text);
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

                            string Teacher_Name = reader["Teacher_Name"].ToString();
                            string Student_Name = reader["Student_Name"].ToString();
                            string Course_Name = reader["Course_Name"].ToString();
                            string Semester = reader["Semester"].ToString();


                            textBox4.Text = Course_Name;
                            textBox3.Text = Student_Name;
                            textBox2.Text = Teacher_Name;
                            textBox5.Text = Semester;


                            Console.WriteLine($"COURSE Name: {Course_Name}, student_Name: {Student_Name}, Teacher_Name: {Teacher_Name}, Semester: {Semester}");
                        }
                    }
                    else
                    {

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


        private void button3_Click(object sender, EventArgs e)
        {
            string updatedCourseName = textBox2.Text;
            string updatedTeacherName = textBox3.Text;
            string updatedStudentName = textBox4.Text;
            string updatedSemester = textBox5.Text;

            UpdateCoursesData(textBox1.Text, updatedCourseName, updatedTeacherName, updatedStudentName, updatedSemester);
        }

        private void UpdateCoursesData(string courseID, string updatedCourseName, string updatedTeacherName, string updatedStudentName, string updatedSemester)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Course SET Course_Name = @Course_Name, Teacher_Name = @Teacher_Name, Student_Name = @Student_Name, Semester = @Semester WHERE Course_ID = @Course_ID", con);
            cmdUpdate.Parameters.AddWithValue("@Course_ID", courseID);
            cmdUpdate.Parameters.AddWithValue("@Course_Name", updatedCourseName);
            cmdUpdate.Parameters.AddWithValue("@Teacher_Name", updatedTeacherName);
            cmdUpdate.Parameters.AddWithValue("@Student_Name", updatedStudentName);
            cmdUpdate.Parameters.AddWithValue("@Semester", updatedSemester);

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

                    // Optionally, you can display a success message or perform additional actions
                    MessageBox.Show("Course data updated successfully");
                }
                else
                {
                    Console.WriteLine("No rows updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating course data: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
          
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();


            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();


            form2.Show();
        }



    }

}
