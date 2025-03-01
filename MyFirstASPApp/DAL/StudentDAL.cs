using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyFirstASPApp.DAL
{
    public class StudentDAL
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;



        public DataTable GetAllStudents()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = "SELECT Id, Name, DOB, Stream FROM Students";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2) Insert a New Student
        public void InsertStudent(string name, DateTime dob, string stream)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = "INSERT INTO Students (Name, DOB, Stream) VALUES (@Name, @DOB, @Stream)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@Stream", stream);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 3) Update an Existing Student
        public void UpdateStudent(int id, string name, DateTime dob, string stream)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = "UPDATE Students SET Name=@Name, DOB=@DOB, Stream=@Stream WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@Stream", stream);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 4) Delete a Student
        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = "DELETE FROM Students WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}