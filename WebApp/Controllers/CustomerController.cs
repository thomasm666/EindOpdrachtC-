using OrderFoodApp.Service.Products;
using OrderFoodApp.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
///  maak class, laad products en images url.
/// </summary>
namespace OrderFoodApp.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IProductsService _productsService;
        public CustomerController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new CustomerViewModel
            {
                Products = _productsService.ProductsList(),
                ImagesFolder = ConfigurationManager.AppSettings["imagesFolder"]
            };
            return View(model);
        }
    }
}