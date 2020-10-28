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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tEmployee t)
        {
            db.tEmployees.Add(t);
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                int DeleteId = Convert.ToInt32(id);
                tEmployee x = db.tEmployees.FirstOrDefault(p => p.fEmployeeId == DeleteId);
                if (x != null)
                {
                    db.tEmployees.Remove(x);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Home");
        }



    }
}