using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using OrderFoodApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Maakt rollen en defineerd rollen
/// </summary>
namespace OrderFoodApp.WebApp.Infrastructure.Identity
{
    public class OfaSignInManager : SignInManager<OfaUser, int>
    {
        public OfaSignInManager(OfaUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(OfaUser user)
        {
            return user.GenerateUserIdentityAsync((OfaUserManager)UserManager);
        }

        public static OfaSignInManager Create(IdentityFactoryOptions<OfaSignInManager> options, IOwinContext context)
        {
            return new OfaSignInManager(context.GetUserManager<OfaUserManager>(), context.Authentication);
        }
    }
}