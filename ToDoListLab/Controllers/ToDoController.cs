using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListLab.Models;

namespace ToDoListLab.Controllers
{
    public class ToDoController: Controller
    {
        ToDoDAL tddb = new ToDoDAL();
        EmployeeDAL eDAL = new EmployeeDAL();
        public IActionResult Index()
        {
            EmployeeTaskViewModel etvm = new EmployeeTaskViewModel();
            return View(etvm);
        }
        public IActionResult CreateToDo()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateToDo(ToDo td)
        {
            if(ModelState.IsValid)
            {
                tddb.AddToDo(td);
                return RedirectToAction("Index", "ToDo");
            }
            else
            {
                return View(td);
            }
        }

        public IActionResult Results(ToDo  td)
        {
            return View(td);
        }

        public IActionResult AssignTask()
        {
            EmployeeTaskViewModel em = new EmployeeTaskViewModel();
            return View(em);
        }

        [HttpPost]
        public IActionResult AssignTask(int toDoId, int employeeId)
        {
            Assignment a = new Assignment();
            a.EmployeeId = employeeId;
            a.ToDoId = toDoId;
            AssignmentDAL ad = new AssignmentDAL();
            ad.CreateAssignment(a);
            return RedirectToAction("Index", "Employee");
        }
    }
}
