using Jobb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Jobb.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private profile Profile;

        public CustomPrincipal(profile Profile)
        {
            this.Profile = Profile;
            this.Identity = new GenericIdentity(Profile.Username);
        }
        public IIdentity Identity
        {
            get;
            set;
        }
        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Profile.Roles.ToString().Contains(r));
        }
    }
}