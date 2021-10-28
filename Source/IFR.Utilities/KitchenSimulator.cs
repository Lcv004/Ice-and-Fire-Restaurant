using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using IFR.Entity;
using IFR.Services.Controllers;
using IFR.Services.Managers;
using IFR.Utilities;


namespace IFR.Services.Managers
{
    public class KitchenSimulator
    {
        public OrderManager _orderManager;
        public List<Chef> _chefs;
        public KitchenSimulator(OrderManager ordermanager, List<Chef> chefs)
        {
            _orderManager = ordermanager;
            _chefs = chefs;
        }

        public void Run()
        {
            while (true)
            {
                _orderManager.searchNewOrders();
                if (_orderManager._orderQueue.Any())
                {
                    Chef availableChef = _chefs.Find(chef => chef.Status == ChefStatus.AVAILABLE);
                    if (availableChef != null)
                    {
                        OrderStructure nextOrder = _orderManager._orderQueue.Dequeue();
                        KitchenRequest kitchenRequest;
                        kitchenRequest.order = nextOrder;
                        kitchenRequest.chef = availableChef;

                        ThreadPool.QueueUserWorkItem(Cook, kitchenRequest);
                        _chefs.Find(chef => chef.Id == availableChef.Id).Status = ChefStatus.BUSY;
                    }                    
                }
                /*else
                {
                    foreach (Chef chef in _chefs)
                    {
                        Console.WriteLine(chef.Id + " is " + chef.Status);
                    }
                    Console.WriteLine();
                    Thread.Sleep(2000);
                }*/
            }
        }

        public void Cook(Object info)
        {
            KitchenRequest kitchenRequest = (KitchenRequest)info;
            Console.WriteLine("Chef " + kitchenRequest.chef.Id + " is preparing order " +
                               kitchenRequest.order.orderValue.Id + "...");
            Console.WriteLine("Chef Exp: " + kitchenRequest.chef.Experience + " Order Compl: " +
                               kitchenRequest.order.orderValue.Complexity);
            int t = (kitchenRequest.order.orderValue.Complexity * 1000) / kitchenRequest.chef.Experience;
            Thread.Sleep(t);
            Console.WriteLine("Order " + kitchenRequest.order.orderValue.Id + " finished after " + t + " minutes!");
            _chefs.Find(chef => chef.Id == kitchenRequest.chef.Id).Status = ChefStatus.AVAILABLE;
        }
    }
}
