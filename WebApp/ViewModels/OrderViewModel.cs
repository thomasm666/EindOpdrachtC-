using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maak class orderDTO, prenext DTO
/// </summary>
namespace OrderFoodApp.WebApp.ViewModels
{
    public class OrderViewModel
    {
        public OrderDto Order { get; set; }
        public PrevNextIdsDto PrevNext { get; set; }
    }
}