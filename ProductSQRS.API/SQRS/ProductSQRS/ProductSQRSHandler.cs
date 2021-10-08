using MediatR;
using ProductSQRS.API.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSQRS.API.SQRS.ProductSQRS
{
    public static class ProductSQRSHandler
    {
        public record Query(int Id) :IRequest<Respond>;
        public class Handler : IRequestHandler<Query, Respond>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Respond> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id);
                var res = new Respond(product.Id, product.Name, product.Price, product.LastPrice);
                return res;
            }
        }

        public record Respond(int Id ,string Name,decimal Price,decimal LastPrice);
         
    }
}
