using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductSQRS.API.Data;
using ProductSQRS.API.Entity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSQRS.API.SQRS.ProductSQRS
{
    public static class GetAllProductSQRS
    {
        public record Query():IRequest<List<Product>>;
        public class Handler : IRequestHandler<Query, List<Product>>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }    
            public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                var list = await _context.Products.ToListAsync();
                return list;
            }
        }
    }
}
