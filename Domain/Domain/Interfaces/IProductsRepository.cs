using OrderFoodApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Product Insert(Product item);
        Product Update(Product item);
        IList<Product> List();
        bool Delete(int id);
        Product GetById(int id);
    }
}
