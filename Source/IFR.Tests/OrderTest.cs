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
            // To order you check the menu. So I have to:
            // 1. Create products and categories.
            // 2. Create a menu.
            // 3. Place orders based on menu.

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

            var order = new Order
            {
                Products = new List<Product>(),
                Quantities = new List<int>(),
                Cost = 0.0f
            };

            order.Products.Add(buffaloWings);
            order.Quantities.Add(3);
            order.Products.Add(soup);
            order.Quantities.Add(2);
            order.Products.Add(salad);
            order.Quantities.Add(1);
            order.Products.Add(iceCream);
            order.Quantities.Add(6);

            for (int i = 0; i < order.Products.Count; i++)
            {
                order.Cost = order.Products[i].Price + order.Quantities[i];
            }

            orderController.Add(order);

            Console.WriteLine("List of products ordered:");
            for (int i = 0; i < order.Products.Count; i++)
            {
                Console.WriteLine(order.Products[i].Name);
            }
            Console.WriteLine("-- Total Cost: {0}", order.Cost);
        }
    }
}
