using Newtonsoft.Json;
using ProductSQRS.API.Entity;
using ProductSQRS.API.EventRequest;
using ProductSQRS.API.EventVm;
using ProductSQRS.API.EventVMRequest;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static ProductSQRS.API.EventRequest.Event;

namespace ProductSQRS.ConnectAPI.ProductCnAPI
{
    public class ProductConnectAPI : IProductConnectAPI
    {
        private readonly HttpClient _httpClient;
        public ProductConnectAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var list = await _httpClient.GetFromJsonAsync<List<Product>>("/api/Product/GetAllProduct");
            return list;
        }

        public async Task<Dictionary<int, IList<Event.IEvent>>> GetAllEventById(int Id)
        {
            var list = await _httpClient.PostAsJsonAsync("/api/Product/GetById",Id);
            var read = await list.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Dictionary<int, IList<Event.IEvent>>>(read);
            return result;
        }

        public async Task<bool> AddRecive(CreateRecive request)
        {
            var list = await _httpClient.PostAsJsonAsync("/api/Product/AddEventRecive", request);
            return list.IsSuccessStatusCode;
        }

        public async Task<bool> AddSend(CreateSend request)
        {
            var list = await _httpClient.PostAsJsonAsync("/api/Product/AddEventSend", request);
            return list.IsSuccessStatusCode;
        }

        public async Task<bool> AddAdjusted(CreateAdjused request)
        {
            var list = await _httpClient.PostAsJsonAsync("/api/Product/AddEventAdjusted", request);
            return list.IsSuccessStatusCode;
        }

        public async Task<List<EventViewModel>> GetAllById(int Id)
        {
            var list = await _httpClient.PostAsJsonAsync("/api/Product/GetByIdViewModel", Id);
            var listRead = await list.Content.ReadAsStringAsync();
            var read = JsonConvert.DeserializeObject<List<EventViewModel>>(listRead);
            return read;
        }
    }
}
