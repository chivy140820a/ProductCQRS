using System.Threading.Tasks;

namespace ProductSQRS.ConnectAPI.CheckConnectAPI
{
    public interface ICheckConnectAPI
    {
        Task<bool> Check(string username);
    }
}
