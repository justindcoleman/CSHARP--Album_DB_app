using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkW5D2_New.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Artists()
        {
            ViewBag.Message = "an album db";

            return View();
        }

        public ActionResult Genres()
        {
            ViewBag.Message = "Contact me at anemail@emailaddresses.com";

            return View();
        }

        public ActionResult Albums()
        {
            ViewBag.Message = "the real good stufff is here!!!";

            return View();
        }
    }
}