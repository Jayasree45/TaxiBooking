using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;


namespace Project.Controllers
{
    public class GetFareController : Controller
    {
        // GET: GetFair
        public ActionResult Index()
        {
           return View();
        }
      
        
        public ActionResult DisplayFare()
        {
            return View();

        }

    }
}