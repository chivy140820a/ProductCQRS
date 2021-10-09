using ProductSQRS.API.Constant;

namespace ProductSQRS.API.EventVMRequest
{
    public class EventViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Common Common { get; set; }
    }
}
