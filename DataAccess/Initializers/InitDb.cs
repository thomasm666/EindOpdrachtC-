using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrderFoodApp.DataAccess.Identity;
using OrderFoodApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Init van de database, rollen
/// </summary>
namespace OrderFoodApp.DataAccess.Initializers
{
    public static partial class InitDb
    {
        public static void InitUsersAndRoles(OfaDbContext context)
        {
            var roleStore = new OfaRoleStore(context);
            var roleManager = new RoleManager<OfaRole, int>(roleStore);
            var userStore = new UserStore<OfaUser, OfaRole, int, UserLogin, UserRole, UserClaim>(context);
            var userManager = new UserManager<OfaUser, int>(userStore);

            OfaRole systemRole = null;
            OfaRole adminRole = null;
            OfaRole kitchenRole = null;

            /* create roles */

            if (!roleManager.RoleExists("System"))
            {
                systemRole = new OfaRole();
                systemRole.Name = "System";
                roleManager.Create(systemRole);
            }
            else
                systemRole = roleManager.FindByName("System");

            if (!roleManager.RoleExists("Administrator"))
            {
                adminRole = new OfaRole();
                adminRole.Name = "Administrator";
                roleManager.Create(adminRole);
            }
            else
                adminRole = roleManager.FindByName("Administrator");

            if (!roleManager.RoleExists("User"))
            {
                kitchenRole = new OfaRole();
                kitchenRole.Name = "User";
                roleManager.Create(kitchenRole);
            }
            else
                kitchenRole = roleManager.FindByName("User");

            /* create users */

            var systemUser = new OfaUser { UserName = "SYSTEM" };
            userManager.Create(systemUser, "z=5#!xKj3_*[;9ND{n2");
            userManager.AddToRole(systemUser.Id, "System");

            var adminUser = new OfaUser { UserName = "admin@domain.com", Email = "admin@domain.com", EmailConfirmed = true, LockoutEnabled = false };
            userManager.Create(adminUser, "ofaadmin");
            userManager.AddToRole(adminUser.Id, "Administrator");

            var user = new OfaUser { UserName = "user@domain.com", Email = "user@domain.com", EmailConfirmed = true, LockoutEnabled = false };
            userManager.Create(user, "ofauser");
            userManager.AddToRole(user.Id, "User");
        }
    }
}
