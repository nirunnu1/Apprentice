using Jobb.Models;
using Jobb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static Jobb.Models.modelEnum;

namespace Jobb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       
        public ActionResult Login()
        {
            SessionPrincipal.Username = string.Empty;
            FormsAuthentication.SignOut();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            ProfileModel cm = new ProfileModel();
 
                if (ModelState.IsValid)
                {
                    if (cm.Login(model.UserName, model.Password) == null)
                    {
                        ViewBag.loginError = " Account's Invalid";
                        return View("Login");
                    }
                }
            
            FormsAuthentication.SetAuthCookie(model.UserName, false);
            SessionPrincipal.Username = model.UserName;
            switch (cm.Find(model.UserName).Roles)
            {
                case modelEnum.Roles.Admin:
                    return RedirectToAction("meeting", "Admin");
                case modelEnum.Roles.Instructor:
                    return RedirectToAction("Index", "Instructor");
                default:
                    return RedirectToAction("Home", "Student");
            }
        }
        public ActionResult Logout()
        {
            SessionPrincipal.Username = string.Empty;
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Account");
           
        }
        public ActionResult meetingPartial()
        {
            MyContext context = new MyContext();
           var model = context.meeting.Where(t => t.Type == meetingcase.Announce && t.meet_show==status.Yes).ToArray();
            return View(model);
        }

    }
}