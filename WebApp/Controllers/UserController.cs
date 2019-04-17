using DTOs;
using OrderFoodApp.Service.Orders;
using OrderFoodApp.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Maak class, laad user orders.
/// </summary>
namespace OrderFoodApp.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IOrdersService _ordersService;
        public UserController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        
        /// <summary>
        /// Orders van vandaag
        /// </summary>


        [HttpGet]
        public ActionResult Index(string id)
        {
            var model = new UserOrdersViewModel
            {
                 Orders = _ordersService.OrdersTodaysList()
            };
            return View(model);
        }
        
      
        [HttpGet]
        public ActionResult Order(int id)
        {
            var today = DateTime.Today;
            var order = _ordersService.GetTodayById(id, today);
            var model = new OrderViewModel
            {
                Order = order,
                PrevNext = null!= order ?_ordersService.GetPrevNextOrderIDs(order, today) : new PrevNextIdsDto()
            };
            return View(model);
        }
    }
}
