using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autorennstall.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork UnitOfWork = new UnitOfWork();

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