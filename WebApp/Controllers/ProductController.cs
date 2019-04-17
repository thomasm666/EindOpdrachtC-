using DTOs;
using OrderFoodApp.Service.Products;
using OrderFoodApp.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Maak class, view edit delete producten.
/// </summary>
namespace OrderFoodApp.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new ProductsViewModel
            {
                Products = _productsService.ProductsList(),
                ImagesFolder = ConfigurationManager.AppSettings["imagesFolder"]
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            /// Edit producten
            var model = new EditProductViewModel();
            if (id.HasValue && 0 != id.Value)
            {
                model.Product = _productsService.GetById(id.Value);
                if (null == model.Product)
                    throw new HttpException((int)HttpStatusCode.InternalServerError, "Kan product niet vinden");
            }
            else
            {
                model.Product = new ProductDto();
            }
            
        }
        
        /// <summary>
        /// Edit product
        /// </summary>
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var files = Request.Files;
                if (1 == files.Count && 0 < files[0].ContentLength)
                {
                    try
                    {
                        /// upload image
                        var folder = Server.MapPath(ConfigurationManager.AppSettings["imagesFolder"]);
                        var filename = folder + files[0].FileName;
                        files[0].SaveAs(filename);
                        if (!string.IsNullOrEmpty(model.Product.Image))
                        {
                            var oldFile = folder + model.Product.Image;
                            System.IO.File.Delete(oldFile);
                        }
                        model.Product.Image = files[0].FileName;
                    }
                    catch (Exception ex)
                    {
                        throw new HttpException((int)HttpStatusCode.InternalServerError, "Kan afbeelding niet uploaden");
                    }
                }

                var result = _productsService.Save(model.Product);
                if (null == result)
                    throw new HttpException((int)HttpStatusCode.InternalServerError, "Kan product niet opslaan");
                return RedirectToAction("", "product");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Delete(int id)
            /// delete product
        {
            var product = _productsService.GetById(id);
            if (null == product)
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Kan product niet vinden");
            try
            {
                if (!string.IsNullOrEmpty(product.Image))
                {
                    var folder = Server.MapPath(ConfigurationManager.AppSettings["imagesFolder"]);
                    var oldFile = folder + product.Image;
                    System.IO.File.Delete(oldFile);
                }
                var res = _productsService.Delete(id);
                if (!res)
                    throw new HttpException((int)HttpStatusCode.InternalServerError, "Unable to delete product");
                return RedirectToAction("", "product");
            }
            catch (Exception ex)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Unable to delete product");
            }
        }
    }
}
