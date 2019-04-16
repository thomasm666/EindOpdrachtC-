using Microsoft.AspNet.Identity.EntityFramework;
using OrderFoodApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.DataAccess.Identity
{
    public class OfaUserStore : UserStore<OfaUser, OfaRole, int,
                            UserLogin, UserRole, UserClaim>
    {
        public OfaUserStore(OfaDbContext context) : base(context)
        {
        }
    }
}
