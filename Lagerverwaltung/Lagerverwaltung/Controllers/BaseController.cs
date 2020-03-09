using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lagerverwaltung.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Create UnitOfWork Instance
        /// </summary>
        protected UnitOfWork UnitOfWork = new UnitOfWork();

        /// <summary>
        /// Removes the Instance from the memory
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}