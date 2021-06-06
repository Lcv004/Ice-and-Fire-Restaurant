using System.Collections.Generic;
using IFR.Entity;

namespace IFR.Services.Repositories
{
    public class OrderRepository : IRepository<long, Order>
    {
        Dictionary<long, Order> _orderDictionary;
        long _id;

        private OrderRepository()
        {
             _orderDictionary = new Dictionary<long, Order>();
             _id = 0;
        }

        public void Add(Order entity)
        {
            _id ++;
            _orderDictionary.Add(_id, entity);
        }

        public void Remove(long key)
        {
            if (_orderDictionary.ContainsKey(key))
            {
                _orderDictionary.Remove(key);
            }
        }

        public Order Get(long key)
        {
            return _orderDictionary[key];
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderDictionary.Values;
        }
    }
}
