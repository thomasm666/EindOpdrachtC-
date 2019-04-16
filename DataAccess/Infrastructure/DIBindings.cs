using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.DataAccess.Infrastructure
{
    public class DIBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<OfaDbContext>().ToSelf();
        }
    }
}
