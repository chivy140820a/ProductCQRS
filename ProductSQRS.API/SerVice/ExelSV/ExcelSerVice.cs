using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using ProductSQRS.API.Data;
using ProductSQRS.API.Entity;
using System.IO;
using System.Threading.Tasks;

namespace ProductSQRS.API.SerVice.ExelSV
{
    public class ExcelSerVice : IExcelSerVice
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public ExcelSerVice(ApplicationDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<int> ImportExcel(string Thumimage)
        {
            using (var package = new ExcelPackage(new FileInfo(Thumimage)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                Product product;
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    product = new Product();
                    product.Name = workSheet.Cells[i, 1].Value.ToString();
                    decimal.TryParse(workSheet.Cells[i, 2].Value.ToString(), out var price);
                    product.Price = price;
                    decimal.TryParse(workSheet.Cells[i, 3].Value.ToString(), out var lastPrice);
                    product.LastPrice = lastPrice;
                    _context.Products.Add(product);
                }
            }
            return await _context.SaveChangesAsync();
        }
    }
}
