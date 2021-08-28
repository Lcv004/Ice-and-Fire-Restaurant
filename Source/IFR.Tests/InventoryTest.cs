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
    public static class InventoryTest
    {
        public static void Test()
        {
            Ioc ioc = Ioc.getInstance();
            var productController = (ProductController)Ioc._serviceInstances["ProductController"];
            var inventoryController = (InventoryController)Ioc._serviceInstances["InventoryController"];

            var iceCream = new Product
            {
                Name = "Ice cream",
                Price = 2.99f
            };

            var tacos = new Product
            {
                Name = "Tacos",
                Price = 5.99f
            };

            var frozenStrawberryJuice = new Product
            {
                Name = "Frozen strawberry juice",
                Price = 4.99f
            };

            var productInventory = new Inventory
            {
                Products = new List<Product>(),
                ProductQuantities = new List<int>()
            };

            productInventory.Products.Add(iceCream);
            productInventory.ProductQuantities.Add(20);

            productInventory.Products.Add(tacos);
            productInventory.ProductQuantities.Add(30);

            productInventory.Products.Add(frozenStrawberryJuice);
            productInventory.ProductQuantities.Add(25);

            inventoryController.Add(productInventory);

            int inventories = inventoryController.GetAll().Count();

            Console.WriteLine("We have {0} inventories", inventories);

            if (inventories > 0)
            {
                Console.WriteLine("First product: {0} \t\t Price: {1}",
                              inventoryController.Get(1).Products[0].Name,
                              inventoryController.Get(1).Products[0].Price);
                Console.WriteLine("Third product: {0} \t Price: {1}",
                                  inventoryController.Get(1).Products[2].Name,
                                  inventoryController.Get(1).Products[2].Price);
            }
            

            inventoryController.Remove(1);
            inventories = inventoryController.GetAll().Count();

            Console.WriteLine("We have {0} inventories", inventories);

            if (inventories > 0)
            {
                Console.WriteLine("First product: {0} \t\t Price: {1}",
                              inventoryController.Get(1).Products[0].Name,
                              inventoryController.Get(1).Products[0].Price);
                Console.WriteLine("Third product: {0} \t Price: {1}",
                                  inventoryController.Get(1).Products[2].Name,
                                  inventoryController.Get(1).Products[2].Price);
            }
        }
    }
}
