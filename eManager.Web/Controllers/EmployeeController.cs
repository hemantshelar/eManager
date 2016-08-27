using eManager.Domain;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        IDepartmentDataSource _departmentDataSource = null;

        public EmployeeController(IDepartmentDataSource departmentDataSource)
        {
            _departmentDataSource = departmentDataSource;
        }


        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeVM();
            model.DepartmentId = departmentId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeVM employee)
        {

            if (ModelState.IsValid == false)
            {
                View(employee);
            }

            var department = _departmentDataSource.Departments.Where(d => d.Id == employee.DepartmentId).First();

            Employee newEmployee = new Employee
            {
                Name = employee.Name,
                HireDate = employee.HireDate
            };

            department.Employees.Add(newEmployee);
            _departmentDataSource.Save();

            return RedirectToAction("Detail", "Department", new  { id = employee.DepartmentId});
        }
    }
}