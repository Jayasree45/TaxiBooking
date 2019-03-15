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
    public class CustomersController : Controller
    {
        Training_12DecMumbaiEntities db = new Training_12DecMumbaiEntities();
        
        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }



        // GET: Customers/Create
        [AllowAnonymous]
        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Registration Of Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        // POST: Customers/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,Password,ConfirmPassword,PhoneNumber,EmailID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

       /// <summary>
       /// Release memory of deleted Customers
       /// </summary>
       /// <param name="disposing"></param>
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
