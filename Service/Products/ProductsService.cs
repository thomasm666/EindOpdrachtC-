using AutoMapper;
using DTOs;
using OrderFoodApp.Domain.Interfaces;
using OrderFoodApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.Service.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public IList<ProductDto> ProductsList()
        {
            return _mapper.Map<IList<ProductDto>>(_productsRepository.List());
        }

        public ProductDto Save(ProductDto product)
        {
            var productDb = _mapper.Map<Product>(product);
            if (0 == productDb.Id)
                productDb = _productsRepository.Insert(productDb);
            else
                productDb = _productsRepository.Update(productDb);
            return _mapper.Map<ProductDto>(productDb);
        }

        public ProductDto GetById(int id)
        {
            return _mapper.Map<ProductDto>(_productsRepository.GetById(id));
        }

        public bool Delete(int id)
        {
            return _productsRepository.Delete(id);
        }
    }
}
