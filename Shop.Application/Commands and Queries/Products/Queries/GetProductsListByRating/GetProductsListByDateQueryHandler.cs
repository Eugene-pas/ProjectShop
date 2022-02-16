using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Products.Queries.GetProductsList;
using System.Linq;


namespace Shop.Application.Commands_and_Queries.Products.Queries.GetProductsListByRating
{
    public class GetProductsListByRatingQueryHandler
        : IRequestHandler<GetProductsListByRatingQuery, ProductsListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;

        public GetProductsListByRatingQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductsListVm> Handle(GetProductsListByRatingQuery request, CancellationToken cancellationToken)
        {
            var productQuery = await _dbContext.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)
                .ProjectTo<ProductsLookupDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Rating)
                .ToListAsync(cancellationToken);

            return new ProductsListVm { Products = productQuery };
        }
    }
}
