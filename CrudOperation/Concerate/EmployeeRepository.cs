using CrudOperation.Data;
using CrudOperation.Interface;
using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudOperation.Helper;

namespace CrudOperation.Concerate
{
    public class EmployeeRepository : IEmployeeRepository

    {
        public List<EmployeeDepartmentViewModel> GetEmployeeInfo()
        {
            List<EmployeeDepartmentViewModel> employees = new List<EmployeeDepartmentViewModel>();
            using (EMSEntities eMS = new EMSEntities() )
            {
                var myResult = eMS.Employees.ToList();

                var myDepartment = eMS.Depts.ToList();

                employees = myResult.Join(myDepartment, y => y.DepartmentID, x => x.ID, (x, y) => new EmployeeDepartmentViewModel()
                {
                    City = x.City,
                    State = x.State,
                    FullName = x.FirstName + "" + x.LastName,
                    EmployeeId = x.ID,
                    ZipCode = x.ZipCode,
                    DepartmentId = x.DepartmentID.Value,
                    DepartmentName = y.DepartmentName
                    


                }).ToList();





            }

            return employees;
        }

        public bool InsertEmployeeInfo(EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {

            using (EMSEntities eMS = new EMSEntities())
            {

                var myResult = eMS.Employees.Add(employeeDepartmentViewModel.ToViewMode());

                var myres = eMS.SaveChanges();

                return myres > 0 ? true : false;

            }

        }
    }
}