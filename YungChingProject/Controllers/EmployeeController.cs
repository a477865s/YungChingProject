using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProject.Models;

namespace YungChingProject.Controllers
{
    public class EmployeeController : Controller
    {
        ExampleEntities db = new ExampleEntities();

        // GET: Employee
        public ActionResult Home()
        {
            var prj = db.tEmployees.ToList();
            return View(prj);
        }
    }
}