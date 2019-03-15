using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    //[Authorize(Roles =("Admin,Driver"))]
    public class TaxisController : Controller
    {
        private TaxiContext db = new TaxiContext();

        // GET: Taxis
        public ActionResult Index()
        {
            return View(db.Taxis.ToList());
        }

        // GET: Taxis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taxi taxi = db.Taxis.Find(id);
            if (taxi == null)
            {
                return HttpNotFound();
            }
            return View(taxi);
        }

        // GET: Taxis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taxis/Create
        /// <summary>
        /// Registering Taxi
        /// </summary>
        /// <param name="taxi"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaxiID,TaxiModel,Color,RegisterNumber,TaxiType")] Taxi taxi)
        {
            if (ModelState.IsValid)
            {
                db.Taxis.Add(taxi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taxi);
        }

        /// <summary>
        /// Updating Taxi Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Taxis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taxi taxi = db.Taxis.Find(id);
            if (taxi == null)
            {
                return HttpNotFound();
            }
            return View(taxi);
        }

        // POST: Taxis/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaxiID,TaxiModel,Color,RegisterNumber,TaxiType")] Taxi taxi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taxi);
        }

        /// <summary>
        /// Delete Taxi Based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Taxis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taxi taxi = db.Taxis.Find(id);
            if (taxi == null)
            {
                return HttpNotFound();
            }
            return View(taxi);
        }

        // POST: Taxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Taxi taxi = db.Taxis.Find(id);
            db.Taxis.Remove(taxi);
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
