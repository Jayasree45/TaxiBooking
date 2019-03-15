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
    public class BookingsController : Controller
    {
        Training_12DecMumbaiEntities db = new Training_12DecMumbaiEntities();
        //private BookingContext db = new BookingContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }
        //public ActionResult Display()
        //{
        //    using (var context = new Training_12DecMumbaiEntities())
        //    {var query= from st in context.Customers where st.CustomerName=="anusha" select st}


        //        return View();
        //}

   
        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.TaxiID = new SelectList(db.Taxis, "TaxiID", "TaxiModel");
            ViewBag.SourceAddress = new SelectList(db.Bookings, "BookingID", "SourceAddress");
            ViewBag.DestinationAddress = new SelectList(db.Bookings, "BookingID", "DestinationAddress");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,TaxiID,CustomerID,BookingDate,TripDate,StartTime,EndTime,SourceAddress,DestinationAddress")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", booking.CustomerID);
            ViewBag.TaxiID = new SelectList(db.Taxis, "TaxiID", "TaxiModel", booking.TaxiID);
            return View(booking);
        }

        //// GET: Bookings/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Booking booking = db.Bookings.Find(id);
        //    if (booking == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", booking.CustomerID);
        //    ViewBag.TaxiID = new SelectList(db.Taxis, "TaxiID", "TaxiModel", booking.TaxiID);
        //    return View(booking);
        //}

        //// POST: Bookings/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BookingID,TaxiID,CustomerID,BookingDate,TripDate,StartTime,EndTime,SourceAddress,DestinationAddress")] Booking booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(booking).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", booking.CustomerID);
        //    ViewBag.TaxiID = new SelectList(db.Taxis, "TaxiID", "TaxiModel", booking.TaxiID);
        //    return View(booking);
        //}

        //// GET: Bookings/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Booking booking = db.Bookings.Find(id);
        //    if (booking == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(booking);
        //}

        //// POST: Bookings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Booking booking = db.Bookings.Find(id);
        //    db.Bookings.Remove(booking);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult BookCab()
        {
            ViewBag.Message = "Your Admin page.";

            return View();
        }
        public ActionResult success()
        {
            ViewBag.Message = "You Have Booked Successfully";
            return View();
        }

        public ActionResult Cars()
        {
            return View();
        }

        [HttpPost]
        public ActionResult trail(trail model)
        {
            trail trail1 = new trail();
            List<trail> items;
            if (Session["items"] == null)
            {
                items = new List<trail>();
                items.Add(model);
                Session.Add("items", items);
            }
            else
            {
                items = Session["items"] as List<trail>;
                items.Add(model);
                Session["items"] = items;
            }
            return View();
        }
    }
}
