using CrudOperation.Data;
using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOperation.Helper
{
    static class Helper
    {
        public static Employee ToViewMode(this EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            Employee employee = new Employee();

            employee.City = employeeDepartmentViewModel.City;
            employee.State = employeeDepartmentViewModel.State;
            employee.DepartmentID = employeeDepartmentViewModel.DepartmentId;
            employee.FirstName = employeeDepartmentViewModel.FirstName;
            employee.LastName = employeeDepartmentViewModel.LastName;
            employee.DepartmentID = employeeDepartmentViewModel.DepartmentId;
            employee.ZipCode = employeeDepartmentViewModel.ZipCode;


            return employee;

        }
    }
}