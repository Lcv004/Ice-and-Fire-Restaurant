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
            float orderCost = 0.0f;
            int orderComplexity = 0;
            for (int p = 0; p < entity.Products.Count; p++)
            {
                orderCost += entity.Products[p].Price * entity.Quantities[p];
                orderComplexity += entity.Products[p].Complexity;
            }
            entity.Cost = orderCost;
            entity.Complexity = orderComplexity;

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
        public IEnumerable<long> FindByStatus(int status)
        {
            return _orderRepository.FindByStatus(status);
        }
        public IEnumerable<long> FindIncompleteOrders()
        {
            return _orderRepository.FindIncompleteOrders();
        }
    }
}
