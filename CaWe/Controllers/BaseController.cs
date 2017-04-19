using CaWe.Attributes;
using CaWe.Helpers;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaWe.Controllers
{
    [PreventCaching]
    public class BaseController : Controller
    {
        private AuthHelper authHelper;

        protected AuthHelper AuthHelper
        {
            get { return authHelper ?? (authHelper = new AuthHelper()); }
        }

    }
}