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
            TempData["Attend_msg"] = "新增成功";
            return RedirectToAction("Home");
        }
        public ActionResult Edit(int? id)
        {
            tEmployee x = db.tEmployees.Where(p => p.fEmployeeId == id).FirstOrDefault();

            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(tEmployee t)
        {
            tEmployee x = db.tEmployees.Where(f => f.fEmployeeId == t.fEmployeeId).FirstOrDefault();
            if (x == null)
            {
                TempData["Attend_msg"] = "編輯失敗";
                return RedirectToAction("Home");
            }
            else
            {
                x.fName = t.fName;
                x.fIdent = t.fIdent;
                x.fPassword = t.fPassword;
                x.fDepartment = t.fDepartment;
                TempData["Attend_msg"] = "編輯成功";
                return RedirectToAction("Home");
            }
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
                TempData["Attend_msg"] = "刪除成功";
            }

            return RedirectToAction("Home");
        }



    }
}