using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrderFoodApp.DataAccess.Identity;
using OrderFoodApp.Domain.Models;
using OrderFoodApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///  Init van de database, producten toevoegen
/// </summary>
namespace OrderFoodApp.DataAccess.Initializers
{
    public static partial class InitDb
    {
        public static void InitProducts(OfaDbContext context)
        {
            var chicken = new Product
            {
                Name = "Chicken",
                Price = 5,
                Image= "200912-xl-moroccan-chicken.png"
            };
            var burger = new Product
            {
                Name = "Burger",
                Price = 2.5M,
                Image = "exps28800_UG143377D12_18_1b_RMS-696x696.png"

            };
            var fries = new Product
            {
                Name = "Fries",
                Price = 2,
                Image = "20180309-french-fries-vicky-wasik-15.png"
            };

            context.Products.Add(chicken);
            context.Products.Add(burger);
            context.Products.Add(fries);
            context.SaveChanges();
        }
    }
}
