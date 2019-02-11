using FileHelpers;

namespace Cignium.EL
{
    [DelimitedRecord(",")]
    public class Product
    {
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }   
    }
}
