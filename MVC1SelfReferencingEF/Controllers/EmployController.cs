using MVC1SelfReferencingEF.context;
using MVC1SelfReferencingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1SelfReferencingEF.Controllers
{
    public class EmployController : Controller
    {
        EmployeeContext context = new EmployeeContext();

        // GET: Employ
        public ActionResult Index()
        {
            List<Employee> emps = new List<Employee>();

            emps = context.Employees.OrderBy(e => e.ManagerID).ToList();

            return View(emps);
        }

        public ActionResult DisplayTree()
        {
            EmployeeContext context = new EmployeeContext();

            List<Employee> emps = new List<Employee>();

            emps = context.Employees.OrderBy(e => e.ManagerID).ToList();

            return View(emps);
        }
        // GET: Employ/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employ/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employ/Edit/5
        public ActionResult Edit(int id)
        {
            var query = context.Employees
                .Where(s => s.EmployeeID == id)
                .FirstOrDefault();

            return View(query);
        }

        // POST: Employ/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var query = context.Employees
                .Where(s => s.EmployeeID == id)
                .FirstOrDefault();

                query.EmployeeName = collection["EmployeeName"];
                query.ManagerID = Int32.Parse(collection["ManagerID"]);
                

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employ/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employ/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
