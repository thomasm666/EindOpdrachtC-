using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.Service.Products
{
    public interface IProductsService
    {
        IList<ProductDto> ProductsList();
        ProductDto Save(ProductDto product);
        ProductDto GetById(int id);
        bool Delete(int id);
    }
}
