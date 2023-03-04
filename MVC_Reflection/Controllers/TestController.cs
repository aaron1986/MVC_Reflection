using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Reflection.Models;

namespace MVC_Reflection.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            using (DBEntities6 db = new DBEntities6())
            {
                List<Employee> employees = db.Employees.ToList();
                List<Company> companies = db.Companies.ToList();

                var result = from emp in employees
                             join comp in companies on emp.DeptId equals comp.DeptId into table1
                             select new ViewModel
                             {
                                 employee = emp,
                             };

                return View(result);
            }
        }
    }
}