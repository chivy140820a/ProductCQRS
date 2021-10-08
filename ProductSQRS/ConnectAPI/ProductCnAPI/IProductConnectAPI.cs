using ProductSQRS.API.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ProductSQRS.API.EventRequest.Event;
using ProductSQRS.API.EventVMRequest;
using ProductSQRS.API.EventVm;

namespace ProductSQRS.ConnectAPI.ProductCnAPI
{
    public interface IProductConnectAPI
    {
        Task<List<Product>> GetAllProduct();
       
        Task<Dictionary<int, IList<IEvent>>> GetAllEventById(int Id);
        Task<bool> AddRecive(CreateRecive request);
        Task<bool> AddSend(CreateSend request);
        Task<bool> AddAdjusted(CreateAdjused request);
    }

}
