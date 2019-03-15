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
    [Authorize]
    public class BookingsController : Controller
    {
        Training_12DecMumbaiEntities db = new Training_12DecMumbaiEntities();
        
        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }

        public ActionResult Index1()
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }
        /// <summary>
        /// Different fare For Different Models of Car
        /// </summary>
        /// <returns></returns>
        public ActionResult Cars()
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }

        public ActionResult IndexForSedan()
        {
           
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }

        public ActionResult IndexForSVU()
        {
          
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }

        public ActionResult IndexForHatchAC()
        {
            
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }

        public ActionResult IndexForSedan5()
        {
           
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }

        public ActionResult IndexSuzuki3()
        {
           
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }


        public ActionResult thankyou()
        {
          
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Taxi);
            return View(bookings.ToList());
        }


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
            //ViewBag.SourceAddress = new SelectList(db.Bookings, "BookingID", "SourceAddress");
            //ViewBag.DestinationAddress = new SelectList(db.Bookings, "BookingID", "DestinationAddress");
            return View();
        }
        /// <summary>
        /// Booking the Cab
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        // POST: Bookings/Create
        
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
