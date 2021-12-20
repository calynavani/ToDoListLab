using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class EmployeeTaskViewModel
    {
        //A view model is a model created specifically only to exist on views
        //they're used to show off multiple model classes at once, or to move around small pieces of data from the controller to the view

        public List<ToDo> ToDos { get; set; } 
        public List<Employee> Employees { get; set; }

        public EmployeeTaskViewModel()
        {
            //We will use both our DAL's to fill out this model
            ToDoDAL tdDAL = new ToDoDAL();
            EmployeeDAL eDAL = new EmployeeDAL();
            ToDos = tdDAL.GetToDos();
            Employees = eDAL.GetEmployees();

        }
    }
}
