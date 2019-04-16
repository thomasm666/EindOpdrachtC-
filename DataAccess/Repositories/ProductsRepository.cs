using OrderFoodApp.Domain.Interfaces;
using OrderFoodApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly OfaDbContext _context;

        public ProductsRepository(OfaDbContext context) => _context = context;

        public Product Insert(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Product Update(Product item)
        {
            var origProduct = _context.Products.Find(item.Id);
            if (null == origProduct)
                return null;
            _context.Entry<Product>(origProduct).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return origProduct;
        }

        public IList<Product> List()
        {
            return _context.Products.OrderBy(p => p.Name).ToList();
        }

        public bool Delete(int id)
        {
            var product2Delete = _context.Products.Find(id);
            if (null == product2Delete)
                return false;
            _context.Products.Remove(product2Delete);
            _context.SaveChanges();
            return true;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
