using System.Linq;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler 
        : IRequestHandler<GetProductsListQuery, ProductsListVm>
    {
        private readonly IDataBaseContext _dbContext;

        public GetProductsListQueryHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ProductsListVm> Handle(GetProductsListQuery request, 
            CancellationToken cancellationToken)
        {
            var productQuery = await _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .ToListAsync(cancellationToken);
            return new ProductsListVm { Products = productQuery };
        }
    }
}
