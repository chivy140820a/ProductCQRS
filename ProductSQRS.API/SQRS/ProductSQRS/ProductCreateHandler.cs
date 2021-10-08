using MediatR;
using ProductSQRS.API.Data;
using ProductSQRS.API.Entity;
using ProductSQRS.ViewModel.ProductVM;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSQRS.API.SQRS.ProductSQRS
{
    public class ProductCreateHandler
    {
        public record QueryCreateProduct(CreateProduct request) :IRequest<Response>;
        public class ProductHandler : IRequestHandler<QueryCreateProduct, Response>
        {
            private readonly ApplicationDbContext _context;
            public ProductHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Response> Handle(QueryCreateProduct request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    Name = request.request.Name,
                    Price = request.request.Price,
                    LastPrice = request.request.LastPrice
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                var res = new Response(product.Id, product.Name, product.Price, product.LastPrice);
                return res;
            }
        }

        public record Response(int Id,string Name,decimal Price,decimal LastPrice);
    }
}
