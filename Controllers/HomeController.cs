using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your Aboutus page.";

            return View();
        }

        public ActionResult Feedback()
        {
            ViewBag.Message = "Your Feedback page.";

            return View();
        }

        public ActionResult Thankyou()
        {
            ViewBag.Message = "Your Thankyou page.";

            return View();
        }
        public ActionResult RegUser()
        {
            ViewBag.Message = "Your user page.";

            return View();
        }

        public ActionResult RegAdmin()
        {
            ViewBag.Message = "Your Admin page.";

            return View();
        }

        public ActionResult Inspect()
        {
            return View();
        }
      
    }
}