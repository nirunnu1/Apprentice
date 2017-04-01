using System;
using System.Collections.Generic;
using System.Linq;
using Jobb.Models;
using System.Web.Mvc;

namespace Jobb.Security
{
    public class Authentication : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPrincipal.Username))
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Account", action = "Login" }));

            else
            {
                ProfileModel cm = new ProfileModel();
                CustomPrincipal cp = new CustomPrincipal(cm.Find
                    (SessionPrincipal.Username));
                if (!cp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new
                        System.Web.Routing.RouteValueDictionary(new { Controller = "Account", action = "Login" }));

            }

        }

    }
}