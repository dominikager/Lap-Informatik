using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormelOne.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Will redirect to RacePointers - preventing 404 if the HomeController is linked somewhere
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Index", "RacePoints");
        }
    }
}