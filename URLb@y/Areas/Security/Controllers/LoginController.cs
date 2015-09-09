using BOL;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            //use the membership class to check if the user exist in the system
            try
            {
                if (Membership.ValidateUser(user.UserEmail, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed  ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Login Failed  " + e.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }

        public ActionResult ExternalLogin(string provider)
        {
            try
            {
                OAuthWebSecurity.RequestAuthentication(provider, Url.Action("ExternalLoginCallback"));
                return RedirectToAction("Index", "Home", new { area = "Common" });
            }
           
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Index", "Home", new { area = "Common" });
            }
        }
        public ActionResult ExternalLoginCallback(string provider)
        {

            /*
            OAuthWebSecurity.RequestAuthentication - this is the API to make call to our provider to login. We pass provider's name and the callback url to handle the result.

            OAuthWebSecurity.VerifyAuthentication - this API validates the login and returns result from our provider. We can check the result by verivying it's IsSuccessful property.

            FormsAuthentication.SetAuthCookie - in case if everything is OK, we can make all things we need to do and then write cookies to pass the authentication.
            */
            var result = OAuthWebSecurity.VerifyAuthentication();

            if (result.IsSuccessful == false)
            {
                TempData["Msg"] = "Login Failed  ";
                return RedirectToAction("Index");
            }
            else
            {
                objBs.CreateUserIfDoesNotExist(result.UserName);
                FormsAuthentication.SetAuthCookie(result.UserName, false);
                return RedirectToAction("Index", "Home", new { area = "Common" });
            }
        }
    }
}