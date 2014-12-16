using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoSite.Controllers
{
    public class LController : Controller
    {
        // GET: L
        public ActionResult Index(string i)
        {
            return RedirectToAction("Display", "Home",new {shortUrl=i});
        }
    }
}