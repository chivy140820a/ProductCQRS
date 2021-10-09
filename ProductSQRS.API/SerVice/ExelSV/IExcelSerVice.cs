using System.Threading.Tasks;

namespace ProductSQRS.API.SerVice.ExelSV
{
    public interface IExcelSerVice
    {
        Task<int> ImportExcel(string Thumimage);
    }
}
