using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.Security
{
    public static class SessionPrincipal
    {
        static string usernameSessionver = "username";
        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[usernameSessionver];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernameSessionver] = value;
            }
        }
    }
}