using System;
using IFR.Services.Repositories;
using IFR.Services.Controllers;
using System.Collections.Generic;

namespace IFR.Utilities
{
    public class Ioc
    {
        public static Ioc _instance;
        public static Dictionary<string, object> _serviceInstances;
        
        private Ioc()
        {
            _serviceInstances = new Dictionary<string, object>();

            // Repository instances
            _serviceInstances.Add("ProductRepository", new ProductRepository());
            _serviceInstances.Add("InventoryRepository", new InventoryRepository());
            _serviceInstances.Add("MenuRepository", new MenuRepository());
            _serviceInstances.Add("OrderRepository", new OrderRepository());

            // Controller instances
            _serviceInstances.Add("ProductController", new ProductController(
                                (ProductRepository) _serviceInstances["ProductRepository"]));

            _serviceInstances.Add("InventoryController", new InventoryController(
                                (InventoryRepository) _serviceInstances["InventoryRepository"]));

            _serviceInstances.Add("MenuController", new MenuController(
                                (MenuRepository) _serviceInstances["MenuRepository"]));
                                
            _serviceInstances.Add("OrderController", new OrderController(
                                (OrderRepository) _serviceInstances["OrderRepository"]));
        }

        public static Ioc getInstance()
        {
            if (_instance == null)
            {
                _instance = new Ioc();
            }

            return _instance;
        }
    }
}
