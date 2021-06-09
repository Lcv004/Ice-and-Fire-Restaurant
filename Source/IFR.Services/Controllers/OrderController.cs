using IFR.Entity;
using IFR.Services.Repositories;
using System.Collections.Generic;

namespace IFR.Services.Controllers
{
    public class OrderController
    {
        OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public void Add(Order entity)
        {
            _orderRepository.Add(entity);
        }
        public void Remove(long key)
        {
            _orderRepository.Remove(key);
        }
        public Order Get(long key)
        {
            return _orderRepository.Get(key);
        }
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }
    }
}
