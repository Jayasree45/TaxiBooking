using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Diplays the Home Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Diplays the Contact Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Diplays the Register Page
        /// </summary>
        /// <returns></returns>

        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }


        /// <summary>
        /// Diplays the About Page
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your Aboutus page.";

            return View();
        }

        /// <summary>
        /// Diplays the Feedback Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Feedback()
        {
            ViewBag.Message = "Your Feedback page.";

            return View();
        }

        /// <summary>
        /// Diplays the Thank You Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Thankyou()
        {
            ViewBag.Message = "Your Thankyou page.";

            return View();
        }

       

    }
}