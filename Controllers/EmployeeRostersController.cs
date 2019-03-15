using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using System.Data.SqlClient;

namespace Project.Controllers
{
    public class EmployeeRostersController : Controller
    {
        Training_12DecMumbaiEntities db = new Training_12DecMumbaiEntities();
        //private EmployeeRosterContext db = new EmployeeRosterContext();

        // GET: EmployeeRosters
        public ActionResult Index()
        {
            var employeeRosters = db.EmployeeRosters.Include(e => e.Employee);
            return View(employeeRosters.ToList());
        }

        // GET: EmployeeRosters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoster employeeRoster = db.EmployeeRosters.Find(id);
            if (employeeRoster == null)
            {
                return HttpNotFound();
            }
            return View(employeeRoster);
        }

        // GET: EmployeeRosters/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            return View();
        }

        // POST: EmployeeRosters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RosterID,FromDate,ToDate,InTime,OutTime,EmployeeID")] EmployeeRoster employeeRoster)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRosters.Add(employeeRoster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", employeeRoster.EmployeeID);
            return View(employeeRoster);
        }

        // GET: EmployeeRosters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoster employeeRoster = db.EmployeeRosters.Find(id);
            if (employeeRoster == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", employeeRoster.EmployeeID);
            return View(employeeRoster);
        }

        // POST: EmployeeRosters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RosterID,FromDate,ToDate,InTime,OutTime,EmployeeID")] EmployeeRoster employeeRoster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRoster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", employeeRoster.EmployeeID);
            return View(employeeRoster);
        }

        // GET: EmployeeRosters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRoster employeeRoster = db.EmployeeRosters.Find(id);
            if (employeeRoster == null)
            {
                return HttpNotFound();
            }
            return View(employeeRoster);
        }

        // POST: EmployeeRosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRoster employeeRoster = db.EmployeeRosters.Find(id);
            db.EmployeeRosters.Remove(employeeRoster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
