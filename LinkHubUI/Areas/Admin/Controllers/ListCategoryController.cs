using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListCategoryController : Controller
    {
        private CategoryBs objBs;

        public ListCategoryController()
        {
            objBs = new CategoryBs();
        }

        // GET: Admin/ListCategory
        public ActionResult Index(String SortOrder, String SortBy, String Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var categories = objBs.GetAll().ToList();

            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryName).ToList();
                            break;

                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryName).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryDesc).ToList();
                            break;

                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    categories = categories.OrderBy(x => x.CategoryName).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.GetAll().Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            //page number is needed in order to highlight the page
            ViewBag.Page = page;


            //categories contaiins a list of objects of all the categories in the db, we use the page number to extract display the revelant 
            //number of pages
            //if page == 2, 2 - 1 = 1 * 10 = 10, skip the first 10 records and take next 10

            categories.ToList();
            int elementCount = (page - 1) * 10;

            List<BOL.tbl_Category> returnedCategories = new List<BOL.tbl_Category>(categories.Count());
            int internalCount = 0;

            for (int i = elementCount; internalCount < 10 && i < categories.Count(); i++, internalCount++)
            {
                if (categories.ElementAt(i) != null)
                    returnedCategories.Add(categories.ElementAt(i));
            }
            //urls = urls.Skip((page - 1) * 10).Take(10);

            return View(returnedCategories);
        }


        public ActionResult Delete(int id)
        {
            try
            {
                objBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Failed to delete " + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}