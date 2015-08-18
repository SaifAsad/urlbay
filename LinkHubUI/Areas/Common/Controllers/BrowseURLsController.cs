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
        public ActionResult Index(String SortOrder, String SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var urls = objBs.GetAll().Where(x => x.IsApproved == "A").ToList();

            switch (SortBy)
            {
                case "Title":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlTitle).ToList();
                            break;

                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "Category":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlTitle).ToList();
                            break;

                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "Url":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;

                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "UrlDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;

                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
            }
            return View(urls);
        }
    }
}
    
