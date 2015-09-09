using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    [Authorize(Roles = "A, U")]
    public class URLController : BaseUserController
    {
        // GET: User/URL
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url myUrl)
        {
            try
            {
                myUrl.IsApproved = "P";
                //return email address which will be used to find the user id
                myUrl.UserId = objBs.userBs.GetAll().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;

                if (ModelState.IsValid)
                {

                    objBs.urlBs.Insert(myUrl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }

    }
}