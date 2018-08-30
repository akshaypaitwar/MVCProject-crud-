using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MVCDemo.Models
{
    public class SqlDataHelper
    {
        public Employee GetEmployeeData(int id)
        {
            Employee emp = new Employee();
             string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
           // string cs = "data source=.;database=master;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select Id,Name,Gender from Employee where Id= "+id , con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                emp.Id = Convert.ToInt32( reader["Id"].ToString());
                emp.Name = reader["Name"].ToString();
                emp.Gender = reader["Gender"].ToString();
            }
            return emp;
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employee = new List<Employee>();
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            // string cs = "data source=.;database=master;integrated security=true;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select Id,Name,Gender from Employee", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(reader["Id"].ToString());
                emp.Name = reader["Name"].ToString();
                emp.Gender = reader["Gender"].ToString();
                employee.Add(emp);
            }
            return employee;
        }
        public void InsertEmployee(Employee employees)
        {
            Employee emp = new Employee();
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            
            SqlCommand cmd = new SqlCommand("usp_InsertEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", employees.Name);
            cmd.Parameters.AddWithValue("@Gender", employees.Gender);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
    }
}