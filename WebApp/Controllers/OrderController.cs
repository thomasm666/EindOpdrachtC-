using DTOs;
using OrderFoodApp.Service.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Maak class, save orders en publish errors.
/// </summary>
namespace OrderFoodApp.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersService _ordersService;
        public OrderController(IOrdersService ordersService) => _ordersService = ordersService;

        [HttpPost]
        public ActionResult Save(OrderDto model)
        {
            try
            {
                var res = _ordersService.Save(model);
                return Json(new { success = true, total = res.Items.Sum(i => i.Quantity * i.Price) });
            }catch(Exception ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Kan order niet opslaan");
            }
        }

        [HttpGet]
        public ActionResult ToggleState(int id)
        {
            _ordersService.ToggleState(id);
            return RedirectToAction("order", "user", new { id = id });
        }
    }
}