using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCApp.Models;

namespace MVCApp.DAL
{
    public class DBOperation
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public List<StData> GetStudentList()
        {
            List<StData> studentList = new List<StData>();
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM student", con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StData student = new StData();
                    student.Id = Convert.ToInt32(reader["id"]);
                    student.Name = reader["name"].ToString();
                    student.LastName = reader["lname"].ToString();
                    studentList.Add(student);
                }
                con.Close();
            }
            return studentList;
        }

        public void AddStudent(StData student)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO student (name, lname) VALUES (@name, @lname)", con);

                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@lname", student.LastName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM student WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public StData GetById(int id) {


            StData stData = new StData();
            using (SqlConnection con = new SqlConnection(conn)) {
                SqlCommand cmd = new SqlCommand("Select * from student where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read()) {
                    stData.Name = sqlDataReader["name"].ToString();
                    stData.LastName = sqlDataReader["lname"].ToString();
                }
            }
            return stData;
        }

        public void UpdateStudent(StData student) {
            using (SqlConnection con = new SqlConnection(conn)) {
                SqlCommand cmd = new SqlCommand("Update student set name=@name, lname=@lname where id=@id", con);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@lname", student.LastName);
                cmd.Parameters.AddWithValue("@id", student.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Register(UserRegistration userRegistration)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_reg (email, username, password, address) VALUES (@Email, @Username, @Password, @Address)", con);
                cmd.Parameters.AddWithValue("@UserName", userRegistration.UserName);
                cmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                cmd.Parameters.AddWithValue("@Email", userRegistration.Email);
                cmd.Parameters.AddWithValue("@Address", userRegistration.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public bool Login(UserLogin userLogin)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_reg WHERE username=@UserName AND password=@Password", con);
                cmd.Parameters.AddWithValue("@UserName", userLogin.UserName);
                cmd.Parameters.AddWithValue("@Password", userLogin.Password);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                return count > 0;
            }
        }
    }
}