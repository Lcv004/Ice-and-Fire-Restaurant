using System;
using System.Collections.Generic;
using IFR.Entity;

namespace IFR.Services.Repositories
{
    public class ProductRepository : IRepository<long, Product>
    {
        Dictionary<long, Product> _productDictionary;
        long _id;

        private ProductRepository()
        {
             _productDictionary = new Dictionary<long, Product>();
             _id = 0;
        }

        public void Add(Product entity)
        {
            _id ++;
            _productDictionary.Add(_id, entity);
        }

        public void Remove(long key)
        {
            if (_productDictionary.ContainsKey(key))
            {
                _productDictionary.Remove(key);
            }
        }

        public Product Get(long key)
        {
            return _productDictionary[key];
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDictionary.Values;
        }
    }
}
