using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler 
        : IRequestHandler<GetProductsListQuery, ProductsListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductsListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductsListVm> Handle(GetProductsListQuery request, 
            CancellationToken cancellationToken)
        {
            var productQuery = await _dbContext.Product
                .ProjectTo<ProductsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductsListVm { Products = productQuery };
        }
    }
}
