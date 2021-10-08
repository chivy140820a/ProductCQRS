using ProductSQRS.API.Constant;

namespace ProductSQRS.API.EventRequest
{
    public class Event
    {
        public interface IEvent { };
        public record Recive(int productid,int quantity,Common Common): IEvent;
        public record Send(int productid,int quantity, Common Common) : IEvent;
        public record Adjusted(int productid,int quantity,string reason, Common Common) : IEvent;
    }
}
