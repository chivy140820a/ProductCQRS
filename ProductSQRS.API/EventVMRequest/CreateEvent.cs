using static ProductSQRS.API.EventRequest.Event;

namespace ProductSQRS.API.EventVMRequest
{
    public class CreateEvent
    {
        public IEvent IEvent { get; set; }
        public int Id { get; set; }
    }
}
