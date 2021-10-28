using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IFR.Entity
{
    public class Chef
    {
        const int TIME = 10000;
        public string Id { get; set; }
        public int Experience { get; set; }
        public bool Status { get; set; }

        public void Cook(Object context)
        {
            Order order = (Order)context;
            Console.WriteLine("Chef {0}: Cooking...\n", Id); 
            int cookingTime = TIME / Experience;
            Thread.Sleep(cookingTime);
            Console.WriteLine("Chef {0}: Ready!\n", Id);
        }
    }
}
