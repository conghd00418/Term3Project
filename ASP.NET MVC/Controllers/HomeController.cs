﻿using ASP.NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private ProjectDatabaseEntitiesFinal db = new ProjectDatabaseEntitiesFinal();

        public ActionResult Index()
        {
            var danhsachphim = db.DanhSachPhims.ToList();
            return View(danhsachphim);
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