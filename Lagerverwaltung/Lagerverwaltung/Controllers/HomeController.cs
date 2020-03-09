using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lagerverwaltung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // To Prevent 404 it redirects to Main part of Application
            return RedirectToAction("Index", "Processes");
        }
    }
}