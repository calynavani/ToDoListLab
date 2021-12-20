using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListLab.Models;

namespace ToDoListLab.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL dbEmployee = new EmployeeDAL();
        ToDoDAL dbToDo = new ToDoDAL();

        public IActionResult Index()
        {
            EmployeeTaskViewModel etvm = new EmployeeTaskViewModel();       
            return View(etvm);
        }

        public IActionResult Details(int id)
        {
            Employee e = dbEmployee.GetEmployee(id);
            return View(e);
        }

        public IActionResult CreateEmployee()
        {

            return View();
        }


        [HttpPost]
        public IActionResult CreateEmployee(Employee e)
        {
            if(ModelState.IsValid)
            {
                dbEmployee.AddEmployee(e);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(e);
            }
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee e = dbEmployee.GetEmployee(id);
            return View(e);
        }

        [HttpPost]

        public IActionResult UpdateEmployee(Employee e)
        {
            dbEmployee.UpdateEmployee(e);
            return RedirectToAction("Index", "Employee");
        }

        public IActionResult DeleteEmployee(int id)
        {
            dbEmployee.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
