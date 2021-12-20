using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class EmployeeDAL
    {
        //Get CRUD actions working
     
        
        public List<Employee> GetEmployees()
        {
            using(var connect = new MySqlConnection(Secret.connection))
            {
                string sql = "select * from employee";
                connect.Open();
                List<Employee> employees = connect.Query<Employee>(sql).ToList();
                connect.Close();
                return employees;

            }
            
        }
        public Employee GetEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = "select * from employee where id=" +id;
                connect.Open();
                Employee employee = connect.Query<Employee>(sql).ToList().First();
                connect.Close();
                return employee;

            }
        }
        public void AddEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"insert into employee values(0, '{e.Name}', {e.HoursAvailible}, '{e.Title}')";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }

        }

        public void UpdateEmployee(Employee e)
        {
            using(var connect = new MySqlConnection(Secret.connection))
            {
                string sql = "update employee " +
                    $"set `Name`= '{e.Name}', HoursAvailible={e.HoursAvailible}, Title={e.Title}" +
                    $" where id={e.Id} ";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = "delete from employee where id=" + id;
                string sql2 = "delete from assignments where employeeId=" + id;
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

    }
}
