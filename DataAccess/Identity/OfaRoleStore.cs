using Microsoft.AspNet.Identity.EntityFramework;
using OrderFoodApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.DataAccess.Identity
{
    public class OfaRoleStore : RoleStore<OfaRole, int, UserRole>
    {
        public OfaRoleStore(OfaDbContext context)
        : base(context)
        {
        }
    }
}
