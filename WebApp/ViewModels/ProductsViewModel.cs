using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maak class, add producten en image link (voor folder)
/// </summary>
namespace OrderFoodApp.WebApp.ViewModels
{
    public class ProductsViewModel
    {
        public IList<ProductDto> Products { get; set; }
        public string ImagesFolder { get; set; }
    }
}