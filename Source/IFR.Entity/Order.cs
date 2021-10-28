using System.Collections.Generic;

namespace IFR.Entity
{
    public class Order
    {
        public string Customer { get; set; }
        public long Id { get; set; }
        public List<Product> Products { get; set; }
        public List<int> Quantities { get; set; }
        public float Cost { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int Complexity { get; set; }
    }
}
