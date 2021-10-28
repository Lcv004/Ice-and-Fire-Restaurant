using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFR.Entity;
using IFR.Services.Controllers;
using IFR.Services.Managers;
using IFR.Services.Repositories;

namespace IFR.Utilities
{
    public class Init
    {
        private static Init instance;
        private OrderManager orderManager;
        private List<Chef> chefs;
        private Init()
        {
            Ioc.getInstance();

            var pizza = new Product { Name = "Pizza", Price = 4.99f , Complexity = 2};
            var hotdog = new Product { Name = "Hotdog", Price = 2.99f, Complexity = 1 };
            var coffee = new Product { Name = "Coffee", Price = 0.99f, Complexity = 1 };
            var salcocho = new Product { Name = "Salcocho", Price = 7.99f, Complexity = 4 };

            var orderController = (OrderController)Ioc._serviceInstances["OrderController"];

            orderController.Add(new Order
            {
                Customer = "Luis",
                Priority = OrderPriority.DELIVERY,
                Products = new List<Product> { pizza, coffee },
                Quantities = new List<int> { 1, 2 },
                Status = OrderStatus.PENDING
            });

            orderController.Add(new Order
            {
                Customer = "Maryi",
                Priority = OrderPriority.STORE,
                Products = new List<Product> { hotdog, coffee },
                Quantities = new List<int> { 2, 1 },
                Status = OrderStatus.PENDING
            });

            orderController.Add(new Order
            {
                Customer = "Luiggi",
                Priority = OrderPriority.DELIVERY,
                Products = new List<Product> { pizza, coffee, salcocho, hotdog },
                Quantities = new List<int> { 1, 1, 1, 1 },
                Status = OrderStatus.PENDING
            });

            orderManager = new OrderManager(orderController);
            chefs = new List<Chef>();

            for (int i = 0; i < 3; i++)
            {
                chefs.Add(new Chef());
            }

            chefs[0] = new Chef
            {
                Experience = 1,
                Id = "Junior",
                Status = ChefStatus.AVAILABLE
            };
            chefs[1] = new Chef
            {
                Experience = 2,
                Id = "Mid",
                Status = ChefStatus.AVAILABLE
            };
            chefs[2] = new Chef
            {
                Experience = 5,
                Id = "Senior",
                Status = ChefStatus.AVAILABLE
            };
        }

        public static void Getinstance()
        {
            if (instance == null)
            {
                instance = new Init();
            }
        }

        public static OrderManager GetOrderManager()
        {
            return instance.orderManager;
        }

        public static List<Chef> GetChefs()
        {
            return instance.chefs;
        }
    }
}
