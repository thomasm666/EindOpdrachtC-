using AutoMapper;
using Ninject.Modules;
using OrderFoodApp.DataAccess.Repositories;
using OrderFoodApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.Service.Infrastructure
{
    public class DIBindings : NinjectModule
    {
        public override void Load()
        {

            this.Bind<IProductsRepository>().To<ProductsRepository>();
            this.Bind<IOrdersRepository>().To<OrdersRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperServiceProfile>());
            config.AssertConfigurationIsValid();
            this.Bind<IMapper>().ToConstant(config.CreateMapper()).InSingletonScope();
        }
    }
}
