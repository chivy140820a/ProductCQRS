using Microsoft.AspNetCore.Components;
using ProductSQRS.API.SerVice;
using ProductSQRS.ConnectAPI.UserCnAPI;
using ProductSQRS.ViewModel.UserViewModel;
using System.Threading.Tasks;

namespace ProductSQRS.Pages
{
    public partial class HomeBase
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IUserConnectAPI usetconnenctAPI { get; set; }
        public AuthenticationRequest authen { get; set; } = new AuthenticationRequest();
        
        public async Task Take()
        {
            var autheti = new AuthenticationRequest()
            {
                UserName = "Admin123",
                Password = "Admin123@123",
                RememberMe = true
            };
            var authen = await usetconnenctAPI.Authen(autheti);
            navigationManager.NavigateTo(authen);
        }
    }
}
