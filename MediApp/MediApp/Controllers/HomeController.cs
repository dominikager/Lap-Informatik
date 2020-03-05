using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediApp.Controllers
{
    /// <summary>
    /// Extends the BaseAuthController for UnitOfWork and Authorize
    /// </summary>
    public class HomeController : BaseAuthController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Visits"); // TODO remove HomeController everywhere - this is just because of no time
        }
    }
}