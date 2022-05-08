using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CrudOperation.Interface
{
    

   /// <summary>
   /// 
   /// </summary>
    public interface IDepartmentRepositroy
    {
        /// <summary>
        ///  This will get information of department
        /// </summary>
        /// <returns>this is will return list of department</returns>
         List<SelectListItem> GetDapartments();
    }
}
