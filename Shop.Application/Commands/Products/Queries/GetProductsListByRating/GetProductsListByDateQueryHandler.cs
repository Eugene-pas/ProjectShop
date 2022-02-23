using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Common.Pagination;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByRating
{
    public class GetProductsListByRatingQueryHandler
        : IRequestHandler<GetProductsListByRatingQuery, ProductPaginatedVm>
    {
        private readonly IDataBaseContext _dbContext;

        public GetProductsListByRatingQueryHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ProductPaginatedVm> Handle(GetProductsListByRatingQuery request, CancellationToken cancellationToken)
        {
            var productQuery = _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Where(x => x.Category.Id == request.CategoryId)
                .OrderBy(x => x.Rating);

            var paginatedList = await PaginatedList<Product>
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
