using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(0,40, ErrorMessage ="Hours can not exceed 40!")]
        public float HoursAvailible { get; set; }
        [MaxLength(40)]
        public string Title { get; set; }

        ////We want a property to represent all todos assigned to this employee
        //public List<ToDo> ToDos { get; set; }

       
    }
}
