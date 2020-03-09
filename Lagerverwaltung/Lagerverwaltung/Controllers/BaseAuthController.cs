using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lagerverwaltung.Controllers
{
    /// <summary>
    /// Extending BaseController to have the same UnitOfWork Instance
    /// Add Authorize Tag so only logged in persons can access this controller
    /// </summary>
    [Authorize]
    public class BaseAuthController : BaseController
    {
    }
}