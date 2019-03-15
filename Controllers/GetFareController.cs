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
        //public static readonly Random random = new Random();
        //public static int DisplayFare(int min, int max)
        //{
        //    int r = random.Next(min,max);
        //    return r;
        //}



        public ActionResult DisplayFare()
        {
            Random random = new Random();
            random.Next(1520, 2563);

         

            return View(random);

        }

    }
}