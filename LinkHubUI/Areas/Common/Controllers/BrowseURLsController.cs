using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLsController : Controller
    {
        private UrlBs objBs;

        public BrowseURLsController()
        {
            objBs = new UrlBs();
        }

        // GET: Common/BrowseURLs
        public ActionResult Index(String SortOrder, String SortBy, String Page)
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
            ViewBag.TotalPages = Math.Ceiling(objBs.GetAll().Where(x => x.IsApproved == "A").Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            //page number is needed in order to highlight the page
            ViewBag.Page = page;


            //urls contaiins a list of objects of all the urls in the db, we use the page number to extract display the revelant 
            //number of pages
            //if page == 2, 2 - 1 = 1 * 10 = 10, skip the first 10 records and take next 10

            urls.ToList();
            int elementCount = (page - 1 ) * 10;

            List<BOL.tbl_Url> returnedURLs = new List<BOL.tbl_Url>(urls.Count());
            int internalCount = 0;

            for(int i = elementCount; internalCount < 10 && i < urls.Count() ; i++, internalCount++)
            {
                if(urls.ElementAt(i) != null)
                    returnedURLs.Add(urls.ElementAt(i));
            }
            //urls = urls.Skip((page - 1) * 10).Take(10);

            return View(returnedURLs);
        }
    }
}
    
