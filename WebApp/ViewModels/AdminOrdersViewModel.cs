using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maakt class 
/// Order list en reportDate
/// </summary>
namespace OrderFoodApp.WebApp.ViewModels
{
    public class AdminOrdersViewModel
    {
        public IList<OrderDto> Orders { get; set; }
        public DateTime ReportDate { get; set; }
    }
}