using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Maak class, add products een image link.
/// </summary>
namespace OrderFoodApp.WebApp.ViewModels
{
    public class EditProductViewModel
    {
        public ProductDto Product { get; set; }
        public string ImagesFolder { get; set; }
    }
}