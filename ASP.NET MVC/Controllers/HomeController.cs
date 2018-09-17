using ASP.NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private ProjectDatabaseEntities db = new ProjectDatabaseEntities();

        public ActionResult Index()
        {
            return View(db.DanhSachPhims.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}