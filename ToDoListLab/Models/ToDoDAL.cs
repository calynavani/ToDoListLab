using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class ToDoDAL
    {
        public List<ToDo> GetToDos()
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = "select * from todo";
                connect.Open();
                List<ToDo> toDos = connect.Query<ToDo>(sql).ToList();
                connect.Close();
                return toDos;

            }

        }
        public ToDo GetToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = "select * from todo where id=" + id;
                string sql2 =
                connect.Open();
                ToDo toDo = connect.Query<ToDo>(sql).ToList().First();
                connect.Close();
                return toDo;

            }
        }
        public void AddToDo(ToDo t)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string sql = $"insert into todo values(0, '{t.Name}', {t.HoursNeeded}, {t.IsCompleted})";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }

        }

    }
}
