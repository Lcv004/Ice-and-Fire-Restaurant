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
    static class MenuTest
    {
        public static void Test()
        {
            Ioc ioc = Ioc.getInstance();
            var menuController = (MenuController)Ioc._serviceInstances["MenuController"];

            var buffaloWings = new Product
            {
                ID = 1,
                Name = "Buffalo Wings",
            };

            var soup = new Product
            {
                ID = 2,
                Name = "Soup",
            };

            var salad = new Product
            {
                ID = 3,
                Name = "Salad",
            };

            var iceCream = new Product
            {
                ID = 4,
                Name = "Ice Cream",
            };

            var IceAndFireMenu = new Menu()
            {
                Category = new Dictionary<string, List<Product>>()
            };

            var hotDishes = new List<Product>();
            var coldDishes = new List<Product>();

            hotDishes.Add(buffaloWings);
            hotDishes.Add(soup);
            coldDishes.Add(salad);
            coldDishes.Add(iceCream);

            IceAndFireMenu.Category.Add("Hot dishes", hotDishes);
            IceAndFireMenu.Category.Add("Cold dishes", coldDishes);

            menuController.Add(IceAndFireMenu);

            Console.WriteLine("In Cold dishes of the menu are:\n");
            foreach (Product dish in menuController.Get(1).Category["Hot dishes"])
            {
                Console.WriteLine(dish.Name);
            }
        }
    }
}
