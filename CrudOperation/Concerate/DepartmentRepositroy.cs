using CrudOperation.Data;
using CrudOperation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CrudOperation.Helper;

namespace CrudOperation.Concerate
{
    public class DepartmentRepositroy : IDepartmentRepositroy
    {
        public List<SelectListItem> GetDapartments()
        {
            using (EMSEntities em = new EMSEntities())
            {
                var myresult = em.Depts.ToList().ToViewModel();

                return myresult;
            }

        }
    }
}
