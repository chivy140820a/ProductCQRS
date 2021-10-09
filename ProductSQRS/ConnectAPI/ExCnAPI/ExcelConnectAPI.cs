using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductSQRS.ConnectAPI.ExCnAPI
{
    public class ExcelConnectAPI : IExcelConnectAPI
    {
        private readonly HttpClient _httpClient;
        public ExcelConnectAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Create(string pathimage)
        {
            var list = await _httpClient.PostAsJsonAsync("/api/Excel/Create", pathimage);
            return list.IsSuccessStatusCode;
        }
    }
}
