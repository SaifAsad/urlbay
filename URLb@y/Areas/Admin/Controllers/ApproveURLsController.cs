using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApproveURLsController : BaseAdminController
    {
        // GET: /Admin/ApproveURLs/
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }

        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetById(id);
                myUrl.IsApproved = "A";
                objBs.urlBs.Update(myUrl);
                TempData["Msg"] = "Approved Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Approval Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult ApproveOrRejectAll(List<int> Ids, string status, string currentStatus)
        {
            try
            {
                objBs.ApproveOrReject(Ids, status);
                TempData["Msg"] = "Operation Successfull";
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == currentStatus).ToList();
                return PartialView("partialView_ApproveURLs", urls);
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Operation Failed" + e1.Message;
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved == currentStatus).ToList();
                return PartialView("partialView_ApproveURLs", urls);
            }
        }
        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetById(id);
                myUrl.IsApproved = "R";
                objBs.urlBs.Update(myUrl);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Rejection Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}