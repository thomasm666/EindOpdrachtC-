using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maak class, add orders and status.
/// </summary>
namespace OrderFoodApp.WebApp.ViewModels
{
    public class UserOrdersViewModel
    {
        public IList<OrderDto> Orders { get; set; }
        public bool ShowDone { get; set; } 
    }
}