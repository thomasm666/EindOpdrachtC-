using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maakt class, add producten en image link.
/// </summary>
namespace OrderFoodApp.WebApp.ViewModels
{
    public class CustomerViewModel
    {
        public IList<ProductDto> Products { get; set; }
        public string ImagesFolder { get; set; }

    }
}