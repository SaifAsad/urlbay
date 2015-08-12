using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLsController : Controller
    {
        // GET: Common/BrowseURLs
        public ActionResult Index()
        {
            return View();
        }
    }
}