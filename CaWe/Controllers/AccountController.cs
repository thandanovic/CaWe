using CaWe.Attributes;
using CaWe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaWe.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (base.AuthHelper.SignIn(model))
                return RedirectToAction("MyAccount");
            else
                return View(model);
        }

        public ActionResult Logout()
        {
            base.AuthHelper.SignOut();
            return RedirectToAction("Login");
        }

        /// <summary>
        /// Test only
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles("user")]
        public ActionResult MyAccount()
        {
            return View();
        }
    }
}