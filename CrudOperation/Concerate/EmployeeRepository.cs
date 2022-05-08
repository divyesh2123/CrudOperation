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
        public bool EmployeeDelete(int employeeId)
        {
            using (EMSEntities eMS = new EMSEntities())
            {
                var myresullt = eMS.Employees.Where(y => y.ID == employeeId).FirstOrDefault();

                eMS.Employees.Remove(myresullt);

                var my =   eMS.SaveChanges() > 0 ? true : false;

                return my;



            }
        }

        public EmployeeDepartmentViewModel GetEmployeeByID(int employeeId)
        {

            using (EMSEntities eMS = new EMSEntities())
            {
                var myresult = eMS.Employees.Where(y => y.ID == employeeId).FirstOrDefault();

                



                return myresult.ToViewModel();


            }

        }

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

        public bool InsertUpdateEmployeeInfo(EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {

            using (EMSEntities eMS = new EMSEntities())
            {

                if (employeeDepartmentViewModel.EmployeeId == 0)
                {

                    var myResult = eMS.Employees.Add(employeeDepartmentViewModel.ToViewMode());

                    var myres = eMS.SaveChanges();

                    return myres > 0 ? true : false;

                }
                else
                {
                    var myme = eMS.Employees.Where(y => y.ID == employeeDepartmentViewModel.EmployeeId).FirstOrDefault();

                    myme.State = employeeDepartmentViewModel.State;
                    myme.City = employeeDepartmentViewModel.City;
                    myme.FirstName = employeeDepartmentViewModel.FirstName;
                    myme.LastName = employeeDepartmentViewModel.LastName;
                    myme.DepartmentID = employeeDepartmentViewModel.DepartmentId;
                    myme.ZipCode = employeeDepartmentViewModel.ZipCode;

                    return eMS.SaveChanges() > 0 ? true : false;


                }


            }

        }
    }
}