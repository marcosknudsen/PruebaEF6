using PruebaEF6.Models;
using PruebaEF6.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PruebaEF6.Controllers
{
    public class HomeController : Controller
    {
        private PlayerRepository playerRepository=new PlayerRepository();
        public ActionResult Index()
        {
            return View();
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