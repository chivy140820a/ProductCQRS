using System.Threading.Tasks;

namespace ProductSQRS.ConnectAPI.ExCnAPI
{
    public interface IExcelConnectAPI
    {
        Task<bool> Create(string pathimage);
    }
}
