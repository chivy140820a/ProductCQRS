using System.Threading.Tasks;

namespace ProductSQRS.API.SerVice.RequitmentSV
{
    public interface IRequitmentSerVice
    {
        public Task<bool> Author(string UserName);
    }
}
