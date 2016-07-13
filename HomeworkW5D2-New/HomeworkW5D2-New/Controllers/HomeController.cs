using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkW5D2_New.Controllers
{
    public class HomeController : Controller
    {
        AlbumHomeworkDBEntities DB = new AlbumHomeworkDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PWHATI2()
        {
            ViewBag.Message = "an album db";

            return View(DB.AlbumTables.ToList());
        }

        public ActionResult forms()
        {
            ViewBag.Message = "Contact me at anemail@emailaddresses.com";

            return View();
        }

        public ActionResult Albums()
        {
            ViewBag.Message = "the real good stufff is here!!!";

            return View();
        }

        public ActionResult PageWhatHasAllTheInfo()
        {
            ViewBag.Message = "the real good stufff is here!!!";
            //var artistsvar = DB.ArtistTables.ToList();
            return View(DB.ArtistTables.ToList());
        }
    }
}