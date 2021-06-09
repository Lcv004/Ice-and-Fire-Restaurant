using System.Collections.Generic;
using IFR.Entity;
using IFR.Services.Repositories;

namespace IFR.Services.Controllers
{
    public class ProductController
    {
        ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public void Add(Product entity)
        {
            _productRepository.Add(entity);
        }
        public void Remove(long key)
        {
            _productRepository.Remove(key);
        }
        public Product Get(long key)
        {
            return _productRepository.Get(key);
        }
        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}
