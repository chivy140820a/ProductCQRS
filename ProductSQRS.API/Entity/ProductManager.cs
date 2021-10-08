using ProductSQRS.API.Constant;

namespace ProductSQRS.API.Entity
{
    public class ProductManager
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Common Common { get; set; }
        public int Quantity { get; set; }
    }
}
