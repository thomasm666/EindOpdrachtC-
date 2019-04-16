using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// startup
[assembly: OwinStartup(typeof(OrderFoodApp.WebApp.Startup))]
namespace OrderFoodApp.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // app.UseCors(CorsOptions.AllowAll);
        }
    }
}