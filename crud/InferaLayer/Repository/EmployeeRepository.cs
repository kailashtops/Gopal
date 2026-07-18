using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using InferaLayer.Data;

namespace InferaLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBConnectionFactory _db;
        private readonly SqlConnection con;
        public EmployeeRepository(DBConnectionFactory db)
        {
            _db = db;
            con.ConnectionString= _db.CreateConnection();
        }
        public void AddEmployee(Employes employee)
        {
            
            using var cmd = new SqlCommand("sp_insert",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", employee.FirstName);
            cmd.Parameters.AddWithValue("@lname", employee.LastName);
            cmd.Parameters.AddWithValue("@joindate", employee.JoinDate);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@photo", employee.ProfileImagePath.FileName);
            cmd.Parameters.AddWithValue("@isactive", employee.IsActive);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public IEnumerable<Employes> GetAllEmployees()
        {
            var list = new List<Employes>();
            using var cmd = new SqlCommand("sp_select",con);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Employes
                {
                    Id = (int)reader["Id"],
                    FirstName = reader["fname"].ToString(),
                    LastName = reader["lname"].ToString(),
                    JoinDate = (System.DateTime)reader["joindate"],
                    Email = reader["email"].ToString(),
                    ExistingProfileImagePath = reader["photo"].ToString(),
                    IsActive= Convert.ToBoolean(reader["isactive"].ToString())
                });
            }
            return list;
        }
    }
}
