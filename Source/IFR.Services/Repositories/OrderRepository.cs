using System.Collections.Generic;
using System.Linq;
using IFR.Entity;

namespace IFR.Services.Repositories
{
    public class OrderRepository : IRepository<long, Order>
    {
        Dictionary<long, Order> _orderDictionary;
        long _id;

        public OrderRepository()
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

        public IEnumerable<long> FindByStatus(int status)
        {
            var result = new List<long>();
            foreach (KeyValuePair<long, Order> kvp in _orderDictionary)
            {
                if (kvp.Value.Status == status)
                {
                    result.Add(kvp.Key);
                }
            }
            return result;
        }

        public IEnumerable<long> FindIncompleteOrders()
        {
            var result = new List<long>();
            foreach (KeyValuePair<long, Order> kvp in _orderDictionary)
            {
                if (kvp.Value.Status != OrderStatus.CANCELED && kvp.Value.Status != OrderStatus.DONE)
                {
                    result.Add(kvp.Key);
                }
            }
            return result;
        }
    }
}
