using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppen.Controllers
{ 
  [AllowAnonymous]
    public class StartController : Controller
    {
        // GET: Start
        public ActionResult Index()
        {
            return View();
        }
    }
}