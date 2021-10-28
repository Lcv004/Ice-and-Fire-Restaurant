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
    public static class KitchenSimulatorTest
    {
        public static void Test()
        {
            Init.Getinstance();
            OrderManager orderManager = Init.GetOrderManager();
            List<Chef> chefs = Init.GetChefs();

            KitchenSimulator kitchen = new KitchenSimulator(orderManager, chefs);
            kitchen.Run();
        }
    }
}
