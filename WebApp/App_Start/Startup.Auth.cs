using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using OrderFoodApp.DataAccess;
using OrderFoodApp.Domain.Models.Identity;
using OrderFoodApp.WebApp.Infrastructure.Identity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// create class load user context into variable.
/// </summary>
namespace OrderFoodApp.WebApp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(OfaDbContext.Create);
            app.CreatePerOwinContext<OfaUserManager>(OfaUserManager.Create);
            app.CreatePerOwinContext<OfaRoleManager>(OfaRoleManager.Create);
            app.CreatePerOwinContext<OfaSignInManager>(OfaSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<OfaUserManager, OfaUser, int>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                        getUserIdCallback: (id) => (Int32.Parse(id.GetUserId())))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}