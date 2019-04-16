using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OrderFoodApp.DataAccess;
using OrderFoodApp.DataAccess.Identity;
using OrderFoodApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maakt rollen en defineerd rollen
/// </summary>
namespace OrderFoodApp.WebApp.Infrastructure.Identity
{
    public class OfaUserManager : UserManager<OfaUser, int>
    {
        public OfaUserManager(IUserStore<OfaUser, int> store)
            : base(store)
        {
        }

        public static OfaUserManager Create(IdentityFactoryOptions<OfaUserManager> options, IOwinContext context)
        {
            var manager = new OfaUserManager(
                new OfaUserStore(context.Get<OfaDbContext>()));
            // Configure validation logic for usernames 
            manager.UserValidator = new UserValidator<OfaUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords 
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
                /*RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,*/
            };

            
            //  manager.EmailService = new EmailService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<OfaUser, int>(
                        dataProtectionProvider.Create("Order Food App Identity"));
            }
            return manager;
        }
    }

}