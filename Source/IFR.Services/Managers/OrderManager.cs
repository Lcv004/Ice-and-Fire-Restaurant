using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using IFR.Entity;
using IFR.Services.Controllers;

namespace IFR.Services.Managers
{
    public class OrderManager
    {
        //public static ManualResetEvent mre = new ManualResetEvent(false);

        public OrderController _orderController;
        //public OrderStructure _order;
        public Queue<OrderStructure> _orderQueue;
        
        public OrderManager(OrderController orderController)
        {
            _orderController = orderController;
            _orderQueue = new Queue<OrderStructure>();
        }

        public void searchNewOrders()
        {
            var orderList = _orderController.FindByStatus(OrderStatus.PENDING);
            if (orderList.Any())
            {
                OrderStructure order;
                foreach (var item in orderList)
                {
                    order.orderValue = _orderController.Get(item);
                    order.orderKey = item;
                    order.orderValue.Id = long.Parse(DateTime.Today.Date.ToString("yyyyMMdd") + item.ToString());
                    _orderQueue.Enqueue(order);
                    _orderController.Get(item).Status = OrderStatus.PROCESSING;
                }
            }
        }

        public void processOrder(Chef chef)
        {
            ThreadPool.QueueUserWorkItem(chef.Cook, _orderQueue.Dequeue().orderValue);
            //chef.Cook(_orderQueue.Dequeue().orderValue);
            //_orderController.Get(_orderQueue.Dequeue().orderKey).Status = OrderStatus.DONE;
        }
    }
}
