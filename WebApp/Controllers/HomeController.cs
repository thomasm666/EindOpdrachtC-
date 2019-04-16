using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Maak class, redirect op basis van user role.
/// </summary>
namespace OrderFoodApp.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("", "admin");
            }
            else if (User.IsInRole("User"))
            {
                return RedirectToAction("", "user");
            }
            else {
                return RedirectToAction("error", "home");
            }
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }
    }
}
