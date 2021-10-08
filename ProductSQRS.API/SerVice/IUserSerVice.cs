using ProductSQRS.ViewModel.UserViewModel;
using System.Threading.Tasks;

namespace ProductSQRS.API.SerVice
{
    public interface IUserSerVice
    {
        Task<bool> Register(RegisterRequest request);
        Task<string> Authentication(AuthenticationRequest request);
    }
}
