using System.Collections.Generic;

namespace Restaurant
{
    public class Order
    {
        public List<Product> Products { get; set; };
        public List<int> Quantities { get; set; };
        public float Cost { get; set; };
    }
}
