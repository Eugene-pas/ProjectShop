using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsList;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByRating
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
                .Include(x => x.Seller)
                .Where(x => x.Category.Id == request.CategoryId)
                .OrderBy(x => x.Rating)
                .ToListAsync(cancellationToken);

            return new ProductsListVm { Products = productQuery };
        }
    }
}
