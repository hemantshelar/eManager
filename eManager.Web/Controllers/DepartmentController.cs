using eManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentDataSource departmentDataSource = null;

        public DepartmentController(IDepartmentDataSource departmentDataSource)
        {
            this.departmentDataSource = departmentDataSource;
        }


        // GET: Department
        public ActionResult Detail(int id)
        {
            var model = this.departmentDataSource.Departments.Where(d => d.Id == id).FirstOrDefault();

            return View(model);
        }
    }
}