using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Products.Queries.GetProductsList;
using System.Linq;

namespace Shop.Application.Commands_and_Queries.Products.Queries.GetProductsListByPrice
{
    public class GetProductsListByPriceQueryHandler
        : IRequestHandler<GetProductsListByPriceQuery, ProductsListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;

        public GetProductsListByPriceQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductsListVm> Handle(GetProductsListByPriceQuery request, CancellationToken cancellationToken)
        {
            var productQuery = await _dbContext.Product
                .ProjectTo<ProductsLookupDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Price)
                .ToListAsync(cancellationToken);

            return new ProductsListVm { Products = productQuery };
        }
    }
}
