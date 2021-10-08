using ProductSQRS.ViewModel.UserViewModel;
using System.Threading.Tasks;

namespace ProductSQRS.ConnectAPI.UserCnAPI
{
    public interface IUserConnectAPI
    {
        Task<string> Authen(AuthenticationRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
