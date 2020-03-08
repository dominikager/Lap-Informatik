using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormelOne.Controllers
{
    public class BaseController : Controller, IDisposable
    {
        public UnitOfWork UnitOfWork = new UnitOfWork();

        /// <summary>
        /// Remove this instance from the memory
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