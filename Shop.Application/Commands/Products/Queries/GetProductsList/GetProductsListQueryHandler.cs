using System.Linq;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using MediatR.Wrappers;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler 
        : IRequestHandler<GetProductsListQuery, ProductsListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;
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
