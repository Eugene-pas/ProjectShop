using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shop.Application.Commands.Products.Queries.GetProductsList;
using Shop.Application.Common.Pagination;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByRating
{
    public class GetProductsListByRatingQueryHandler
        : IRequestHandler<GetProductsListByRatingQuery, ProductPaginatedVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;
        public GetProductsListByRatingQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductPaginatedVm> Handle(GetProductsListByRatingQuery request, CancellationToken cancellationToken)
        {
            var productQuery = _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Where(x => x.Category.Id == request.CategoryId)
                .OrderBy(x => x.Review.Sum(x => x.Rating))
                .ProjectTo<ProductsLookupDto>(_mapper.ConfigurationProvider);
               

            var paginatedList = await PaginatedList<ProductsLookupDto>
                .CreateAsync(productQuery, request.PageNumber, request.PageSize);

            return new ProductPaginatedVm
            {
                Products = paginatedList,
                Page = paginatedList.PageIndex,
                TotalPagesAmount = paginatedList.TotalPages,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }
    }
}
