using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace CaWe.Attributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string[] Roles { get; set; }

        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.Roles = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var principal = filterContext.HttpContext.User;
            if (!principal.Identity.IsAuthenticated || !HasAnyRole(principal))
            {
                filterContext.HttpContext.Response.Redirect("~/401.html");
            }
        }

        private bool HasAnyRole(IPrincipal principal)
        {
            if (Roles == null)
                return true;

            for (int i = 0; i < Roles.Length; i++)
            {
                if (principal.IsInRole(Roles[i]))
                    return true;
            }
            return false;
        }
    }
}