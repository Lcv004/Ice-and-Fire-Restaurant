using System.Collections.Generic;

namespace IFR.Entity
{
    public class Order
    {
        public List<Product> Products { get; set; };
        public List<int> Quantities { get; set; };
        public float Cost { get; set; };
    }
}
