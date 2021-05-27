using System.Collections.Generic;

namespace restaurant
{
    // This class represents the stock
    // of products the restaurant has.
    class Inventory
    {
        // Attributes
        public int ID { get;, set; }
        public List<Product> Products { get;, set; };
        public List<int> ProductQuantities { get;, set; };
    }
}