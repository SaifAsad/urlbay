using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLsController : Controller
    {
        private UrlBs objBs;

        public BrowseURLsController()
        {
            objBs = new UrlBs();
        }

        // GET: Common/BrowseURLs
        public ActionResult Index()
        {
            var urls = objBs.GetAll().Where(x=>x.IsApproved=="A").ToList();
            return View(urls);
        }
    }
}