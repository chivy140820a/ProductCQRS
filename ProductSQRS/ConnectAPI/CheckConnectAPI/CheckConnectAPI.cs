using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductSQRS.ConnectAPI.CheckConnectAPI
{
    public class CheckConnectAPI : ICheckConnectAPI
    {
        private readonly HttpClient _httpClient;
        public CheckConnectAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }    
        public async Task<bool> Check(string username)
        {
            var check = await _httpClient.PostAsJsonAsync("/api/Requit/Author", username);
            var read = await check.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(read);
            return result;

        }
    }
}
