using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Ninject.Modules;
using OrderFoodApp.DataAccess.Identity;
using OrderFoodApp.Domain.Models.Identity;
using OrderFoodApp.Service.Orders;
using OrderFoodApp.Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// create/maintain app bindings.
/// </summary>
namespace OrderFoodApp.WebApp.Infrastructure
{
    public class DIBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IProductsService>().To<ProductsService>();
            this.Bind<IOrdersService>().To<OrdersService>();

            this.Bind<IUserStore<OfaUser, int>>().To<OfaUserStore>();
            this.Bind<IRoleStore<OfaRole, int>>().To<OfaRoleStore>();

            this.Bind<IAuthenticationManager>().ToMethod(c =>
                HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}