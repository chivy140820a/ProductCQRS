using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ProductSQRS.ViewModel.UserViewModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductSQRS.ConnectAPI.UserCnAPI
{
    public class UserConnectAPI : IUserConnectAPI
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ISessionStorageService _sessionStorageService;
        private readonly HttpClient _httpClient;
        public UserConnectAPI(HttpClient httpClient, ISessionStorageService sessionStorageService,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _sessionStorageService = sessionStorageService;
            _httpClient = httpClient;
        }    
        public async Task<string> Authen(AuthenticationRequest request)
        {
            string res = "/Home";
            var token = await _httpClient.PostAsJsonAsync("/api/User/Authen", request);
            var tokenstring = await token.Content.ReadAsStringAsync();

            await _sessionStorageService.SetItemAsync("authToken", tokenstring);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(request.UserName);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenstring);
            return res;
        }
        public Task<bool> Register(RegisterRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
