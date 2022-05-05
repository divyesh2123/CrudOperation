using CrudOperation.Concerate;
using CrudOperation.Interface;
using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();

            var myResult = employeeRepository.GetEmployeeInfo();


            return View(myResult);
        }

        public ActionResult Create()
        {
            EmployeeDepartmentViewModel employeeDepartmentViewModel = new EmployeeDepartmentViewModel();

          

                return View(employeeDepartmentViewModel);
        }

        [HttpPost]
        public ActionResult Create(EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();

            var myResult = employeeRepository.InsertEmployeeInfo(employeeDepartmentViewModel);

            if(myResult)
            {

                return RedirectToAction("Index");
            }


        }
    }
}