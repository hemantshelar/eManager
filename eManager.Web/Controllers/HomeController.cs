using eManager.Domain;
using eManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        IDepartmentDataSource _departmentSource = new DepartmentDb();

        public HomeController(IDepartmentDataSource departmentSource)
        {
            _departmentSource = departmentSource;
        }
        public ActionResult Index()
        {
            var result  = _departmentSource.Departments.ToList<Department>();
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}