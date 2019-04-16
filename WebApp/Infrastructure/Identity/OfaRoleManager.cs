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
/// Maak rollen en defined de rollen.
/// </summary>
namespace OrderFoodApp.WebApp.Infrastructure.Identity
{
    public class OfaRoleManager : RoleManager<OfaRole, int>
    {
        public OfaRoleManager(IRoleStore<OfaRole, int> roleStore)
            : base(roleStore)
        {
        }

        public static OfaRoleManager Create(
            IdentityFactoryOptions<OfaRoleManager> options, IOwinContext context)
        {
            var roleStore = new OfaRoleStore(context.Get<OfaDbContext>());
            return new OfaRoleManager(roleStore);
        }
    }
}