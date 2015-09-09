using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListUserController : BaseAdminController
    {

        // GET: Admin/ListUser
        public ActionResult Index(String SortOrder, String SortBy, String Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var users = objBs.userBs.GetAll().ToList(); ;

            switch (SortBy)
            {
                case "UserEamil":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;

                        case "Desc":
                            users = users.OrderByDescending(x => x.UserEmail).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "Role":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Role).ToList();
                            break;

                        case "Desc":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    users = users.OrderBy(x => x.UserEmail).ToList();
                    break;
            }
            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetAll().Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            //page number is needed in order to highlight the page
            ViewBag.Page = page;


            //urls contaiins a list of objects of all the urls in the db, we use the page number to extract display the revelant 
            //number of pages
            //if page == 2, 2 - 1 = 1 * 10 = 10, skip the first 10 records and take next 10

            users.ToList();
            int elementCount = (page - 1) * 10;

            List<BOL.tbl_User> returnedUsers = new List<BOL.tbl_User>(users.Count());
            int internalCount = 0;

            for (int i = elementCount; internalCount < 10 && i < users.Count(); i++, internalCount++)
            {
                if (users.ElementAt(i) != null)
                    returnedUsers.Add(users.ElementAt(i));
            }
            //urls = urls.Skip((page - 1) * 10).Take(10);

            return View(returnedUsers);
        }
    }
}