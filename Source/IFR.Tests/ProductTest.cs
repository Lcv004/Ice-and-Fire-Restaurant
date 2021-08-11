using System;
using IFR.Entity;
using IFR.Services.Controllers;
using IFR.Utilities;

namespace IFR.Tests
{
    public static class ProductTest
    {
        public static void Test()
        {
            Ioc _ioc = Ioc.getInstance();
            var productController = (ProductController) Ioc._serviceInstances["ProductController"];

            var iceCream = new Product
            {
                Name = "Ice cream",
                ID = 142
            };

            var tacos = new Product
            {
                Name = "Tacos",
                ID = 98
            };

            var frozenStrawberryJuice = new Product
            {
                Name = "Frozen strawberry juice",
                ID = 124
            };

            productController.Add(iceCream);
            productController.Add(tacos);
            productController.Add(frozenStrawberryJuice);

            Console.WriteLine("First product: {0}", productController.Get(1).Name);
            Console.WriteLine("Third product: {0}", productController.Get(3).Name);
        }
    }
}
