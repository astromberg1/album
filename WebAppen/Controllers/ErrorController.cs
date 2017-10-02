using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppen.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {
        [AllowAnonymous]

        // GET: Error
        public ActionResult Error()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult InternalError()
        {
            return View();
        }
    }
}