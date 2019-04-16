using System.Web;
using System.Web.Mvc;

/// <summary>
/// Maak class, maak errors 
/// </summary>
namespace OrderFoodApp.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
