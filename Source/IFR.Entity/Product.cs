namespace IFR.Entity
{
    // This class is a representation
    // of an ingredient of a dish.
    public class Product
    {
        // Attributes
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Complexity { get; set; }
    }
}
