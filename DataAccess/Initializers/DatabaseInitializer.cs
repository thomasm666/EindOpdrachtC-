using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Init UsersAndRoles en Products
/// </summary>
namespace OrderFoodApp.DataAccess.Initializers
{
    class DatabaseInitializer : DropCreateDatabaseIfModelChanges<OfaDbContext>
    {
        protected override void Seed(OfaDbContext context)
        {
            InitDb.InitUsersAndRoles(context);
            InitDb.InitProducts(context);
        }
    }
}
