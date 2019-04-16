using Microsoft.AspNet.Identity.EntityFramework;
using OrderFoodApp.Domain.Models.Identity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderFoodApp.DataAccess.Initializers;
using OrderFoodApp.Domain.Models;

namespace OrderFoodApp.DataAccess
{
    public class OfaDbContext : IdentityDbContext<OfaUser, OfaRole, int, UserLogin, UserRole, UserClaim>
    {
        public OfaDbContext() : base("OrderFoodApp")
        {
            Database.SetInitializer<OfaDbContext>(new DatabaseInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static OfaDbContext Create()
        {
            return new OfaDbContext();
        }
    }
}
