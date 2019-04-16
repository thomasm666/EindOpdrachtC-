using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

/// <summary>
/// Maak class en call template bij startup.
/// </summary>
namespace OrderFoodApp.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration/services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
