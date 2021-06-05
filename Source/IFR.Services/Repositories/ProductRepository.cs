using System;
using System.Collections.Generic;
using IFR.Entity;

namespace IFR.Services.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        Dictionary<long, Product> _productDictionary;
        long _key;

        private ProductRepository()
        {
             _productDictionary = new Dictionary<long, Product>();
             _key = 0;
        }

        public void Add(Product entity)
        {
            if (!_productDictionary.ContainsKey(_key))
            {
                _key ++;
                _productDictionary.Add(_key, entity);
            }
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
            if (_productDictionary.ContainsKey(key))
            {
                return _productDictionary[key];
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDictionary.Values;
        }
    }
}
