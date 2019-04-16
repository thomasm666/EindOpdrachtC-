using OrderFoodApp.Service.Orders;
using OrderFoodApp.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// Httpget API admin
/// </summary>
namespace OrderFoodApp.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOrdersService _ordersService;
        public AdminController(IOrdersService ordersService) => _ordersService = ordersService;

        [HttpGet]
        public ActionResult Index(DateTime? id)
        {
            var today = id.HasValue ? id.Value.Date : DateTime.Today;
            var model = new AdminOrdersViewModel {
                ReportDate = today,
                Orders = _ordersService.OrdersList(today)
            };
            return View(model);
        }
    }
}