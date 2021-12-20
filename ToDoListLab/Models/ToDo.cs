using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public float HoursNeeded { get; set; }
        public bool IsCompleted { get; set; }

        ////Since this is a many to many relationship, we need to put in a property for Employee
        public List<Employee> Employee { get; set; }
    }
}
