using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFR.Entity;
using IFR.Services.Controllers;
using IFR.Utilities;

namespace IFR.Tests
{
    public static class OrderTest
    {
        public static void Test()
        {
            Ioc ioc = Ioc.getInstance();
            var orderController = (OrderController)Ioc._serviceInstances["OrderController"];

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
                Customer = "LC",
                Products = new List<Product>(),
                Quantities = new List<int>(),
                Cost = 0.0f,
                Status = 2
            };

            var secondOrder = new Order
            {
                Customer = "MVP",
                Products = new List<Product>(),
                Quantities = new List<int>(),
                Cost = 0.0f,
                Status = 0
            };

            firstOrder.Products.Add(buffaloWings);
            firstOrder.Quantities.Add(3);
            firstOrder.Products.Add(soup);
            firstOrder.Quantities.Add(2);
            firstOrder.Products.Add(salad);
            firstOrder.Quantities.Add(1);
            firstOrder.Products.Add(iceCream);
            firstOrder.Quantities.Add(6);

            secondOrder.Products.Add(soup);
            secondOrder.Quantities.Add(1);
            secondOrder.Products.Add(iceCream);
            secondOrder.Quantities.Add(1);

            firstOrder.Cost = sumProductsCosts(firstOrder);
            secondOrder.Cost = sumProductsCosts(secondOrder);

            orderController.Add(firstOrder);
            orderController.Add(secondOrder);

            Console.WriteLine("List of products ordered by {0}:", firstOrder.Customer);
            for (int i = 0; i < firstOrder.Products.Count; i++)
            {
                Console.WriteLine(firstOrder.Products[i].Name);
            }
            Console.WriteLine("\n-- Total Cost: {0}\n", firstOrder.Cost);

            Console.WriteLine("List of products ordered by {0}:", secondOrder.Customer);
            for (int i = 0; i < secondOrder.Products.Count; i++)
            {
                Console.WriteLine(secondOrder.Products[i].Name);
            }
            Console.WriteLine("\n-- Total Cost: {0}\n", secondOrder.Cost);

            if (orderController.GetAll().Count() > 1)
            {
                Console.WriteLine("There are many orders!");
            }
            else if (orderController.GetAll().Count() > 0)
            {
                Console.WriteLine("There's an order!");
            }

            if (orderController.FindByStatus(OrderStatus.DONE).Any())
            {
                var completedOrders = orderController.FindByStatus(OrderStatus.DONE).Count();
                Console.WriteLine("{0} orders completed.", completedOrders);
            }

            if (orderController.FindIncompleteOrders().Any())
            {
                var incompletedOrders = orderController.FindIncompleteOrders().Count();
                Console.WriteLine("{0} incomplete orders.", incompletedOrders);
            }

            orderController.Remove(1);

            if (orderController.GetAll().Count() == 0)
            {
                Console.WriteLine("Orders deleted!");
            }
        }

        private static float sumProductsCosts(Order order)
        {
            for (int i = 0; i < order.Products.Count; i++)
            {
                order.Cost = order.Products[i].Price + order.Quantities[i];
            }
            return order.Cost;
        }
    }
}
