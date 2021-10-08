using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductSQRS.API.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSQRS.API.SQRS.ProductSQRS
{
    public class RepositorySQRS<T> where T:class
    {
        public record Query():IRequest<List<T>>;
        public class Handler : IRequestHandler<Query, List<T>>
        {
            private readonly ApplicationDbContext _context;
            public DbSet<T> table = null;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
                table = _context.Set<T>();
            }    
            public async Task<List<T>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await table.ToListAsync();
            }
        }
    }
}
