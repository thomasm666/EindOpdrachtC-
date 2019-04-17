using Microsoft.AspNet.Identity.Owin;
using OrderFoodApp.WebApp.Infrastructure.Identity;
using OrderFoodApp.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Maak class, validate user type, redirect bij errors.
/// </summary>
namespace OrderFoodApp.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly OfaUserManager _userMgr;
        private readonly OfaRoleManager _roleMgr;
        private readonly OfaSignInManager _signinMgr;
        public AccountController(OfaUserManager userMgr, OfaRoleManager roleMgr, OfaSignInManager signinMgr)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
            _signinMgr = signinMgr;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }


        /// <summary>
        ///  login controller
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinMgr.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (SignInStatus.Success == result)
                {
                    var user = await _userMgr.FindByEmailAsync(model.Username);
                    if (null == user)
                        throw new HttpException((int)HttpStatusCode.InternalServerError, "Kan gebruiker zijn email niet vinden");

                    if (await _userMgr.IsInRoleAsync(user.Id, "Administrator"))
                        return RedirectToAction("", "admin");

                    if (await _userMgr.IsInRoleAsync(user.Id, "User"))
                        return RedirectToAction("", "user");

                    throw new HttpException((int)HttpStatusCode.InternalServerError, "Gebruiker heeft geen role");
                }
                else if (SignInStatus.LockedOut == result)
                {
                    return RedirectToAction("LockedOut");
                }
                else if (SignInStatus.RequiresVerification == result)
                {
                    return RedirectToAction("Verification");
                }
                model.NotFound = true;
            }
            return View(model);
        }



        [HttpGet]
        public ActionResult Lockedout()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Verification()
        {
            return View();
        }
        
        /// <summary>
        /// Log uit
        /// </summary>
        [HttpGet]
        public ActionResult Logoff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("login", "account");
        }
    }
}
