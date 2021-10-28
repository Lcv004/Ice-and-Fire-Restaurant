using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFR.Entity;
using IFR.Services.Controllers;
using IFR.Services.Managers;
using IFR.Utilities;

namespace IFR.Tests
{
    public static class OrderManagerTest
    {
        public static void Test()
        {
            Ioc ioc = Ioc.getInstance();
            var orderController = (OrderController)Ioc._serviceInstances["OrderController"];
            var orderManager = new OrderManager(orderController);

            var buffaloWings = new Product
            {
                ID = 1,
                Name = "Buffalo Wings",
                Price = 9.99f
            };
            var soup = new Product
            {
                ID = 2,
                Name = "Soup",
                Price = 5.99f
            };
            var salad = new Product
            {
                ID = 3,
                Name = "Salad",
                Price = 2.99f
            };
            var iceCream = new Product
            {
                ID = 4,
                Name = "Ice Cream",
                Price = 4.99f
            };

            var firstOrder = new Order
            {
                Customer = "LCG",
                Products = new List<Product>(),
                Quantities = new List<int>(),
                Cost = 0.0f,
                Status = 0,
                Priority = OrderPriority.DELIVERY,
                Complexity = 0
            };
            var secondOrder = new Order
            {
                Customer = "MVP",
                Products = new List<Product>(),
                Quantities = new List<int>(),
                Cost = 0.0f,
                Status = 0,
                Priority = OrderPriority.STORE,
                Complexity = 1
            };
            var thirdOrder = new Order
            {
                Customer = "LCV",
                Products = new List<Product>(),
                Quantities = new List<int>(),
                Cost = 0.0f,
                Status = 0,
                Priority = OrderPriority.STORE,
                Complexity = 2
            };

            var chefJunior = new Chef
            {
                Experience = 1
            };
            var chefMid = new Chef
            {
                Experience = 2
            };
            var chefSenior = new Chef
            {
                Experience = 4
            };

            firstOrder.Products.Add(buffaloWings);
            firstOrder.Quantities.Add(3);
            firstOrder.Products.Add(soup);
            firstOrder.Quantities.Add(2);
            firstOrder.Products.Add(salad);
            firstOrder.Quantities.Add(1);
            firstOrder.Products.Add(iceCream);
            firstOrder.Quantities.Add(6);
            firstOrder.Cost = sumProductsCosts(firstOrder);

            secondOrder.Products.Add(soup);
            secondOrder.Quantities.Add(1);
            secondOrder.Products.Add(iceCream);
            secondOrder.Quantities.Add(1);
            secondOrder.Cost = sumProductsCosts(secondOrder);

            thirdOrder.Products.Add(iceCream);
            thirdOrder.Quantities.Add(2);
            thirdOrder.Cost = sumProductsCosts(thirdOrder);

            orderController.Add(firstOrder);
            orderController.Add(secondOrder);
            orderController.Add(thirdOrder);

            Console.WriteLine("Printing orders (pending):");
            printOrdersStatus(orderController);
            Console.WriteLine("Order queue has {0} elements\n", orderManager._orderQueue.Count());
            orderManager.searchNewOrders();
            Console.WriteLine("Printing orders (processing):");
            printOrdersStatus(orderController);
            Console.WriteLine();

            Console.WriteLine("Order queue has {0} elements", orderManager._orderQueue.Count());
            Console.WriteLine("=> Order given to a chef without much experience. Waiting..."); 
            orderManager.processOrder(chefJunior);

            Console.WriteLine("Order queue has {0} elements", orderManager._orderQueue.Count());
            Console.WriteLine("=> Order given to a mid level chef. Waiting..."); 
            orderManager.processOrder(chefMid);

            Console.WriteLine("Order queue has {0} elements", orderManager._orderQueue.Count());
            Console.WriteLine("=> Order given to an experimented chef. Waiting...");
            orderManager.processOrder(chefSenior);

            Console.WriteLine("Order queue has {0} elements", orderManager._orderQueue.Count());
        }

        private static float sumProductsCosts(Order order)
        {
            for (int i = 0; i < order.Products.Count; i++)
            {
                order.Cost = order.Products[i].Price + order.Quantities[i];
            }
            return order.Cost;
        }

        private static void printOrdersStatus(OrderController orderController)
        {
            Console.WriteLine("First order status is: {0}", orderController.Get(1).Status);
            Console.WriteLine("Second order status is: {0}", orderController.Get(2).Status);
            Console.WriteLine("Third order status is: {0}\n", orderController.Get(3).Status);
        }
    }
}
